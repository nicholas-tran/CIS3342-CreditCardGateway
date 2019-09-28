<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTransaction.aspx.cs" Inherits="CreditCardWebApplication.AddTransaction" %>

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
        <header>Add Transaction</header>
            <div class="btn-group btn-group-lg">
                <asp:Button ID="btnHome" Text="Home" runat="server" OnClick="btnHome_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnAddTransaction" Text="Add Transaction" runat="server" OnClick="btnAddTransaction_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyAccount" Text="Modify Account" runat="server" OnClick="btnModifyAccount_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyCreditCard" Text="Modify Credit Card" runat="server" OnClick="btnModifyCreditCard_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnRetrieveAllTransactions" Text="Retrieve Transactions" runat="server" OnClick="btnRetrieveAllTransactions_Click" CssClass="btn btn-default" />
            </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblTransactionMessage" runat="server"></asp:Label>
                    <asp:Table ID="tblTransactionInformation" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                Account ID:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAccountID" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Billing Information:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtBillingInformation" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Credit Card Number:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Textbox ID="txtCreditCardNumber" runat="server"></asp:Textbox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                CVV:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Textbox ID="txtCVV" runat="server"></asp:Textbox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Expiration Date:
                            </asp:TableCell>
                            <asp:TableCell>
                                    <asp:DropDownList ID="ddlTransactionExpirationMonth" runat="server">
                                        <asp:ListItem Text="1" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblTransactionExpirationSlash" Text="/" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlTransactionExpirationYear" runat="server">
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Amount:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Textbox ID="txtAmount" runat="server"></asp:Textbox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btnAddNewTransaction" Text="Submit" OnClick="btnAddNewTransaction_Click" runat="server"/>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btnClear" Text="Clear" runat="server"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
