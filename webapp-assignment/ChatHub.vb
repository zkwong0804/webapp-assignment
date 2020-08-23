Imports Microsoft.AspNet.SignalR

Public Class ChatHub
    Inherits Hub

    Public Sub Hello()
        Clients.All.Hello()
    End Sub
    Public Sub Send(ByVal name As String, ByVal message As String)
        Clients.All.broadcastMessage(name, message)
    End Sub
End Class

