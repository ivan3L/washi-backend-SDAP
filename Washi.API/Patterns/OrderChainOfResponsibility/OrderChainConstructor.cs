using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Patterns.OrderChainOfResponsibility
{
    public class OrderChainConstructor
    {
        CheckPaymentMethodHandler checkPaymentMethodHandler = new CheckPaymentMethodHandler();
        CheckUserInformationHandler checkUserInformationHandler = new CheckUserInformationHandler();
        CheckSubscriptionHandler checkSubscriptionHandler = new CheckSubscriptionHandler();
        CheckPromotionHandler checkPromotionHandler = new CheckPromotionHandler();

        public OrderChainConstructor()
        {
            checkPaymentMethodHandler.SetNext(checkUserInformationHandler)
                                     .SetNext(checkSubscriptionHandler)
                                     .SetNext(checkPromotionHandler);
        }
    }
}
