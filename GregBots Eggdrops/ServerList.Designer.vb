<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServerList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServerList))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.lstServers = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.btnAddServer = New System.Windows.Forms.Button
        Me.grpServerList = New System.Windows.Forms.GroupBox
        Me.btnSaveServer = New System.Windows.Forms.Button
        Me.cmbActive = New System.Windows.Forms.ComboBox
        Me.CmdReconnect = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtServerIP = New System.Windows.Forms.TextBox
        Me.btnDeleteServer = New System.Windows.Forms.Button
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuStrip1.SuspendLayout()
        Me.grpServerList.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(431, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddServerToolStripMenuItem, Me.SaveServerToolStripMenuItem, Me.DeleteServerToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AddServerToolStripMenuItem
        '
        Me.AddServerToolStripMenuItem.Name = "AddServerToolStripMenuItem"
        Me.AddServerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddServerToolStripMenuItem.Text = "Add Server"
        '
        'DeleteServerToolStripMenuItem
        '
        Me.DeleteServerToolStripMenuItem.Name = "DeleteServerToolStripMenuItem"
        Me.DeleteServerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteServerToolStripMenuItem.Text = "Delete Server"
        '
        'SaveServerToolStripMenuItem
        '
        Me.SaveServerToolStripMenuItem.Name = "SaveServerToolStripMenuItem"
        Me.SaveServerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveServerToolStripMenuItem.Text = "Save Server"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(114, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'lstServers
        '
        Me.lstServers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstServers.FullRowSelect = True
        Me.lstServers.Location = New System.Drawing.Point(118, 19)
        Me.lstServers.Name = "lstServers"
        Me.lstServers.Size = New System.Drawing.Size(307, 254)
        Me.lstServers.TabIndex = 1
        Me.lstServers.UseCompatibleStateImageBehavior = False
        Me.lstServers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IDNum"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Server IP"
        Me.ColumnHeader2.Width = 103
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Port"
        Me.ColumnHeader3.Width = 58
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Reconnect"
        Me.ColumnHeader4.Width = 68
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Active"
        Me.ColumnHeader5.Width = 49
        '
        'btnAddServer
        '
        Me.btnAddServer.Location = New System.Drawing.Point(22, 192)
        Me.btnAddServer.Name = "btnAddServer"
        Me.btnAddServer.Size = New System.Drawing.Size(80, 23)
        Me.btnAddServer.TabIndex = 2
        Me.btnAddServer.Text = "Add Server"
        Me.btnAddServer.UseVisualStyleBackColor = True
        '
        'grpServerList
        '
        Me.grpServerList.Controls.Add(Me.btnSaveServer)
        Me.grpServerList.Controls.Add(Me.cmbActive)
        Me.grpServerList.Controls.Add(Me.CmdReconnect)
        Me.grpServerList.Controls.Add(Me.Label4)
        Me.grpServerList.Controls.Add(Me.Label3)
        Me.grpServerList.Controls.Add(Me.Label2)
        Me.grpServerList.Controls.Add(Me.Label1)
        Me.grpServerList.Controls.Add(Me.txtPort)
        Me.grpServerList.Controls.Add(Me.txtServerIP)
        Me.grpServerList.Controls.Add(Me.btnDeleteServer)
        Me.grpServerList.Controls.Add(Me.lstServers)
        Me.grpServerList.Controls.Add(Me.btnAddServer)
        Me.grpServerList.Location = New System.Drawing.Point(0, 27)
        Me.grpServerList.Name = "grpServerList"
        Me.grpServerList.Size = New System.Drawing.Size(431, 284)
        Me.grpServerList.TabIndex = 3
        Me.grpServerList.TabStop = False
        '
        'btnSaveServer
        '
        Me.btnSaveServer.Location = New System.Drawing.Point(22, 221)
        Me.btnSaveServer.Name = "btnSaveServer"
        Me.btnSaveServer.Size = New System.Drawing.Size(80, 23)
        Me.btnSaveServer.TabIndex = 15
        Me.btnSaveServer.Text = "Save Server"
        Me.btnSaveServer.UseVisualStyleBackColor = True
        '
        'cmbActive
        '
        Me.cmbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActive.FormattingEnabled = True
        Me.cmbActive.Location = New System.Drawing.Point(12, 165)
        Me.cmbActive.Name = "cmbActive"
        Me.cmbActive.Size = New System.Drawing.Size(100, 21)
        Me.cmbActive.TabIndex = 14
        '
        'CmdReconnect
        '
        Me.CmdReconnect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmdReconnect.FormattingEnabled = True
        Me.CmdReconnect.Location = New System.Drawing.Point(12, 120)
        Me.CmdReconnect.Name = "CmdReconnect"
        Me.CmdReconnect.Size = New System.Drawing.Size(100, 21)
        Me.CmdReconnect.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Active"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Server IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Reconnect"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(12, 74)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 6
        '
        'txtServerIP
        '
        Me.txtServerIP.Location = New System.Drawing.Point(12, 35)
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.Size = New System.Drawing.Size(100, 20)
        Me.txtServerIP.TabIndex = 5
        '
        'btnDeleteServer
        '
        Me.btnDeleteServer.Location = New System.Drawing.Point(22, 250)
        Me.btnDeleteServer.Name = "btnDeleteServer"
        Me.btnDeleteServer.Size = New System.Drawing.Size(80, 23)
        Me.btnDeleteServer.TabIndex = 4
        Me.btnDeleteServer.Text = "Delete Server"
        Me.btnDeleteServer.UseVisualStyleBackColor = True
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'ServerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 317)
        Me.Controls.Add(Me.grpServerList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Easy Win Drop - Server List"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpServerList.ResumeLayout(False)
        Me.grpServerList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstServers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddServer As System.Windows.Forms.Button
    Friend WithEvents grpServerList As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtServerIP As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteServer As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbActive As System.Windows.Forms.ComboBox
    Friend WithEvents CmdReconnect As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AddServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaveServer As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
