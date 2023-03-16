<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="myreviews.aspx.cs" Inherits="SourceMarket.USERAREA.myreviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div class="tab-pane fade show" role="tabpanel" id="reviews">
        <asp:Repeater ID="Reviewsrepeater" runat="server" DataSourceID="SqlDataSource" OnItemCommand="Reviewsrepeater_ItemCommand">
            <ItemTemplate>
                <div class="reviews">
                    <div class="review-item">

                        <span><%#Eval("PID") %></span>
                        <h4><%#Eval("title") %></h4>
                        <span class="text-muted"><%#Eval("EmailID") %>&nbsp;,&nbsp;<%#Eval("time") %></span><p><%#Eval("review") %></p>
                        <br />
                        <asp:Button ID="DeleteReview" CssClass="btn btn-primary" Text="Delete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' />
                    </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
        <asp:SqlDataSource runat="server" ID="SqlDataSource" ConnectionString='<%$ ConnectionStrings:CATALOGConnectionString %>' ProviderName='<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [reviews] WHERE ([EmailID] = ?)">
            <SelectParameters>
                <asp:SessionParameter SessionField="Email" Name="EmailID" Type="String"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
        </center>
</asp:Content>
