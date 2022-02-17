using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs
{
    public class BookListDTO
    {
        public List<BookListItemDTO> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
