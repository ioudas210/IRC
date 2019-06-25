<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChannelList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChannelList))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddChannelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteChannelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lstChannels = New System.Windows.Forms.ListView
        Me.colID = New System.Windows.Forms.ColumnHeader
        Me.botID = New System.Windows.Forms.ColumnHeader
        Me.Chan = New System.Windows.Forms.ColumnHeader
        Me.AOp = New System.Windows.Forms.ColumnHeader
        Me.grpChannelList = New System.Windows.Forms.GroupBox
        Me.cmbAutoOp = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtChannelName = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.grpChannelList.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(372, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddChannelToolStripMenuItem, Me.DeleteChannelToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddChannelToolStripMenuItem
        '
        Me.AddChannelToolStripMenuItem.Name = "AddChannelToolStripMenuItem"
        Me.AddChannelToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AddChannelToolStripMenuItem.Text = "Add Channel"
        '
        'DeleteChannelToolStripMenuItem
        '
        Me.DeleteChannelToolStripMenuItem.Name = "DeleteChannelToolStripMenuItem"
        Me.DeleteChannelToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.DeleteChannelToolStripMenuItem.Text = "Delete Channel"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.HelToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'HelToolStripMenuItem
        '
        Me.HelToolStripMenuItem.Name = "HelToolStripMenuItem"
        Me.HelToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.HelToolStripMenuItem.Text = "Help File"
        '
        'lstChannels
        '
        Me.lstChannels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.botID, Me.Chan, Me.AOp})
        Me.lstChannels.FullRowSelect = True
        Me.lstChannels.Location = New System.Drawing.Point(150, 9)
        Me.lstChannels.Name = "lstChannels"
        Me.lstChannels.Size = New System.Drawing.Size(216, 250)
        Me.lstChannels.TabIndex = 1
        Me.lstChannels.UseCompatibleStateImageBehavior = False
        Me.lstChannels.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'botID
        '
        Me.botID.Text = "BotId"
        Me.botID.Width = 0
        '
        'Chan
        '
        Me.Chan.Text = "Channel"
        Me.Chan.Width = 141
        '
        'AOp
        '
        Me.AOp.Text = "Auto Op"
        Me.AOp.Width = 70
        '
        'grpChannelList
        '
        Me.grpChannelList.Controls.Add(Me.cmbAutoOp)
        Me.grpChannelList.Controls.Add(Me.Label2)
        Me.grpChannelList.Controls.Add(Me.Label1)
        Me.grpChannelList.Controls.Add(Me.txtChannelName)
        Me.grpChannelList.Controls.Add(Me.btnAdd)
        Me.grpChannelList.Controls.Add(Me.lstChannels)
        Me.grpChannelList.Controls.Add(Me.btnDelete)
        Me.grpChannelList.Location = New System.Drawing.Point(0, 27)
        Me.grpChannelList.Name = "grpChannelList"
        Me.grpChannelList.Size = New System.Drawing.Size(372, 269)
        Me.grpChannelList.TabIndex = 2
        Me.grpChannelList.TabStop = False
        Me.grpChannelList.Text = "Channel List"
        '
        'cmbAutoOp
        '
        Me.cmbAutoOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAutoOp.FormattingEnabled = True
        Me.cmbAutoOp.Location = New System.Drawing.Point(15, 101)
        Me.cmbAutoOp.Name = "cmbAutoOp"
        Me.cmbAutoOp.Size = New System.Drawing.Size(133, 21)
        Me.cmbAutoOp.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Auto Op"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Channel Name:"
        '
        'txtChannelName
        '
        Me.txtChannelName.Location = New System.Drawing.Point(15, 41)
        Me.txtChannelName.Name = "txtChannelName"
        Me.txtChannelName.Size = New System.Drawing.Size(133, 20)
        Me.txtChannelName.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(31, 139)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(98, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add Channel"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(31, 168)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete Channel"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ChannelList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 298)
        Me.Controls.Add(Me.grpChannelList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChannelList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Easy Win Drop - Channel List"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpChannelList.ResumeLayout(False)
        Me.grpChannelList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddChannelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteChannelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstChannels As System.Windows.Forms.ListView
    Friend WithEvents grpChannelList As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtChannelName As System.Windows.Forms.TextBox
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents botID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Chan As System.Windows.Forms.ColumnHeader
    Friend WithEvents AOp As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbAutoOp As System.Windows.Forms.ComboBox
End Class
