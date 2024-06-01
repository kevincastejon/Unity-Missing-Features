using KevinCastejon.MissingFeatures.SharedUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingComponents
{
    public class TransformTeleporter : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private TransformData _to;
        [SerializeField] private bool _usePosition = true;
        [SerializeField] private bool _useRotation = true;
        [SerializeField] private bool _useScale = true;

        public void Teleport()
        {
            if (_usePosition)
            {
                _target.position = _to.Position;
            }
            if (_useRotation)
            {
                _target.rotation = _to.Rotation;
            }
            if (_useScale)
            {
                _target.localScale = _to.Scale;
            }
        }
    }
}