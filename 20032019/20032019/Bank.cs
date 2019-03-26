using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _20032019
{
    public class Bank : IBank 
    {
        

        private List<Account> accounts = new List<Account>();
        private List<Customer> customers = new List<Customer>();
        private Dictionary<int, Customer> dictionaryID = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> dictionaryCustNumber = new Dictionary<int, Customer>();
        private Dictionary<int, Account> dictionaryAccNumber = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> dictionaryCustomers = new Dictionary<Customer, List<Account>>();
       
        private int totalMoneyInBank;
        private int profits;

       public string Name
       {
            get
            {
                return Name;
            }
       }
        public string Address
        {
            get
            {
                return Address;
            }
        }

        

        public int CustomerCount
        {
            get
            {
                return CustomerCount;
            }
        }
        internal Customer GetCustomerByID(int   customerId)
        {
            if (dictionaryID.TryGetValue(customerId, out Customer customer))
                return customer;
            throw new CustomerNotFountException();
        }
        internal  Customer GetCustomerByNumber( int customerNumber)
        {
            if (dictionaryCustNumber.TryGetValue(customerNumber, out Customer customer))
                return customer;
            throw new CustomerNotFountException();
        }
        internal Account GetAccountByNumber( int accountNumber)
        {
            if(dictionaryAccNumber.TryGetValue(accountNumber, out Account account))
            {
                return account;
            }
            else
            {
                throw new AccountNotFoundException($"Account Number {accountNumber} Sorry Not found account number in  our bank");
            }

        }
        internal List<Account> GetAccountsByCustomer(Customer customer)
        {
            if (dictionaryCustomers.TryGetValue(customer,out List<Account> accounts))
            {
                return accounts;
            }
            else
            {
                throw new AccountNotFoundException($"Customer {customers} Dont Have account in our bank");
            }
        }
        internal Customer AddNewCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new CustomerNullException();
            }
           
            if(customers.Contains(customer))
            {
                throw new CustomerAlreadyExistException($"Customer {customer.Name} Already exist in our bank");
            }
            customers.Add(customer);
            dictionaryID.Add(customer.CustomerID, customer);
            dictionaryCustNumber.Add(customer.CustomerNumber, customer);
            return customer;
        }
        internal void OpenNewAccount(Account account, Customer customer)
        {
            if(accounts.Contains(account))
            {
                throw new AccountNotFoundException();
            }
            accounts.Add(account);
            dictionaryAccNumber.Add(account.AccountNumber, account);
            dictionaryCustomers.Add(customer,accounts);

        }
        internal int Deposit(Account account, int amount)
        {
            totalMoneyInBank = totalMoneyInBank + amount;
            return account.Balance;
        }
        internal int Withdraw(Account account, int amount)
        {
            totalMoneyInBank = totalMoneyInBank - amount;
            if(account.Balance < account.MaxMinusAllowed)
            {
                throw new BalanceExption($"You out from balance");
            }
            return account.Balance;
        }
        internal int GetCostumerTotalBalance(Customer customer)
        {
            int sum = 0;
            foreach(Account item in GetAccountsByCustomer(customer))
            {
                sum = sum + item.Balance;
            }
            return sum;
        }
        internal void CloseAccount(Account account, Customer customer)
        {
            accounts.Remove(account);
            customers.Remove(customer);
            dictionaryAccNumber.Remove(account.AccountNumber);
            dictionaryCustNumber.Remove(customer.CustomerNumber);
            dictionaryID.Remove(customer.CustomerID);
            dictionaryCustomers.Remove(customer);

        }
        internal void ChargeAnnualComission(float percentage)
        {
            float comission = 0;

            foreach(Account account in accounts)
            {
                
                if(account.Balance < account.MaxMinusAllowed)
                {

                    percentage = percentage * 2.0f;
                }

                comission = percentage * account.Balance / 100.0f;
                
               
            }

           

        }
        internal void JoinAccounts(Account account1, Account account2)
        {
            if(account1.AccountOwner.CustomerID != account2.AccountOwner.CustomerID)
            {
                throw new NotSameCustomerException($"Accounts {account1.AccountNumber} + {account2.AccountNumber} Wrong same customer");
            }
            Account account3 = account1 + account2;
            accounts.Remove(account1);
            accounts.Remove(account2);
            dictionaryAccNumber.Remove(account1.AccountNumber);
            dictionaryAccNumber.Remove(account2.AccountNumber);
            dictionaryAccNumber.Add(account3.AccountNumber, account3);
            accounts.Add(account3);


        }
        public Bank()
        {

        }
        
      
    }
}
