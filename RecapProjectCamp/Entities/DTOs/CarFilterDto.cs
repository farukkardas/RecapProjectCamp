using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarFilterDto : IDto
    {
        public string ColorName { get; set; }
        public string BrandName { get; set; }
    }
}
