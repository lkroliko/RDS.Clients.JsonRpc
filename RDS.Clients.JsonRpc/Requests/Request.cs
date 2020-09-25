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
        [JsonProperty("params", Order = 2)]
        public Params Params { get; set; } 

        [JsonProperty("id", Order = 3)]
        public ushort Id { get; set; }

        [JsonProperty("jsonrpc", Order = 4)]
        public string Jsonrpc { get; set; } = "2.0";

        [JsonProperty("method", Order = 1)]
        public string Method { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
    }
}
