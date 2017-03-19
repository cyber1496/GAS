using UnityEditor;

namespace Cyber.GAS
{
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
            EditorUtility.SetDirty(data);
        }
    }
}