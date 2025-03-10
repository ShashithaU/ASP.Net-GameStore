using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class GameCreateDto(
    [Required][StringLength(50)] string Name , 
    [Required][StringLength(20)]string Genre , 
    [Range(1,100)]string Price , 
    DateOnly ReleaseDate);
