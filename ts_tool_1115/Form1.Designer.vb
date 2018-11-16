<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.debug_log = New System.Windows.Forms.Label()
        Me.IPAddr = New System.Windows.Forms.TextBox()
        Me.NowNum = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NowLoginID = New System.Windows.Forms.Label()
        Me.ConnectStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TSPassWord = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.VersionRegion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.VersionNum = New System.Windows.Forms.TextBox()
        Me.CheckConnectStatus = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(378, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "登入"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Server IP"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'debug_log
        '
        Me.debug_log.AutoSize = True
        Me.debug_log.Location = New System.Drawing.Point(416, 24)
        Me.debug_log.Name = "debug_log"
        Me.debug_log.Size = New System.Drawing.Size(37, 12)
        Me.debug_log.TabIndex = 2
        Me.debug_log.Text = "--------"
        '
        'IPAddr
        '
        Me.IPAddr.Location = New System.Drawing.Point(71, 52)
        Me.IPAddr.Name = "IPAddr"
        Me.IPAddr.Size = New System.Drawing.Size(100, 22)
        Me.IPAddr.TabIndex = 4
        Me.IPAddr.Text = "210.242.243.31"
        Me.IPAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NowNum
        '
        Me.NowNum.Location = New System.Drawing.Point(71, 80)
        Me.NowNum.Name = "NowNum"
        Me.NowNum.Size = New System.Drawing.Size(100, 22)
        Me.NowNum.TabIndex = 5
        Me.NowNum.Text = "0"
        Me.NowNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "當前為"
        '
        'NowLoginID
        '
        Me.NowLoginID.AutoSize = True
        Me.NowLoginID.Location = New System.Drawing.Point(12, 193)
        Me.NowLoginID.Name = "NowLoginID"
        Me.NowLoginID.Size = New System.Drawing.Size(98, 12)
        Me.NowLoginID.TabIndex = 7
        Me.NowLoginID.Text = "登入帳號 : ******"
        '
        'ConnectStatus
        '
        Me.ConnectStatus.AutoSize = True
        Me.ConnectStatus.Location = New System.Drawing.Point(12, 223)
        Me.ConnectStatus.Name = "ConnectStatus"
        Me.ConnectStatus.Size = New System.Drawing.Size(113, 12)
        Me.ConnectStatus.TabIndex = 8
        Me.ConnectStatus.Text = "登入狀態：斷開連接"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "密碼"
        '
        'TSPassWord
        '
        Me.TSPassWord.Location = New System.Drawing.Point(71, 109)
        Me.TSPassWord.Name = "TSPassWord"
        Me.TSPassWord.Size = New System.Drawing.Size(100, 22)
        Me.TSPassWord.TabIndex = 10
        Me.TSPassWord.Text = "123456"
        Me.TSPassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "版本代號"
        '
        'VersionRegion
        '
        Me.VersionRegion.Location = New System.Drawing.Point(71, 24)
        Me.VersionRegion.Name = "VersionRegion"
        Me.VersionRegion.Size = New System.Drawing.Size(25, 22)
        Me.VersionRegion.TabIndex = 12
        Me.VersionRegion.Text = "TP"
        Me.VersionRegion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(108, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "版本"
        '
        'VersionNum
        '
        Me.VersionNum.Location = New System.Drawing.Point(143, 24)
        Me.VersionNum.Name = "VersionNum"
        Me.VersionNum.Size = New System.Drawing.Size(28, 22)
        Me.VersionNum.TabIndex = 14
        Me.VersionNum.Text = "188"
        Me.VersionNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckConnectStatus
        '
        Me.CheckConnectStatus.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 264)
        Me.Controls.Add(Me.VersionNum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.VersionRegion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TSPassWord)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ConnectStatus)
        Me.Controls.Add(Me.NowLoginID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NowNum)
        Me.Controls.Add(Me.IPAddr)
        Me.Controls.Add(Me.debug_log)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "秋風老王吃大便"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents debug_log As Label
    Friend WithEvents IPAddr As TextBox
    Friend WithEvents NowNum As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NowLoginID As Label
    Friend WithEvents ConnectStatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TSPassWord As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents VersionRegion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents VersionNum As TextBox
    Friend WithEvents CheckConnectStatus As Timer
End Class
