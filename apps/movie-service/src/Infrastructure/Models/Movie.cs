using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Infrastructure.Models;

[Table("Movies")]
public class MovieDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerDbModel? Customer { get; set; } = null;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Range(-999999999, 999999999)]
    public int? Duration { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
