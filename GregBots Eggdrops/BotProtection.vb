Imports MySql.Data.MySqlClient
Imports System.Net.Sockets

Public Class BotProtection
    Public Channel As String
    Public Reop As Boolean
    Public IssuerNick As String

    Public Function ReopFunc(ByVal Channel As String, ByVal Reop As Boolean, ByRef IrcSocket As Socket, ByRef SendBytes As [Byte]()) As Boolean
        'FUNCTION NAME:ReopFunc
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Try
            SendInfo("MODE " & Channel & " -b " & Channel & "@", SendBytes, IrcSocket)
        Catch ex As Exception

        End Try
    End Function
    Public Function UnBan(ByVal Channel As String, ByVal Reop As Boolean, ByRef IrcSocket As Socket, ByRef SendBytes As [Byte](), ByVal hostmask As String) As Boolean
        'FUNCTION NAME:UnBan
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Try
            SendInfo("MODE " & Channel & " -b " & hostmask & "@", SendBytes, IrcSocket)
        Catch ex As Exception

        End Try
    End Function
    Public Function DetectBanAgainstMe(ByVal Channel As String, ByVal Reop As Boolean, ByRef IrcSocket As Socket, ByRef SendBytes As [Byte](), ByVal hostmask As String) As Boolean
        'FUNCTION NAME:DetectBanAgainstMe
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Try
            SendInfo("MODE " & Channel & " -b " & hostmask & "@", SendBytes, IrcSocket)
        Catch ex As Exception

        End Try
    End Function

    Public Function DetermineChannelJoin(ByVal BotID As String, ByVal Channel As String) As Boolean
        'FUNCTION NAME:DetermineChannelJoin
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        SQL = "SELECT Rejoin FROM tblchannellist WHERE BotID=" & BotID & " AND Rejoin=1 AND ChannelName=""" & Channel & """"

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

                If reply = 1 Then
                    DetermineChannelJoin = True
                Else
                    DetermineChannelJoin = False
                End If

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
                DetermineChannelJoin = False
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
            DetermineChannelJoin = False
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try

        Return DetermineChannelJoin
    End Function
End Class
