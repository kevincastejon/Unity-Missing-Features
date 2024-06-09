using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    public class QuickAssetsWindow : EditorWindow
    {
        private SerializedObject _so;
        private SerializedProperty _assets;
        private ReorderableList _list;
        private float _size = 50f;
        [MenuItem("Window/Unity Missing Windows/QuickAssets Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(QuickAssetsWindow));
            window.titleContent = new GUIContent("Quick Assets");
        }
        private void OnEnable()
        {
            string[] paths = AssetDatabase.FindAssets("t:QuickAssetsSo").Select(x => AssetDatabase.GUIDToAssetPath(x)).ToArray();
            if (paths.Length == 0)
            {
                AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<QuickAssetsSO>(), "Assets/QuickAssetsList.asset");
                _so = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>("Assets/QuickAssetsList.asset"));
                _assets = _so.FindProperty("_quickAssets");
                InitList();
            }
            else
            {
                _so = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>(paths[0]));
                _assets = _so.FindProperty("_quickAssets");
                InitList();
            }
        }

        private void InitList()
        {
            _list = new ReorderableList(_so, _assets, true, false, true, true);
            _list.elementHeightCallback = ElementHeightCallback;
            _list.onAddCallback = OnAddCallback;
            _list.drawElementCallback = DrawElementCallback;
        }

        private float ElementHeightCallback(int index)
        {
            return _size;
        }

        private void OnGUI()
        {
            _so.Update();
            EditorGUI.BeginChangeCheck();
            _size = GUI.HorizontalSlider(EditorGUILayout.GetControlRect(), _size, 16f, 50f);
            if (EditorGUI.EndChangeCheck())
            {
                InitList();
            }
            EditorGUI.BeginChangeCheck();
            _list.DoLayoutList();
            _so.ApplyModifiedProperties();
        }
        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - (_size + 2f), rect.height), _assets.GetArrayElementAtIndex(index), GUIContent.none);
            EditorGUI.BeginDisabledGroup(_assets.GetArrayElementAtIndex(index).objectReferenceValue == null);
            GUIContent label = EditorGUIUtility.IconContent("d_SearchJump Icon");
            label.tooltip = "Open without selection";
            if (GUI.Button(new Rect(rect.x + (rect.width - _size), rect.y, _size, rect.height), label))
            {
                AssetDatabase.OpenAsset(_assets.GetArrayElementAtIndex(index).objectReferenceValue);
            }
            EditorGUI.EndDisabledGroup();
        }

        private void OnAddCallback(ReorderableList list)
        {
            int index = list.index == -1 ? 0 : _list.index;
            _assets.InsertArrayElementAtIndex(index);
            _assets.GetArrayElementAtIndex(index).objectReferenceValue = null;
            list.Select(index);
        }
    }
}
