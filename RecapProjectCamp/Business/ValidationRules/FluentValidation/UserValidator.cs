using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("İsim en az 2 harfli olmalıdır!"); ;
            RuleFor(p => p.FirstName).MaximumLength(39).WithMessage("İsim maksimum 40 karakter olabilir!"); ;
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz!"); ;
            RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyisim en az 2 harfli olmalıdır!");
            RuleFor(p => p.LastName).MaximumLength(39).WithMessage("İsim maksimum 40 karakter olabilir!");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email boş bırakılamaz!"); ;
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçersiz mail formatı!");
            RuleFor(p => p.Email).MaximumLength(299).WithMessage("Email en fazla 300 karakter olabilir!");
            RuleFor(p => p.Email).MinimumLength(10).WithMessage("Email minimum 10 karakter olabilir!");
            RuleFor(p => p.Email).Must(IsEmailUnique).WithMessage("Bu emaile kayıtlı kullanıcı bulunuyor!");


        }

        private bool IsEmailUnique(string arg)
        {
            CarBrandContext context = new CarBrandContext();

            var result = context.Users
                .Where(p => p.Email.ToLower() == arg.ToLower())
                .SingleOrDefault();

            if (result == null)
                return true;
            return false;
        }
    }
}
