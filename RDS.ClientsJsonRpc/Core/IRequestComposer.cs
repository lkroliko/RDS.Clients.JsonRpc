using RDS.Clients.JsonRpc.Requests;

namespace RDS.Clients.JsonRpc.Core
{
    internal interface IRequestComposer
    {
        Request Compose(Params @params);
    }
}