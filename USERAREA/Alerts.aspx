<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="Alerts.aspx.cs" Inherits="SourceMarket.USERAREA.Alerts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="page login-page">
        <section class="clean-block clean-form dark">
            <div class="container">
                <asp:Label ID="msgLBL" runat="server" CssClass="label label-default" ></asp:Label>
                <asp:MultiView ID="MultiviewAlerts" runat="server">
                    <asp:View ID="ViewAlerts" runat="server">

                        <div class="text-center">
                            <asp:GridView ID="GridViewAlerts" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" Height="208px" Width="662px" OnRowCommand="GridViewAlerts_RowCommand">
                                <Columns>

                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="From">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelFrom" runat="server" Text='<%# Bind("From") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelSubject" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Send in">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTime" runat="server" Text='<%# Bind("alerttime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelStatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButtonDelete" CommandName="View" CommandArgument='<%# Bind("ID") %>' runat="server" CausesValidation="False"><i class="fa fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />


                    </asp:View>
                    <asp:View ID="ViewAlert" runat="server">
                        <div class="form-group">
                            &nbsp<label for="ID">ID : </label>
                            <asp:TextBox ID="TextBoxID" ReadOnly="true" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                        </div>
                        &nbsp
                         <div class="form-group">
                             &nbsp<asp:TextBox ID="TextBoxDate" ReadOnly="true" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                         </div>
                        &nbsp
                         <div class="form-group">
                             &nbsp<label for="from">From : </label>
                             <asp:TextBox ID="TextBoxFrom" CssClass="form-control item input-group" ReadOnly="true" type="text" runat="server"></asp:TextBox>
                         </div>
                        &nbsp
                         <div class="form-group">
                             &nbsp<label for="subject">Subject : </label>
                             <asp:TextBox ID="TextBoxSubject" ReadOnly="true" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                         </div>
                        &nbsp
                         <div class="form-group">
                             &nbsp<label for="Message">Message : </label>
                             <asp:TextBox ID="TextBoxMessage" ReadOnly="true" CssClass="form-control item input-group" TextMode="MultiLine" Rows="10" type="text" runat="server"></asp:TextBox>
                         </div>
                        &nbsp
                        &nbsp<asp:Button ID="ButtonClose" CssClass="btn btn-primary btn-block" runat="server" Text="Return" OnClick="ButtonClose_Click" />&nbsp
                    </asp:View>
                </asp:MultiView>

            </div>
        </section>
    </main>
</asp:Content>
