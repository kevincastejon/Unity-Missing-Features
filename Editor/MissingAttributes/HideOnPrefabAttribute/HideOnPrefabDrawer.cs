using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomPropertyDrawer(typeof(HideOnPrefabAttribute))]
    public class HideOnPrefabDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            HideOnPrefabAttribute att = (HideOnPrefabAttribute)attribute;
            bool hidden = att.invert ? UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() == null : UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() != null;
            return hidden ? 0 : EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            HideOnPrefabAttribute att = (HideOnPrefabAttribute)attribute;
            bool hidden = att.invert ? UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() == null : UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage() != null;
            if (hidden) return;
            EditorGUI.PropertyField(position, property, label);
        }
    }
}