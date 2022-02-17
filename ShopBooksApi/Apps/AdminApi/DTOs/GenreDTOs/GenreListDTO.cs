using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.GenreDTOs
{
    public class GenreListDTO
    {
        public List<GenreListItemDTO> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
