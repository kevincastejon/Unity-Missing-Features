using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyPropAttribute))]
    public class ReadOnlyPropDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Pour désactiver l'UI (rendre en lecture seule)
            EditorGUI.BeginDisabledGroup(true);

            // On dessine la propriété
            EditorGUI.PropertyField(position, property, label, true);

            // On réactive l'UI
            EditorGUI.EndDisabledGroup();
        }
    }
}