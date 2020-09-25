using Moq;
using RDS.Clients.JsonRpc.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace RDS.Clients.JsonRpc.Tests.Unit.Core.NotificationHandlerTests
{
    [Trait("Category", "NotificationHandler")]
    public class Class
    {
        IResponseParser _responseParser = Mock.Of<IResponseParser>();

        [Fact]
        public void ItExists()
        {
            new NotificationHandler(_responseParser, this.GetType());
        }

        [Fact]
        public void WhenTypeIsNullThenNoException()
        {
            new NotificationHandler(_responseParser, null);
        }
    }
}
