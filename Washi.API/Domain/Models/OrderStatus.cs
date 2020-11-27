using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Washi.API.TempLibrary.Factory;
//using Washi.API.TempLibrary.State;

//namespace Washi.API.Domain.Models
//{
//    public class OrderStatus
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public IList<Order> Orders { get; set; } = new List<Order>();
//        //
//        public string StateName { get; set; }
//        private IState<OrderStatus> CurrentState { get; set; }
//        private OrderableFactory<OrderStatus> Factory { get; set; }
//        public void SetState(IState<OrderStatus> state)
//        {
//            CurrentState = state;
//        }
//        public void Past()
//        {
//            Factory.CreateOrderable(this);
//            this.CurrentState.Past(this);
//        }
//        public void Future()
//        {
//            Factory.CreateOrderable(this);
//            this.CurrentState.Future(this);
//        }
//        public void Neutral()
//        {
//            Factory.CreateOrderable(this);
//            this.CurrentState.Neutral(this);
//        }
//        //
//    }
//}
