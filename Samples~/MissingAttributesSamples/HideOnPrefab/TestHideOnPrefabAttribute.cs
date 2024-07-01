using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestHideOnPrefabAttribute : MonoBehaviour
    {
        [HideOnPrefab]
        [SerializeField] private int _healthPoints;

        [HideOnPrefab(true)]
        [SerializeField] private int _damages;
    }
}
