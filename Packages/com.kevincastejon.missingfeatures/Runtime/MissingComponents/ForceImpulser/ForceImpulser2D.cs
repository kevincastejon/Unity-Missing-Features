using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.ForceImpulsers
{
    /// <summary>
    /// A component that can apply impulse force on 2D physics objects.
    /// </summary>
    public class ForceImpulser2D : MonoBehaviour
    {
        [Tooltip("The target Rigidbody2D to apply the force to. If omitted then a GetComponent<Rigidbody2D>() will be called to look for a rigidoby on the same gameobject than the component.")]
        [SerializeField] private Rigidbody2D _target;
        [Tooltip("The force to apply.")]
        [SerializeField] private Vector2 _force;
        [Tooltip("Will the force be applied on start.")]
        [SerializeField] private bool _applyImpulseOnStart;

        /// <summary>
        /// The target Rigidbody2D to apply the force to. If omitted then a GetComponent<Rigidbody2D>() will be called to look for a rigidoby on the same gameobject than the component.
        /// </summary>
        public Rigidbody2D Target { get => _target; set => _target = value; }
        /// <summary>
        /// The force to apply.
        /// </summary>
        public Vector2 Force { get => _force; set => _force = value; }
        /// <summary>
        /// Will the force be applied on start.
        /// </summary>
        public bool ApplyImpulseOnStart { get => _applyImpulseOnStart; set => _applyImpulseOnStart = value; }

        private void Awake()
        {
            _target = _target ? _target : GetComponent<Rigidbody2D>();
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
            _target.AddForce(_force, ForceMode2D.Impulse);
        }
    }
}
