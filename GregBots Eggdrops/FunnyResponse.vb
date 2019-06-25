Imports System.Net.Sockets

Public Class FunnyResponse
    Public Function Init(RecvString As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket) As Boolean

        If InStr(message, "story") > 0 Then
            SendInfo("PRIVMSG " & channel & " :Cool story BRO, tell it again." & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If message = "Rick Astley" Then
            SendInfo("PRIVMSG " & channel & " :Will Never Give You Up." & vbCrLf, SendBytes, tnSocket)
            SendInfo("PRIVMSG  " & channel & " :Never Let You Down, Never Turn Around and Hurt You" & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If message = "@lame_detect" Then
            SendInfo("PRIVMSG " & channel & " :Detecting Canadians" & vbCrLf, SendBytes, tnSocket)
            Return True
        End If
        Return False
    End Function
End Class