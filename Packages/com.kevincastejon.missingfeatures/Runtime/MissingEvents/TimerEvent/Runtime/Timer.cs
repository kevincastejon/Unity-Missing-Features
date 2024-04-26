using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    [System.Serializable]
    public class Timer
    {
        [Min(0.01f)][SerializeField] private float _duration = 1f;
        [Min(0)][SerializeField] private int _count = 1;

        [SerializeField] private UnityEvent<float> _onProgress = new UnityEvent<float>();
        [SerializeField] private UnityEvent<int> _onTime = new UnityEvent<int>();
        [SerializeField] private UnityEvent<int> _onComplete = new UnityEvent<int>();
        private UnityEvent<float, int> _onProgressWithCount = new UnityEvent<float, int>();
        private float _elapsedTime = 0f;
        private int _currentCount = 0;
        private bool _isStarted;
        private bool _isCompleted;

        public Timer()
        {
            _duration = 1f;
            _count = 1;
        }

        public Timer(float duration)
        {
            _duration = duration;
        }
        public Timer(int count)
        {
            _count = count;
        }
        public Timer(float duration = 1f, int count = 1)
        {
            _duration = duration;
            _count = count;
        }


        public float Duration { get => _duration; set => _duration = value; }
        public float ElapsedTime { get => _elapsedTime; }
        public float Progress { get => Mathf.Clamp01(_elapsedTime / _duration); }
        public int Count { get => _count; set => _count = value; }
        public int CurrentCount { get => _currentCount; }
        public UnityEvent<int> OnTime { get => _onTime; }
        public UnityEvent<float> OnProgress { get => _onProgress; }
        public UnityEvent<float, int> OnProgressWithCount { get => _onProgressWithCount; }
        public UnityEvent<int> OnComplete { get => _onComplete; }
        public bool IsStarted { get => _isStarted; }
        public bool IsCompleted { get => _isCompleted; }

        public void Play()
        {
            if (_count == 0 || _currentCount < _count)
            {
                _isStarted = true;
            }
        }

        public void Stop()
        {
            _isStarted = false;
        }

        public void Clear()
        {
            _isCompleted = false;
            _elapsedTime = 0f;
            _currentCount = 0;
        }

        public void Update(float deltaTime)
        {
            if (!_isStarted || (_count > 0 && _currentCount == _count))
            {
                return;
            }

            _elapsedTime += deltaTime;
            _onProgress.Invoke(Progress);
            if (_elapsedTime > _duration)
            {
                _elapsedTime = _duration - _elapsedTime;
                _currentCount++;
                _onTime.Invoke(_currentCount);
                if (_count > 0 && _currentCount == _count)
                {
                    _isStarted = false;
                    _isCompleted = true;
                    _onComplete.Invoke(_currentCount);
                }
            }
        }
    }
}
