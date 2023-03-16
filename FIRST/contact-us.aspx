<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="SourceMarket.FIRST.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <main class="page contact-us-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">Contact Us</h2>
                </div>
                <form>
                    <div class="form-group"><label>Name</label><asp:TextBox ID="NameTB" runat="server" CssClass="form-control input-group item" type="text"></asp:TextBox></div>
                    <div class="form-group"><label>Subject</label><asp:TextBox ID="SubjectTB" runat="server" CssClass="form-control input-group item" type="text"></asp:TextBox></div>
                    <div class="form-group"><label>Email</label><asp:TextBox ID="EmailTB" runat="server" CssClass="form-control input-group item" type="email"></asp:TextBox></div>
                    <div class="form-group"><label>Message</label><asp:TextBox ID="MessageTB" runat="server" CssClass="form-control input-group item" TextMode="MultiLine" Rows="4" type="text"></asp:TextBox></textarea></div>
                    <div class="form-group"><asp:Button ID="sendBTN" CssClass="btn btn-primary btn-block" runat="server" Text="Send" OnClick="sendBTN_Click"/></div>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </form>
            </div>
            
        </section>
    </main>
</asp:Content>
