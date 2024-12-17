namespace MovieService.APIs.Dtos;

public class MovieCreateInput
{
    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public string? Id { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
