<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="usermanager.aspx.cs" Inherits="SourceMarket.USERAREA.usermanager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataKeyField="Email" Width="100%" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand">
        <AlternatingItemStyle BackColor="White" ForeColor="#284775"></AlternatingItemStyle>

        <EditItemTemplate>
            <div class="text-center">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                &nbsp;<br /> &nbsp;<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("FullName") %>' CssClass="input-group input-group-text form-control"></asp:TextBox>
&nbsp;&nbsp;<br />&nbsp;<asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("PhoneNumber") %>' CssClass="input-group input-group-text form-control"></asp:TextBox>
                <br />
                &nbsp;<asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Password") %>' CssClass="input-group input-group-text form-control"></asp:TextBox>
                <br />
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Eval("status") %>'>
                    <asp:ListItem>active</asp:ListItem>
                    <asp:ListItem>pending</asp:ListItem>
                    <asp:ListItem>admin</asp:ListItem>
                </asp:DropDownList>
                <br />
                &nbsp;<asp:TextBox ID="TextBox4"  Text='<%# Eval("joindate") %>' runat="server" CssClass="input-group input-group-text form-control"></asp:TextBox>
            </div>
        </EditItemTemplate>

        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333"></ItemStyle>
        <ItemTemplate>
            <div class="text-center">
                &nbsp;<asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="joindateLabel" runat="server" Text='<%# Eval("joindate") %>' />
                <strong>
                <br />
                <asp:Label ID="FullNameLabel" runat="server" Text='<%# Eval("FullName") %>' />
                &nbsp;
                <br />
                </strong>&nbsp;<asp:Label ID="PhoneNumberLabel" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                <br />
                Password:
                <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
                <br />
                <br />
                <br />
            </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedItemStyle>
    </asp:DataList>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:CATALOGConnectionString %>' ProviderName='<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>
</asp:Content>
