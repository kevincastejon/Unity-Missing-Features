using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A simple component to hold and fire a UnityEvent as a component.
/// </summary>
public class UnityEventComponent : MonoBehaviour
{
    [Tooltip("The UnityEvent of the component")]
    [SerializeField] private UnityEvent _event = new();
    /// <summary>
    /// The UnityEvent of the component
    /// </summary>
    public UnityEvent Event { get => _event; }

    /// <summary>
    /// Invoke the UnityEvent of the component
    /// </summary>
    public void InvokeEvent()
    {
        _event.Invoke();
    }
}
