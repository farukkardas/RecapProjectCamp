using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IOperationClaimService operationClaimService,
            IUserOperationClaimDal userOperationClaimDal
        )
        {
            _operationClaimService = operationClaimService;
            _userOperationClaimDal = userOperationClaimDal;
        }

        [SecuredOperation("admin")]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        public IResult AddUserClaim(User user)
        {
            var operationClaim = _operationClaimService.GetByName("user").Data;
            var userOperationClaim = new UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = user.Id };
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        [SecuredOperation("admin")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }
    }
}
