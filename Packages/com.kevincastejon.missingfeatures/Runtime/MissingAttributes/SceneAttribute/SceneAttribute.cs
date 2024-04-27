using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Displays a dropdown list of available build settings Scenes (must be used with a 'string' typed property).
    /// </summary>
    public class SceneAttribute : PropertyAttribute
    {
        public bool allowMissing;
        /// <summary>
        /// Displays a dropdown list of available build settings Scenes (must be used with a 'string' typed property).
        /// </summary>
        /// <param name="allowMissing">If true, the dropdown list will display a "<Missing>" field if the scene name does not match any build settings scene. If false, the dropdown list will select the first item if the scene name does not match any build settings scene.</param>
        public SceneAttribute(bool allowMissing = false)
        {
            this.allowMissing = allowMissing;
        }
    }
}