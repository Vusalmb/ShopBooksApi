using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
