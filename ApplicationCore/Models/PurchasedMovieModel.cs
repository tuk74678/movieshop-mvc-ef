namespace ApplicationCore.Models;

public class PurchasedMovieModel
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public Guid PurchaseNumber { get; set; }
    public decimal TotalPrice { get; set; }
    
    public MovieCardModel Movie { get; set; }
}