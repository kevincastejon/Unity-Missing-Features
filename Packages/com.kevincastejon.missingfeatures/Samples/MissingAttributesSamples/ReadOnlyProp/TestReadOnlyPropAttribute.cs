using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestReadOnlyPropAttribute : MonoBehaviour
    {
        [ReadOnlyProp]
        [SerializeField] private int _healthPoints;
        [ReadOnlyProp]
        [SerializeField] private int _damages;
    }
}
