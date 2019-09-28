using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardLibrary
{
    public class AccountTransaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public int CreditCardID { get; set; }

        public AccountTransaction()
        {

        }

        public AccountTransaction(int transactionID, DateTime timeStamp, decimal amount, int creditCardID)
        {
            this.TransactionID = transactionID;
            this.TransactionDate = timeStamp;
            this.Amount = amount;
            this.CreditCardID = creditCardID;
        }

        public AccountTransaction(decimal amount, int creditCardID)
        {
            this.Amount = amount;
            this.CreditCardID = creditCardID;
        }
    }
}
