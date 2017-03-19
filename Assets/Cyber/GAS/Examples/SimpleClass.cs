using System.Collections;
namespace Cyber.GAS.Examples
{
    public class SimpleClass
    {
        public int id = 0;
        public string name = string.Empty;
        public int number = 0;
        public float value = 0f;
    }

    [System.Serializable]
    public class SerializeClass
    {
        public int id = 0;
        public string name = string.Empty;
        public int number = 0;
        public float value = 0f;
    }
}