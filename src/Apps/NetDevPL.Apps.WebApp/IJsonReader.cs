using System.Collections.Generic;

namespace NetDevPLWeb
{
    public interface IJsonReader
    {
        ICollection<T> ReadAll<T>(string filePath);
        T Read<T>(string filePath);
    }
}