using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc
{
    public abstract class Params
    {
        [JsonIgnore]
        internal string Method { get { return ((JsonRpcMethodAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(JsonRpcMethodAttribute))).Method; } }
    }
}
