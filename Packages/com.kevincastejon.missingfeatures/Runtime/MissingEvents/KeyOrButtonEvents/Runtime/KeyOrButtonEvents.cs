using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingEvents
{
    public class KeyOrButtonEvents : MonoBehaviour
    {
        [SerializeField] private InputEventType _type;
        [SerializeField] private KeyCode _key;
        [SerializeField] private string _virtualButtonName;
        [SerializeField] private UnityEvent _downEvent;
        [SerializeField] private UnityEvent _upEvent;

        public InputEventType Type { get => _type; set => _type = value; }
        public KeyCode Key { get => _key; set => _key = value; }
        public string VirtualButtonName { get => _virtualButtonName; set => _virtualButtonName = value; }
        public UnityEvent DownEvent { get => _downEvent; }
        public UnityEvent UpEvent { get => _upEvent; }

        private void Update()
        {
            if (Type == InputEventType.KEYCODE)
            {
                if (Key == KeyCode.None)
                {
                    if (Input.anyKeyDown)
                    {
                        DownEvent.Invoke();
                    }
                }
                else
                {
                    if (Input.GetKeyDown(Key))
                    {
                        DownEvent.Invoke();
                    }
                    else if (Input.GetKeyUp(Key))
                    {
                        UpEvent.Invoke();
                    }
                }
            }
            else
            {
                if (Input.GetButtonDown(VirtualButtonName))
                {
                    DownEvent.Invoke();
                }
                else if (Input.GetButtonUp(VirtualButtonName))
                {
                    UpEvent.Invoke();
                }
            }
        }
    }
}
