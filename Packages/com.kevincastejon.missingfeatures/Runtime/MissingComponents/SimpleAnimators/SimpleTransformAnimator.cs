using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.SharedUtils;
using KevinCastejon.MissingFeatures.MissingEvents;
namespace KevinCastejon.MissingFeatures.MissingComponents.SimpleAnimators
{
    /// <summary>
    /// A simple motion animator component for simple Transform animation
    /// </summary>
    public class SimpleTransformAnimator : MonoBehaviour
    {
        [Tooltip("The Transform to animate. If omitted then the component's gameobject's Transform will be used.")]
        [SerializeField] private Transform _target;
        [Tooltip("The beginning state of the animation.")]
        [SerializeField] private Transform _from;
        [Tooltip("The end state of the animation.")]
        [SerializeField] private Transform _to;

        [SerializeField] private Timer _timing;
        [Tooltip("Will the animation loop by playing the animation backward or will snap back to the beginning.")]
        [SerializeField] private bool _yoyo = true;
        [Tooltip("The easing function to use for the animation.")]
        [SerializeField] private EasingType _easingType;
        [Tooltip("Will the animation automatically start.")]
        [SerializeField] private bool _autoStart;
        [Tooltip("Will the rotation animation use euler angles rather than quaternion.")]
        [SerializeField] private bool _useEulerAngles;

        /// <summary>
        /// The Transform to animate. If omitted then the component's gameobject's Transform will be used.
        /// </summary>
        public Transform Target { get => _target; set => _target = value; }
        /// <summary>
        /// The beginning state of the animation.
        /// </summary>
        public Transform From { get => _from; set => _from = value; }
        /// <summary>
        /// The end state of the animation.
        /// </summary>
        public Transform To { get => _to; set => _to = value; }
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
        /// Will the rotation animation use euler angles rather than quaternion.
        /// </summary>
        public bool UseEulerAngles { get => _useEulerAngles; set => _useEulerAngles = value; }
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
            _target = _target ? _target : transform;
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
                _target.position = Vector3.Lerp(_from.position, _to.position, t);
                if (_useEulerAngles)
                {
                    _target.eulerAngles = Vector3.Lerp(_from.eulerAngles, _to.eulerAngles, t);
                }
                else
                {
                    _target.rotation = Quaternion.Lerp(_from.rotation, _to.rotation, t);
                }
                _target.localScale = Vector3.Lerp(_from.localScale, _to.localScale, t);
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
    }
}
