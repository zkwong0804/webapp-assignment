Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Comment")>
Partial Public Class Comment
    Public Property id As Integer

    Public Property rate As Integer?

    <Column("comment")>
    Public Property comment1 As String

    Public Property pictureLoc As String

    Public Property creator As Integer

    Public Property product As Integer?

    Public Overridable Property Member As Member

    Public Overridable Property Product1 As Product
End Class
