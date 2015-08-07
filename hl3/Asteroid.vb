Public Class Asteroid
    Inherits Tickable



    Private DestroyedCount As Integer
    Private xc As Double
    Private yc As Double
    Private ticking As Boolean = False ' necessary so that it doesn't crash
    Public Sub New(xChange As Double, yChange As Double)
        DestroyedCount = 0
        Me.BackgroundImage = My.Resources.rock
        Me.xc = xChange
        Me.yc = yChange
        Me.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub New(dc As Integer)
        DestroyedCount = dc
    End Sub

    Private Sub Init()
        Me.Image = My.Resources.rock
        Me.Width = 32
        Me.Height = 32

    End Sub

    Public Sub MissileCollision()
        Console.WriteLine("RIP")
        While ticking 'Um
        End While
        Form1.INSTANCE.Unspawn(Me)
    End Sub


    Public Overrides Sub Tick(blah As Form1)
        'This is called 20-30 times every second in theory
        ticking = True
        Me.Left += Me.xc
        Me.Top += Me.yc
        If IsNothing(Parent) Then
            Return
        End If
        If Me.Left > Parent.Width And Me.xc > 0 Then ' gone off-screen
            Me.Left = -Me.Width
        ElseIf Me.Right < 0 And Me.xc < 0 Then
            Me.Left = Parent.Width
        ElseIf Me.Top < 0 And Me.yc < 0 Then
            Me.Top = Parent.Height
        ElseIf Me.Top > Parent.Height And Me.yc > 0 Then
            Me.Top = -Me.Height
        End If

        If blah.Ship.Overlaps(Me.Bounds) Then
            blah.Ship.Collided()
            ticking = False
            Me.MissileCollision()
        End If
        ticking = False
    End Sub

    Sub Dead()

    End Sub
End Class
