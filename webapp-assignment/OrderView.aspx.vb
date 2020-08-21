Imports System.Web.ModelBinding
Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types

Public Class OrderView
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("userType")) Then
            Response.Redirect("AccessDenied.aspx")
        End If

        If Not Page.IsPostBack Then
            fvOrder.DataBind()
        End If
    End Sub

    Private Sub OrderView_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If IsNothing(Session("userType")) Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Session("userType").ToString() = "owner" Then
                Page.MasterPageFile = "~/Owner.Master"
            End If
        End If
    End Sub

    Protected Function GetCouponCode(ByVal cID As Integer) As String
        Dim c As Coupon = dbCtx.Coupons.Where(Function(f) f.id = cID).SingleOrDefault()
        Return If(IsNothing(c), "No coupon", c.name).ToString()
    End Function

    Protected Sub btnEdit_Command(sender As Object, e As CommandEventArgs)
        fvOrder.ChangeMode(FormViewMode.Edit)
    End Sub

    Protected Sub btnUpdate_Command(sender As Object, e As CommandEventArgs)
        Dim oid As Integer = Request.QueryString.Get("id")
        Dim order As Order = dbCtx.Orders.Where(Function(f) f.id = oid).SingleOrDefault()
        order.status = CType(fvOrder.FindControl("ddlStatus"), DropDownList).SelectedValue
        order.isShipped = CType(fvOrder.FindControl("cbxIsShipped"), CheckBox).Checked
        If order.isShipped And order.status <> "completed" Then
            order.status = "shipping"
        End If
        order.shippingAddress = CType(fvOrder.FindControl("tbxShippingAddress"), TextBox).Text
        Debug.WriteLine(CType(fvOrder.FindControl("tbxShippingAddress"), TextBox).Text)
        dbCtx.SaveChanges()
        fvOrder.ChangeMode(FormViewMode.ReadOnly)

        'Send SMS notification
        If order.status = "shipping" Then
            Const accountSid = "ACee716e89b0b331e99531f9c24102e2ee"
            Const authToken = "a9b2d4e1664b69f65faf7d0f4721ff7c"
            TwilioClient.Init(accountSid, authToken)

            Dim toNumber = New PhoneNumber(String.Format("+{0}", order.Member1.contact))
            Dim message = MessageResource.Create(
                toNumber, from:=New PhoneNumber("+12027988913"),
                body:=String.Format("Your order[{0}] has been shipped!", order.id))

            Console.WriteLine(message.Sid)
        End If

    End Sub

    Protected Sub btnCancel_Command(sender As Object, e As CommandEventArgs)
        fvOrder.ChangeMode(FormViewMode.ReadOnly)
    End Sub

    ' The id parameter should match the DataKeyNames value set on the control
    ' or be decorated with a value provider attribute, e.g. <QueryString>ByVal id as Integer
    Public Function fvOrder_GetItem(<QueryString> ByVal id As Integer) As webapp_assignment.Order
        Return dbCtx.Orders.Where(Function(f) f.id = id).SingleOrDefault()
    End Function

    ' The id parameter name should match the DataKeyNames value set on the control
    Public Sub fvOrder_UpdateItem(ByVal id As Integer)
        Dim item As webapp_assignment.Order = Nothing
        ' Load the item here, e.g. item = MyDataLayer.Find(id)
        If item Is Nothing Then
            ' The item wasn't found
            ModelState.AddModelError("", String.Format("Item with id {0} was not found", id))
            Return
        End If
        TryUpdateModel(item)
        If ModelState.IsValid Then
            ' Save changes here, e.g. MyDataLayer.SaveChanges()

        End If
    End Sub
End Class