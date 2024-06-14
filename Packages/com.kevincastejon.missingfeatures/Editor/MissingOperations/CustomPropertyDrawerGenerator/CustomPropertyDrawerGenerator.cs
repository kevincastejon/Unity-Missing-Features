using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace KevinCastejon.MissingFeatures.MissingOperations
{
    public class CustomPropertyDrawerGenerator : Editor
    {
        [MenuItem("Assets/Missing Operations/Generate Custom Property Drawer", true)]
        private static bool GenerateCustomDrawerValidation()
        {
            string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());
            Type selectedType = AssetDatabase.GetMainAssetTypeAtPath(selectedPath);
            bool isScriptAsset = selectedType == typeof(MonoScript);
            return isScriptAsset;
        }

        [MenuItem("Assets/Missing Operations/Generate Custom Property Drawer")]
        private static void GenerateCustomDrawer()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            path = path.Substring(6);
            path = path.Substring(0, path.LastIndexOf("/"));
            MonoScript script = (MonoScript)Selection.activeObject;
            Type scriptClass = script.GetClass();
            if (script.GetClass().IsSubclassOf(typeof(ScriptableObject)) || script.GetClass().IsSubclassOf(typeof(MonoBehaviour)))
            {
                Debug.LogError("CustomPropertyDrawerGenerator only works with plain C# class");
                return;
            }
            FieldInfo[] pis = scriptClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            List<string> propsNames = new List<string>();
            for (int i = 0; i < pis.Length; i++)
            {
                propsNames.Add(pis[i].Name);
            }
            if (!Directory.Exists(Application.dataPath + path + "/Editor"))
            {
                AssetDatabase.CreateFolder("Assets" + path, "Editor");
            }
            string copyPath = Application.dataPath + path + "/Editor/" + scriptClass.Name + "Drawer.cs";
            if (!File.Exists(copyPath))
            {
                using (StreamWriter outfile =
                    new StreamWriter(copyPath))
                {
                    string nameSpace = scriptClass.Namespace;
                    outfile.WriteLine($"using System.Collections;");
                    outfile.WriteLine($"using System.Collections.Generic;");
                    outfile.WriteLine($"using UnityEngine;");
                    outfile.WriteLine($"using UnityEditor;");
                    if (nameSpace != null)
                    {
                        outfile.WriteLine($"namespace " + nameSpace);
                        outfile.WriteLine($"{{");
                    }
                    outfile.WriteLine($"");
                    outfile.WriteLine($"[CustomPropertyDrawer(typeof({scriptClass.Name}))]");
                    outfile.WriteLine($"public class {scriptClass.Name}Drawer : PropertyDrawer");
                    outfile.WriteLine($"{{");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)");
                    outfile.WriteLine($"    {{");
                    outfile.WriteLine($"");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        SerializedProperty {propName} = property.FindPropertyRelative(\"{propName}\");");
                    }
                    if (propsNames.Count == 0)
                    {
                        outfile.WriteLine($"        return 20f;");
                    }
                    else
                    {
                        outfile.WriteLine($"        return 20f +");
                    }
                    for (int i = 0; i < propsNames.Count; i++)
                    {
                        string propName = propsNames[i];
                        outfile.WriteLine($"            EditorGUI.GetPropertyHeight({propName}, true) " + (i == propsNames.Count - 1 ? ";" : "+"));
                    }
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    }}");
                    outfile.WriteLine($"    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)");
                    outfile.WriteLine($"    {{");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"        position = EditorGUI.IndentedRect(position);");
                    outfile.WriteLine($"        Rect rect = new Rect(position);");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        SerializedProperty {propName} = property.FindPropertyRelative(\"{propName}\");");
                    }
                    outfile.WriteLine($"        rect.height = 20f;");
                    outfile.WriteLine($"        EditorGUI.LabelField(rect, label);");
                    outfile.WriteLine($"        rect.y += rect.height;");
                    outfile.WriteLine($"        EditorGUI.indentLevel++;");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        rect.height = EditorGUI.GetPropertyHeight({propName}, true);");
                        outfile.WriteLine($"        EditorGUI.PropertyField(rect, {propName});");
                        outfile.WriteLine($"        rect.y += rect.height;");
                    }
                    outfile.WriteLine($"        EditorGUI.indentLevel--;");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    }}");
                    outfile.WriteLine($"}}");
                    if (nameSpace != null)
                    {
                        outfile.WriteLine($"}}");
                    }
                }
                AssetDatabase.Refresh();
                Debug.Log("CustomDrawer file created at " + copyPath);
            }
            else
            {
                Debug.LogError("The file " + copyPath + " already exists!");
            }
        }
    }
}