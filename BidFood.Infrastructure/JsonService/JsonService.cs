using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace BidFood.Infrastructure
{
    public class JsonService:IJsonService
    {
       
        public async Task<T> ReadJSONAsync<T>(string filePath)
        {
            try
            {
                using FileStream stream = File.OpenRead(filePath);
                return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(stream);
            }
            catch
            {
                throw;
            }
        }

        public async Task WriteJSONAsync(string filePath,dynamic data)
        {
            try
            {
                await System.IO.File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch
            {
                throw;
            }
        }

    }
}
