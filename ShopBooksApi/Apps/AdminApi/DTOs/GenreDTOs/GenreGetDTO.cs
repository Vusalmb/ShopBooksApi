using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.GenreDTOs
{
    public class GenreGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DisplayStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int BooksCount { get; set; }
    }
}
