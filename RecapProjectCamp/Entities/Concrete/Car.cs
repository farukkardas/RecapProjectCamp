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
        [Required(ErrorMessage = "Aracın yılı boş bırakılamaz!")]
        public int ModelYear { get; set; }
        [Required(ErrorMessage = "Marka Boş bırakılamaz!")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Renk boş bırakılamaz!")]
        public int ColorId { get; set; }
        [Required(ErrorMessage = "Model boş bırakılamaz!")]
        public string CarName { get; set; }
        [Required(ErrorMessage = "Günlük fiyat boş bırakılamaz!")]
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
