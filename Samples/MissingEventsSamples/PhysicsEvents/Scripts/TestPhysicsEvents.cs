using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingEventsSamples
{
    public class TestPhysicsEvents : MonoBehaviour
    {
        public void OnEnter(Collider collider)
        {
            Debug.Log("ENTERED "+collider);
        }

        public void OnStay(Collider collider)
        {
            Debug.Log("STAYING " + collider);
        }

        public void OnExit(Collider collider)
        {
            Debug.Log("EXITED " + collider);
        }
        public void OnAwake()
        {
            Debug.Log("AWAKE");
        }
        public void OnSleep()
        {
            Debug.Log("ASLEEP");
        }
    }
}
