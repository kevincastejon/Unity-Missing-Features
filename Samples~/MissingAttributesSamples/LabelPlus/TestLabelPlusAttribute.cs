using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestLabelPlusAttribute : MonoBehaviour
    {
        [LabelPlus("Assets/Samples/Missing Features/1.0.0/Missing Attributes Samples/Shared/Icons/greencrossicon.png", "Health Points", (int)LabelPlusColor.green)]
        [SerializeField] private int _healthPoints;
        [LabelPlus("Assets/Samples/Missing Features/1.0.0/Missing Attributes Samples/Shared/Icons/atk.png", "Damages", new float[] { 1f, 0f, 0f, 1f })]
        [SerializeField] private int _damages;
    }
}
