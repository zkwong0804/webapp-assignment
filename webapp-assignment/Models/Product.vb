Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Product")>
Partial Public Class Product
    Public Sub New()
        Product_Order = New HashSet(Of Product_Order)()
    End Sub

    Public Property id As Integer

    Public Property name As String

    Public Property price As Decimal?

    Public Property amt As Integer?

    Public Property description As String

    Public Property isAvailable As Boolean

    Public Property imageLoc As String

    Public Property category As Integer

    Public Overridable Property Category1 As Category

    Public Overridable Property Product_Order As ICollection(Of Product_Order)
End Class
