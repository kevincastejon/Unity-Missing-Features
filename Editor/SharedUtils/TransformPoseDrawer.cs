using KevinCastejon.MissingFeatures.SharedUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(TransformData))]
public class TransformPoseDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return property.isExpanded ? EditorGUIUtility.singleLineHeight * 6 : EditorGUIUtility.singleLineHeight;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect rect = position;
        rect.height = property.isExpanded ? rect.height / 6f : rect.height;
        SerializedProperty _reference = property.FindPropertyRelative("_reference");
        SerializedProperty _parent = property.FindPropertyRelative("_parent");
        SerializedProperty _position = property.FindPropertyRelative("_position");
        SerializedProperty _rotation = property.FindPropertyRelative("_rotation");
        SerializedProperty _scale = property.FindPropertyRelative("_scale");
        property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label);
        rect.y += rect.height;
        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;
            EditorGUI.BeginChangeCheck();
            _reference.objectReferenceValue = EditorGUI.ObjectField(rect, new GUIContent("Reference (optional)"), _reference.objectReferenceValue, typeof(Transform), true);
            if (EditorGUI.EndChangeCheck() && _reference.objectReferenceValue)
            {
                Transform transform = (Transform)_reference.objectReferenceValue;
                _parent.objectReferenceValue = transform.parent;
                _position.vector3Value = transform.localPosition;
                _rotation.quaternionValue = transform.localRotation;
                _scale.vector3Value = transform.localScale;
            }
            rect.y += rect.height;
            EditorGUI.BeginDisabledGroup(_reference.objectReferenceValue != null);
            EditorGUI.PropertyField(rect, _parent);
            rect.y += rect.height;
            EditorGUI.PropertyField(rect, _position);
            rect.y += rect.height;
            _rotation.quaternionValue = Quaternion.Euler(EditorGUI.Vector3Field(rect, _rotation.displayName, _rotation.quaternionValue.eulerAngles));
            rect.y += rect.height;
            EditorGUI.PropertyField(rect, _scale);
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;
        }
    }
}
