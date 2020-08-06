Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Order")>
Partial Public Class Order
    Public Sub New()
        Product_Order = New HashSet(Of Product_Order)()
    End Sub

    Public Property id As Integer

    <Column("date", TypeName:="date")>
    Public Property _date As Date?

    Public Property shippingAddress As String

    Public Property isShipped As Boolean?

    Public Property status As String

    Public Property total As Decimal?

    Public Property member As Integer

    Public Property grantedPromotion As Integer

    Public Overridable Property Member1 As Member

    Public Overridable Property Promotion As Promotion

    Public Overridable Property Product_Order As ICollection(Of Product_Order)
End Class
