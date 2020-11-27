using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.TempLibrary.State
{
    public interface IState<T>
    {
        void Past(T orderstatus);
        void Future(T orderstatus);
        void Neutral(T orderstatus);
    }
}