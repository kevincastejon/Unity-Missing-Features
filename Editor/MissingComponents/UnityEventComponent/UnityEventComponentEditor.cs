using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents
{

    [CustomEditor(typeof(UnityEventComponent))]
    public class UnityEventComponentEditor : Editor
    {
        private SerializedProperty _event;

        private UnityEventComponent _script;

        private void OnEnable()
        {
            _event = serializedObject.FindProperty("_event");

            _script = (UnityEventComponent)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_event);
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Fire", GUILayout.Width(50)))
            {
                _script.InvokeEvent();
            }
            EditorGUILayout.Space(10);
            EditorGUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
