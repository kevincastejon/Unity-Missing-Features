using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.ColorSetters
{
    /// <summary>
    /// A simple color setter component meant to be plugged to UnityEvent for setting color without scripting. Works with Renderer
    /// </summary>
    public class RendererColorSetter : MonoBehaviour
    {
        [Tooltip("The Renderer to animate the color. If omitted then a GetComponent<Renderer>() will be called to look for a renderer on the same gameobject than the component.")]
        [SerializeField] private Renderer _target;
        [Tooltip("The colors array to use when setting color")]
        [SerializeField] private Color[] _colors;

        private void Awake()
        {
            _target = _target ? _target : GetComponent<Renderer>();
        }
        /// <summary>
        /// The Renderer to animate the color. If omitted then a GetComponent<Renderer>() will be called to look for a renderer on the same gameobject than the component.
        /// </summary>
        public Renderer Target { get => _target; set => _target = value; }
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
            _target.material.SetColor("_Color", _colors[colorIndex % _colors.Length]);
        }
        /// <summary>
        /// Sets the material emissive color to specified index. A modulo is used to ensure no out of bound index errors.
        /// </summary>
        /// <param name="colorIndex"></param>
        public void SetEmissiveColor(int colorIndex)
        {
            if (_colors == null || _colors.Length == 0) { return; }
            _target.material.SetColor("_EmissionColor", _colors[colorIndex % _colors.Length]);
        }
        public void Reset()
        {
            _colors = new Color[] { Color.black, Color.white, Color.red, new Color(1f, 0.5f, 0f), Color.yellow, Color.green, Color.blue, Color.magenta };
        }
    }
}
