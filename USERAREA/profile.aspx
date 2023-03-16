<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="SourceMarket.USERAREA.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h3 class="text-dark mb-4">Profile</h3>
        <div class="row mb-3">
            <div class="col-lg-4">
                <div class="card mb-3">
                    <div class="card-header py-3">
                        <p class="text-primary m-0 font-weight-bold">payment method</p>
                    </div>
                    <div class="card-body text-center shadow">
                        <div class="col">
                            <div class="form-group">
                                <label for="CreditCard">
                                    <strong>CeditCard &nbsp; &nbsp;&nbsp;</strong><br />
                                </label>
                                <asp:TextBox ID="VisaNum" runat="server" type="text" name="CreditCard"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="CreditCard">
                                    <strong>Holder Name &nbsp; &nbsp;&nbsp;</strong><br />
                                </label>
                                <asp:TextBox ID="HolderName" runat="server" type="text" name="HolderName"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="CreditCard" style="text-align: center; margin-left: 26px; margin-right: 34px;">
                                    <strong>CVC &nbsp; &nbsp; &nbsp;</strong><br />
                                </label>
                                <asp:TextBox ID="CVC" runat="server" type="text" placeholder="CVC" name="CVC"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label for="CreditCard">
                                    <strong>Expiration Date &nbsp; &nbsp; &nbsp;</strong><br />

                                </label>
                                <asp:TextBox ID="ExpirationDate" runat="server" type="text" placeholder="Expiration Date" name="ExpirationDate"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="SaveChangesCreditCard" OnClick="SaveChangesCreditCard_Click" runat="server" CssClass="btn btn-primary btn-sm" type="submit" Text="Save Changes" />

                    </div>
                </div>
                <div class="card shadow">
                    <div class="card-header py-3">
                        <p class="text-primary m-0 font-weight-bold">change password</p>
                    </div>
                    <div class="card-body">

                        <div class="form-group">
                            <label for="address">
                                <strong>old password</strong><br />
                            </label>

                            <asp:TextBox ID="TextBoxOldPassword" runat="server" CssClass="form-control" type="password"></asp:TextBox>

                        </div>
                        <div class="form-row">

                            <div class="col">
                                <div class="form-group">
                                    <label for="city">
                                        <strong>New password</strong><br />
                                    </label>
                                    <asp:TextBox ID="TextBoxNewPassword" runat="server" CssClass="form-control" type="password"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="ChangePasswordButton" runat="server" UseSubmitBehavior="false" CssClass="btn btn-primary btn-sm" Text="Change password" OnClick="ChangePasswordButton_Click" />

                        </div>

                    </div>
                </div>
            </div>
            <div class="col-lg-8">

                <div class="row">
                    <div class="col">
                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <p class="text-primary m-0 font-weight-bold">User</p>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="username"><strong>Name</strong></label><asp:TextBox ID="TextBoxFullName" runat="server" class="form-control" type="text" placeholder="full name" name="FullName"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="first_name">
                                                    <strong>phone number</strong><br />
                                                </label>
                                                <asp:TextBox ID="TextBoxPhoneNumber" runat="server" CssClass="form-control" type="text" placeholder="+0123456789000" name="first_name"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="email"><strong>Email Address</strong></label>
                                                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" type="email" placeholder="user@example.com" name="email"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary btn-sm" type="submit" Text="Save Changes" />

                                    </div>
                                </form>
                            </div>
                        </div>
                        <div class="card shadow mb-4">
                            <div class="card-header py-3">
                                <h6 class="text-primary font-weight-bold m-0">Products</h6>
                            </div>
                            <div class="card-body">

                                <asp:Repeater ID="RepeaterProducts" DataSourceID="SqlDataSource1" runat="server">
                                    <ItemTemplate>
                                        <div class="card-body">
                                            <h4 class="small font-weight-bold"><%# Eval("title") %><span class="float-right"><%# Eval("downloadcount") %></span></h4>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:CATALOGConnectionString %>' ProviderName='<%$ ConnectionStrings:CATALOGConnectionString.ProviderName %>' SelectCommand="SELECT [downloadcount], [title] FROM [Product] WHERE ([Email] = ?) ORDER BY [downloadcount] DESC">
                                <SelectParameters>
                                    <asp:SessionParameter SessionField="Email" Name="Email" Type="String"></asp:SessionParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel ID="PanelAdminAlerts" runat="server">
            <div class="card shadow mb-5">
                <div class="card-header py-3">
                    <p class="text-primary m-0 font-weight-bold">admin alert center</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">

                            <div class="form-group">
                                <label for="signature">
                                    <strong>To</strong><br>
                                </label>
                                <asp:TextBox ID="TextBoxTo" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="signature">
                                    <strong>the title</strong><br>
                                </label>
                                <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="signature">
                                    <strong>the message</strong><br>
                                </label>
                                <asp:TextBox ID="TextBoxMessage" runat="server" TextMode="multiline" Rows="5" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="ButtonShareAlert" runat="server" CssClass="btn btn-primary btn-sm" Text="Share" UseSubmitBehavior="false" OnClick="ButtonShareAlert_Click" />
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
