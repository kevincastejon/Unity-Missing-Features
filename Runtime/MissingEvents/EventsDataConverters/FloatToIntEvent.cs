using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace KevinCastejon.MissingFeatures.MissingEvents.EventsDataConverters
{
    /// <summary>
    /// A component to plug between a UnityEvent\<float\> and a method that accepts an int parameter.
    /// </summary>
    public class FloatToIntEvent : MonoBehaviour
    {
        [Tooltip("Fires when a float value has been converted to int")]
        [SerializeField] private UnityEvent<int> _onConvert;

        /// <summary>
        /// Fires when a float value has been converted to int
        /// </summary>
        public UnityEvent<int> OnConvert { get => _onConvert; }

        /// <summary>
        /// Converts the float value to the closest inferior int value and fires the event with that value
        /// </summary>
        /// <param name="value">The float value to convert</param>
        public void FloorToInt(float value)
        {
            _onConvert.Invoke(Mathf.FloorToInt(value));
        }
        /// <summary>
        /// Convert the float value to the closest superior int value and fires the event with that value
        /// </summary>
        /// <param name="value">The float value to convert</param>
        public void CeilToInt(float value)
        {
            _onConvert.Invoke(Mathf.CeilToInt(value));
        }
        /// <summary>
        /// Convert the float value to the closest int value and fires the event with that value
        /// </summary>
        /// <param name="value">The float value to convert</param>
        public void RoundToInt(float value)
        {
            _onConvert.Invoke(Mathf.RoundToInt(value));
        }
    }
}