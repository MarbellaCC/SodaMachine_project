using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables (Has A)
        private List<Coin> _register;
        private List<Can> _inventory;

        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();
            
            FillInventory();
            FillRegister();
        }

        //Member Methods (Can Do)
        public void FillRegister()
        {
            for (int i = 0; i < 20; i++)
            {
                Coin quarter = new Quarter();
                _register.Add(quarter);
            }
            for (int i = 0; i < 10; i++)
            {
                Coin dime = new Dime();
                _register.Add(dime);
            }
            for (int i = 0; i < 20; i++)
            {
                Coin nickel = new Nickel();
                _register.Add(nickel);
            }
            for (int i = 0; i < 50; i++)
            {
                Coin penny = new Penny();
                _register.Add(penny);
            }
        }
        
        public void FillInventory()
        {
            for (int i = 0; i < 20; i++)
            {
                RootBeer rootBeer = new RootBeer();
                _inventory.Add(rootBeer);
            }
            for (int i = 0; i < 20; i++)
            {
                Cola cola = new Cola();
                _inventory.Add(cola);
            }
            for (int i = 0; i < 20; i++)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
                _inventory.Add(orangeSoda);
            }
        }

        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }

        private void Transaction(Customer customer)
        {
            string sodaChosen = UserInterface.SodaSelection(_inventory);
            Can customerSelectedCan = GetSodaFromInventory(sodaChosen);
            List<Coin> payment = customer.GatherCoinsFromWallet(customerSelectedCan);
            CalculateTransaction(payment, customerSelectedCan, customer);
        }

        private Can GetSodaFromInventory(string nameOfSoda)
        {
            foreach (Can can in _inventory)
            {
                if (can.Name.Equals(nameOfSoda))
                {
                    return can;
                }
            }
            return null;
        }
        
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {
            double sum = TotalCoinValue(payment);
            double registerTotalValue = TotalCoinValue(_register);
            double changeValue = DetermineChange(sum, chosenSoda.Price);

            if (sum >= chosenSoda.Price && _inventory.Contains(chosenSoda) == false)
            {
                UserInterface.DisplayError("Sorry we dont have that soda anymore");
                customer.AddCoinsIntoWallet(payment);
            }
            else if (sum < chosenSoda.Price)
            {
                UserInterface.DisplayError("You didnt enter enough money to buy that soda");
                customer.AddCoinsIntoWallet(payment);
            }
            else if(sum == chosenSoda.Price)
            {
                DepositCoinsIntoRegister(payment);
                _inventory.Remove(chosenSoda);
                customer.AddCanToBackpack(chosenSoda);
                UserInterface.EndMessage(chosenSoda.Name, 0);
            }
            else if (sum > chosenSoda.Price && changeValue > registerTotalValue)
            {
                UserInterface.DisplayError("Sorry theres not enough change");
                customer.AddCoinsIntoWallet(payment);
            }
            else if(sum > chosenSoda.Price)
            {
                DepositCoinsIntoRegister(payment);
                List<Coin> change = GatherChange(changeValue);
                customer.AddCoinsIntoWallet(change);
                _inventory.Remove(chosenSoda);
                customer.AddCanToBackpack(chosenSoda);
                UserInterface.EndMessage(chosenSoda.Name, changeValue);
            }
        }

        private List<Coin> GatherChange(double changeValue)
        {
            List<Coin> changeGathered = new List<Coin>();
            while(changeValue > 0)
            {
                while (changeValue >= .25)
                {
                    foreach(Coin coin in _register)
                    {
                        changeGathered.Add(GetCoinFromRegister("Quarter"));
                        changeValue -= .25;
                        break;
                    }
                }
                while (changeValue >= .10)
                {
                    foreach (Coin coin in _register)
                    {
                        changeGathered.Add(GetCoinFromRegister("Dime"));
                        changeValue -= .10;
                        break;
                    }
                }
                while (changeValue >= .05)
                {
                    foreach (Coin coin in _register)
                    { 
                        changeGathered.Add(GetCoinFromRegister("Nickel"));
                        changeValue -= .05;
                        break;
                    }
                }
                while (changeValue >= .01)
                {
                    foreach (Coin coin in _register)
                    {
                        changeGathered.Add(GetCoinFromRegister("Penny"));
                        changeValue -= .01;
                        break;
                    }
                }
            }
            return changeGathered;
        }

        private bool RegisterHasCoin(string name)
        {
            foreach(Coin coin in _register)
            {
                if (coin.Name.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }

        private Coin GetCoinFromRegister(string name)
        {
            foreach (Coin coin in _register)
            {
                if (coin.Name == name)
                {
                    return coin;
                }
            }
            return null;
        }

        private double DetermineChange(double totalPayment, double canPrice)
        {
            double changeAmount;
            changeAmount = totalPayment - canPrice;
            return changeAmount;
        }

        private double TotalCoinValue(List<Coin> payment)
        {
            double totalValue = 0;
            foreach (Coin coin in payment)
            {
                totalValue += coin.Value;
            }
            return totalValue;
        }

        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            _register.AddRange(coins);
        }
    }
}
