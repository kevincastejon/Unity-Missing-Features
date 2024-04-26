using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogger : MonoBehaviour
{
    public void DebugLog(object message)
    {
        Debug.Log(message);
    }
    public void DebugLogWarning(object message)
    {
        Debug.LogWarning(message);
    }
    public void DebugLogError(object message)
    {
        Debug.LogError(message);
    }
}
