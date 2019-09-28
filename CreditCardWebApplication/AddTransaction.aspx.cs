using CreditCardLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CreditCardWebApplication
{
    public partial class AddTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        public void btnAddTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTransaction.aspx");
        }
        public void btnModifyAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyAccount.aspx");
        }
        public void btnModifyCreditCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyCreditCard.aspx");
        }
        public void btnRetrieveAllTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("RetrieveTransactions.aspx");
        }
        public void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            int accountID = 0;
            if (!int.TryParse(txtAccountID.Text, out accountID))
            {
                lblTransactionMessage.Text = "Account ID is not valid input.";
                return;
            }
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/" + accountID + "?apikey=1");
            //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/" + accountID + "?apikey=1");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Account account = js.Deserialize<Account>(data);

            if (account.AccountID != accountID)
            {
                lblTransactionMessage.Text = "Account not found.";
                return;
            }
            else if (account.BillingAddress != txtBillingInformation.Text)
            {
                lblTransactionMessage.Text = "Billing address does not match.";
                return;
            }
            int creditCardID = 0;
            if (!int.TryParse(txtCreditCardNumber.Text, out creditCardID))
            {
                lblTransactionMessage.Text = "Credit Card ID is not valid input.";
                return;
            }
            int cvv = 0;
            if(!int.TryParse(txtCVV.Text, out cvv)){
                lblTransactionMessage.Text = "CVV is not a valid integer value.";
                return;
            }
            decimal amount = 0;
            if(!decimal.TryParse(txtAmount.Text, out amount))
            {
                lblTransactionMessage.Text = "Amount is not a valid decimal value.";
                return;
            }
            request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetCreditCard/" + accountID + "?apikey=1");
            //request = WebRequest.Create("http://localhost:23637/api/Accounts/GetCreditCard/" + accountID + "?apikey=1");
            response = request.GetResponse();

            theDataStream = response.GetResponseStream();
            reader = new StreamReader(theDataStream);
            data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            js = new JavaScriptSerializer();
            CreditCard creditCard = js.Deserialize<CreditCard>(data);
            string creditCardExpirationDate = ddlTransactionExpirationMonth.SelectedValue + "/" + ddlTransactionExpirationYear.SelectedValue;
            if (creditCard.CreditCardID != creditCardID)
            {
                lblTransactionMessage.Text = "Credit card number not found.";
                return;
            }
            else if (!creditCard.CVV.Equals(Convert.ToString(cvv)))
            {
                lblTransactionMessage.Text = "CVV does not match.";
                return;
            }
            else if (!creditCard.ExpirationDate.Equals(creditCardExpirationDate))
            {
                lblTransactionMessage.Text = "Expiration date does not match.";
                return;
            }
            else if(creditCard.Balance < amount)
            {
                lblTransactionMessage.Text = "Amount exceeds balance.";
                return;
            }
            else if(creditCard.CreditCardStatus != 1)
            {
                lblTransactionMessage.Text = "Cannot add transaction for a deactivated credit card.";
                return;
            }
            AccountTransaction newTransaction = new AccountTransaction();
            newTransaction.CreditCardID = creditCardID;
            newTransaction.Amount = amount;
            js = new JavaScriptSerializer();
            String jsonTransaction = js.Serialize(newTransaction);
            try
            {
                request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/AddTransaction?apikey=1");
                //request = WebRequest.Create("http://localhost:23637/api/Accounts/AddTransaction?apikey=1");
                request.Method = "POST";
                request.ContentLength = jsonTransaction.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonTransaction);
                writer.Flush();
                writer.Close();

                response = request.GetResponse();
                theDataStream = response.GetResponseStream();
                reader = new StreamReader(theDataStream);
                data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                if (data == "true")
                {
                    lblTransactionMessage.Text = "The transaction was successfully added to the database.";
                }
                else
                {
                    lblTransactionMessage.Text = "The transaction wasn't updated to the database.";
                }
            }
            catch (Exception ex)
            {
                lblTransactionMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}