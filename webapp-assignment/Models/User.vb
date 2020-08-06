Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("User")>
Partial Public Class User
    Public Sub New()
        Members = New HashSet(Of Member)()
        Owners = New HashSet(Of Owner)()
    End Sub

    Public Property id As Integer

    Public Property name As String

    Public Property email As String

    Public Property password As String

    Public Overridable Property Members As ICollection(Of Member)

    Public Overridable Property Owners As ICollection(Of Owner)
End Class
