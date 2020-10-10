using Newtonsoft.Json;
using RDS.Clients.JsonRpc.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Clients.JsonRpc.Responses
{
    internal class Response 
    {
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }

        [JsonProperty("id")]
        public ushort Id { get; internal set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }

        [JsonProperty("params")]
        public object Notification { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonIgnore]
        public ResponseTypes Type { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
    }
}
