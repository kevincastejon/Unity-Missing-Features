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
        public void DebugLogWarning(float message)
        {
            Debug.LogWarning(message);
        }
        public void DebugLogWarning(int message)
        {
            Debug.LogWarning(message);
        }
        public void DebugLogWarning(bool message)
        {
            Debug.LogWarning(message);
        }
        public void DebugLogError(float message)
        {
            Debug.LogError(message);
        }
        public void DebugLogError(int message)
        {
            Debug.LogError(message);
        }
        public void DebugLogError(bool message)
        {
            Debug.LogError(message);
        }
    }
}