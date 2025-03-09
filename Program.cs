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
app.MapPost("/games" , (GameCreateDto game) => {
    GameDto newgame = new GameDto(games.Count+1, game.Name, game.Genre, game.Price, game.ReleaseDate);
    games.Add(newgame);
    return Results.Created();  
});

app.MapPut("/games/{id}" , (int id , GameCreateDto game) => 
{
    int index = games.FindIndex(f => f.Id == id);
    if(index == -1)
    {
        return Results.NotFound();
    }
    games[index] = new GameDto(id,game.Name,game.Genre,game.Price,game.ReleaseDate);
    return Results.Accepted();
});

app.MapDelete("/games/{id}" , (int id) => {
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});
app.Run();
