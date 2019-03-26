using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _20032019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Customer> dictionaryId = new Dictionary<int, Customer>();
            Customer c1 = new Customer(3,"Moshe", 0523456789);
            Customer c2 = new Customer(5, "Yuda", 054354589);
            Customer c3 = new Customer(4, "Avraam", 050849419);

            dictionaryId.Add(3, new Customer(3, "Moshe", 0523456789));
            dictionaryId.Add(c2.CustomerID, c2);
            dictionaryId.Add(c3.CustomerID, c3);
            Console.WriteLine(c1);

            Bank bank = new Bank();
            bank.ChargeAnnualComission(35.0f);
            bank.GetAccountByNumber(3);
            bank.GetCustomerByID(3);
            bank.GetCustomerByNumber(10);
            Console.WriteLine(bank);

            Console.WriteLine("-----------------------------------");
            


            Account account = new Account(c1, 3000, 10000);
            Account account1 = new Account(c2, 5000, 20000);
            Account account2 = new Account(c3, 12000, -1000);
            account.Add(3000);
            account.Subtract(2500);

            Console.WriteLine(account);
            Console.WriteLine("---------------------------------------");

        }
    }
}
