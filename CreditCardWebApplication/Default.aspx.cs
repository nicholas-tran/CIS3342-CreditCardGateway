using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreditCardWebApplication
{
    public partial class Default : System.Web.UI.Page
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
    }
}