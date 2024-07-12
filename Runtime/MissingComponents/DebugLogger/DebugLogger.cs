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
        [Tooltip("A string to append at the beginning of the log")]
        [SerializeField] private string _preString;
        [Tooltip("A string to append at the end of the log")]
        [SerializeField] private string _postString;

        /// <summary>
        /// A string to append at the beginning of the log
        /// </summary>
        public string PreString { get => _preString; set => _preString = value; }
        /// <summary>
        /// A string to append at the end of the log
        /// </summary>
        public string PostString { get => _postString; set => _postString = value; }

        public void DebugLog(string message)
        {
            Debug.Log(_preString + message + _postString);
        }
        public void DebugLogWarning(string message)
        {
            Debug.LogWarning(_preString + message + _postString);
        }
        public void DebugLogError(string message)
        {
            Debug.LogError(_preString + message + _postString);
        }
        public void DebugLog(float message)
        {
            Debug.Log(_preString + message + _postString);
        }
        public void DebugLog(int message)
        {
            Debug.Log(_preString + message + _postString);
        }
        public void DebugLog(bool message)
        {
            Debug.Log(_preString + message + _postString);
        }
        public void DebugLogWarning(float message)
        {
            Debug.LogWarning(_preString + message + _postString);
        }
        public void DebugLogWarning(int message)
        {
            Debug.LogWarning(_preString + message + _postString);
        }
        public void DebugLogWarning(bool message)
        {
            Debug.LogWarning(_preString + message + _postString);
        }
        public void DebugLogError(float message)
        {
            Debug.LogError(_preString + message + _postString);
        }
        public void DebugLogError(int message)
        {
            Debug.LogError(_preString + message + _postString);
        }
        public void DebugLogError(bool message)
        {
            Debug.LogError(_preString + message + _postString);
        }
    }
}