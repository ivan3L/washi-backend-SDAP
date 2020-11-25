using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.TempLibrary;

namespace Washi.API.Patterns.OrderValidationChain
{
    public class AddressValidator : IChain<Order>
    {
        private IChain<Order> _nextInChain;

        public string process(Order order)
        {
            if ((int)(order.DeliveryAddress[order.DeliveryAddress.Length - 1]) >= 48
                && (int)(order.DeliveryAddress[order.DeliveryAddress.Length - 1]) <= 57) return null;
            else return " ~Address is invalid~";
        }

        public void SetNext(IChain<Order> nextInChain)
        {
            _nextInChain = nextInChain;
        }
    }
}