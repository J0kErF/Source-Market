<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SourceMarket.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page login-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <div class="block-heading">
    
                <div>
                    
                    <h2 class="text-info">&nbsp;</h2>
                    <h2 class="text-info">Log In</h2>
                </div>
                <asp:Panel ID="Panel1" runat="server" CssClass=" form-check form-control clean-form form-group">
                    <br />
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="EmailTB"></asp:RequiredFieldValidator>
                        &nbsp<label for="email">Email</label><asp:TextBox ID="EmailTB" CssClass="form-control item input-group" type="email" runat="server"></asp:TextBox>
                    </div>
                    &nbsp
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field" ControlToValidate="PasswordTB"></asp:RequiredFieldValidator>
                        &nbsp<label for="password">Password</label><asp:TextBox ID="PasswordTB" CssClass="form-control item input-group" type="password" runat="server" Style="left: 0px; top: 0px"></asp:TextBox>
                    </div>
                    &nbsp
                    <br />
                   
                    &nbsp<asp:Button ID="loginBTN" CssClass="btn btn-primary btn-block" runat="server" Text="Log In" OnClick="loginBTN_Click" />&nbsp
                

                </asp:Panel>
            </div>
            </div>
        </section>
    </main>

</asp:Content>
