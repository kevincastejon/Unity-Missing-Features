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
            bool show = (bool)property.serializedObject.targetObject.GetType().GetMethod(att.boolMethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty).Invoke(property.serializedObject.targetObject, null);
            if (show)
            {
                return base.GetPropertyHeight(property, label);
            }
            else return 0f;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowPropConditionalAttribute att = (ShowPropConditionalAttribute)attribute;
            bool show = (bool)property.serializedObject.targetObject.GetType().GetMethod(att.boolMethodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty).Invoke(property.serializedObject.targetObject, null);
            if (show)
            {
                // On dessine la propriété
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}