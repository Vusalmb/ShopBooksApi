using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.DAL.Entities
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }
        public bool DisplayStatus { get; set; }
        public List<Book> Books { get; set; }
    }
}
