using MediatR;

namespace TodoApi.Behaviors
{
    public class LoggingRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingRequestBehavior<TRequest, TResponse>> _logger;

        public LoggingRequestBehavior(ILogger<LoggingRequestBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler {Request} started", typeof(TRequest).Name);
            var response = await next();
            _logger.LogInformation("Handler {Request} finished", typeof(TRequest).Name);
            return response;
        }
    }
}