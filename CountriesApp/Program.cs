var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
string[] countries = ["USA", "Canada", "Mexico","India","Japan"];

app.MapGet("/countries", async (context) =>
{
    for (int i = 0; i < countries.Length; i++)
    {
        var country = countries[i];
        await context.Response.WriteAsync(i+1 + ", " + country + "\n");
    }
});

app.MapGet("/countries/{id:int}", async (context) =>
{
    if (int.TryParse(context.Request.RouteValues["id"]?.ToString(), out int id))
    {
        if (id >= 1 && id <= countries.Length)
        {
            var country = countries[id - 1];
            await context.Response.WriteAsync($"Country with ID {id}: {country}");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Country not found");
        }
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid ID");
    }
});
app.MapGet("/", () => "Hello World!");

app.Run();
