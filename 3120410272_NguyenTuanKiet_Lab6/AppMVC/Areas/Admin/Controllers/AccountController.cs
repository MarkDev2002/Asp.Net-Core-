using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;
// Other using statements
[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class AccountController : Controller
{
    private readonly BookStoreDbContext _context;
    public AccountController(BookStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null && user.IsActive)
            {
                HttpContext.Session.SetInt32("UserID", user.Id);
                HttpContext.Session.SetString("Username", user.Username);

                return RedirectToAction("Index", "Books");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
