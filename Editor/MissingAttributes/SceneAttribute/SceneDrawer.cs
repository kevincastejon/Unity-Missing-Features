using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            List<string> scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes).Select(x => ExtractSceneName(x.path)).ToList();
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogWarning("Scene attribute must be used with 'string' property type");
                base.OnGUI(position, property, label);
                return;
            }
            List<string> scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes).Select(x => ExtractSceneName(x.path)).ToList();
            if (scenes.Count == 0)
            {
                EditorGUI.HelpBox(position, "No scene found into the builds settings!", MessageType.Warning);
                return;
            }
            if (!scenes.Contains(property.stringValue))
            {
                string missingLabel = "<Missing> " + property.stringValue;
                scenes.Insert(0, missingLabel);
                string name = scenes[EditorGUI.Popup(position, label, 0, scenes.Select(x => new GUIContent(x)).ToArray())];
                if (name != missingLabel)
                {
                    property.stringValue = name;
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