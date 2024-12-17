namespace MovieService.APIs.Dtos;

public class Movie
{
    public DateTime CreatedAt { get; set; }

    public string? Customer { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public string Id { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
