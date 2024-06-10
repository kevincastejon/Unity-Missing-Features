using KevinCastejon.MissingFeatures.MissingAttributes;
using KevinCastejon.MissingFeatures.SharedUtils;
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
        [Tooltip("Optional position, rotation and scale settings for the instances")]
        [SerializeField] private bool _useDestinationSetting;
        [SerializeField] private PoseData _destination;
        [Tooltip("Optional parent settings for the instances")]
        [SerializeField] private Transform _parent;
        [Tooltip("Optional local/global settings for the instances positions and rotation")]
        [SerializeField] private bool _worldPositionStays;

        /// <summary>
        /// Instantiates the target gameobject or prefab
        /// </summary>
        public void InstantiateObject(GameObject gameObject)
        {
            if (_parent)
            {
                if (_useDestinationSetting)
                {
                    Instantiate(gameObject, _destination.Position, _destination.Rotation, _parent);
                }
                else
                {
                    Instantiate(gameObject, _parent, _worldPositionStays);
                }
            }
            else
            {
                if (_useDestinationSetting)
                {
                    Instantiate(gameObject, _destination.Position, _destination.Rotation);
                }
                else
                {
                    Instantiate(gameObject);
                }
            }
        }
        /// <summary>
        /// Set the destination values to the local position rotation and scale of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetDestinationLocalFromTransform(Transform transform)
        {
            _destination.SetPoseDataLocalFromTransform(transform);
        }
        /// <summary>
        /// Set the destination values to the global position rotation and scale of the specified Transform component.
        /// </summary>
        /// <param name="transform">The Transform component used to feed the data from.</param>
        public void SetDestinationGlobalFromTransform(Transform transform)
        {
            _destination.SetPoseDataGlobalFromTransform(transform);
        }
    }
}
