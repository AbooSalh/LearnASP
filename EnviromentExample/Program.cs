
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllers();
app.UseStaticFiles();
app.UseRouting();
app.Run();