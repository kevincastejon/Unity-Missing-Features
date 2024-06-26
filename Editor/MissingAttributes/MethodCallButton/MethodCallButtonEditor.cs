using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MethodCallButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            MonoBehaviour monoBehaviour = (MonoBehaviour)target;
            MethodInfo[] methods = monoBehaviour.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(MethodCallButtonAttribute), true);
                foreach (MethodCallButtonAttribute attribute in attributes)
                {
                    if (GUILayout.Button(string.IsNullOrEmpty(attribute.label) ? method.Name : attribute.label))
                    {
                        method.Invoke(monoBehaviour, null);
                    }
                }
            }
        }
    }
}