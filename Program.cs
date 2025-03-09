using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (1, "GTA V", "Action", "50", new DateOnly(2013, 9, 17)),
    new (2, "FIFA 22", "Sports", "60", new DateOnly(2021, 10, 1)),
    new (3, "Cyberpunk 2077", "RPG", "40", new DateOnly(2020, 12, 10))
];


app.MapGet("/games", () => games);
app.MapGet("/", () => "Hello World!");
app.MapGet("games/{id}", (int id) => games.FindAll(game => game.Id == id));
app.MapPost("/games" , ())
app.Run();
