Imports System.Web

Module Module1
    Public Function SendSMS(ByVal reply As String, ByVal id As String, ByVal number As String, ByVal network As String, ByVal message As String, ByVal cc As String, ByVal currency As String, ByVal value As String, ByVal ekey As String, ByVal title As String)
        Dim webClient As New System.Net.WebClient
        Dim url As String = "http://client.txtnation.com/gateway.php?" & "reply=" & reply & "&id=" & id & "&number=" & number & "&network=" & network & "&message=" & HttpUtility.UrlEncode(message) & "&cc=" & cc & "&currency=" & currency & "&value=" & value & "&ekey=" & ekey & "&title=" & title
        Dim result As String = webClient.DownloadString(url)
        SendSMS = result
    End Function

    Sub Main()
        Dim result As String = SendSMS("1", "1234", "07123456789", "network", "My test message", "Test Company", "CUR", "12.3", "key", "from title")
        Console.WriteLine(result)
        Console.ReadKey()
    End Sub

End Module


