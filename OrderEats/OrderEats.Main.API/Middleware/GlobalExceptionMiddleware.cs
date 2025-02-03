using System.Net;
using System.Text.Json;

namespace OrderEats.Main.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleUnauthorizedException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleUnauthorizedException(HttpContext context, UnauthorizedAccessException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";

            var response = new { Message = "Unauthorized", Error = ex.Message };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new { Message = "An error occurred", Error = ex.Message };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
