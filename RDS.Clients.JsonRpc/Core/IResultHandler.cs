using RDS.Clients.JsonRpc.Requests;
using RDS.Clients.JsonRpc.Responses;

namespace RDS.Clients.JsonRpc.Core
{
    interface IResultHandler
    {
        ResultResponse<T> GetResponse<T>(Request request) where T : Result;
        void Handle(Response response);
    }
}