<%@ Page Title="" Language="C#" MasterPageFile="~/FIRST/MasterPageFirst.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SourceMarket.FIRST.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main class="page landing-page">
        <section class="clean-block clean-hero" style="background-image: url(&quot;assets/img/tech/image4.jpg&quot;); color: rgba(9, 162, 255, 0.85);">
            <div class="text">
                <h2>Sell / Buy Apps Source code</h2>
                <p>This site provides you with tools to make it easy to sell or buy apps source code .</p>
                <button class="btn btn-light btn-lg" type="button"><a href="registration.aspx">Register.</a></button>
            </div>
        </section>
        <section class="clean-block features">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">Features</h2>
                </div>
                <div class="row justify-content-center">
                    <div class="col-md-5 feature-box">
                        <i class="icon-star icon"></i>
                        <h4>NO Taxes</h4>
                        <p></p>
                    </div>
                    <div class="col-md-5 feature-box">
                        <i class="icon-pencil icon"></i>
                        <h4>Customizable</h4>
                        <p></p>
                    </div>
                    <div class="col-md-5 feature-box">
                        <i class="icon-screen-smartphone icon"></i>
                        <h4>Responsive</h4>
                    </div>
                    <div class="col-md-5 feature-box">
                        <i class="icon-refresh icon"></i>
                        <h4>Full History</h4>
                    </div>
                </div>
            </div>
        </section>
        <section class="clean-block about-us">
            <div class="container">
                <div class="block-heading">
                    <h2 class="text-info">About Us</h2>
                </div>
                <div class="row justify-content-center">
                    <div class="col-sm-6 col-lg-4">
                        <div class="card clean-card text-center">
                            <div class="card-body info">
                                <h4 class="card-title">Mohammad Yosef</h4>
                                <p class="card-text">student in 12 grade studying at albshaer school ,Computer science and physics specialist.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>

</asp:Content>
