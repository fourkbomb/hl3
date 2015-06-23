Public Class Form1

    Private Objects As List(Of Tickable) = New List(Of Tickable)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EventTimer.Interval = 1000 / 30
        EventTimer.Start()
        Dim s As Asteroid = New Asteroid()
        Spawn(s, 20, 20)
    End Sub

    Public Sub Spawn(t As Tickable, x As Integer, y As Integer)
        t.Top = y
        t.Height = x
        Objects.Add(t)
        t.BackgroundImage = My.Resources.rock
        t.Height = 128
        t.Width = 128
        Me.Controls.Add(t)
    End Sub

    Private Sub EventTimer_Tick(sender As Object, e As EventArgs) Handles EventTimer.Tick
        For Each I In Objects
            I.Tick()
        Next
    End Sub
End Class
