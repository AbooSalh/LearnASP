using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    var request = context.Request;
    Dictionary<string, StringValues> querDic = QueryHelpers.ParseQuery(queryString: request.QueryString.ToString());
    foreach (var item in querDic)
    {
        Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
    }
    return "Hello Worldss!";
});

app.Run();
