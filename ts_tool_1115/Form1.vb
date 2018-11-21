Public Class Form1
    Dim AcctNo() As String
    Dim FileNum As Integer
    Dim strTemp As String
    Dim i As Integer
    Dim AcctNo_max_num As Integer
    Dim sock1 As New Net.Sockets.TcpClient
    Dim opassword As String
    Dim chklog As Boolean = False
    Dim logout As Boolean = True
    Dim pick(), times As Byte, count As Long
    Dim ip As String
    Dim strbuff As String
    Dim NowState As String = "done"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'IPAddr.Text = "210.242.243.31"
        ip = IPAddr.Text
        AcctNo = Split(My.Computer.FileSystem.ReadAllText("D:\TS_ID\AA+BB+CC+DD.txt", System.Text.Encoding.Default), ",")
        AcctNo_max_num = UBound(AcctNo)
        MainCtrl.Start()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If NowNum.Text = "" Then
            MsgBox("請輸入開始號碼", 48)
            NowNum.Focus()
            Exit Sub
        End If
        If IsNumeric(NowNum.Text) = False Then
            MsgBox("輸入必須是數字", 48)
            NowNum.Focus()
            Exit Sub
        End If
        If NowNum.Text > AcctNo_max_num Then
            strbuff = "超出擁有帳號最大值" & AcctNo_max_num
            MsgBox(strbuff, 48)
            NowNum.Focus()
            Exit Sub
        End If

        If sock1.Connected = True Then
            sock1.Client.Disconnect(False)
            sock1.Close()
            sock1 = New Net.Sockets.TcpClient
            ConnectStatus.Text = "登入狀態：斷開連接"
            Button1.Text = "登入"
            chklog = False
        Else
            sock1.NoDelay = True
            sock1.Connect(ip, 6414)
            ConnectStatus.Text = "登入狀態：正在連接"
            Button1.Text = "登出"
            Login()
            CheckConnectStatus.Start()
            NowState = "done"
            chklog = True
        End If



        'DebugLog.Text = AcctNo(NowNum.Text)
        MainCtrl.Interval = 100
        'Timer1.Start()

        'Label1.Text = temp_max
    End Sub

    Sub Login()
        If sock1.Connected = False Then
            sock1.Connect(ip, 6414)
            sock1.NoDelay = True
        End If

        Dim pack() As Byte
        Dim tmp, length, country, version, id, password As String
        Dim password_tmp() As Char
        Dim i As Integer

        country = Buwei(Hex(Asc(VersionRegion.Text.Substring(0, 1))), 2) & Buwei(Hex(Asc(VersionRegion.Text.Substring(1, 1))), 2)
        version = Buwei(Hex(VersionNum.Text), 4)
        id = Buwei(Hex(Val(AcctNo(NowNum.Text))), 8)
        opassword = TSPassWord.Text
        password_tmp = opassword.ToCharArray
        password = ""
        For i = 0 To password_tmp.GetUpperBound(0)
            password &= Buwei(Hex(Asc(password_tmp(i))), 2)
        Next
        NowLoginID.Text = "登入帳號 : " & AcctNo(NowNum.Text)
        length = Buwei(Hex(Len(password) \ 2 + 10), 4)
        tmp = "59E9ACADAD59E9" & length & "AC" & Buwei(Hex(Len(password) \ 2), 2) & id & country & version & password
        ReDim pack(Len(tmp) \ 2 - 1)
        For i = 0 To Len(tmp) \ 2 - 1
            pack(i) = Val("&h" & Mid(tmp, 1 + i * 2, 2))
        Next
        If sock1.Connected = True Then
            sock1.Client.Send(pack)
        End If
    End Sub

    Sub ReLogin()
        If sock1.Connected = False Then
            sock1.Connect(ip, 6414)
            sock1.NoDelay = True
        End If

        Dim pack() As Byte
        Dim tmp, length, country, version, id, password As String
        Dim password_tmp() As Char
        Dim i As Integer

        country = Buwei(Hex(Asc(VersionRegion.Text.Substring(0, 1))), 2) & Buwei(Hex(Asc(VersionRegion.Text.Substring(1, 1))), 2)
        version = Buwei(Hex(VersionNum.Text), 4)
        id = Buwei(Hex(Val(AcctNo(NowNum.Text))), 8)
        opassword = TSPassWord.Text
        password_tmp = opassword.ToCharArray
        password = ""
        For i = 0 To password_tmp.GetUpperBound(0)
            password &= Buwei(Hex(Asc(password_tmp(i))), 2)
        Next
        NowLoginID.Text = "登入帳號 : " & AcctNo(NowNum.Text)
        length = Buwei(Hex(Len(password) \ 2 + 10), 4)
        tmp = "59E9ACADAD59E9" & length & "AC" & Buwei(Hex(Len(password) \ 2), 2) & id & country & version & password
        ReDim pack(Len(tmp) \ 2 - 1)
        For i = 0 To Len(tmp) \ 2 - 1
            pack(i) = Val("&h" & Mid(tmp, 1 + i * 2, 2))
        Next
        If sock1.Connected = True Then
            sock1.Client.Send(pack)
        End If
    End Sub

    Private Sub CheckConnectStatus_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles CheckConnectStatus.Tick
        If sock1.Connected = True Then
            If sock1.Client.Available = 0 Then
                Exit Sub
            End If
            Dim tmp() As Byte, data As String, i As Integer
            ReDim tmp(sock1.Client.Available - 1)
            sock1.Client.Receive(tmp)
            data = ""
            For i = 0 To tmp.GetUpperBound(0)
                data &= Hex(tmp(i))
            Next
            My.Computer.FileSystem.WriteAllText("D:\TS_ID\debuglog.txt", data, True)
            My.Computer.FileSystem.WriteAllText("D:\TS_ID\debuglog.txt", "****", True)
            If InStr(data, "59E9AFADB9A5") Then
                If Len(data) > 120000 Then
                    ConnectStatus.Text = "登入狀態：成功登入"
                    NowState = "login"
                    CheckConnectStatus.Stop()
                Else
                    ConnectStatus.Text = "登入狀態：登入失敗->重新連線"
                    sock1.Client.Disconnect(False)
                    sock1.Close()
                    sock1 = New Net.Sockets.TcpClient
                    System.Threading.Thread.Sleep(5000)

                    ReLogin()
                End If
            Else
                If InStr(data, "59E9AFADACAB") Then
                    'chklog = False
                    'logout = True
                    ConnectStatus.Text = "登入狀態：帳密錯誤"
                    sock1.Client.Disconnect(False)
                    sock1.Close()
                    sock1 = New Net.Sockets.TcpClient
                Else
                    If InStr(data, "59E9AFADAD") Then
                        'chklog = False
                        'logout = True
                        Dim error_id As Integer = (Val("&h" & data.Substring(InStr(data, "59E9AFADAD") + 9, 2)) Xor 173)
                        ConnectStatus.Text = "登入狀態：錯誤" & error_id
                        sock1.Client.Disconnect(False)
                        sock1.Close()
                        sock1 = New Net.Sockets.TcpClient
                    End If
                End If
            End If
        End If
    End Sub

    Function Buwei(ByVal data As String, ByVal length As Integer) As String
        Dim i As Integer
        Dim tmp As String = ""
        Do Until Len(data) = length
            data = "0" & data
        Loop
        For i = 1 To length \ 2
            If Len(Hex(Val("&h" & Mid(data, 1 + (i - 1) * 2, 2)) Xor 173)) = 1 Then
                tmp = "0" & Hex(Val("&h" & Mid(data, 1 + (i - 1) * 2, 2)) Xor 173) & tmp
            Else
                tmp = Hex(Val("&h" & Mid(data, 1 + (i - 1) * 2, 2)) Xor 173) & tmp
            End If
        Next
        Buwei = tmp
    End Function

    Sub GoTo12001()

        Dim pack() As Byte
        Dim tmp As String
        Dim i As Integer

        tmp = "59E9A8ADE9AC4C83AC"
        'GO TO 12001
        ReDim pack(Len(tmp) \ 2 - 1)
        For i = 0 To Len(tmp) \ 2 - 1
            pack(i) = Val("&h" & Mid(tmp, 1 + i * 2, 2))
        Next
        If sock1.Connected = True Then
            sock1.Client.Send(pack)
        End If
    End Sub


    Function ChechGo12001TaskDone() As Boolean
        If sock1.Connected = True Then
            If sock1.Client.Available = 0 Then
                ChechGo12001TaskDone = False
                Exit Function
            Else
                Dim tmp() As Byte, data As String, i As Integer
                ReDim tmp(sock1.Client.Available - 1)
                sock1.Client.Receive(tmp)
                data = ""
                For i = 0 To tmp.GetUpperBound(0)
                    data &= Hex(tmp(i))
                Next
                If InStr(data, "4C83") AndAlso Len(data) < 1000 Then
                    DebugLog.Text &= data & vbCrLf
                    'DebugLog.Text &= "get packet" & vbCrLf
                    ChechGo12001TaskDone = True

                End If
            End If
        Else
            

            ChechGo12001TaskDone = False
            Exit Function
        End If
        ChechGo12001TaskDone = False

    End Function

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles MainCtrl.Tick
        'DebugLog.Text &= NowState & vbCrLf
        DebugLog.SelectionStart = DebugLog.Text.Length
        DebugLog.ScrollToCaret()
        DebugLog.Refresh()
        If sock1.Connected = True Then
            If sock1.Client.Available = 0 Then
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        Select Case NowState
            Case "done"
            Case "login"
                If CheckGo12001.Checked = True Then
                    NowState = "goto12001"
                    Exit Sub
                End If
            Case "goto12001"
                If ChechGo12001TaskDone() = False Then
                    GoTo12001()
                End If

        End Select
    End Sub

End Class
