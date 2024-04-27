using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    /// <summary>
    /// An object that fires events base on time
    /// </summary>
    [System.Serializable]
    public class Timer
    {
        [Tooltip("The duration of the timer")]
        [Min(0.01f)][SerializeField] private float _duration = 1f;
        [Tooltip("How many time will the timer run the duration. 0 means infinitely.")]
        [Min(0)][SerializeField] private int _count = 1;
        [Tooltip("Fires when updating the time. The parameter represents the normalized progress of the current cycle. Always between 0 and 1.")]
        [SerializeField] private UnityEvent<float> _onProgress = new UnityEvent<float>();
        [Tooltip("Fires when the duration is reached. The parameter represents the new cycle count.")]
        [SerializeField] private UnityEvent<int> _onTime = new UnityEvent<int>();
        [Tooltip("Fires when the repeat count is reached. The parameter represents the new cycle count. This event will not fire if the 'count' field is set to 0.")]
        [SerializeField] private UnityEvent<int> _onComplete = new UnityEvent<int>();

        private UnityEvent<float, int> _onProgressWithCount = new UnityEvent<float, int>();
        private float _elapsedTime = 0f;
        private int _currentCount = 0;
        private bool _isRunning;
        private bool _isCompleted;
        /// <summary>
        /// Initializes the timer with default duration of 1 second and default count value of 1
        /// </summary>
        public Timer()
        {
            _duration = 1f;
            _count = 1;
        }
        /// <summary>
        /// Initializes the timer with the given duration value
        /// </summary>
        /// <param name="duration">The duration of the timer</param>
        public Timer(float duration)
        {
            _duration = duration;
        }
        /// <summary>
        /// Initializes the timer with the given count value
        /// </summary>
        /// <param name="count">How many time will the timer run the duration. 0 means infinitely.</param>
        public Timer(int count)
        {
            _count = count;
        }
        /// <summary>
        /// Initializes the timer with the given duration and count values
        /// </summary>
        /// <param name="duration">The duration of the timer</param>
        /// <param name="count">How many time will the timer run the duration. 0 means infinitely.</param>
        public Timer(float duration = 1f, int count = 1)
        {
            _duration = duration;
            _count = count;
        }

        /// <summary>
        /// How many time will the timer run the duration. 0 means infinitely.
        /// </summary>
        public float Duration { get => _duration; set => _duration = value; }
        /// <summary>
        /// How many seconds have passed since the beginning of the new cycle
        /// </summary>
        public float ElapsedTime { get => _elapsedTime; }
        /// <summary>
        /// Normalized progress of the current cycle. Always between 0 and 1.
        /// </summary>
        public float Progress { get => Mathf.Clamp01(_elapsedTime / _duration); }
        /// <summary>
        /// How many time will the timer run the duration. 0 means infinitely.
        /// </summary>
        public int Count { get => _count; set => _count = value; }
        /// <summary>
        /// How many time the timer did run the duration.
        /// </summary>
        public int CurrentCount { get => _currentCount; }
        /// <summary>
        /// Fires when the duration is reached. The parameter represents the new cycle count.
        /// </summary>
        public UnityEvent<int> OnTime { get => _onTime; }
        /// <summary>
        /// Fires when updating the time. The parameter represents the normalized progress of the current cycle. Always between 0 and 1.
        /// </summary>
        public UnityEvent<float> OnProgress { get => _onProgress; }
        /// <summary>
        /// Fires when the repeat count is reached. The first parameter represents the normalized progress of the current cycle, the second represents the current cycle count. This event will not fire if the 'count' field is set to 0.
        /// </summary>
        public UnityEvent<float, int> OnProgressWithCount { get => _onProgressWithCount; }
        /// <summary>
        /// Fires when the repeat count is reached. The parameter represents the new cycle count. This event will not fire if the 'count' field is set to 0.
        /// </summary>
        public UnityEvent<int> OnComplete { get => _onComplete; }
        /// <summary>
        /// Is the timer running
        /// </summary>
        public bool IsRunning { get => _isRunning; }
        /// <summary>
        /// Has the timer completed all cycles
        /// </summary>
        public bool IsCompleted { get => _isCompleted; }
        /// <summary>
        /// Makes the timer running. If previously run and stopped, this will resume the timer, call Clear() to reset.
        /// </summary>
        public void Run()
        {
            if (_count == 0 || _currentCount < _count)
            {
                _isRunning = true;
            }
        }
        /// <summary>
        /// Makes the timer stop running. It can be resume by calling Run(), or reset by calling Clear().
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
        }
        /// <summary>
        /// Makes the timer reset. If the timer is running, it will reset and continue running, use Stop() to stop running.
        /// </summary>
        public void Clear()
        {
            _isCompleted = false;
            _elapsedTime = 0f;
            _currentCount = 0;
        }
        /// <summary>
        /// Has to be called in order to update a running timer
        /// </summary>
        /// <param name="deltaTime">The time elasped since the last call</param>
        public void Update(float deltaTime)
        {
            if (!_isRunning || (_count > 0 && _currentCount == _count))
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
                    _isRunning = false;
                    _isCompleted = true;
                    _onComplete.Invoke(_currentCount);
                }
            }
        }
    }
}
