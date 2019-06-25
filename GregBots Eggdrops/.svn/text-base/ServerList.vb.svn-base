Imports MySql.Data.MySqlClient

Public Class ServerList

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ServerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbActive.Items.Add("Yes")
        cmbActive.Items.Add("No")
        CmdReconnect.Items.Add("Yes")
        CmdReconnect.Items.Add("No")
        grpServerList.Text = CurrBotName & " server list"
        PopulateListView(lstServers, "SELECT IDNum,ServerIP,Port,Reconnect,Active FROM tblserverlist WHERE BotID=" & GetBotID(CurrBotName), 5)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myfrm As New About
        myfrm.Show()
    End Sub

    Private Sub lstServers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstServers.Click
        SQL = "SELECT IDNum,ServerIP,Port,Reconnect,Active FROM tblserverlist WHERE BotID=" & GetBotID(CurrBotName)
    End Sub

    Private Sub lstServers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServers.SelectedIndexChanged
        'SQL="SELECT IDNum,ServerIP,Port,Reconnect,Active FROM tblserverlist WHERE BotID=" & GetBotID(CurrBotName))
    End Sub

    Private Sub btnSaveServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveServer.Click
        '   SQL="SELECT IDNum,ServerIP,Port,Reconnect,Active FROM tblserverlist WHERE BotID=" & GetBotID(CurrBotName))
    End Sub

    Private Sub btnDeleteServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteServer.Click
        PopulateListView(lstServers, "SELECT IDNum,ServerIP,Port,Reconnect,Active FROM tblserverlist WHERE BotID=" & GetBotID(CurrBotName), 5)
    End Sub

    Private Sub btnAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddServer.Click
        PopulateListView(lstServers, "SELECT IDNum,ServerIP,Port,Reconnect,Active FROM tblserverlist WHERE BotID=" & GetBotID(CurrBotName), 5)
    End Sub

    Private Sub AddServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddServerToolStripMenuItem.Click
        Call btnAddServer_Click(sender, e)
    End Sub

    Private Sub SaveServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveServerToolStripMenuItem.Click
        Call btnSaveServer_Click(sender, e)
    End Sub

    Private Sub DeleteServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteServerToolStripMenuItem.Click
        Call btnDeleteServer_Click(sender, e)
    End Sub
End Class