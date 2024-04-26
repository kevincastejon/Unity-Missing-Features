using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    [CustomEditor(typeof(PhysicsEvents))]
    public class PhysicsEventsEditor : Editor
    {
        private SerializedProperty _physics2dEvents;
        private SerializedProperty _physics3dEvents;
        private SerializedProperty _useTagFilter;
        private SerializedProperty _tag;

        private void OnEnable()
        {
            _physics2dEvents = serializedObject.FindProperty("_physics2dEvents");
            _physics3dEvents = serializedObject.FindProperty("_physics3dEvents");
            _useTagFilter = serializedObject.FindProperty("_useTagFilter");
            _tag = serializedObject.FindProperty("_tag");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            if (_tag.stringValue == "")
            {
                _tag.stringValue = UnityEditorInternal.InternalEditorUtility.tags[0];
            }
            _useTagFilter.boolValue = EditorGUILayout.Toggle(new GUIContent("Use tag filter"), _useTagFilter.boolValue);
            if (_useTagFilter.boolValue)
            {
                EditorGUI.indentLevel++;
                _tag.stringValue = EditorGUILayout.TagField(new GUIContent("Tag filter"), _tag.stringValue);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.PropertyField(_physics2dEvents);
            EditorGUILayout.PropertyField(_physics3dEvents);
            serializedObject.ApplyModifiedProperties();
        }
    }
}