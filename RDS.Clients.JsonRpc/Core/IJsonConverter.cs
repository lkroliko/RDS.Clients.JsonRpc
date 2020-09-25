using System;

namespace RDS.Clients.JsonRpc.Core
{
    internal interface IJsonConverter
    {
        string SerializeObject(object value);
        T DeserializeObject<T>(string json);
        object DeserializeObject(string json, Type type);
        void PopulateObject(string json, object target);
    }
}