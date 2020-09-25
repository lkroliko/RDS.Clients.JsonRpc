using System;
using System.Threading;

namespace RDS.Clients.JsonRpc
{
    public interface IJsonRpcClient
    {
        event EventHandler<NotificationEventArgs> NotificationReceived;

        T Send<T>(Params @params) where T : Result;
        void Start(CancellationToken token);
    }
}