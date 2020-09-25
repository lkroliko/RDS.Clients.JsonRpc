using Moq;
using Newtonsoft.Json;
using RDS.Devices.EvoLabel;
using RDS.Net.Connections.Abstractions;
using System;
using System.Reflection;
using Xunit;

namespace RDS.Clients.JsonRpc.Tests.Integration
{
    [Trait("Category", "Integration")]
    public class Integration
    {
        IConnection _connection = Mock.Of<IConnection>();
        ISender _sender = Mock.Of<ISender>();
        IReceiver _receiver = Mock.Of<IReceiver>();
        JsonRpcClient _client;

        public Integration()
        {
            Mock.Get(_connection).Setup(c => c.Sender).Returns(_sender);
            Mock.Get(_connection).Setup(c => c.Receiver).Returns(_receiver);
            _client = new JsonRpcClientBuilder().UseConnection(_connection).SetNotificationBaseType(typeof(TestNotificationBase)).Build();
        }

        [Fact]
        public void GivenParamsThenSenderSendCalled()
        {
            TestParams testParams = new TestParams() { ParamsName = "test name" };

            _client.Send<Result>(testParams);

            Mock.Get(_sender).Verify(s => s.SendLine("{\"params\":{\"ParamsName\":\"test name\"},\"id\":0,\"jsonrpc\":\"2.0\",\"method\":\"test.method\"}"), Times.Once);
        }

        [Fact]
        public void GivenResultThenResultReturned()
        {
            TestParams testParams = new TestParams();
            Mock.Get(_sender).Setup(s => s.SendLine(It.IsAny<string>())).Callback(() =>
            {
                Mock.Get(_receiver).Raise(r => r.Received += null, new ReceivedEventArgs("{\"result\": {\"ResultName\": \"test name\"}, \"id\": 0, \"jsonrpc\": \"2.0\"}"));
            });

            var result = _client.Send<TestResult>(testParams);
            
            Assert.Equal("test name", result.ResultName);
        }

        [Fact]
        public void GivenNotificationThenEventNotificationReceivedCalled()
        {
            int callCount = 0;
            _client.NotificationReceived += (sender, args) =>
            {
                callCount++;
            };

            Mock.Get(_receiver).Raise(r => r.Received += null, new ReceivedEventArgs("{\"params\": {\"NotificationName\": \"test name\"}, \"method\":\"notification.test\", \"jsonrpc\": \"2.0\"}"));

            Assert.Equal(1, callCount);
        }
    }
}
