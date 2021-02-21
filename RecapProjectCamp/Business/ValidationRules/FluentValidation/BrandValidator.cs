using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.BrandName).NotEmpty();
            RuleFor(p => p.BrandName).MinimumLength(2);
            RuleFor(p => p.BrandName).Must(IsBrandUnique);
        }

        private bool IsBrandUnique(string arg)
        {
            CarBrandContext context = new CarBrandContext();
            var result = context.Brands.Where(p => p.BrandName.ToLower() == arg.ToLower()).SingleOrDefault();
            if (result == null)
                return true;
            return false;
        }
    }
}
