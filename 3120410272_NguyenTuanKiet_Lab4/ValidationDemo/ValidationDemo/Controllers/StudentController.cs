using Microsoft.AspNetCore.Mvc;
using ValidationDemo.Models;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            
            return RedirectToAction("Index", "Home");
        }

        return View(student);
    }
}
