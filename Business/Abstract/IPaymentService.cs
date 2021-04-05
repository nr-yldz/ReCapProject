using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IDataResult<Payment> GetById(int id);
        IResult IsCardExist(Payment payment);
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
    }
}
