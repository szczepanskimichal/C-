var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseExceptionHandler("/error");

app.MapGet("/weatherforecast", () =>
{
    throw new ArgumentException();
    var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
        .ToArray();
    return Results.Ok(forecast);
});



app.MapGet("/error", () =>
{
    return Results.Problem(
        title: "An unexpected error occurred.",
        statusCode: 500);
});

//app.MapGet("/weatherforecast", () =>
//{
//    try
//    {
//        //throw new ArgumentException();
//        var forecast = Enumerable.Range(1, 5).Select(index =>
//                new WeatherForecast
//                (
//                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                    Random.Shared.Next(-20, 55),
//                    summaries[Random.Shared.Next(summaries.Length)]
//                ))
//            .ToArray();
//        return Results.Ok(forecast);
//    }
//    catch
//    {
//        return Results.NotFound("error");
//    }
//});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
