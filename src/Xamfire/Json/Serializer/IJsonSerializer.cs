using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Json.Serializer
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T model);
        T Deserialize<T>(string json);
    }
}
