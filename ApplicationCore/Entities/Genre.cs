using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Genre
{
    // use data annotation to configure data models
    [Key]
    public int Id { get; set; }
    [MaxLength(24)]
    public string Name { get; set; }
    
    // Navigation properties
    public ICollection<MovieGenre> MovieGenres { get; set; }
}