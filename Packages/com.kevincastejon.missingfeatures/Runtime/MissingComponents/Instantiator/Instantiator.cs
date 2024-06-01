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
        [Tooltip("Optional settings for the instance")]
        [SerializeField] private TransformData _destination;

        /// <summary>
        /// Instantiates the target gameobject or prefab
        /// </summary>
        public void InstantiateObject(GameObject gameObject)
        {
            GameObject go = Instantiate(gameObject);
            if (_destination.Parent)
            {
                go.transform.SetParent(_destination.Parent);
            }
            go.transform.localPosition = _destination.Position;
            go.transform.localRotation = _destination.Rotation;
            go.transform.localScale = _destination.Scale;
        }
    }
}
