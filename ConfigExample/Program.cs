
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();
app.MapControllers();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync($"Current Environment: {app.Configuration.GetValue<string>("mykey","hi")}");
    });
});


app.Run();

