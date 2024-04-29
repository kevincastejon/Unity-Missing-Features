using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Hides the property in PlayMode. The behaviour can be inverted with the 'invert' parameter so the property is visible only in PlayMode.
    /// </summary>
    public class HideOnPlayAttribute : PropertyAttribute
    {
        public readonly bool isTrue;

        /// <summary>
        /// Hide the property in PlayMode. The behaviour can be inverted with the 'invert' parameter so the property is visible only in PlayMode.
        /// </summary>
        /// <param name="isTrue">If set to true, it inverts the behaviour and makes the property visible only in PlayMode.</param>
        public HideOnPlayAttribute(bool isTrue = false)
        {
            this.isTrue = isTrue;
        }
    }
}