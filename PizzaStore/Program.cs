using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

var builder = WebApplication.CreateBuilder(args);
//EFCORE - In-Memory DB
builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));
//SWAGGER/OPENAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "PizzaStore API",
    Description = "Making the best pizza in town",
    Version = "v1"
  });
});

var app = builder.Build();
//SWagger only in development
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API v1");
  });
}
// Serve static files from wwwroot (for a simple HTML test page)
app.UseDefaultFiles();
app.UseStaticFiles();
//GET ALL!!!
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
//app.MapGet("/", () => "Hello World!");
//POST CREATE PIZZA
app.MapPost("/pizzas", async (PizzaDb db, Pizza pizza) =>
{
  db.Pizzas.Add(pizza);
  await db.SaveChangesAsync();
  return Results.Created($"/pizzas/{pizza.Id}", pizza);
});

// GET by id
app.MapGet("/pizza/{id:int}", async (PizzaDb db, int id) =>
{
  var pizza = await db.Pizzas.FindAsync(id);
  return pizza is null ? Results.NotFound() : Results.Ok(pizza);
});

// PUT update
app.MapPut("/pizza/{id:int}", async (PizzaDb db, Pizza updatePizza, int id) =>
{
  var pizza = await db.Pizzas.FindAsync(id);
  if (pizza is null) return Results.NotFound();

  pizza.Name = updatePizza.Name;
  pizza.Description = updatePizza.Description;

  await db.SaveChangesAsync();
  return Results.NoContent();
});

// DELETE
app.MapDelete("/pizza/{id:int}", async (PizzaDb db, int id) =>
{
  var pizza = await db.Pizzas.FindAsync(id);
  if (pizza is null) return Results.NotFound();

  db.Pizzas.Remove(pizza);
  await db.SaveChangesAsync();
  return Results.Ok();
});

app.Run();