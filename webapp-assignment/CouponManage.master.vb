Public Class CouponManage
    Inherits System.Web.UI.MasterPage
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cvDiscount_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Try
            Dim rate As Decimal = Decimal.Parse(args.Value)
            If rate < 0 Or rate > 100 Then
                args.IsValid = False
            End If
        Catch ex As Exception
            args.IsValid = False
        End Try
    End Sub

    Public Property Name As String
        Get
            Return tbxName.Text
        End Get
        Set(value As String)
            tbxName.Text = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return tbxDesc.Text
        End Get
        Set(value As String)
            tbxDesc.Text = value
        End Set
    End Property

    Public Property FreeShipping As Boolean
        Get
            Return cbxFreeShipping.Checked
        End Get
        Set(value As Boolean)
            cbxFreeShipping.Checked = value
        End Set
    End Property

    Public Property DiscountRate As Decimal
        Get
            Return Decimal.Parse(tbxDiscount.Text)
        End Get
        Set(value As Decimal)
            tbxDiscount.Text = value.ToString()
        End Set
    End Property

    Public Property Product As Integer
        Get
            Return ddlProduct.SelectedValue
        End Get
        Set(value As Integer)
            ddlProduct.Items.FindByValue(value.ToString()).Selected = True
        End Set
    End Property

    Public Property Category As Integer
        Get
            Return ddlCategory.SelectedValue
        End Get
        Set(value As Integer)
            ddlCategory.Items.FindByValue(value.ToString()).Selected = True
        End Set
    End Property

    Public Property Available As Boolean
        Get
            Return cbxAvailable.Checked
        End Get
        Set(value As Boolean)
            cbxAvailable.Checked = value
        End Set
    End Property

    Public Function GetCoupon() As Coupon
        Dim coupon As New Coupon()
        coupon.available = Me.Available
        If Me.Category = -1 Then
            coupon.category = Nothing
        Else
            coupon.category = Me.Category
        End If

        If Me.Product = -1 Then
            coupon.product = Nothing
        Else
            coupon.product = Me.Product
        End If
        coupon.description = Me.Description
        coupon.discountRate = Me.DiscountRate
        coupon.isFreeShipping = Me.FreeShipping
        coupon.name = Me.Name

        Return coupon

    End Function

    Public Sub SetCoupon(ByVal coupon As Coupon)
        Me.Available = coupon.available
        If IsNothing(coupon.category) Then
            Me.Category = -1
        Else
            Me.Category = coupon.category
        End If

        If IsNothing(coupon.product) Then
            Me.Product = -1
        Else
            Me.Product = coupon.product
        End If

        Me.Description = coupon.description
        Me.DiscountRate = coupon.discountRate
        Me.FreeShipping = coupon.isFreeShipping
        Me.Name = coupon.name
    End Sub

    Private Sub CouponManage_Init(sender As Object, e As EventArgs) Handles Me.Init
        ddlCategory.DataSource = dbCtx.Categories.ToList()
        ddlCategory.DataTextField = "name"
        ddlCategory.DataValueField = "id"

        ddlProduct.DataSource = dbCtx.Products.ToList()
        ddlProduct.DataTextField = "name"
        ddlProduct.DataValueField = "id"

        ddlCategory.DataBind()
        ddlProduct.DataBind()
    End Sub
End Class