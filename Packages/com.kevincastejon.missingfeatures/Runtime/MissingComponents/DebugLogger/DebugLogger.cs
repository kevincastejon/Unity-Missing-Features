using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingComponents
{
    /// <summary>
    /// A component with public methods that you can plug to UnityEvents callback to debug events firing
    /// </summary>
    public class DebugLogger : MonoBehaviour
    {
        public void DebugLog(string message)
        {
            Debug.Log(message);
        }
        public void DebugLogWarning(string message)
        {
            Debug.LogWarning(message);
        }
        public void DebugLogError(string message)
        {
            Debug.LogError(message);
        }
        public void DebugLog(object message)
        {
            Debug.Log(message);
        }
        public void DebugLog(float message)
        {
            Debug.Log(message);
        }
        public void DebugLog(int message)
        {
            Debug.Log(message);
        }
        public void DebugLog(bool message)
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
}