using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.TempLibrary.ChainOfResponsibility
{
    public class BaseHandler: IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }

        public object Handle(object request)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(request);
            else return null;
        }
    }

}
