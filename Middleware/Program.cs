using Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

// Middleware is a software component that is assembled into an application pipeline to handle requests and responses. Each component:
// Middleware 1
app.Use(async (context,  next) =>
{
    await context.Response.WriteAsync("Hello World!");
    await next(context);
});
// Middleware 2
app.UseMiddleware<CustomMiddleware>();
app.UseMiddleware<CustomMiddleware>();
app.UseWhen(context => context.Request.Path.StartsWithSegments("/hello"), builder =>
{
    builder.UseHelloCustomMiddleware();
});
app.Run();