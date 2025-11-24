namespace ApplicationCore.Models;

public class MovieCardModel
{
    // data to be presented to the UI
    public int Id { get; set; }
    public string Title { get; set; }
    public string PosterUrl { get; set; }
    public string Character { get; set; }
}