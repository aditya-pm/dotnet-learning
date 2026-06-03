namespace GameStore.Api.Models;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Genre? Genre { get; set; }  // Navigation property
    public int GenreId { get; set; }  // Foreign Key
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
