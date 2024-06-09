using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.SharedUtils
{
    /// <summary>
    /// Utilitary class to store Transform data
    /// </summary>
    [Serializable]
    public class TransformData
    {
        [SerializeField] private Vector3 _position = Vector3.zero;
        [SerializeField] private Quaternion _rotation = Quaternion.identity;
        [SerializeField] private Vector3 _scale = Vector3.one;

        /// <summary>
        /// The position data
        /// </summary>
        public Vector3 Position { get => _position; set => _position = value; }
        /// <summary>
        /// The rotation data
        /// </summary>
        public Quaternion Rotation { get => _rotation; set => _rotation = value; }
        /// <summary>
        /// The scale data
        /// </summary>
        public Vector3 Scale { get => _scale; set => _scale = value; }
        /// <summary>
        /// Set the values to the local position rotation and scale of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetTransformDataLocalFromTransform(Transform transform)
        {
            _position = transform.localPosition;
            _rotation = transform.localRotation;
            _scale = transform.localScale;
        }
        /// <summary>
        /// Set the values to the local position rotation and scale of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetTransformDataGlobalFromTransform(Transform transform)
        {
            _position = transform.position;
            _rotation = transform.rotation;
            _scale = transform.localScale;
        }
    }
}
