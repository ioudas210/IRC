Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions

Public Class EggDropBotClasses
    'Socket Stuff
    Public tnSocket As Socket
    Public SendBytes As [Byte]()

    'Class textbox to assign text to send back to
    Public TheTextBox As TextBox

    'BOT SPECIFIC INFO
    Public ThreadID As Integer
    Public LocalFirstSW As Boolean
    Public ChannelJoinSW As Boolean
    Public ExitSW As Boolean
    Public BotName As String
    Public cmdPrefix As String
    Public Record As String
    Public MasterAuth As Boolean
    Public Master As Boolean = False
    Public BotID As Long
    Public LowerLevel As Boolean = False
    Public ServerName As String
    Public rndNum As New Random(System.DateTime.Now.Millisecond)
    Public RecvString As String = String.Empty

    'Uni Class calls
    Public AclClass As New Acl
    Public ChannelCommandClass As New ChannelCommand
    Public MathChannelClass As New MathCheckClass
    Public ComResponses As New CommonResponses
    Public FunnyResponses As New FunnyResponse
    Public Games As New ChatGames

    'CLASS SPECIFIC FUNCS
    Public Function Reconnect(ByRef tnSocket As Socket)
        'FUNCTION NAME:reconnect
        'INPUT        :Thread ID as object
        'EXISTANCE    :Main Engine
        'OUTPUT       :Anything
        LocalFirstSW = True
        ChannelJoinSW = True
        tnSocket.Close()
        ConnectedToServer = False

        tnSocket = Nothing
        Command = Nothing
        RecvString = Nothing
        ThreadKillID = 9999

        tnSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        tnSocket.Connect(currServer, PPort)
        Return True
    End Function
    Public Function ConnectBot(ByVal threadID) As Object
        'FUNCTION NAME:ConnectBot
        'INPUT        :Thread ID as object
        'EXISTANCE    :Main Engine
        'OUTPUT       :Anything

        'INSTANCE CLASS CHILD OBJECTS
        ChannelCommandClass.CmdPrefix = cmdPrefix
        MathChannelClass.cmdPrefix = cmdPrefix


        threadID = My.Settings.ThreadID

        'DECLARE SOCKET VARS

        Dim NumBytes As Integer = 0
        Dim RecvBytes(255) As [Byte]
        Dim nickname, ident, hostname, channel, message
        Dim regexp As String
        Dim Responses As New CommonResponses
        Dim InputDetection As New InputDetection
        Dim ChatChannel As New ChatChannel
        message = ""
        RecvString = ""
        tnSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        Try
            tnSocket.Connect(currServer, PPort)
            Do While tnSocket.Connected
                Do
                    If NumBytes < 256 Then
                        NumBytes = tnSocket.Receive(RecvBytes, RecvBytes.Length, 0)
                        RecvString = RecvString + Encoding.ASCII.GetString(RecvBytes, 0, NumBytes)
                        TheTextBox.AppendText(RecvString)
                    Else
                        NumBytes = 0 'RESET
                    End If
                Loop While NumBytes = 256

                'WE NOW HAVE RECV DATA
                While Not RecvString = ""



                    'DETERMINE IF CONNECTED
                    If ConnectedToServer Then
                        If Responses.Init(RecvString, cmdPrefix, SendBytes, tnSocket, BotID, BotName, ServerName, threadID) Then

                        End If
                        If InputDetection.Init(RecvString, SendBytes, tnSocket, cmdPrefix, BotID, ServerName, Master, LocalFirstSW, ChannelJoinSW) Then

                        End If

                        '#############################
                        '#DETERMINE Notice           #
                        '#############################

                        regexp = "^\:(?<nickname>.+?)\!(?<ident>.+?)\@(?<hostname>.+?) NOTICE (?<user>.+) \:(?<message>.+)."

                        If (IrcInputCheck(RecvString, regexp)) Then
                            Dim re As New Regex(regexp)
                            Dim user As String

                            'CHAT GRABBER
                            mt = re.Match(RecvString)
                            nickname = mt.Groups("nickname").ToString
                            ident = mt.Groups("ident").ToString
                            hostname = mt.Groups("hostname").ToString
                            message = mt.Groups("message").ToString
                            channel = mt.Groups("channel").ToString
                            user = mt.Groups("user").ToString

                            ''CTCP CHAN PING REPLY
                            If Responses.CtcpReply(message, nickname, SendBytes, tnSocket) Then
                                RecvString = ""
                                Exit While
                            End If

                            If Len(message) > 0 Then
                                RecvString = ""
                                Exit While
                            End If
                        End If

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


                            'CHECK ACL
                            If (AclClass.IsMaster(nickname, BotID)) Then
                                Master = True
                            Else
                                Master = False
                            End If
                            'CHECK CHANNEL RELATED CALSL

                            If ChatChannel.Init(RecvString, cmdPrefix, SendBytes, tnSocket, BotID, BotName, ServerName, threadID, message) Then
                                RecvString = ""
                                Exit While
                            End If
                            If MathChannelClass.CheckMathChannel(re, message, tnSocket, SendBytes, BotID, BotName, channel) Then
                                RecvString = ""
                                Exit While
                            End If
                            If ChannelCommandClass.CheckCommandInChannel(re, message, tnSocket, SendBytes, BotID, BotName, channel) Then
                                RecvString = ""
                                Exit While
                            End If

                            If FunnyResponses.Init(RecvString, SendBytes, tnSocket) Then
                                RecvString = ""
                                Exit While
                            End If

                            If Games.Init(RecvString, SendBytes, tnSocket, cmdPrefix) Then
                                RecvString = ""
                                Exit While
                            End If

                            'RECONNECT COMMAND.
                            If message = cmdPrefix & "reconnect" Then
                                Reconnect(tnSocket)
                            End If

                            'If :gregc!n=gc@cpe-74-75-90-244.maine.res.rr.com QUIT :
                            If command2 = "QUIT" Then
                                If AclClass.IsUserAuthed(nickname, BotID, channel) Then
                                    SQL = "UPDATE tblauth SET IsAuthed=0 WHERE BotID=" & BotID & " AND UserName=""" & QueryClean(nickname) & """"
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
                                        If RecordInsert(QueryClean(channel), QueryClean(nickname), QueryClean(message), BotID, ServerName) = False Then
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    '####################################
                    '#On server channel commands        #
                    '####################################

                    'PAST CHANNEL COMMANDS Server commands go here
                    If RegXPChecker("\:.+ 433 \* .+ \:.+", RecvString) Then
                        Dim newnick As String
                        newnick = "testbot"
                        SendInfo("NICK " & newnick & vbCrLf, SendBytes, tnSocket)

                    End If

                    If RegXPChecker("\:.+ 376 .+", RecvString) Then
                        Responses.InitialJoin(SendBytes, tnSocket, BotID)

                    End If
                    ':irc.mad-season.com 376 gregbot2 :End of /MOTD command.
                    'ASSIGN SERVER NICK  
                    'ALSO HANDLES CHANNEL JOINS
                    'force test api for password rfc. 3/18/2019
                    Dim pass As String = "greg"
                    Responses.SetNickOnServer(SendBytes, pass, tnSocket, LocalFirstSW, ChannelJoinSW)
                    RecvString = ""
                End While
            Loop

        Catch myerror As Exception
            'NEED A BETTER METHOD FOR HANDLING
            Debug.Print(myerror.Message())

            Dim thetime As String = Format(Today, "yyyy/MM/dd")
            Dim errorHandleStr As String = QueryClean(myerror.ToString)

            SQL = "INSERT INTO tblerrorlog(botid, ErrorNumber, ErrorMessage,HappenedWhen,BotName) VALUES(" & BotID & ", """ & errorHandleStr & """, """ & myerror.Message & " " & message & """,""" & thetime & """,""" & BotName & """)"
            Try
                If InsertRecords(SQL, "ErrorLog") Then

                End If

            Catch ex As Exception

            End Try
            Command = Nothing
            RecvString = Nothing
            'Reconnect(tnSocket)
        End Try

        Return True
    End Function
End Class
