using System.IO;
using UnityEngine;
using UnityEditor;

namespace Cyber.GAS
{
    public class SettingDataEditor
    {
        [MenuItem("Cyber/GAS/Create Setting Asset")]
        static void CreateSettingAsset()
        {
            string path = string.Format("{0}{1}.asset", "Assets/Resources/", SettingData.AssetPath);
            string fullPath = Path.GetFullPath(path);
            if (File.Exists(fullPath))
            {
                return;
            }
            string directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SettingData>(), path);
            AssetDatabase.Refresh();
        }
    }
    [CustomEditor(typeof(SettingData))]
    public class SettingDataInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            SettingData data = target as SettingData;
            EditorGUILayout.LabelField("URL:The spreadsheet URL.(https://docs.google.com/spreadsheets/d/XXXX)");
            data.url = EditorGUILayout.TextField(data.url);
            EditorGUILayout.LabelField("ID:ID passed to SpreadsheetApp.openById in Google Apps Script.");
            data.id = EditorGUILayout.TextField(data.id);
        }
    }
}