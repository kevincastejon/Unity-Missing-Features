using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    [CustomEditor(typeof(TimerEvents))]
    public class TimerEventsEditor : Editor
    {
        private SerializedProperty _timer;
        private SerializedProperty _autoStart;
        private SerializedProperty _progress;
        private SerializedProperty _currentCount;
        private SerializedProperty _isStarted;
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
            _isStarted = serializedObject.FindProperty("_isStarted");
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

            EditorGUILayout.PropertyField(_duration, new GUIContent("Duration", "Duration of each cycle"));
            EditorGUILayout.PropertyField(_count, new GUIContent("Count", "Number of cycles. 0 means infinite number of cycles"));
            EditorGUILayout.PropertyField(_autoStart, new GUIContent("Auto Start", "If true the timer plays on Start, otherwise it will plays on the Play() method call"));
            EditorGUILayout.LabelField("Started : " + _isStarted.boolValue + "    IsCompleted : " + _isCompleted.boolValue);
            EditorGUILayout.LabelField("Count : " + _currentCount.intValue + (_count.intValue == 0 ? "" : "/" + _count.intValue) + "    Progress : " + (_progress.floatValue * 100).ToString("F2") + "%");
            Rect rect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);
            EditorGUI.ProgressBar(rect, _progress.floatValue, "Progress");
            EditorGUILayout.PropertyField(_onProgress, new GUIContent("On Progress", "This event will fire on each update. The parameter is the progress between 0f and 1f"));
            EditorGUILayout.PropertyField(_onTime, new GUIContent("On Time", "This event will fire when the timer has done a cycle. The parameter is the current cycle count"));
            EditorGUILayout.PropertyField(_onComplete, new GUIContent("On Complete", "This event will fire when the timer has done the last cycle (note that if Count is set to 0 then this event will never fire). The parameter is the last cycle number"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
