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
        private readonly ILogger<MiddlewareError> _Ilogger;

        public MiddlewareError(RequestDelegate next, ILogger<MiddlewareError> logger)
        {
            _next = next;
            _Ilogger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch
                (Exception e)
            {
                _Ilogger.LogError(e.Message);
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
