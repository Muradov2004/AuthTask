namespace AuthTask.Models;

public class Product : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
    public ICollection<Cart>? Cart { get; set; }
}
