using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs
{
    public class BookListItemDTO
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
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public AuthorInBookListItemDTO Author { get; set; }
        public GenreInBookListItemDTO Genre { get; set; }
    }

    public class AuthorInBookListItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreInBookListItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
