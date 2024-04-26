using UnityEngine;
using UnityEngine.Events;


namespace KevinCastejon.MissingFeatures.MissingEvents
{
    [System.Serializable]
    public class InputEvent
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
    }
}
