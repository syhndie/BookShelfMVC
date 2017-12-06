using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShelfMVC.Models;

namespace BookShelfMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookShelfMVCContext _context;

        public BooksController(BookShelfMVCContext context)
        {
            _context = context;
        }

        // GET: Books
        public IActionResult Index(string titleFilter, string authorLastNameFilter, string sort)
        {
            var indexVM = new IndexViewModel
            {
                TitleFilter = titleFilter,
                AuthorLastNameFilter = authorLastNameFilter,
                Sort = sort,
                Books = Book.GetSortedBooks(_context, titleFilter, authorLastNameFilter, sort)
            };
            if (indexVM.TitleFilter == null)
            {
                indexVM.TitleFilter = "";
            }
            return View(indexVM);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return Content("The book ID is null.");
            }

            var book = await _context.Book
                .SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return Content("The book ID is null.");
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,AuthorLastName,AuthorFirstName,CallNumber")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Content("The book ID is null.");
            }

            var book = await _context.Book.SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return Content("The book ID is null.");
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,AuthorLastName,AuthorFirstName,CallNumber")] Book book)
        {
            if (id != book.ID)
            {
                return Content("The book ID does not match any in the database.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ID))
                    {
                        return Content("This book does not exist.");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Content("The book ID is null.");
            }

            var book = await _context.Book
                .SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return Content("The book ID is null.");
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.SingleOrDefaultAsync(m => m.ID == id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
