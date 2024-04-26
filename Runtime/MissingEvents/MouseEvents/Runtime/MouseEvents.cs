using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    public class MouseEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onMouseEnter;
        [SerializeField] private UnityEvent _onMouseOver;
        [SerializeField] private UnityEvent _onMouseDown;
        [SerializeField] private UnityEvent _onMouseDrag;
        [SerializeField] private UnityEvent _onMouseUp;
        [SerializeField] private UnityEvent _onMouseUpAsButton;
        [SerializeField] private UnityEvent _onMouseExit;
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
