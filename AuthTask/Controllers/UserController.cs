using AuthTask.Data;
using AuthTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthTask.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    public UserController(AppDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
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

    public async Task<IActionResult> CartAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user!.Id);

        if (!cart!.IsOrdered)
        {
            await _context.Entry(user!)
                .Reference(u => u.Cart)
                .Query()
                .Include(c => c.Products)
                .LoadAsync();

            var productsInCart = user.Cart?.Products.ToList();

            return View(productsInCart);
        }
        else return View(new List<Product>());

    }

    public async Task<IActionResult> AddCartAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null) return RedirectToAction("Index");

        var user = await _userManager.GetUserAsync(User);

        if (user!.Cart is null)
        {
            var existingCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (existingCart != null)
            {
                user.CartId = existingCart.Id;
                user.Cart = existingCart;
            }
            else
            {
                var newCart = new Cart { UserId = user.Id };
                user.Cart = newCart;
                user.CartId = newCart.Id;
            }
        }
        try
        {
            user.Cart.Products ??= new List<Product>();
            user.Cart.Products.Add(product);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }

    }

    public async Task<IActionResult> OrderAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user!.Id);

        cart!.IsOrdered = true;

        cart.Products.Clear();

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

}
