using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KevinCastejon.MissingFeatures.MissingComponents
{
    /// <summary>
    /// A component that can click on a button.
    /// </summary>
    public class ButtonClicker : MonoBehaviour
    {
        /// <summary>
        /// Invoke a Button click event
        /// </summary>
        /// <param name="button">The Button UI to click on</param>
        public void Click(Button button) { button.onClick.Invoke(); }
    }
}
