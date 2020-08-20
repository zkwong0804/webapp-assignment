

Public Class Product1
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()
    Private _product As Product
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Request.QueryString.Get("id")
        SelectedProduct = dbCtx.Products.Where(Function(f) f.id = id).SingleOrDefault()
        If IsNothing(SelectedProduct) Then
            Response.Redirect("ProductNotFound2.aspx")
        End If

        If Not Page.IsPostBack Then
            lvPostedcomments.DataBind()
        End If
    End Sub

    Public Property SelectedProduct As Product
        Get
            Return Me._product
        End Get
        Set(value As Product)
            Me._product = value
        End Set
    End Property

    Public Sub lbtAddCart_Click() Handles lbtAddCart.Click
        If Page.IsValid Then
            Master.AddToCart(SelectedProduct, Integer.Parse(tbxQuantity.Text))
            Response.Redirect("ViewAll.aspx")
        End If
    End Sub

    Public Sub lbtBuyNow_Click() Handles lbtBuyNow.Click
        If Page.IsValid Then
            Master.AddToCart(SelectedProduct, Integer.Parse(tbxQuantity.Text))
            Response.Redirect("Checkout.aspx")
        End If
    End Sub

    Protected Sub cvQuantity_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Try
            Dim q As Integer = Integer.Parse(args.Value)
            If q < 0 Then
                args.IsValid = False
            End If
        Catch ex As FormatException
            args.IsValid = False
        End Try
    End Sub

    Protected Sub btnPost_Click(sender As Object, e As EventArgs)
        If Page.IsValid Then
            'save image to local file first
            Dim imageLoc As String = String.Format("~/images/Comments/{0}", fupReview.PostedFile.FileName)
            fupReview.SaveAs(Server.MapPath(imageLoc))


            'star create and store new comment object
            Dim comment As New Comment()
            comment.rate = ddlRate.SelectedValue
            comment.comment1 = tbxReview.Text
            comment.pictureLoc = imageLoc
            comment.product = CInt(Request.QueryString.Get("id"))
            comment.creator = CInt(CType(Session("member"), Member).id)

            dbCtx.Comments.Add(comment)
            dbCtx.SaveChanges()
            Response.Redirect("Default.aspx")
        End If
    End Sub


    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String
    Public Function lvPostedcomments_GetData() As IQueryable(Of webapp_assignment.Comment)
        Dim _id As Integer = Request.QueryString.Get("id")
        Return dbCtx.Comments.Where(Function(f) f.product = _id)
    End Function

    Protected Function GetTotalReviews() As Integer
        Dim _id As Integer = Request.QueryString.Get("id")
        Return dbCtx.Comments.Where(Function(f) f.product = _id).Count
    End Function

    Protected Function HasBoughtBefore() As Boolean
        If IsNothing(Session("userType")) Then
            Return False
        End If
        Dim _id As Integer = Request.QueryString.Get("id")
        Dim _mid As Integer = CType(Session("member"), Member).id
        Dim _po As Product_Order = dbCtx.Product_Order.Where(Function(f) f.product = _id And f.Order.member = _mid).SingleOrDefault()

        Return Not IsNothing(_po)
    End Function
End Class