using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(HeaderPlusAttribute))]
    public class HeaderPlusDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            return EditorGUIUtility.singleLineHeight * 1.5f;
        }
        public override void OnGUI(Rect position)
        {
            HeaderPlusAttribute headerIcon = attribute as HeaderPlusAttribute;
            position.yMin += EditorGUIUtility.singleLineHeight * 0.5f;
            position = EditorGUI.IndentedRect(position);
            float originalWidth = position.width;
            position.width = position.height;
            GUI.DrawTexture(position, EditorGUIUtility.Load(headerIcon.iconPath) as Texture2D);
            if (!headerIcon.textIsNull)
            {
                Color previousColor = Color.white;
                if (!headerIcon.colorIsNull)
                {
                    previousColor = EditorStyles.boldLabel.normal.textColor;
                    EditorStyles.boldLabel.normal.textColor = headerIcon.color;
                }
                position.width = originalWidth - position.height - 5;
                position.x += position.height + 5;
                GUI.Label(position, headerIcon.text, EditorStyles.boldLabel);
                if (!headerIcon.colorIsNull)
                {
                    EditorStyles.boldLabel.normal.textColor = previousColor;
                }
            }
        }
    }
}