Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Category")>
Partial Public Class Category
    Public Sub New()
        Category11 = New HashSet(Of Category)()
        Products = New HashSet(Of Product)()
    End Sub

    Public Property id As Integer

    Public Property name As String

    Public Property isAvailable As Boolean

    <Column("category")>
    Public Property category1 As Integer

    Public Overridable Property Category11 As ICollection(Of Category)

    Public Overridable Property Category2 As Category

    Public Overridable Property Products As ICollection(Of Product)
End Class
