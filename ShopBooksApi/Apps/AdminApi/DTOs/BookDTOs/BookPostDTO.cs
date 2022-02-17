using FluentValidation;
using Microsoft.AspNetCore.Http;
using ShopBooksApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs
{
    public class BookPostDTO
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Detail { get; set; }
        public string Language { get; set; }
        public string Publishing { get; set; }
        public string Cover { get; set; }
        public string Weight { get; set; }
        public bool DisplayStatus { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }

    public class BookPostDTOValidator: AbstractValidator<BookPostDTO>
    {
        public BookPostDTOValidator()
        {
            RuleFor(b => b.Name)
                .MaximumLength(150).WithMessage("Uzunluğu maksimum 150 ola bilər!")
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
            RuleFor(b => b.Detail)
                .MaximumLength(500).WithMessage("Uzunluğu maksimum 500 ola bilər!")
                .NotEmpty().WithMessage("Detail mütləqdir!");
            RuleFor(b => b.Language)
                .MaximumLength(50).WithMessage("Uzunluğu maksimum 50 ola bilər!")
                .NotEmpty().WithMessage("Language mütləqdir!");
            RuleFor(b => b.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Mənfi ola bilməz!")
                .NotEmpty().WithMessage("Price mütləqdir!");
            RuleFor(b => b.Publishing)
                .MaximumLength(50).WithMessage("Uzunluğu maksimum 50 ola bilər!")
                .NotEmpty().WithMessage("Publishing mütləqdir!");
            RuleFor(b => b.Cover)
                .MaximumLength(50).WithMessage("Uzunluğu maksimum 50 ola bilər!")
                .NotEmpty().WithMessage("Cover mütləqdir!");
            RuleFor(b => b.Weight)
                .MaximumLength(50).WithMessage("Uzunluğu maksimum 50 ola bilər!")
                .NotEmpty().WithMessage("Weight mütləqdir!");
            RuleFor(b => b.PageCount)
                .GreaterThanOrEqualTo(0).WithMessage("Mənfi ola bilməz!")
                .NotEmpty().WithMessage("PageCount mütləqdir!");
            RuleFor(b => b.DisplayStatus)
                .NotNull().WithMessage("DisplayStatus mütləqdir!");
            RuleFor(b => b.AuthorId)
                .GreaterThanOrEqualTo(1).NotNull();
            RuleFor(b => b.GenreId)
                .GreaterThanOrEqualTo(1).NotNull();
        }
    }
}
