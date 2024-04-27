using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    /// <summary>
    /// A component that offers UnityEvent fields for Unity's visible callback methods
    /// </summary>
    public class VisibleEvents : MonoBehaviour
    {
        [Tooltip("Fires when the OnBecameVisible method is called")]
        [SerializeField] private UnityEvent _onBecameVisible;
        [Tooltip("Fires when the OnBecameInvisible method is called")]
        [SerializeField] private UnityEvent _onBecameInvisible;

        /// <summary>
        /// Fires when the OnBecameVisible method is called
        /// </summary>
        public UnityEvent onBecameVisible { get => _onBecameVisible; }
        /// <summary>
        /// Fires when the OnBecameInvisible method is called
        /// </summary>
        public UnityEvent onBecameInvisible { get => _onBecameInvisible; }

        private void OnBecameVisible()
        {
            _onBecameVisible.Invoke();
        }
        private void OnBecameInvisible()
        {
            _onBecameInvisible.Invoke();
        }
    }
}
