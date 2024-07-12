using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace KevinCastejon.MissingFeatures.MissingComponents
{
    /// <summary>
    /// A component inspired by the native ToggleGroup component, but allowing events firing at group level. Note: you should not rely anymore on the individual Toggle components events when referenced into a group.
    /// </summary>
    public class BetterToggleGroup : UIBehaviour
    {
        [Tooltip("Is it allowed that no toggle is switched on?")]
        [SerializeField] private bool m_AllowSwitchOff = false;
        [Tooltip("The Toggle components inside this group.")]
        [SerializeField] protected List<Toggle> m_Toggles = new List<Toggle>();
        [Tooltip("Fires when a toggle is switched on.")]
        [SerializeField] private UnityEvent<Toggle> _onToggleOn = new();
        [Tooltip("Fires when a toggle is switched off.")]
        [SerializeField] private UnityEvent<Toggle> _onToggleOff = new();
        [Tooltip("Fires when a toggle is switched on.")]
        [SerializeField] private UnityEvent<int> _onToggleOn_INT = new();
        [Tooltip("Fires when a toggle is switched off.")]
        [SerializeField] private UnityEvent<int> _onToggleOff_INT = new();

        /// <summary>
        /// Is it allowed that no toggle is switched on?
        /// </summary>
        /// <remarks>
        /// If this setting is enabled, pressing the toggle that is currently switched on will switch it off, so that no toggle is switched on. If this setting is disabled, pressing the toggle that is currently switched on will not change its state.
        /// Note that even if allowSwitchOff is false, the Toggle Group will not enforce its constraint right away if no toggles in the group are switched on when the scene is loaded or when the group is instantiated. It will only prevent the user from switching a toggle off.
        /// </remarks>
        public bool allowSwitchOff { get { return m_AllowSwitchOff; } set { m_AllowSwitchOff = value; } }

        /// <summary>
        /// Fires when a toggle is switched on.
        /// </summary>
        public UnityEvent<Toggle> OnToggleOn { get => _onToggleOn; }
        /// <summary>
        /// Fires when a toggle is switched off.
        /// </summary>
        public UnityEvent<Toggle> OnToggleOff { get => _onToggleOff; }
        /// <summary>
        /// Fires when a toggle is switched on.
        /// </summary>
        public UnityEvent<int> OnToggleOn_INT { get => _onToggleOn_INT; }
        /// <summary>
        /// Fires when a toggle is switched off.
        /// </summary>
        public UnityEvent<int> OnToggleOff_INT { get => _onToggleOff_INT; }

        protected BetterToggleGroup()
        { }

        /// <summary>
        /// Because all the Toggles have registered themselves in the OnEnabled, Start should check to
        /// make sure at least one Toggle is active in groups that do not AllowSwitchOff
        /// </summary>
        protected override void Start()
        {
            EnsureValidState();
            base.Start();
            for (int i = 0; i < m_Toggles.Count; i++)
            {
                Toggle toggle = m_Toggles[i];
                toggle.onValueChanged.AddListener((bool value) => OnToggleChanged(toggle));
            }
        }

        private void OnToggleChanged(Toggle toggle)
        {
            if (toggle.isOn)
            {
                NotifyToggleOn(toggle);
            }
            else
            {
                if (m_AllowSwitchOff)
                {
                    _onToggleOff.Invoke(toggle);
                    _onToggleOff_INT.Invoke(m_Toggles.FindIndex(x => x == toggle));
                }
                else
                {
                    toggle.SetIsOnWithoutNotify(true);
                }
            }
        }

        protected override void OnEnable()
        {
            EnsureValidState();
            base.OnEnable();
        }

        private void ValidateToggleIsInGroup(Toggle toggle)
        {
            if (toggle == null || !m_Toggles.Contains(toggle))
                throw new ArgumentException(string.Format("Toggle {0} is not part of ToggleGroup {1}", new object[] { toggle, this }));
        }

        /// <summary>
        /// Notify the group that the given toggle is enabled.
        /// </summary>
        /// <param name="toggle">The toggle that got triggered on.</param>
        /// <param name="sendCallback">If other toggles should send onValueChanged.</param>
        public void NotifyToggleOn(Toggle toggle)
        {
            ValidateToggleIsInGroup(toggle);
            // disable all toggles in the group
            for (var i = 0; i < m_Toggles.Count; i++)
            {
                if (m_Toggles[i] == toggle)
                {
                    _onToggleOn.Invoke(toggle);
                    _onToggleOn_INT.Invoke(i);
                    continue;
                }
                if (m_Toggles[i].isOn)
                {
                    m_Toggles[i].SetIsOnWithoutNotify(false);
                    _onToggleOff.Invoke(m_Toggles[i]);
                    _onToggleOff_INT.Invoke(i);
                }
            }
        }
        /// <summary>
        /// Ensure that the toggle group still has a valid state. This is only relevant when a ToggleGroup is Started
        /// or a Toggle has been deleted from the group.
        /// </summary>
        public void EnsureValidState()
        {
            if (!allowSwitchOff && !AnyTogglesOn() && m_Toggles.Count != 0)
            {
                m_Toggles[0].isOn = true;
                NotifyToggleOn(m_Toggles[0]);
            }

            IEnumerable<Toggle> activeToggles = ActiveToggles();

            if (activeToggles.Count() > 1)
            {
                Toggle firstActive = GetFirstActiveToggle();

                foreach (Toggle toggle in activeToggles)
                {
                    if (toggle == firstActive)
                    {
                        continue;
                    }
                    toggle.isOn = false;
                }
            }
        }

        /// <summary>
        /// Are any of the toggles on?
        /// </summary>
        /// <returns>Are and of the toggles on?</returns>
        public bool AnyTogglesOn()
        {
            return m_Toggles.Find(x => x.isOn) != null;
        }

        /// <summary>
        /// Returns the toggles in this group that are active.
        /// </summary>
        /// <returns>The active toggles in the group.</returns>
        /// <remarks>
        /// Toggles belonging to this group but are not active either because their GameObject is inactive or because the Toggle component is disabled, are not returned as part of the list.
        /// </remarks>
        public IEnumerable<Toggle> ActiveToggles()
        {
            return m_Toggles.Where(x => x.isOn);
        }

        /// <summary>
        /// Returns the toggle that is the first in the list of active toggles.
        /// </summary>
        /// <returns>The first active toggle from m_Toggles</returns>
        /// <remarks>
        /// Get the active toggle for this group. As the group
        /// </remarks>
        public Toggle GetFirstActiveToggle()
        {
            IEnumerable<Toggle> activeToggles = ActiveToggles();
            return activeToggles.Count() > 0 ? activeToggles.First() : null;
        }

        /// <summary>
        /// Switch all toggles off.
        /// </summary>
        /// <remarks>
        /// This method can be used to switch all toggles off, regardless of whether the allowSwitchOff property is enabled or not.
        /// </remarks>
        public void SetAllTogglesOff(bool sendCallback = true)
        {
            bool oldAllowSwitchOff = m_AllowSwitchOff;
            m_AllowSwitchOff = true;

            if (sendCallback)
            {
                for (var i = 0; i < m_Toggles.Count; i++)
                    m_Toggles[i].isOn = false;
            }
            else
            {
                for (var i = 0; i < m_Toggles.Count; i++)
                    m_Toggles[i].SetIsOnWithoutNotify(false);
            }

            m_AllowSwitchOff = oldAllowSwitchOff;
        }
    }
}
