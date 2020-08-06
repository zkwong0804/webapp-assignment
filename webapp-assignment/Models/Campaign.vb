Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Campaign")>
Partial Public Class Campaign
    Public Property id As Integer

    Public Property promotionID As Integer

    <Column(TypeName:="date")>
    Public Property startDate As Date?

    <Column(TypeName:="date")>
    Public Property endDate As Date?

    Public Overridable Property Promotion As Promotion
End Class
