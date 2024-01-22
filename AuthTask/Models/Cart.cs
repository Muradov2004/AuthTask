namespace AuthTask.Models;

public class Cart : BaseEntity
{
    public bool IsOrdered { get; set; } = false;
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
