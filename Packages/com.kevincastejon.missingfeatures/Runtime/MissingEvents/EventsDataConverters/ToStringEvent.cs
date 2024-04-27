using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace KevinCastejon.MissingFeatures.MissingEvents.EventsDataConverters
{
    /// <summary>
    /// A component to plug between a UnityEvent and a method that accepts an string parameter. Supported types are bool, int and float
    /// </summary>
    public class ToStringEvent : MonoBehaviour
    {
        [Tooltip("Fires when a float value has been converted to int")]
        [SerializeField] private UnityEvent<string> _onConvert;

        /// <summary>
        /// Fires when a float value has been converted to string.
        /// </summary>
        public UnityEvent<string> OnConvert { get => _onConvert; }
        /// <summary>
        /// Converts the Object to its name and fires the event with that string.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        public void ObjectToName(Object obj)
        {
            _onConvert.Invoke(obj.name);
        }
        /// <summary>
        /// Converts the boolean value to a string and fires the event with that string.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        public void BoolToString(bool value)
        {
            _onConvert.Invoke(value.ToString());
        }
        /// <summary>
        /// Converts the int value to a string and fires the event with that string.
        /// </summary>
        /// <param name="value">The int value to convert.</param>
        public void IntToString(int value)
        {
            _onConvert.Invoke(value.ToString());
        }
        /// <summary>
        /// Converts the float value to a string and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToString(float value)
        {
            _onConvert.Invoke(value.ToString());
        }
        /// <summary>
        /// Converts the float value to a string skipping the floating digits and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF0(float value)
        {
            _onConvert.Invoke(value.ToString("F0"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 1 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF1(float value)
        {
            _onConvert.Invoke(value.ToString("F1"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 2 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF2(float value)
        {
            _onConvert.Invoke(value.ToString("F2"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 3 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF3(float value)
        {
            _onConvert.Invoke(value.ToString("F3"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 4 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF4(float value)
        {
            _onConvert.Invoke(value.ToString("F4"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 5 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF5(float value)
        {
            _onConvert.Invoke(value.ToString("F5"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 6 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF6(float value)
        {
            _onConvert.Invoke(value.ToString("F6"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 7 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF7(float value)
        {
            _onConvert.Invoke(value.ToString("F7"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 8 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF8(float value)
        {
            _onConvert.Invoke(value.ToString("F8"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 9 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF9(float value)
        {
            _onConvert.Invoke(value.ToString("F9"));
        }
        /// <summary>
        /// Converts the float value to a string truncated to 10 floating digit and fires the event with that string.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        public void FloatToStringF10(float value)
        {
            _onConvert.Invoke(value.ToString("F10"));
        }
    }
}