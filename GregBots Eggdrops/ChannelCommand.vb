﻿Imports System.Text.RegularExpressions
Imports System.Net.Sockets

Public Class ChannelCommand

    Public CmdPrefix As Char
    Public mt As Match
    Public item, item2


    Public Function CheckCommandInChannel(ByRef re As Regex, ByVal message As String, ByRef tnSocket As Socket, ByRef SendBytes As [Byte](), ByVal botID As Integer, ByVal BotName As String, ByVal Channel As String)
        If RegXPChecker("^" & CmdPrefix & "part (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "part (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("PART " & item & " :" & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "unban (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "unban (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " -b " & item & "@", SendBytes, tnSocket)
            Return True
        End If


        If RegXPChecker("^" & CmdPrefix & "devoice (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "devoice (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " -v " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "ban (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "ban (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " +b " & item, SendBytes, tnSocket)
            Return True
        End If



        If RegXPChecker("^" & CmdPrefix & "kick (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "kick (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString
            SendInfo("KICK " & Channel & " " & item & " :" & item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "kick (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "kick (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("KICK " & Channel & " " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "mode (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "mode (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "op (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "op (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " +o " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "deop (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "deop (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " -o " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "voice (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "voice (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("MODE " & Channel & " +v " & item, SendBytes, tnSocket)
            Return True
        End If



        If RegXPChecker("^" & CmdPrefix & "kick (?<item>.+) (?<item2>.+) (?<item3>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "kick (?<item>.+?) (?<item2>.+) (?<item3>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString()

            item2 = mt.Groups("item2").ToString
            If IsValidChannel(item) = True Then
                Dim item3
                item3 = mt.Groups("item3").ToString
                SendInfo("KICK " & item & " " & item2 & " :" & item3, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If


        If RegXPChecker("^" & CmdPrefix & "action (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "action (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("PRIVMSG  " & Channel & " :" & "ACTION " & item & "", SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "topic (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "topic (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("TOPIC " & Channel & " :" & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "part (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "part (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("PART :" & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "rejoin$", message) Then
            SendInfo("PART :" & Channel, SendBytes, tnSocket)
            SendInfo("JOIN :" & Channel, SendBytes, tnSocket)
            Return True
        End If



        If RegXPChecker("^" & CmdPrefix & "unban (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "unban (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " -b " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "action (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "action (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) = True Then
                SendInfo("PRIVMSG  " & item & " :" & "ACTION " & item2 & "", SendBytes, tnSocket)
            Else
                Return False
            End If
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "topic (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "topic (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) = True Then
                SendInfo("TOPIC " & item & " :" & item2, SendBytes, tnSocket)
            Else
                Return False
            End If
            Return True
        End If

        If RegXPChecker("^" & CmdPrefix & "ban (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "ban (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " +b " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "voice (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "voice (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " +v " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "devoice (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "devoice (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " -v " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "op (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "op (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " +o " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^\" & CmdPrefix & "mode (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^\" & CmdPrefix & "mode (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "deop (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "deop (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then
                SendInfo("MODE " & item & " -o " & item2, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "join (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "join (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If IsValidChannel(item) Then
                SendInfo("JOIN :" & item, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "addchan (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "addchan (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If IsValidChannel(item) Then

                If Not AddChan(item, item2, botID) Then

                End If

                SendInfo("PRIVMSG " & Channel & " :Added " & item & vbCrLf, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "delchan (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "delchan (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If IsValidChannel(item) Then
                DelChan(item, botID)
                SendInfo("PRIVMSG " & Channel & " :Deleted " & item & vbCrLf, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^" & CmdPrefix & "rejoin (?<item>.+)", message) Then
            re = New Regex("^" & CmdPrefix & "rejoin (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If IsValidChannel(item) Then
                SendInfo("PART :" & item, SendBytes, tnSocket)
                SendInfo("JOIN :" & item, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        Return False
    End Function
End Class
