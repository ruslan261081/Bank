using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20032019
{
   public  class Customer
   {
        private static int numberOfCust;
        private readonly int customerId;
        private readonly int customerNumber;
        public string Name { get; private set; }
        private readonly int customerID;
        public int PnNumber { get; private set; }
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
        }
        public int CustomerNumber
        {
            get
            {
                return this.customerNumber;
            }
        }

        public Customer(int customerID, string name, int pnNumber)
        {
            this.customerID = customerID;
            Name = name;
            PnNumber = pnNumber;
            this.customerNumber = numberOfCust++;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (ReferenceEquals(customer1, null) && ReferenceEquals(customer2, null))
                return true;
            if (ReferenceEquals(customer1, null) || ReferenceEquals(customer2, null))
                return false;

            return customer1.customerID == customer2.customerId;

        }
        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }

        public override bool Equals(object obj)
        {
            Customer other = obj as Customer;
            return this == other;
        }

        public override int GetHashCode()
        {
            return this.customerNumber;
        }
    }
}
