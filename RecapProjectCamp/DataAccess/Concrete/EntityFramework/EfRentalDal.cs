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
        public List<RentalDetailDTO> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarBrandContext context = new CarBrandContext())
            {
                var result = from rental in context.Rentals
                    join car in context.Cars on rental.CarId equals car.CarId
                    join customer in context.Customers on rental.CustomerId equals customer.UserId
                    join user in context.Users on customer.UserId equals user.Id
                    join brand in context.Brands on car.BrandId equals brand.Id
                    select new RentalDetailDTO()
                    {
                        Id = rental.Id,
                        CarDescription = car.Description,
                        CarBrand = brand.BrandName,
                        CarModel = car.ModelYear,
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = rental.RentDate,
                        ReturnDate = (DateTime)rental.ReturnDate
                    };
                return result.ToList();

            }
        }

       
    }
}
