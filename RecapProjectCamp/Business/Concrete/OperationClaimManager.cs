using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class OperationClaimManager:IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
        }

        public IDataResult<OperationClaim> GetByName(string name)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == name));
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        [SecuredOperation("admin")]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);

            return new SuccessResult(Messages.OperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);

            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        [SecuredOperation("admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);

            return new SuccessResult(Messages.OperationClaimDeleted);
        }
    }
}
