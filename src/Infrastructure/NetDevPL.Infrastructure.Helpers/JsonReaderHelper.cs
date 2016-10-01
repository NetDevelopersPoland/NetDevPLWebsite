using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace NetDevPL.Infrastructure.Helpers
{
    public class JsonReaderHelper
    {
        public static List<T> ReadObjectListFromJson<T>(string jsonPath)
        {
            string json = File.ReadAllText(jsonPath);
            var objects = JsonConvert.DeserializeObject<List<T>>(json);

            return objects.ToList();
        }
    }
}