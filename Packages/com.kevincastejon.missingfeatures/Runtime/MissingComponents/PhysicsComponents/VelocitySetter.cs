using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.PhysicsComponents
{
    /// <summary>
    /// A component that can sets the velocity and/or angular velocity to physics objects.
    /// </summary>
    public class VelocitySetter : MonoBehaviour
    {
        [Tooltip("The target Rigidbody to apply the force to. If omitted then a GetComponent<Rigidbody>() will be called to look for a rigidoby on the same gameobject than the component.")]
        [SerializeField] private Rigidbody _target;
        [Tooltip("The velocity vector to set.")]
        [SerializeField] private Vector3 _velocity;
        [Tooltip("The angular velocity vector to use.")]
        [SerializeField] private Vector3 _angularVelocity;
        [Tooltip("Will the X axis velocity be untouched.")]
        [SerializeField] private bool _bypassX;
        [Tooltip("Will the Y axis velocity be untouched.")]
        [SerializeField] private bool _bypassY;
        [Tooltip("Will the Z axis velocity be untouched.")]
        [SerializeField] private bool _bypassZ;

        /// <summary>
        /// The target Rigidbody to apply the force to. If omitted then a GetComponent<Rigidbody>() will be called to look for a rigidoby on the same gameobject than the component.
        /// </summary>
        public Rigidbody Target { get => _target; set => _target = value; }
        private void Awake()
        {
            _target = _target ? _target : GetComponent<Rigidbody>();
        }
        /// <summary>
        /// Sets the specified velocity to the target Rigidbody
        /// </summary>
        public void SetVelocity()
        {
            Vector3 vel = _velocity;
            if (_bypassX)
            {
                vel.x = _target.velocity.x;
            }
            if (_bypassY)
            {
                vel.y = _target.velocity.y;
            }
            if (_bypassZ)
            {
                vel.z = _target.velocity.z;
            }
            _target.velocity = vel;
        }
        /// <summary>
        /// Sets the specified angular velocity to the target Rigidbody
        /// </summary>
        public void SetAngularVelocity()
        {
            Vector3 vel = _angularVelocity;
            if (_bypassX)
            {
                vel.x = _target.velocity.x;
            }
            if (_bypassY)
            {
                vel.y = _target.velocity.y;
            }
            if (_bypassZ)
            {
                vel.z = _target.velocity.z;
            }
            _target.angularVelocity = vel;
        }
    }
}
