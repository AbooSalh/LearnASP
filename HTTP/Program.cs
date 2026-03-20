var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{

    var request = context.Request;
    var response = context.Response;
    // Log the request method and path
    Console.WriteLine($"Received {request.Method} request for {request.Path}");
    // Set a custom header in the response
    response.Headers["X-Custom-Header"] = "Hello from ASP.NET Core!";
    Console.WriteLine($"Sent response wisth custom : {response.Headers["X-Custom-Header"]}");
    // Return a simple response
    return "Hello World!";
});

app.Run();
