Public Class AccountUpdate
    Inherits System.Web.UI.Page
    Shared dbCtx As New AssignmentDbContext()
    Shared member As Member

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If IsNothing(Session("rvEmail")) And IsNothing(Session("member")) Then
                Response.Redirect("AccessDenied.aspx")
            Else
                If Not IsNothing(Session("rvEmail")) Then
                    lblAccount.Text = "Please fill in the following field to complete your account"
                    pnlDob.Visible = True
                    tbxEmail.Text = Session("rvEmail")
                ElseIf Session("userType") <> "member" Then
                    Response.Redirect("AccessDenied.aspx")
                Else
                    member = Session("member")
                    tbxEmail.Text = member.User.email
                    tbxName.Text = member.User.name
                    tbxAddress.Text = member.address
                    tbxContact.Text = member.contact
                End If
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click() Handles btnUpdate.Click
        If Page.IsValid Then
            If Not IsNothing(Session("rvEmail")) Then
                Try
                    Dim dateVal As Date = DateTime.ParseExact(tbxDob.Text, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    If validateDate(dateVal) Then
                        lblDobValidate.Visible = False
                        lblUpdateMessage.Text = "<p>Updating the account...</p>"
                        Dim newUser As New User()
                        Dim newMember As New Member()
                        newUser.name = tbxName.Text
                        newUser.email = Session("rvEmail")
                        newUser.password = Session("rvPass")
                        dbCtx.Users.Add(newUser)
                        dbCtx.SaveChanges()

                        newMember.address = tbxAddress.Text
                        newMember.contact = tbxContact.Text
                        newMember.dob = Convert.ToDateTime(tbxDob.Text)
                        newMember.joinedDate = Date.Now
                        newMember.userId = dbCtx.Users.Where(Function(e) e.email = newUser.email).SingleOrDefault().id
                        dbCtx.Members.Add(newMember)
                        dbCtx.SaveChanges()

                        Response.Redirect("CreateAccountSuccess.aspx")
                    Else
                        lblDobValidate.Text = "5 years old or younger are not allowed to register member"
                        lblDobValidate.Visible = True
                    End If
                Catch ex As Exception
                    lblDobValidate.Text = $"Invalid date format.[{ex.Message}]"
                    lblDobValidate.Visible = True
                End Try
            Else

                Dim newMember As Member = dbCtx.Members.Where(Function(e) e.id = member.id).SingleOrDefault()
                newMember.address = tbxAddress.Text
                newMember.contact = tbxContact.Text
                newMember.User.name = tbxName.Text

                dbCtx.SaveChanges()
                Session("member") = newMember

                lblUpdateMessage.Text = "<p>Update success!!</p>"
            End If
        End If
    End Sub

    Private Function validateDate(ByVal selectedDate As Date) As Boolean
        Return (selectedDate.Year + 5) < Date.Now.Year
    End Function
End Class