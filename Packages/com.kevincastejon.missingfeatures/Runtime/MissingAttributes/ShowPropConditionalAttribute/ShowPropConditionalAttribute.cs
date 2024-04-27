using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Shows or hides a property based on a bool method returned value.
    /// </summary>
    public class ShowPropConditionalAttribute : PropertyAttribute
    {
        public readonly string boolMethodName;

        /// <summary>
        /// Shows or hides a property based on a bool method returned value.
        /// </summary>
        public ShowPropConditionalAttribute(string boolMethodName)
        {
            this.boolMethodName = boolMethodName;
        }
    }
}