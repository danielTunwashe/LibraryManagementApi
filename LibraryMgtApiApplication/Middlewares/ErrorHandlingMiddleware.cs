using LibraryMgtApiDomain.CustomeErrorEntity;
using LibraryMgtApiDomain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace LibraryMgtApiApplication.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment env) : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;
        private readonly IHostEnvironment _env= env;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                context.Response.ContentType = "application/json";

                int statusCode = ex switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    ArgumentException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var response = new ErrorDetails
                {
                    StatusCode = statusCode,
                    Message = ex.Message
                };

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                //context.Response.StatusCode = 404;
                //await context.Response.WriteAsync(notFound.Message);

                //_logger.LogWarning(notFound.Message);
            }
        }

       
    }
}
