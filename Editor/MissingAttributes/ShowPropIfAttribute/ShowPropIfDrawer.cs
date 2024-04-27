using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(ShowPropIfAttribute))]
    public class ShowPropIfDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowPropIfAttribute att = (ShowPropIfAttribute)attribute;
            if (property.serializedObject.FindProperty(att.boolSerializedPropertyName).boolValue == att.isTrue)
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            else return 0f;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowPropIfAttribute att = (ShowPropIfAttribute)attribute;
            if (property.serializedObject.FindProperty(att.boolSerializedPropertyName).boolValue == att.isTrue)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
    }
}