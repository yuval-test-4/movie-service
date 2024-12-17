namespace MovieService.APIs.Dtos;

public class CustomerUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<string>? Movies { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
