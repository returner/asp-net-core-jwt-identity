﻿using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BusinessLayer.Behaviors
{
    public class LoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggerBehavior<TRequest, TResponse>> _logger;

        public LoggerBehavior(ILogger<LoggerBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Request : {typeof(TRequest).Name}");

            var response = await next.Invoke();

            _logger.LogInformation($"Response: {typeof(TResponse).Name + Environment.NewLine} Response Content: {JsonConvert.SerializeObject(response)}");

            return response;
        }
    }
}
