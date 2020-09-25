using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Clients.JsonRpc.Requests
{
    internal class Request
    {
        [JsonProperty("params")]
        public Params Params { get; set; } 

        [JsonProperty("id")]
        public ushort Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
    }
}
