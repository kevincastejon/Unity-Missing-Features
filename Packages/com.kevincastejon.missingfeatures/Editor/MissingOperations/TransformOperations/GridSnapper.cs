using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingOperations
{
    public class GridSnapper : Editor
    {
        [MenuItem("GameObject/Missing Operations/Snap To Grid")]
        private static void SnapToGrid()
        {
            GameObject[] selecteds = Selection.GetFiltered<GameObject>(SelectionMode.ExcludePrefab);
            foreach (GameObject selected in selecteds)
            {
                Undo.RecordObject(selected.transform, "Snap object to grid");
                Vector3 newPos = Vector3.zero;
                newPos.x = (float)Math.Round(selected.transform.localPosition.x / EditorSnapSettings.gridSize.x) * EditorSnapSettings.gridSize.x;
                newPos.y = (float)Math.Round(selected.transform.localPosition.y / EditorSnapSettings.gridSize.y) * EditorSnapSettings.gridSize.y;
                newPos.z = (float)Math.Round(selected.transform.localPosition.z / EditorSnapSettings.gridSize.z) * EditorSnapSettings.gridSize.z;
                selected.transform.localPosition = newPos;
            }
        }
    }
}
