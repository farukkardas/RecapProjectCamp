using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
  public class EfUserOperationClaimDal:EfEntityRepositoryBase<UserOperationClaim,CarBrandContext> , IUserOperationClaimDal
    {
    }
}
