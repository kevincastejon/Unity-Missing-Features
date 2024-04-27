using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    /// <summary>
    /// A component that offers UnityEvent fields for Unity's mouse callback methods
    /// </summary>
    public class MouseEvents : MonoBehaviour
    {
        [Tooltip("Fires when the OnMouseEnter method is called")]
        [SerializeField] private UnityEvent _onMouseEnter;
        [Tooltip("Fires when the OnMouseOver method is called")]
        [SerializeField] private UnityEvent _onMouseOver;
        [Tooltip("Fires when the OnMouseDown method is called")]
        [SerializeField] private UnityEvent _onMouseDown;
        [Tooltip("Fires when the OnMouseDrag method is called")]
        [SerializeField] private UnityEvent _onMouseDrag;
        [Tooltip("Fires when the OnMouseUp method is called")]
        [SerializeField] private UnityEvent _onMouseUp;
        [Tooltip("Fires when the OnMouseUpAsButton method is called")]
        [SerializeField] private UnityEvent _onMouseUpAsButton;
        [Tooltip("Fires when the OnMouseExit method is called")]
        [SerializeField] private UnityEvent _onMouseExit;

        /// <summary>
        /// Fires when the OnMouseEnter method is called
        /// </summary>
        public UnityEvent onMouseEnter { get => _onMouseEnter; }
        /// <summary>
        /// Fires when the OnMouseOver method is called
        /// </summary>
        public UnityEvent onMouseOver { get => _onMouseOver; }
        /// <summary>
        /// Fires when the OnMouseDown method is called
        /// </summary>
        public UnityEvent onMouseDown { get => _onMouseDown; }
        /// <summary>
        /// Fires when the OnMouseDrag method is called
        /// </summary>
        public UnityEvent onMouseDrag { get => _onMouseDrag; }
        /// <summary>
        /// Fires when the OnMouseUp method is called
        /// </summary>
        public UnityEvent onMouseUp { get => _onMouseUp; }
        /// <summary>
        /// Fires when the OnMouseUpAsButton method is called
        /// </summary>
        public UnityEvent onMouseUpAsButton { get => _onMouseUpAsButton; }
        /// <summary>
        /// Fires when the OnMouseExit method is called
        /// </summary>
        public UnityEvent onMouseExit { get => _onMouseExit; }

        private void OnMouseEnter()
        {
            _onMouseEnter.Invoke();
        }
        private void OnMouseOver()
        {
            _onMouseOver.Invoke();
        }
        private void OnMouseDown()
        {
            _onMouseDown.Invoke();
        }
        private void OnMouseDrag()
        {
            _onMouseDrag.Invoke();
        }
        private void OnMouseUp()
        {
            _onMouseUp.Invoke();
        }
        private void OnMouseUpAsButton()
        {
            _onMouseUpAsButton.Invoke();
        }
        private void OnMouseExit()
        {
            _onMouseExit.Invoke();
        }
    }
}
