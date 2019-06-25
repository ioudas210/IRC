Imports MySql.Data.MySqlClient

Module DBModules
    Public Function PopulateListView(ByRef lstView As ListView, ByVal SQL As String, ByVal ColCount As Integer) As Boolean
        'FUNCTION NAME:PopulateListView
        'INPUT        :ListView,SQL,Column count for SQL
        'EXISTANCE    :Repopulates listview
        'OUTPUT       :SQL Results

        Dim li As New ListViewItem
        Dim x As Integer

        conn.ConnectionString = My.Settings.ConnStr
        lstView.Items.Clear()

        Try
            conn.Open()
            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader

                While myReader.Read
                    li = New ListViewItem
                    li.Text = nz(myReader.GetValue(0), "")
                    For x = 1 To ColCount - 1
                        li.SubItems.Add(nz(myReader.GetValue(x), ""))
                    Next
                    lstView.Items.Add(li)
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
    End Function

    Public Function PopulateComboBox(ByRef cmbBox As ComboBox, ByVal SQL As String, ByVal Col As String) As Boolean
        'FUNCTION NAME:PopulateComboBox
        'INPUT        :Combobox, SQL, Column
        'EXISTANCE    :Populates a combo box based on a sql column
        'OUTPUT       :SQL Results

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()
            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(myData)
                cmbBox.DataSource = myData
                cmbBox.DisplayMember = Col
                cmbBox.ValueMember = Col

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
            End Try

        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try

        Return True
    End Function

    Public Function PopulateGridView(ByRef grdView As DataGridView, ByVal SQL As String)
        'FUNCTION NAME:PopulateGridView
        'INPUT        :Grid View , SQL
        'EXISTANCE    :Repopulates gridview on sql string
        'OUTPUT       :SQL Results

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()
            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(myData)

                grdView.DataSource = myData
                grdView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

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


    Public Function SavePref(ByVal botID As Integer, ByVal SQL As String) As Boolean
        'FUNCTION NAME:SavePref
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Try
            If InsertRecords(SQL, "SavePref") Then

            End If
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function DelPref(ByVal botID As Integer, ByVal SQL As String) As Boolean
        'FUNCTION NAME: DelPref
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Try
            If DeleteRecords(SQL, "DelPref") Then

            End If
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function AddPref(ByVal botID As Integer, ByVal SQL As String) As Boolean
        'FUNCTION NAME: AddPref
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        Try
            If InsertRecords(SQL, "Add Pref") Then

            End If
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function CheckIfUserExists(ByVal UserName As String, ByVal SQL As String, ByVal botID As Integer) As Boolean
        'FUNCTION NAME:CheckIfUserExists
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

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
                If UserName = reply Then
                    CheckIfUserExists = True
                Else
                    CheckIfUserExists = False
                End If

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
                CheckIfUserExists = False
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
            CheckIfUserExists = False
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return CheckIfUserExists
    End Function

    Public Function DupeCheck(ByVal FieldName As String, ByVal SQL As String) As Boolean
        'FUNCTION NAME:DupeCheck
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

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
                If FieldName = reply Then
                    DupeCheck = True
                Else
                    DupeCheck = False
                End If

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
                DupeCheck = False
            End Try
        Catch myerror As MySqlException
            MsgBox("Error connecting to the database: " & myerror.Message)
            DupeCheck = False
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try
        Return DupeCheck
    End Function

    Public Function DelBotCmd(ByVal botID As Integer, ByVal SQL As String) As Boolean
        'FUNCTION NAME:DelBotCmd
        'INPUT        :
        'EXISTANCE    :333
        'OUTPUT       :

        Try
            If DeleteRecords(SQL, "DelBotCmd") Then

            End If
        Catch ex As Exception

        End Try

        Return True
    End Function

    Public Function AddBotCmd(ByVal botID As Integer, ByVal SQL As String) As Boolean
        'FUNCTION NAME:AddBotCmd
        'INPUT        :BotID, SQL as string
        'EXISTANCE    :Adds bot cmd to table
        'OUTPUT       :true if it executes

        Try
            If InsertRecords(SQL, "AddBotCmd") Then

            End If
        Catch ex As Exception

        End Try

        Return True
    End Function

    Public Function InsertRecords(ByRef SQL As String, ByVal ProgramPart As String) As Boolean
        'FUNCTION NAME:InsertRecords
        'INPUT        : 
        'EXISTANCE    :
        'OUTPUT       :

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
        myCommand.Connection = conn
        myCommand.CommandText = SQL
        Try
            conn.Open()
            myCommand.ExecuteNonQuery()

        Catch myerror As MySqlException
            Debug.Print(myerror.Message)
            'SendError(SQL, Date.Now, ProgramPart)
            'MsgBox("There was an error deleting from the database: " & myerror.Message)
            InsertRecords = False
        End Try
        If conn.State <> ConnectionState.Closed Then conn.Close()
        InsertRecords = True
        Return True
    End Function

    Public Function DeleteRecords(ByRef SQL As String, ByVal ProgramPart As String) As Boolean
        'FUNCTION NAME:DeleteRecords
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
        myCommand.Connection = conn
        myCommand.CommandText = SQL
        Try
            conn.Open()
            myCommand.ExecuteNonQuery()

        Catch myerror As MySqlException
            Debug.Print(myerror.Message)

            MsgBox("There was an error deleting from the database: " & myerror.Message)
            DeleteRecords = False
        End Try
        If conn.State <> ConnectionState.Closed Then conn.Close()
        DeleteRecords = True
    End Function

    Public Function UpdateRecords(ByRef SQL As String, ByVal ProgramPart As String) As Boolean
        'FUNCTION NAME: UpdateRecords
        'INPUT        : SQL as string, Program Part called as string (MUST BE CKEAN)
        'EXISTANCE    : UPDATE STATEMENT
        'OUTPUT       : True if executed false if problems ensued

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
        myCommand.Connection = conn
        myCommand.CommandText = SQL
        Try
            conn.Open()
            myCommand.ExecuteNonQuery()

        Catch myerror As MySqlException
            Debug.Print(myerror.Message)
            MsgBox("There was an error deleting from the database: " & myerror.Message)
            UpdateRecords = False
        End Try
        If conn.State <> ConnectionState.Closed Then conn.Close()
        UpdateRecords = True
   End Function

    Public Function GetField(ByVal SQL As String, ByVal FieldName As String, ByVal ProgramPart As String) As String
        'FUNCTION NAME: GetField
        'INPUT        :
        'EXISTANCE    :
        'OUTPUT       :

        GetField = ""
        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader

                While myReader.Read
                    GetField = nz(myReader.GetValue(0), "None")
                End While

            Catch myerror As MySqlException
                MsgBox("There was an error reading from the database: " & myerror.Message)
                GetField = "Error Reading " & ProgramPart
            End Try
        Catch myerror As MySqlException

            MsgBox("Error connecting to the database: " & myerror.Message)
            GetField = "Error Reading " & ProgramPart
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
        End Try

        Return GetField
    End Function

    Public Function RecordInsert(ByVal channel As String, ByVal NickName As String, ByVal Message As String, ByVal botID As Integer, ByVal Server As String) As Boolean
        'FUNCTION NAME: RecordInsert
        'INPUT        : Channel name, Nickname as string, Message, Bot ID as integer, server as string
        'EXISTANCE    : Record all traffic for later use
        'OUTPUT       : True if recorded false if not
        Try
            'RECORD INSERT FOR CHANNEL DATA
            SQL = "INSERT INTO tbluserchat(botid, channel, nick,Message,TheTime,Server)" _
             & "VALUES(" & botID & ", """ & channel & """, """ & NickName & """,""" & Message & """,""" & thetime & """,""" & Server & """)"

            If InsertRecords(SQL, "Record Insert") = False Then
                Debug.Print("WEE")

            End If
        Catch ex As Exception
            RecordInsert = False
        End Try
        RecordInsert = True
    End Function
End Module
