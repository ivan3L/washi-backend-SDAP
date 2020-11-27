using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Persistence.Contexts;
using Washi.API.Domain.Repositories;
using Washi.API.Persistence.Repositories;
using Washi.API.TempLibrary;

namespace Washi.API.Patterns.ClientRepositoriesFacade
{
    public class ClientRepositoriesFacade
    {
        public Facade<IUserProfileRepository, IUserPaymentMethodRepository> ClientReposFacade { get; set; }
        public ClientRepositoriesFacade(IUserProfileRepository userProfileRepository, IUserPaymentMethodRepository userPaymentMethodRepository)
        {
            ClientReposFacade = new Facade<IUserProfileRepository, IUserPaymentMethodRepository>(userProfileRepository, userPaymentMethodRepository);
        }
    }
}
