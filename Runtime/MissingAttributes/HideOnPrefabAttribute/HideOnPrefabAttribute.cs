using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Hides the property in PrefabMode. The behaviour can be inverted with the 'invert' parameter so the property is visible only in PrefabMode.
    /// </summary>
    public class HideOnPrefabAttribute : PropertyAttribute
    {
        public readonly bool isTrue;

        /// <summary>
        /// Hide the property in PrefabMode. The behaviour can be inverted with the 'invert' parameter so the property is visible only in PrefabMode.
        /// </summary>
        /// <param name="isTrue">If set to true, it inverts the behaviour and makes the property visible only in PrefabMode.</param>
        public HideOnPrefabAttribute(bool isTrue = false)
        {
            this.isTrue = isTrue;
        }
    }
}