using KevinCastejon.MissingFeatures.MissingEvents;
using KevinCastejon.MissingFeatures.SharedUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingComponents.SimpleAnimators
{
    public class SimpleLightAnimator : MonoBehaviour
    {
        [Tooltip("The Light to animate. If omitted then the component's gameobject's first Light component will be used.")]
        [SerializeField] private Light _target;
        [Tooltip("The beginning state of the animation.")]
        [SerializeField] private LightData _origin;
        [Tooltip("The end state of the animation.")]
        [SerializeField] private LightData _destination;
        [SerializeField] private Timer _timing;
        [Tooltip("Will the animation loop by playing the animation backward or will snap back to the beginning.")]
        [SerializeField] private bool _yoyo = true;
        [Tooltip("The easing function to use for the animation.")]
        [SerializeField] private EasingType _easingType;
        [Tooltip("Will the animation automatically start.")]
        [SerializeField] private bool _autoStart;

        /// <summary>
        /// The Light to animate. If omitted then the component's gameobject's first Light component will be used.
        /// </summary>
        public Light Target { get => _target; set => _target = value; }
        /// <summary>
        /// The beginning state of the animation.
        /// </summary>
        public LightData Origin { get => _origin; set => _origin = value; }
        /// <summary>
        /// The end state of the animation.
        /// </summary>
        public LightData Destination { get => _destination; set => _destination = value; }
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
            _target = _target ? _target : GetComponent<Light>();
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
                _target.color = Color.Lerp(_origin.Color, _destination.Color, t);
                _target.intensity = Mathf.Lerp(_origin.Intensity, _destination.Intensity, t);
                _target.range = Mathf.Lerp(_origin.Range, _destination.Range, t);
                _target.spotAngle = Mathf.Lerp(_origin.SpotAngle, _destination.SpotAngle, t);
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
        /// <summary>
        /// Set the origin values from a Light component.
        /// </summary>
        /// <param name="light">The Transform component used to feed the data from.</param>
        public void SetOriginFromLight(Light light)
        {
            _origin.SetLightDataFromLight(light);
        }
        /// <summary>
        /// Set the destination values from a Light component.
        /// </summary>
        /// <param name="light">The Light component used to feed the data from.</param>
        public void SetDestinationFromLight(Light light)
        {
            _destination.SetLightDataFromLight(light);
        }
    }
}
