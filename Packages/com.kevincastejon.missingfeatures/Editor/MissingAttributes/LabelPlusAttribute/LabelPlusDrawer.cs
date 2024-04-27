using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(LabelPlusAttribute))]
    public class LabelPlusDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LabelPlusAttribute labelPlus = attribute as LabelPlusAttribute;
            if (labelPlus.iconPath.Length > 0f)
            {

            float originalWidth = position.width;
            position.width = position.height;
            GUI.DrawTexture(position, EditorGUIUtility.Load(labelPlus.iconPath) as Texture2D);
            position.width = originalWidth - position.height - 5;
            position.x += position.height + 5;
            }

            Color previousColor = EditorStyles.label.normal.textColor;
            if (!labelPlus.colorIsNull)
            {
                previousColor = EditorStyles.label.normal.textColor;
                EditorStyles.label.normal.textColor = labelPlus.color;
            }
            EditorGUI.PropertyField(position, property, labelPlus.textIsNull ? label : new GUIContent(labelPlus.text));
            if (!labelPlus.colorIsNull)
            {
                EditorStyles.label.normal.textColor = previousColor;
            }
        }
    }
}