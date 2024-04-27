using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(HideOnPlayAttribute))]
    public class HideOnPlayDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            HideOnPlayAttribute att = (HideOnPlayAttribute)attribute;
            bool hidden = att.invert ? !Application.isPlaying : Application.isPlaying;
            return hidden ? 0f : base.GetPropertyHeight(property, label);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            HideOnPlayAttribute att = (HideOnPlayAttribute)attribute;
            bool hidden = att.invert ? !Application.isPlaying : Application.isPlaying;
            if (!hidden)
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}