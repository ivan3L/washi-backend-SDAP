//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Washi.API.Domain.Models;
//using Washi.API.Domain.Repositories;
//using Washi.API.Domain.Services.Communications.PatternsCommunications;
//using Washi.API.TempLibrary.Factory;
//using Washi.API.TempLibrary.State;

//namespace Washi.API.Patterns.State
//{
//    public class FutureOrderStatusState : IState<OrderStatus>
//    {
//        public void Future(OrderStatus orderstatus)
//        {
//            throw new Exception("The order status is already in the future");
//        }

//        public void Neutral(OrderStatus orderstatus)
//        {
//            orderstatus.StateName = "Neutral";
//            orderstatus.SetState(new NeutralOrderStatusState());
//        }

//        public void Past(OrderStatus orderstatus)
//        {
//            orderstatus.StateName = "Past";
//            orderstatus.SetState(new PastOrderStatusState());
//        }
//    }
//}