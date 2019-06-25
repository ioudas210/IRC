﻿Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class ControlCenter
    Public addy As IPAddress
    Dim FormTimerStopWatch As New Stopwatch
    Dim SelectedBotName As String = ""

    Public Sub LoadBotCmds(ByVal BotName As String)
        SQL = "SELECT IDNUM FROM tblbotcmdlist WHERE BotID=""" & GetBotID(BotName) & """"

        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)

        Try
            conn.Open()

            Try
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myReader = myCommand.ExecuteReader

                lstBotCmds.Items.Clear()
                While myReader.Read

                    lstBotCmds.Items.Add(nz(myReader.GetValue(0), ""))
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

    Private Sub ControlCenter_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQL = "UPDATE tblserverlist SET Active=" & 0
        UpdateRecords(SQL, "End Form Close")
        End
    End Sub

    Private Sub ControlCenter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'EDIT THIS IF YOUR INITIAL DB SERVER STRING IS messed
        'My.Settings.ConnStr = des.Encrypt('YOUR DB STRING HERE')
        'My.Settings.Save()


        'ALLOWS TEXTBOT TO BE APPENDED TO FROM THREAD & START PROGRAM CHECKS

        FormTimerStopWatch.Start()
        Control.CheckForIllegalCrossThreadCalls = False

        'DEFAULT THREAD KILL
        My.Settings.KillID = 0
        My.Settings.Save()

        'LOAD UP INACTIVE EGGDROPS
        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID WHERE tblserverlist.Active=0"
        PopulateListView(lstInactiveEggdrops, SQL, 7)

        'LOAD UP PLUGINS

        'LOAD UP ACTIVE BOTS (SHOULD BE ZERO IF INITAL APP HAS STARTED)

        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID WHERE tblserverlist.Active=1"
        PopulateListView(lstActiveEggdrops, SQL, 7)

        'LOAD UP STATS

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        'First minimize the form  
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        NtIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        NtIcon.Icon = New Icon("c:\gregbottrayicon.ico")

        ' appear when the systray icon is right clicked.
        NtIcon.ContextMenuStrip = Me.ContextMenuStrip1
        ' The Text property sets the text that will be displayed in a tooltip, when the mouse hovers over the systray icon.
        NtIcon.Text = "Easy Win Drop"
        NtIcon.Visible = True
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        'STATUS: COMPLETED
        Dim myfrm As New About
        myfrm.Show()
    End Sub

    Private Sub DatabaseSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseSettingsToolStripMenuItem.Click
        'STATUS: COMPLETED
        Dim myfrm As New DatabaseSettings
        myfrm.Show()
        Me.Hide()
    End Sub

    Private Sub EndToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndToolStripMenuItem.Click
        End
    End Sub

    Private Sub FileToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem1.Click
        Me.Visible = True
        NtIcon.Visible = False
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub btnInactiveStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactiveStart.Click
        
        'MAKE SURE THEY SELECTED SOMETHING
        If lstInactiveEggdrops.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim cn As New EggDropBotClasses
        Dim server As String
        Dim x As System.Threading.Thread
        Dim intI As Integer = 0
        Dim lstStuff As New ListViewItem

        server = lstInactiveEggdrops.SelectedItems(0).SubItems(2).Text
        GetIP(server, addy)
        PPort = lstInactiveEggdrops.SelectedItems(0).SubItems(3).Text
        currServer = System.Convert.ToString(addy)

        If currServer = "" Then
            MsgBox("Invalid server IP")
            Exit Sub
        End If

        'ASSIGN BOT INFO TO ENGINE THREAD FROM INACTIVE BOT
        cn.TheTextBox = TextBox1
        cn.LocalFirstSW = True
        cn.ChannelJoinSW = True

        'Debug.Print(lstInactiveEggdrops.SelectedItems(0).SubItems(4).Text)
        cn.ExitSW = IIf(lstInactiveEggdrops.SelectedItems(0).SubItems(5).Text = 0, True, False)
        cn.Record = True
        cn.cmdPrefix = lstInactiveEggdrops.SelectedItems(0).SubItems(4).Text
        cn.MasterAuth = False
        CurrBotName = lstInactiveEggdrops.SelectedItems(0).SubItems(1).Text
        cn.BotName = CurrBotName
        cn.BotID = lstInactiveEggdrops.SelectedItems(0).Text
        cn.ServerName = server
      
        'START THREAD
        x = New Thread(AddressOf cn.ConnectBot)
        x.Start()

        cn.ThreadID = x.GetHashCode

        'UPDATE BOT DB
        SQL = "UPDATE tblserverlist SET Active =" & 1 & " WHERE BotID = " & cn.BotID & " AND ServerIP=""" & server & """"
        If UpdateRecords(SQL, "Control Center Start Bot") = False Then

        End If

        CurrThread = x.GetHashCode
        server = Nothing
        addy = Nothing

        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID WHERE tblserverlist.Active=1"
        PopulateListView(lstActiveEggdrops, SQL, 7)

        cn = Nothing
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim li As ListViewItem
        Dim eg As New EggDropBotClasses

        'THIS DETERMINES IF A BOT HAS BEEN DISCONNECTED
        If RegXPChecker(closingstr, nz(TextBox1.Text, "")) Then
            Dim re As New Regex(closingstr)
            Dim mt As Match
            mt = re.Match(TextBox1.Text)
            Dim key
            key = mt.Groups("key").ToString
            mt = Nothing
            re = Nothing

            For Each li In lstActiveEggdrops.Items
                'IF THREAD IS ONE WERE LOOKING FOR UPDATE DB REFRESH LISTS

                If li.SubItems(2).Text Like key Then
                    SQL = "UPDATE tblbots SET tblbots.Active=" & 0 & ", ThreadID=0 WHERE IDNum=" & GetBotID(li.Text) & ""
                    If UpdateRecords(SQL, "Control Center Set Active Bot") = False Then

                    End If

                    li.Remove()
                    PopulateListView(lstInactiveEggdrops, "SELECT idnum,BotName,Server,CmdPrefix,Reconnect FROM tblbots WHERE ACTIVE=0", 5)
                    TextBox1.Text = ""
                End If
            Next

        End If
    End Sub

    Private Sub btnActiveDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActiveDisconnect.Click
        If lstActiveEggdrops.SelectedItems.Count > 0 Then
            'PANEL KILL UPDATE DB WHERE BOT IS TO INACTIVE
            SQL = "UPDATE tblbots SET tblbots.Active=" & 0 & " WHERE IDNum=" & lstActiveEggdrops.SelectedItems(0).Text & ""
            If UpdateRecords(SQL, "Control Center Disconnect") = False Then

            End If

            ThreadKillID = lstActiveEggdrops.SelectedItems(0).Text
            lstActiveEggdrops.SelectedItems(0).Remove()
            SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID"
            PopulateListView(lstInactiveEggdrops, SQL, 7)

            'PopulateListView(lstActiveEggdrops, "SELECT idnum,BotName,ThreadID,CmdPrefix FROM tblbots WHERE ACTIVE=1", 4)
        End If
    End Sub

    Private Sub lstActiveEggdrops_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstActiveEggdrops.SelectedIndexChanged
        If lstActiveEggdrops.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        LoadBotCmds(lstActiveEggdrops.SelectedItems(0).Text)
    End Sub

    Private Sub lstInactiveEggdrops_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInactiveEggdrops.Click
        If lstInactiveEggdrops.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        LoadBotCmds(lstInactiveEggdrops.SelectedItems(0).SubItems(1).Text)
    End Sub

    Private Sub btnInactiveEggDropRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactiveEggDropRefresh.Click
        PopulateListView(lstInactiveEggdrops, "SELECT idnum,BotName,Server,CmdPrefix,Reconnect FROM tblbots WHERE ACTIVE=0", 5)
    End Sub

    Private Sub btnActiveRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActiveRefresh.Click
        SQL = "SELECT tblserverlist.BotID,tblbots.BotName, tblserverlist.ServerIP, tblserverlist.Port, tblbots.CmdPrefix, tblserverlist.Reconnect, tblserverlist.Ident FROM tblbots LEFT JOIN tblserverlist ON tblbots.idnum = tblserverlist.BotID WHERE tblserverlist.Active=1"
        PopulateListView(lstActiveEggdrops, SQL, 7)
    End Sub

    Private Sub btnClosePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosePanel.Click
        If TextBox1.Visible = True Then
            Me.Height = Me.Height - TextBox1.Height
            TextBox1.Visible = False
        End If
    End Sub

    Private Sub btnShowPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowPanel.Click
        If TextBox1.Visible = False Then
            Me.Height = Me.Height + TextBox1.Height
            TextBox1.Visible = True
        End If
    End Sub

    Private Sub btnPluginDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPluginDelete.Click

    End Sub

    Private Sub GroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupsToolStripMenuItem.Click
        'STATUS: COMPLETED  
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Dim myfrm As New BotGroupLevels
        myfrm.Show()
    End Sub

    Private Sub LevelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelsToolStripMenuItem.Click
        'STATUS: COMPLETED
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Dim myfrm As New BotLevelList
        myfrm.Show()
    End Sub

    Private Sub ServerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerListToolStripMenuItem.Click
        'STATUS: COMPLETED
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Dim myfrm As New ServerList
        myfrm.Show()
    End Sub

    Private Sub ChannelListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChannelListToolStripMenuItem.Click
        'STATUS: COMPLETED
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Dim myfrm As New ChannelList
        myfrm.Show()
    End Sub

    Private Sub DisconnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectToolStripMenuItem.Click
        'STATUS: COMPLETED
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Call btnActiveDisconnect_Click(sender, e)
    End Sub

    Private Sub DisconnectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectAllToolStripMenuItem.Click
        'STATUS: COMPLETED
        Dim li As ListViewItem
        For Each li In lstActiveEggdrops.Items
            li.Selected = True
            Call btnActiveDisconnect_Click(sender, e)
        Next
    End Sub

    Private Sub AllBotSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBotSettingsToolStripMenuItem.Click
        'STATUS: COMPLETED
        Dim myfrm As New BasicSettings
        myfrm.Show()
        Me.Hide()
    End Sub

    Private Sub AddBotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBotToolStripMenuItem.Click
        'STATUS: COMPLETED
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Call btnInactiveStart_Click(sender, e)
    End Sub

    Private Sub StopAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopAllToolStripMenuItem.Click
        'STOP ALL SCRIPT INPUT FOR BOT
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        TextBox1.AppendText("HALT:" & vbCrLf)
    End Sub

    Public Function checkCurBotName() As String
        If lstActiveEggdrops.SelectedItems.Count = 0 And lstInactiveEggdrops.SelectedItems.Count = 0 Then
            CurrBotName = "None"
        Else
            If lstActiveEggdrops.SelectedItems.Count = 0 Then
                CurrBotName = lstInactiveEggdrops.SelectedItems(0).SubItems(1).Text
            Else
                CurrBotName = lstActiveEggdrops.SelectedItems(0).SubItems(1).Text
            End If
        End If
        Return CurrBotName
    End Function

    Private Sub SecuritySettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecuritySettingsToolStripMenuItem.Click
        'STATUS: COMPLETED
        If checkCurBotName() = "None" Then
            Exit Sub
        End If

        Dim myfrm As New BotSecurity
        myfrm.Show()
    End Sub
End Class
