using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestTagAttribute : MonoBehaviour
    {
        [Tag]
        [SerializeField] private string _targetTag;
    }
}
