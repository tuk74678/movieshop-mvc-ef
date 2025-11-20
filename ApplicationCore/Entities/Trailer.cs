using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Trailer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(2084)]
    public string Name { get; set; }
    [MaxLength(2084)]
    public string TrailerUrl { get; set; } 
    [ForeignKey("Movies")]
    // Foreign Key
    public int MovieId { get; set; }
    // Navigation property
    public Movie Movie { get; set; }
}