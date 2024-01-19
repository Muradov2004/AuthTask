using AuthTask.Data;
using AuthTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AuthTask.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? category)
    {
        var categories = _context.Categories.ToList();
        ViewData["Categories"] = categories;

        IQueryable<Product> products = _context.Products;

        if (category.HasValue && category > 0)
        {
            products = products.Where(p => p.CategoryId == category);
        }

        var productList = products.ToList();
        return View(productList);
    }

    public IActionResult AddOrder(int id)
    {
        var products = _context.Products.Where(p => p.Id == id);
        var cart = _context.Carts.Where(p => p.Id == id);

        return RedirectToAction("Index");
    }

}
