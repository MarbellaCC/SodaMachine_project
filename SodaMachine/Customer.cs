using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //Member Variables (Has A)
        public Wallet Wallet;
        public Backpack Backpack;

        //Constructor (Spawner)
        public Customer()
        {
            Wallet = new Wallet();
            Backpack = new Backpack();
        }
        //Member Methods (Can Do)

        public List<Coin> GatherCoinsFromWallet(Can selectedCan)
        {
            List<Coin> gatheredCoins = new List<Coin>();
            double gatheredCoinsValue = 0;
            
            while (gatheredCoinsValue < selectedCan.Price)
            {
                string coinSelected = UserInterface.CoinSelection(selectedCan, Wallet.Coins);
                Coin gatheredCoin = GetCoinFromWallet(coinSelected);
                if (gatheredCoin == null)
                {
                    break;
                }
                gatheredCoins.Add(gatheredCoin);
                gatheredCoinsValue += gatheredCoin.Value;
            }
            return gatheredCoins;

        }

        public Coin GetCoinFromWallet(string coinName)
        {
            foreach(Coin coin in Wallet.Coins) 
            {
                if (coin.Name.Equals(coinName)) 
                {
                    Wallet.Coins.Remove(coin);
                    return coin;
                }
            }
            return null;
        }
 
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {
            Wallet.Coins.AddRange(coinsToAdd);
        }

        public void AddCanToBackpack(Can purchasedCan)
        {
            Backpack.cans.Add(purchasedCan);
        }
    }
}
