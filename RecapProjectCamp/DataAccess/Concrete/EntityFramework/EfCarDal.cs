using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarBrandContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails(Expression<Func<CarDetailDTO, bool>> filter = null)
        {
            using (CarBrandContext context = new CarBrandContext())
            {
                var result = from c in context.Cars
                    join z in context.Brands on c.BrandId equals z.Id
                    join g in context.Colors on c.ColorId equals g.Id
                    select new CarDetailDTO()
                    {
                        Id = c.CarId,
                        CarName = c.CarName,
                        DailyPrice = c.DailyPrice,
                        BrandName = z.BrandName,
                        ColorName = g.ColorName,
                        ModelYear = c.ModelYear


                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
