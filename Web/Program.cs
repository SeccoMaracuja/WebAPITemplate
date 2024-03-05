using Lamar.Microsoft.DependencyInjection;
using Web;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLamar(registry =>
{
    LamarConfiguration.Configure(registry, builder.Configuration, builder.Environment);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YourProject.Web.API V1"));
}

// Exception Handler
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();