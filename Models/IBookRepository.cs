using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks { get;  }
        IEnumerable<Book> BooksOfTheWeek { get;}
        Book GetBookById(int bookId);
    }
}
