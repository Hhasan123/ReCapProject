using Core.Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();

            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u=>u.Email).Must(EndsWith);

        }

        private bool EndsWith(string arg)
        {
            if (arg.EndsWith("@gmail.com"))
            {
                return true;
            }
            throw new ValidationException("Mail adress have to end with '@gmail.com'");
        }
    }
}
