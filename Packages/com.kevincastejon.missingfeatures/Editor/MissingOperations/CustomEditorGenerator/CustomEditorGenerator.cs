using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


namespace KevinCastejon.MissingFeatures.MissingOperations
{
    public class CustomEditorGenerator : Editor
    {
        [MenuItem("Assets/Missing Operations/Generate Custom Editor", true)]
        private static bool GenerateCustomEditorValidation()
        {
            string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());
            Type selectedType = AssetDatabase.GetMainAssetTypeAtPath(selectedPath);
            bool isScriptAsset = selectedType == typeof(MonoScript);
            return isScriptAsset;
        }

        [MenuItem("Assets/Missing Operations/Generate Custom Editor")]
        private static void GenerateCustomEditor()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            path = path.Substring(6);
            path = path.Substring(0, path.LastIndexOf("/"));
            MonoScript script = (MonoScript)Selection.activeObject;
            Type scriptClass;
            SerializedObject so;
            GameObject go = null;
            bool isScriptable = false;
            if (script.GetClass().IsSubclassOf(typeof(ScriptableObject)))
            {
                scriptClass = script.GetClass();
                so = new SerializedObject(CreateInstance(scriptClass));
                isScriptable = true;
            }
            else if (script.GetClass().IsSubclassOf(typeof(MonoBehaviour)))
            {
                go = new GameObject("CustomEditorGenerator");
                scriptClass = script.GetClass();
                Component cpt = go.AddComponent(scriptClass);
                so = new SerializedObject(cpt);
            }
            else
            {
                Debug.LogError("CustomEditorGenerator only works with MonoBehaviour or ScriptableObject script assets");
                return;
            }

            List<string> propsNames = new List<string>();
            SerializedProperty sp = so.GetIterator();
            if (sp.NextVisible(true))
            {
                do
                {
                    if (sp.name != "m_Script")
                    {
                        propsNames.Add(sp.name);
                    }
                }
                while (sp.NextVisible(false));
            }
            if (!isScriptable)
            {
                DestroyImmediate(go);
            }
            if (!Directory.Exists(Application.dataPath + path + "/Editor"))
            {
                AssetDatabase.CreateFolder("Assets" + path, "Editor");
            }
            string copyPath = Application.dataPath + path + "/Editor/" + scriptClass.Name + "Editor.cs";
            if (!File.Exists(copyPath))
            { // do not overwrite
                using (StreamWriter outfile =
                    new StreamWriter(copyPath))
                {
                    string nameSpace = scriptClass.Namespace;
                    outfile.WriteLine($"using System.Collections;");
                    outfile.WriteLine($"using System.Collections.Generic;");
                    outfile.WriteLine($"using UnityEditor;");
                    if (nameSpace != null)
                    {
                        outfile.WriteLine($"namespace " + nameSpace);
                        outfile.WriteLine($"{{");
                    }
                    outfile.WriteLine($"");
                    outfile.WriteLine($"[CustomEditor(typeof({scriptClass.Name}))]");
                    outfile.WriteLine($"public class {scriptClass.Name}Editor : Editor");
                    outfile.WriteLine($"{{");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"    private SerializedProperty {propName};");
                    }
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    private {scriptClass.Name} _script;");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    private void OnEnable()");
                    outfile.WriteLine($"    {{");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        {propName} = serializedObject.FindProperty(\"{propName}\");");
                    }
                    outfile.WriteLine($"");
                    outfile.WriteLine($"        _script = ({scriptClass.Name})target;");
                    outfile.WriteLine($"    }}");
                    outfile.WriteLine($"");
                    outfile.WriteLine($"    public override void OnInspectorGUI()");
                    outfile.WriteLine($"    {{");
                    outfile.WriteLine($"        serializedObject.Update();");
                    outfile.WriteLine($"");
                    foreach (string propName in propsNames)
                    {
                        outfile.WriteLine($"        EditorGUILayout.PropertyField({propName});");
                    }
                    outfile.WriteLine($"");
                    outfile.WriteLine($"        serializedObject.ApplyModifiedProperties();");
                    outfile.WriteLine($"    }}");
                    outfile.WriteLine($"}}");
                    if (nameSpace != null)
                    {
                        outfile.WriteLine($"}}");
                    }
                }
                AssetDatabase.Refresh();
                Debug.Log("Editor file created at " + copyPath);
            }
            else
            {
                Debug.LogError("The file " + copyPath + " already exists!");
            }
        }
    }
}