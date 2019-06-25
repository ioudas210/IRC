﻿Imports MySql.Data.MySqlClient

Public Class BasicSettings
    Dim FormTimerStopWatch As New Stopwatch
    Dim eg As New EggDropBotClasses
    Dim BotName As String
    Dim botId As Long
    Dim OpList As String
    Dim Master As String
    Dim OPListProtect As Long
    Dim ChannelListID As Long
    Dim ResponseList As Long
    Dim VoiceList As Long

    Public Sub AssignValues()
        SQL = "SELECT tblserverlist.BotID,tblbots.Master,tblbots.BotName,tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID WHERE tblserverlist.Active=0"
        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader

                While myReader.Read
                    Debug.Print(nz(myReader.GetValue(0), ""))
                    Debug.Print(nz(myReader.GetValue(1), ""))
                    txtMasterNick.Text = nz(myReader.GetValue(1), "")
                    txtServer.Text = nz(myReader.GetValue(3), "")
                    txtCmdPrefix.Text = nz(myReader.GetValue(5), "")
                    txtBotName.Text = nz(myReader.GetValue(2), "")
                    txtAuth.Text = nz(myReader.GetValue(6), "")

                    If nz(myReader.GetValue(7), 0) = "0" Then
                        chkProtectList.Checked = False
                    Else
                        chkProtectList.Checked = True
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
    End Sub

    Private Sub BasicSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim myfrm As New ControlCenter
        myfrm.Show()
    End Sub

    Private Sub BasicSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID"
        PopulateListView(lstBotList, SQL, 7)
    End Sub

    Private Sub EditCurrentProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCurrentProfileToolStripMenuItem.Click

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProfileToolStripMenuItem.Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myfrm As New About
    End Sub

    Private Sub btnChannelList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChannelList.Click
        If lstBotList.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        CurrBotName = lstBotList.SelectedItems(0).SubItems(1).Text
        Dim myfrm As New ChannelList
        myfrm.Show()
    End Sub

    Private Sub btnAddProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProfile.Click
        Dim li As ListViewItem

        If txtBotName.Text = "" Then
            Exit Sub
        End If

        For Each li In lstBotList.Items
            If li.SubItems(0).Text = txtBotName.Text Then
                MsgBox("You cannot join the same channel twice")
                Exit Sub
            End If
        Next

        If RegXPChecker(A2ZRegex, txtMasterNick.Text) = False Then
            Exit Sub
        End If

        If RegXPChecker(A2ZRegex, txtServer.Text) Then
            'Exit Sub
        End If

        If Len(txtCmdPrefix.Text) > 1 Then
            Exit Sub
        End If


        If txtAuth.Text = "" Then
            Exit Sub
        End If

        If RegXPChecker(A2ZRegex, txtMasterNick.Text) Then
            'MAKE DB CALL
            Dim AuthCmd As String
            Dim Pass As String

            BotName = txtBotName.Text
            Master = txtMasterNick.Text
            OpList = 0
            OPListProtect = 0
            ChannelListID = 0
            AuthCmd = txtAuth.Text
            Pass = GenerateHash(txtPassword.Text)

          
            SQL = "INSERT INTO tblserverlist(ServerIP,Port,BotID,Reconnect,Active,Ident,Prefix)" _
             & "VALUES(""" & QueryClean(txtServer.Text) & """, " & 6667 & ", " & CurrBotID & "," & 1 & _
             ",0,""" & txtAuth.Text & """,""" & txtCmdPrefix.Text & """)"

            Debug.Print(SQL)

            If InsertRecords(SQL, "Add Server Profile") = False Then

            End If
        Else
            MsgBox("Please enter a valid master name")
            Exit Sub
        End If

        lstBotList.Items.Clear()
        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID"
        PopulateListView(lstBotList, SQL, 7)
    End Sub

    Private Sub btnRemoveProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveProfile.Click
        Dim li As ListViewItem

        For Each li In lstBotList.Items
            If li.Text = lstBotList.Text Then
                MsgBox("You cannot join the same channel twice")
                Exit Sub
            End If
        Next

        'MAKE SURE IT IS A VALID CHANNEL
        If txtBotName.Text = "" Then
            Exit Sub
        End If

        If RegXPChecker(A2ZChanRegex, txtBotName.Text) And RegXPChecker(A2ZCmdRegex, txtServer.Text) Then
            'MAKE DB CALL
            SQL = "DELETE FROM tblBots WHERE BotName=""" & lstBotList.SelectedItems(0).SubItems(1).Text & """"

            If DeleteRecords(SQL, "Basic Settings Remove Bot") = False Then
                Exit Sub
            End If

        Else
            MsgBox("Please enter a valid channel name")
            Exit Sub
        End If

        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID"
        PopulateListView(lstBotList, SQL, 7)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBotName.Text = ""
        txtAuth.Text = ""
        txtCmdPrefix.Text = ""
        txtServer.Text = ""
        txtMasterNick.Text = ""
        txtPassword.Text = ""
        chkProtectList.Checked = False
        ChkReconnect.Checked = False
    End Sub

    Private Sub lstBotList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstBotList.Click
        txtBotName.Text = ""
        txtMasterNick.Text = ""
        txtAuth.Text = ""
        txtServer.Text = ""
        chkProtectList.Checked = False
        If lstBotList.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        botId = lstBotList.SelectedItems(0).Text
        AssignValues()
    End Sub

    Private Sub lstBotList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBotList.SelectedIndexChanged
        Call lstBotList_Click(sender, e)
    End Sub

    Private Sub btnServerList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServerList.Click
        If lstBotList.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        CurrBotName = lstBotList.SelectedItems(0).SubItems(1).Text
        Dim myfrm As New ServerList
        myfrm.Show()
    End Sub

    Private Sub btnAccessList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccessList.Click
        If lstBotList.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim myfrm As New BotLevelList
        myfrm.Show()
    End Sub

    Private Sub btnGrpAuth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpAuth.Click
        If lstBotList.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim myfrm As New BotGroupLevels
        myfrm.Show()
    End Sub
End Class