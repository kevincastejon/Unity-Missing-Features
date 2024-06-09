using KevinCastejon.MissingFeatures.SharedUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingComponents
{
    public class TransformTeleporter : MonoBehaviour
    {
        [Tooltip("The target Transform.")]
        [SerializeField] private Transform _target;
        [Tooltip("The Transform data to use for teleportation.")]
        [SerializeField] private TransformData _destination;
        [Tooltip("Will use position value for teleporting.")]
        [SerializeField] private bool _usePosition = true;
        [Tooltip("Will use rotation value for teleporting.")]
        [SerializeField] private bool _useRotation = true;
        [Tooltip("Will use scale value for teleporting.")]
        [SerializeField] private bool _useScale = true;

        /// <summary>
        /// The target Transform.
        /// </summary>
        public Transform Target { get => _target; set => _target = value; }
        /// <summary>
        /// The Transform data to use for teleportation.
        /// </summary>
        public TransformData Destination { get => _destination; set => _destination = value; }
        /// <summary>
        /// Will use position value for teleporting.
        /// </summary>
        public bool UsePosition { get => _usePosition; set => _usePosition = value; }
        /// <summary>
        /// Will use rotation value for teleporting.
        /// </summary>
        public bool UseRotation { get => _useRotation; set => _useRotation = value; }
        /// <summary>
        /// Will use scale value for teleporting.
        /// </summary>
        public bool UseScale { get => _useScale; set => _useScale = value; }
        /// <summary>
        /// Set the destination values to the local position rotation and scale of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetDestinationLocalFromTransform(Transform transform)
        {
            _destination.SetTransformDataLocalFromTransform(transform);
        }
        /// <summary>
        /// Set the destination values to the global position rotation and scale of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetDestinationGlobalFromTransform(Transform transform)
        {
            _destination.SetTransformDataGlobalFromTransform(transform);
        }
        /// <summary>
        /// Sets the Transform world coordinates values to the destination ones.
        /// </summary>
        public void TeleportGlobal()
        {
            if (_usePosition)
            {
                _target.position = _destination.Position;
            }
            if (_useRotation)
            {
                _target.rotation = _destination.Rotation;
            }
            if (_useScale)
            {
                _target.localScale = _destination.Scale;
            }
        }
        /// <summary>
        /// Sets the Transform local coordinates values to the destination ones.
        /// </summary>
        public void TeleportLocal()
        {
            if (_usePosition)
            {
                _target.localPosition = _destination.Position;
            }
            if (_useRotation)
            {
                _target.localRotation = _destination.Rotation;
            }
            if (_useScale)
            {
                _target.localScale = _destination.Scale;
            }
        }
    }
}