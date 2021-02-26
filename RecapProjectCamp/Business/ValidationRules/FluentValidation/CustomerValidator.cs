using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MinimumLength(2);
            RuleFor(p => p.CompanyName).MaximumLength(50);
            RuleFor(p => p.CompanyName).Must(IsCompanyUnique);
            RuleFor(p => p.UserId).NotEmpty();
        }

        private bool IsCompanyUnique(string arg)
        {
            CarBrandContext context = new CarBrandContext();

            var result = context.Customers
                .Where(p => p.CompanyName.ToLower() == arg.ToLower())
                .SingleOrDefault();

            if (result == null)
                return true;    
            return false;
        }
    }
}
