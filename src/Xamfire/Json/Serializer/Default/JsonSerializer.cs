using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Json.Serializer.Default
{
    public class JsonSerializer : IJsonSerializer
    {
        public JsonSerializer()
        {
            
        }

        public T Deserialize<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize<T>(T model)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }
    }
}
