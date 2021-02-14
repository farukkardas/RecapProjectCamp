using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDTO:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
