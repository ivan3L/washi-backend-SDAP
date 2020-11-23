using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications.PatternsCommunications
{
    public class CheckPaymentMethodResponse: BaseResponse<Order>
    {
        public CheckPaymentMethodResponse(string message) : base(message) { }
        public CheckPaymentMethodResponse(Order order) : base(order) { }
    }
}
