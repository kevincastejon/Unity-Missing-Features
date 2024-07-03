using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    /// <summary>
    /// A component that fires events base on time
    /// </summary>
    public class TimerEvent : MonoBehaviour
    {
        [SerializeField] private Timer _timer = default;
        [Tooltip("Will the timer automatically run on start")]
        [SerializeField] private bool _autoStart = true;
        [SerializeField] private float _progress;
        [Tooltip("The current cycle count")]
        [SerializeField] private int _currentCount;
        [Tooltip("Is the timer running")]
        [SerializeField] private bool _isRunning;
        [Tooltip("Has the timer completed all cycles")]
        [SerializeField] private bool _isCompleted;
        /// <summary>
        /// How many time will the timer run the duration. 0 means infinitely.
        /// </summary>
        public float Duration { get => _timer.Duration; set => _timer.Duration = value; }
        /// <summary>
        /// How many seconds have passed since the beginning of the new cycle
        /// </summary>
        public float ElapsedTime { get => _timer.ElapsedTime; }
        /// <summary>
        /// Normalized progress of the current cycle. Always between 0 and 1.
        /// </summary>
        public float Progress { get => _progress; }
        /// <summary>
        /// How many time will the timer run the duration. 0 means infinitely.
        /// </summary>
        public int Count { get => _timer.Count; set => _timer.Count = value; }
        /// <summary>
        /// How many time the timer did run the duration.
        /// </summary>
        public int CurrentCount { get => _currentCount; }
        /// <summary>
        /// Fires when the duration is reached. The parameter represents the new cycle count.
        /// </summary>
        public UnityEvent<int> OnTime { get => _timer.OnTime; }
        /// <summary>
        /// Fires when updating the time. The parameter represents the normalized progress of the current cycle. Always between 0 and 1.
        /// </summary>
        public UnityEvent<float> OnProgress { get => _timer.OnProgress; }
        /// <summary>
        /// Fires when the repeat count is reached. The first parameter represents the normalized progress of the current cycle, the second represents the current cycle count. This event will not fire if the 'count' field is set to 0.
        /// </summary>
        public UnityEvent<float, int> OnProgressWithCount { get => _timer.OnProgressWithCount; }
        /// <summary>
        /// Fires when the repeat count is reached. The parameter represents the new cycle count. This event will not fire if the 'count' field is set to 0.
        /// </summary>
        public UnityEvent<int> OnComplete { get => _timer.OnComplete; }
        /// <summary>
        /// Is the timer running
        /// </summary>
        public bool IsRunning { get => _isRunning; }
        /// <summary>
        /// Has the timer completed all cycles
        /// </summary>
        public bool IsCompleted { get => _isCompleted; }

        private void Start()
        {
            if (_autoStart)
            {
                _timer.Run();
            }
        }
        private void Update()
        {
            _timer.Update(Time.deltaTime);
            _progress = _timer.Progress;
            _currentCount = _timer.CurrentCount;
            _isRunning = _timer.IsRunning;
            _isCompleted = _timer.IsCompleted;
        }
        /// <summary>
        /// Makes the timer running. If previously run and stopped, this will resume the timer, call Clear() to reset.
        /// </summary>
        [ContextMenu("Run")]
        public void Run()
        {
            _timer.Run();
        }
        /// <summary>
        /// Makes the timer stop running. It can be resume by calling Run(), or reset by calling Clear().
        /// </summary>
        [ContextMenu("Stop")]
        public void Stop()
        {
            _timer.Stop();
        }
        /// <summary>
        /// Makes the timer reset. If the timer is running, it will reset and continue running, use Stop() to stop running.
        /// </summary>
        [ContextMenu("Clear")]
        public void Clear()
        {
            _timer.Clear();
        }
        /// <summary>
        /// Makes the timer reset then play from the beginning.
        /// </summary>
        [ContextMenu("ClearAndRun")]
        public void ClearAndRun()
        {
            _timer.ClearAndRun();
        }
    }
}
