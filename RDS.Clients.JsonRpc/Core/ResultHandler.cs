using RDS.Clients.JsonRpc.Requests;
using RDS.Clients.JsonRpc.Responses;
using RDS.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RDS.Clients.JsonRpc.Core
{
    class ResultHandler : IResultHandler
    {
        IResponseParser _responseParser;
        List<Response> _responses = new List<Response>();
        ILogger _logger;

        public ResultHandler(IResponseParser responseParser, ILogger logger)
        {
            _responseParser = responseParser;
            _logger = logger;
        }

        public void Handle(Response response)
        {
            _responses.Add(response);
        }

        public ResultResponse<T> GetResponse<T>(Request request) where T : Result
        {
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(i * 5);
                Response response = _responses.Find(t => t.Id == request.Id);
                if (response != null)
                {
                    _responses.Remove(response);
                    var resultResponse = _responseParser.ParseToResultResponse<T>(response.Json);
                    if (resultResponse.Result == null)
                        resultResponse.Result = Activator.CreateInstance<T>();
                    resultResponse.Result.RpcError = resultResponse.Error;
                    return resultResponse;
                }
            }
            _logger.Warning($"Timeout for respond for request {request.Id}");
            return null;
        }
    }
}