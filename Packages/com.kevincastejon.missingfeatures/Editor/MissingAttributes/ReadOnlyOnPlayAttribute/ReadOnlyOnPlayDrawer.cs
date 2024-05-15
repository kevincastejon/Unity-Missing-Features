using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyOnPlayAttribute))]
    public class ReadOnlyOnPlayDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyOnPlayAttribute att = (ReadOnlyOnPlayAttribute)attribute;
            bool rdOnly = att.invert ? !Application.isPlaying : Application.isPlaying;
            if (rdOnly)
            {
                EditorGUI.BeginDisabledGroup(true);
            }

            EditorGUI.PropertyField(position, property, label, true);

            if (rdOnly)
            {
                EditorGUI.EndDisabledGroup();
            }
        }
    }
}