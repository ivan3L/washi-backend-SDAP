using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.TempLibrary
{
    public interface IChain<T>
    {
        void SetNext(IChain<T> nextInChain);
        string process(T request);
    }
}
