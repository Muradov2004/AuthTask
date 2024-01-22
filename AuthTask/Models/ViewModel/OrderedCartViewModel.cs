namespace AuthTask.Models.ViewModel;

public class OrderedCartViewModel
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public List<OrderedProductViewModel> Products { get; set; }
}
