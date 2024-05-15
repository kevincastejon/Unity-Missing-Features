using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(LayerAttribute))]
    class LayerAttributeEditor : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                Debug.LogWarning("Layer attribute must be used with 'int' property type");
                base.OnGUI(position, property, label);
                return;
            }
            property.intValue = EditorGUI.LayerField(position, label, property.intValue);
        }
    }
}