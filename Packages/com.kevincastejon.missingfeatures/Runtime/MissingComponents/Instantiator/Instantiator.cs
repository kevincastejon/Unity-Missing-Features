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
        [SerializeField] private TransformData _destination;
        [Tooltip("Optional local/global settings for the instances positions and rotation")]
        [SerializeField] private bool _useLocalScope;
        [Tooltip("Optional parent settings for the instances")]
        [SerializeField] private bool _useParentSetting;
        [SerializeField] private Transform _parent;

        /// <summary>
        /// Instantiates the target gameobject or prefab
        /// </summary>
        public void InstantiateObject(GameObject gameObject)
        {
            GameObject go;
            if (_useParentSetting)
            {
                go = Instantiate(gameObject, _parent);
            }
            else
            {
                go = Instantiate(gameObject);
            }
            if (_useDestinationSetting)
            {
                if (_useLocalScope)
                {
                    go.transform.localPosition = _destination.Position;
                    go.transform.localRotation = _destination.Rotation;
                    go.transform.localScale = _destination.Scale;
                }
                else
                {
                    go.transform.position = _destination.Position;
                    go.transform.rotation = _destination.Rotation;
                    go.transform.localScale = _destination.Scale;
                }
            }
        }
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
    }
}
