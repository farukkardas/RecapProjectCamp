using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFColorDal:EfEntityRepositoryBase<Color,CarBrandContext>,IColorDal
    {
      
    }
}
