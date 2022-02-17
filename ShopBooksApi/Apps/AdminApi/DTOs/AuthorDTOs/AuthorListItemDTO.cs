using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.AuthorDTOs
{
    public class AuthorListItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool DisplayStatus { get; set; }
    }
}
