using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    public class TileDuplicatorWindow : EditorWindow
    {
        Vector3Int gridsize;
        [MenuItem("Window/Unity Missing Windows/Tile Duplicator", false, 222)]
        internal static void DuplicateTile()
        {
            EditorWindow window = GetWindow(typeof(TileDuplicatorWindow));
            window.titleContent = new GUIContent("Grid Duplicator");
        }
        private void OnEnable()
        {

        }
        private void OnGUI()
        {
            Vector3Int newGridSize = EditorGUILayout.Vector3IntField("Grid size", gridsize);
            newGridSize.x = Mathf.Max(newGridSize.x, 1);
            newGridSize.y = Mathf.Max(newGridSize.y, 1);
            newGridSize.z = Mathf.Max(newGridSize.z, 1);
            gridsize = newGridSize;
            GameObject selected = Selection.activeGameObject;
            if (selected != null)
            {
                if (GUILayout.Button(new GUIContent("Duplicate tile to make a grid")))
                {
                    for (int i = 0; i < gridsize.z; i++)
                    {
                        for (int j = 0; j < gridsize.y; j++)
                        {
                            for (int k = 0; k < gridsize.x; k++)
                            {
                                if (i == 0 && j == 0 && k == 0)
                                {
                                    continue;
                                }
                                GameObject tile;
                                if (PrefabUtility.IsAnyPrefabInstanceRoot(selected))
                                {
                                    tile = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromSource(selected), selected.transform.parent);
                                    tile.transform.position = selected.transform.position + new Vector3(EditorSnapSettings.gridSize.x * k, EditorSnapSettings.gridSize.y * j, EditorSnapSettings.gridSize.z * i);
                                    tile.transform.rotation = selected.transform.rotation;
                                }
                                else
                                {
                                    tile = Instantiate(selected, selected.transform.position + new Vector3(EditorSnapSettings.gridSize.x * k, EditorSnapSettings.gridSize.y * j, EditorSnapSettings.gridSize.z * i), selected.transform.rotation, selected.transform.parent);
                                }
                                Undo.RegisterCreatedObjectUndo(tile, "Created object");
                                tile.name += "[" + k + " - " + j + " - " + i + "]";
                            }
                        }
                    }
                }
                EditorGUILayout.LabelField(new GUIContent("The cells size are determined by the grid settings " + EditorSnapSettings.gridSize));
            }
            else
            {
                EditorGUILayout.LabelField(new GUIContent("Select a tile to duplicate"));
            }
        }
    }
}
