using System;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Displays a button into the inspector that will call a method on click.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodCallButtonAttribute : PropertyAttribute 
    {
        /// <summary>
        /// Optional label for the button. Default value is the method name.
        /// </summary>
        public readonly string label;
        /// <summary>
        /// Displays a button into the inspector that will call a method on click.
        /// </summary>
        public MethodCallButtonAttribute()
        {
        }
        /// <summary>
        /// Displays a button into the inspector that will call a method on click.
        /// </summary>
        /// <param name="label">Optional label for the button. Default value is the method name.</param>
        public MethodCallButtonAttribute(string label)
        {
            this.label = label;
        }
    }
}