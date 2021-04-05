using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator: AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.CardCvv).NotEmpty().MinimumLength(3);
            RuleFor(c => c.CardNumber).NotEmpty().MinimumLength(12);
            RuleFor(c => c.NameOnCard).NotEmpty();
            RuleFor(c => c.MoneyInCard).GreaterThanOrEqualTo(0);
        }
    }
}
