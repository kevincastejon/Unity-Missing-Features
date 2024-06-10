using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.SharedUtils;
using KevinCastejon.MissingFeatures.MissingEvents;
namespace KevinCastejon.MissingFeatures.MissingComponents.SimpleAnimators
{
    /// <summary>
    /// A simple color animator component for simple Renderer color animation
    /// </summary>
    public class SimpleRendererColorAnimator : MonoBehaviour
    {
        [Tooltip("The Renderer to animate the color. If omitted then a GetComponent<Renderer>() will be called to look for a renderer on the same gameobject than the component.")]
        [SerializeField] private Renderer _target;
        [Tooltip("The beginning state of the animation.")]
        [SerializeField] private Color _from = Color.white;
        [Tooltip("The end state of the animation.")]
        [SerializeField] private Color _to = Color.white;

        [SerializeField] private Timer _timing;
        [Tooltip("Will the animation loop by playing the animation backward or will snap back to the beginning.")]
        [SerializeField] private bool _yoyo = true;
        [Tooltip("The easing function to use for the animation.")]
        [SerializeField] private EasingType _easingType;
        [Tooltip("Will the animation automatically start.")]
        [SerializeField] private bool _autoStart;

        /// <summary>
        /// The Renderer to animate. If omitted then the component's gameobject's Renderer will be used.
        /// </summary>
        public Renderer Target { get => _target; set => _target = value; }
        /// <summary>
        /// The beginning state of the animation.
        /// </summary>
        public Color From { get => _from; set => _from = value; }
        /// <summary>
        /// The end state of the animation.
        /// </summary>
        public Color To { get => _to; set => _to = value; }
        /// <summary>
        /// The timer used for the animation
        /// </summary>
        public Timer Timing { get => _timing; }
        /// <summary>
        /// Will the animation loop by playing the animation backward or by snapping back to the beginning.
        /// </summary>
        public bool Yoyo { get => _yoyo; set => _yoyo = value; }
        /// <summary>
        /// The easing function to use for the animation.
        /// </summary>
        public EasingType EasingType { get => _easingType; set => _easingType = value; }
        /// <summary>
        /// Will the animation automatically start.
        /// </summary>
        public bool AutoStart { get => _autoStart; set => _autoStart = value; }
        /// <summary>
        /// Is tha animation playing
        /// </summary>
        public bool IsPlaying { get => _timing.IsRunning; }
        /// <summary>
        /// Is the animation playin backward because of yoyo loop
        /// </summary>
        public bool IsReversed { get => _timing.CurrentCount % 2 == 1; }

        private void Awake()
        {
            _target = _target ? _target : GetComponent<Renderer>();
        }
        private void Start()
        {
            if (_autoStart)
            {
                Play();
            }
        }
        private void Update()
        {
            if (IsPlaying)
            {
                _timing.Update(Time.deltaTime);
                float t = _timing.Progress;
                t = EasingHelper.Ease(t, _easingType);
                if (_timing.CurrentCount % 2 == 1)
                {
                    t = 1f - t;
                }
                _target.material.color = Color.Lerp(_from, _to, t);
            }
        }
        /// <summary>
        /// Starts the animation
        /// </summary>
        public void Play()
        {
            _timing.Run();
        }
        /// <summary>
        /// Stops the animation
        /// </summary>
        public void Stop()
        {
            _timing.Stop();
        }
        /// <summary>
        /// Resets the animation
        /// </summary>
        public void Clear()
        {
            _timing.Clear();
        }
        /// <summary>
        /// Resets and plays the animation
        /// </summary>
        public void ClearAndPlay()
        {
            Clear();
            Play();
        }
    }
}
