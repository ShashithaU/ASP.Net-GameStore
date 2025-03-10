using System;
using System.IO.Compression;
using GameStore.Dtos;

namespace GameStore.EndPoints;

public static class GameEndPoints
{
    private static readonly List<GameDto> games = [
        new (1, "GTA V", "Action", "50", new DateOnly(2013, 9, 17)),
    new (2, "FIFA 22", "Sports", "60", new DateOnly(2021, 10, 1)),
    new (3, "Cyberpunk 2077", "RPG", "40", new DateOnly(2020, 12, 10))
    ];

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {

        var group = app.MapGroup("/games");

        group.MapGet("/", () => games);
        
        group.MapGet("/{id}", (int id) => games.FindAll(game => game.Id == id));
        group.MapPost("/", (GameCreateDto game) =>
        {
            GameDto newgame = new GameDto(games.Count + 1, game.Name, game.Genre, game.Price, game.ReleaseDate);
            games.Add(newgame);
            return Results.Created();
        }).WithParameterValidation();

        group.MapPut("/{id}", (int id, GameCreateDto game) =>
        {
            int index = games.FindIndex(f => f.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto(id, game.Name, game.Genre, game.Price, game.ReleaseDate);
            return Results.Accepted();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
        return group;
    }
}