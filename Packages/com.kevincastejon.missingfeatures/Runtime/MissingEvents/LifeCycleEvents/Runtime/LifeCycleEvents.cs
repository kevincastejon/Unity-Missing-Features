using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    public class LifeCycleEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onEnable;
        [SerializeField] private UnityEvent _onAwake;
        [SerializeField] private UnityEvent _onStarted;
        [SerializeField] private UnityEvent _onFixedUpdate;
        [SerializeField] private UnityEvent _onUpdate;
        [SerializeField] private UnityEvent _onDisable;
        [SerializeField] private UnityEvent _onDestroy;
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
