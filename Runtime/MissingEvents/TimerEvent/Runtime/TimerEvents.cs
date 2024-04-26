using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    public class TimerEvents : MonoBehaviour
    {
        [SerializeField] private Timer _timer = default;
        [SerializeField] private bool _autoStart = true;
        [SerializeField] private float _progress;
        [SerializeField] private int _currentCount;
        [SerializeField] private bool _isStarted;
        [SerializeField] private bool _isCompleted;
        public float Duration { get => _timer.Duration; set => _timer.Duration = value; }
        public float ElapsedTime { get => _timer.ElapsedTime; }
        public float Progress { get => _progress; }
        public int Count { get => _timer.Count; set => _timer.Count = value; }
        public int CurrentCount { get => _currentCount; }
        public UnityEvent<int> OnTime { get => _timer.OnTime; }
        public UnityEvent<float> OnProgress { get => _timer.OnProgress; }
        public UnityEvent<float, int> OnProgressWithCount { get => _timer.OnProgressWithCount; }
        public UnityEvent<int> OnComplete { get => _timer.OnComplete; }
        public bool IsStarted { get => _isStarted; }
        public bool IsCompleted { get => _isCompleted; }

        private void Start()
        {
            if (_autoStart)
            {
                _timer.Play();
            }
        }
        private void Update()
        {
            _timer.Update(Time.deltaTime);
            _progress = _timer.Progress;
            _currentCount = _timer.CurrentCount;
            _isStarted = _timer.IsStarted;
            _isCompleted = _timer.IsCompleted;
        }

        [ContextMenu("Play")]
        public void Play()
        {
            _timer.Play();
        }
        [ContextMenu("Stop")]
        public void Stop()
        {
            _timer.Stop();
        }
        [ContextMenu("Clear")]
        public void Clear()
        {
            _timer.Clear();
        }
    }
}
