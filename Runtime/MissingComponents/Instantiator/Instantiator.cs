using KevinCastejon.MissingFeatures.MissingAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents
{
    /// <summary>
    /// A component that can instantiate objects.
    /// </summary>
    public class Instantiator : MonoBehaviour
    {
        [Tooltip("Will instantiate the gameobject into this parent. Null means at the scene root.")]
        [SerializeField] private Transform _parent;
        [Tooltip("Will instantiate the gameobject at this local position")]
        [SerializeField] private Vector3 _position;
        [Tooltip("Will instantiate the gameobject with this rotation")]
        [SerializeField] private Vector3 _rotation;

        /// <summary>
        /// Instantiates the target gameobject or prefab
        /// </summary>
        public void InstantiateObject(Object gameObject)
        {
            Instantiate(gameObject, _position, Quaternion.Euler(_rotation.x, _rotation.y, _rotation.z), _parent);
        }
    }
}
