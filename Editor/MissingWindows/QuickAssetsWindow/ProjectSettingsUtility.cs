using UnityEngine;
using System.IO;
using KevinCastejon.MissingFeatures.MissingWindows;

public static class ProjectSettingsUtility
{
    private static readonly string ProjectSettingsPath = Path.Combine(Application.dataPath, "../ProjectSettings/QuickAssets/QuickAssetsList.asset");

    public static void SaveMyData(QuickAssetsSO myData)
    {
        if (myData == null)
        {
            Debug.LogError("QuickAssets object is null. Cannot save.");
            return;
        }

        // Serialize the ScriptableObject to JSON
        string jsonData = JsonUtility.ToJson(myData);
        if (!Directory.Exists(Path.Combine(Application.dataPath, "../ProjectSettings/QuickAssets")))
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "../ProjectSettings/QuickAssets"));
        }
        // Write the JSON to the ProjectSettings folder
        File.WriteAllText(ProjectSettingsPath, jsonData);
    }

    public static QuickAssetsSO LoadMyData()
    {
        if (!File.Exists(ProjectSettingsPath))
        {
            Debug.LogWarning("No QuickAssets file found. Creating a new one.");
            QuickAssetsSO myData = ScriptableObject.CreateInstance<QuickAssetsSO>();
            SaveMyData(myData);
            return myData;
        }

        // Read the JSON from the file
        string jsonData = File.ReadAllText(ProjectSettingsPath);

        // Create an instance of MyData and populate it with the JSON data
        QuickAssetsSO loadedData = ScriptableObject.CreateInstance<QuickAssetsSO>();
        JsonUtility.FromJsonOverwrite(jsonData, loadedData);
        return loadedData;
    }
}