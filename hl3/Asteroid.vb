Public Class Asteroid
    Inherits Tickable



    Private DestroyedCount As Integer
    Private xc As Double
    Private yc As Double
    Public Sub New(xChange As Double, yChange As Double)
        DestroyedCount = 0
        Me.BackgroundImage = My.Resources.rock
        Me.xc = xChange
        Me.yc = yChange

    End Sub

    Private Sub New(dc As Integer)
        DestroyedCount = dc
    End Sub

    Private Sub Init()
        Me.Image = My.Resources.rock
        Me.Width = 128
        Me.Height = 128
    End Sub

    Public Sub MissileCollision()
        Console.WriteLine("RIP")
        Form1.INSTANCE.Unspawn(Me)
    End Sub


    Public Overrides Sub Tick(blah As Form1)
        'This is called 20-30 times every second in theory
        Me.Left += Me.xc
        Me.Top += Me.yc
        If Me.Left > Parent.Width And Me.xc > 0 Then ' gone off-screen
            Me.Left = -Me.Width
        ElseIf Me.Right < 0 And Me.xc < 0 Then
            Me.Left = Parent.Width
        ElseIf Me.Top < 0 And Me.yc < 0 Then
            Me.Top = Parent.Height
        ElseIf Me.Top > Parent.Height And Me.yc > 0 Then
            Me.Top = -Me.Height
        End If


    End Sub

    Sub Dead()

    End Sub
End Class
