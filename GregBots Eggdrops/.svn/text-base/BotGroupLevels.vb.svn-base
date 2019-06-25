Imports MySql.Data.MySqlClient

Public Class BotGroupLevels

    Private Sub BotGroupLevels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateListView(lstGroupNames, "SELECT BotName,BotGroup,UserName,Channel,Server FROM tblaclbygroup WHERE BotName=""" & CurrBotName & """", 5)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myfrm As New About
        myfrm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBotName.Text = ""
        txtGroupName.Text = ""
        txtUserName.Text = ""
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        lstGroupNames.SelectedItems(0).Remove()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim li As New ListViewItem
        li.Text = txtBotName.Text
        li.SubItems.Add(txtGroupName.Text)
        li.SubItems.Add(txtUserName.Text)
    End Sub
End Class