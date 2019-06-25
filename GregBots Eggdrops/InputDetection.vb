Imports System.Text.RegularExpressions
Imports System.Net.Sockets

Public Class InputDetection
    Public Function Init(RecvString As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket, cmdPrefix As String, botid As String, ServerName As String, Master As Boolean, LocalFirstSW As Boolean, ChannelJoinSW As Boolean) As Boolean
        Dim AclClass As New Acl
        Dim Responses As New CommonResponses
        Dim eggdropclass As New EggDropBotClasses
        eggdropclass.cmdPrefix = cmdPrefix
        Dim user As String
        regexp = "^\:(?<nickname>.+?)\!(?<ident>.+?)\@(?<hostname>.+?) NOTICE (?<user>.+) \:(?<message>.+)."

        If (IrcInputCheck(RecvString, regexp)) Then


            'THIS WILL NEED TO BE FIXED BETTER  CHECK IF NETWORK IRC SERVICES ARE TALKING TO BOT
            If InStr(nickname, "Serv") > 0 Or InStr(nickname, "serv") > 0 Then
                RecvString = ""
            Else
                'SET PASS NOTICE
                If RegXPChecker("^set pass:(?<item>.+) (?<item2>.+)", message) Then
                    Dim item, item2 As String
                    re = New Regex("^set pass:(?<item>.+) (?<item2>.+)")
                    mt = re.Match(message)
                    item = mt.Groups("item").ToString
                    item2 = mt.Groups("item2").ToString
                    If item = "" Or item2 = "" Then
                        SendInfo("NOTICE " & nickname & " :Invalid syntax " & item & "." & vbCrLf, SendBytes, tnSocket)
                    Else
                        item2 = GenerateHash(item2)
                        Debug.Print(item2)
                        item2 = QueryClean(item2)
                        item = QueryClean(item)
                        SQL = "UPDATE tblauth SET Password=""" & QueryClean(item2) & """ WHERE BotID=" & botid & " AND UserName=""" & QueryClean(item) & """"

                        If UpdateRecords(SQL, "Set Pass Hash") = False Then
                            Return False
                        End If
                    End If
                End If
            End If
        End If
        ':MrTwig!n=Jaw@unaffiliated/jawster NICK :Twig-Away
        ':ioudas!n=gc@cpe-74-75-90-244.maine.res.rr.com PRIVMSG gregbot2 :hey
        regexp = "^\:(?<nickname>.+?)\!(?<ident>.+?)\@(?<hostname>.+?) PRIVMSG (?<user>.+?) \:(?<message>.+)."

        If (IrcInputCheck(RecvString, regexp)) Then
            re = New Regex(regexp)
            re = New Regex(regexp)

            mt = re.Match(RecvString)
            nickname = mt.Groups("nickname").ToString
            ident = mt.Groups("ident").ToString
            hostname = mt.Groups("hostname").ToString
            channel = "#" & mt.Groups("channel").ToString
            message = mt.Groups("message").ToString
            user = mt.Groups("user").ToString

            If InStr(user, "#") > 0 Then
            Else
                If InStr(message, "PING") > 0 Or InStr(message, "TIME") > 0 Or InStr(message, "VERSION") > 0 Then

                    If Responses.CtcpReply(message, nickname, SendBytes, tnSocket) Then
                    End If
                Else
                    RecvString = "PING"
                End If
            End If
        End If

        '#####################################
        '#DETERMINE Chan/Server Kick Commands#
        '#####################################
        regexp = "^\:(?<nickname>.+?)\!(?<ident>.+?)\@(?<hostname>.+?) (?<command>.+?) #(?<channel>.+?) (?<userkicked>.+) \:(?<message>.+)."
        If IrcInputCheck(RecvString, regexp) Then
            re = New Regex(regexp)

            mt = re.Match(RecvString)
            nickname = mt.Groups("nickname").ToString
            ident = mt.Groups("ident").ToString
            hostname = mt.Groups("hostname").ToString
            command2 = mt.Groups("command").ToString
            channel = "#" & mt.Groups("channel").ToString
            message = mt.Groups("message").ToString
            Dim botProtectRejoin As New BotProtection
            Select Case command2
                Case "KICK"
                    'run kick code

                    If (botProtectRejoin.DetermineChannelJoin(botid, channel)) Then
                        SendInfo("JOIN " & channel, SendBytes, tnSocket)
                    End If
                                    'RecvString = ""
                Case "MODE"
                    'wee
                    'Mode protection goes here
                    If botProtectRejoin.DetectBanAgainstMe(channel, True, tnSocket, SendBytes, "greg") Then

                    End If
            End Select

            If (AclClass.IsMaster(nickname, botid)) Then
                Master = True
            Else
                Master = False
            End If
        End If


        '####################################
        '#DETERMINE Chan/Server Commands    #
        '####################################

        regexp = "^\:(?<nickname>.+?)\!(?<ident>.+?)\@(?<hostname>.+?) (?<command>.+?) #(?<channel>.+?) \:(?<message>.+)."
        If (IrcInputCheck(RecvString, regexp)) Then
            re = New Regex(regexp)
            mt = re.Match(RecvString)
            nickname = mt.Groups("nickname").ToString
            ident = mt.Groups("ident").ToString
            hostname = mt.Groups("hostname").ToString
            command2 = mt.Groups("command").ToString
            channel = "#" & mt.Groups("channel").ToString
            message = mt.Groups("message").ToString

            If (AclClass.IsMaster(nickname, botid)) Then
                Master = True
            Else
                Master = False
            End If
            If nickname = "joey" Or nickname = "joey_" Then
                'SendInfo("PRIVMSG " & channel & " :Joey is a gay canadian!" & vbCrLf, SendBytes, tnSocket)
            End If
            'RECONNECT COMMAND.
            If message = cmdPrefix & "reconnect" Then
                LocalFirstSW = True
                ChannelJoinSW = True
                tnSocket.Close()
                ConnectedToServer = False
            End If

            'If :gregc!n=gc@cpe-74-75-90-244.maine.res.rr.com QUIT :
            If command2 = "QUIT" Then
                If AclClass.IsUserAuthed(nickname, botid, channel) Then
                    SQL = "UPDATE tblauth SET IsAuthed=0 WHERE BotID=" & botid & " AND UserName=""" & QueryClean(nickname) & """"
                    If UpdateRecords(SQL, "QUIT AUTH") Then
                    End If
                Else
                End If
            End If

            'DB INSERT OF RCVD DATA TO USER CHAT TABLE
            If RecordSW Then
                If Not InStr(message, cmdPrefix & "last") > 0 Then
                    If InStr(message, cmdPrefix & "seen") > 0 Then
                    Else
                        If RecordInsert(QueryClean(channel), QueryClean(nickname), QueryClean(message), botid, ServerName) = False Then
                        End If
                    End If
                End If
            End If

            If Responses.CtcpReply(message, nickname, SendBytes, tnSocket) Then
                RecvString = ""
            End If
        End If

        Return True
    End Function
End Class
