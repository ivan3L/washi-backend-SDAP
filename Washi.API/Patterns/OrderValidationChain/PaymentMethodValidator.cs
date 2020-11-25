using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.TempLibrary;

namespace Washi.API.Patterns.OrderValidationChain
{
    public class PaymentMethodValidator : IChain<Order>
    {
        private IChain<Order> _nextInChain;
        private List<UserPaymentMethod> _userPaymentMethods;

        public void SetUserPaymentMethods (List<UserPaymentMethod> userPaymentMethods)
        {
            _userPaymentMethods = userPaymentMethods;
        }

        public string process(Order order)
        {
            if (_userPaymentMethods.Count == 0) return " ~User does not have an associated payment method~";
            else return null;
        }

        public void SetNext(IChain<Order> nextInChain)
        {
            _nextInChain = nextInChain;
        }
    }
}
