using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarBrandFilterDto:IDto
    {
        public string BrandName { get; set; }
    }
}
