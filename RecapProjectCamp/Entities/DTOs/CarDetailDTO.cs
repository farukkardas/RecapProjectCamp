﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDTO : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime CarImageDate { get; set; }
        public string ImagePath { get; set; }

    }
}
