﻿using System;
using RDS.Clients.JsonRpc;
using RDS.Clients.JsonRpc.Core;
using RDS.Clients.JsonRpc.Requests;
using RDS.Net.Connections.Abstractions;

namespace RDS.Devices.EvoLabel
{
    public class JsonRpcClientBuilder
    {
        public static JsonRpcClientBuilder New { get { return new JsonRpcClientBuilder(); } }

        IConnection _connection;
        Type _notificationBaseType;

        public JsonRpcClientBuilder UseConnection(IConnection connection)
        {
            _connection = connection;
            return this;
        }

        public JsonRpcClientBuilder SetNotificationBaseType(Type type)
        {
            _notificationBaseType = type;
            return this;
        }

        public JsonRpcClient Build()
        {
            IJsonConverter jsonConverter = new JsonConverter();
            IRequestComposer requestComposer = new RequestComposer(new RequestFactory(), jsonConverter);
            IResponseParser responseParser = new ResponseParser(jsonConverter);
            INotificationHandler notificationHandler = new NotificationHandler(responseParser, _notificationBaseType);
            IResultHandler resultHandler = new ResultHandler(responseParser);
            IReceiverHandler receiverHandler = new ReceiverHandler(_connection, responseParser, notificationHandler, resultHandler);
            return new JsonRpcClient(_connection, requestComposer, resultHandler, notificationHandler);
        }

        public static implicit operator JsonRpcClient(JsonRpcClientBuilder builder)
        {
            return builder.Build();
        }
    }
}
