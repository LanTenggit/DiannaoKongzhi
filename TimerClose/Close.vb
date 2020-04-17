Imports System.Data
Imports System.Threading

Public Class Close


    Dim thread As Thread
    Private Sub Close_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ComboBox1.SelectedItem = ComboBox1.Items(0)

    End Sub






    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim thread As Thread = New Threading.Thread(AddressOf TimerClose)
        thread.Start()

    End Sub




    ''' <summary>
    ''' 定时重启
    ''' </summary>
    Public Sub TimerClose()


        While True
            Thread.Sleep(1000)


            Dim h = Convert.ToInt32(Me.ComboBox1.SelectedItem.ToString)
        Dim m = Convert.ToInt32(Me.TextBox1.Text)
        Dim siteResponds As Boolean = My.Computer.Network.Ping("10.114.113.2")
        Select Case siteResponds
            Case False

                MessageBox.Show("服务器连接失败!")

                Exit Select
                Return
            Case True

                Dim Nowtime = Now().ToString("H:mm:ss")
                If Convert.ToDateTime(Nowtime).Hour = h AndAlso Convert.ToDateTime(Nowtime).Minute >= m AndAlso Convert.ToDateTime(Nowtime).Minute <= m + 1 Then
                    CloseAPP()
                End If


        End Select

        End While

    End Sub
    ''' <summary>
    ''' 关闭程序
    ''' </summary>
    Public Sub CloseAPP()
        Shell("shutdown -f -r -t 0")
    End Sub
    ''' <summary>
    ''' 重启
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CloseAPP()
    End Sub
    ''关闭
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Shell("shutdown -f -s -t 0", vbHide) '关闭
        'Shell("shutdown -f -r -t 0", vbHide) '重启
    End Sub
    '注销
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Shell("shutdown -f -l -t 0", vbHide) '注销
    End Sub
End Class
