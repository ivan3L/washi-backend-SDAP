using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.TempLibrary;

namespace Washi.API.Patterns.OrderValidationChain
{
    public class OrderValidation
    {
        public string ValidateOrder(Order order, Facade<IUserProfileRepository, IUserPaymentMethodRepository> clientReposFacade)
        {
            var paymentMethodValidator = new PaymentMethodValidator();
            var addressValidator = new AddressValidator();
            var phoneNumberValidator = new PhoneNumberValidator();

            paymentMethodValidator.SetNext(addressValidator);
            addressValidator.SetNext(phoneNumberValidator);
            
            //Using Client Repositories Facade
            phoneNumberValidator.SetUserProfile(clientReposFacade._subsystem1.FindByIdNotAsync(order.UserId));
            paymentMethodValidator.SetUserPaymentMethods(clientReposFacade._subsystem2.ListByUserId(order.UserId));

            return paymentMethodValidator.process(order) + addressValidator.process(order) + phoneNumberValidator.process(order);
        }
    }
}
