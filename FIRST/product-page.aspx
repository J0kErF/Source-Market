<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="product-page.aspx.cs" Inherits="SourceMarket.FIRST.product_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page product-page">
        <section class="clean-block clean-product dark">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">Product Page</h2>
                </div>

                <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" DataSourceID="SqlDataSourceDATA" hieght="100%" Width="100%">
                    <ItemTemplate>
                        <div class="block-content ">
                            <div class="product-info">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="gallery">
                                            <div class="sp-wrap">
                                                <a href="<%#Eval("Pic") %>">
                                                    <img class="img-fluid d-block mx-auto" src="<%#Eval("Pic") %>"></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="info">
                                            <center><h3><%# Eval("title") %></h3></center>
                                            <div class="price">
                                                <center><h3><%#Eval("price") %> $</h3></center>
                                            </div>
                                            <center><button class="btn btn-primary" type="button" runat="server" onserverclick="AddToCart_ServerClick"><i class="icon-basket"></i>Add to Cart</button></center>
                                            <div class="summary">
                                                <p><%#Eval("info") %></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSourceDATA" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>" ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Product] WHERE ([ID] = ?)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div class="product-info">
                    <div>
                        <ul class="nav nav-tabs" id="myTab">
                            <li class="nav-item"><a class="nav-link active" role="tab" data-toggle="tab" id="description-tab" href="#description">Description</a></li>
                            <li class="nav-item"><a class="nav-link" role="tab" data-toggle="tab" id="specifications-tabs" href="#specifications">Specifications</a></li>
                            <li class="nav-item"><a class="nav-link" role="tab" data-toggle="tab" id="reviews-tab" href="#reviews">Reviews</a></li>
                        </ul>
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane active fade show description" role="tabpanel" id="description">
                                <!---- The description ---->
                                <asp:Label ID="LabelDescription" runat="server" Text="No Description Found"></asp:Label>
                            </div>
                            <!---- The specification ---->
                            <div class="tab-pane fade show specifications" role="tabpanel" id="specifications">
                                <div class="table-responsive table-bordered">
                                    <table class="table table-bordered">
                                        <tbody>
                                            <asp:Label ID="specificationslabel" runat="server" Text=""></asp:Label>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                             <!---- The reviews ---->
                            <div class="tab-pane fade show" role="tabpanel" id="reviews">
                                <asp:Repeater ID="Reviewsrepeater" runat="server" DataSourceID="SqlDataSourceReviews">
                                    <ItemTemplate>
                                        <div class="reviews">
                                            <div class="review-item">
                                                <h4><%#Eval("title") %></h4>
                                                <span class="text-muted"><%#Eval("EmailID") %>&nbsp;,&nbsp;<%#Eval("time") %></span><p><%#Eval("review") %></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>

                                </asp:Repeater>
                                <asp:Panel ID="PanelWriteR" runat="server">
                                    <br />
                                    <asp:TextBox ID="ReviewTitle" runat="server" PlaceHolder="Title" CssClass="input-group form-control item" ></asp:TextBox>
                                    <br />
                                    <asp:TextBox ID="ReviewBody" runat="server" PlaceHolder="Body ..." CssClass="form-control item input-group" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="WriteAReview" runat="server" Text=" Write a Review " CssClass="btn btn-primary form-control" OnClick="WriteAReview_Click" />
                                </asp:Panel>
                            </div>
                            <asp:SqlDataSource ID="SqlDataSourceReviews" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>" ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [reviews] WHERE ([PID] = ?) ORDER BY [time] DESC">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="PID" QueryStringField="ID" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>

        </section>
    </main>
</asp:Content>
