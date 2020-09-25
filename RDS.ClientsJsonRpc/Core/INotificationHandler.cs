using RDS.Clients.JsonRpc.Responses;
using System;

namespace RDS.Clients.JsonRpc.Core
{
    interface INotificationHandler
    {
        event EventHandler<NotificationEventArgs> NotificationReceived;
        void Handle(Response response);
    }
}