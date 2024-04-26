using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    [CustomEditor(typeof(KeyOrButtonEvents))]
    public class KeyOrButtonEventsEditor : Editor
    {
        private SerializedProperty _type;
        private SerializedProperty _key;
        private SerializedProperty _virtualButtonName;
        private SerializedProperty _downEvent;
        private SerializedProperty _upEvent;

        private KeyOrButtonEvents _object;

        private void OnEnable()
        {
            _type = serializedObject.FindProperty("_type");
            _key = serializedObject.FindProperty("_key");
            _virtualButtonName = serializedObject.FindProperty("_virtualButtonName");
            _downEvent = serializedObject.FindProperty("_downEvent");
            _upEvent = serializedObject.FindProperty("_upEvent");

            _object = (KeyOrButtonEvents)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_type);
            if ((InputEventType)_type.enumValueIndex == InputEventType.KEYCODE)
            {
                EditorGUILayout.PropertyField(_key);
            }
            else
            {
                EditorGUILayout.PropertyField(_virtualButtonName);
            }
            EditorGUILayout.PropertyField(_downEvent);
            EditorGUILayout.PropertyField(_upEvent);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
