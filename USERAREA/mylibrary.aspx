<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="mylibrary.aspx.cs" Inherits="SourceMarket.USERAREA.mylibrary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" OnItemCommand="DataList1_ItemCommand">
        <ItemStyle BackColor="White" ForeColor="#003399" />
        <ItemTemplate>
            ID : <asp:Label ID="IDLabel" runat="server" Text=' <%# Eval("Pid") %>' />
            <br />
            <br />
            &nbsp;<div class="product-name" style="text-align: center">
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("Ptitle") %>' />
            </div>
            <br />
            <div class="text-center">
                <br />
                <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("Spath") %>' CommandName="download" CssClass="btn btn-primary" Text='Download' />
            </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    </asp:DataList>

</asp:Content>
