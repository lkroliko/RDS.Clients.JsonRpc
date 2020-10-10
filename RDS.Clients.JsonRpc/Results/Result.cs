using RDS.Clients.JsonRpc.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Clients.JsonRpc
{
    public class Result
    {
        public Error RpcError { get; set; }
        public bool HasRpcError { get { return RpcError != null; } }
    }
}
