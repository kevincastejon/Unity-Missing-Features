using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingOperations
{
    public class ResetTransformPreservingChildren : Editor
    {
        [MenuItem("GameObject/Missing Operations/Reset Local Transform Preserving Children")]
        private static void ResetLocalPosition()
        {
            GameObject selected = Selection.activeGameObject;
            Undo.RegisterFullObjectHierarchyUndo(selected, "Reset Local Transform Preserving Children");
            GameObject temp = new GameObject();
            int max = selected.transform.childCount;
            for (int i = 0; i < max; i++)
            {
                selected.transform.GetChild(0).SetParent(temp.transform, true);
            }
            selected.transform.localPosition = Vector3.zero;
            selected.transform.localRotation = Quaternion.identity;
            selected.transform.localScale = Vector3.one;
            for (int i = 0; i < max; i++)
            {
                temp.transform.GetChild(0).SetParent(selected.transform, true);
            }
            DestroyImmediate(temp); 
        }
    }
}
