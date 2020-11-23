using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services.Communications.PatternsCommunications;
using Washi.API.TempLibrary.ChainOfResponsibility;

namespace Washi.API.Patterns.OrderChainOfResponsibility
{
    public class CheckPaymentMethodHandler: BaseHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;

        public CheckPaymentMethodHandler(IUserRepository userRepository, IUserPaymentMethodRepository userPaymentMethodRepository)
        {
            _userRepository = userRepository;
            _userPaymentMethodRepository = userPaymentMethodRepository;
        }
        public object Handle(Order order)
        {
            var user = _userRepository.FindById(order.UserId);
            var userPaymentMethods = _userPaymentMethodRepository.ListByUserIdAsync(user.Id);
            //int cont = 0;
            //foreach (UserPaymentMethod userPaymentMethod in userPaymentMethods) cont++;
            //if (cont >= 1) return base.Handle(order);
            if (userPaymentMethods != null) return base.Handle(order);
            else return new CheckPaymentMethodResponse("User does not have an associated payment method");
        }
    }
}