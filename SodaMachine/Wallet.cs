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
        //Fills wallet with starting money
        private void FillRegister()
        {
            for (int i = 0; i < 10; i++)
            {
                Coin quarter = new Coin();
                Coins.Add(quarter);
            }
            for (int i = 0; i < 14; i++)
            {
                Coin dime = new Coin();
                Coins.Add(dime);
            }
            for (int i = 0; i < 18; i++)
            {
                Coin nickel = new Coin();
                Coins.Add(nickel);
            }
            for (int i = 0; i < 20; i++)
            {
                Coin penny = new Coin();
                Coins.Add(penny);
            }
        }
    }
}
