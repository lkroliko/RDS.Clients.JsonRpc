using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc.Requests
{
    internal class RequestFactory : IRequestFactory
    {
        public Request Get()
        {
            return new Request();
        }
    }
}
