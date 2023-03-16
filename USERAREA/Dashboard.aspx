<%@ Page Title="" Language="C#" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SourceMarket.USERAREA.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="d-sm-flex justify-content-between align-items-center mb-4">
            <h3 class="text-dark mb-0">Dashboard</h3>
            <!-- <a id="generatereportbtn" runat="server" class="btn btn-primary btn-sm d-none d-sm-inline-block" role="button" onclick="GenerateReport_Click"><i class="fas fa-download fa-sm text-white-50"></i>&nbsp;Generate Report</a> -->
        </div>
        <div class="row">
            <div class="col-md-8 col-xl-4 mb-4">
                <div class="card shadow border-left-primary py-2">
                    <div class="card-body">
                        <div class="row align-items-center no-gutters">
                            <div class="col mr-2">
                                <div class="text-uppercase text-primary font-weight-bold text-xs mb-1"><span>Total Deals</span></div>
                                <div class="text-dark font-weight-bold h5 mb-0">
                                    <asp:Label ID="Dealslbl" runat="server"></asp:Label>
                                </div>

                            </div>
                            <div class="col-auto"><i class="fas fa-calendar fa-2x text-gray-300"></i></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8 col-xl-4 mb-4">
                <div class="card shadow border-left-success py-2">
                    <div class="card-body">
                        <div class="row align-items-center no-gutters">
                            <div class="col mr-2">
                                <div class="text-uppercase text-success font-weight-bold text-xs mb-1"><span>Total Earnings</span></div>
                                <div class="text-dark font-weight-bold h5 mb-0">
                                    <asp:Label ID="Totallbl" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto"><i class="fas fa-dollar-sign fa-2x text-gray-300"></i></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8 col-xl-4 mb-4">
                <div class="card shadow border-left-warning py-2">
                    <div class="card-body">
                        <div class="row align-items-center no-gutters">
                            <div class="col mr-2">
                                <div class="text-uppercase text-warning font-weight-bold text-xs mb-1"><span>Total Products</span></div>
                                <div class="text-dark font-weight-bold h5 mb-0">
                                    <asp:Label ID="Productslbl" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto"><i class="fas fa-code fa-2x text-gray-300"></i></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <asp:Label Style="width: 100%" ID="Statuslbl" runat="server"></asp:Label>
        </div>
        <div class="row" style="width: 100%; padding-left: 11px;">
            <div class="col">
                <asp:LinkButton ID="CreateProductsLB" runat="server" OnClick="CreateProductsLB_Click">
                <div class="col-lg-12 mb-4">
                    <div class="card text-white bg-secondary shadow">
                        <div class="card-body">
                            <p class="m-0">Create new product</p>
                        </div>
                    </div>
                </div>
                    </asp:LinkButton>
            </div>

            <div class="col">
                <div class="col-lg-12 mb-4">
                    <asp:LinkButton ID="MyProductsLB" runat="server" OnClick="MyProductsLB_Click">
                    <div class="card text-white bg-secondary shadow">
                        <div class="card-body">
                            <p class="m-0">My Products</p>
                        </div>
                    </div>
                        </asp:LinkButton>
                </div>
            </div>


        </div>
        <div class="row" style="width: 100%; padding-left: 11px;">
            <div class="col">
                <asp:LinkButton ID="LinkButtonMyLibrary" runat="server" OnClick="LinkButtonMyLibrary_Click">
                <div class="col-lg-12 mb-4">
                    <div class="card text-white bg-secondary shadow">
                        <div class="card-body">
                            <p class="m-0">My Library</p>
                        </div>
                    </div>
                </div>
                    </asp:LinkButton>
            </div>
            <div class="col">
                <div class="col-lg-12 mb-4">
                    <asp:LinkButton ID="LinkButtonMyReviews" runat="server" OnClick="LinkButtonMyReviews_Click">
                    <div class="card text-white bg-secondary shadow">
                        <div class="card-body">
                            <p class="m-0">My Reviews</p>
                        </div>
                    </div>
                        </asp:LinkButton>
                </div>
            </div>
            <div class="col">
                <div class="col-lg-12 mb-4">
                    <asp:LinkButton ID="LinkButtonDeals" runat="server" OnClick="LinkButtonDeals_Click">
                    <div class="card text-white bg-secondary shadow">
                        <div class="card-body">
                            <p class="m-0">My Deals</p>
                        </div>
                    </div>
                        </asp:LinkButton>
                </div>
            </div>
            <div class="col">
                <div class="col-lg-12 mb-4">
                    <asp:LinkButton ID="LinkButtonCurrency" runat="server" OnClick="LinkButtonCurrency_Click">
                    <div class="card text-white bg-secondary shadow">
                        <div class="card-body">
                            <p class="m-0">Currency Convertor</p>
                        </div>
                    </div>
                        </asp:LinkButton>
                </div>
            </div>

        </div>
        <asp:Panel ID="PanelAdminToolsLinks" runat="server" Visible="false">
            <div class="row" style="width: 100%; padding-left: 11px;">
                <div class="col">
                    <div class="col-lg-12 mb-4">
                         <asp:LinkButton ID="LinkButtonPendings" runat="server" OnClick="LinkButtonPendings_Click">
                        <div class="card text-white bg-primary shadow">
                            <div class="card-body">
                                <p class="m-0">Pendings</p>
                            </div>
                        </div>
                             </asp:LinkButton>
                    </div>
                </div>
                <div class="col">
                    <div class="col-lg-12 mb-4">
                        <asp:LinkButton ID="AddUserLinkButton" runat="server" OnClick="AddUserLinkButton_Click">
                        <div class="card text-white bg-primary shadow">
                            <div class="card-body">
                                <p class="m-0">Add User</p>
                            </div>
                        </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>


</asp:Content>
