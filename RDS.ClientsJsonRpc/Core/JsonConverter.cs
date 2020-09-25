using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RDS.Clients.JsonRpc.Core
{
    internal class JsonConverter : IJsonConverter
    {
        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public object DeserializeObject(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json,type);
        }

        public void PopulateObject(string json, object target)
        {
            JsonConvert.PopulateObject(json, target);
        }
    }
}
