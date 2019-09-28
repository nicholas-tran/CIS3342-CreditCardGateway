<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyAccount.aspx.cs" Inherits="CreditCardWebApplication.ModifyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify Account</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="styles/StyleSheet.css" rel="stylesheet" />
            <style type="text/css">
        .gvModifyAccount{ border-spacing:3px; border-collapse: separate;}
        .gvModifyAccount > tbody > tr > th,
        .gvModifyAccount >tbody > tr > td {border:2px ridge black; padding: 3px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>Modify Account</header>
            <div class="btn-group btn-group-lg">
                <asp:Button ID="btnHome" Text="Home" runat="server" OnClick="btnHome_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnAddTransaction" Text="Add Transaction" runat="server" OnClick="btnAddTransaction_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyAccount" Text="Modify Account" runat="server" OnClick="btnModifyAccount_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyCreditCard" Text="Modify Credit Card" runat="server" OnClick="btnModifyCreditCard_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnRetrieveAllTransactions" Text="Retrieve Transactions" runat="server" OnClick="btnRetrieveAllTransactions_Click" CssClass="btn btn-default" />
            </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lblModifyAccountMessage" runat="server"></asp:Label>
                    <asp:GridView ID="gvModifyAccount" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvModifyAccount_RowCancelingEdit" OnRowEditing="gvModifyAccount_RowEditing" OnRowUpdating="gvModifyAccount_RowUpdating" 
                     BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None" CssClass="gvModifyAccount" GridLines="None" CellSpacing="-1">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="AccountID" HeaderText="Account ID" ReadOnly="true"/>
                            <asp:BoundField DataField="AccountName" HeaderText="Account Name"/>
                            <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address"/>
                            <asp:CommandField ButtonType="Button" ShowEditButton="True">
                            <ControlStyle CssClass="btn btn-basic" />
                            </asp:CommandField>
                        </Columns>
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
                <div class="col-md-6">
                    <asp:Table ID="tblAddAccount" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                Enter Name:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAccountName" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Billing Address:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><asp:Button ID="btnAddAccount" Text="Confirm Add" runat="server" OnClick="btnAddAccount_Click" CssClass="btn btn-basic"/></asp:TableCell>
                            <asp:TableCell><asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-basic"/></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblAddAccountMessage" runat="server"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
