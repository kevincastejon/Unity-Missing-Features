using KevinCastejon.MissingFeatures.SharedUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(TransformData))]
    public class TransformDataDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return property.isExpanded ? (EditorGUIUtility.singleLineHeight * 6)+10 : EditorGUIUtility.singleLineHeight;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect rect = position;
            rect.height = property.isExpanded ? EditorGUIUtility.singleLineHeight : rect.height;
            SerializedProperty _position = property.FindPropertyRelative("_position");
            SerializedProperty _rotation = property.FindPropertyRelative("_rotation");
            SerializedProperty _scale = property.FindPropertyRelative("_scale");
            property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label);
            rect.y += rect.height +2f;
            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUI.BeginChangeCheck();
                Transform transformLocalRef = (Transform)EditorGUI.ObjectField(rect, new GUIContent("Feeder (local)"), null, typeof(Transform), true);
                if (EditorGUI.EndChangeCheck() && transformLocalRef)
                {
                    _position.vector3Value = transformLocalRef.localPosition;
                    _rotation.quaternionValue = transformLocalRef.localRotation;
                    _scale.vector3Value = transformLocalRef.localScale;
                }
                rect.y += rect.height+2f;
                Transform transformGlobalRef = (Transform)EditorGUI.ObjectField(rect, new GUIContent("Feeder (global)"), null, typeof(Transform), true);
                if (EditorGUI.EndChangeCheck() && transformGlobalRef)
                {
                    _position.vector3Value = transformGlobalRef.position;
                    _rotation.quaternionValue = transformGlobalRef.rotation;
                    _scale.vector3Value = transformGlobalRef.localScale;
                }
                rect.y += rect.height+2f;
                EditorGUI.PropertyField(rect, _position);
                rect.y += rect.height+2f;
                _rotation.quaternionValue = Quaternion.Euler(EditorGUI.Vector3Field(rect, _rotation.displayName, _rotation.quaternionValue.eulerAngles));
                rect.y += rect.height+2f;
                EditorGUI.PropertyField(rect, _scale);
                EditorGUI.indentLevel--;
            }
        }
    }
}
