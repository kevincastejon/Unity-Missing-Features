using KevinCastejon.MissingFeatures.SharedUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(LightData))]
    public class LightDataDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return property.isExpanded ? (EditorGUIUtility.singleLineHeight * 7)+10 : EditorGUIUtility.singleLineHeight;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect rect = position;
            rect.height = property.isExpanded ? EditorGUIUtility.singleLineHeight : rect.height;
            SerializedProperty _color = property.FindPropertyRelative("_color");
            SerializedProperty _intensity = property.FindPropertyRelative("_intensity");
            SerializedProperty _range = property.FindPropertyRelative("_range");
            SerializedProperty _spotAngle = property.FindPropertyRelative("_spotAngle");
            property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label);
            rect.y += rect.height +2f;
            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUI.BeginChangeCheck();
                Light lightRef = (Light)EditorGUI.ObjectField(rect, new GUIContent("Feeder"), null, typeof(Light), true);
                if (EditorGUI.EndChangeCheck() && lightRef)
                {
                    _color.colorValue = lightRef.color;
                    _intensity.floatValue = lightRef.intensity;
                    _range.floatValue = lightRef.range;
                    _spotAngle.floatValue = lightRef.spotAngle;
                }
                rect.y += rect.height+2f;
                EditorGUI.PropertyField(rect, _color);
                rect.y += rect.height+2f;
                EditorGUI.PropertyField(rect, _intensity);
                rect.y += rect.height+2f;
                EditorGUI.PropertyField(rect, _range);
                rect.y += rect.height+2f;
                _spotAngle.floatValue = EditorGUI.Slider(rect, new GUIContent("Spot Angle", "Spot Angle"),_spotAngle.floatValue, 0f, 180f);
                EditorGUI.indentLevel--;
            }
        }
    }
}
