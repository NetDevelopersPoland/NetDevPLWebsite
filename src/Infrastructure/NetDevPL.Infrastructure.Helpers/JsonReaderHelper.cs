using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NetDevPL.Infrastructure.Helpers
{
    public class JsonReaderHelper
    {
        public static List<T> ReadObjectListFromJson<T>(string jsonPath)
        {
            string json = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}