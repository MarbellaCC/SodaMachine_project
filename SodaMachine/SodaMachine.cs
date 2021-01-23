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

        //A method to fill the sodamachines register with coin objects.
        public void FillRegister()
        {
            for (int i = 0; i < 20; i++)
            {
                Coin quarter = new Coin();
            }
            for (int i = 0; i < 10; i++)
            {
                Coin dime = new Coin();
            }
            for (int i = 0; i < 20; i++)
            {
                Coin nickel = new Coin();
            }
            for (int i = 0; i < 50; i++)
            {
                Coin penny = new Coin();
            }
        }
        //A method to fill the sodamachines inventory with soda can objects.
        public void FillInventory()
        {
            for (int i = 0; i < 20; i++)
            {
                RootBeer rootBeer = new RootBeer();
            }
            for (int i = 0; i < 20; i++)
            {
                Cola cola = new Cola();
            }
            for (int i = 0; i < 20; i++)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
            }
        }
        //Method to be called to start a transaction.
        //Takes in a customer which can be passed freely to which ever method needs it.
        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }
        
        //This is the main transaction logic think of it like "runGame".  This is where the user will be prompted for the desired soda.
        //grab the desired soda from the inventory.
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer)
        {
            GetSodaFromInventory();

        }
        //Gets a soda from the inventory based on the name of the soda.
        private Can GetSodaFromInventory(string nameOfSoda)
        {
            Console.WriteLine("What soda would you like? Your options are cola, orange soda and rootbeer ");
            string chosenSoda = Console.ReadLine();
            return chosenSoda;
        }

        //This is the main method for calculating the result of the transaction.
        //It takes in the payment from the customer, the soda object they selected, and the customer who is purchasing the soda.
        //This is the method that will determine the following:
        //If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Dispense soda, and change to the customer.
        //If the payment is greater than the cost of the soda, but the machine does not have ample change: Dispense payment back to the customer.
        //If the payment is exact to the cost of the soda:  Dispense soda.
        //If the payment does not meet the cost of the soda: dispense payment back to the customer.
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {
            //need to figure out sum of payment
            //ccompare sum to cost of soda
            //if sum < cost of soda give money back to customer
            double sum = 0;
            for(int i = 0; i < payment.Count; i++)
            {
                sum += payment[i].Value;
            }
            
            double registerTotalValue = 0;
            for(int i = 0; i < _register.Count; i++)
            {
                registerTotalValue += _register[i].Value;
            }
            
            double changeValue = DetermineChange(sum, chosenSoda.Price);

            if (sum >= chosenSoda.Price && _inventory.Contains(chosenSoda) == false)
            {
                customer.AddCoinsIntoWallet(payment);
            }
            else if (sum < chosenSoda.Price)
            {
                customer.AddCoinsIntoWallet(payment);
            }
            else if(sum == chosenSoda.Price)
            {
                DepositCoinsIntoRegister(payment);
                customer.AddCanToBackpack(chosenSoda);
            }
            else if (sum > chosenSoda.Price && changeValue > registerTotalValue)
            {
                customer.AddCoinsIntoWallet(payment);
            }
            else if(sum > chosenSoda.Price)
            {
                DepositCoinsIntoRegister(payment);
                List<Coin> change = GatherChange(changeValue);
                customer.AddCoinsIntoWallet(change);
                customer.AddCanToBackpack(chosenSoda);
            }
            
        }
        //Takes in the value of the amount of change needed.
        //Attempts to gather all the required coins from the sodamachine's register to make change.
        //Returns the list of coins as change to despense.
        //If the change cannot be made, return null.
        private List<Coin> GatherChange(double changeValue)
        {
            
            if ()
            {
                
                
            }
            else
            {
                return null;
            }    
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            if (_register.Contains(.Name) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            
        }
        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)
        {
            double changeAmount;
            changeAmount = totalPayment - canPrice;
            return changeAmount;
        }
        //Takes in a list of coins to return the total value of the coins as a double.
        private double TotalCoinValue(List<Coin> payment)
        {
            double sum = 0;
            for (int i = 0; i < payment.Count; i++)
            {
                sum += payment[i].Value;
            }
            return sum;
        }
        //Puts a list of coins into the soda machines register.
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            
        }
    }
}
