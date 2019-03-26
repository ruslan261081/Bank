using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20032019
{
   public  class Account
   {
        private static int numberOfAcc;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber { get; }
        public int Balance { get; private set; }
        public Customer AccountOwner { get; }
        public int MaxMinusAllowed { get; }

        public Account(Customer customer, int monthlyIncome, int balance)
        {
            this.accountNumber = numberOfAcc++;
            maxMinusAllowed = monthlyIncome * 3;
            this.accountOwner = customer;
            Balance = Balance;
        }
        public void Add(int amount)
        {
            Balance = Balance + amount;
        }
        public void Subtract( int amount)
        {
            if(this.Balance < this.MaxMinusAllowed)
            {
                throw new BalanceExption();
            }
        }

        public static bool operator == (Account account1, Account account2)
        {
            if (ReferenceEquals(account1,  null) && ReferenceEquals(account2, null))
                return true;
            if (ReferenceEquals(account1, null) || ReferenceEquals(account2, null))
                return false;

            return account1.Balance == account2.Balance;
        }
        public static bool operator !=(Account account1, Account account2)
        {
            return !(account1 == account2);
        }

        public override bool Equals(object obj)
        {
            Account other = obj as Account;
            return this == other;
        }

        public override int GetHashCode()
        {
            return this.accountNumber;
        }
        public static Account operator + (Account account1, Account account2)
        {
            Customer customer = new Customer(account1.accountOwner.CustomerID, account1.accountOwner.Name, account1.accountOwner.PnNumber);
            return new Account(customer, (account1.maxMinusAllowed / 3) + (account2.maxMinusAllowed / 3), account1.Balance + account2.Balance);
        }
    }
}
