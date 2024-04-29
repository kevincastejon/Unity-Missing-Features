using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(ShowPropConditionalAttribute))]
    public class ShowPropConditionalDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowPropConditionalAttribute att = (ShowPropConditionalAttribute)attribute;
            bool show = (bool)property.serializedObject.targetObject.GetType().GetMethod(att.boolMethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty).Invoke(property.serializedObject.targetObject, null) == att.isTrue;
            if (show)
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            else return 0f;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowPropConditionalAttribute att = (ShowPropConditionalAttribute)attribute;
            bool show = (bool)property.serializedObject.targetObject.GetType().GetMethod(att.boolMethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty).Invoke(property.serializedObject.targetObject, null) == att.isTrue;
            if (show)
            {
                // On dessine la propri�t�
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
    }
}