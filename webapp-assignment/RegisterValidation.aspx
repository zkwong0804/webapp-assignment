<%@ Page Title="" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Main.Master" CodeBehind="RegisterValidation.aspx.vb"
    Inherits="webapp_assignment.RegisterValidation" Async="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:Panel ID="pnlValidate" 
                        runat="server" 
                        Visible="false">

                        <asp:TextBox ID="tbxValidate"
                            runat="server"></asp:TextBox>
                        <asp:Button ID="btnValidate" 
                            runat="server"
                            Text="Validate"/>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
