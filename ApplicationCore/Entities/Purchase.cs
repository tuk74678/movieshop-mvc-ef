using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Purchase
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime PurchaseDateTime { get; set; }
    public Guid PurchaseNumber { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal TotalPrice { get; set; }
    // Navigation properties
    public Movie Movie { get; set; }
    public User User { get; set; }
}