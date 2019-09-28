using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardLibrary
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string BillingAddress { get; set; }

        public Account()
        {

        }

        public Account(int accID, string name, string billAddress)
        {
            this.AccountID = accID;
            this.AccountName = name;
            this.BillingAddress = billAddress;
        }

        public Account(string name, string billAddress)
        {
            this.AccountName = name;
            this.BillingAddress = billAddress;
        }
    }
}
