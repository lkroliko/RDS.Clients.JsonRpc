using Newtonsoft.Json;
using RDS.Clients.JsonRpc.Core;
using RDS.Net.Connections;
using RDS.Net.Connections.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RDS.Clients.JsonRpc
{
    public class JsonRpcClient
    {
        IConnection _connection;
        IRequestComposer _requestComposer;
        IResultHandler _resultHandler;
        INotificationHandler _notificationHandler;

        public event EventHandler<NotificationEventArgs> NotificationReceived { add { _notificationHandler.NotificationReceived += value; } remove { _notificationHandler.NotificationReceived -= value; } }

        internal JsonRpcClient(IConnection connection, IRequestComposer requestComposer, IResultHandler resultHandler, INotificationHandler notificationHandler)
        {
            _connection = connection;
            _requestComposer = requestComposer;
            _resultHandler = resultHandler;
            _notificationHandler = notificationHandler;
        }

        public void Start(CancellationToken token)
        {
            _connection.Start(token);
        }

        public T Send<T>(Params @params) where T : Result
        {
            var request = _requestComposer.Compose(@params);
            _connection.Sender.SendLine(request.Json);
            var response = _resultHandler.GetResponse<T>(request);
            return response?.Result;
        }
    }
}
