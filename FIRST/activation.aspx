<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="activation.aspx.cs" Inherits="SourceMarket.activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page login-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <div class="block-heading">
    
                <div>
                    
                    <h2 class="text-info">&nbsp;</h2>
                    <h2 class="text-info">Activate Your Account</h2>
                </div>
                <asp:Panel ID="Panel1" runat="server" CssClass=" form-check form-control clean-form form-group">
                    <br />
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="codeTB"></asp:RequiredFieldValidator>
                        &nbsp<label>code</label><asp:TextBox ID="codeTB" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                    </div>
                   
                   
                    &nbsp<asp:Button ID="ActivateBTN" CssClass="btn btn-primary btn-block" runat="server" Text="Activate" OnClick="ActivateBTN_Click" />&nbsp
                
                </asp:Panel>
            </div>
            </div>
        </section>
    </main>

</asp:Content>
