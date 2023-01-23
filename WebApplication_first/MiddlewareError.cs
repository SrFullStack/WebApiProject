using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication_first
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareError
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<MiddlewareError> _logger;

        public MiddlewareError(RequestDelegate next)
        {
            _next = next;
            //_logger = logger;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<MiddlewareError> logger)
        {
            try
            {
                await _next(httpContext);

            }
            catch
                (Exception e)
            {
                logger.LogError(e.Message);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.WriteAsync(e.Message);
            }


           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareErrorExtensions
    {
        public static IApplicationBuilder UseMiddlewareError(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareError>();
        }
    }
}
