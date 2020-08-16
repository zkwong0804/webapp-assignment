Public Class Cart
    Private _product As Product
    Private _orderAmt As Integer

    Public Property Product As Product
        Get
            Return Me._product
        End Get
        Set(value As Product)
            Me._product = value
        End Set
    End Property

    Public Property OrderAmt As Integer
        Get
            Return Me._orderAmt
        End Get
        Set(value As Integer)
            Me._orderAmt = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal product As Product, ByVal quantity As Integer)
        Me.Product = product
        Me.OrderAmt = quantity
    End Sub
End Class
