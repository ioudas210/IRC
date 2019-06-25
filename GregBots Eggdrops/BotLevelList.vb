Imports MySql.Data.MySqlClient

Public Class BotLevelList

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BotLevelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grpLevelList.Text = "Level List for " & CurrBotName
        PopulateListView(lstLevelList, "SELECT BotName,UserAccessName,Level,Server FROM tblAcl", 4)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myfrm As New About
        myfrm.Show()
    End Sub

    Private Sub HelpFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpFileToolStripMenuItem.Click

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lstLevelList.SelectedItems.Count = 0 Then
            Exit Sub
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lstLevelList.SelectedItems.Count = 0 Then
            Exit Sub
        End If
    End Sub
End Class