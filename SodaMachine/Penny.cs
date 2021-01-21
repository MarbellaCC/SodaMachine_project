using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Penny:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Penny(string Name)
        {
            this.Name = Name;
            value = .01;
        }
        //Member Methods (Can Do)
    }
}
