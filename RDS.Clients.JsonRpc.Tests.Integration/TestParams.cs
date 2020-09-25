using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc.Tests.Integration
{
    [JsonRpcMethod("test.method")]
    class TestParams : Params
    {
        public string ParamsName { get; set; }
    }
}
