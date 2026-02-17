/*

using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//custom middleware
app.Use(async (context, next) =>
{
  await next();
  System.Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});
app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

app.MapGet("/", () => "Hello World! Michal made this app for you :)");
app.MapGet("/about", () => "This is a simple wsdsddsdeb application adsadsadssabuilt with ASsadsadsP.NET Core.");

app.Run();
*/

using MyWebbAppVol2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IPersonService, PersonService>();
var app = builder.Build();

app.MapGet("/", (IPersonService personService) =>
{
  return $"Hellooooooooo {personService.GetPersonName()}!";
});
app.Run();