namespace AuthTask.Models;

public class Cart : BaseEntity
{
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    public ICollection<Product>? Products { get; set; }
}
