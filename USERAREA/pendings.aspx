<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="pendings.aspx.cs" Inherits="SourceMarket.USERAREA.pendings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">Data Manager</h3>
        <div class="card shadow">
            <div class="card-header py-3">
                <div class="row">
                    <div class="col-sm-10">
                        <asp:DropDownList ID="DDLTablName" runat="server">
                            <asp:ListItem Text="Users" Value="USERS"></asp:ListItem>
                            <asp:ListItem Text="Products" Value="Product"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <asp:LinkButton ID="LBSELECT" runat="server" CssClass="btn btn-primary" OnClick="LBSELECT_Click"><i class="fa fa-search"></i></asp:LinkButton>

                    </div>
                </div>
            </div>
            <div class="card-body">

                <div class="row">
                    <div class="col-sm-12">
                        <asp:MultiView ID="DATAVIEW" runat="server">
                            <asp:View ID="view1" runat="server">
                                <div id="Div1" runat="server" class="table-responsive table mt-2" role="grid">
                                    <asp:DataList ID="DTUSERS" runat="server" RepeatColumns="3" DataSourceID="SqlDataSourceUSERS" OnItemCommand="DTUSERS_ItemCommand">
                                        <ItemTemplate>
                                            <div class="text-center">
                                                <asp:Label ID="EmailLbl" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="NameLbl" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="Statuslbl" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                <br />
                                                <br />
                                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:Button ID="Pending" Text="Pending" runat="server" CssClass="btn btn-primary" CommandName="Pending" CommandArgument='<%# Eval("Email") %>' />
                                                &nbsp&nbsp
                                                <asp:Button ID="Active" Text="Active" runat="server" CssClass="btn btn-primary" CommandName="Active" CommandArgument='<%# Eval("Email") %>' />
                                                &nbsp&nbsp
                                                <asp:Button ID="Admin" runat="server" Text="Admin" CssClass="btn btn-primary" CommandName="Admin" CommandArgument='<%# Eval("Email") %>' />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSourceUSERS" ConnectionString='<%$ ConnectionStrings:CATALOGConnectionString %>' ProviderName='<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [USERS] ORDER BY [joindate] DESC"></asp:SqlDataSource>
                                </div>
                            </asp:View>
                            <asp:View ID="view2" runat="server">

                                <div id="Data" runat="server" class="table-responsive table mt-2" role="grid">
                                    <asp:DataList ID="dlProducts" runat="server" RepeatColumns="5" DataSourceID="SqlDataSourceProduct" OnItemCommand="dlProducts_ItemCommand">
                                        <ItemTemplate>
                                            <div class="text-center">
                                                <asp:Label ID="PID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="PNAME" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="PSTATUS" runat="server" Text='<%# Eval("state") %>'></asp:Label>
                                                <br />
                                                <br />
                                                &nbsp
                                                <asp:Button ID="Pending" Text="Pending" runat="server" CssClass="btn btn-primary" CommandName="Pending" CommandArgument='<%# Eval("ID") %>' />
                                                &nbsp&nbsp
                                                <asp:Button ID="Active" runat="server" Text="Active" CssClass="btn btn-primary" CommandName="Active" CommandArgument='<%# Eval("ID") %>' />&nbsp&nbsp
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSourceProduct" ConnectionString='<%$ ConnectionStrings:CATALOGConnectionString %>' ProviderName='<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [Product] ORDER BY [addeddate] DESC"></asp:SqlDataSource>
                                </div>

                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
