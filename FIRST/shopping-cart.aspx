<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="shopping-cart.aspx.cs" Inherits="SourceMarket.FIRST.shopping_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page shopping-cart-page">
        <section class="clean-block clean-cart dark">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">Shopping Cart</h2>
                </div>
                <div class="content">
                    <div class="row no-gutters">
                        <div class="col-md-12 col-lg-8">
                            <div class="items">
                                <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" DataSourceID="SqlDataSourcecart" OnItemCommand="DataList1_ItemCommand">
                                    <ItemTemplate>
                                        <div class="product">
                                            <div class="row justify-content-center align-items-center">
                                                <div class="col-md-3">
                                                    <div class="product-image">

                                                        <img class="img-fluid d-block mx-auto image" src='<%#Eval("Pic") %>' />
                                                    </div>
                                                </div>
                                                <div class="col-md-5 product-info">
                                                    <a class="product-name" href="product-page.aspx?ID=<%#Eval("ID") %>"><%#Eval("title") %></a>
                                                </div>
                                                <asp:Label ID="PID" Text='<%#Eval("ID") %>' Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="UID" Text='<%#Eval("Email") %>' Visible="false" runat="server"></asp:Label>
                                                <div class="col-6 col-md-2 price"><span><%#Eval("price") %></span></div>
                                                <asp:Button ID="DeleteButton" runat="server" CssClass="btn btn-primary btn-block btn-lg" Text="Remove" CommandName="delete"/>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    
                                </asp:DataList>
                                <asp:SqlDataSource ID="SqlDataSourcecart" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>"  ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>" SelectCommand="SELECT Product.price, Product.ID, Product.Pic, Product.title, USERS.Email FROM ((cartproducts INNER JOIN Product ON cartproducts.PID = Product.ID) INNER JOIN USERS ON cartproducts.UID = USERS.Email) WHERE (USERS.Email = ?)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="?" SessionField="Email" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>

                        </div>
                        <div class="col-md-12 col-lg-4">
                            <div class="summary">
                                <h3>Summary</h3>
                                <h4><span class="text">Total</span><span class="price"><asp:Label ID="Total" runat="server"></asp:Label></span></h4>
                                <asp:Button ID="topayment" runat="server" CssClass="btn btn-primary btn-block btn-lg" Text="Checkout" OnClick="topayment_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>

</asp:Content>
