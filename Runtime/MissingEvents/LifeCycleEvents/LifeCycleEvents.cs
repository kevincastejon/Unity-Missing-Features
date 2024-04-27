using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    /// <summary>
    /// A component that offers UnityEvent fields for Unity's lifecycle callback methods
    /// </summary>
    public class LifeCycleEvents : MonoBehaviour
    {
        [Tooltip("Fires when the OnEnable method is called")]
        [SerializeField] private UnityEvent _onEnable;
        [Tooltip("Fires when the Awake method is called")]
        [SerializeField] private UnityEvent _onAwake;
        [Tooltip("Fires when the Start method is called")]
        [SerializeField] private UnityEvent _onStarted;
        [Tooltip("Fires when the Update method is called")]
        [SerializeField] private UnityEvent _onFixedUpdate;
        [Tooltip("Fires when the FixedUpdate method is called")]
        [SerializeField] private UnityEvent _onUpdate;
        [Tooltip("Fires when the OnDisable method is called")]
        [SerializeField] private UnityEvent _onDisable;
        [Tooltip("Fires when the OnDestroy method is called")]
        [SerializeField] private UnityEvent _onDestroy;
        /// <summary>
        /// Fires when the OnEnable method is called
        /// </summary>
        public UnityEvent onEnable { get => _onEnable; }
        /// <summary>
        /// Fires when the Awake method is called
        /// </summary>
        public UnityEvent onAwake { get => _onAwake; }
        /// <summary>
        /// Fires when the Start method is called
        /// </summary>
        public UnityEvent onStart { get => _onStarted; }
        /// <summary>
        /// Fires when the Update method is called
        /// </summary>
        public UnityEvent onFixedUpdate { get => _onFixedUpdate; }
        /// <summary>
        /// Fires when the FixedUpdate method is called
        /// </summary>
        public UnityEvent onUpdate { get => _onUpdate; }
        /// <summary>
        /// Fires when the OnDisable method is called
        /// </summary>
        public UnityEvent onDisable { get => _onDisable; }
        /// <summary>
        /// Fires when the OnDestroy method is called
        /// </summary>
        public UnityEvent onDestroy { get => _onDestroy; }

        private void OnEnable()
        {
            _onEnable.Invoke();
        }
        private void Awake()
        {
            _onAwake.Invoke();
        }
        private void Start()
        {
            _onStarted.Invoke();
        }
        private void Update()
        {
            _onUpdate.Invoke();
        }
        private void FixedUpdate()
        {
            _onFixedUpdate.Invoke();
        }
        private void OnDisable()
        {
            _onDisable.Invoke();
        }
        private void OnDestroy()
        {
            _onDestroy.Invoke();
        }
    }
}
