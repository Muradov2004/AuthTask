using Microsoft.AspNetCore.Identity;

namespace AuthTask.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = null!;
    public int Year { get; set; }
    public Cart Cart { get; set; } = null!;
}
