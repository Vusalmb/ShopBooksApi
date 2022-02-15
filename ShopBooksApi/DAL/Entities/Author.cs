using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int BookCount { get; set; }
        public List<Book> Books { get; set; }
    }
}
