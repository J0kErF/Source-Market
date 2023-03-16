<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="SourceMarket.USERAREA.DataManager" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h3 class="text-dark mb-4">Data Manager</h3>
        <div class="card shadow">
            <div class="card-header py-3">
                <div class="row">
                    <div class="col-sm-10">
                        <asp:DropDownList ID="DropDownListTableName" runat="server" CssClass="form-control form-control-sm custom-select custom-select-sm"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <asp:LinkButton ID="LBSELECT" runat="server" CssClass="btn btn-primary" OnClick="LBSELECT_Click"><i class="fa fa-search"></i></asp:LinkButton>

                    </div>
                </div>
            </div>
            <div class="card-body">
               
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Panel ID="panel_GET" runat="server">
                            <label class="label col-form-label-sm">ID  : &nbsp</label>
                            <asp:TextBox ID="TextBoxID" runat="server" CssClass="input form-control input-groubt"></asp:TextBox>
                            <asp:Button ID="ButtonGetByID" runat="server" CssClass="btn btn-primary" Text=" Get " OnClick="ButtonGetByID_Click" />
                            <br />
                        </asp:Panel>
                        <asp:MultiView ID="DATAVIEW" runat="server">
                            <asp:View ID="view1" runat="server">


                                <asp:Panel ID="EditPanel" runat="server">
                                </asp:Panel>
                                    <asp:Button ID="BTNdelete" OnClick="BTNdelete_Click" runat="server" Text=" Delete " CssClass="btn btn-primary" />

                            </asp:View>
                            <asp:View ID="view2" runat="server">

                                <div id="Data" runat="server" class="table-responsive table mt-2" role="grid">
                                    <!---------- GridView ----------->
                                    <asp:GridView ID="GridViewAdmin" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                        </Columns>

                                    </asp:GridView>

                                </div>

                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>