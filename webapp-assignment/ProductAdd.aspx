<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ProductManage.master" CodeBehind="ProductAdd.aspx.vb" Inherits="webapp_assignment.ProductAdd" %>

<%@ MasterType VirtualPath="~/ProductManage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="btnHolder" runat="server">

    <asp:Button ID="btnAdd" runat="server" Text="Add product" ClientIDMode="Static" CssClass="btn btn-info btn-lg" />
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Send email confirmation</h4>
                </div>
                <div class="modal-body">
                    <p>Do you want notify the new product to all members></p>
                    <asp:Button ID="btnSend" runat="server" Text="Yes" ClientIDMode="Static" OnClick="btnSend_Click" />
                    <asp:Button ID="btnProceed" runat="server" Text="No" ClientIDMode="Static" OnClick="btnProceed_Click" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        $("#btnAdd").click(function (e) {
            e.preventDefault()
        })
    </script>
</asp:Content>
