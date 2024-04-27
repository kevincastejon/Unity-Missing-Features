using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogWarning("Tag attribute must be used with 'string' property type");
                base.OnGUI(position, property, label);
                return;
            }
            if (property.stringValue == "")
            {
                property.stringValue = UnityEditorInternal.InternalEditorUtility.tags[0];
            }
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}