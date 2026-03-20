using Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddLogging();

var app = builder.Build();

// Add the LoginMiddleware to the pipeline
app.UseLoginMiddleware();

app.Run(async context =>
{
    await context.Response.WriteAsync("No response");
});

app.Run();