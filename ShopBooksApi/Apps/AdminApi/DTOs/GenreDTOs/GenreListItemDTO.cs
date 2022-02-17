using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.GenreDTOs
{
    public class GenreListItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DisplayStatus { get; set; }
    }
}
