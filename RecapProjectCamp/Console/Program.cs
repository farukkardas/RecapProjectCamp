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

            
        }


        
    }
}
