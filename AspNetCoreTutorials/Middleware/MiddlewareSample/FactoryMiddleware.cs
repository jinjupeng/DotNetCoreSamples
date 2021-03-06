using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MiddlewareSample
{
    public static class MiddlewareExrensions
    {
        public static IApplicationBuilder UseFactoryActivatedMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FactoryActivatedMiddleware>();
        }
    }
    public class FactoryActivatedMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public FactoryActivatedMiddleware(ILoggerFactory logger)   // 
        {
            _logger = logger.CreateLogger<FactoryActivatedMiddleware>();

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // TODO  logic handler
            _logger.LogInformation("测试");
            await next(context);
            // TODO  logic handler
        }
    }
}