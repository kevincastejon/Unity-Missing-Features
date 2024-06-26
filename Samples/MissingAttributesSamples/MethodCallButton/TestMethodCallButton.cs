using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MissingFeatures.MissingAttributes;
using UnityEngine.Events;

namespace KevinCastejon.MissingFeatures.MissingAttributesSamples
{
    public class TestMethodCallButton : MonoBehaviour
    {
        [MethodCallButton]
        public void MyMethod()
        {
            Debug.Log("HELLO WORLD");
        }
    }
}
