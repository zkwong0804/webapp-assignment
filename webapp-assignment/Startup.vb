Imports Microsoft.VisualBasic
Imports Microsoft.Owin
Imports Owin
<Assembly: OwinStartup(GetType(webapp_assignment.Startup))>
Public Class Startup
    Public Sub Configuration(ByVal app As IAppBuilder)
        app.MapSignalR()
    End Sub
End Class
