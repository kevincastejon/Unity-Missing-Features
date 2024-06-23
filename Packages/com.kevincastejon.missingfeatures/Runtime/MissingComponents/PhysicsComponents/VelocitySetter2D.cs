using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.PhysicsComponents
{
    /// <summary>
    /// A component that can sets the velocity and/or angular velocity to 2D physics objects.
    /// </summary>
    public class VelocitySetter2D : MonoBehaviour
    {
        [Tooltip("The target Rigidbody2D to apply the force to. If omitted then a GetComponent<Rigidbody2D>() will be called to look for a rigidoby on the same gameobject than the component.")]
        [SerializeField] private Rigidbody2D _target;
        [Tooltip("The velocity vector to set.")]
        [SerializeField] private Vector3 _velocity;
        [Tooltip("The angular velocity value to use.")]
        [SerializeField] private float _angularVelocity;
        [Tooltip("Will the X axis velocity be untouched.")]
        [SerializeField] private bool _bypassX;
        [Tooltip("Will the Y axis velocity be untouched.")]
        [SerializeField] private bool _bypassY;
        [Tooltip("Will the Z axis velocity be untouched.")]
        [SerializeField] private bool _bypassZ;

        /// <summary>
        /// The target Rigidbody2D to apply the force to. If omitted then a GetComponent<Rigidbody2D>() will be called to look for a rigidoby on the same gameobject than the component.
        /// </summary>
        public Rigidbody2D Target { get => _target; set => _target = value; }
        private void Awake()
        {
            _target = _target ? _target : GetComponent<Rigidbody2D>();
        }
        /// <summary>
        /// Sets the specified velocity to the target Rigidbody2D
        /// </summary>
        public void SetVelocity()
        {
            Vector2 vel = _velocity;
            if (_bypassX)
            {
                vel.x = _target.velocity.x;
            }
            if (_bypassY)
            {
                vel.y = _target.velocity.y;
            }
            _target.velocity = vel;
        }
        /// <summary>
        /// Sets the specified angular velocity to the target Rigidbody2D
        /// </summary>
        public void SetAngularVelocity()
        {
            _target.angularVelocity = _angularVelocity;
        }
    }
}
