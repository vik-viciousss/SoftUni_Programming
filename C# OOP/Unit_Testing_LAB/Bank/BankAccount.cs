using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount 
    {
        private decimal amount = 0;

        public BankAccount(decimal amount, string name)
        {
            this.Amount = amount;
            this.Name = name;
        }

        public decimal Amount
        {
            get => this.amount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("No negatives");
                }

                this.amount = value;
            }
        }

        public string Name { get; set; }

        public void Deposit(decimal amount)
        {
            Amount += amount;
        }
    }
}
