using RoutingExample;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("custom", typeof(CustomConstraints));
});
app.Map("/map1", async context =>
{
    await context.Response.WriteAsync("Hello from map1!");
});
app.Map("/map2", async context =>
{
    await context.Response.WriteAsync("Hello from map2!");
});
app.Map("files/{filename}.{extension?}", async context =>
{
    var filename = context.Request.RouteValues["filename"];
    var extension = context.Request.RouteValues["extension"];
    await context.Response.WriteAsync($"Hello from files! You requested: {filename}.{extension}");
});
app.Map("products/{id:int?:maxlength(5):custom}", async context =>
{
    int? id = (int?)context.Request.RouteValues["id"];
    await context.Response.WriteAsync($"Hello from products! You requested product with ID: {id}");
});
app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Hello from fallbacks!");
});
app.Run();
