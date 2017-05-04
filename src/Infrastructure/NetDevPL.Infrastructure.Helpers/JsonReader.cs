using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NetDevPL.Infrastructure.Services
{
    public class JsonReader : IJsonReader
    {
        public T Read<T>(string filePath)
        {
            string json = ReadJson(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public ICollection<T> ReadAll<T>(string filePath)
        {
            string json = ReadJson(filePath);
            return JsonConvert.DeserializeObject<T[]>(json);
        }

        private static string ReadJson(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
