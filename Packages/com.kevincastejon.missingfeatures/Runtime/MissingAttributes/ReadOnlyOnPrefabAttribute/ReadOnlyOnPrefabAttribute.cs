using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Prevents a property from being edited on the inspector in PrefabMode. The behaviour can be inverted so the property is editable only in PrefabMode.
    /// </summary>
    public class ReadOnlyOnPrefabAttribute : PropertyAttribute
    {
        public readonly bool invert;

        /// <summary>
        /// Prevents a property from being edited on the inspector in PrefabMode. The behaviour can be inverted so the property is editable only in PrefabMode.
        /// </summary>
        /// <param name="invert">If set to true, it will invert the behaviour and make a property editable only in PrefabMode</param>
        public ReadOnlyOnPrefabAttribute(bool invert = false)
        {
            this.invert = invert;
        }
    }
}