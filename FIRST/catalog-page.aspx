<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="catalog-page.aspx.cs" Inherits="SourceMarket.FIRST.catalog_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page catalog-page">
        <section class="clean-block clean-catalog dark">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">Catalog Page</h2>
                </div>
                <div></div>
                <div class="content">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="d-none d-md-block">
                                <div class="filters">
                                    <div class="filter-item">
                                        <asp:Button ID="ApplyButton" runat="server" CssClass="btn btn-block btn-primary" Text="Apply" OnClick="ApplyButton_Click" />
                                        <br />
                                        <asp:Button ID="ResetButton" runat="server" CssClass="btn btn-block btn-primary" Text="Reset" OnClick="ResetButton_Click" />
                                        <br />
                                        <h3>Show by</h3>
                                        <asp:RadioButtonList ID="byRBL" runat="server" CssClass="custom-radio ">
                                            <asp:ListItem Value="popularity">&nbsp popularity</asp:ListItem>
                                            <asp:ListItem Value="time">&nbsp time</asp:ListItem>
                                            <asp:ListItem Value="price">&nbsp price</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="col-md-9">
                            <div class="products">
                                <div class="row no-gutters">

                                    <!-------  repeater/data list  ------->
                                    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyField="ID" DataSourceID="catalogdatasource" GridLines="Both" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" OnItemCommand="DataList1_ItemCommand">
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <ItemStyle BackColor="White" ForeColor="#003399" />
                                        <ItemTemplate>
                                            ID:
                                                            <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                                            <br />
                                            <br />
                                            &nbsp;<div class="product-name" style="text-align: center">
                                                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' /></div>
                                            <br />
                                            &nbsp;<div class="image">
                                                <asp:Image ID="Image1" CssClass="img-fluid d-block mx-auto" runat="server" Height="160px" ImageUrl='<%# Eval("Pic") %>' Width="160px" /></div>
                                            <div class="text-center">
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="productpage" CssClass="btn btn-primary" Text='<%# Eval("price") %>' />
                                            </div>


                                        </ItemTemplate>
                                        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    </asp:DataList>
                                    <asp:SqlDataSource ID="catalogdatasource" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Product] WHERE ([state] = ?)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="active" Name="state" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>


                                </div>
                            </div>

                            <!------------->
                        </div>
                    </div>

                </div>
            </div>

        </section>
    </main>
</asp:Content>
