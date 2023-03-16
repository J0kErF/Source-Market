<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="currency.aspx.cs" Inherits="SourceMarket.USERAREA.currency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">Currency Convertor</h3>
        <div class="card shadow">
            <div class="card-header py-3">
                <div class="row">
                    <div class="col-sm-1">
                        From
                    </div>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control form-control-sm custom-select custom-select-sm">
                            <asp:ListItem Text="ILS"></asp:ListItem>
                            <asp:ListItem Text="USD"></asp:ListItem>
                            <asp:ListItem Text="EUR"></asp:ListItem>
                            <asp:ListItem Text="AED"></asp:ListItem>
                            <asp:ListItem Text="CAD"></asp:ListItem>
                            <asp:ListItem Text="INR"></asp:ListItem>
                            <asp:ListItem Text="EGP"></asp:ListItem>
                            <asp:ListItem Text="SAR"></asp:ListItem>
                            <asp:ListItem Text="EGP"></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-1">
                        To
                    </div>

                    <div class="col-sm-2">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control form-control-sm custom-select custom-select-sm">

                            <asp:ListItem Text="ILS"></asp:ListItem>
                            <asp:ListItem Text="USD"></asp:ListItem>
                            <asp:ListItem Text="EUR"></asp:ListItem>
                            <asp:ListItem Text="AED"></asp:ListItem>
                            <asp:ListItem Text="CAD"></asp:ListItem>
                            <asp:ListItem Text="INR"></asp:ListItem>
                            <asp:ListItem Text="EGP"></asp:ListItem>
                            <asp:ListItem Text="SAR"></asp:ListItem>
                            <asp:ListItem Text="EGP"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-1">
                        Amount
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="TextBoxAmount" runat="server" Width="140px"></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                        <asp:LinkButton ID="LBSearch" runat="server" CssClass="btn btn-primary" OnClick="LBSearch_Click"><i class="fa fa-search"></i></asp:LinkButton>
                    </div>

                    <div class="col-sm-2">
                        <asp:TextBox ID="TextBoxVal" runat="server" Width="140px" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="card-body">

                <div class="row">
                    <div class="col-sm-12">
                        <asp:Panel ID="panel_GET" runat="server">
                            <asp:Button ID="ButtonClearHistory" runat="server" CssClass="btn btn-primary" Text=" Clear History " OnClick="ButtonClearHistory_Click" />
                            <br />
                        </asp:Panel>
                        <div id="Data" runat="server" class="table-responsive table mt-2" role="grid">
                            <asp:GridView ID="GridViewHistory" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceHistory">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                    <asp:BoundField DataField="From" HeaderText="From" SortExpression="From" />
                                    <asp:BoundField DataField="To" HeaderText="To" SortExpression="To" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                    <asp:BoundField DataField="Val" HeaderText="Val" SortExpression="Val" />
                                    <asp:BoundField DataField="AddDate" HeaderText="AddDate" SortExpression="AddDate" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceHistory" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGConnectionString %>" ProviderName="<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [History] WHERE ([Email] = ?) ORDER BY [AddDate] DESC">
                                <SelectParameters>
                                    <asp:SessionParameter SessionField="Email" Name="Email" Type="String"></asp:SessionParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
