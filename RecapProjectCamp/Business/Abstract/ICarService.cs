using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarByBrandId(int BrandId);
        List<Car> GetCarsByColorId(int ColorId);
        List<ProductDetailDTO> GetProductDetails();

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);


    }
}
