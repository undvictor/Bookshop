using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public class BookRepository : IBookRepository
    {
        //bring in dbcontext and inject locally 
        private readonly BokDbContext _bokDbContext;
        public BookRepository(BokDbContext bokDbContext)
        {
            _bokDbContext = bokDbContext;
        }
        public IEnumerable<Book> AllBooks
        {//all books returned
            get
            {
                return _bokDbContext.Books.Include(c => c.Category);
            }
        }

        public IEnumerable<Book> BooksOfTheWeek
        {//book of the week returned
            get
            {
                return _bokDbContext.Books.Include(c => c.Category).Where(b => b.IsBookOfTheWeek);
                //return _bokDbContext.Books.Include(c => c.Category).Where(b => b.IsBookOfTheWeek);
            }
        }

        public Book GetBookById(int bookId)
        {//specific book
            return _bokDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
