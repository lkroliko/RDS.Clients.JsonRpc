using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using RDS.Clients.JsonRpc.Responses;
using System.Net.Http.Headers;

namespace RDS.Clients.JsonRpc.Core
{
    class NotificationHandler : INotificationHandler
    {
        public event EventHandler<NotificationEventArgs> NotificationReceived;
        internal virtual void OnNotificationReceived(NotificationEventArgs args) { NotificationReceived.Invoke(this, args); }

        Dictionary<string, Type> _methodTypeDictionary = new Dictionary<string, Type>();
        IResponseParser _responseParser;

        internal NotificationHandler(IResponseParser responseParser, Type notificationBaseType)
        {
            RegisterNotifications(notificationBaseType);
            _responseParser = responseParser;
        }

        public void Handle(Response response)
        {
            if (_methodTypeDictionary.Keys.Contains(response.Method))
            {
                var notificationResponse = new NotificationResponse();
                notificationResponse.Notification = Activator.CreateInstance(_methodTypeDictionary[response.Method]);

                _responseParser.ParseToObject(response, notificationResponse);
                OnNotificationReceived(new NotificationEventArgs(notificationResponse.Notification));
            }
        }

        private void RegisterNotifications(Type type)
        {
            if (type == null)
                return;

            var subclassTypes = Assembly
            .GetAssembly(type)
            .GetTypes()
            .Where(t => t.IsSubclassOf(type));

            subclassTypes.ToList().ForEach((t) =>
            {
                var method = ((JsonRpcMethodAttribute)Attribute.GetCustomAttribute(t, typeof(JsonRpcMethodAttribute))).Method;
                _methodTypeDictionary[method] = t;
            });
        }
    }
}
