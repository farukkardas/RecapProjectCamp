using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Results.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<IOrderedEnumerable<CarDetailDTO>> GetAllCarDetails();
        IDataResult<List<CarDetailDTO>> GetCarDetailById(int carId);
        IDataResult<List<CarDetailDTO>> GetCarDetailBrandId(string brandName);
        IDataResult<List<CarDetailDTO>> GetCarDetailByColor(string colorName);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);
        
    }
}
