using AuthTask.Data;
using AuthTask.Models;
using AuthTask.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTask.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public AdminController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
            var product = _mapper.Map<Product>(model);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        var categories = _context.Categories.ToList();
        ViewData["Categories"] = categories;
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);
        if (product != null)
            _context.Products.Remove(product);

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);
        var updateProduct = _mapper.Map<UpdateProductViewModel>(product);
        var categories = _context.Categories.ToList();
        ViewData["Categories"] = categories;
        return View(updateProduct);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == model.Id);
            if (product != null)
            {
                product.Title = model.Title;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
                product.Price = model.Price;
                product.ModifiedTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        return View(model);
    }
}
