using GameStore.Api.Data;
using GameStore.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreDb();

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

// equivalent to: dotnet ef database update
// NOTE: not equivalent to: dotnet ef migrations add 
app.MigrateDb();

app.Run();
