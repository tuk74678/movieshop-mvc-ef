using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Role
{
    // use data annotation to configure data models
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
}