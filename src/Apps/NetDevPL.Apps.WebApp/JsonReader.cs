using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NetDevPLWeb
{
    public class JsonReader : IJsonReader
    {
        public T Read<T>(string filePath)
        {
            string json = ReadJson<T>(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public ICollection<T> ReadAll<T>(string filePath)
        {
            string json = ReadJson<T>(filePath);
            return JsonConvert.DeserializeObject<T[]>(json);
        }

        private static string ReadJson<T>(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
