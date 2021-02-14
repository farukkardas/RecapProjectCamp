using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Linq;
using DataAccess.Concrete.Entity_Framework;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());

            
            //BrandMethod(brandManager);
            //ColorMethod(colorManager);
            //CarMethod(carManager);
        }

        private static void BrandMethod(BrandManager brandManager)
        {
            //- add
            Brand brand1 = (new Brand()
            {
                Id = 7, BrandName = "Lexus"
            });
            brandManager.Add(brand1);


            //- delete
            brandManager.Delete(brand1);

            //- update
            brandManager.Update(new Brand()
            {
                Id = 7, BrandName = "Seat"
            });

            //- getall
            brandManager.GetAll();

            // getbyid
            brandManager.GetById(3);
        }

        private static void ColorMethod(ColorManager colorManager)
        {
            //-  add
            Color color1 = new Color() {Id = 6, ColorName = "Lilia"};
            colorManager.Add(color1);

            //-  delete
            colorManager.Delete(color1);

            //- update
            colorManager.Update(new Color()
            {
                ColorName = "Grey", Id = 6
            });

            //- GetAll

            colorManager.GetAll();

            //- GetById 

            colorManager.GetById(3);
        }

        private static void CarMethod(CarManager carManager)
        {
            //-add
            Car car1 = new Car()
            {
                CarId = 10,
                BrandId = 3,
                DailyPrice = 300,
                CarName = "Toyota Corolla",
                Description = "-",
                ModelYear = 2006,
                ColorId = 5
            };
            carManager.Add(car1);


            //-update
            carManager.Update(new Car()
            {
                CarId = 10,
                BrandId = 3,
                DailyPrice = 250,
                CarName = "Toyota Corolla",
                Description = "-",
                ModelYear = 2006,
                ColorId = 5
            });


            // -delete
            carManager.Delete(car1);

            // -Getall
            foreach (var xCar in carManager.GetAll())
            {
                System.Console.WriteLine(xCar.CarName);
            }

            //  -GetById
            foreach (var zCar in carManager.GetCarByBrandId(2))
            {
                System.Console.WriteLine(zCar.CarName);
            }
        }
    }
}
