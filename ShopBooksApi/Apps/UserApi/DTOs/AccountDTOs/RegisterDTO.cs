using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.UserApi.DTOs.AccountDTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterDTOValidator: AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(r => r.UserName).MinimumLength(5).MaximumLength(20).NotEmpty();
            RuleFor(r => r.FullName).MinimumLength(5).MaximumLength(25).NotEmpty();
            RuleFor(r => r.Password).MinimumLength(8).MaximumLength(20).NotEmpty();
            RuleFor(r => r.ConfirmPassword).MinimumLength(8).MaximumLength(20).NotEmpty();
            RuleFor(r => r).Custom((r, context) =>
              {
                  if(r.Password != r.ConfirmPassword)
                  {
                      context.AddFailure("ConfirmPassword", "Password və ConfirmPassword eyni olmalıdır!");
                  }
              });
        }
    }
}
