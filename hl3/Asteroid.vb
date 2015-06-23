Public Class Asteroid
    Inherits Tickable

    Private DestroyedCount As Integer

    Public Sub New()
        DestroyedCount = 0
    End Sub

    Private Sub New(dc As Integer)
        DestroyedCount = dc
    End Sub

    Private Sub Init()
        Me.Image = My.Resources.rock
        Me.Width = 128
        Me.Height = 128
    End Sub


    Public Overrides Sub Tick()
        'This is called 20-30 times every second in theory
        Console.WriteLine("Tick!")
        Dim rand = New Random()
        If rand.Next() Mod 10 > 5 Then
            Me.Left += 5
        Else
            Me.Left -= 5
        End If



    End Sub

    Sub Dead()

    End Sub
End Class
