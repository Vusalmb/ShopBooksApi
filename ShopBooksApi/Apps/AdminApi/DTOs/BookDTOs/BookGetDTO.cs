using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs
{
    public class BookGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Language { get; set; }
        public string Publishing { get; set; }
        public string Cover { get; set; }
        public string Weight { get; set; }
        public bool DisplayStatus { get; set; }
        public int PageCount { get; set; }
        public AuthorInBookGetDTO Author { get; set; }
        public GenreInBookGetDTO Genre { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class AuthorInBookGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCounts { get; set; }
    }

    public class GenreInBookGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCounts { get; set; }
    }
}
