var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions
{
    // You can configure options here
    RequestPath = "/static"
});
app.MapGet("/", () => "Hello World!");

app.Run();
