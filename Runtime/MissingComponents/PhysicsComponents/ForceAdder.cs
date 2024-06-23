using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.PhysicsComponents
{
    /// <summary>
    /// A component that can add force and/or torque to physics objects.
    /// </summary>
    public class ForceAdder : MonoBehaviour
    {
        [Tooltip("The target Rigidbody to apply the force or torque to. If omitted then a GetComponent<Rigidbody>() will be called to look for a rigidoby on the same gameobject than the component.")]
        [SerializeField] private Rigidbody _target;
        [Tooltip("The force vector to add.")]
        [SerializeField] private Vector3 _force;
        [Tooltip("The torque vector to add.")]
        [SerializeField] private Vector3 _torque;
        [Tooltip("Will the force be applied relatively to the Rigidbody2D coordinate system.")]
        [SerializeField] private bool _useRelativeForce;
        [Tooltip("The ForceMode to use.")]
        [SerializeField] private ForceMode _forceMode;

        /// <summary>
        /// The target Rigidbody to add the force or torque to. If omitted then a GetComponent<Rigidbody>() will be called to look for a rigidoby on the same gameobject than the component.
        /// </summary>
        public Rigidbody Target { get => _target; set => _target = value; }
        /// <summary>
        /// The force vector to add.
        /// </summary>
        public Vector3 Force { get => _force; set => _force = value; }
        /// <summary>
        /// The torque vector to add.
        /// </summary>
        public Vector3 Torque { get => _torque; set => _torque = value; }
        /// <summary>
        /// Will the force be applied relatively to the Rigidbody2D coordinate system.
        /// </summary>
        public bool UseRelativeForce { get => _useRelativeForce; set => _useRelativeForce = value; }
        /// <summary>
        /// The ForceMode to use.
        /// </summary>
        public ForceMode ForceMode { get => _forceMode; set => _forceMode = value; }

        private void Awake()
        {
            _target = _target ? _target : GetComponent<Rigidbody>();
        }
        /// <summary>
        /// Adds the force to the rigidbody target.
        /// </summary>
        public void AddForce()
        {
            if (_useRelativeForce)
            {
                _target.AddRelativeForce(_force, _forceMode);
            }
            else
            {
                _target.AddForce(_force, _forceMode);
            }
        }
        /// <summary>
        /// Adds the torque to the rigidbody target.
        /// </summary>
        public void AddTorque()
        {
            if (_useRelativeForce)
            {
                _target.AddRelativeTorque(_torque, _forceMode);
            }
            else
            {
                _target.AddTorque(_torque, _forceMode);
            }
        }
    }
}