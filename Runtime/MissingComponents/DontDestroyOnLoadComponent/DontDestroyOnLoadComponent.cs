using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A component that places its related gameobject into the DontDestroyOnLoad scene on Start.
/// </summary>
public class DontDestroyOnLoadComponent : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
