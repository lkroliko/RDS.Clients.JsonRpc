using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RDS.Clients.JsonRpc;
using RDS.Clients.JsonRpc.Core;
using RDS.Clients.JsonRpc.Responses;
using RDS.Net.Connections.Abstractions;

namespace RDS.Clients.JsonRpc.Core
{
    internal class ReceiverHandler : IReceiverHandler
    {
        IConnection _connection;
        IResponseParser _responseParser;
        INotificationHandler _notificationHandler;
        IResultHandler _resultHandler;

        internal ReceiverHandler(IConnection connection, IResponseParser responseParser, INotificationHandler notificationHandler, IResultHandler resultHandler)
        {
            _connection = connection;
            _connection.Receiver.Received += ReceiverReceived;
            _responseParser = responseParser;
            _notificationHandler = notificationHandler;
            _resultHandler = resultHandler;
        }

        private void ReceiverReceived(object obj, ReceivedEventArgs args)
        {
            var response = _responseParser.ParseToResponse(args.Value);

            if (response.Type == ResponseTypes.Notification)
            {
                _notificationHandler.Handle(response);
            }
            else
            {
                _resultHandler.Handle(response);
            }   
        }    
    }
}
