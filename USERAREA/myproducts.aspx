<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="myproducts.aspx.cs" Inherits="SourceMarket.USERAREA.myproducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="products">
                                <div class="row no-gutters">

                                    <!-------  repeater/data list  ------->
                                    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None"  CellPadding="4" DataKeyField="ID" DataSourceID="catalogdatasource" GridLines="Both" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%" OnItemCommand="DataList1_ItemCommand">
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <ItemStyle BackColor="White" ForeColor="#003399" />
                                        <ItemTemplate>
                                            ID:
                                                            <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' ></asp:Label>
                                                            <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("state") %>'></asp:Label>
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
                                                <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="productpage" CssClass="btn btn-primary" Text="View" />
                                                 &nbsp; &nbsp;
                                                <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" CssClass="btn btn-primary" Text="Edit" />
                                                &nbsp; &nbsp;
                                                <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" CssClass="btn btn-primary" Text="Delete" />
                                            </div>


                                        </ItemTemplate>
                                        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    </asp:DataList>
                                    <asp:SqlDataSource ID="catalogdatasource" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>">
                                       
                                    </asp:SqlDataSource>


                                </div>
                            </div>

</asp:Content>
