using AutoMapper;
using ShopBooksApi.Apps.AdminApi.DTOs.AuthorDTOs;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.Profiles
{
    public class AuthorMapProfile: Profile
    {
        public AuthorMapProfile()
        {
            CreateMap<Author, AuthorGetDTO>();
        }
    }
}
