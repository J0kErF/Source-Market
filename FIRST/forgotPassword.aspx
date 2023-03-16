<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="SourceMarket.FIRST.forgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page login-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <div class="block-heading">

                    <div>

                        <h2 class="text-info">&nbsp;</h2>
                        <h2 class="text-info">Forgot Password</h2>
                    </div>
                    <asp:Panel ID="Panel1" runat="server" CssClass=" form-check form-control clean-form form-group">
                        <br />
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="EmailTB"></asp:RequiredFieldValidator>
                            &nbsp<label for="email">Email</label><asp:TextBox ID="EmailTB" CssClass="form-control item input-group" type="email" runat="server"></asp:TextBox>
                        </div>
                        &nbsp
                 

                        &nbsp<asp:Button ID="ResetBTN" CssClass="btn btn-primary btn-block" runat="server" Text=" Reset " OnClick="ResetBTN_Click"/>&nbsp
                

                    </asp:Panel>
                    <asp:Panel ID="panelNewPassword" runat="server"  CssClass=" form-check form-control clean-form form-group">
                           <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field" ControlToValidate="PasswordTB"></asp:RequiredFieldValidator>
                        &nbsp<label for="password">Email Code</label><asp:TextBox ID="PasswordTB" CssClass="form-control item input-group" type="text" runat="server" Style="left: 0px; top: 0px"></asp:TextBox>
                    </div>
                        &nbsp
                    <br />
                        <br />
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Field" ControlToValidate="EmailTB"></asp:RequiredFieldValidator>
                            &nbsp<label for="password">New Password</label><asp:TextBox ID="TextBoxNewPassword" CssClass="form-control item input-group" type="Text" runat="server"></asp:TextBox>
                        </div>
                        &nbsp<asp:Button ID="ChangeBTN" CssClass="btn btn-primary btn-block" runat="server" Text="Change Password" OnClick="ChangeBTN_Click" />&nbsp
                

                    </asp:Panel>
                </div>
            </div>
        </section>
    </main>

</asp:Content>
