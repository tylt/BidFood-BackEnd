using System;
using System.Threading.Tasks;

namespace BidFood.Infrastructure
{
    public interface IJsonService
    {
        Task<T> ReadJSONAsync<T>(string filePath);
        Task WriteJSONAsync(string filePath, dynamic data);
    }
}
