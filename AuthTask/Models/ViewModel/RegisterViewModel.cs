using System.ComponentModel.DataAnnotations;

namespace AuthTask.Models.ViewModel;

public class RegisterViewModel
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    [MinLength(5)]
    public string FullName { get; set; } = null!;

    [Required]
    public int Year { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
}
