using System.ComponentModel.DataAnnotations;

namespace AuthTask.Models.ViewModel;

public class UpdateProductViewModel
{
    public int Id { get; set; }
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
