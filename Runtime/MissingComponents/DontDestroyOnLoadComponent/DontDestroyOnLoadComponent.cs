using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadComponent : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
