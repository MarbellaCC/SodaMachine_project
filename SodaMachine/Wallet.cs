using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //Member Variables (Has A)
        public List<Coin> Coins;

        //Constructor (Spawner)
        public Wallet()
        {
            Coins = new List<Coin>();
          
            FillRegister();
        }

        //Member Methods (Can Do)
        private void FillRegister()
        {
            for (int i = 0; i < 10; i++)
            {
                Coin quarter = new Quarter();
                Coins.Add(quarter);
            }
            for (int i = 0; i < 14; i++)
            {
                Coin dime = new Dime();
                Coins.Add(dime);
            }
            for (int i = 0; i < 18; i++)
            {
                Coin nickel = new Nickel();
                Coins.Add(nickel);
            }
            for (int i = 0; i < 20; i++)
            {
                Coin penny = new Penny();
                Coins.Add(penny);
            }
        }
    }
}
