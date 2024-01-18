using System.ComponentModel.DataAnnotations;

namespace AuthTask.Models.ViewModel;

public class LoginViewModel
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
