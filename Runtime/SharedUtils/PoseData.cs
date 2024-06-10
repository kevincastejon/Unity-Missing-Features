using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.SharedUtils
{
    /// <summary>
    /// Utilitary class to store Pose data
    /// </summary>
    [Serializable]
    public class PoseData
    {
        [SerializeField] private Vector3 _position = Vector3.zero;
        [SerializeField] private Quaternion _rotation = Quaternion.identity;

        /// <summary>
        /// The position data
        /// </summary>
        public Vector3 Position { get => _position; set => _position = value; }
        /// <summary>
        /// The rotation data
        /// </summary>
        public Quaternion Rotation { get => _rotation; set => _rotation = value; }
        /// <summary>
        /// Set the values to the local position rotation of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetTransformDataLocalFromTransform(Transform transform)
        {
            _position = transform.localPosition;
            _rotation = transform.localRotation;
        }
        /// <summary>
        /// Set the values to the local position rotation of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetTransformDataGlobalFromTransform(Transform transform)
        {
            _position = transform.position;
            _rotation = transform.rotation;
        }
    }
}
