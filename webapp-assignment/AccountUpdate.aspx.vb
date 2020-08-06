Public Class AccountUpdate
    Inherits System.Web.UI.Page
    Dim dbCtx As New AssignmentDbContext()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (IsNothing(Session("rvEmail")) And IsNothing(Session("rvPass"))) Or IsNothing("user") Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Not IsNothing(Session("rvEmail")) Then
                lblAccount.Text = "Please fill in the following field to complete your account"
                pnlDob.Visible = True
                tbxEmail.Text = Session("rvEmail")
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click() Handles btnUpdate.Click
        If Not IsNothing(Session("rvEmail")) Then
            Dim newUser As New User()
            Dim newMember As New Member()
            newUser.name = tbxName.Text
            newUser.email = Session("rvEmail")
            newUser.password = Session("rvPass")
            dbCtx.Users.Add(newUser)
            dbCtx.SaveChanges()

            newMember.address = tbxAddress.Text
            newMember.contact = tbxContact.Text
            newMember.dob = calDob.SelectedDate
            newMember.joinedDate = Date.Now
            newMember.userId = dbCtx.Users.Where(Function(e) e.email = newUser.email).SingleOrDefault().id
            dbCtx.Members.Add(newMember)
            dbCtx.SaveChanges()

            Response.Redirect("CreateAccountSuccess.aspx")
        End If

        lblUpdateMessage.Text = "<p>Update success!!</p>"
    End Sub

End Class