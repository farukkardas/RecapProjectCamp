using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Concrete.Entity_Framework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarBrandContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (CarBrandContext context = new CarBrandContext())
            {
                var result = from c in context.Customers
                    join user in context.Users on c.UserId equals user.Id
                    select new CustomerDetailDto()
                    {
                        UserId = c.UserId,
                        CompanyName = c.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    };
                return result.ToList();
            }
        }
    }
}
