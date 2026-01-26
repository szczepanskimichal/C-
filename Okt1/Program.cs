using Microsoft.Data.Sqlite;
using Dapper;


var connectionString = "Data Source=data/app.db";
using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();
    var sql = @"
    CREATE TABLE IF NOT EXISTS notes (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      title TEXT NOT NULL,
      body TEXT NOT NULL,
      createdUtc TEXT NOT NULL
    );";
    connection.Execute(sql);
}


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/health", () => "api is running");


app.MapGet("/notes", async () =>
{
  var connectionString = "Data Source=data/app.db";
  using var connection = new SqliteConnection(connectionString);
  await connection.OpenAsync();
  var sql = "SELECT id AS Id, title AS Title, body AS Body, createdUtc AS CreatedUtc FROM notes ORDER BY id";
  var notes = await connection.QueryAsync<Note>(sql);
  return Results.Ok(notes);
});

app.MapPost("/notes", async (CreateNote input) =>
{
  var connectionString = "Data Source=data/app.db";
  using var connection = new SqliteConnection(connectionString);
  await connection.OpenAsync();
  var createdUtc = DateTime.UtcNow.ToString("O");
  var sql = @"INSERT INTO notes (title, body, createdUtc)
        VALUES (@Title, @Body, @CreatedUtc);
        SELECT last_insert_rowid();";
  var id = await connection.QuerySingleAsync<long>(sql, new
  {
    input.Title,
    input.Body,
    CreatedUtc = createdUtc
  });
  return Results.Created($"/notes/{id}", new { id });
});

app.Run();

public class Note
{
  public long Id { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public string CreatedUtc { get; set; }
}

record CreateNote(string Title, string Body);