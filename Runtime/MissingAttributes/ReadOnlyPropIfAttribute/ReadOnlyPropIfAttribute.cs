using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Makes the current property editable or not on the inspector based on a serialized bool property value.
    /// </summary>
    public class ReadOnlyPropIfAttribute : PropertyAttribute
    {
        public readonly string boolSerializedPropertyName;
        public readonly bool isTrue;

        /// <summary>
        /// Makes the current property editable on the inspector based on a serialized bool property value.
        /// </summary>
        /// <param name="boolSerializedPropertyName">The name of the serialized bool property that determines the editability of the property</param>
        /// <param name="isTrue">Wether to check if the serialized bool property value should be true or false in order to make the current property editable or not into the inspector</param>
        public ReadOnlyPropIfAttribute(string boolSerializedPropertyName, bool isTrue = true)
        {
            this.boolSerializedPropertyName = boolSerializedPropertyName;
            this.isTrue = isTrue;
        }
    } 
}