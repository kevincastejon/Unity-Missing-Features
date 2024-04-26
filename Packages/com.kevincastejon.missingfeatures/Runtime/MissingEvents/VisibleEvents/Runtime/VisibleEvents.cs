using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    public class VisibleEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onBecameVisible;
        [SerializeField] private UnityEvent _onBecameInvisible;
        [SerializeField] private UnityEvent<bool> _onChange;

        private void OnBecameVisible()
        {
            _onBecameVisible.Invoke();
            _onChange.Invoke(true);
        }
        private void OnBecameInvisible()
        {
            _onBecameInvisible.Invoke();
            _onChange.Invoke(false);
        }
    }
}
