Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Public Class HTTPSocketClass
    Public Function ParseHTML(ByVal HTML As String) As String
        'FUNCTION NAME: GetTitle
        'INPUT        : Url , Channel, Irc Channel socket to send response to
        'EXISTANCE    : This determines if someone put a url in a channel
        'OUTPUT       : Title

        Dim TempArray As Array 'array used to strip out the <title>
        Dim Temp As String = ""
        Dim DelimiterA() As String = {"<title>"}
        Dim DelimiterB() As String = {"</title>"}
        Dim Title As String = ""
        Try
            If HTML <> "" Then
                If (InStr(HTML, "<title>") > 0) And (InStr(HTML, "</title>") > 0) Then
                    TempArray = HTML.Split(DelimiterA, StringSplitOptions.None)
                    Temp = TempArray(1)
                    TempArray = Temp.Split(DelimiterB, StringSplitOptions.None)
                    Title = TempArray(0)

                End If
            End If
        Catch ex As Exception
            Title = ""
        End Try

        Return Title
    End Function

    Public Function DownloadHTML(ByRef Url As String) As String
        'FUNCTION NAME: GetTitle
        'INPUT        : Url , Channel, Irc Channel socket to send response to
        'EXISTANCE    : This determines if someone put a url in a channel
        'OUTPUT       : Title

        Dim uri As New Uri(Url)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        Dim Title As String = "" 'returned <title>
        Dim HTML As String = "" 'html returned from web request
        Dim Temp As String = ""

        Try
            If True Then
                request = HttpWebRequest.Create(uri)
                request.Method = WebRequestMethods.Http.Get
                request.Timeout = 60000 '1000ms = 1 second
                response = request.GetResponse
                Url = response.ResponseUri.OriginalString
                Dim reader As New StreamReader(response.GetResponseStream())
                HTML = reader.ReadToEnd
                response.Close()
            Else
                HTML = ""
            End If

            If HTML <> "" Then

            End If
        Catch ex As Exception
            Title = ""
        End Try

        Return HTML
    End Function
End Class
