using System.ComponentModel.DataAnnotations;

namespace AuthTask.Models.ViewModel;

public class AddProductViewModel
{
    [Required]
    [MinLength(2)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(5)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public double Price { get; set; }
}
