using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogWarning("Scene attribute must be used with 'string' property type");
                base.OnGUI(position, property, label);
                return;
            }
            List<string> scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes).Select(x => ExtractSceneName(x.path)).ToList();
            bool allowMissing = (attribute as SceneAttribute).allowMissing;
            if (!scenes.Contains(property.stringValue))
            {
                if (property.stringValue != "" && allowMissing)
                {
                    scenes.Insert(0, "<Missing>");
                    string name = scenes[EditorGUI.Popup(position, label, 0, scenes.Select(x => new GUIContent(x)).ToArray())];
                    property.stringValue = name == "<Missing>" ? property.stringValue : name;
                }
                else
                {
                    property.stringValue = scenes[0];
                    property.stringValue = scenes[EditorGUI.Popup(position, label, 0, scenes.Select(x => new GUIContent(x)).ToArray())];
                }
            }
            else
            {
                property.stringValue = scenes[EditorGUI.Popup(position, label, scenes.IndexOf(property.stringValue), scenes.Select(x => new GUIContent(x)).ToArray())];
            }
        }

        private string ExtractSceneName(string scenePath)
        {
            int indexOfLastSlash = scenePath.LastIndexOf("/") + 1;
            int indexOfExtension = scenePath.LastIndexOf(".unity") - indexOfLastSlash;
            return (scenePath.Substring(indexOfLastSlash, indexOfExtension));
        }
    }
}