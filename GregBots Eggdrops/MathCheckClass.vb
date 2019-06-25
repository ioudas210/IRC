Imports System.Text.RegularExpressions
Imports System.Net.Sockets

Public Class MathCheckClass
    Public cmdPrefix As Char
    Public mt As Match
    Public item, item2

    Public Function IsValidNumber(ByVal number As Long) As Boolean
        Return True
    End Function

    Public Function CheckMathChannel(ByRef re As Regex, ByVal message As String, ByRef tnSocket As Socket, ByRef SendBytes As [Byte](), ByVal botID As Integer, ByVal BotName As String, ByVal Channel As String) As Boolean
        If RegXPChecker("^" & cmdPrefix & "calc (?<item>.+)\+(?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "calc (?<item>.+)\+(?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item) And RegXPChecker(ZeroTo9Regex, item2) Then
                item = System.Convert.ToInt64(item)
                item2 = System.Convert.ToInt64(item2)
            Else
                Return False
            End If

            SendInfo("PRIVMSG " & Channel & " :Answer: " & item + item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "calc (?<item>.+)\/(?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "calc (?<item>.+)\/(?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item) And RegXPChecker(ZeroTo9Regex, item2) Then

            Else
                Return False
            End If

            SendInfo("PRIVMSG " & Channel & " :Answer: " & item / item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "calc (?<item>.+)-(?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "calc (?<item>.+)-(?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item) And RegXPChecker(ZeroTo9Regex, item2) Then
                item = System.Convert.ToInt64(item)
                item2 = System.Convert.ToInt64(item2)
            Else
                Return False
            End If

            SendInfo("PRIVMSG " & Channel & " :Answer: " & item - item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "sqrt evil", message) Then
            SendInfo("PRIVMSG " & Channel & " :Answer: Women", SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "sqrt women", message) Then
            SendInfo("PRIVMSG " & Channel & " :Answer: Evil", SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "sqrt (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "sqrt (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If RegXPChecker(ZeroTo9Regex, item) = False Then
                Return False
            End If

            SendInfo("PRIVMSG " & Channel & " :Answer: " & Math.Sqrt(item), SendBytes, tnSocket)
            Return True
        End If

        Return False
    End Function
End Class
