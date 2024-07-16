using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestReadOnlyOnPrefabAttribute : MonoBehaviour
    {
        [ReadOnlyOnPrefab]
        [SerializeField] private int _healthPoints;

        [ReadOnlyOnPrefab(true)]
        [SerializeField] private int _damages;
    }
}
