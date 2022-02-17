using FluentValidation;
using Microsoft.AspNetCore.Http;
using ShopBooksApi.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs
{
    public class BookPutDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Language { get; set; }
        public string Publishing { get; set; }
        public string Cover { get; set; }
        public string Weight { get; set; }
        public bool DisplayStatus { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public double Price { get; set; }
    }
}
