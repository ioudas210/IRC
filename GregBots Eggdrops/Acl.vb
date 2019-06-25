﻿Imports MySql.Data.MySqlClient

Public Class Acl
    Public Function UserStatusLevel(ByVal nickname As String, ByVal BotID As String) As Object
        'FUNCTION NAME:UserStatusLevel
        'INPUT        :Nick Name, BotID
        'EXISTANCE    :Checks Level for a user
        'OUTPUT       :Level Result

        SQL = "SELECT Level FROM tblAcl WHERE BotID=" & BotID & " AND UserAccessName =""" & QueryClean(nickname) & """"
        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader
                Dim reply As String = ""
                While myReader.Read
                    reply = nz(myReader.GetValue(1), 0)
                End While

                If reply > 0 Then
                    UserStatusLevel = True
                Else
                    UserStatusLevel = False
                End If

            Catch myerror As MySqlException
                UserStatusLevel = False
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try
        Catch myerror As MySqlException
            UserStatusLevel = False
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return UserStatusLevel
    End Function

    Public Function PasswordVerification(ByVal UserName As String, ByVal BotID As Integer, ByVal Pass As String) As Boolean
        'FUNCTION NAME:PasswordVerification
        'INPUT        :UserName, BotID, Pass
        'EXISTANCE    :Checks against the db pass 
        'OUTPUT       :True or False depending if they got it right


        UserName = QueryClean(UserName)

        SQL = "SELECT Password FROM tblAuth WHERE BotID=" & BotID & " AND UserName =""" & UserName & """"
        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader
                Dim reply As String = ""
                While myReader.Read
                    reply = nz(myReader.GetValue(0), 0)
                End While

                If Pass = reply Then
                    PasswordVerification = True
                Else
                    PasswordVerification = False
                End If

            Catch myerror As MySqlException
                PasswordVerification = False
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try

        Catch myerror As MySqlException
            PasswordVerification = False
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return PasswordVerification
    End Function

    Public Function GetUserInfo(ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String) As Boolean
        'FUNCTION NAME:GetUserInfo
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :



        UserName = QueryClean(UserName)
        SQL = "SELECT IDNum,BotName,BotID,UserAccessName,Level FROM tblacl WHERE BotId=" & BotID
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

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
    End Function

    Public Function SetUserPriv(ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String) As Boolean
        'FUNCTION NAME:SetUserPriv
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        UserName = QueryClean(UserName)

        SQL = "SELECT IDNum,BotName,BotID,UserAccessName,Level FROM tblacl WHERE BotId=" & BotID
        If CheckIfUserExists(UserName, SQL, BotID) Then
        Else
        End If

        'SQL = "UPDATE INTO tbluserchat(botid, channel, nick,Message,TheTime)" _
        ' & "VALUES(" & CurrBotID & ", """ & channel & """, """ & nickname & """,""" & Message & """,""" & thetime & """)"

        myCommand.CommandText = SQL

        Try
            conn.Open()
            myCommand.ExecuteNonQuery()
        Catch myerror As MySqlException
            SetUserPriv = False
            Debug.Print(myerror.Message)
            MsgBox("There was an error updating the database: " & myerror.Message)
        End Try

        If conn.State <> ConnectionState.Closed Then conn.Close()
        conn = Nothing
        myCommand = Nothing
        SetUserPriv = True

        Return SetUserPriv
    End Function

    Public Function AddUserLevel(ByVal UserName As String, ByVal BotID As String, ByVal ChannelName As String, ByVal BotName As String, ByVal Level As String, ByVal server As String) As String
        'FUNCTION NAME:AddUserLevel
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        UserName = QueryClean(UserName)
        Level = QueryClean(Level)
        ChannelName = QueryClean(ChannelName)
        server = QueryClean(server)
        SQL = "SELECT UserName FROM tblauth WHERE UserName=""" & UserName & """ AND BotId=" & BotID
        If Not CheckIfUserExists(UserName, SQL, BotID) = False Then
        Else

            SQL = "INSERT INTO tblauth(botid, UserName, IsAuthed,LockedTries,Password)" _
            & "VALUES(" & BotID & ", """ & UserName & """," & 0 & "," & 5 & ",""" & "Default" & """)"

            If InsertRecords(SQL, "Add User Auth") = False Then
                AddUserLevel = "False"
                Return AddUserLevel
            End If
        End If

        SQL = "SELECT UserAccessName FROM tblacl WHERE UserAccessName=""" & UserName & """ AND Channel=""" & ChannelName & """ AND BotId=" & BotID
        If CheckIfUserExists(UserName, SQL, BotID) Then
            AddUserLevel = ("PRIVMSG " & ChannelName & " :Updating User level " & Level & " for user: " & UserName & vbCrLf)
            SQL = "UPDATE tblacl SET botID=" & BotID & ",BotName=""" & BotName & """, UserAccessName=""" & UserName & """,Level=""" & Level & """,server=""" & server & """ WHERE BotID=" & BotID & " AND UserAccessName=""" & QueryClean(UserName) & """"
        Else
            AddUserLevel = ("PRIVMSG " & ChannelName & " :User " & UserName & " does not exist creating level: " & Level & " for " & UserName & vbCrLf)
            SQL = "INSERT INTO tblacl(botid, BotName, UserAccessName,Level,Channel,Server)" _
            & "VALUES(" & BotID & ", """ & BotName & """, """ & UserName & """,""" & Level & """,""" & ChannelName & """,""" & server & """)"
        End If

        If InsertRecords(SQL, "Add User Level") = False Then
            AddUserLevel = "False"
        End If
        Return AddUserLevel
    End Function

    Public Function AddUserGroup(ByVal BotName As String, ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String, ByVal GroupName As String, ByVal server As String) As String
        'FUNCTION NAME:AddUserGroup
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        GroupName = QueryClean(GroupName)
        UserName = QueryClean(UserName)

        SQL = "SELECT UserName FROM tblauth WHERE UserName=""" & QueryClean(UserName) & """ AND BotId=" & BotID
        If Not CheckIfUserExists(UserName, SQL, BotID) = False Then
            Debug.Print(UserName)
        Else
            AddUserGroup = ("PRIVMSG " & ChannelName & " :User does not exist for this level. Now Creating " & UserName & vbCrLf)
            SQL = "INSERT INTO tblAuth(botid, UserName, IsAuthed,LockedTries,Password)" _
           & "VALUES(" & BotID & ", """ & UserName & """, " & 0 & ", " & 5 & ",""" & "Default" & """)"

            If InsertRecords(SQL, "Add User Auth") = False Then
                AddUserGroup = "False"
                Return AddUserGroup
            End If
        End If

        SQL = "SELECT UserName FROM tblaclbygroup WHERE BotId=" & BotID & " AND BotGroup=""" & QueryClean(GroupName) & """ AND UserName=""" & QueryClean(UserName) & """"
        If CheckIfUserExists(UserName, SQL, BotID) Then
            AddUserGroup = ("PRIVMSG " & ChannelName & " :Updating User group " & GroupName & " for " & UserName & vbCrLf)

            SQL = "UPDATE tblaclbygroup SET botID=" & BotID & ",BotName=""" & BotName & """, BotGroup=""" & GroupName & """,UserName=""" & UserName & """ WHERE BotID=" & BotID & " AND UserName=""" & QueryClean(UserName) & """"
            If UpdateRecords(SQL, "Add User Group") = False Then
                AddUserGroup = "False"
            End If
        Else
            AddUserGroup = ("PRIVMSG " & ChannelName & " :User does not exist for this group. Now creating " & GroupName & " for " & UserName & vbCrLf)

            SQL = "INSERT INTO tblaclbygroup(botid, BotName, UserName,BotGroup)" _
           & "VALUES(" & BotID & ", """ & BotName & """,""" & QueryClean(UserName) & """,""" & QueryClean(GroupName) & """)"
            If InsertRecords(SQL, "Add User Group") = False Then
                AddUserGroup = "False"
            End If
        End If

        Return AddUserGroup
    End Function

    Public Function DelUserGroup(ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String, ByVal GroupName As String) As Boolean
        'FUNCTION NAME:DelUserGroup
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :
        UserName = QueryClean(UserName)
        GroupName = QueryClean(GroupName)

        SQL = "DELETE FROM tblaclbygroup WHERE BotID=" & BotID & " AND UserName=""" & UserName & """ AND GroupName=""" & GroupName & """"

        If DeleteRecords(SQL, "Del User Group") = False Then

        End If

    End Function

    Public Function IsUserAuthed(ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String) As Boolean
        'FUNCTION NAME:IsUserAuthed
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :



        SQL = "SELECT IsAuthed FROM tblAuth WHERE UserName=""" & QueryClean(UserName) & """ AND BotID=" & BotID
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
                If "1" = reply Then
                    IsUserAuthed = True
                Else
                    IsUserAuthed = False
                End If

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
                IsUserAuthed = False
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
            IsUserAuthed = False
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return IsUserAuthed
    End Function

    Public Function DelUserLevel(ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String) As Boolean
        'FUNCTION NAME:DelUserLevel
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        SQL = "SELECT IDNum,BotName,BotID,UserAccessName,Level FROM tblacl WHERE BotId=" & BotID
        If CheckIfUserExists(UserName, SQL, BotID) Then
        Else
        End If

        SQL = "DELETE FROM tblacl WHERE BotID=" & BotID & " AND UserName=""" & QueryClean(UserName) & """"
        If DeleteRecords(SQL, "Del UserLevel") = False Then
        End If

        Return DelUserLevel
    End Function

    Public Function IsMaster(ByVal UserName As String, ByVal BotID As Integer) As Boolean
        'FUNCTION NAME:IsMaster
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        SQL = "SELECT IDNum,Master FROM tblbots WHERE IDNum=" & BotID
        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader
                Dim reply As String = ""
                While myReader.Read
                    reply = nz(myReader.GetValue(1), "None")
                End While

                If UserName = reply Then
                    IsMaster = True
                Else
                    IsMaster = False
                End If
            Catch myerror As MySqlException
                IsMaster = False
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try
        Catch myerror As MySqlException
            IsMaster = False
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try

        Return IsMaster
    End Function

    Public Function GetUserPass(ByVal UserName As String, ByVal BotID As Integer, ByVal Pass As String) As Boolean
        'FUNCTION NAME:GetUserPass
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        SQL = "SELECT IDNum,BotName,BotID,UserAccessName,Level FROM tblacl WHERE BotId=" & BotID & " AND UserAccessName=""" & QueryClean(UserName) & """"
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

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
    End Function

    Public Function BotCmdLevelAdd(ByVal BotId As String, ByVal Cmd As String, ByVal Usage As String, ByVal Syntax As String, ByVal Prefix As String, ByVal Level As String, ByVal Group As String) As Boolean
        'FUNCTION NAME:BotCmdLevelAdd
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        If nz(Cmd, "") = "" Then
            BotCmdLevelAdd = False
            Return BotCmdLevelAdd
        End If
        Cmd = QueryClean(Cmd)
        Usage = QueryClean(Usage)
        Syntax = QueryClean(Syntax)
        Prefix = QueryClean(Prefix)

        SQL = "SELECT Count(idnum) FROM tblbotcmdlist WHERE BotId=" & BotId & " AND Command=""" & Cmd & """"

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader
                Dim reply As String = ""
                While myReader.Read
                    reply = nz(myReader.GetValue(0), 0)
                End While

                If reply > 0 Then
                    BotCmdLevelAdd = False
                    Return BotCmdLevelAdd
                End If
            Catch myerror As MySqlException
                'MsgBox("There was an error reading from the database: " & myerror.Message)
                BotCmdLevelAdd = False
            End Try
        Catch myerror As MySqlException
            'msgbox("Error connecting to the database: " & myerror.Message)
            BotCmdLevelAdd = False
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try


        SQL = "INSERT INTO tblbotcmdlist(botid, Command, Usage,Syntax,CmdPrefix,Level,Group)" _
        & "VALUES(" & BotId & ", """ & Cmd & """, """ & Usage & """,""" & Syntax & """,""" & _
        Prefix & """,""" & Level & """,""" & Group & """)"

        If InsertRecords(SQL, "Bot Cmd Level Add") = False Then
            BotCmdLevelAdd = False
        End If
        Return BotCmdLevelAdd
    End Function

    Public Function SetUserPass(ByVal UserName As String, ByVal BotID As Integer, ByVal ChannelName As String, ByVal Pass As String) As Boolean
        'FUNCTION NAME:SetUserPass
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        SQL = "SELECT IDNum,BotName,BotID,UserAccessName,Level FROM tblacl WHERE BotId=" & BotID
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

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
    End Function
End Class
