using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.TempLibrary
{
    public class Facade<Subsystem1, Subsystem2>
    {
        public Subsystem1 _subsystem1;

        public Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

    }

}
