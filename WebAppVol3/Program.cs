using WebAppVol3.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IWelcomeService, WelcomeService>();
var app = builder.Build();

//app.MapGet("/", (WelcomeService welcomeService) => welcomeService.GetWelcomeMessage());
app.MapGet("/", async (IWelcomeService welcomeService1, IWelcomeService welcomeService2) =>
{
  var message1 = welcomeService1.GetWelcomeMessage();
  var message2 = welcomeService2.GetWelcomeMessage();
  return $"{message1}\n{message2}";
});
app.Run();
