using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    public class ScenesExplorerWindow : EditorWindow
    {
        private bool _additive;
        private bool _forceSave;
        private float _size = 50f;
        List<SceneAsset> _scenes; 
        string[] _paths;
        [MenuItem("Window/UnityMissingWindows/Scenes Explorer Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(ScenesExplorerWindow));
            window.titleContent = new GUIContent("Scenes Explorer");
        }
        private void Refresh()
        {
            _paths = AssetDatabase.FindAssets("t:Scene").Select(x => AssetDatabase.GUIDToAssetPath(x)).ToArray();
            _scenes = _paths.Select(x => AssetDatabase.LoadAssetAtPath<SceneAsset>(x)).ToList();
        }
        private void OnEnable()
        {
            Refresh();
        }
        private void OnGUI()
        {
            _additive = EditorGUILayout.ToggleLeft("Additive Loading", _additive);
            if (!_additive)
            {
                _forceSave = EditorGUILayout.ToggleLeft("Force Save Open Scenes", _forceSave);
            }
            _size = GUI.HorizontalSlider(EditorGUILayout.GetControlRect(), _size, 16f, 50f);
            GUIContent refreshLabel = EditorGUIUtility.IconContent("d_Refresh@2x");
            refreshLabel.tooltip = "Refresh";
            if (GUILayout.Button(refreshLabel) || _scenes.FindIndex(x=>x == null)>-1)
            {
                Refresh();
            }
            for (int i = 0; i < _scenes.Count; i++)
            {
                GUIContent label = EditorGUIUtility.IconContent("d_SceneAsset Icon");
                label.tooltip = _scenes[i].name;
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(label, GUILayout.Width(_size), GUILayout.Height(_size)))
                {
                    if (!_additive)
                    {
                        if (_forceSave)
                        {
                            EditorSceneManager.SaveOpenScenes();
                        }
                        else
                        {
                            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                        }
                    }
                    EditorSceneManager.OpenScene(_paths[i], _additive ? OpenSceneMode.Additive : OpenSceneMode.Single);
                }
                EditorGUILayout.LabelField(_scenes[i].name, EditorStyles.boldLabel, GUILayout.Height(_size));
                EditorGUILayout.EndHorizontal();
            }
        }
    }

}