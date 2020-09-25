using RDS.Clients.JsonRpc;
using RDS.Clients.JsonRpc.Responses;
using System;

namespace RDS.Clients.JsonRpc.Core
{
    internal interface IResponseParser
    {
        Response ParseToResponse(string json);
        ResultResponse<T> ParseToResultResponse<T>(string json) where T : Result;
        void ParseToObject(Response response, object target);
    }
}