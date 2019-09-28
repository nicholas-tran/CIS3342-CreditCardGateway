using CreditCardLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreditCardWebApplication
{
    public partial class ModifyCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts?apikey=1");
                //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts?apikey=1");
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Account[] accounts = js.Deserialize<Account[]>(data);

                ddlSelectAccountForCreditCard.DataSource = accounts;
                ddlSelectAccountForCreditCard.DataTextField = "AccountName";
                ddlSelectAccountForCreditCard.DataValueField = "AccountID";
                ddlSelectAccountForCreditCard.DataBind();

                request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetAccountsWithoutCreditCards?apikey=1");
                //request = WebRequest.Create("http://localhost:23637/api/Accounts/GetAccountsWithoutCreditCards?apikey=1");
                response = request.GetResponse();

                theDataStream = response.GetResponseStream();
                reader = new StreamReader(theDataStream);
                data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                js = new JavaScriptSerializer();
                accounts = js.Deserialize<Account[]>(data);

                ddlSelectAccountToAddCreditCard.DataSource = accounts;
                ddlSelectAccountToAddCreditCard.DataTextField = "AccountName";
                ddlSelectAccountToAddCreditCard.DataValueField = "AccountID";
                ddlSelectAccountToAddCreditCard.DataBind();
            }
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

        protected void btnSelectAccountForCreditCard_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            CreditCard creditCard = js.Deserialize<CreditCard>(data);
            if (creditCard.CreditCardID == 0)
            {
                lblModifyCreditCardMessage.Text = "No credit card exists for this account.";
                return;
            }
            List<CreditCard> creditCards = new List<CreditCard>(0);
            creditCards.Add(creditCard);

            gvModifyCreditCard.DataSource = creditCards;
            gvModifyCreditCard.DataBind();
        }

        protected void gvModifyCreditCard_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModifyCreditCard.EditIndex = e.NewEditIndex;
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            CreditCard creditCard = js.Deserialize<CreditCard>(data);
            List<CreditCard> creditCards = new List<CreditCard>(0);
            creditCards.Add(creditCard);

            gvModifyCreditCard.DataSource = creditCards;
            gvModifyCreditCard.DataBind();
        }

        protected void gvModifyCreditCard_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            GridViewRow row = (GridViewRow)gvModifyCreditCard.Rows[e.RowIndex];
            CreditCard editCreditCard = new CreditCard();
            int creditCardID = Convert.ToInt32(row.Cells[0].Text);
            editCreditCard.CreditCardID = creditCardID;
            int cvv = Convert.ToInt32(row.Cells[1].Text);
            editCreditCard.CVV = Convert.ToString(cvv);
            DropDownList ddlExpirationMonth = (DropDownList)row.Cells[2].Controls[1];
            DropDownList ddlExpirationYear = (DropDownList)row.Cells[2].Controls[5];
            string expirationDate = ddlExpirationMonth.SelectedValue + "/" + ddlExpirationYear.SelectedValue;
            editCreditCard.ExpirationDate = expirationDate;
            decimal balance = 0;
            TextBox textBoxBalance = (TextBox)row.Cells[3].Controls[0];
            if (!decimal.TryParse(textBoxBalance.Text, out balance))
            {
                lblModifyCreditCardMessage.Text = "Balance is not a valid decimal value.";
                return;
            }
            editCreditCard.Balance = balance;
            int accountID = Convert.ToInt32(row.Cells[4].Text);
            editCreditCard.AccountID = accountID;
            DropDownList ddlStatus = (DropDownList)row.Cells[5].Controls[1];
            int status = Convert.ToInt32(ddlStatus.SelectedValue);
            editCreditCard.CreditCardStatus = status;
            decimal creditLimit = 0;
            TextBox textBoxCreditLimit = (TextBox)row.Cells[6].Controls[0];
            if (!decimal.TryParse(textBoxCreditLimit.Text, out creditLimit)) {
                lblModifyCreditCardMessage.Text = "Credit limit is not a valid decimal value.";
                return;
            }
            editCreditCard.CreditLimit = creditLimit;
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonCreditCard = js.Serialize(editCreditCard);
            try
            {
                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/UpdateCreditCard?apikey=1");
                //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/UpdateCreditCard?apikey=1");
                request.Method = "PUT";
                request.ContentLength = jsonCreditCard.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonCreditCard);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                if (data == "true")
                {
                    lblModifyCreditCardMessage.Text = "The credit card was successfully updated.";
                }
                else
                {
                    lblModifyCreditCardMessage.Text = "The credit card wasn't updated.";
                }
            }
            catch (Exception ex)
            {
                lblModifyCreditCardMessage.Text = "Error: " + ex.Message;
            }
            WebRequest request2 = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            //WebRequest request2 = WebRequest.Create("http://localhost:23637/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            WebResponse response2 = request2.GetResponse();

            Stream theDataStream2 = response2.GetResponseStream();
            StreamReader reader2 = new StreamReader(theDataStream2);
            String data2 = reader2.ReadToEnd();
            reader2.Close();
            response2.Close();

            JavaScriptSerializer js2 = new JavaScriptSerializer();
            CreditCard creditCard = js.Deserialize<CreditCard>(data2);
            List<CreditCard> creditCards = new List<CreditCard>(0);
            creditCards.Add(creditCard);

            gvModifyCreditCard.DataSource = creditCards;
            gvModifyCreditCard.EditIndex = -1;
            gvModifyCreditCard.DataBind();
        }

        protected void gvModifyCreditCard_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModifyCreditCard.EditIndex = -1;
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/GetCreditCard/" + ddlSelectAccountForCreditCard.SelectedValue + "?apikey=1");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            CreditCard creditCard = js.Deserialize<CreditCard>(data);
            List<CreditCard> creditCards = new List<CreditCard>(0);
            creditCards.Add(creditCard);

            gvModifyCreditCard.DataSource = creditCards;
            gvModifyCreditCard.DataBind();
        }

        protected void gvModifyCreditCard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("ddlExpirationMonth");
                    CreditCard editCreditCard = e.Row.DataItem as CreditCard;
                    string[] expirationDate = editCreditCard.ExpirationDate.ToString().Split('/');
                    ddList.SelectedValue = expirationDate[0];

                    ddList = (DropDownList)e.Row.FindControl("ddlExpirationYear");
                    ddList.SelectedValue = expirationDate[1];

                    ddList = (DropDownList)e.Row.FindControl("ddlCreditCardStatus");
                    string creditCardStatus = editCreditCard.CreditCardStatus.ToString();
                    ddList.SelectedValue = creditCardStatus;
                }
            }
        }
        protected void btnConfirmAddCreditCard_Click(object sender, EventArgs e)
        {
            CreditCard newCreditCard = new CreditCard();
            try {
                newCreditCard.AccountID = Convert.ToInt32(ddlSelectAccountToAddCreditCard.SelectedValue);
            }
            catch (Exception ex)
            {
                lblAddCreditCardMessage.Text = "Error: No account without credit card exists. Create a new account first.";
                return;
            }
            int cvv = 0;
            if (!int.TryParse(txtAddCVV.Text, out cvv))
            {
                lblAddCreditCardMessage.Text = "CVV is not a valid integer set.";
                return;
            }
            else
            {
                newCreditCard.CVV = Convert.ToString(cvv);
            }
            newCreditCard.ExpirationDate = ddlAddExpirationMonth.SelectedValue + "/" + ddlAddExpirationYear.SelectedValue;
            decimal creditLimit = 0;
            if (!decimal.TryParse(txtAddCreditLimit.Text, out creditLimit))
            {
                lblAddCreditCardMessage.Text = "Credit limit is not a valid decimal value.";
                return;
            }
            else
            {
                newCreditCard.CreditLimit = creditLimit;
            }
            newCreditCard.CreditCardStatus = 1;
            newCreditCard.Balance = creditLimit;
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonAccount = js.Serialize(newCreditCard);
            try
            {
                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/AddCreditCard?apikey=1");
                //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/AddCreditCard?apikey=1");
                request.Method = "POST";
                request.ContentLength = jsonAccount.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonAccount);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                if (data == "true")
                {
                    lblAddCreditCardMessage.Text = "The credit card was successfully assigned and added to the database.";
                }
                else
                {
                    lblAddCreditCardMessage.Text = "The credit card wasn't assigned and updated to the database.";
                }
            }
            catch (Exception ex)
            {
                lblAddCreditCardMessage.Text = "Error: " + ex.Message;
            }
            WebRequest request2 = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetAccountsWithoutCreditCards?apikey=1");
            //request = WebRequest.Create("http://localhost:23637/api/Accounts/GetAccountsWithoutCreditCards?apikey=1");
            WebResponse response2 = request2.GetResponse();

            Stream theDataStream2 = response2.GetResponseStream();
            StreamReader reader2 = new StreamReader(theDataStream2);
            String data2 = reader2.ReadToEnd();
            reader2.Close();
            response2.Close();

            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Account[] accounts2 = js2.Deserialize<Account[]>(data2);

            ddlSelectAccountToAddCreditCard.DataSource = accounts2;
            ddlSelectAccountToAddCreditCard.DataTextField = "AccountName";
            ddlSelectAccountToAddCreditCard.DataValueField = "AccountID";
            ddlSelectAccountToAddCreditCard.DataBind();
        }
        protected void btnCancelAddCreditCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyCreditCard.aspx");
        }
    }
}