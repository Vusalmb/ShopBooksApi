using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.UserApi.DTOs.AccountDTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(r => r.UserName).MinimumLength(5).MaximumLength(20).NotEmpty();
            RuleFor(r => r.Password).MinimumLength(8).MaximumLength(20).NotEmpty();
        }
    }
}
