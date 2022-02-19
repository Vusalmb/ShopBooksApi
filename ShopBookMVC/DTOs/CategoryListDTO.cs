using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBookMVC.DTOs
{
    public class CategoryListDTO
    {
        public List<CategoryListItemDTO> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
