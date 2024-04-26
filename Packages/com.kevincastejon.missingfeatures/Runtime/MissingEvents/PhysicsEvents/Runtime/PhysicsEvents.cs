using System;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    public class PhysicsEvents : MonoBehaviour
    {
        [Serializable]
        public struct Physics2DEventsSet
        {
            [SerializeField] private Physics2DEvents _triggerEvents;
            [SerializeField] private Physics2DEvents _collisionEvents;

            public Physics2DEvents TriggerEvents { get => _triggerEvents; }
            public Physics2DEvents CollisionEvents { get => _collisionEvents; }
        }
        [Serializable]
        public struct Physics3DEventsSet
        {
            [SerializeField] private Physics3DEvents _triggerEvents;
            [SerializeField] private Physics3DEvents _collisionEvents;

            public Physics3DEvents TriggerEvents { get => _triggerEvents; }
            public Physics3DEvents CollisionEvents { get => _collisionEvents; }
        }
        [Serializable]
        public struct Physics2DEvents
        {
            [SerializeField]
            private UnityEvent<Collider2D> _onEnter;
            [SerializeField]
            private UnityEvent<Collider2D> _onStay;
            [SerializeField]
            private UnityEvent<Collider2D> _onExit;

            public UnityEvent<Collider2D> OnEnter { get => _onEnter; }
            public UnityEvent<Collider2D> OnStay { get => _onStay; }
            public UnityEvent<Collider2D> OnExit { get => _onExit; }
        }
        [Serializable]
        public struct Physics3DEvents
        {
            [SerializeField]
            private UnityEvent<Collider> _onEnter;
            [SerializeField]
            private UnityEvent<Collider> _onStay;
            [SerializeField]
            private UnityEvent<Collider> _onExit;

            public UnityEvent<Collider> OnEnter { get => _onEnter; }
            public UnityEvent<Collider> OnStay { get => _onStay; }
            public UnityEvent<Collider> OnExit { get => _onExit; }
        }
        [SerializeField] private bool _useTagFilter;
        [SerializeField] private string _tag;
        [SerializeField] private Physics2DEventsSet _physics2dEvents;
        [SerializeField] private Physics3DEventsSet _physics3dEvents;

        public bool UseTagFilter { get => _useTagFilter; set => _useTagFilter = value; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collision.collider.CompareTag(_tag)))
            {
                _physics2dEvents.CollisionEvents.OnEnter.Invoke(collision.collider);
            }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collision.collider.CompareTag(_tag)))
            {
                _physics2dEvents.CollisionEvents.OnStay.Invoke(collision.collider);
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collision.collider.CompareTag(_tag)))
            {
                _physics2dEvents.CollisionEvents.OnExit.Invoke(collision.collider);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collision.collider.CompareTag(_tag)))
            {
                _physics3dEvents.CollisionEvents.OnEnter.Invoke(collision.collider);
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collision.collider.CompareTag(_tag)))
            {
                _physics3dEvents.CollisionEvents.OnStay.Invoke(collision.collider);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collision.collider.CompareTag(_tag)))
            {
                _physics3dEvents.CollisionEvents.OnExit.Invoke(collision.collider);
            }
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collider.CompareTag(_tag)))
            {
                _physics2dEvents.TriggerEvents.OnEnter.Invoke(collider);
            }
        }
        private void OnTriggerStay2D(Collider2D collider)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collider.CompareTag(_tag)))
            {
                _physics2dEvents.TriggerEvents.OnStay.Invoke(collider);
            }
        }
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collider.CompareTag(_tag)))
            {
                _physics2dEvents.TriggerEvents.OnExit.Invoke(collider);
            }
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collider.CompareTag(_tag)))
            {
                _physics3dEvents.TriggerEvents.OnEnter.Invoke(collider);
            }
        }
        private void OnTriggerStay(Collider collider)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collider.CompareTag(_tag)))
            {
                _physics3dEvents.TriggerEvents.OnStay.Invoke(collider);
            }
        }
        private void OnTriggerExit(Collider collider)
        {
            if (isActiveAndEnabled && (!_useTagFilter || collider.CompareTag(_tag)))
            {
                _physics3dEvents.TriggerEvents.OnExit.Invoke(collider);
            }
        }
    }
}
