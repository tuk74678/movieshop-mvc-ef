using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Models;

public class RegisterViewModel
{
    [Display(Name = "First name")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Display(Name = "Last name")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
    
    [Display(Name = "Email address")]
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email")]
    public string EmailAddress { get; set; }

    [Display(Name = "Date of birth")]
    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Confirm password")]
    [Required(ErrorMessage = "Confirm password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
}