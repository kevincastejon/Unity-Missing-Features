using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    internal class PhysicsWindow : EditorWindow
    {
        private SerializedObject _physics;
        private SerializedObject _physics2D;
        private SerializedProperty _gravity;
        private SerializedProperty _gravity2D;
        private SerializedProperty defaultMaterial;
        private SerializedProperty defaultMaterial2D;
        private SerializedProperty _queriesHitTrigger;
        private SerializedProperty _queriesHitTrigger2D;
        private bool _is2D;
        [MenuItem("Window/UnityMissingWindows/Physics Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(PhysicsWindow));
            window.titleContent = new GUIContent("Physics");
        }
        private void OnEnable()
        {
            _physics = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>("ProjectSettings/DynamicsManager.asset"));
            _physics2D = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>("ProjectSettings/Physics2DSettings.asset"));
            _gravity = _physics.FindProperty("m_Gravity");
            _gravity2D = _physics2D.FindProperty("m_Gravity");
            defaultMaterial = _physics.FindProperty("m_DefaultMaterial");
            defaultMaterial2D = _physics2D.FindProperty("m_DefaultMaterial");
            _queriesHitTrigger = _physics.FindProperty("m_QueriesHitTriggers");
            _queriesHitTrigger2D = _physics2D.FindProperty("m_QueriesHitTriggers");
        }
        private void OnGUI()
        {
            _physics.Update();
            _physics2D.Update();
            _is2D = GUILayout.Toolbar(_is2D?1:0, new GUIContent[] { new GUIContent("2D", "2D"), new GUIContent("3D", "3D") }) == 0 ? true : false;
            if (_is2D)
            {
                EditorGUILayout.PropertyField(_gravity2D);
                EditorGUILayout.PropertyField(defaultMaterial2D);
                EditorGUILayout.PropertyField(_queriesHitTrigger2D);
            }
            else
            {
                EditorGUILayout.PropertyField(_gravity);
                EditorGUILayout.PropertyField(defaultMaterial);
                EditorGUILayout.PropertyField(_queriesHitTrigger);
            }
            _physics.ApplyModifiedProperties();
            _physics2D.ApplyModifiedProperties();
        }
    }
}
