using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    [CustomEditor(typeof(TimerEvent))]
    public class TimerEventsEditor : Editor
    {
        private SerializedProperty _timer;
        private SerializedProperty _autoStart;
        private SerializedProperty _progress;
        private SerializedProperty _currentCount;
        private SerializedProperty _isRunning;
        private SerializedProperty _isCompleted;

        private SerializedProperty _duration;
        private SerializedProperty _count;
        private SerializedProperty _onProgress;
        private SerializedProperty _onTime;
        private SerializedProperty _onComplete;

        private void OnEnable()
        {
            _timer = serializedObject.FindProperty("_timer");
            _autoStart = serializedObject.FindProperty("_autoStart");
            _progress = serializedObject.FindProperty("_progress");
            _currentCount = serializedObject.FindProperty("_currentCount");
            _isRunning = serializedObject.FindProperty("_isRunning");
            _isCompleted = serializedObject.FindProperty("_isCompleted");

            _duration = _timer.FindPropertyRelative("_duration");
            _count = _timer.FindPropertyRelative("_count");
            _onProgress = _timer.FindPropertyRelative("_onProgress");
            _onTime = _timer.FindPropertyRelative("_onTime");
            _onComplete = _timer.FindPropertyRelative("_onComplete");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_duration);
            EditorGUILayout.PropertyField(_count);
            EditorGUILayout.PropertyField(_autoStart);
            EditorGUILayout.LabelField("Running : " + _isRunning.boolValue + "    IsCompleted : " + _isCompleted.boolValue);
            EditorGUILayout.LabelField("Count : " + _currentCount.intValue + (_count.intValue == 0 ? "" : "/" + _count.intValue) + "    Progress : " + (_progress.floatValue * 100).ToString("F2") + "%");
            Rect rect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);
            EditorGUI.ProgressBar(rect, _progress.floatValue, "Progress");
            EditorGUILayout.PropertyField(_onProgress);
            EditorGUILayout.PropertyField(_onTime);
            EditorGUILayout.PropertyField(_onComplete);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
