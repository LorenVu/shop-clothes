using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace Clothes.Application.Services.Serialize;

public class SerializeService
{
    public string Serialize<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }
        });
    }

    public string Serialize<T>(T obj, Type type) =>
        JsonConvert.SerializeObject(obj, type, new JsonSerializerSettings());
    
    public T? Deserialize<T>(string text) =>
        JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings());
}