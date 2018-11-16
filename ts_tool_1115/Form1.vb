﻿Public Class Form1
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IPAddr.Text = "210.242.243.31"
        ip = IPAddr.Text
        AcctNo = Split(My.Computer.FileSystem.ReadAllText("D:\TS_ID\AA+BB+CC+DD.txt", System.Text.Encoding.Default), ",")
        AcctNo_max_num = UBound(AcctNo)
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
            chklog = True
        End If



        debug_log.Text = AcctNo(NowNum.Text)
        Timer1.Interval = 1
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
        CheckConnectStatus.Start()
        'Timer3.Start()
    End Sub

    Private Sub CheckConnectStatus_Tick(sender As Object, e As EventArgs) Handles CheckConnectStatus.Tick
        If sock1.Connected = True AndAlso chklog = True Then
            If sock1.Client.Available = 0 Then Exit Sub
            Dim tmp() As Byte, data As String, i As Integer
            ReDim tmp(sock1.Client.Available - 1)
            sock1.Client.Receive(tmp)
            data = ""
            For i = 0 To tmp.GetUpperBound(0)
                data &= Hex(tmp(i))
            Next
            If InStr(data, "59E9AFADB9A5") Then
                chklog = True
                logout = False
                ConnectStatus.Text = "登入狀態：成功登入"
            Else
                If InStr(data, "59E9AFADACAB") Then
                    chklog = False
                    logout = True
                    ConnectStatus.Text = "登入狀態：帳密錯誤"
                    sock1.Client.Disconnect(False)
                    sock1.Close()
                    sock1 = New Net.Sockets.TcpClient
                Else
                    If InStr(data, "59E9AFADAD") Then
                        chklog = False
                        logout = True
                        Dim error_id As Integer = (Val("&h" & data.Substring(InStr(data, "59E9AFADAD") + 9, 2)) Xor 173)
                        ConnectStatus.Text = "登入狀態：錯誤" & error_id
                        sock1.Client.Disconnect(False)
                        sock1.Close()
                        sock1 = New Net.Sockets.TcpClient
                    End If
                End If
            End If
            'chklogin()
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If i > AcctNo_max_num Then
            Timer1.Stop()
        Else
            debug_log.Text = AcctNo(NowNum.Text)
            i += 1
        End If

    End Sub
End Class
