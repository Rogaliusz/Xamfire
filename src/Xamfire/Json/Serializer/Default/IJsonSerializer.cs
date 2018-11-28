using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Json.Serializer.Default
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T model);
        T Deserialize<T>(string json);
    }
}
