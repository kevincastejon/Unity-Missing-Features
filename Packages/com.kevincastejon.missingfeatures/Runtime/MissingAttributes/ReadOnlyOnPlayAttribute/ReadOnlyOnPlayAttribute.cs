using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Prevents a property from being edited on the inspector in PlayMode. The behaviour can be inverted so the property is editable only in PlayMode.
    /// </summary>
    public class ReadOnlyOnPlayAttribute : PropertyAttribute
    {
        public readonly bool invert;

        /// <summary>
        /// Prevents a property from being edited on the inspector in PlayMode. The behaviour can be inverted so the property is editable only in PlayMode.
        /// </summary>
        /// <param name="invert">If set to true, it will invert the behaviour and make a property editable only in PlayMode</param>
        public ReadOnlyOnPlayAttribute(bool invert = false)
        {
            this.invert = invert;
        }
    }
}