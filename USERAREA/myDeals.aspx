<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="myDeals.aspx.cs" Inherits="SourceMarket.USERAREA.myDeals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DealsDataList" runat="server" RepeatColumns="4" DataKeyField="ID" DataSourceID="SqlDataSourceDeals" width="100%">

        <ItemTemplate>
            <div class="text-center">
                Deal ID:
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                <br />
                <asp:Label ID="DealTimeLabel" runat="server" Text='<%# Eval("DealTime") %>' />
                <br />
                <br />
                Seller Email:
                <asp:Label ID="SellerEmailLabel" runat="server" Text='<%# Eval("SellerEmail") %>' />
                <br />
                Buyer Email:
                <asp:Label ID="BuyerEmailLabel" runat="server" Text='<%# Eval("BuyerEmail") %>' />
                <br />
                <br />
                Product ID:
                <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                <br />
                Source ID:
                <asp:Label ID="SourceIDLabel" runat="server" Text='<%# Eval("SourceID") %>' />
                <br />
                <br />
                Price:
                <asp:Label ID="PPriceLabel" runat="server" Text='<%# Eval("PPrice") %>' />
                <br />
                <span style="color: #0066FF">___________________________________________________</span><br />
            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceDeals" ConnectionString='<%$ ConnectionStrings:CATALOGConnectionString %>' ProviderName='<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [DEALS] WHERE (([SellerEmail] = ?) OR ([BuyerEmail] = ?)) ORDER BY [DealTime] DESC">
        <SelectParameters>
            <asp:SessionParameter SessionField="Email" Name="SellerEmail" Type="String"></asp:SessionParameter>
            <asp:SessionParameter SessionField="Email" Name="BuyerEmail" Type="String"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
