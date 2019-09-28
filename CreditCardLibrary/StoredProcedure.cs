using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utilities;        // import needed for DBConnect class

namespace CreditCardLibrary
{
    public class StoredProcedure
    {
        public DataSet StoredProcedureGetAllAccounts()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiGetAccounts";
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet StoredProcedureGetAccount(int AccountID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiGetAccountByID";
            objCommand.Parameters.AddWithValue("@accountID", AccountID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet StoredProcedureGetAccountsWithoutCreditCards()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiSelectAccountsWithoutCreditCards";
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }
        public DataSet StoredProcedureGetCreditCard(int AccountID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiGetCreditCardByAccountID";
            objCommand.Parameters.AddWithValue("@accountID", AccountID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public Boolean StoredProcedureAddAccount(Account theAccount)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiInsertAccount";
            objCommand.Parameters.AddWithValue("@accountName", theAccount.AccountName);
            objCommand.Parameters.AddWithValue("@billingAddress", theAccount.BillingAddress);
            // Execute the INSERT statement in the database
            // The DoUpdateUsingCmdObj() method returns the number of records effected by the INSERT statement.
            // Otherwise, it returns -1 when there was an error exception.
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean StoredProcedureAddCreditCard(CreditCard theCreditCard)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiInsertCreditCardForAccount";
            objCommand.Parameters.AddWithValue("@accountID", theCreditCard.AccountID);
            objCommand.Parameters.AddWithValue("@cvv", theCreditCard.CVV);
            objCommand.Parameters.AddWithValue("@expirationDate", theCreditCard.ExpirationDate);
            objCommand.Parameters.AddWithValue("@balance", theCreditCard.Balance);
            objCommand.Parameters.AddWithValue("@creditLimit", theCreditCard.CreditLimit);
            // Execute the INSERT statement in the database
            // The DoUpdateUsingCmdObj() method returns the number of records effected by the INSERT statement.
            // Otherwise, it returns -1 when there was an error exception.
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean StoredProcedureAddTransaction(AccountTransaction theTransaction)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiInsertTransaction";
            objCommand.Parameters.AddWithValue("@creditCardID", theTransaction.CreditCardID);
            objCommand.Parameters.AddWithValue("@amount", theTransaction.Amount);
            // Execute the INSERT statement in the database
            // The DoUpdateUsingCmdObj() method returns the number of records effected by the INSERT statement.
            // Otherwise, it returns -1 when there was an error exception.
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean StoredProcedureUpdateAccount(Account theAccount)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiUpdateAccount";
            objCommand.Parameters.AddWithValue("@accountID", theAccount.AccountID);
            objCommand.Parameters.AddWithValue("@accountName", theAccount.AccountName);
            objCommand.Parameters.AddWithValue("@billingAddress", theAccount.BillingAddress);
            // Execute the INSERT statement in the database
            // The DoUpdateUsingCmdObj() method returns the number of records effected by the INSERT statement.
            // Otherwise, it returns -1 when there was an error exception.
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean StoredProcedureUpdateCreditCard(CreditCard theCreditCard)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiUpdateCreditCard";
            objCommand.Parameters.AddWithValue("@creditCardID", theCreditCard.CreditCardID);
            objCommand.Parameters.AddWithValue("@cvv", theCreditCard.CVV);
            objCommand.Parameters.AddWithValue("@expirationDate", theCreditCard.ExpirationDate);
            objCommand.Parameters.AddWithValue("@balance", theCreditCard.Balance);
            objCommand.Parameters.AddWithValue("@status", theCreditCard.CreditCardStatus);
            objCommand.Parameters.AddWithValue("@creditLimit", theCreditCard.CreditLimit);
            // Execute the INSERT statement in the database
            // The DoUpdateUsingCmdObj() method returns the number of records effected by the INSERT statement.
            // Otherwise, it returns -1 when there was an error exception.
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public DataSet StoredProcedureGetAllTransactions(int creditCardID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiGetTransactionsForCreditCard";
            objCommand.Parameters.AddWithValue("@creditCardID", creditCardID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet StoredProcedureGetAllCreditCards()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ApiGetAllCreditCards";
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }
    }
}
