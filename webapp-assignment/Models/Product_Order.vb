Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Product_Order
    Public Property id As Integer

    Public Property product As Integer

    Public Property orderid As Integer

    Public Property price As Decimal

    Public Overridable Property Order As Order

    Public Overridable Property Product1 As Product
End Class
