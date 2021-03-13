    using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Concrete.Entity_Framework;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarBrandContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (CarBrandContext context = new CarBrandContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars
                        on r.CarId equals c.CarId
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join cus in context.Customers
                        on r.CustomerId equals cus.Id
                    join u in context.Users
                        on cus.UserId equals u.Id
                    select new RentalDetailDto
                    {
                        RentalId = r.Id,
                        BrandName = b.BrandName,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        RentDate = r.RentDate,
                        DailyPrice = c.DailyPrice,
                        ReturnDate = (DateTime) r.ReturnDate
                    };
                return result.ToList();
            }
        }

       
    }
}
