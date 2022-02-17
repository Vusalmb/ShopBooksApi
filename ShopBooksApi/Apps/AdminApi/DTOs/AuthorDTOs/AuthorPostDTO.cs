using FluentValidation;
using Microsoft.AspNetCore.Http;
using ShopBooksApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.AuthorDTOs
{
    public class AuthorPostDTO
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public bool DisplayStatus { get; set; }
    }

    public class AuthorPostDTOValidator : AbstractValidator<AuthorPostDTO>
    {
        public AuthorPostDTOValidator()
        {
            RuleFor(b => b.Name)
                .MaximumLength(50).WithMessage("Uzunluğu maksimum 50 ola bilər!")
                .NotEmpty().WithMessage("Name mütləqdir!");
            RuleFor(b => b.Image).Custom((b, content) =>
            {
                if (b == null)
                {
                    content.AddFailure("Image", "Image mütləqdir!");
                }
                else if (!b.IsImage())
                {
                    content.AddFailure("Image", "Düzgün İmage file daxil edin!");
                }
                else if (!b.IsSizeOkay(2))
                {
                    content.AddFailure("Image", "Image ölçüsü 2MB-dan artıq ola bilməz!");
                }
            });
            RuleFor(b => b.DisplayStatus)
                .NotNull().WithMessage("DisplayStatus mütləqdir!");
        }
    }
}
