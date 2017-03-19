using UnityEngine;
using UnityEngine.Networking;

namespace Cyber.GAS
{
    public static class Utility
    {
        public static UnityWebRequest CreateRequestGetSheetJson(string sheetName)
        {
            return UnityWebRequest.Get(GenerateURL(sheetName));
        }
        public static WWW CreateWWWGetSheetJson(string sheetName)
        {
            return new WWW(GenerateURL(sheetName));
        }
        static string GenerateURL(string sheetName)
        {
            return string.Format("{0}?{1}&{2}",
                                SettingData.Instance.url,
                                Param("sheetId", SettingData.Instance.id),
                                Param("sheetName", sheetName));
        }
        static string Param(string key, string param)
        {
            return string.Format("{0}={1}", key, param);
        }
    }
}