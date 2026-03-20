using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Login
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoginMiddleware> _logger;

        public LoginMiddleware(RequestDelegate next, ILogger<LoginMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                // Set the response content type
                httpContext.Response.ContentType = "text/plain";

                // Check if the request has form content
                if (!httpContext.Request.HasFormContentType)
                {
                    _logger.LogWarning("Unsupported content type: {ContentType}", httpContext.Request.ContentType);
                    httpContext.Response.StatusCode = StatusCodes.Status415UnsupportedMediaType;
                    await httpContext.Response.WriteAsync("Unsupported content type. Please use application/x-www-form-urlencoded.");
                    return;
                }

                // Try to retrieve form values
                httpContext.Request.Form.TryGetValue("email", out var email);
                httpContext.Request.Form.TryGetValue("password", out var password);

                // Validate credentials
                if (email == "admin@example.com" && password == "admin1234")
                {
                    _logger.LogInformation("Login successful for email: {Email}", email);
                    httpContext.Response.StatusCode = StatusCodes.Status200OK;
                    await httpContext.Response.WriteAsync("Login successful!");
                }
                else
                {
                    _logger.LogWarning("Invalid login attempt for email: {Email}", email);
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the login request.");

                // Return a generic error response
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync("An unexpected error occurred. Please try again later.");
            }

            // Call the next middleware in the pipeline
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
