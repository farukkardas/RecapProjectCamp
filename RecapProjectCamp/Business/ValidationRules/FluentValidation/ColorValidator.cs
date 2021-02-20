using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Business.ValidationRules.FluentValidation
{
    class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).NotEmpty();
            RuleFor(p => p.ColorName).MinimumLength(2);
            RuleFor(p => p.ColorName).Must(IsUnique).WithMessage("Bu renk mevcut!");
        }

        private bool IsUnique(string arg)
        {
            CarBrandContext context = new CarBrandContext();

            var result = context.Colors.Where(p => p.ColorName.ToLower() == arg.ToLower()).SingleOrDefault();

            if(result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
