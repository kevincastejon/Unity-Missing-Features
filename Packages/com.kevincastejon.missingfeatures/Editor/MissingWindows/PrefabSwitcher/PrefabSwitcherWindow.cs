using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows.Experimental
{
    internal class PrefabSwitcherWindow : EditorWindow
    {
        private PrefabSwitcherList _list;

        [MenuItem("Window/Unity Missing Windows/Prefab Switcher Window (experimental)", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(PrefabSwitcherWindow));
            window.titleContent = new GUIContent("Prefab Switcher");
        }

        //private void OnEnable()
        //{
        //    _reorderableList = new(_prefabsList, typeof(GameObject), false, false, true, true);
        //    _reorderableList.drawElementCallback += DrawElementCallback;
        //    _reorderableList.onAddCallback += OnAddCallback;
        //}

        //private void OnAddCallback(ReorderableList list)
        //{
        //    _prefabsList.Add(null);
        //}

        //private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        //{
        //    _prefabsList[index] = (GameObject)EditorGUI.ObjectField(rect, GUIContent.none, _prefabsList[index], typeof(GameObject), false);
        //}

        private void OnGUI()
        {
            List<GameObject> selections = Selection.gameObjects.Where(x => !string.IsNullOrEmpty(x.scene.name)).ToList();
            EditorGUILayout.BeginHorizontal();
            _list = (PrefabSwitcherList)EditorGUILayout.ObjectField(new GUIContent("Prefab List"), _list, typeof(PrefabSwitcherList), false);
            if (GUILayout.Button(new GUIContent("New", "Create a new PrefabSwitcherList asset")))
            {
                PrefabSwitcherList asset = ScriptableObject.CreateInstance<PrefabSwitcherList>();
                AssetDatabase.CreateAsset(asset, "Assets/NewPrefabSwitcherList.asset");
                AssetDatabase.SaveAssets();
            }
            EditorGUILayout.EndHorizontal();
            if (_list != null)
            {
                Editor.CreateEditor(_list).OnInspectorGUI();
            }
            EditorGUI.BeginDisabledGroup(_list == null || _list.Prefabs.Length == 0 || selections.Count == 0);
            if (GUILayout.Button("Switch"))
            {
                foreach (var sceneObject in selections)
                {
                    PrefabUtility.ReplacePrefabAssetOfPrefabInstance(sceneObject, _list.Prefabs[Random.Range(0, _list.Prefabs.Length)], InteractionMode.UserAction);
                }
            }
            EditorGUI.EndDisabledGroup();
        }

        [MenuItem("GameObject/Prefab Switcher (experimental)", false, 10)]
        private static void OpenFromContextMenu()
        {
            EditorWindow window = GetWindow(typeof(PrefabSwitcherWindow));
            window.titleContent = new GUIContent("Prefab Switcher");
        }
    }
}
