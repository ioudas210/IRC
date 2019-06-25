Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Net.Sockets
Imports System.Net

Public Class ChatChannel
    Public Function Init(RecvString As String, cmdPrefix As String, ByRef SendBytes As Byte(), ByRef tnSocket As Socket, ByVal botid As String, botname As String, ServerName As String, threadID As String, message As String) As Boolean
        Dim AclClass As New Acl

        If RegXPChecker("^" & cmdPrefix & "set pass (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "set pass (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If item = "" Then
                SendInfo("PRIVMSG " & channel & " :Please include a username when setting a password." & item & vbCrLf, SendBytes, tnSocket)
            Else
                SendInfo("NOTICE " & nickname & " :Please notice me set pass:UserName PasswordHere for user " & item & "." & vbCrLf, SendBytes, tnSocket)
            End If

            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "ident$", message) Then
            re = New Regex("^" & cmdPrefix & "ident")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            Dim serverip As String
            serverip = GetField("SELECT ServerIP  FROM tblserverlist WHERE BotID=" & botid & " AND ServerIP=""" & currServer & """", "ServerIP", "GetIP")
            If serverip = "" Then
                Return False
            End If

            Dim reply As String = GetField("SELECT Ident FROM tblserverlist WHERE BotID=" & botid & " AND ServerIP=""" & currServer & """", "Ident", "Ident")
            If reply = "" Then
                Return False
            End If
            SendInfo(reply, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "sha (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "sha (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If item = "" Then
                SendInfo("PRIVMSG " & channel & " :Please include a username when setting a password." & item & vbCrLf, SendBytes, tnSocket)
            Else
                SendInfo("PRIVMSG " & channel & " :" & GenerateHash(item) & vbCrLf, SendBytes, tnSocket)
            End If
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "nick (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "nick (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("NICK " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "delserver (?<item>.+?)", message) Then
            re = New Regex("^" & cmdPrefix & "delserver (?<item>.+?)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("PRIVMSG " & channel & " :Deleted server" & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "addserver (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "addserver (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If AddServer(item, GetBotID(botname), "6667", 1, 1) Then
                SendInfo("PRIVMSG " & channel & " :Added server " & item & vbCrLf, SendBytes, tnSocket)
            End If

            'SendInfo("PRIVMSG " & channel & " :Added server " & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^http://(?<site>.+)", message) Then
            re = New Regex("^http://(?<site>.+)")
            mt = re.Match(message)
            item = mt.Groups("site").ToString
            Dim url As String = "http://" & item
            Dim http As New HTTPSocketClass
            Dim webresult As String
            webresult = http.DownloadHTML(url)
            webresult = Trim(http.ParseHTML(webresult))
            SendInfo("PRIVMSG " & channel & " :Title:" & webresult & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^https://(?<site>.+)", message) Then
            re = New Regex("^https://(?<site>.+)")
            mt = re.Match(message)
            item = mt.Groups("site").ToString
            Dim url As String = "https://" & item
            Dim http As New HTTPSocketClass
            Dim webresult As String
            webresult = http.DownloadHTML(url)
            webresult = Trim(http.ParseHTML(webresult))
            SendInfo("PRIVMSG " & channel & " :Title:" & webresult & vbCrLf, SendBytes, tnSocket)
            Return True
        End If


        If RegXPChecker("^" & cmdPrefix & "quit (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "quit (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("QUIT :" & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "quit$", message) Then
            If nickname = "MrTwig" Or nickname = "MrPenguin" Then
                SendInfo("PRIVMSG " & channel & " :fag", SendBytes, tnSocket)

                Return True
            End If
            SendInfo("QUIT :" & "Good Bye", SendBytes, tnSocket)
            Return True
        End If


        If RegXPChecker("^" & cmdPrefix & "help (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "help (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SQL = "SELECT tblbotcmdlist.BotID, tblbotcmdlist.Command, tblbotcmdlist.Usage, tblbotcmdlist.Syntax FROM tblbotcmdlist GROUP BY tblbotcmdlist.BotID, tblbotcmdlist.Command, tblbotcmdlist.Usage, tblbotcmdlist.Syntax HAVING (((tblbotcmdlist.BotID)=" & botid & ") AND ((tblbotcmdlist.Command)=""" & QueryClean(item) & """));"

            conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

            Try
                conn.Open()
                Try
                    myCommand.Connection = conn
                    myCommand.CommandText = SQL
                    myReader = myCommand.ExecuteReader
                    Dim reply As String = ""
                    While myReader.Read
                        reply = "Command:" & nz(myReader.GetValue(1), "")
                        reply = reply & "  Syntax:" & nz(myReader.GetValue(3), "")
                        If reply = "Command:  Syntax:" Then

                        Else
                            SendInfo("NOTICE " & nickname & " :" & reply, SendBytes, tnSocket)
                            Wait(2000)
                        End If
                    End While

                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "help$", message) Then
            SQL = "SELECT tblbotcmdlist.BotID, tblbotcmdlist.Command, tblbotcmdlist.Usage, tblbotcmdlist.Syntax FROM tblbotcmdlist GROUP BY tblbotcmdlist.BotID, tblbotcmdlist.Command, tblbotcmdlist.Usage, tblbotcmdlist.Syntax HAVING (((tblbotcmdlist.BotID)=" & botid & "));"
            conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

            Try
                conn.Open()
                Try
                    myCommand.Connection = conn
                    myCommand.CommandText = SQL
                    myReader = myCommand.ExecuteReader
                    Dim reply As String = ""

                    While myReader.Read
                        reply = "Command:" & nz(myReader.GetValue(1), "")
                        reply = reply & "  Syntax:" & nz(myReader.GetValue(3), "")
                        If reply = "Command:  Syntax:" Then

                        Else
                            SendInfo("NOTICE " & nickname & " :" & reply, SendBytes, tnSocket)
                            Wait(2000)
                        End If
                    End While

                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "errorlog (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "errorlog (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            If RegXPChecker(ZeroTo9Regex, item) Then
                item = System.Convert.ToInt32(item)
                If item < 0 Then
                    Return False
                End If
            Else
                Return False
            End If

            SQL = "SELECT IDNum,ErrorNumber,HappenedWhen FROM tblerrorlog WHERE BotID=" & botid & " ORDER BY IDNum DESC LIMIT " & QueryClean(item)

            conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
            Try
                conn.Open()
                Try
                    myCommand.Connection = conn
                    myCommand.CommandText = SQL
                    myReader = myCommand.ExecuteReader

                    Dim reply As String = ""
                    While myReader.Read
                        reply = "Error Num:" & nz(myReader.GetValue(1), "") & " at:" & nz(myReader.GetValue(2), "")
                        reply = Replace(reply, vbCrLf, "")
                        Debug.Print(reply)

                        If reply = "Error Num: at:" Then
                            Return True
                        End If
                        SendInfo("PRIVMSG " & channel & " :" & reply, SendBytes, tnSocket)
                        Wait(2200)

                    End While
                    Return True
                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            SendInfo("PRIVMSG " & channel & " :Hooray no errors! you must of fixed me!", SendBytes, tnSocket)
            Return False
        End If

        If RegXPChecker("^" & cmdPrefix & "delerrorlog$", message) Then

            If DeleteRecords("DELETE FROM tblerrorlog WHERE BotID=" & botid, "Error log Del") Then

            End If

            SendInfo("PRIVMSG " & channel & " :Deleted error log", SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "calc (?<item>.+)\*(?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "calc (?<item>.+)\*(?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item) = False Or RegXPChecker(ZeroTo9Regex, item2) = False Then
                Return False
            End If

            SendInfo("PRIVMSG " & channel & " :Answer: " & item * item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "setupftp (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "setupftp (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item2) = False Then
                Return False
            End If

            SQL = "INSERT INTO tblP2PServers(Server,Port,Proto,BotID) VALUES(""" & item & """,""" & item2 & """,""" & "FTP" & """," & botid & ")"
            If InsertRecords(SQL, "InsertFTP") Then

            End If

            SendInfo("NOTICE " & nickname & " :to set a username notice me: SetFtpUser <username>", SendBytes, tnSocket)
            SendInfo("NOTICE " & nickname & " :to set a username notice me: SetFtpPass <pass>", SendBytes, tnSocket)
            SendInfo("PRIVMSG " & channel & " :Added ftp server " & item & " on port " & item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "setupssh (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "setupssh (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item2) = False Then
                Return False
            End If

            SQL = "INSERT INTO tblP2PServers(Server,Port,Proto,BotID) VALUES(""" & item & """,""" & item2 & """,""" & "FTP" & """," & botid & ")"
            If InsertRecords(SQL, "InsertFTP") Then

            End If

            SendInfo("NOTICE " & nickname & " :to set a username notice me: SetFtpUser <username>", SendBytes, tnSocket)
            SendInfo("NOTICE " & nickname & " :to set a username notice me: SetFtpPass <pass>", SendBytes, tnSocket)
            SendInfo("PRIVMSG " & channel & " :Added ftp server " & item & " on port " & item2, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "setuptracker (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "setuptracker (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            SQL = "INSERT INTO tblP2PServers(Server,Port,Proto,BotID) VALUES(""" & item & """,""" & item2 & """,""" & "BITTORRENT" & """," & botid & ")"

            If InsertRecords(SQL, "InsertFTP") Then

            End If

            SendInfo("PRIVMSG " & channel & " :Added torrent tracker: " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "mergetracker (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "mergetracker (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            SQL = "INSERT INTO tblP2PServers(Server,Port,Proto,BotID) VALUES(""" & item & """,""" & item2 & """,""" & "BITTORRENT" & """," & botid & ")"

            If InsertRecords(SQL, "InsertFTP") Then

            End If

            SendInfo("PRIVMSG " & channel & " :Added torrent tracker: " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "last (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "last (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            'MAKE DB CALL
            SQL = "SELECT message FROM tbluserchat WHERE tbluserchat.Nick=""" & QueryClean(item) & """ AND tbluserchat.Channel=""" & channel & """ ORDER BY idnum DESC LIMIT 1"

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
                    End While

                    If reply = "" Then
                        SendInfo("PRIVMSG " & channel & " :No history for " & item, SendBytes, tnSocket)
                    Else
                        SendInfo("PRIVMSG " & channel & " :" & item & " said: " & reply, SendBytes, tnSocket)
                    End If

                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "gem (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "gem (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            SQL = "INSERT INTO tbllines(botid, Command, Line) VALUES(" & botid & ", """ & cmdPrefix & "gem" & """, """ & item & """)"

            If InsertRecords(SQL, "GEM") Then

            End If

            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "gem$", message) Then

            Dim maxint As String = "0"
            Dim minint As String = "0"
            maxint = GetField("SELECT max(idnum) FROM tbllines", maxint, "Max")
            minint = GetField("SELECT min(idnum) FROM tbllines", minint, "min") - 1

            SQL = "SELECT Line FROM tbllines WHERE IDNum>=" & RandomNumber(maxint, minint)


            conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
            Try
                conn.Open()

                Try
                    myCommand.Connection = conn
                    myCommand.CommandText = SQL
                    myReader = myCommand.ExecuteReader
                    Dim reply As String = ""
                    While myReader.Read
                        reply = "PRIVMSG " & channel & " :" & nz(myReader.GetValue(0), "")
                        Exit While
                    End While

                    SendInfo(reply, SendBytes, tnSocket)

                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If



        If RegXPChecker("^" & cmdPrefix & "seen (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "seen (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            SQL = "SELECT TheTime,message FROM tbluserchat WHERE tbluserchat.Nick=""" & QueryClean(item) & """ AND tbluserchat.Channel=""" & QueryClean(channel) & """ ORDER BY idnum DESC LIMIT 1"

            conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

            Try
                conn.Open()

                Try
                    myCommand.Connection = conn
                    myCommand.CommandText = SQL
                    myReader = myCommand.ExecuteReader
                    Dim reply As String = ""
                    While myReader.Read
                        reply = "PRIVMSG " & channel & " :" & item & " was last seen on: " & nz(myReader.GetValue(0), "Never") & " Saying " & nz(myReader.GetValue(1), "I Dont Exist!")
                    End While

                    SendInfo(reply, SendBytes, tnSocket)
                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "google (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "google (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            Dim url As String = "http://www.google.com/search?q=" & item & "&btnI"
            Dim webresponse As String
            Dim httpsdownload As New HTTPSocketClass
            webresponse = httpsdownload.DownloadHTML(url)
            webresponse = httpsdownload.ParseHTML(webresponse)
            SendInfo("PRIVMSG " & channel & " : " & webresponse & " - " & url & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "weather (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "weather (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            Dim url As String = "http://api.wunderground.com/auto/wui/geo/WXCurrentObXML/index.xml?query=" & item
            Dim webClient As System.Net.WebClient = New System.Net.WebClient()
            webClient.DownloadFile(url, My.Application.Info.DirectoryPath & "\tmp.txt")
            Dim str2 As String = ""
            Dim xmlparse As New XmlReader
            Dim reply As String

            reply = xmlparse.ReadXML(My.Application.Info.DirectoryPath & "\tmp.txt")

            If reply = "" Or reply = "None" Then
                Return False
            End If

            reply = "PRIVMSG " & channel & " :" & reply
            SendInfo(reply, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "say (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^\" & cmdPrefix & "say (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If IsValidChannel(item) Then
                item2 = mt.Groups("item2").ToString
                SendInfo("PRIVMSG " & item & " :" & item2 & vbCrLf, SendBytes, tnSocket)
                Return True
            Else
                Return False
            End If
        End If

        If RegXPChecker("^\" & cmdPrefix & "say (?<item>.+)", message) Then
            re = New Regex("^\" & cmdPrefix & "say (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("PRIVMSG " & channel & " :" & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If


        If RegXPChecker("^\" & cmdPrefix & "rawr$", message) Then
            SendInfo("PRIVMSG " & channel & " : RAWR" & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        'LEVEL ADDING AND GROUP CMD ADDING
        If RegXPChecker("^\" & cmdPrefix & "addlevel (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^\" & cmdPrefix & "addlevel (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If InStr(item, "#") > 0 Then
                Return False
            End If

            If RegXPChecker(ZeroTo9Regex, item2) = False Then
                SendInfo("PRIVMSG " & channel & " :" & item & vbCrLf, SendBytes, tnSocket)
            End If

            result = AclClass.AddUserLevel(item, botid, channel, botname, item2, ServerName)

            If Not result = "False" Then
                SendInfo(result, SendBytes, tnSocket)
            End If

            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "addlevel (?<item>.+) ", message) Then
            re = New Regex("^\" & cmdPrefix & "addlevel (?<item>.+)")
            mt = re.Match(message)
            item = "#" & mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item2) = False Then
                SendInfo("PRIVMSG " & channel & " :" & item & vbCrLf, SendBytes, tnSocket)
            End If

            result = AclClass.AddUserLevel(item, botid, channel, botname, item2, ServerName)

            If Not result = "False" Then
                SendInfo(result, SendBytes, tnSocket)
            End If

            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "dellevel (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "dellevel (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString
            SendInfo("PRIVMSG " & channel & " :Deleted level " & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "delcmd (?<item>.+) group (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "delcmd (?<item>.+) group (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString
            SendInfo("PRIVMSG " & channel & " :Deleted command group " & item2 & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "addgroup (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^\" & cmdPrefix & "addgroup (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString
            result = AclClass.AddUserGroup(botname, item2, botid, channel, item, ServerName)

            If Not result = "False" Then
                SendInfo(result, SendBytes, tnSocket)
            End If

            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "listgroups (?<item>.+?)", message) Then
            re = New Regex("^\" & cmdPrefix & "listgroups (?<item>.+?)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            If RegXPChecker(A2ZRegex, item) Then

                SQL = "SELECT BotGroup FROM tblaclbygroup WHERE BotID=" & botid & " AND BotGroup=""" & item & """GROUP BY BotGroup"

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
                            SendInfo("NOTICE " & nickname & " : Group " & reply & vbCrLf, SendBytes, tnSocket)
                            Wait(1000)
                        End While

                    Catch myerror As MySqlException
                        MsgBox("There was an error reading from the database: " & myerror.Message)
                    End Try
                Catch myerror As MySqlException
                    MsgBox("Error connecting to the database: " & myerror.Message)
                Finally
                    If conn.State <> ConnectionState.Closed Then conn.Close()
                End Try
            End If

            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "listgroups$", message) Then
            SQL = "SELECT BotGroup FROM tblaclbygroup WHERE BotID=" & botid & " GROUP BY BotGroup"

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
                        SendInfo("NOTICE " & nickname & " : Group " & reply & vbCrLf, SendBytes, tnSocket)
                        Wait(1000)
                    End While

                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "listlevels (?<item>.+?)", message) Then
            re = New Regex("^\" & cmdPrefix & "listlevels (?<item>.+?)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            If RegXPChecker(ZeroTo9Regex, item) Then

                SQL = "SELECT Level FROM tblacl WHERE BotID=" & botid & " AND Level=""" & item & """ GROUP BY Level"

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
                            SendInfo("NOTICE " & nickname & " : Level " & reply & vbCrLf, SendBytes, tnSocket)
                            Wait(1000)
                        End While

                    Catch myerror As MySqlException
                        MsgBox("There was an error reading from the database: " & myerror.Message)
                    End Try
                Catch myerror As MySqlException
                    MsgBox("Error connecting to the database: " & myerror.Message)
                Finally
                    If conn.State <> ConnectionState.Closed Then conn.Close()
                End Try
            End If

            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "listlevels$", message) Then

            SQL = "SELECT Level FROM tblacl WHERE BotID=" & botid & " GROUP BY Level"

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
                        SendInfo("NOTICE " & nickname & " : Level " & reply & vbCrLf, SendBytes, tnSocket)
                        Wait(1000)
                    End While

                Catch myerror As MySqlException
                    MsgBox("There was an error reading from the database: " & myerror.Message)
                End Try
            Catch myerror As MySqlException
                MsgBox("Error connecting to the database: " & myerror.Message)
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
            End Try
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "delgroup (?<item>.+)", message) Then
            re = New Regex("^\" & cmdPrefix & "delgroup (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            result = AclClass.DelUserGroup(nickname, botid, channel, item)

            If Not result = "False" Then
                SendInfo("PRIVMSG " & channel & " :Deleted level " & item & vbCrLf, SendBytes, tnSocket)
            End If
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "setupproxy (?<item>.+?)", message) Then
            re = New Regex("^\" & cmdPrefix & "setupproxy (?<item>.+?)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            SQL = "INSERT INTO tblserverevasion(botID, ThreadID,Server,BotName) VALUES(" & botid & ", """ & threadID & """, """ & item & """,""" & botname & """)"
            InsertRecords(SQL, "SETUP PROXY")
            SendInfo("PRIVMSG " & channel & " :Added proxy " & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "addcmd (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^\" & cmdPrefix & "addcmd (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If RegXPChecker(ZeroTo9Regex, item2) Then
                SQL = "INSERT INTO tblbotcmdlist(botid, Command, Level) VALUES(" & botid & ", """ & item & """, """ & item2 & """)"
                AddBotCmd(botid, SQL)
                SendInfo("PRIVMSG " & channel & " :Added command " & item & " to level: " & item2 & vbCrLf, SendBytes, tnSocket)
            ElseIf RegXPChecker(A2ZRegex, item2) Then
                SQL = "INSERT INTO tblbotcmdlist(botID, Command,GroupName) VALUES(" & botid & ", """ & item & """, """ & item2 & """)"
                AddBotCmd(botid, SQL)
                SendInfo("PRIVMSG " & channel & " :Added command " & item & " to group: " & item2 & vbCrLf, SendBytes, tnSocket)
            End If

            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "delcmd (?<item>.+?) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "delcmd (?<item>.+?) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString
            SendInfo("PRIVMSG " & channel & " :Deleted command level " & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^\" & cmdPrefix & "delcmd (?<item>.+?)", message) Then
            re = New Regex("^\" & cmdPrefix & "delcmd (?<item>.+?)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item").ToString

            'If DeleteRecords("DELETE FROM tblbotcmdlist WHERE Command=""" & item & """", "Delete botcmdlist") Then

            'End If

            SendInfo("PRIVMSG " & channel & " :Deleted command level " & item & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "link (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "link (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("NOTICE  " & item & " :Link" & botname, SendBytes, tnSocket)
            SendInfo("PRIVMSG  " & channel & " :Linked to " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "unlink (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "unlink (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            SendInfo("PRIVMSG  " & channel & " :Linked " & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "adduserprotect (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "adduserprotect (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If (AddProtect(item, botname, item2, channel)) Then

            End If

            SendInfo("PRIVMSG " & channel & " :" & "added user", SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "adduserprotect (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "adduserprotect (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString

            If (AddProtect(item, botid, botname)) Then

            End If

            SendInfo("PRIVMSG " & channel & " :" & "Added user:" & item, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "deluserprotect (?<item>.+) (?<item2>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "deluserprotect (?<item>.+) (?<item2>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString

            If (DelProtect(item, botname, item2, channel)) Then

            End If

            SendInfo("PRIVMSG " & channel & " :" & "deleted user", SendBytes, tnSocket)
            Return True
        Else
            If RegXPChecker("^" & cmdPrefix & "deluser (?<item>.+)", message) Then
                re = New Regex("^" & cmdPrefix & "deluser (?<item>.+)")
                mt = re.Match(message)
                item = mt.Groups("item").ToString

                If (DelProtect(item, botname, "", channel)) Then

                End If

                SendInfo("PRIVMSG " & channel & " :" & "deleted user", SendBytes, tnSocket)
                Return True
            End If
        End If

        If RegXPChecker("^" & cmdPrefix & "deluserprotect (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "deluserprotect (?<item>.+")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            item2 = mt.Groups("item2").ToString '

            If (DelProtect(item, botname, item2, channel)) Then

            End If

            SendInfo("PRIVMSG " & channel & " :" & "deleted user", SendBytes, tnSocket)
            Return True
        Else
            If RegXPChecker("^" & cmdPrefix & "deluser (?<item>.+)", message) Then
                re = New Regex("^" & cmdPrefix & "deluser (?<item>.+)")
                mt = re.Match(message)
                item = mt.Groups("item").ToString

                If (DelProtect(item, botname, "", channel)) Then

                End If

                SendInfo("PRIVMSG " & channel & " :" & "deleted user", SendBytes, tnSocket)
                Return True
            End If
        End If

        If RegXPChecker("^\" & cmdPrefix & "login$", message) Then
            SendInfo("NOTICE " & nickname & " :Please notice me auth:password" & vbCrLf, SendBytes, tnSocket)
            Return True
        End If


        If RegXPChecker("^\" & cmdPrefix & "mylevel$", message) Then
            Dim Ulevel As String = ""
            Dim UAuth As String = ""
            Ulevel = GetField("SELECT Level FROM tblacl WHERE BotID=" & botid & " AND UserAccessName=""" & nickname & """", Ulevel, "Ulevel")
            SendInfo("NOTICE " & nickname & " :you are AuthStatus at Status:" & Ulevel & vbCrLf, SendBytes, tnSocket)
            Return True
        End If

        If RegXPChecker("^" & cmdPrefix & "sql (?<item>.+)", message) Then
            re = New Regex("^" & cmdPrefix & "sql (?<item>.+)")
            mt = re.Match(message)
            item = mt.Groups("item").ToString
            If InStr(LCase(item), "drop") > 0 Then
                Return True
            End If

            If InStr(LCase(item), "delete") > 0 Then
                Return True
            End If

            If InStr(LCase(item), "update") > 0 Then
                Return True
            End If

            If InStr(LCase(item), "truncate") > 0 Then
                Return True
            End If

            If InStr(LCase(item), "insert") > 0 Then
                Return True
            End If

            Try
                conn.Open()
                Dim stm As String = item
                Dim cmd As MySqlCommand = New MySqlCommand(stm, conn)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                Dim result2 As String = ""
                While reader.Read()
                    Dim i
                    For i = 0 To reader.FieldCount - 1
                        result2 = result2 & " " & String.Concat(" ", reader(i))
                    Next i

                    SendInfo("PRIVMSG " & channel & " :" & reader.GetInt32(0) & ": " & result2, SendBytes, tnSocket)
                    result2 = ""
                End While

                reader.Close()
            Catch ex As MySqlException
                Console.WriteLine("Error: " & ex.ToString())
            Finally
                conn.Close()
            End Try

            Return True
        End If
    End Function
End Class
