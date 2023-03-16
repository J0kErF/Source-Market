<%@ Page Title="" Language="C#" validateRequest="false" MasterPageFile="~/USERAREA/MasterUSERAREA.Master" AutoEventWireup="true" CodeBehind="NEProduct.aspx.cs" Inherits="SourceMarket.USERAREA.NEProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="md-stepper-horizontal orange">

                        <div class="md-step active done">
                            <asp:LinkButton ID="LinkButton0" OnClick="LinkButton0_Click" runat="server">
                            <div class="md-step-circle grey"><span>1</span></div>
                            <div class="md-step-title"><span><strong>Basic info</strong></span></div>
                            <div class="md-step-bar-left"></div>
                            <div class="md-step-bar-right"></div>
                            </asp:LinkButton>
                        </div>
                        <div class="md-step active editable">
                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">
                            <div class="md-step-circle grey"><span>2</span></div>
                            <div class="md-step-title"><span><strong>info expand</strong></span></div>
                            <div class="md-step-bar-left"></div>
                            <div class="md-step-bar-right"></div>
                            </asp:LinkButton>
                        </div>
                        <div class="md-step active currency">
                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server">
                            <div class="md-step-circle orange"><span>2</span></div>
                            <div class="md-step-title">
                                <span>Payment<br>
                                </span>
                            </div>
                            <div class="md-step-bar-left"></div>
                            <div class="md-step-bar-right"></div>
                            </asp:LinkButton>
                        </div>

                        <div class="md-step active thanks">
                            <asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" runat="server">
                                <div class="md-step-circle green"><span>2</span></div>
                                <div class="md-step-title">
                                    <span>Finish<br />
                                    </span>
                                </div>
                                <div class="md-step-bar-left"></div>
                                <div class="md-step-bar-right"></div>
                            </asp:LinkButton>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />

        <center>
        <asp:MultiView ID="MultiViewSteps" runat="server">
            <asp:View ID="View1" runat="server">
            
                <asp:FileUpload ID="FileUploadImage" runat="server" style="display:none;"/>
                <asp:LinkButton ID="ProductImage" runat="server"><asp:Image ID="ImagePro" runat="server" Width="500px" Height="450px" CssClass="img-profile" BackColor="White" ImageAlign="Middle" ImageUrl="~/media/DOWNLOADIMAGEBUTTON.png" /> </asp:LinkButton>
                <br />
                <asp:Button ID="UploadToServerBTN" runat="server" CssClass="btn btn-primary" Text="Upload to server" OnClick="UploadToServerBTN_Click"/>
                <br />
                <div class="form-group">
                    <br />
                    <label for="title">Title</label>
                    <asp:TextBox ID="TitleTextBox" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                    <br />
                    <label for="title">Information (subtitle)</label>
                    <asp:TextBox ID="TextBoxInfo" TextMode="MultiLine" Rows="3" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                    <label for="title">Description</label>
                    <asp:TextBox ID="TextBoxDescription" TextMode="MultiLine" Rows="5" CssClass="form-control item input-group" type="text" runat="server"></asp:TextBox>
                </div>
                <br />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="form-row">
                    <div class="col-sm-2 form-group"><label class="label col-form-label">Specifications</label></div>
                    <div class="col-sm-3 form-group"><asp:TextBox ID="TextBoxName" PlaceHolder="Name" CssClass="form-control" type="text" runat="server"></asp:TextBox></div>
                    <div class="col-sm-3 form-group"><asp:TextBox ID="TextBoxValue" PlaceHolder="Value" CssClass="form-control" type="text" runat="server"></asp:TextBox></div>
                    <div class="col-sm-2 form-group"><asp:Button ID="ButtonAdd" CssClass="btn btn-primary" Text="        Add        " runat="server" OnClick="ButtonAdd_Click"/></div>
                    <div class="col-sm-2 form-group"><asp:Button ID="ButtonClear" CssClass="btn btn-primary" Text="        Clear        " runat="server" OnClick="ButtonClear_Click"/></div>
                </div>

                <div class="form-row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        
                        <table class="table dataTable my-0" style="text-align:center;">
                            <asp:Label ID="LabelSpec" runat="server" Text=""></asp:Label>
                        </table>
                        
                    </div> 
                </div>
                <div class="form-row">
                    
                    <div class="col-sm-1 form-group"><label class="label col-form-label">OS</label></div>
                    <div class="col-sm-2 form-group"><asp:TextBox ID="TextBoxOS" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-sm-1 form-group"><label class="label col-form-label">Code Language (Main)</label></div>
                    <div class="col-sm-2 form-group"><asp:TextBox ID="TextBoxCL" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-sm-1 form-group"><label class="label col-form-label">Category</label></div>
                    <div class="col-sm-2 form-group"><asp:TextBox ID="TextBoxC" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-sm-1 form-group"><label class="label col-form-label">Ver</label></div>
                    <div class="col-sm-1 form-group"><asp:TextBox ID="TextBoxVer" runat="server" CssClass="form-control"></asp:TextBox></div>
                    
                </div>
                <div class="form-row">
                    <div class="col-sm-12" >
                        <asp:FileUpload ID="FileUploadProj" runat="server" style="display:none;"/>
                <asp:LinkButton ID="LinkButtonProj" runat="server"><asp:Image ID="ImageProj" runat="server" Width="500px" Height="400px" CssClass="img-profile" BackColor="White" ImageAlign="Middle" ImageUrl="~/media/UPLOADPRODUCTSOURCEIMAGEBUTTON.png" /> </asp:LinkButton>
                <br />
                <asp:Button ID="ButtonUploadProj" runat="server" CssClass="btn btn-primary" OnClick="ButtonUploadProj_Click" Text="Upload to server" />
                
                <br />
                        <asp:LinkButton ID="projLinkButton" OnClick="projLinkButton_Click" runat="server" Visible="false" ></asp:LinkButton>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="row">
                <div class="col-sm-6">
                    <div class="form-row">
                        <div class="col-sm-2 form-group"><label class="label col-form-label">PRICE ($)</label></div>
                        <div class="col-sm-2 form-group"><asp:TextBox ID="TextBoxPrice" runat="server" CssClass="form-control"></asp:TextBox></div>
                        
                    </div>
                    
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-1">

                        </div>
                        <div class="col-sm-4">
                            By clicking finish that means you are accepting our <a href="../FIRST/Policy.aspx">Policy</a> and our <a href="../media/TERMS OF USE.docx" target="_blank">Terms of use</a>
                        </div>
                    </div>
                </div>
                    </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
               
                <asp:DropDownList Visible="false" ID="DDL" runat="server" >
                                            
                                        </asp:DropDownList>
                 
                    <asp:Panel ID="panelNew" runat="server">
                        <div class="row" style="text-align:center;">
                            <div class="col-sm-3">
                            </div>
                            <center>
                            <div class="col-sm-8">
                        
                                <div class="row">
                                    <h2>
                                        <a class="card-title" style="text-align:center; color:limegreen;">The Product Added Successfully <i class="fa fa-check"></i></a>
                                    </h2>
                                </div>
                        
                                <div class="row" style="text-align:center;">
                                    <h6>&nbsp&nbsp&nbsp&nbsp&nbsp You can see the product by clicking<asp:LinkButton ID="LBPI" runat="server" Text=" Here." OnClick="LBPI_Click"></asp:LinkButton></h6>
                                </div>
                            </div>
                            </center>
                        </div>
                    </asp:Panel>
                <asp:Panel ID="PanelEdit" runat="server">
                    <div class="row">
                        
                        <asp:Label Width="5%" ID="lbl0" runat="server"></asp:Label>
                            <asp:LinkButton Width="40%" ID="DeleteLinkButton" OnClick="DeleteLinkButton_Click" CssClass="btn btn-primary" runat="server">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<i class="fa fa-trash-o"></i>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:LinkButton>
        
                            <asp:Label Width="10%" ID="lbl1" runat="server"></asp:Label>
                        
                            <asp:LinkButton Width="40%" ID="UpdateLinkButton" OnClick="UpdateLinkButton_Click" CssClass="btn btn-primary" runat="server">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<i class="fa fa-save"></i>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:LinkButton>
                        <asp:Label Width="5%" ID="lbl2" runat="server"></asp:Label>
                        
                    </div>
                    <div class="row">
                       <asp:Label Width="5%" ID="lbl3" runat="server"></asp:Label>
                        <asp:Label Style="width: 90%" ID="Statuslbl" runat="server"></asp:Label>
                        <asp:Label Width="5%" ID="lbl4" runat="server"></asp:Label>
                    </div>
                    <div class="row"></div>
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
        </center>
    </section>
</asp:Content>
