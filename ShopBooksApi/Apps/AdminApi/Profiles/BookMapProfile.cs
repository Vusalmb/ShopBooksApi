using AutoMapper;
using ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.Profiles
{
    public class BookMapProfile:Profile
    {
        public BookMapProfile()
        {
            CreateMap<Book, BookGetDTO>();
            CreateMap<Author, AuthorInBookGetDTO>();  // nested map
            CreateMap<Genre, GenreInBookGetDTO>();
        }
    }
}
