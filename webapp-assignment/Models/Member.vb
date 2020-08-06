Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Member")>
Partial Public Class Member
    Public Sub New()
        Comments = New HashSet(Of Comment)()
        Orders = New HashSet(Of Order)()
    End Sub

    Public Property id As Integer

    Public Property contact As String

    Public Property address As String

    <Column(TypeName:="date")>
    Public Property dob As Date?

    <Column(TypeName:="date")>
    Public Property joinedDate As Date?

    Public Property userId As Integer

    Public Overridable Property Comments As ICollection(Of Comment)

    Public Overridable Property User As User

    Public Overridable Property Orders As ICollection(Of Order)
End Class
