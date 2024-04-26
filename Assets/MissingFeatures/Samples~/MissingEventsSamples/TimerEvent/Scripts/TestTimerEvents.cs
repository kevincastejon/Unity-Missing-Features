using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingEventsSamples
{
    public class TestTimerEvents : MonoBehaviour
    {
        public void OnProgress(float progress)
        {
            Debug.Log("ON PROGRESS : " + progress);
        }
        public void OnTime(int count)
        {
            Debug.Log("ON TIME : " + count);
        }
        public void OnCompleted(int count)
        {
            Debug.Log("ON COMPLETED : " + count);
        }
    }
}
