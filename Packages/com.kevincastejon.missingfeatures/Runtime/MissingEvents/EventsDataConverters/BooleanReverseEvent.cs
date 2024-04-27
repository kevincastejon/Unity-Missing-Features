using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace KevinCastejon.MissingFeatures.MissingEvents.EventsDataConverters
{
    /// <summary>
    /// A component to plug between a UnityEvent\<bool\> and a method that accepts an boolean parameter to reverse its value.
    /// </summary>
    public class BooleanReverseEvent : MonoBehaviour
    {
        [Tooltip("Fires when a float value has been converted to int")]
        [SerializeField] private UnityEvent<bool> _onReverse;

        /// <summary>
        /// Fires when a bool value has been reversed
        /// </summary>
        public UnityEvent<bool> OnReverse { get => _onReverse; }

        /// <summary>
        /// Reverses a boolean value and fires the event with that value
        /// </summary>
        /// <param name="value">The boolean value to reverse</param>
        public void Reverse(bool value)
        {
            _onReverse.Invoke(!value);
        }
    }
}