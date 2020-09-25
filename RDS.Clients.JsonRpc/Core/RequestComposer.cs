using RDS.Clients.JsonRpc.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDS.Clients.JsonRpc.Core
{
    internal class RequestComposer : IRequestComposer
    {
        IRequestFactory _requestFactory;
        IJsonConverter _jsonConverter;
        ushort _lastId = 0;

        public RequestComposer(IRequestFactory requestFactory, IJsonConverter jsonConverter)
        {
            _requestFactory = requestFactory;
            _jsonConverter = jsonConverter;
        }

        public Request Compose(Params @params)
        {
            var request = _requestFactory.Get();
            request.Id = _lastId++;
            request.Method = @params.Method;
            request.Params = @params;
            request.Json = _jsonConverter.SerializeObject(request);
            return request;
        }
    }
}
