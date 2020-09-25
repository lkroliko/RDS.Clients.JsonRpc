using System;

namespace RDS.Clients.JsonRpc
{
    public class NotificationEventArgs : EventArgs
    {
        public object Notification { get; }

        public NotificationEventArgs(object notification)
        {
            Notification = notification;
        }
    }
}