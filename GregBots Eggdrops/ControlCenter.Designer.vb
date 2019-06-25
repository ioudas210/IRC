<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlCenter
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlCenter))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SystemInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BasicSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllBotSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LevelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ServerListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChannelListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SecuritySettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScriptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StopAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StartAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BotsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddBotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisconnectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HaltAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DatabaseSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.P2PSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BugReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grpActiveEggdrops = New System.Windows.Forms.GroupBox
        Me.lstActiveEggdrops = New System.Windows.Forms.ListView
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.TID = New System.Windows.Forms.ColumnHeader
        Me.Serv = New System.Windows.Forms.ColumnHeader
        Me.Cmd = New System.Windows.Forms.ColumnHeader
        Me.Reconnect = New System.Windows.Forms.ColumnHeader
        Me.btnActiveDisconnect = New System.Windows.Forms.Button
        Me.btnActiveRefresh = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.grpInactiveEggDrops = New System.Windows.Forms.GroupBox
        Me.lstInactiveEggdrops = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.btnInactiveEggDropRefresh = New System.Windows.Forms.Button
        Me.btnInactiveStart = New System.Windows.Forms.Button
        Me.grpStats = New System.Windows.Forms.GroupBox
        Me.btnShowPanel = New System.Windows.Forms.Button
        Me.btnClosePanel = New System.Windows.Forms.Button
        Me.lstGlobalStats = New System.Windows.Forms.ListView
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.btnStatsRefresh = New System.Windows.Forms.Button
        Me.btnOpenLog = New System.Windows.Forms.Button
        Me.GrpPlugins = New System.Windows.Forms.GroupBox
        Me.lstBotCmds = New System.Windows.Forms.ListView
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.btnPluginAdd = New System.Windows.Forms.Button
        Me.btnPluginDelete = New System.Windows.Forms.Button
        Me.btnPluginRefresh = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EndToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuStrip1.SuspendLayout()
        Me.grpActiveEggdrops.SuspendLayout()
        Me.grpInactiveEggDrops.SuspendLayout()
        Me.grpStats.SuspendLayout()
        Me.GrpPlugins.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImage = CType(resources.GetObject("MenuStrip1.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(971, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemInfoToolStripMenuItem, Me.HideToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SystemInfoToolStripMenuItem
        '
        Me.SystemInfoToolStripMenuItem.Name = "SystemInfoToolStripMenuItem"
        Me.SystemInfoToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SystemInfoToolStripMenuItem.Text = "System Info"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(140, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BasicSettingsToolStripMenuItem, Me.ScriptsToolStripMenuItem, Me.BotsToolStripMenuItem, Me.DatabaseSettingsToolStripMenuItem, Me.P2PSettingsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'BasicSettingsToolStripMenuItem
        '
        Me.BasicSettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllBotSettingsToolStripMenuItem, Me.ToolStripSeparator2, Me.GroupsToolStripMenuItem, Me.LevelsToolStripMenuItem, Me.ServerListToolStripMenuItem, Me.ChannelListToolStripMenuItem, Me.SecuritySettingsToolStripMenuItem})
        Me.BasicSettingsToolStripMenuItem.Name = "BasicSettingsToolStripMenuItem"
        Me.BasicSettingsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BasicSettingsToolStripMenuItem.Text = "Basic Settings"
        '
        'AllBotSettingsToolStripMenuItem
        '
        Me.AllBotSettingsToolStripMenuItem.Name = "AllBotSettingsToolStripMenuItem"
        Me.AllBotSettingsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AllBotSettingsToolStripMenuItem.Text = "All Bot Settings"
        '
        'GroupsToolStripMenuItem
        '
        Me.GroupsToolStripMenuItem.Name = "GroupsToolStripMenuItem"
        Me.GroupsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.GroupsToolStripMenuItem.Text = "Groups"
        '
        'LevelsToolStripMenuItem
        '
        Me.LevelsToolStripMenuItem.Name = "LevelsToolStripMenuItem"
        Me.LevelsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.LevelsToolStripMenuItem.Text = "Levels"
        '
        'ServerListToolStripMenuItem
        '
        Me.ServerListToolStripMenuItem.Name = "ServerListToolStripMenuItem"
        Me.ServerListToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ServerListToolStripMenuItem.Text = "Server List"
        '
        'ChannelListToolStripMenuItem
        '
        Me.ChannelListToolStripMenuItem.Name = "ChannelListToolStripMenuItem"
        Me.ChannelListToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ChannelListToolStripMenuItem.Text = "Channel List"
        '
        'SecuritySettingsToolStripMenuItem
        '
        Me.SecuritySettingsToolStripMenuItem.Name = "SecuritySettingsToolStripMenuItem"
        Me.SecuritySettingsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SecuritySettingsToolStripMenuItem.Text = "Security Settings"
        '
        'ScriptsToolStripMenuItem
        '
        Me.ScriptsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StopAllToolStripMenuItem, Me.StartAllToolStripMenuItem, Me.InstallToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.ScriptsToolStripMenuItem.Name = "ScriptsToolStripMenuItem"
        Me.ScriptsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ScriptsToolStripMenuItem.Text = "Scripts"
        '
        'StopAllToolStripMenuItem
        '
        Me.StopAllToolStripMenuItem.Name = "StopAllToolStripMenuItem"
        Me.StopAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StopAllToolStripMenuItem.Text = "Stop All"
        '
        'StartAllToolStripMenuItem
        '
        Me.StartAllToolStripMenuItem.Name = "StartAllToolStripMenuItem"
        Me.StartAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StartAllToolStripMenuItem.Text = "Start All"
        '
        'InstallToolStripMenuItem
        '
        Me.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem"
        Me.InstallToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InstallToolStripMenuItem.Text = "Install"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'BotsToolStripMenuItem
        '
        Me.BotsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBotToolStripMenuItem, Me.DisconnectToolStripMenuItem, Me.DisconnectAllToolStripMenuItem, Me.HaltAllToolStripMenuItem})
        Me.BotsToolStripMenuItem.Name = "BotsToolStripMenuItem"
        Me.BotsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BotsToolStripMenuItem.Text = "Bots"
        '
        'AddBotToolStripMenuItem
        '
        Me.AddBotToolStripMenuItem.Name = "AddBotToolStripMenuItem"
        Me.AddBotToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddBotToolStripMenuItem.Text = "Add Bot"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DisconnectToolStripMenuItem.Text = "Disconnect"
        '
        'DisconnectAllToolStripMenuItem
        '
        Me.DisconnectAllToolStripMenuItem.Name = "DisconnectAllToolStripMenuItem"
        Me.DisconnectAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DisconnectAllToolStripMenuItem.Text = "Disconnect All"
        '
        'HaltAllToolStripMenuItem
        '
        Me.HaltAllToolStripMenuItem.Name = "HaltAllToolStripMenuItem"
        Me.HaltAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HaltAllToolStripMenuItem.Text = "Halt All Code"
        '
        'DatabaseSettingsToolStripMenuItem
        '
        Me.DatabaseSettingsToolStripMenuItem.Name = "DatabaseSettingsToolStripMenuItem"
        Me.DatabaseSettingsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DatabaseSettingsToolStripMenuItem.Text = "Database Settings"
        '
        'P2PSettingsToolStripMenuItem
        '
        Me.P2PSettingsToolStripMenuItem.Name = "P2PSettingsToolStripMenuItem"
        Me.P2PSettingsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.P2PSettingsToolStripMenuItem.Text = "P2P Settings"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.BugReportToolStripMenuItem, Me.HelpFileToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'BugReportToolStripMenuItem
        '
        Me.BugReportToolStripMenuItem.Name = "BugReportToolStripMenuItem"
        Me.BugReportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BugReportToolStripMenuItem.Text = "Bug Report"
        '
        'HelpFileToolStripMenuItem
        '
        Me.HelpFileToolStripMenuItem.Name = "HelpFileToolStripMenuItem"
        Me.HelpFileToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HelpFileToolStripMenuItem.Text = "Help File"
        '
        'grpActiveEggdrops
        '
        Me.grpActiveEggdrops.BackColor = System.Drawing.Color.Transparent
        Me.grpActiveEggdrops.Controls.Add(Me.lstActiveEggdrops)
        Me.grpActiveEggdrops.Controls.Add(Me.btnActiveDisconnect)
        Me.grpActiveEggdrops.Controls.Add(Me.btnActiveRefresh)
        Me.grpActiveEggdrops.Location = New System.Drawing.Point(6, 30)
        Me.grpActiveEggdrops.Name = "grpActiveEggdrops"
        Me.grpActiveEggdrops.Size = New System.Drawing.Size(479, 234)
        Me.grpActiveEggdrops.TabIndex = 4
        Me.grpActiveEggdrops.TabStop = False
        Me.grpActiveEggdrops.Text = "Active Eggdrops"
        '
        'lstActiveEggdrops
        '
        Me.lstActiveEggdrops.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader1, Me.TID, Me.Serv, Me.Cmd, Me.Reconnect})
        Me.lstActiveEggdrops.FullRowSelect = True
        Me.lstActiveEggdrops.Location = New System.Drawing.Point(6, 19)
        Me.lstActiveEggdrops.Name = "lstActiveEggdrops"
        Me.lstActiveEggdrops.Size = New System.Drawing.Size(381, 199)
        Me.lstActiveEggdrops.TabIndex = 5
        Me.lstActiveEggdrops.UseCompatibleStateImageBehavior = False
        Me.lstActiveEggdrops.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "IDNum"
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "BotName"
        Me.ColumnHeader1.Width = 101
        '
        'TID
        '
        Me.TID.Text = "ThreadID"
        '
        'Serv
        '
        Me.Serv.Text = "Server"
        Me.Serv.Width = 110
        '
        'Cmd
        '
        Me.Cmd.Text = "Cmd Prefix"
        Me.Cmd.Width = 44
        '
        'Reconnect
        '
        Me.Reconnect.Text = "Reconnect"
        '
        'btnActiveDisconnect
        '
        Me.btnActiveDisconnect.Location = New System.Drawing.Point(393, 79)
        Me.btnActiveDisconnect.Name = "btnActiveDisconnect"
        Me.btnActiveDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.btnActiveDisconnect.TabIndex = 4
        Me.btnActiveDisconnect.Text = "Disconnect"
        Me.btnActiveDisconnect.UseVisualStyleBackColor = True
        '
        'btnActiveRefresh
        '
        Me.btnActiveRefresh.Location = New System.Drawing.Point(393, 34)
        Me.btnActiveRefresh.Name = "btnActiveRefresh"
        Me.btnActiveRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnActiveRefresh.TabIndex = 3
        Me.btnActiveRefresh.Text = "Refresh"
        Me.btnActiveRefresh.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 495)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(965, 121)
        Me.TextBox1.TabIndex = 5
        '
        'grpInactiveEggDrops
        '
        Me.grpInactiveEggDrops.BackColor = System.Drawing.Color.Transparent
        Me.grpInactiveEggDrops.Controls.Add(Me.lstInactiveEggdrops)
        Me.grpInactiveEggDrops.Controls.Add(Me.btnInactiveEggDropRefresh)
        Me.grpInactiveEggDrops.Controls.Add(Me.btnInactiveStart)
        Me.grpInactiveEggDrops.Location = New System.Drawing.Point(491, 30)
        Me.grpInactiveEggDrops.Name = "grpInactiveEggDrops"
        Me.grpInactiveEggDrops.Size = New System.Drawing.Size(480, 234)
        Me.grpInactiveEggDrops.TabIndex = 5
        Me.grpInactiveEggDrops.TabStop = False
        Me.grpInactiveEggDrops.Text = "Inactive Eggdrops"
        '
        'lstInactiveEggdrops
        '
        Me.lstInactiveEggdrops.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader3, Me.ColumnHeader10, Me.ColumnHeader19, Me.ColumnHeader14, Me.ColumnHeader17, Me.ColumnHeader2})
        Me.lstInactiveEggdrops.FullRowSelect = True
        Me.lstInactiveEggdrops.Location = New System.Drawing.Point(6, 19)
        Me.lstInactiveEggdrops.Name = "lstInactiveEggdrops"
        Me.lstInactiveEggdrops.Size = New System.Drawing.Size(381, 199)
        Me.lstInactiveEggdrops.TabIndex = 6
        Me.lstInactiveEggdrops.UseCompatibleStateImageBehavior = False
        Me.lstInactiveEggdrops.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ID"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "BotName"
        Me.ColumnHeader3.Width = 101
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Server"
        Me.ColumnHeader10.Width = 103
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Port"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Cmd Prefix"
        Me.ColumnHeader14.Width = 69
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Reconnect"
        Me.ColumnHeader17.Width = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Ident"
        '
        'btnInactiveEggDropRefresh
        '
        Me.btnInactiveEggDropRefresh.Location = New System.Drawing.Point(393, 79)
        Me.btnInactiveEggDropRefresh.Name = "btnInactiveEggDropRefresh"
        Me.btnInactiveEggDropRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnInactiveEggDropRefresh.TabIndex = 4
        Me.btnInactiveEggDropRefresh.Text = "Refresh"
        Me.btnInactiveEggDropRefresh.UseVisualStyleBackColor = True
        '
        'btnInactiveStart
        '
        Me.btnInactiveStart.Location = New System.Drawing.Point(393, 34)
        Me.btnInactiveStart.Name = "btnInactiveStart"
        Me.btnInactiveStart.Size = New System.Drawing.Size(75, 23)
        Me.btnInactiveStart.TabIndex = 3
        Me.btnInactiveStart.Text = "Start"
        Me.btnInactiveStart.UseVisualStyleBackColor = True
        '
        'grpStats
        '
        Me.grpStats.BackColor = System.Drawing.Color.Transparent
        Me.grpStats.Controls.Add(Me.btnShowPanel)
        Me.grpStats.Controls.Add(Me.btnClosePanel)
        Me.grpStats.Controls.Add(Me.lstGlobalStats)
        Me.grpStats.Controls.Add(Me.btnStatsRefresh)
        Me.grpStats.Controls.Add(Me.btnOpenLog)
        Me.grpStats.Location = New System.Drawing.Point(491, 270)
        Me.grpStats.Name = "grpStats"
        Me.grpStats.Size = New System.Drawing.Size(486, 222)
        Me.grpStats.TabIndex = 6
        Me.grpStats.TabStop = False
        Me.grpStats.Text = "Global Stats"
        '
        'btnShowPanel
        '
        Me.btnShowPanel.Location = New System.Drawing.Point(393, 157)
        Me.btnShowPanel.Name = "btnShowPanel"
        Me.btnShowPanel.Size = New System.Drawing.Size(75, 23)
        Me.btnShowPanel.TabIndex = 9
        Me.btnShowPanel.Text = "Show Panel"
        Me.btnShowPanel.UseVisualStyleBackColor = True
        '
        'btnClosePanel
        '
        Me.btnClosePanel.Location = New System.Drawing.Point(393, 128)
        Me.btnClosePanel.Name = "btnClosePanel"
        Me.btnClosePanel.Size = New System.Drawing.Size(75, 23)
        Me.btnClosePanel.TabIndex = 8
        Me.btnClosePanel.Text = "Close Panel"
        Me.btnClosePanel.UseVisualStyleBackColor = True
        '
        'lstGlobalStats
        '
        Me.lstGlobalStats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader13})
        Me.lstGlobalStats.FullRowSelect = True
        Me.lstGlobalStats.Location = New System.Drawing.Point(6, 17)
        Me.lstGlobalStats.Name = "lstGlobalStats"
        Me.lstGlobalStats.Size = New System.Drawing.Size(381, 199)
        Me.lstGlobalStats.TabIndex = 7
        Me.lstGlobalStats.UseCompatibleStateImageBehavior = False
        Me.lstGlobalStats.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "BotName"
        Me.ColumnHeader5.Width = 101
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ThreadID"
        Me.ColumnHeader6.Width = 63
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Server"
        Me.ColumnHeader13.Width = 209
        '
        'btnStatsRefresh
        '
        Me.btnStatsRefresh.Location = New System.Drawing.Point(393, 80)
        Me.btnStatsRefresh.Name = "btnStatsRefresh"
        Me.btnStatsRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnStatsRefresh.TabIndex = 4
        Me.btnStatsRefresh.Text = "Refresh"
        Me.btnStatsRefresh.UseVisualStyleBackColor = True
        '
        'btnOpenLog
        '
        Me.btnOpenLog.Location = New System.Drawing.Point(393, 34)
        Me.btnOpenLog.Name = "btnOpenLog"
        Me.btnOpenLog.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenLog.TabIndex = 3
        Me.btnOpenLog.Text = "Open Log"
        Me.btnOpenLog.UseVisualStyleBackColor = True
        '
        'GrpPlugins
        '
        Me.GrpPlugins.BackColor = System.Drawing.Color.Transparent
        Me.GrpPlugins.Controls.Add(Me.lstBotCmds)
        Me.GrpPlugins.Controls.Add(Me.btnPluginAdd)
        Me.GrpPlugins.Controls.Add(Me.btnPluginDelete)
        Me.GrpPlugins.Controls.Add(Me.btnPluginRefresh)
        Me.GrpPlugins.Location = New System.Drawing.Point(6, 270)
        Me.GrpPlugins.Name = "GrpPlugins"
        Me.GrpPlugins.Size = New System.Drawing.Size(479, 222)
        Me.GrpPlugins.TabIndex = 5
        Me.GrpPlugins.TabStop = False
        Me.GrpPlugins.Text = "Bot Commands"
        '
        'lstBotCmds
        '
        Me.lstBotCmds.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader16})
        Me.lstBotCmds.FullRowSelect = True
        Me.lstBotCmds.Location = New System.Drawing.Point(6, 19)
        Me.lstBotCmds.Name = "lstBotCmds"
        Me.lstBotCmds.Size = New System.Drawing.Size(381, 193)
        Me.lstBotCmds.TabIndex = 6
        Me.lstBotCmds.UseCompatibleStateImageBehavior = False
        Me.lstBotCmds.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "ID"
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "BotName"
        Me.ColumnHeader7.Width = 106
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "ThreadID"
        Me.ColumnHeader8.Width = 57
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Plugin"
        Me.ColumnHeader16.Width = 191
        '
        'btnPluginAdd
        '
        Me.btnPluginAdd.Location = New System.Drawing.Point(393, 80)
        Me.btnPluginAdd.Name = "btnPluginAdd"
        Me.btnPluginAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnPluginAdd.TabIndex = 8
        Me.btnPluginAdd.Text = "Add"
        Me.btnPluginAdd.UseVisualStyleBackColor = True
        '
        'btnPluginDelete
        '
        Me.btnPluginDelete.Location = New System.Drawing.Point(393, 109)
        Me.btnPluginDelete.Name = "btnPluginDelete"
        Me.btnPluginDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnPluginDelete.TabIndex = 7
        Me.btnPluginDelete.Text = "Delete"
        Me.btnPluginDelete.UseVisualStyleBackColor = True
        '
        'btnPluginRefresh
        '
        Me.btnPluginRefresh.Location = New System.Drawing.Point(393, 34)
        Me.btnPluginRefresh.Name = "btnPluginRefresh"
        Me.btnPluginRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnPluginRefresh.TabIndex = 3
        Me.btnPluginRefresh.Text = "Refresh"
        Me.btnPluginRefresh.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.EndToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(112, 48)
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(111, 22)
        Me.FileToolStripMenuItem1.Text = "Show"
        '
        'EndToolStripMenuItem
        '
        Me.EndToolStripMenuItem.Name = "EndToolStripMenuItem"
        Me.EndToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.EndToolStripMenuItem.Text = "Quit"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'ControlCenter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(971, 618)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.grpInactiveEggDrops)
        Me.Controls.Add(Me.GrpPlugins)
        Me.Controls.Add(Me.grpActiveEggdrops)
        Me.Controls.Add(Me.grpStats)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "ControlCenter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Easy Win Drop - Control Center"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpActiveEggdrops.ResumeLayout(False)
        Me.grpInactiveEggDrops.ResumeLayout(False)
        Me.grpStats.ResumeLayout(False)
        Me.GrpPlugins.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BasicSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpActiveEggdrops As System.Windows.Forms.GroupBox
    Friend WithEvents btnActiveDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnActiveRefresh As System.Windows.Forms.Button
    Friend WithEvents grpInactiveEggDrops As System.Windows.Forms.GroupBox
    Friend WithEvents btnInactiveEggDropRefresh As System.Windows.Forms.Button
    Friend WithEvents btnInactiveStart As System.Windows.Forms.Button
    Friend WithEvents grpStats As System.Windows.Forms.GroupBox
    Friend WithEvents btnStatsRefresh As System.Windows.Forms.Button
    Friend WithEvents btnOpenLog As System.Windows.Forms.Button
    Friend WithEvents GrpPlugins As System.Windows.Forms.GroupBox
    Friend WithEvents btnPluginAdd As System.Windows.Forms.Button
    Friend WithEvents btnPluginDelete As System.Windows.Forms.Button
    Friend WithEvents btnPluginRefresh As System.Windows.Forms.Button
    Friend WithEvents BotsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HaltAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EndToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisconnectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents AddBotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstActiveEggdrops As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TID As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstInactiveEggdrops As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstGlobalStats As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstBotCmds As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Serv As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cmd As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Reconnect As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BugReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnShowPanel As System.Windows.Forms.Button
    Friend WithEvents btnClosePanel As System.Windows.Forms.Button
    Friend WithEvents GroupsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServerListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChannelListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllBotSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents P2PSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecuritySettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

End Class
