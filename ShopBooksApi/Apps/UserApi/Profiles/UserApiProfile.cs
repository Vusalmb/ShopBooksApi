using AutoMapper;
using ShopBooksApi.Apps.UserApi.DTOs.AccountDTOs;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.UserApi.Profiles
{
    public class UserApiProfile:Profile
    {
        public UserApiProfile()
        {
            CreateMap<AppUser, AccountGetDTO>();
        }
    }
}
