namespace Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nHello World from Custom Middleware! Start");
            await next(context);
            await context.Response.WriteAsync("\nHello World from Custom Middleware! End");
        }
        
    }
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            {
                return app.UseMiddleware<CustomMiddleware>();
            }
        }
    }
}
