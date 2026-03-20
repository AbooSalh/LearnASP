using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    var request = context.Request;
    Dictionary<string, StringValues> querDic = QueryHelpers.ParseQuery(queryString: request.QueryString.ToString());
    
    var firstNumber = querDic["firstNumber"].ToString();
    var secondNumber = querDic["secondNumber"].ToString();
    var operation = querDic["operation"].ToString();
    
    if (string.IsNullOrEmpty(firstNumber) || string.IsNullOrEmpty(secondNumber))
        return "Error: firstNumber and secondNumber are required.";
    
    string result = operation switch
    {
        "add" => (double.Parse(firstNumber) + double.Parse(secondNumber)).ToString(),
        "subtract" => (double.Parse(firstNumber) - double.Parse(secondNumber)).ToString(),
        "multiply" => (double.Parse(firstNumber) * double.Parse(secondNumber)).ToString(),
        "divide" => double.Parse(secondNumber) != 0 ? (double.Parse(firstNumber) / double.Parse(secondNumber)).ToString() : "Error: Division by zero.",
        _ => "Error: Invalid operation. Use add, subtract, multiply, or divide."
    };
    return result;
});

app.Run();
