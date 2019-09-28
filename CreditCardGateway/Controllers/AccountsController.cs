using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;              // import needed for DataSet and other data classes
using System.Data.SqlClient;    // import needed for ADO.NET classes
using Utilities;                // import needed for DBConnect class
using CreditCardLibrary;
namespace CreditCardGateway.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private string ApiKey = "1";

        private Boolean Verification(string apiKey)
        {
            if (ApiKey == apiKey)
            {
                return true;
            }
            else return false;
        }

        //GET api/Accounts
        [HttpGet]
        public List<Account> GetAllAccounts(string apiKey)
        {
            if (!Verification(apiKey))
            {
                return null;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                DataSet ds = sp.StoredProcedureGetAllAccounts();
                List<Account> accounts = new List<Account>();
                Account account;
                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    account = new Account();
                    account.AccountID = int.Parse(record["AccountID"].ToString());
                    account.AccountName = record["AccountName"].ToString();
                    account.BillingAddress = record["BillingAddress"].ToString();
                    accounts.Add(account);
                }
                return accounts;
            }
        }

        //GET api/Accounts/id
        [HttpGet("{accountID}")]
        public Account GetAccount(int accountID, string apiKey)

        {
            if (!Verification(apiKey))
            {
                return null;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                DataSet ds = sp.StoredProcedureGetAccount(accountID);
                DataRow record;
                Account account = new Account();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    record = ds.Tables[0].Rows[0];
                    account.AccountID = int.Parse(record["AccountID"].ToString());
                    account.AccountName = record["AccountName"].ToString();
                    account.BillingAddress = record["BillingAddress"].ToString();
                }
                return account;
            }
        }

        //GET api/Accounts/GetAccountsWithoutCreditCards
        [HttpGet("GetAccountsWithoutCreditCards")]
        public List<Account> GetAccountsWithoutCreditCards(string apiKey)

        {
            if (!Verification(apiKey))
            {
                return null;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                DataSet ds = sp.StoredProcedureGetAccountsWithoutCreditCards();
                List<Account> accounts = new List<Account>();
                Account account;
                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    account = new Account();
                    account.AccountID = int.Parse(record["AccountID"].ToString());
                    account.AccountName = record["AccountName"].ToString();
                    accounts.Add(account);
                }
                return accounts;
            }
        }

        //GET api/Accounts/GetCreditCard/accountID
        [HttpGet("GetCreditCard/{accountID}")]
        public CreditCard GetCreditCard(int accountID, string apiKey)

        {
            if (!Verification(apiKey))
            {
                return null;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                DataSet ds = sp.StoredProcedureGetCreditCard(accountID);
                DataRow record;
                CreditCard creditCard = new CreditCard();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    record = ds.Tables[0].Rows[0];
                    creditCard.CreditCardID = int.Parse(record["CreditCardID"].ToString());
                    creditCard.CVV = record["CVV"].ToString();
                    creditCard.ExpirationDate = record["ExpirationDate"].ToString();
                    creditCard.Balance = Convert.ToDecimal(record["Balance"].ToString());
                    creditCard.AccountID = Convert.ToInt32(record["AccountID"].ToString());
                    creditCard.CreditCardStatus = Convert.ToInt32(record["CreditCardStatus"].ToString());
                    creditCard.CreditLimit = Convert.ToDecimal(record["CreditLimit"].ToString());
                }
                return creditCard;
            }
        }
        // POST api/Accounts
        // The [FromBody] attribute is needed in order to pass a JSON object
        // and allow the model-binding to occur properly. This tells the .NET framework
        // to use the 'content-type' header information from the HTTP Request to
        // determine which of the configured IInputFormatters to use in the model-binding.
        [HttpPost("AddAccount")]
        public Boolean AddAccount([FromBody]Account theAccount, string apiKey)
        {
            if (!Verification(apiKey))
            {
                return false;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                if (!sp.StoredProcedureAddAccount(theAccount)){
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        [HttpPost("AddCreditCard")]
        public Boolean AddCreditCard([FromBody]CreditCard theCreditCard, string apiKey)
        {
            if (!Verification(apiKey))
            {
                return false;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                if (!sp.StoredProcedureAddCreditCard(theCreditCard))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        [HttpPost("AddTransaction")]
        public Boolean AddTransaction([FromBody]AccountTransaction theTransaction, string apiKey)
        {
            if (!Verification(apiKey))
            {
                return false;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                if (!sp.StoredProcedureAddTransaction(theTransaction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        [HttpPut("UpdateAccount")]
        public Boolean UpdateAccount([FromBody]Account theAccount, string apiKey)
        {
            if (!Verification(apiKey))
            {
                return false;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                if (!sp.StoredProcedureUpdateAccount(theAccount))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        [HttpPut("UpdateCreditCard")]
        public Boolean UpdateCreditCard([FromBody]CreditCard theCreditCard, string apiKey)
        {
            if (!Verification(apiKey))
            {
                return false;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                if (!sp.StoredProcedureUpdateCreditCard(theCreditCard))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } 
        }

        [HttpGet("GetAllTransactions/{creditCardID}")]
        public List<AccountTransaction> GetAllTransactions(int creditCardID, string apiKey)
        {
            if (!Verification(apiKey))
            {
                return null;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                DataSet ds = sp.StoredProcedureGetAllTransactions(creditCardID);
                List<AccountTransaction> accountTransactions = new List<AccountTransaction>();
                AccountTransaction accountTransaction;
                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    accountTransaction = new AccountTransaction();
                    accountTransaction.TransactionID = int.Parse(record["TransactionID"].ToString());
                    accountTransaction.TransactionDate = Convert.ToDateTime(record["TransactionDate"].ToString());
                    accountTransaction.Amount = Convert.ToDecimal(record["Amount"].ToString());
                    accountTransaction.CreditCardID = Convert.ToInt32(record["CreditCardID"].ToString());
                    accountTransactions.Add(accountTransaction);
                }
                return accountTransactions;
            }
        }
        [HttpGet("GetAllCreditCards")]
        public List<CreditCard> GetAllCreditCards(string apiKey)
        {
            if (!Verification(apiKey))
            {
                return null;
            }
            else
            {
                StoredProcedure sp = new StoredProcedure();
                DataSet ds = sp.StoredProcedureGetAllCreditCards();
                List<CreditCard> creditCards = new List<CreditCard>();
                CreditCard creditCard;
                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    creditCard = new CreditCard();
                    creditCard.CreditCardID = int.Parse(record["CreditCardID"].ToString());
                    creditCards.Add(creditCard);
                }
                return creditCards;
            }
        }
    }
}