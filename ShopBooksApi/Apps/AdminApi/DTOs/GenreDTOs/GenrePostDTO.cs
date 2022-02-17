using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.AdminApi.DTOs.GenreDTOs
{
    public class GenrePostDTO
    {
        public string Name { get; set; }
        public bool DisplayStatus { get; set; }
    }

    public class GenrePostDTOValidator : AbstractValidator<GenrePostDTO>
    {
        public GenrePostDTOValidator()
        {
            RuleFor(b => b.Name)
                .MaximumLength(50).WithMessage("Uzunluğu maksimum 50 ola bilər!")
                .NotEmpty().WithMessage("Name mütləqdir!");
            RuleFor(b => b.DisplayStatus)
                .NotNull().WithMessage("DisplayStatus mütləqdir!");
        }
    }
}
