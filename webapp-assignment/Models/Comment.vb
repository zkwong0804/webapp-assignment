Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Comment")>
Partial Public Class Comment
    Public Sub New()
        Comment11 = New HashSet(Of Comment)()
    End Sub

    Public Property id As Integer

    Public Property rate As Integer?

    <Column("comment")>
    Public Property comment1 As String

    Public Property pictureLoc As String

    Public Property creator As Integer

    Public Property replyTo As Integer

    Public Overridable Property Member As Member

    Public Overridable Property Comment11 As ICollection(Of Comment)

    Public Overridable Property Comment2 As Comment
End Class
