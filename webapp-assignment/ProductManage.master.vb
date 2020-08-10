Public Class ProductManage
    Inherits System.Web.UI.MasterPage
    Dim dbCtx As New AssignmentDbContext()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim categories = dbCtx.Categories.Where(Function(f) f.id <> 1).ToList()

            If Not IsNothing(categories) And categories.Count > 0 Then
                For Each cat As Category In categories
                    Dim li As New ListItem()
                    li.Text = cat.name
                    li.Value = cat.id
                    ddlCategory.Items.Add(li)
                Next
            Else
                Response.Redirect("InsufficientCategory.aspx")
            End If
        End If
    End Sub

    Protected Sub cuvPrice_Validate(source As Object, args As ServerValidateEventArgs) Handles cuvPrice.ServerValidate
        If String.IsNullOrEmpty(args.Value) Then
            args.IsValid = False
        Else
            Try
                If CDec(args.Value) < 0 Then
                    args.IsValid = False
                End If
            Catch ex As Exception
                args.IsValid = False
            End Try
        End If
    End Sub

    Protected Sub cuvAmt_Validate(source As Object, args As ServerValidateEventArgs) Handles cuvAmt.ServerValidate
        If String.IsNullOrEmpty(args.Value) Then
            args.IsValid = False
        Else
            If CInt(args.Value) < 0 Then
                args.IsValid = False
            End If
        End If
    End Sub

    Public Property Name As String
        Get
            Return tbxName.Text
        End Get
        Set(value As String)
            tbxName.Text = value
        End Set
    End Property

    Public Property Category As Integer
        Get
            Return ddlCategory.SelectedValue
        End Get
        Set(value As Integer)
            ddlCategory.SelectedValue = value
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return Decimal.Parse(tbxPrice.Text)
        End Get
        Set(value As Decimal)
            tbxPrice.Text = value
        End Set
    End Property

    Public Property ImageMessage As String
        Get
            Return lblImageMsg.Text
        End Get
        Set(value As String)
            lblImageMsg.Text = value
        End Set
    End Property

    Public Property Amt As Integer
        Get
            Return CInt(tbxAmt.Text)
        End Get
        Set(value As Integer)
            tbxAmt.Text = value
        End Set
    End Property

    Public Property Desc As String
        Get
            Return tbxDesc.Text
        End Get
        Set(value As String)
            tbxDesc.Text = value
        End Set
    End Property

    Public Sub SetImage(ByVal url As String)
        imgProduct.ImageUrl = url
    End Sub

    Public Function IsHasImage() As Boolean
        Return fupImage.HasFile
    End Function

    Public Function GetUploadImageName() As String
        Return fupImage.PostedFile.FileName
    End Function

    Public Function GetUploadImageLoc() As String
        Return "~/images/Products/" & GetUploadImageName()
    End Function

    Public Sub SaveImage()
        fupImage.SaveAs(Server.MapPath(GetUploadImageLoc()))
    End Sub

    Public Property Available As Boolean
        Get
            Return cbxAvailable.Checked
        End Get
        Set(value As Boolean)
            cbxAvailable.Checked = value
        End Set
    End Property

End Class