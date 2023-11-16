using System.Net;
using System.Text.Json;
using Talabat.APIs.Errors;

namespace Talabat.APIs.Middlewares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/jason";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                if (_env.IsDevelopment())
                {
                    var response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString());
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var jsonResponse = JsonSerializer.Serialize(response, options);
                    context.Response.WriteAsync(jsonResponse);
                }
                else
                {
                    var response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var jsonResponse = JsonSerializer.Serialize(response, options);
                    context.Response.WriteAsync(jsonResponse);
                }
            }
        }
    }
}
