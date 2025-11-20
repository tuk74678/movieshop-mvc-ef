using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class MovieCast
{
    public int CastId { get; set; }
    [MaxLength(450)]
    public string Character { get; set; }
    public int MovieId { get; set; }
    // Navigation property
    public Cast Cast { get; set; }
    public Movie Movie { get; set; }
}