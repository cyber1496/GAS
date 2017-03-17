using UnityEngine;

namespace Cyber.GAS
{
    public class SettingData : ScriptableObject
    {
        public static string AssetPath = "GAS/SettingData";
        static SettingData instance;
        public static SettingData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<SettingData>(AssetPath);
                }
                return instance;
            }
        }
        public string url;
        public string id;
    }
}
