using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Dime:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Dime(string Name)
        {
            this.Name = Name;
            value = .10;
        }

        //Member Methods (Can Do)
    }
}
