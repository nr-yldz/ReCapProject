using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(Payment payment)
        {

            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentListed);
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {

            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(c => c.CardNumber == cardNumber), Messages.PaymentListed);
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(c => c.Id == id), Messages.PaymentListed);
        }

        public IResult IsCardExist(Payment payment)
        {
            var result = _paymentDal.Get(c => c.NameOnCard == payment.NameOnCard && c.CardNumber == payment.CardNumber && c.CardCvv == payment.CardCvv);
            if (result == null)
            {
                return new ErrorResult(Messages.CardCannotFound);
            }
            return new SuccessResult(Messages.CardExists);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }
    }
}
