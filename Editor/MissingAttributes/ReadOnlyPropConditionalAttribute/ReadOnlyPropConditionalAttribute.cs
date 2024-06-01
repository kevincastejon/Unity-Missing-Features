using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyPropConditionalAttribute))]
    public class ReadOnlyPropConditionalDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyPropConditionalAttribute att = (ReadOnlyPropConditionalAttribute)attribute;
            bool readOnly = (bool)property.GetType().GetMethod(att.boolMethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty).Invoke(property, null) == att.isTrue;
            EditorGUI.BeginDisabledGroup(readOnly);
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}