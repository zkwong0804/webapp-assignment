<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="OwnerLogin.aspx.vb" Inherits="webapp_assignment.OwnerLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section contact-section bg-light">
        <div class="container">

            <div class="row block-9">

                <div class="col-md-6 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <h1>Login</h1>
                        <div class="form-group">
                            <asp:Label ID="lblLoginMail"
                                runat="server"
                                Text="Login Email"></asp:Label>
                            <asp:TextBox ID="tbxLoginMail"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Email">tommy04081996@1utar.my</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLoginMail"
                                runat="server"
                                ControlToValidate="tbxLoginMail"
                                ErrorMessage="This field should not be empty!"
                                ForeColor="Red"
                                ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblLoginPass"
                                runat="server"
                                Text="Password"></asp:Label>
                            <asp:TextBox ID="tbxLoginPass"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Password">adminzhenkai</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLoginPass"
                                runat="server"
                                ControlToValidate="tbxLoginPass"
                                ErrorMessage="This field should not be empty!"
                                ForeColor="Red"
                                ValidationGroup="login"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblLoginMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Button
                                ID="btnLogin"
                                runat="server"
                                CssClass="btn btn-primary py-3 px-5"
                                Text="Login"
                                ValidationGroup="login" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsHolder" runat="server">
</asp:Content>
