
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityDemo.Models;

namespace EntityDemo.Controllers
{
    public class BookImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookImages.Include(b => b.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookImages = await _context.BookImages
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookImages == null)
            {
                return NotFound();
            }

            return View(bookImages);
        }

        // GET: BookImages/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            return View();
        }

        // POST: BookImages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BookId")] BookImages bookImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookImages.BookId);
            return View(bookImages);
        }
        // GET: BookImages/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookImages = await _context.BookImages.FindAsync(id);
            if (bookImages == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookImages.BookId);
            return View(bookImages);
        }

        // POST: BookImages/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BookId")] BookImages bookImages)
        {
            if (id != bookImages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookImagesExists(bookImages.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookImages.BookId);
            return View(bookImages);
        }

        // GET: BookImages/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookImages = await _context.BookImages
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookImages == null)
            {
                return NotFound();
            }

            return View(bookImages);
        }

        // POST: BookImages/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookImages = await _context.BookImages.FindAsync(id);
            if (bookImages != null)
            {
                _context.BookImages.Remove(bookImages);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookImagesExists(int id)
        {
            return _context.BookImages.Any(e => e.Id == id);
        }
    }
}
