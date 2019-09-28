<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrieveTransactions.aspx.cs" Inherits="CreditCardWebApplication.RetrieveTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieve Transactions</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="styles/StyleSheet.css" rel="stylesheet" />
    <style type="text/css">
        .gvShowTransactions{ border-spacing:3px; border-collapse: separate;}
        .gvShowTransactions > tbody > tr > th,
        .gvShowTransactions >tbody > tr > td {border:2px ridge black; padding: 3px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <header>Retrieve Transactions</header>
            <div class="btn-group btn-group-lg">
                <asp:Button ID="btnHome" Text="Home" runat="server" OnClick="btnHome_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnAddTransaction" Text="Add Transaction" runat="server" OnClick="btnAddTransaction_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyAccount" Text="Modify Account" runat="server" OnClick="btnModifyAccount_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyCreditCard" Text="Modify Credit Card" runat="server" OnClick="btnModifyCreditCard_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnRetrieveAllTransactions" Text="Retrieve Transactions" runat="server" OnClick="btnRetrieveAllTransactions_Click" CssClass="btn btn-default" />
            </div>
        <br />
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <asp:Table ID="tblSelectAccount" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlSelectAccount" runat="server">
                                </asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btnShowTransactions" Text="Show Transactions" runat="server" OnClick="btnShowTransactions_Click" CssClass="btn btn-basic"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="gvShowTransactions" runat="server" ForeColor="#333333"
                        BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None" CssClass="gvShowTransactions" GridLines="None" CellSpacing="-1">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
