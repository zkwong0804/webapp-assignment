Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Coupon")>
Partial Public Class Coupon
    Public Sub New()
        Orders = New HashSet(Of Order)()
    End Sub

    Public Property id As Integer

    Public Property name As String

    Public Property description As String

    Public Property isFreeShipping As Boolean?

    Public Property discountRate As Decimal?

    Public Property product As Integer?

    Public Property category As Integer?

    Public Property available As Boolean?

    Public Overridable Property Orders As ICollection(Of Order)
End Class
