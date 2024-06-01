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
        [SerializeField] private Transform _reference = null;
        [SerializeField] private Transform _parent = null;
        [SerializeField] private Vector3 _position = Vector3.zero;
        [SerializeField] private Quaternion _rotation = Quaternion.identity;
        [SerializeField] private Vector3 _scale = Vector3.one;

        /// <summary>
        /// Optional Transform reference that will be used to feed the data
        /// </summary>
        public Transform Reference { get => _reference; set => _reference = value; }
        /// <summary>
        /// An optional reference to a parent Transform
        /// </summary>
        public Transform Parent { get => _parent; set => _parent = value; }
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
    }
}
