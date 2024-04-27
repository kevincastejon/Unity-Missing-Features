using KevinCastejon.MissingFeatures.MissingAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents
{
    /// <summary>
    /// A component that can destroy objects.
    /// </summary>
    public class Destroyer : MonoBehaviour
    {
        [Tooltip("Will use a delay before destroying the target")]
        [SerializeField] private bool _useDelayBeforeDestruction;
        [Tooltip("The delay before destroying the target")]
        [SerializeField][ShowPropIf("_useDelayBeforeDestruction")] private float _delayBeforeDestruction = 0f;
        /// <summary>
        /// Will destroy the gameobject associated to this component
        /// </summary>
        public void DestroySelf()
        {
            if (_useDelayBeforeDestruction)
            {
                Destroy(gameObject, _delayBeforeDestruction);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        /// <summary>
        /// Will destroy the target gameobject
        /// </summary>
        /// <param name="target">The target gameobject</param>
        public void DestroyGameObject(GameObject target)
        {
            if (_useDelayBeforeDestruction)
            {
                Destroy(target, _delayBeforeDestruction);
            }
            else
            {
                Destroy(target);
            }
        }
        /// <summary>
        /// Will destroy the target component
        /// </summary>
        /// <param name="target">The target gameobject</param>
        public void DestroyComponent(Component target)
        {
            if (_useDelayBeforeDestruction)
            {
                Destroy(target, _delayBeforeDestruction);
            }
            else
            {
                Destroy(target);
            }
        }
    }
}
