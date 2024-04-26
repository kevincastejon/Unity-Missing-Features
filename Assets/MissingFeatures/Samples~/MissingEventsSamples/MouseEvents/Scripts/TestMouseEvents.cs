using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingEventsSamples
{
    public class TestMouseEvents : MonoBehaviour
    {
        public void MouseEnter()
        {
            Debug.Log("MouseEnter");
        }
        public void MouseOver()
        {
            Debug.Log("MouseOver");
        }
        public void MouseDown()
        {
            Debug.Log("MouseDown");
        }
        public void MouseDrag()
        {
            Debug.Log("MouseDrag");
        }
        public void MouseUp()
        {
            Debug.Log("MouseUp");
        }
        public void MouseUpAsButton()
        {
            Debug.Log("MouseUpAsButton");
        }
        public void MouseExit()
        {
            Debug.Log("MouseExit");
        }
    }
}
