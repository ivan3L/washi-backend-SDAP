using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;

namespace Washi.API.Patterns.OrderValidationChain
{
    public class OrderValidation
    {
        public string ValidateOrder(Order order, UserProfile userProfile, List<UserPaymentMethod> userPaymentMethods)
        {
            var paymentMethodValidator = new PaymentMethodValidator();
            var addressValidator = new AddressValidator();
            var phoneNumberValidator = new PhoneNumberValidator();

            paymentMethodValidator.SetNext(addressValidator);
            addressValidator.SetNext(phoneNumberValidator);

            phoneNumberValidator.SetUserProfile(userProfile);
            paymentMethodValidator.SetUserPaymentMethods(userPaymentMethods);

            return paymentMethodValidator.process(order) + addressValidator.process(order) + phoneNumberValidator.process(order);
        }
    }
}
