
Imports System.Net.Sockets
Imports System.Text.RegularExpressions
Public Class ChatGames

    Public Function Init(RecvString As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket, cmdPrefix As String) As Boolean
        If RegXPChecker("^" & cmdPrefix & "8ball (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "8ball (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            Dim EightBallResponse(20) As String
            EightBallResponse(0) = "You may rely on it"
            EightBallResponse(1) = "Yes - definitely"
            EightBallResponse(2) = "Yes"
            EightBallResponse(3) = "Without a doubt"
            EightBallResponse(4) = "Very doubtful"
            EightBallResponse(5) = "Signs point to yes"
            EightBallResponse(6) = "Reply hazy, try again"
            EightBallResponse(7) = "Outlook not so good"
            EightBallResponse(8) = "Outlook good"
            EightBallResponse(9) = "My sources say no"
            EightBallResponse(10) = "My reply is no"
            EightBallResponse(11) = "Most likely"
            EightBallResponse(12) = "It is decidedly so"
            EightBallResponse(13) = "It is certain"
            EightBallResponse(14) = "Don't count on it"
            EightBallResponse(15) = "Concentrate and ask again"
            EightBallResponse(16) = "Cannot predict now"
            EightBallResponse(17) = "Better not tell you now"
            EightBallResponse(18) = "Ask again later"
            EightBallResponse(19) = "As I see it, yes"


            Dim rndnumeightball As Integer
            rndnumeightball = RandomNumber(19, 0)
            Debug.Print(rndnumeightball)
            SendInfo("PRIVMSG " & channel & " :" & EightBallResponse(rndnumeightball), SendBytes, tnSocket)
            Return True
        End If
    End Function
End Class
