using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalDtoValidator:AbstractValidator<RentalDto>
    {
        public RentalDtoValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.ModelName).NotEmpty();
            RuleFor(r => r.BrandName).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
        }
    }
}
