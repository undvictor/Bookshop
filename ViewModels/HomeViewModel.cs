using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bokbutiken.Models;

namespace Bokbutiken.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BooksOfTheWeek { get; set; }
    }
}
