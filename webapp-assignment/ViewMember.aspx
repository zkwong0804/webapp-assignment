<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Owner.Master" CodeBehind="ViewMember.aspx.vb" Inherits="webapp_assignment.ViewMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">
            <div class="row block-9">
                <div class="col-md-12 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <table class="table table-sm table-hover">
                            <tr>
                                <td>ID: </td>
                                <td><%= SelectedMember.id %></td>
                            </tr>
                            <tr>
                                <td>Name: </td>
                                <td><%= SelectedMember.User.name %></td>
                            </tr>
                            <tr>
                                <td>Email: </td>
                                <td><%= SelectedMember.User.email %></td>
                            </tr>
                            <tr>
                                <td>Contact: </td>
                                <td><%= SelectedMember.contact %></td>
                            </tr>
                            <tr>
                                <td>Address: </td>
                                <td><%= SelectedMember.address %></td>
                            </tr>
                            <tr>
                                <td>Date of birth: </td>
                                <td><%= SelectedMember.dob %></td>
                            </tr>
                            <tr>
                                <td>Joined date: </td>
                                <td><%= SelectedMember.joinedDate %></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
