using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Makes a property editable or not into the editor based on a bool method returned value.
    /// </summary>
    public class ReadOnlyPropConditionalAttribute : PropertyAttribute
    {
        public readonly string boolMethodName;
        public readonly bool isTrue;

        /// <summary>
        /// Makes a property editable or not into the editor based on a bool method returned value.
        /// </summary>
        /// <param name="boolMethodName">The name of the bool method that determines the visibility of the property</param>
        /// <param name="isTrue">Wether to check if the serialized bool method returned value should be true or false in order to make the current property editable or not into the inspector</param>
        public ReadOnlyPropConditionalAttribute(string boolMethodName, bool isTrue = true)
        {
            this.boolMethodName = boolMethodName;
            this.isTrue = isTrue;
        }
    }
}