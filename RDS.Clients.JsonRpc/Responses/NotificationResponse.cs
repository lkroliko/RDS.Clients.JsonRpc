using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc.Responses
{
    class NotificationResponse : Response
    {
        [JsonProperty("params")]
        public new object Notification { get; set; }
    }
}
