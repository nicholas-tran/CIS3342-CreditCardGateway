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
    public partial class ModifyAccount : System.Web.UI.Page
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

                gvModifyAccount.DataSource = accounts;
                gvModifyAccount.DataBind();
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

        protected void gvModifyAccount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModifyAccount.EditIndex = e.NewEditIndex;
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

            gvModifyAccount.DataSource = accounts;
            gvModifyAccount.DataBind();
        }

        protected void gvModifyAccount_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            GridViewRow row = (GridViewRow)gvModifyAccount.Rows[e.RowIndex];
            Account account = new Account();
            int accountID = 0;
            TextBox textBoxAccountName = (TextBox)row.Cells[1].Controls[0];
            string accountName = textBoxAccountName.Text;
            TextBox textBoxBillingAddress = (TextBox)row.Cells[2].Controls[0];
            string billingAddress = textBoxBillingAddress.Text;
            if (int.TryParse(row.Cells[0].Text, out accountID))
            {
                account.AccountID = accountID;
                account.AccountName = accountName;
                account.BillingAddress = billingAddress;
                if (accountName == "")
                {
                    lblModifyAccountMessage.Text = "Account name is blank.";
                    return;
                }
            else if (billingAddress == "")
                {
                    lblModifyAccountMessage.Text = "Billing address is blank.";
                    return;
                }
                else
                {
                    JavaScriptSerializer js2 = new JavaScriptSerializer();
                    String jsonAccount = js2.Serialize(account);
                    try
                    {
                        WebRequest request2 = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/UpdateAccount?apikey=1");
                        //WebRequest request2 = WebRequest.Create("http://localhost:23637/api/Accounts/UpdateAccount?apikey=1");
                        request2.Method = "PUT";
                        request2.ContentLength = jsonAccount.Length;
                        request2.ContentType = "application/json";

                        StreamWriter writer = new StreamWriter(request2.GetRequestStream());
                        writer.Write(jsonAccount);
                        writer.Flush();
                        writer.Close();

                        WebResponse response2 = request2.GetResponse();
                        Stream theDataStream2 = response2.GetResponseStream();
                        StreamReader reader2 = new StreamReader(theDataStream2);
                        String data2 = reader2.ReadToEnd();
                        reader2.Close();
                        response2.Close();
                        if (data2 == "true") {
                            lblModifyAccountMessage.Text = "The account was successfully updated.";
                        }
                        else {
                            lblModifyAccountMessage.Text = "The account wasn't updated.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblModifyAccountMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
            else
            {
                lblModifyAccountMessage.Text = "Account ID is not a valid integer.";
                return;
            }
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

            gvModifyAccount.DataSource = accounts;
            gvModifyAccount.EditIndex = -1;
            gvModifyAccount.DataBind();
        }

        protected void gvModifyAccount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModifyAccount.EditIndex = -1;
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

            gvModifyAccount.DataSource = accounts;
            gvModifyAccount.DataBind();
        }

        protected void btnAddAccount_Click(object sender, EventArgs e)
        {
            Account newAccount = new Account();
            if(txtAccountName.Text == "")
            {
                lblAddAccountMessage.Text = "Name is invalid.";
            }
            else if(txtBillingAddress.Text == "")
            {
                lblAddAccountMessage.Text = "Billing address is invalid.";
            }
            newAccount.AccountName = txtAccountName.Text;
            newAccount.BillingAddress = txtBillingAddress.Text;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonAccount = js.Serialize(newAccount);
            try
            {
                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/AddAccount?apikey=1");
                //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/AddAccount?apikey=1");
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
                    lblAddAccountMessage.Text = "The account was successfully added to the database.";
                }
                else
                {
                    lblAddAccountMessage.Text = "The account wasn't updated to the database.";
                }
                WebRequest request2 = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts?apikey=1");
                //WebRequest request2 = WebRequest.Create("http://localhost:23637/api/Accounts?apikey=1");
                WebResponse response2 = request2.GetResponse();

                Stream theDataStream2 = response2.GetResponseStream();
                StreamReader reader2 = new StreamReader(theDataStream2);
                String data2 = reader2.ReadToEnd();
                reader2.Close();
                response2.Close();

                gvModifyAccount.EditIndex = -1;

                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Account[] accounts = js2.Deserialize<Account[]>(data2);

                gvModifyAccount.DataSource = accounts;
                gvModifyAccount.DataBind();
            }
            catch (Exception ex)
            {
                lblAddAccountMessage.Text = "Error: " + ex.Message;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyAccount.aspx");
        }
    }
}