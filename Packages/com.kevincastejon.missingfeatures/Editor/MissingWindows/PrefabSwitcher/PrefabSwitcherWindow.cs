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
        ReorderableList _reorderableList;
        List<GameObject> _prefabsList = new();

        [MenuItem("Window/Unity Missing Windows/Prefab Switcher Window (experimental)", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(PrefabSwitcherWindow));
            window.titleContent = new GUIContent("Prefab Switcher");
        }

        private void OnEnable()
        {
            _reorderableList = new(_prefabsList, typeof(GameObject), false, false, true, true);
            _reorderableList.drawElementCallback += DrawElementCallback;
            _reorderableList.onAddCallback += OnAddCallback;
        }

        private void OnAddCallback(ReorderableList list)
        {
            _prefabsList.Add(null);
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            _prefabsList[index] = (GameObject)EditorGUI.ObjectField(rect, GUIContent.none, _prefabsList[index], typeof(GameObject), false);
        }

        private void OnGUI()
        {
            List<GameObject> selections = Selection.gameObjects.Where(x => !string.IsNullOrEmpty(x.scene.name)).ToList();
            EditorGUILayout.LabelField(new GUIContent(selections.Count + " object(s) selected"));
            _reorderableList.DoLayoutList();
            if (GUILayout.Button("Switch"))
            {
                foreach (var sceneObject in selections)
                {
                    PrefabUtility.ReplacePrefabAssetOfPrefabInstance(sceneObject, _prefabsList[Random.Range(0, _prefabsList.Count)], InteractionMode.UserAction);
                }
            }
        }

        [MenuItem("GameObject/Prefab Switcher (experimental)", false, 10)]
        private static void OpenFromContextMenu()
        {
            EditorWindow window = GetWindow(typeof(PrefabSwitcherWindow));
            window.titleContent = new GUIContent("Prefab Switcher");
        }
    }
}
