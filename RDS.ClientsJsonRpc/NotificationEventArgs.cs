namespace RDS.Clients.JsonRpc
{
    public class NotificationEventArgs
    {
        object Notification { get; }

        public NotificationEventArgs(object notification)
        {
            Notification = notification;
        }
    }
}