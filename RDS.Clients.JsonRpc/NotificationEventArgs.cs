namespace RDS.Clients.JsonRpc
{
    public class NotificationEventArgs
    {
        public object Notification { get; }

        public NotificationEventArgs(object notification)
        {
            Notification = notification;
        }
    }
}