Public Class OwnerProduct
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lbtAdd_Click() Handles lbtAdd.Click
        togglePanels(True, False, False)
    End Sub

    Protected Sub lbtUpdate_Click() Handles lbtUpdate.Click
        togglePanels(False, True, False)
    End Sub

    Protected Sub lbtRemove_Click() Handles lbtRemove.Click
        togglePanels(False, False, True)
    End Sub

    Protected Sub togglePanels(ByVal add As Boolean, ByVal update As Boolean, ByVal remove As Boolean)
        pnlAdd.Visible = add
        pnlUpdate.Visible = update
        pnlRemove.Visible = remove
    End Sub
End Class