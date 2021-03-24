using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
    public class Car : IEntity

    {
        public int CarId { get; set; }
      
        public int ModelYear { get; set; }
      
        public int BrandId { get; set; }
     
        public int ColorId { get; set; }
      
        public string CarName { get; set; }
      
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string FuelEffiency { get; set; }
        public string Engine { get; set; }
        public int HorsePower { get; set; }
    }
}
