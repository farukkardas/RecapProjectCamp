using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Concrete.Entity_Framework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarBrandContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetAllRentalDetails()
        {
            using (CarBrandContext context = new CarBrandContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                                 on r.CarId equals c.CarId
                             join cu in context.Customers
                                 on r.CustomerId equals cu.Id
                             select new RentalDetailDTO
                             {
                                 Id = r.Id,
                                 CarId = c.CarId,
                                 CarName = c.Description,
                                 CustomerName = cu.CompanyName,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
