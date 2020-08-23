Public Class contact
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("userType")) Then
            Dim ut As String = Session("userType").ToString()
            If ut = "member" Then
                displayname.Text = CType(Session("member"), Member).User.name
            Else
                displayname.Text = "Customer Support"
            End If

        Else
            displayname.Text = "Anonymus"
        End If
    End Sub

    Private Sub contact_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Not IsNothing(Session("userType")) AndAlso Session("userType").ToString() = "owner" Then
            Page.MasterPageFile = "~/Owner.Master"
        End If
    End Sub
End Class