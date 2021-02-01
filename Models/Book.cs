using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public bool IsBookOfTheWeek { get; set; }
        public bool Instock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
