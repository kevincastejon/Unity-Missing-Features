using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.ColorSetters
{
    /// <summary>
    /// A simple color setter component meant to be plugged to UnityEvent for setting color without scripting. Works with SpriteRenderer
    /// </summary>
    public class SpriteRendererColorSetter : MonoBehaviour
    {
        [Tooltip("The SpriteRenderer to animate the color. If omitted then a GetComponent<SpriteRenderer>() will be called to look for a renderer on the same gameobject than the component.")]
        [SerializeField] private SpriteRenderer _target;
        [Tooltip("The colors array to use when setting color")]
        [SerializeField] private Color[] _colors;

        private void Awake()
        {
            _target = _target ? _target : GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// The SpriteRenderer to animate the color. If omitted then a GetComponent<SpriteRenderer>() will be called to look for a renderer on the same gameobject than the component.
        /// </summary>
        public SpriteRenderer Target { get => _target; set => _target = value; }
        /// <summary>
        /// The colors array to use when setting color
        /// </summary>
        public Color[] Colors { get => _colors; set => _colors = value; }
        /// <summary>
        /// Sets the color to specified index. A modulo is used to ensure no out of bound index errors.
        /// </summary>
        /// <param name="colorIndex"></param>
        public void SetColor(int colorIndex)
        {
            if (_colors == null || _colors.Length == 0) { return; }
            _target.color = _colors[colorIndex % _colors.Length];
        }
        public void Reset()
        {
            _colors = new Color[] { Color.black, Color.white, Color.red, new Color(1f, 0.5f, 0f), Color.yellow, Color.green, Color.blue, Color.magenta };
        }
    }
}
