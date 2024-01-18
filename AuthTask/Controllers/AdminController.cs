using AuthTask.Data;
using AuthTask.Models;
using AuthTask.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTask.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        var categories = _context.Categories.ToList();
        ViewData["Categories"] = categories;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Price = model.Price,
                Description = model.Description

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        var categories = _context.Categories.ToList();
        ViewData["Categories"] = categories;
        return View(model);
    }
}
