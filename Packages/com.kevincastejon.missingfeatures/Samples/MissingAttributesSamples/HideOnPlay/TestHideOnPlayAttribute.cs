using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestHideOnPlayAttribute : MonoBehaviour
    {
        [HideOnPlay]
        [SerializeField] private int _healthPoints;

        [HideOnPlay(true)]
        [SerializeField] private int _damages;
    }
}
