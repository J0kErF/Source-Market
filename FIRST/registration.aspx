<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="SourceMarket.FIRST.registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page registration-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <div class="block-heading">
                    <br />
                    <h2 class="text-info">Registration</h2>
                </div>
                <form>
                    <div class="form-group">
                        <label for="name">Name *</label><asp:TextBox ID="NameTB" runat="server" CssClass="form-control item input-group" type="text"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="email">Email *</label><asp:TextBox ID="EmailTB" runat="server" CssClass="form-control item input-group" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="name">Phone Number</label><asp:TextBox ID="PhoneNumberTB" runat="server" CssClass="form-control item input-group" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Password *</label><asp:TextBox ID="PasswordTB" runat="server" CssClass="form-control item input-group" type="password"></asp:TextBox>
                    </div>
                    <asp:Panel ID="AdminPanel" runat="server" Visible="false">
                        <div class="form-group">
                            <label for="password">status </label>
                            <asp:TextBox ID="TextBoxstatus" runat="server" CssClass="form-control item input-group" type="text"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="password">Join Date *</label>
                            <asp:TextBox ID="TextBoxjoindate" runat="server" CssClass="form-control item input-group" type="text"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <asp:Button ID="signupBTN" CssClass="btn btn-primary btn-block" runat="server" Text="Sign Up" OnClick="signupBTN_Click" />
                    <asp:Button ID="UpdateBTN" CssClass="btn btn-primary btn-block" runat="server" Text="Update" OnClick="UpdateBTN_Click" Visible="false" />
                </form>
            </div>
        </section>
    </main>
</asp:Content>
