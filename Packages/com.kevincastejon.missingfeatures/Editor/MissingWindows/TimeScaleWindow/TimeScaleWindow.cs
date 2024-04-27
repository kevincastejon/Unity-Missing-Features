using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    internal class TimeScaleWindow : EditorWindow
    {
        private struct ButtonInfo
        {
            private string _label;
            private float _value;
            internal string Label { get => _label; }
            internal float Value { get => _value; }
            internal ButtonInfo(string label, float value)
            {
                _label = label;
                _value = value;
            }
        }
        private static readonly ButtonInfo[][] ButtonsGroup = new ButtonInfo[4][] {
            new ButtonInfo[3] { new ButtonInfo("0.5", 0.5f), new ButtonInfo("1", 1f), new ButtonInfo("2", 2f) },
            new ButtonInfo[5] { new ButtonInfo("0.1", 0.1f), new ButtonInfo("0.5", 0.5f), new ButtonInfo("1", 1f), new ButtonInfo("2", 2f),new ButtonInfo("4", 4f) },
            new ButtonInfo[7] { new ButtonInfo("0.01", 0.01f), new ButtonInfo("0.1", 0.1f), new ButtonInfo("0.5", 0.5f), new ButtonInfo("1", 1f), new ButtonInfo("2", 2f),new ButtonInfo("4", 4f), new ButtonInfo("8", 8f) },
            new ButtonInfo[9] { new ButtonInfo("0", 0f), new ButtonInfo("0.01", 0.01f), new ButtonInfo("0.1", 0.1f), new ButtonInfo("0.5", 0.5f), new ButtonInfo("1", 1f), new ButtonInfo("2", 2f), new ButtonInfo("4", 4f), new ButtonInfo("8", 8f), new ButtonInfo("10", 10f) }
        };
        private static readonly List<float> ButtonsMapping = new List<float> { 0f, 192f, 268f, 345f };
        private SerializedObject _timeManager;
        private SerializedProperty _timeScale;
        [SerializeField] private float _step;

        [MenuItem("Window/Unity Missing Windows/TimeScale Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(TimeScaleWindow));
            window.titleContent = new GUIContent("TimeScale");
        }
        private void OnEnable()
        {
            _timeManager = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>("ProjectSettings/TimeManager.asset"));
            _timeScale = _timeManager.FindProperty("m_TimeScale");
        }
        private void OnGUI()
        {
            _timeManager.Update();
            EditorGUI.BeginChangeCheck();
            float newValue = EditorGUILayout.Slider(_timeScale.floatValue, 0f, 10f);
            if (EditorGUI.EndChangeCheck())
            {
                _timeScale.floatValue = newValue;
            }
            EditorGUILayout.BeginHorizontal();
            ButtonInfo[] buttons = ButtonsGroup[ButtonsMapping.FindLastIndex(x => position.width > x)];
            for (int i = 0; i < buttons.Length; i++)
            {
                Color colorBkp = GUI.color;
                if (Mathf.Approximately(_timeScale.floatValue, buttons[i].Value))
                {
                    GUI.color = Color.grey;
                }
                if (GUILayout.Button(buttons[i].Label.ToString(), position.width > 350f ? new GUILayoutOption[] { GUILayout.Height(35f) }: new GUILayoutOption[] { GUILayout.Height(35f), GUILayout.Width(35f) }))
                {
                    _timeScale.floatValue = buttons[i].Value;
                }
                GUI.color = colorBkp;
            }
            EditorGUILayout.EndHorizontal();
            _timeManager.ApplyModifiedProperties();
        }
    }
}
