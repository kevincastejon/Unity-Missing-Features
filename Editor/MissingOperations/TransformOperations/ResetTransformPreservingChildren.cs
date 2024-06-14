using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResetTransformPreservingChildren : Editor
{
    [MenuItem("GameObject/Missing Operations/Reset Transform Preserving Children/Reset Local Transform")]
    private static void ResetLocalPosition()
    {
        GameObject selected = Selection.activeGameObject;
        Undo.RegisterFullObjectHierarchyUndo(selected, "Reset Local Transform Preserving Children");
        GameObject temp = new GameObject();
        temp.transform.parent = selected.transform.parent;
        foreach (Transform child in selected.transform)
        {
            child.SetParent(temp.transform, true);
        }
        selected.transform.localPosition = Vector3.zero;
        foreach (Transform child in temp.transform)
        {
            child.SetParent(selected.transform, true);
        }
        DestroyImmediate(temp);
    }
    [MenuItem("GameObject/Missing Operations/Reset Transform Preserving Children/Reset Global Transform")]
    private static void ResetGlobalPosition()
    {
        GameObject selected = Selection.activeGameObject;
        Undo.RegisterFullObjectHierarchyUndo(selected, "Reset Global Transform Preserving Children");
        GameObject temp = new GameObject();
        foreach (Transform child in selected.transform)
        {
            child.SetParent(temp.transform, true);
        }
        selected.transform.localPosition = Vector3.zero;
        foreach (Transform child in temp.transform)
        {
            child.SetParent(selected.transform, true);
        }
        DestroyImmediate(temp);
    }
}
