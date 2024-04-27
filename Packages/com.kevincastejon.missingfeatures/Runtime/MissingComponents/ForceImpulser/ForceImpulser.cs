using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.ForceImpulsers
{
    /// <summary>
    /// A component that can apply impulse force on physics objects.
    /// </summary>
    public class ForceImpulser : MonoBehaviour
    {
        [Tooltip("The target Rigidbody to apply the force to. If omitted then a GetComponent<Rigidbody>() will be called to look for a rigidoby on the same gameobject than the component.")]
        [SerializeField] private Rigidbody _target;
        [Tooltip("The force to apply.")]
        [SerializeField] private Vector3 _force;
        [Tooltip("Will the force be applied on start.")]
        [SerializeField] private bool _applyImpulseOnStart;

        /// <summary>
        /// The target Rigidbody to apply the force to. If omitted then a GetComponent<Rigidbody>() will be called to look for a rigidoby on the same gameobject than the component.
        /// </summary>
        public Rigidbody Target { get => _target; set => _target = value; }
        /// <summary>
        /// The force to apply.
        /// </summary>
        public Vector3 Force { get => _force; set => _force = value; }
        /// <summary>
        /// Will the force be applied on start.
        /// </summary>
        public bool ApplyImpulseOnStart { get => _applyImpulseOnStart; set => _applyImpulseOnStart = value; }

        private void Awake()
        {
            _target = _target ? _target : GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (_applyImpulseOnStart)
            {
                ApplyImpulse();
            }
        }
        /// <summary>
        /// Apply the impulse to the rigidbody target
        /// </summary>
        public void ApplyImpulse()
        {
            _target.AddForce(_force, ForceMode.Impulse);
        }
    }
}