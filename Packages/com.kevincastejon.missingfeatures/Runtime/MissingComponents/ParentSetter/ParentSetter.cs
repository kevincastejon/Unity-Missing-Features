using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents
{
    /// <summary>
    /// A component for setting the parent of a Transform
    /// 
    /// Note : You can already set the parent natively through UnityEvents but you cannot set the null value that parents it to the root of the scene, this component provides a SetParentToRoot() method to achieve this behaviour.
    /// </summary>
    public class ParentSetter : MonoBehaviour
    {
        [Tooltip("The target Transform to reparent")]
        [SerializeField] private Transform _target;
        [Tooltip("Will the world position stay in place when reparenting")]
        [SerializeField] private bool _worldPositionStay;
        /// <summary>
        /// The target Transform to reparent
        /// </summary>
        public Transform Target { get => _target; set => _target = value; }
        /// <summary>
        /// Will the world position stay in place when reparenting
        /// </summary>
        public bool WorldPositionStay { get => _worldPositionStay; set => _worldPositionStay = value; }
        /// <summary>
        /// Set the parent of the target Transform. To set the parent to null (root of the scene hierarchy) use the SetParentToRoot method instead.
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(Transform parent)
        {
            _target.SetParent(parent, _worldPositionStay);
        }
        /// <summary>
        /// Set the parent to null (at the root of the scene hierarchy)
        /// </summary>
        public void SetParentToRoot()
        {
            _target.SetParent(null, _worldPositionStay);
        }
    }
}