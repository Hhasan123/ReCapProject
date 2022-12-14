using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator:AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m => m.ModelName).NotEmpty();
            RuleFor(m => m.ModelName).MinimumLength(2);
        }
    }
}
