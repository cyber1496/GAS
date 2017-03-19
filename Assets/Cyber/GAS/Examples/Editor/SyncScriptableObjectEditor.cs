using UnityEngine;
using UnityEditor;

namespace Cyber.GAS.Examples
{
    public class SyncScriptableObjectEditor : EditorWindow
    {
        [MenuItem("Cyber/GAS/Examples/SyncScriptableObject")]
        static void Go()
        {
            GetWindow<SyncScriptableObjectEditor>();
        }

        static ContinuationManager continuationManager;

        void OnGUI()
        {
            EditorGUILayout.LabelField("SyncScriptableObject");
            if (GUILayout.Button("Sync"))
            {
                continuationManager = new ContinuationManager();
                SyncProcess<TestScriptableObject>(
                    "Assets/Cyber/GAS/Examples/TestScriptableObject.asset",
                    "ScriptableObject",
                    syncedData =>
                    {
                        foreach (var data in syncedData.Array)
                        {
                            Debug.LogFormat("id:{0} name:{1} number:{2} value:{3}", data.id, data.name, data.number, data.value);
                        }
                    }
                );
            }
            Progress();
        }

        void Progress()
        {
            if (continuationManager != null)
            {
                if (!continuationManager.IsDone)
                {
                    EditorUtility.DisplayProgressBar("Progress", "Synchronization progress", continuationManager.Progress);
                }
                else
                {
                    EditorUtility.ClearProgressBar();
                    continuationManager = null;
                }
            }
        }

        void SyncProcess<T>(string assetPath, string sheetName, System.Action<T> action)
            where T : ScriptableObject, ISyncScriptableObject
        {
        // For UnityWebRequest isDone does not return true...
        #if USE_UNITY_WEBREQUEST
            var request = Utility.CreateRequestGetSheetJson(sheetName);
            request.Send();
            continuationManager.Add(
                () => request.isDone,
                () =>
            {
                if (!string.IsNullOrEmpty(request.error))
                {
                    Debug.LogError(request.error);
                }
                else
                {
                    T data = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                    data.Deserialize(request.downloadHandler.text);
                    EditorUtility.SetDirty(data);
                    action(data);
                }
            });
        #else   //USE_WWW
            var request = Utility.CreateWWWGetSheetJson(sheetName);
            continuationManager.Add(
                () => request.isDone,
                () =>
            {
                if (!string.IsNullOrEmpty(request.error))
                {
                    Debug.LogError(request.error);
                }
                else
                {
                    T data = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                    data.Deserialize(request.text);
                    EditorUtility.SetDirty(data);
                    action(data);
                }
            });
        #endif
        }
    }

}