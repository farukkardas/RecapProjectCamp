using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class PaymentManager:IPaymentService
    {
        private IPaymentService _paymentService;

        public PaymentManager(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IResult Payment()
        {
            var random = new Random().Next(2);
            if (random == 0) return new ErrorResult(Messages.PaymentFailed);

            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
