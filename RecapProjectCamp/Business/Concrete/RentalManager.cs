using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Results.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;
        private IFindeksService _findeksService;

        public RentalManager(IRentalDal rentalDal,  IFindeksService findeksService, ICarService carService)
        {
            _rentalDal = rentalDal;
           
            _findeksService = findeksService;
            _carService = carService;
        }
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsRentable(rental), CheckFindeksScoreSufficiency(rental));
            if (result != null) return result;

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }


        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0) return new ErrorResult(Messages.RentalUndeliveredCar);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);


            if (result.Any(r =>
                r.ReturnDate >= rental.RentDate &&
                r.RentDate <= rental.ReturnDate
            )) return new ErrorResult(Messages.RentalNotAvailable);

            return new SuccessResult();
        }

        public IResult CheckFindeksScoreSufficiency(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var findeks = _findeksService.GetByCustomerId(rental.CustomerId).Data;

            if (findeks == null) return new ErrorResult(Messages.FindeksNotFound);
            if (findeks.Score < car.MinFindeksScore) return new ErrorResult(Messages.FindeksNotEnoughForCar);

            return new SuccessResult();
        }


        [CacheAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }
        [CacheAspect(10)]
        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(result);
        }


    }
}
