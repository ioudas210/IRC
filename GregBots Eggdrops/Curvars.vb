Imports System.Net
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Module Curvars
    'CONNECTION AND COMMAND
    Public SQL As String
    Public Command As String = ""
    Public address As IPAddress
    Public ConnectedToServer As Boolean

    'APP SPECIFIC
    Public NtIcon As NotifyIcon
    Public CurrThread As Integer

    'REGEX
    Public A2ZRegex As String = "^[a-z,A-Z]+"
    Public A2ZChanRegex As String = "^[a-z,0-9,A-Z]+"
    Public A2ZCmdRegex As String = "^[a-z,0-9,A-Z]+"
    Public ZeroTo9Regex As String = "^[\-0-9]+"
    Public closingstr As String = "CLOSING:(?<key>[0-9].+)"
    Public mt As Match
    'ENCRYPTION
    Public ReadOnly key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    Public ReadOnly iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}
    Public des As New Encryption(key, iv)

    'BOT INFO
    Public CurrBotName As String
    Public ChannelJoin As Boolean = True
    Public CurrBotID As Integer

    'SERVER INFO
    Public currServer As String
    Public PPort As String

    'REPLY INFO
    Public firstsw As Boolean = True
    Public AnswerChannels As Boolean = True
    Public AnswerCTCPServer As Boolean = True
    Public JoinAnswer As Boolean = False
    Public ThreadKillID As Long
    Public conn As New MySqlConnection
    Public myReader As MySqlDataReader
    Public myCommand As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter
    Public myData As New DataTable
    Public thetime As String = Format(Today, "yyyy/MM/dd")
    Public nickname, ident, hostname, command2, channel, message
    Public regexp As String

    Public rndNum As New Random(System.DateTime.Now.Millisecond)
    Public DEADTIMER As Boolean = False
    Public DEADLEN As Integer
    Public re As Regex
    Public item As String
    Public item2 As String
    Public result As String
    Public RecordSW As Boolean = True

    'SERVER EVASION INNER JOIN
    'SELECT tblserverevasion.Command, tblserverevasion.Server, tblbots.ThreadID, tblbots.idnum
    'FROM tblbots INNER JOIN tblserverevasion ON tblbots.idnum = tblserverevasion.BotID
    'WHERE (((tblbots.idnum)=1));

    'ACL  LevelAUTH INNER JOIN
    'SELECT tblauth.UserName, tblbots.BotName, tblauth.IsAuthed, tblauth.UserName, tblacl.Level, tblacl.Channel, tblbots.idnum
    'FROM (tblbots INNER JOIN tblacl ON tblbots.idnum = tblacl.BotID) INNER JOIN tblauth ON tblbots.idnum = tblauth.BotID
    'WHERE (((tblbots.idnum)=1));

    'ACL BY GROUP INNER JOIN
    'SELECT tblauth.UserName, tblbots.BotName, tblauth.IsAuthed, tblauth.UserName, tblbots.idnum, tblaclbygroup.BotName, tblaclbygroup.BotGroup
    'FROM (tblbots INNER JOIN tblauth ON tblbots.idnum = tblauth.BotID) INNER JOIN tblaclbygroup ON tblbots.idnum = tblaclbygroup.BotID
    'WHERE (((tblbots.idnum)=1));
End Module
