using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Shows or hides a property based on a bool method returned value.
    /// </summary>
    public class ShowPropConditionalAttribute : PropertyAttribute
    {
        public readonly string boolMethodName;
        public readonly bool isTrue;

        /// <summary>
        /// Shows or hides a property based on a bool method returned value.
        /// </summary>
        /// <param name="boolMethodName">The name of the bool method that determines the visibility of the property</param>
        /// <param name="isTrue">Wether to check if the serialized bool method returned value should be true or false in order to show the current property into the inspector</param>
        public ShowPropConditionalAttribute(string boolMethodName, bool isTrue = true)
        {
            this.boolMethodName = boolMethodName;
            this.isTrue = isTrue;
        }
    }
}