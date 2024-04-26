using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingEventsSamples
{
    public class TestLifeCycleEvents : MonoBehaviour
    {
        public void OnEnabled()
        {
            Debug.Log("Enable");
        }
        public void OnAwake()
        {
            Debug.Log("Awake");
        }
        public void OnStart()
        {
            Debug.Log("Started");
        }
        public void OnFixedUpdate()
        {
            Debug.Log("FixedUpdate");
        }
        public void OnUpdate()
        {
            Debug.Log("Update");
        }
        public void OnDestroyed()
        {
            Debug.Log("Destroy");
        }
        public void OnDisabled()
        {
            Debug.Log("Disable");
        }
    }
}
