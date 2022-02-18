using AutoMapper;
using ShopBooksApi.Apps.AdminApi.DTOs.GenreDTOs;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.Profiles
{
    public class GenreMapProfile:Profile
    {
        public GenreMapProfile()
        {
            CreateMap<Genre, GenreGetDTO>();
        }
    }
}
