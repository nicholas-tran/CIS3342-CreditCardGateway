<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyCreditCard.aspx.cs" Inherits="CreditCardWebApplication.ModifyCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify Credit Card</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="styles/StyleSheet.css" rel="stylesheet" />
        <style type="text/css">
        .gvModifyCreditCard{ border-spacing:3px; border-collapse: separate;}
        .gvModifyCreditCard > tbody > tr > th,
        .gvModifyCreditCard >tbody > tr > td {border:2px ridge black; padding: 3px;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
            <header>Modify Credit Card</header>
            <div class="btn-group btn-group-lg">
                <asp:Button ID="btnHome" Text="Home" runat="server" OnClick="btnHome_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnAddTransaction" Text="Add Transaction" runat="server" OnClick="btnAddTransaction_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyAccount" Text="Modify Account" runat="server" OnClick="btnModifyAccount_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnModifyCreditCard" Text="Modify Credit Card" runat="server" OnClick="btnModifyCreditCard_Click" CssClass="btn btn-default" />
                <asp:Button ID="btnRetrieveAllTransactions" Text="Retrieve Transactions" runat="server" OnClick="btnRetrieveAllTransactions_Click" CssClass="btn btn-default" />
            </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-7">
                    <asp:Table ID="tblSelectAccountForCreditCard" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlSelectAccountForCreditCard" runat="server"></asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btnSelectAccountForCreditCard" Text="Find Credit Card" runat="server" OnClick="btnSelectAccountForCreditCard_Click" CssClass="btn btn-default"/>
                            </asp:TableCell>
                        </asp:TableRow>
                        </asp:Table>
                    <asp:Label ID="lblModifyCreditCardMessage" runat="server"></asp:Label>
                    <asp:GridView ID="gvModifyCreditCard" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvModifyCreditCard_RowCancelingEdit" OnRowEditing="gvModifyCreditCard_RowEditing" OnRowUpdating="gvModifyCreditCard_RowUpdating" OnRowDataBound="gvModifyCreditCard_RowDataBound" 
                        ForeColor="#333333"
                         BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None" CssClass="gvModifyCreditCard" GridLines="None" CellSpacing="-1">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CreditCardID" HeaderText="CreditCard ID" ReadOnly="true"/>
                            <asp:BoundField DataField="CVV" HeaderText="CVV" ReadOnly="true"/>
                            <asp:TemplateField HeaderText="Expiration Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblExpirationDate" Text='<%# Eval("ExpirationDate") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlExpirationMonth" runat="server">
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
                                    <asp:Label ID="lblExpirationSlash" Text="/" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlExpirationYear" runat="server">
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Balance" HeaderText="Balance"/>
                            <asp:BoundField DataField="AccountID" HeaderText="Account ID" ReadOnly="true"/>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreditCardStatus" Text='<%# Eval("CreditCardStatus") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCreditCardStatus" runat="server">
                                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreditLimit" HeaderText="Credit Limit" />
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
                <div class="col-md-5">
                    <asp:DropDownList ID="ddlSelectAccountToAddCreditCard" runat="server"></asp:DropDownList>
                                        <asp:Label ID="lblAddCreditCardMessage" runat="server"></asp:Label>
                    <asp:Table ID="tblAddCreditCard" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                Enter a CVV:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAddCVV" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Enter an expiration date:
                            </asp:TableCell>
                            <asp:TableCell>
                                    <asp:DropDownList ID="ddlAddExpirationMonth" runat="server">
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
                                    <asp:Label ID="lblAddExpirationSlash" Text="/" runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddlAddExpirationYear" runat="server">
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Enter a credit limit:</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txtAddCreditLimit" runat="server"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            <asp:Button ID="btnConfirmAddCreditCard" Text="Add Credit Card" runat="server" OnClick="btnConfirmAddCreditCard_Click" CssClass="btn btn-default"/>
                                </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btnCancelAddCreditCard" Text="Cancel" runat="server" OnClick="btnCancelAddCreditCard_Click" CssClass="btn btn-default"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
