using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardLibrary
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public decimal Balance { get; set; }
        public int AccountID { get; set; }

        public int CreditCardStatus { get; set; }

        public decimal CreditLimit { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(int creditCardID, string cvv, string expirationDate, decimal balance, int accountID, int status, decimal creditLimit)
        {
            this.CreditCardID = creditCardID;
            this.CVV = cvv;
            this.ExpirationDate = expirationDate;
            this.Balance = balance;
            this.AccountID = accountID;
            this.CreditCardStatus = status;
        }

        public CreditCard(string cvv, string expirationDate, decimal balance, int accountID, decimal creditLimit)
        {
            this.CVV = cvv;
            this.ExpirationDate = expirationDate;
            this.Balance = balance;
            this.AccountID = accountID;
            this.CreditLimit = creditLimit;
        }
    }
}
