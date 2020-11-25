using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Persistence.Repositories;
using Washi.API.TempLibrary;

namespace Washi.API.Patterns.OrderValidationChain
{
    public class PhoneNumberValidator : IChain<Order>
    {
        private IChain<Order> _nextInChain;
        private UserProfile user;

        public void SetUserProfile (UserProfile userProfile)
        {
            user = userProfile;
        }
        public string process(Order order)
        {
            
            if (user.PhoneNumber >= 900000000 && user.PhoneNumber <= 999999999) return null;
            else return " ~PhoneNumber is invalid~";
        }

        public void SetNext(IChain<Order> nextInChain)
        {
            _nextInChain = nextInChain;
        }
    }
}