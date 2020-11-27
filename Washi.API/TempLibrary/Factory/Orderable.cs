using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.TempLibrary.Factory
{
    public abstract class Orderable
    {
        public abstract string StateName { get; set; }
        public abstract State.IState<Orderable> CurrentState { get; set; }
    }
}

