using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Genre
{
    // use data annotation to configure data models
    [Key]
    public int id { get; set; }
    [MaxLength(24)]
    public string name { get; set; }
}