Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Promotion")>
Partial Public Class Promotion
    Public Sub New()
        Campaigns = New HashSet(Of Campaign)()
        Coupons = New HashSet(Of Coupon)()
        Orders = New HashSet(Of Order)()
    End Sub

    Public Property id As Integer

    Public Property name As String

    Public Property desc As String

    Public Property isFreeShipping As Boolean?

    Public Property discountRate As Decimal?

    Public Property product As Integer?

    Public Property category As Integer?

    Public Overridable Property Campaigns As ICollection(Of Campaign)

    Public Overridable Property Coupons As ICollection(Of Coupon)

    Public Overridable Property Orders As ICollection(Of Order)
End Class
