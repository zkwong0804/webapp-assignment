<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="AccountUpdate.aspx.vb" Inherits="webapp_assignment.AccountUpdate" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="ftco-section contact-section bg-light">
        <div class="container">

            <div class="row block-9">

                <div class="col-md-6 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <h1>Account's info</h1>
                        <asp:Label ID="lblAccount" runat="server" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <asp:Label ID="lblEmail"
                                runat="server"
                                Text="Email: "></asp:Label>
                            <asp:TextBox ID="tbxEmail" 
                                runat="server" 
                                ReadOnly="true" 
                                CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblName"
                                runat="server"
                                Text="Name"></asp:Label>
                            <asp:TextBox ID="tbxName"
                                runat="server"
                                CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblContact"
                                runat="server"
                                Text="Contact"></asp:Label>
                            <asp:TextBox ID="tbxContact"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Phone"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblAddress"
                                runat="server"
                                Text="Address"></asp:Label>
                            <asp:TextBox ID="tbxAddress"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Panel ID="pnlDob" runat="server" Visible="false">
                                <asp:Label ID="lblDob"
                                    runat="server"
                                    Text="Date of birth"></asp:Label>
                                <asp:Calendar ID="calDob" runat="server"></asp:Calendar>
                            </asp:Panel>
                        </div>

                        <div class="form-group">
                            <asp:Button
                                ID="btnUpdate"
                                runat="server"
                                CssClass="btn btn-primary py-3 px-5"
                                Text="Update account" />
                            <asp:Label ID="lblUpdateMessage" runat="server"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
