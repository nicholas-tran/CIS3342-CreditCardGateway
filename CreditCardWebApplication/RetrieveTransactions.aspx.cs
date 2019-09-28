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
    public partial class RetrieveTransactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetAllCreditCards?apikey=1");
                //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/GetAllCreditCards?apikey=1");
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                CreditCard[] creditCards = js.Deserialize<CreditCard[]>(data);

                ddlSelectAccount.DataSource = creditCards;
                ddlSelectAccount.DataValueField = "CreditCardID";
                ddlSelectAccount.DataTextField = "CreditCardID";
                ddlSelectAccount.DataBind();
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

        protected void btnShowTransactions_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug26951/Project4WS/api/Accounts/GetAllTransactions/"+ ddlSelectAccount.SelectedValue +"/?apikey=1");
            //WebRequest request = WebRequest.Create("http://localhost:23637/api/Accounts/GetAllTransactions/"+ ddlSelectAccount.SelectedValue +"/?apikey=1");
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            AccountTransaction[] accountTransactions = js.Deserialize<AccountTransaction[]>(data);
            gvShowTransactions.DataSource = accountTransactions;
            gvShowTransactions.DataBind();
        }
    }
}