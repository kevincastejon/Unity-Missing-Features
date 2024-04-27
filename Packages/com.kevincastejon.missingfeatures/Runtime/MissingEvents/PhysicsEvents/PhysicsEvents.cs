using KevinCastejon.MissingFeatures.MissingAttributes;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    /// <summary>
    /// A component that offers UnityEvent fields for Unity's physics callback methods and sleep state changes
    /// </summary>
    public class PhysicsEvents : MonoBehaviour
    {
        /// <summary>
        /// A set of 2D physics events for triggers and collisions
        /// </summary>
        [Serializable]
        public struct Physics2DEventsSet
        {
            [SerializeField] private Physics2DEvents _triggerEvents;
            [SerializeField] private Physics2DEvents _collisionEvents;

            public Physics2DEvents TriggerEvents { get => _triggerEvents; }
            public Physics2DEvents CollisionEvents { get => _collisionEvents; }
        }
        /// <summary>
        /// A set of 3D physics events for triggers and collisions
        /// </summary>
        [Serializable]
        public struct Physics3DEventsSet
        {
            [SerializeField] private Physics3DEvents _triggerEvents;
            [SerializeField] private Physics3DEvents _collisionEvents;

            public Physics3DEvents TriggerEvents { get => _triggerEvents; }
            public Physics3DEvents CollisionEvents { get => _collisionEvents; }
        }
        /// <summary>
        /// A set of 2D physics events for entering, staying and exiting state
        /// </summary>
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
        /// <summary>
        /// A set of 3D physics events for entering, staying and exiting state
        /// </summary>
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
        /// <summary>
        /// A set of physics events related to sleeping state changes
        /// </summary>
        [Serializable]
        public struct PhysicsSleepEvents
        {
            [Tooltip("Fires when the rigidbody just woke up")]
            [SerializeField] private UnityEvent _onWoke;
            [Tooltip("Fires when the rigidbody just felt asleep")]
            [SerializeField] private UnityEvent _onAsleep;
            /// <summary>
            /// Fires when the rigidbody just woke up
            /// </summary>
            public UnityEvent OnWoke { get => _onWoke; }
            /// <summary>
            /// Fires when the rigidbody just felt asleep
            /// </summary>
            public UnityEvent OnAsleep { get => _onAsleep; }
        }
        [Tooltip("Will filter physics callbacks to a specific gameobject tag")]
        [SerializeField] private bool _useTagFilter;
        [Tooltip("The tag to use as a filter for the physics callbacks")]
        [SerializeField][ShowPropIf("_useTagFilter")][Tag] private string _tag;
        [SerializeField] private Physics2DEventsSet _physics2dEvents;
        [SerializeField] private Physics3DEventsSet _physics3dEvents;
        [Tooltip("Will watch of the sleeping state and fires related events")]
        [SerializeField] private bool _watchSleepingState;
        [SerializeField][ShowPropIf("_watchSleepingState")] private PhysicsSleepEvents _sleepEvents;
        private Rigidbody _body;
        private Rigidbody2D _body2D;
        private bool _lastSleepState;
        /// <summary>
        /// Will filter physics callbacks to a specific gameobject tag
        /// </summary>
        public bool UseTagFilter { get => _useTagFilter; set => _useTagFilter = value; }
        /// <summary>
        /// The tag to use as a filter for the physics callbacks
        /// </summary>
        public string Tag { get => _tag; set => _tag = value; }
        /// <summary>
        /// A set of 2D physics events for entering, staying and exiting state
        /// </summary>
        public Physics2DEventsSet Physics2dEvents { get => _physics2dEvents; }
        /// <summary>
        /// A set of 3D physics events for entering, staying and exiting state
        /// </summary>
        public Physics3DEventsSet Physics3dEvents { get => _physics3dEvents; }
        /// <summary>
        /// A set of physics events related to sleeping state changes
        /// </summary>
        public PhysicsSleepEvents SleepEvents { get => _sleepEvents; }

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            _body2D = GetComponent<Rigidbody2D>();
            if (!_watchSleepingState || (_body == null && _body2D == null))
            {
                enabled = false;
            }
        }

        private void FixedUpdate()
        {
            bool isSleeping = false;
            if (_body)
            {
                isSleeping = _body.IsSleeping();
            }
            else if (_body2D)
            {
                isSleeping = _body.IsSleeping();
            }

            if (_lastSleepState != isSleeping)
            {
                _lastSleepState = isSleeping;
                if (isSleeping)
                {
                    SleepEvents.OnAsleep.Invoke();
                }
                else
                {
                    SleepEvents.OnWoke.Invoke();
                }
            }
        }

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
