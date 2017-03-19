using System.Collections;
using UnityEngine;
using Newtonsoft.Json;

namespace Cyber.GAS.Examples
{
    public class SheetToSimpleClassMain : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine
            (
                GetData<SimpleClass[]>("SimpleClassData",
                    dataArray =>
                    {
                        foreach (var data in dataArray)
                        {
                            Debug.LogFormat("id:{0} name:{1} number:{2} value:{3}", data.id, data.name, data.number, data.value);
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
    }
}