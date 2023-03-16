<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="SourceMarket.USERAREA.error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="text-align: center">
        <div class="text-center">
            <div class="card-header" >
                <center>
                <p style="text-align: center; font-family: Georgia; color: #333333; font-style: normal; font-weight: bold; font-size: 5em;"><%= Request.QueryString["ID"] %></p>
                </center>
            </div>
        </div>
        <p class="text-dark mb-5 lead">Ooops.. It looks like something went wrong</p>
        <p class="text-black-50 mb-0">if this error appears again feel free to contact us</p>
        <a href="Dashboard.aspx">← Back to Dashboard</a>
    </div>
</asp:Content>
