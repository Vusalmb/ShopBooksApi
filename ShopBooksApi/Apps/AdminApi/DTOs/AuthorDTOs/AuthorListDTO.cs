using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.AuthorDTOs
{
    public class AuthorListDTO
    {
        public List<AuthorListItemDTO> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
