using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Clients.JsonRpc.Errors
{
    internal class Error
    {
        [JsonProperty("message")]
        public string Message { get; private set; }

        [JsonProperty("code")]
        public int Code { get; private set; }

        [JsonProperty("data")]
        public string Data { get; private set; }
    }
}
