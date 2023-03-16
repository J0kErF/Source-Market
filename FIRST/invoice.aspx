<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="SourceMarket.FIRST.invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page invoice-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <div class="block-heading">
                    <br />
                    <h2 class="text-info">invoice </h2>

                </div>
                <form>
                    <div class="form-group" style="text-align: center">
                        <asp:ImageButton ID="DownloadInvoice" runat="server" OnClick="DownloadInvoice_Click" ImageUrl="~/media/Download128.png" ImageAlign="Middle" Height="69px" Width="74px" />

                        <asp:Panel ID="InvoicePanel" runat="server">

                            <asp:Label ID="HTMLTABLE" runat="server"></asp:Label>
                        </asp:Panel>
                    </div>
                </form>
            </div>

        </section>
    </main>
</asp:Content>
