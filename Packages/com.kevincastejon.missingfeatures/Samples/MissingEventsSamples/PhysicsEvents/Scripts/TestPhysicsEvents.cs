using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingEventsSamples
{
    public class TestPhysicsEvents : MonoBehaviour
    {
        public void OnEnter(Collider collider)
        {
            Debug.Log("ENTER");
        }

        public void OnStay(Collider collider)
        {
            Debug.Log("STAY");
        }

        public void OnExit(Collider collider)
        {
            Debug.Log("EXIT");
        }
    }
}
