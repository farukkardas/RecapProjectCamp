using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Business.BusinessAspects;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using Core.Utilities.Results.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        //CarManager nesnesi oluşturulduğunda, ICarDal referansı versin diye
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect(10)]
        public IDataResult<List<CarDetailDTO>> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(p => p.Id == carId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailBrandId(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(p => p.BrandName == brandName));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailByColor(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(p => p.ColorName == colorName));
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }
        }
        
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            //ICarDal interfacesindeki GetAll metodunu kullanabilmek için 
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<IOrderedEnumerable<CarDetailDTO>> GetAllCarDetails()
        {
            return new SuccessDataResult<IOrderedEnumerable<CarDetailDTO>>(_carDal.GetCarDetails().OrderBy(c => c.Id));
        }

        [CacheAspect(10)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }
        [CacheAspect(10)]
        public IDataResult<List<CarDetailDTO>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        [CacheAspect(10)]
        public IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        

      

        public IResult AddTransactionalTest(Car car)
        {

            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

       
    }
}
