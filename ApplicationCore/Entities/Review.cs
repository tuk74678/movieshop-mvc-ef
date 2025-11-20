using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Review
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime CreatedDate { get; set; }
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; }
    [Column(TypeName = "nvarchar(max)")]
    public string ReviewText { get; set; }
    // Navigation properties
    public Movie Movie { get; set; }
    public User User { get; set; }
}