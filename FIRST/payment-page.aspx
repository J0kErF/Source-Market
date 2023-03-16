<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="payment-page.aspx.cs" Inherits="SourceMarket.FIRST.payment_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <main class="page payment-page">
        <section class="clean-block payment-form dark">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">Payment</h2>
                </div>
                <form>
                    
         <div class="products">
                        <h3 class="title">Checkout</h3>
    
<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSourcart" >
    
    <ItemTemplate>
        <div class="item"><span class="price"><%#Eval("price") %></span>
                            <p class="item-name"><%#Eval("Title") %></p>
                            <p class="item-description "><a href="product-page.aspx?ID=<%#Eval("ID") %>">Click Here To View Full Details</a></p>
                            <asp:Label ID="ProductID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                        </div>
    </ItemTemplate>
    
</asp:Repeater>
                    
        <div class="total"><span>Total</span><span class="price"><asp:Label ID="Sum" runat="server" Text=""></asp:Label></span></div>
                    </div>
    
                    <asp:SqlDataSource ID="SqlDataSourcart" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>" ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>" SelectCommand="SELECT Product.price, Product.ID, Product.title FROM ((cartproducts INNER JOIN Product ON cartproducts.PID = Product.ID) INNER JOIN USERS ON cartproducts.UID = USERS.Email) WHERE (USERS.Email = ?)">
                        <SelectParameters>
                            <asp:SessionParameter Name="USERS.Email" SessionField="Email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    <div class="card-details">
                        <h3 class="title">Credit Card Details</h3>
                        <div class="form-row">
                            <div class="col-sm-7">
                                <div class="form-group"><label for="card-holder">Card Holder</label><asp:TextBox ID="TextBoxHName" runat="server" CssClass="form-control" type="text" placeholder="Card Holder"></asp:TextBox></div>
                            </div>
                            <div class="col-sm-5">
                                <div class="form-group"><label>Expiration date</label>
                                    <div class="input-group expiration-date"><asp:TextBox ID="TextBoxmonth" runat="server" CssClass="form-control" type="text" placeholder="MM"></asp:TextBox><asp:TextBox ID="TextBoxyear" runat="server" CssClass="form-control" type="text" placeholder="YY"></asp:TextBox></div>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="form-group"><label for="card-number">Card Number</label><asp:TextBox ID="TextBoxNum" runat="server" CssClass="form-control" type="text" placeholder="Card Number"></asp:TextBox></div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group"><label for="cvc">CVC</label><asp:TextBox ID="TextBoxCVC" runat="server" CssClass="form-control" type="text" placeholder="CVC"></asp:TextBox></div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group"><asp:Button ID="ButtonProceed" runat="server" Text="Proceed" CssClass="btn btn-primary btn-block" type="submit" OnClick="ButtonProceed_Click" /></div>
                            </div>
                        </div>
                    </div>
                </form>
            
            </div>
            
        </section>
    </main>

</asp:Content>
