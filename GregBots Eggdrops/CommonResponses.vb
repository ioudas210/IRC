Imports System.Text.RegularExpressions
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient

Public Class CommonResponses
    'COMMON RESPONSES TO SERVERS AND CLIENTS

    Public Function Init(RecvString As String, cmdPrefix As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket, ByVal botid As String, botname As String, ServerName As String, threadID As String) As Boolean
        If Quit(RecvString, threadID) = True Then
            Return False
        End If

        If PingServer(RecvString, SendBytes, tnSocket) Then
            'setpingtime(removed)
        End If
        If InStr(RecvString, "004") > 0 And ConnectedToServer = False Then
            ConnectedToServer = True
        End If

        If RegXPChecker("\:.+ 433 \* .+ \:.+", RecvString) Then
            Dim newnick As String
            newnick = "testbot"
            SendInfo("NICK " & newnick & vbCrLf, SendBytes, tnSocket)
        End If

        Return True
    End Function

    Public Function Quit(ByRef RecvString As String, ByVal ThreadID As Long) As Boolean
        'FUNCTION NAME: Quit
        'INPUT        : Recv Data,TheadID
        'EXISTANCE    : Kills bot through proto or server link disconnectiob
        'OUTPUT       : sends quit cmd if its a panel kill, sends sig term to text box to remove

        'PANEL KILL
        Dim RegExp As String = ""

        If ThreadID = ThreadKillID And Not ThreadID = 0 Then
            '    SendInfo("QUIT :Easy Win Drop Panel Kill" & vbCrLf, SendBytes, tnSocket)
            Wait(2000)
            Return False
        End If

        'SERVER DISCONNECT
        RegExp = "ERROR \:Closing Link: .+"
        If RegXPChecker(RegExp, RecvString) Then
            'SEND SIGTERM TO TEXTBOX
            'DETERMINE IF BOT NEEDS RECONNECT

            Quit = False
            RecvString = ""
            Exit Function
        End If
        Return False
    End Function

    Public Function InitialJoin(ByRef SendBytes As Byte(), ByRef tnSocket As Socket, ByVal BotID As String) As Boolean
        'FUNCTION NAME: InitialJoin
        'INPUT        : Nothing
        'EXISTANCE    : Selects channels and joins then
        'OUTPUT       : Joined channel

        'CHANNEL INNER JOIN
        'SELECT tblbots.idnum, tblchannellist.ChannelName
        'FROM tblbots INNER JOIN tblchannellist ON tblbots.idnum = tblchannellist.BotID
        'WHERE (((tblbots.idnum)=1));

        SQL = "SELECT ChannelName,AutoOp FROM tblchannellist WHERE BotID=" & BotID

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()
            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader
                Dim reply As String = ""

                While myReader.Read
                    reply = nz(myReader.GetValue(0), "")
                    SendInfo("JOIN " & reply, SendBytes, tnSocket)
                End While

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
                Return False
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
            Return False
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return True
    End Function


    Public Function SetNickOnServer(ByRef SendBytes As Byte(), Pass As String, ByRef tnSocket As Socket, ByRef LocalFirstSw As Boolean, ChannelJoinSW As Boolean) As Boolean
        'FUNCTION NAME: SetNickOnServer
        'INPUT        : Nothing
        'EXISTANCE    : Sets the nick and user pref stats
        'OUTPUT       : Data to server about this connect to log in

        If LocalFirstSw = True Then
            SendInfo("PASS " & Pass & vbCrLf, SendBytes, tnSocket)
            SendInfo("NICK " & CurrBotName & vbCrLf, SendBytes, tnSocket)
            SendInfo("USER EasyWinDrop 8 * : EasyWinDrop 1.0" & vbCrLf, SendBytes, tnSocket)
            ConnectedToServer = True
            LocalFirstSw = False
            Return True
        End If

        If ChannelJoinSW = True Then
            ' Wait(1000)

            ChannelJoinSW = False
            JoinAnswer = True
            Return True
        End If
        Return False
    End Function

    Public Function PingServer(ByVal RecvString As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket) As Boolean
        'FUNCTION NAME: PingServer
        'INPUT        : Recv Data From Socket
        'EXISTANCE    : Pings server to maintain connecitong
        'OUTPUT       : Pong reply

        If RegXPChecker("^PING \:(?<key>.+)", RecvString) Then
            Dim re As New Regex("PING \:(?<key>.+)")
            Dim item

            mt = re.Match(RecvString)
            item = mt.Groups("key").ToString
            SendInfo("PONG :" & item & vbCrLf, SendBytes, tnSocket)
            'TheTextBox.AppendText("PONG :" & item & vbCrLf)
            RecvString = ""
            item = Nothing
            Return True
        End If
        Return False
    End Function

    Public Function CtcpReply(ByVal message As String, ByVal nickname As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket) As Boolean
        'FUNCTION NAME: CtcpReply
        'INPUT        : Message from channel, Nickname from channel
        'EXISTANCE    : Replies to the user any ctcp request
        'OUTPUT       : The nesscary request response over ctcp

        If RegXPChecker("\001PING (?<ts>.+)\001", message) Then
            Dim epochtime As String
            Dim ddate As Date
            ddate = "1/1/1970"
            epochtime = CStr(DateDiff(DateInterval.Second, CDate("1/1/1970"), Now.ToUniversalTime))
            SendInfo("NOTICE " & nickname & " :" & Chr(1) & "PING" & " " & epochtime & Chr(1), SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("\001VERSION\001", message) Then
            SendInfo("NOTICE " & nickname & " :" & Chr(1) & "VERSION " & "Easy WinDrop " & 1 & Chr(1), SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("\001TIME\001", message) Then
            SendInfo("NOTICE " & nickname & " :" & Chr(1) & "TIME" & " " & Now.Date.DayOfWeek.ToString & " " & Now.ToUniversalTime & " " & Now.Year & Chr(1), SendBytes, tnSocket)
            Return True
        End If
        Return False
    End Function
End Class
