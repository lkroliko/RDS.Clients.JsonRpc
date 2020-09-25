using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Clients.JsonRpc.Responses
{
    internal class ResultResponse<T> : Response where T: Result
    {
        [JsonProperty("result")]
        public new T Result { get; set; }
    }
}
