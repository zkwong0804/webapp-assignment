Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Coupon")>
Partial Public Class Coupon
    Public Property id As Integer

    Public Property promotionID As Integer

    Public Property availableGrantAmt As Integer?

    Public Overridable Property Promotion As Promotion
End Class
