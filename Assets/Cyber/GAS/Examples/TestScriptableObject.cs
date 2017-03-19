using UnityEngine;
using Newtonsoft.Json;

namespace Cyber.GAS.Examples
{
    public class TestScriptableObject : ScriptableObject, ISyncScriptableObject
    {
        [SerializeField]
        public SerializeClass[] Array;

        public void Deserialize(string json)
        {
            Array = JsonConvert.DeserializeObject<SerializeClass[]>(json);
        }
    }
}