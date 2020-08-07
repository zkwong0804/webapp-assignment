<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="EmailFail.aspx.vb" Inherits="webapp_assignment.EmailFail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Label ID="lblMessage" runat="server" Text="Fail to send email!"></asp:Label>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
