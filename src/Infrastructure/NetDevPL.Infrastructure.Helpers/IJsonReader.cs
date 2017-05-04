using System.Collections.Generic;

namespace NetDevPL.Infrastructure.Services
{
    public interface IJsonReader
    {
        ICollection<T> ReadAll<T>(string filePath);
        T Read<T>(string filePath);
    }
}