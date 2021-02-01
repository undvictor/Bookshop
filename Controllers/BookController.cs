using Bokbutiken.Models;
using Bokbutiken.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.AllBooks.OrderBy(b => b.BookId);
                currentCategory = "All books";
            }
            else
            {
                books = _bookRepository.AllBooks.Where(b => b.Category.CategoryName == category)
                    .OrderBy(b => b.BookId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new BooksListViewModel
            {
                Books = books,
                CurrentCategory = currentCategory
            });
        }
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }
    }
}
