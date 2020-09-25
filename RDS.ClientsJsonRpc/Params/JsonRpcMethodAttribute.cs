using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc
{
    [AttributeUsage(AttributeTargets.Class)]
    public class JsonRpcMethodAttribute  : Attribute
    {
        public string Method { get; }

        public JsonRpcMethodAttribute(string method)
        {
            Method = method;
        }
    }
}
