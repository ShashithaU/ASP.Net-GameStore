using GameStore.Dtos;
using GameStore.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndPoints();

app.Run();
