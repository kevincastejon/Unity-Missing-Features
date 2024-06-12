using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.SharedUtils
{
    /// <summary>
    /// Utilitary class to store Light data
    /// </summary>
    [Serializable]
    public class LightData
    {
        [Tooltip("The color data")]
        [SerializeField] private Color _color = Color.white;
        [Tooltip("The intensity data")]
        [SerializeField] private float _intensity = 1f;
        [Tooltip("The range data")]
        [SerializeField] private float _range = 10f;
        [Tooltip("The spot angle data")]
        [SerializeField] private float _spotAngle = 30f;

        /// <summary>
        /// The color data
        /// </summary>
        public Color Color { get => _color; set => _color = value; }
        /// <summary>
        /// The intensity data
        /// </summary>
        public float Intensity { get => _intensity; set => _intensity = value; }
        /// <summary>
        /// The range data
        /// </summary>
        public float Range { get => _range; set => _range = value; }
        /// <summary>
        /// The spot angle data
        /// </summary>
        public float SpotAngle { get => _spotAngle; set => _spotAngle = value; }
        /// <summary>
        /// Feed the values from a Light component.
        /// </summary>
        /// <param name="light">The Transform component used to feed the data from.</param>
        public void SetLightDataFromLight(Light light)
        {
            _color = light.color;
            _intensity = light.intensity;
            _range = light.range;
            _spotAngle = light.spotAngle;
        }
    }
}
