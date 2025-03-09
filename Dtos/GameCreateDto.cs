namespace GameStore.Dtos;

public record class GameCreateDto(string Name , string Genre , string Price , DateOnly ReleaseDate);
