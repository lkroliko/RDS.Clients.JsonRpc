# JsonRpc Client

1) Classes which are used as params need to inherit from "Params" class and have JsonRpcMethod attribute with method name.


```c#
//{"jsonrpc": "2.0", "method": "method.name", "params": {"Value": 42, "Name": "name"}, "id": 1}
[JsonRpcMethod("method.name")]
class TestParams : Params
{
  public int Value { get; set; }
  public string Name { get; set; }
}
```

2) Classes which are used as result need to inherit from "Result" class.
```c#
//{"jsonrpc": "2.0", "result": {"Value": "value"}, "id": 1}
class TestResult : Result
{
  public string Value { get; set; }
}
```

3) To receive notification base class need to be registered via builder in SetNotificationBaseType method. Notification classes need to inherit from registered base class and have JsonRpcMethod attribute with method name.

```c#
class Notification
{

}
```
```c#
[JsonRpcMethod("method.notification")]
class SpecificNotification : Notification
{
  public string Value { get; set; }
}
```
```c#
var _client = new JsonRpcClientBuilder().UseConnection(_connection).SetNotificationBaseType(typeof(Notification)).Build();
```
