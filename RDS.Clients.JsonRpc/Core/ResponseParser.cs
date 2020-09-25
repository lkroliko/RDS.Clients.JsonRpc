using System;
using System.Collections.Generic;
using System.Text;
using RDS.Clients.JsonRpc;
using RDS.Clients.JsonRpc.Responses;

namespace RDS.Clients.JsonRpc.Core
{
    internal class ResponseParser : IResponseParser
    {
        IJsonConverter _jsonConverter;

        public ResponseParser(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public Response ParseToResponse(string json) 
        {
            var response = _jsonConverter.DeserializeObject<Response>(json);
            response.Json = json;
            response.Type = GetType(response);
            return response;
        }

        public ResultResponse<T> ParseToResultResponse<T>(string json) where T : Result
        {
            var response = _jsonConverter.DeserializeObject<ResultResponse<T>>(json);
            response.Json = json;
            return response;
        }

        public void ParseToObject(Response response, object target)
        {
            _jsonConverter.PopulateObject(response.Json, target);
        }

        private ResponseTypes GetType(Response response)
        {
            if (response.Result != null)
                return ResponseTypes.Result;
            if (response.Notification != null)
                return ResponseTypes.Notification;
            return ResponseTypes.Error;
        }
    }
}
