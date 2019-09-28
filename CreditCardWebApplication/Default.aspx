<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CreditCardWebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>Home Page</header>
            <div class="btn-group btn-group-lg">
                <asp:Button ID="btnHome" Text="Home" runat="server" OnClick="btnHome_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnAddTransaction" Text="Add Transaction" runat="server" OnClick="btnAddTransaction_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyAccount" Text="Modify Account" runat="server" OnClick="btnModifyAccount_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyCreditCard" Text="Modify Credit Card" runat="server" OnClick="btnModifyCreditCard_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnRetrieveAllTransactions" Text="Retrieve Transactions" runat="server" OnClick="btnRetrieveAllTransactions_Click" CssClass="btn btn-default" />
            </div>
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    Select a web page from the nav bar for what you intend to do.
                </div>
            </div>
        </div>
    </form>
</body>
</html>
