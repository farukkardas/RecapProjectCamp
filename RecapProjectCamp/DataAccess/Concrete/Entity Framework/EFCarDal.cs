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
    public class EFCarDal : EfEntityRepositoryBase<Car, CarBrandContext>, ICarDal
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (CarBrandContext context = new CarBrandContext())
            {
                var result = from c in context.Car
                             join z in context.Brand on c.BrandId equals z.Id
                             join g in context.Color on c.ColorId equals g.Id
                             select new ProductDetailDTO
                             {
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = z.BrandName,
                                 ColorName = g.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
