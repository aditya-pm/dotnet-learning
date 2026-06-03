using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data Source=GameStore.db";
// dependency injection below (we inject GameStoreContext)
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

// equivalent to: dotnet ef database update
// NOTE: not equivalent to: dotnet ef migrations add 
app.MigrateDb();

app.Run();
