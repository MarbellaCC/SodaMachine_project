﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Quarter:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Quarter(string Name)
        {
            this.Name = Name;
            value = .25;
        }

        //Member Methods (Can Do)
    }
}
