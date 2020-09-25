using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc.Tests.Integration
{
    [JsonRpcMethod("notification.test")]
    class TestNotification : TestNotificationBase
    {
        public string NotificationName { get; set; }
    }
}
