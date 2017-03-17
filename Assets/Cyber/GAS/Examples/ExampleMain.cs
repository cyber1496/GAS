using System.Collections;
using UnityEngine;
using Newtonsoft.Json;

namespace Cyber.GAS
{
    public class ExampleMain : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine
            (
                GetData<TestData1[]>("Test1",
                    dataArray =>
                    {
                        foreach (var data in dataArray)
                        {
                            Debug.LogFormat("id:{0} name:{1} number:{2} value:{3}", data.id, data.name, data.number, data.value);
                        }
                    }
                )
            );
            StartCoroutine
            (
                GetData<TestData2[]>("Test2",
                    dataArray =>
                    {
                        foreach (var data in dataArray)
                        {
                            Debug.LogFormat("id:{0} name:{1} type:{2} value:{3} number:{4}", data.id, data.name, data.type, data.value, data.number);
                        }
                    }
                )
            );
        }
        IEnumerator GetData<T>(string sheetName, System.Action<T> action)
        {
            var request = Utility.CreateRequestGetSheetJson(sheetName);
            if (request == null)
            {
                yield break;
            }
            yield return request.Send();
            if (request.isError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                action(JsonConvert.DeserializeObject<T>(request.downloadHandler.text));
            }
        }
        class TestData1
        {
            public int id = 0;
            public string name = string.Empty;
            public int number = 0;
            public float value = 0f;
        }
        class TestData2
        {
            public int id = 0;
            public string name = string.Empty;
            public string type = string.Empty;
            public int value = 0;
            public float number = 0f;
        }
    }
}