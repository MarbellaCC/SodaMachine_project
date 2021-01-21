using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Nickel:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Nickel(string Name)
        {
            this.Name = Name;
            value = .10;
        }
        //Member Methods (Can Do)
    }
}
