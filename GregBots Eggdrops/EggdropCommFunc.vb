﻿Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Module EggdropCommFunc
    Public Function RandomNumber(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer
        'FUNCTION NAME: RandomNumber
        'INPUT        : MaxNumber,MinNumber
        'EXISTANCE    : Gens random number
        'OUTPUT       : A random number

        'initialize random number generator
        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If
        Return rndNum.Next(MinNumber, MaxNumber)
    End Function



    Public Function repByCtrlGrp(ByRef controlG As Control, ByVal RepChar As String, ByVal Clear As Boolean) As Boolean
        'FUNCTION NAME: repByCtrlGrp
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Dim ctrl As Control
        For Each ctrl In controlG.Controls
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox Then
                Debug.Print(ctrl.Text)
            End If
        Next
    End Function

    Public Function GetBotID(ByVal BotName As String) As Long
        'FUNCTION NAME: GetBotID
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        SQL = "SELECT IDNUM FROM tblbots WHERE BotName=""" & QueryClean(BotName) & """"
        'GetField(SQL, "IDNUM", "GetBotID")

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader

                While myReader.Read
                    GetBotID = nz(myReader.GetValue(0), "")
                End While

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return GetBotID
    End Function

    Public Function AddProtect(ByVal Username As String, ByVal BotID As String, ByVal BotName As String, Optional ByVal AccessType As String = "None", Optional ByVal Channel As String = "#None") As Boolean
        'FUNCTION NAME: AddProtect
        'INPUT        :Adds user to protect list
        'EXISTANCE    :
        'OUTPUT       :

        Dim TheNick

        If RegXPChecker(A2ZRegex, Username) Then
            'MAKE DB CALL
            TheNick = Username

            If RegXPChecker(A2ZChanRegex, nz(Channel, "")) Then
                SQL = "INSERT INTO tblopprotectlist(botid, UserName, Channel,AccessType,BotName)" _
                 & "VALUES(" & BotID & ",""" & Username & """,""" & Channel & """, """ & AccessType & """,""" & BotName & """)"
            Else
                SQL = "INSERT INTO tblopprotectlist(botid, UserName, AccessType,BotName)" _
              & "VALUES(" & BotID & ",""" & TheNick & """, """ & AccessType & """,""" & BotID & """)"
            End If

            If InsertRecords(SQL, "Add Protect") = False Then
                Return False
            End If
        Else
            MsgBox("Please enter a valid server name")
            Return False
        End If
        Return True
    End Function

    Public Function IsValidChannel(ByVal ChannelStr As String) As Boolean
        If InStr(ChannelStr, "#") > 0 And Len(ChannelStr) >= 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DelProtect(ByVal Username As String, ByVal BotID As String, Optional ByVal AccessType As String = "", Optional ByVal Channel As String = "") As Boolean
        'FUNCTION NAME: DelProtect
        'INPUT        : UserName as String, BotName,
        'EXISTANCE    :
        'OUTPUT       :

        If RegXPChecker(A2ZRegex, Username) Then
            'MAKE DB CALL
            If Not AccessType = "" Then
                SQL = "DELETE FROM tblopprotectlist WHERE botid=" & BotID & " AND AccessType=""" & QueryClean(AccessType) & """ AND UserName=""" & QueryClean(Username) & """"
            Else
                SQL = "DELETE FROM tblopprotectlist WHERE botid=" & BotID & " AND UserName=""" & QueryClean(Username) & """"
            End If

            If DeleteRecords(SQL, "Del Protect") = False Then
                Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function AddChan(ByVal channel As String, ByVal AutoOp As String, ByVal botID As String) As Boolean
        'FUNCTION NAME: AddChan
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :


        SQL = "INSERT INTO tblchannellist(botid, channelname, AutoOp)" _
         & "VALUES(" & botID & ", """ & channel & """, """ & AutoOp & """)"

        If InsertRecords(SQL, "Add chan") = False Then
            Return False
        End If
   

    End Function

    Public Function DelChan(ByVal channel As String, ByVal botID As String) As Boolean
        'FUNCTION NAME: DelChan
        'INPUT        :Channel as string, BotID as string
        'EXISTANCE    : Deletes a channel by botID from the autojin
        'OUTPUT       : True if it has deleted a record


        'MAKE DB CALL
        SQL = "DELETE FROM tblchannellist WHERE botID=" & botID & " AND channelname=""" & QueryClean(channel) & """"
        If DeleteRecords(SQL, "Del chan") = False Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function Wait(ByVal PMillseconds As Integer) As Boolean
        'FUNCTION NAME: Wait
        'INPUT        :Miliseconds as integer
        'EXISTANCE    :To act as a pause function
        'OUTPUT       :A timer based wait where gui still works. True if executed

        Dim TimeNow As DateTime
        Dim TimeEnd As DateTime
        Dim StopFlag As Boolean

        Try
            TimeEnd = Now()
            TimeEnd = TimeEnd.AddMilliseconds(PMillseconds)
            StopFlag = False

            While Not StopFlag
                TimeNow = Now()
                If TimeNow > TimeEnd Then
                    StopFlag = True
                End If
                Application.DoEvents()
            End While

            TimeNow = Nothing
            TimeEnd = Nothing
        Catch
            Return False
        End Try
        Return True
    End Function

    Public Function RegXPChecker(ByRef regEXStr As String, ByVal InputVal As String) As Boolean
        'FUNCTION NAME: RegXPChecker
        'INPUT        :Regex String, Input Value to check
        'EXISTANCE    : Text verification
        'OUTPUT       : True if it matches false if it doesnt

        Dim regexp As New Regex(regEXStr)
        If regexp.IsMatch(InputVal) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AddServer(ByVal server As String, ByVal botID As String, ByVal Port As String, ByVal Active As Integer, ByVal Reconnect As Integer) As Boolean
        'FUNCTION NAME: AddServer
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        If Len(server) = 0 Then
            Return False
        End If

        'MAKE DB CALL

        SQL = "INSERT INTO tblserverlist(botid, ServerIP, Port,Reconnect,Active)" _
         & "VALUES(" & botID & ", """ & server & """, """ & Port & """,""" & Reconnect & """,""" & Active & """)"
        If InsertRecords(SQL, "Add server") = False Then
            Return False
        Else
            Debug.Print("Wee")
        End If
        Return True
    End Function

    Public Function DelServer(ByVal Server As String, ByVal botID As String) As Boolean
        'FUNCTION NAME: DelServer
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        If RegXPChecker(A2ZChanRegex, Server) Then

            SQL = "DELETE FROM tblserverList WHERE botID=" & botID & " AND ServerIP=""" & QueryClean(Server) & """"
            If DeleteRecords(SQL, "Delete Server") = False Then
                Return False
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetIP(ByVal Addy As String, ByRef anaddress As IPAddress) As Boolean
        'FUNCTION NAME: GetIP
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Dim tmpAddy As String = nz(Addy, "")

        Try
            anaddress = System.Net.Dns.GetHostEntry(tmpAddy).AddressList(1)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function nz(ByVal InputVal As Object, ByVal NullValue As Object) As Object
        'FUNCTION NAME: nz
        'INPUT        : Input Value, Value if null
        'EXISTANCE    : Checks nulls in "" or system.db.null and lets you change the type
        'OUTPUT       : The value if its a real value or your specified null

        If IsDBNull(InputVal) Then
            nz = NullValue
            Return nz
        Else
            Return InputVal
        End If

        System.Convert.ToString(InputVal)
        If InputVal = "" Then
            Return NullValue
        End If

    End Function

    Public Function GenerateHashMD5(ByVal SourceText As String) As String
        'FUNCTION NAME: GenerateHash
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Function IrcInputCheck(ByVal InputVal As String, ByVal Regex As String) As Boolean
        'FUNCTION NAME:IrcInputCheck
        'INPUT        :Input from a server and a regex
        'EXISTANCE    :Specialized form of regxpcheck
        'OUTPUT       :true or false if its irc based

        Try
            If RegXPChecker(Regex, InputVal) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return True
    End Function

    Public Function SendInfo(ByVal command As String, ByRef SendBytes As [Byte](), ByRef tnSocket As Socket) As Boolean
        'FUNCTION NAME: SendInfo
        'INPUT        : Command as string, Sendbytes as a byte arry, a socket by ref
        'EXISTANCE    : Sends command via socket. Univerial send
        'OUTPUT       : True

        Try
            Debug.Print(command)
            Wait(2000)
            SendBytes = Encoding.ASCII.GetBytes(command & vbCrLf)
            tnSocket.Send(SendBytes, SendBytes.Length, SocketFlags.None)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function QueryClean(ByVal InputStr As String) As Object
        'FUNCTION NAME: QueryClean
        'INPUT        : Input String
        'EXISTANCE    : Cleans text for db insert
        'OUTPUT       : Clean String

        InputStr = Replace(InputStr, "\", "\\")
        InputStr = Replace(InputStr, Chr(34), "\""")
        InputStr = Replace(InputStr, "'", "\'")
        InputStr = Replace(InputStr, "=", "\=")
        InputStr = Replace(InputStr, "--", "\--")
        InputStr = Replace(InputStr, "-", "\-")
        InputStr = Replace(InputStr, ".", "\.")
        Return InputStr
    End Function

    Function GenerateHash(ByVal strToHash As String) As String
        'FUNCTION NAME: GenerateHash
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Dim sha1Obj As New SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    Public Function CenterMe(ByRef frm As Form) As Boolean
        'FUNCTION NAME: CenterMe
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        'CenterMe.Left = (Screen.Width - frmSampApplication.Width) / 2
        'CenterMe.Top = (Screen.Width - frmSampApplication.Height) / 2
        Return True
    End Function

    Public Function FormIsLoaded(ByVal FormName As String) As Boolean
        'FUNCTION NAME: FormIsLoaded
        'INPUT        :Formname
        'EXISTANCE    :Determines if a form is open
        'OUTPUT       : True or false   

        Dim formTitles As New Collection

        Try
            For Each f As Form In My.Application.OpenForms
                Debug.Print(f.Name)
                If f.Name = "ControlCenter" Then
                    Return True
                End If
            Next
        Catch ex As Exception
            formTitles.Add("Error: " & ex.Message)
        End Try
        Return False
    End Function
End Module
