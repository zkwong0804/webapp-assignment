<%@ Page Title="" Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/Main.Master" CodeBehind="LoginRegister.aspx.vb" 
    Inherits="webapp_assignment.LoginRegister" %>

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
                                TextMode="Email"></asp:TextBox>
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
                                TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLoginPass"
                                runat="server"
                                ControlToValidate="tbxLoginPass"
                                ErrorMessage="This field should not be empty!"
                                ForeColor="Red"
                                ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button 
                                ID="btnLogin" 
                                runat="server" 
                                CssClass="btn btn-primary py-3 px-5" 
                                Text="Login" 
                                ValidationGroup="login"/>
                        </div>
                    </div>

                </div>

                <div class="col-md-6 order-md-last d-flex">
                    <div class="bg-white p-5 contact-form">
                        <h1>Register</h1>
                        <div class="form-group">
                            <asp:Label ID="lblRegisterMail" 
                                runat="server" 
                                Text="Your Email"></asp:Label>
                            <asp:TextBox ID="tbxRegisterMail" 
                                runat="server" 
                                CssClass="form-control" 
                                TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRegisterMail" 
                                runat="server" 
                                ControlToValidate="tbxRegisterMail" 
                                ErrorMessage="This field should not be empty!" 
                                ForeColor="Red" 
                                ValidationGroup="register"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblRegisterPass1" 
                                runat="server" 
                                Text="Password"></asp:Label>
                            <asp:TextBox ID="tbxRegisterPass1" 
                                runat="server" 
                                CssClass="form-control" 
                                TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRegisterPass1" 
                                runat="server" 
                                ControlToValidate="tbxRegisterPass1" 
                                ErrorMessage="This field should not be empty!" 
                                ForeColor="Red"
                                ValidationGroup="register"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblRegisterPass2" 
                                runat="server" 
                                Text="Re-enter password"></asp:Label>
                            <asp:TextBox ID="tbxRegisterPass2" 
                                runat="server" 
                                CssClass="form-control" 
                                TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRegisterPass2" 
                                runat="server" 
                                ControlToValidate="tbxRegisterPass2" 
                                ErrorMessage="This field should not be empty!" 
                                ForeColor="Red"
                                ValidationGroup="register"></asp:RequiredFieldValidator> <br />
                            <asp:CompareValidator ID="cpvRegisterPass" 
                                runat="server" 
                                ControlToCompare="tbxRegisterPass1" 
                                ControlToValidate="tbxRegisterPass2" 
                                Operator="Equal" 
                                ErrorMessage="Password 1 not equal to password 2!" 
                                Forecolor="Red"
                                ValidationGroup="register">

                            </asp:CompareValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnRegister" 
                                runat="server" 
                                Text="Register now!" 
                                CssClass="btn btn-primary py-3 px-5" 
                                ValidationGroup="register" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>

</asp:Content>
