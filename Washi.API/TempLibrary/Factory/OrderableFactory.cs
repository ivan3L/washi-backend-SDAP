//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Washi.API.Domain.Models;
//using Washi.API.Patterns.State;

//namespace Washi.API.TempLibrary.Factory
//{
//    public abstract class OrderableFactory
//    {
//        public abstract Orderable CreateOrderable();
//        public abstract void SetState(State.IState<Orderable> state);
//    }
//    public abstract class OrderableFactory<T>
//    {
//        protected OrderableFactory();
//        public override Orderable CreateOrderable(OrderStatus orderstatus)
//        {
//            if (orderstatus.StateName == "Past")
//            {
//                orderstatus.SetState(new PastOrderStatusState());
//                return orderstatus;
//            }
//            else if (orderstatus.StateName == "Future")
//            {
//                orderstatus.SetState(new FutureOrderStatusState());
//                return orderstatus;
//            }
//            else
//            {
//                orderstatus.SetState(new NeutralOrderStatusState());
//                return orderstatus;
//            }
//        }
//        public abstract Orderable CreateOrderableTable(T t);
//    }
//}
