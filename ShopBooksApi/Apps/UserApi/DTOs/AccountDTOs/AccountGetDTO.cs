using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.UserApi.DTOs.AccountDTOs
{
    public class AccountGetDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
