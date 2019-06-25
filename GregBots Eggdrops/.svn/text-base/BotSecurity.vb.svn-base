Public Class BotSecurity

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myfrm As New About
        myfrm.Show()
    End Sub

    Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBotCommands.SelectedIndexChanged

    End Sub

    Private Sub BotSecurity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstSecurityProfile.Items.Add("Default")
        lstSecurityProfile.Items.Add("Low")
        lstSecurityProfile.Items.Add("Medium")
        lstSecurityProfile.Items.Add("High")
        grpSecuritySettings.Text = grpSecuritySettings.Text & " " & CurrBotName
    End Sub
End Class