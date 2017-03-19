using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Create an asset of ScriptableObject.
/// URL:http://baba-s.hatenablog.com/entry/2015/05/20/112328
/// </summary>
public static class ScriptableObjectCreator
{
    [MenuItem("Assets/Create/Scriptable Object")]
    private static void Create()
    {
        var instance = ScriptableObject.CreateInstance<ScriptableObject>();
        var directory = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (string.IsNullOrEmpty(directory))
        {
            directory = "Assets";
        }

        var extension = Path.GetExtension(directory);

        if (!string.IsNullOrEmpty(extension))
        {
            var filename = Path.GetFileName(directory);
            var startIndex = directory.LastIndexOf(filename) - 1;
            var count = filename.Length + 1;
            directory = directory.Remove(startIndex, count);
        }

        var path = directory + "/" + "NewScriptableObject.asset";
        var uniquePath = AssetDatabase.GenerateUniqueAssetPath(path);

        AssetDatabase.CreateAsset(instance, uniquePath);
        AssetDatabase.SaveAssets();
        Selection.activeObject = instance;
    }
}