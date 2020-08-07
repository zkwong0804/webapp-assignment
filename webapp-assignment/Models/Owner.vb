Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Owner")>
Partial Public Class Owner
    Public Property id As Integer

    Public Property accessLvl As Integer?

    Public Property superior As Integer?

    Public Property userId As Integer

    Public Overridable Property User As User
End Class
