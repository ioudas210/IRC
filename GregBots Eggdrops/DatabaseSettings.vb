Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class DatabaseSettings
    Dim conn As New MySqlConnection

    Dim FormTimerStopWatch As New Stopwatch
    Dim passwd As String
    Dim db As String
    Dim usrid As String
    Dim server As String

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim myfrm As New About
        myfrm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DatabaseSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim myfrm As New ControlCenter
        myfrm.Show()
    End Sub

    Private Sub DatabaseSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstDB.Items.Add(des.Decrypt(My.Settings.ConnStr))
    End Sub

    Private Sub btbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbSave.Click
        'SANITIZE FIELDS

        'ENCRYPT FIELDS
    End Sub

    Private Sub btnFreshInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreshInstall.Click
        conn.ConnectionString = "server=localhost; user id=root; password=asd1095131;database=gregbot"
        Try
            conn.Open()
            MsgBox("Connection Opened Successfully")
            conn.Close()
        Catch myerror As MySqlException
            MsgBox("Error Connecting to Database: " & myerror.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'MYSQL SERVER CONF
        'CAN ONLY HAVE 1 DB
        My.Settings.ConnStr = des.Encrypt("server= " & txtServerIP.Text & "; user id=" & txtUser.Text & "; password=" & txtPassword.Text & ";database=" & txtDatabase.Text & ";")
        My.Settings.Save()
    End Sub

    Private Sub btnTestCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestCon.Click
        conn.ConnectionString = des.Decrypt(My.Settings.ConnStr)
        Try
            conn.Open()
            MsgBox("Connection Opened Successfully")
            conn.Close()
        Catch myerror As MySqlException
            MsgBox("Error Connecting to Database: " & myerror.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub

    Private Sub lstDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDB.Click

        If lstDB.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim serverstring As String
        Dim re As Regex
        Dim server As String
        Dim userid As String
        Dim pass As String
        Dim db As String

        serverstring = lstDB.SelectedItems(0).Text

        If RegXPChecker("server=(?<server>.+); user id=(?<userid>.+); password=(?<pass>.+);database=(?<db>.+);", serverstring) Then
            re = New Regex("server=(?<server>.+); user id=(?<userid>.+); password=(?<pass>.+);database=(?<db>.+);")
            mt = re.Match(serverstring)

            server = mt.Groups("server").ToString
            userid = mt.Groups("userid").ToString
            pass = mt.Groups("pass").ToString
            db = mt.Groups("db").ToString

            txtServerIP.Text = server
            txtUser.Text = userid
            txtPassword.Text = pass
            txtDatabase.Text = db
        End If
    End Sub

    Private Sub lstDB_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDB.MouseClick
        If lstDB.SelectedItems.Count = 0 Then
            Exit Sub
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtDatabase.Text = ""
        txtPassword.Text = ""
        txtUser.Text = ""
        txtServerIP.Text = ""
        txtPort.Text = ""
    End Sub
End Class