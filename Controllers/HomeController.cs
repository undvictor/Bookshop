using Bokbutiken.Models;
using Bokbutiken.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                BooksOfTheWeek = _bookRepository.BooksOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}
