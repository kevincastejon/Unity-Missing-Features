using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyPropIfAttribute))]
    public class ReadOnlyPropIfDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyPropIfAttribute att = (ReadOnlyPropIfAttribute)attribute;
            // Pour désactiver l'UI (rendre en lecture seule)
            EditorGUI.BeginDisabledGroup(property.serializedObject.FindProperty(att.boolSerializedPropertyName).boolValue == att.isTrue);
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}