using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == id));
        }
       
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, string extension)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var addedCarImage = CreatedFile(carImage, extension).Data;
            _carImageDal.Add(addedCarImage);
            return new SuccessResult();
        }
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var carImageUpdate = UpdatedFile(carImage).Data;
            _carImageDal.Update(carImageUpdate);
            return new SuccessResult();
        }
       
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }


        private IResult CheckImageLimit(int carId)
        {
            var imageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.ImageAddFailed);
            }

            return new SuccessResult();
        }


        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, ImageDate = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

        private IDataResult<CarImage> CreatedFile(CarImage carImage, string extension)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images");

            var uniqueFilename = Guid.NewGuid().ToString("I")
                                         + "_" + DateTime.Now.Month + "_"
                                         + DateTime.Now.Day + "_"
                                         + DateTime.Now.Year + extension;

            string source = Path.Combine(carImage.ImagePath);
            string result = $@"{path}\{uniqueFilename}";

            try
            {
                File.Move(source,path + @"\" + uniqueFilename);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CarImage>(e.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage()
                {Id = carImage.Id, CarId = carImage.CarId, ImageDate = DateTime.Now, ImagePath = result});
        }

        private IDataResult<CarImage> UpdatedFile(CarImage carImage)
        {
            var uniqueFileName = Guid.NewGuid().ToString("I") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";

            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{uniqueFileName}";

            File.Copy(carImage.ImagePath,path + "\\" + uniqueFileName);

            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<CarImage>(new CarImage()
                {Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, ImageDate = DateTime.Now});
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

    }
}
