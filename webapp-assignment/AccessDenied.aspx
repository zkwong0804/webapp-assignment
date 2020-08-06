<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="AccessDenied.aspx.vb" Inherits="webapp_assignment.AccessDenied" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <asp:Label ID="lblMessage" runat="server" Text="You are not suspossed to be in here!"></asp:Label>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
