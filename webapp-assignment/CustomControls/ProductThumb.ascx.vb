Public Class ProductThumb
    Inherits System.Web.UI.UserControl
    Private _product As Product
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Property Product As Product
        Get
            Return Me._product
        End Get
        Set(value As Product)
            Me._product = value
        End Set
    End Property


End Class