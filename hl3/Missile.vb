
Public Class Missile
    Inherits Tickable
    Private xc As Integer
    Private yc As Integer
    Private Const MAX_TICKS = 90
    Private ticks As Integer = 0
    Public Sub New(xChange As Integer, yChange As Integer)
        Me.xc = xChange
        Me.yc = yChange
        Me.BackgroundImage = My.Resources.missile
        Me.Height = 7
        Me.Width = 7
    End Sub

    Public Overrides Sub Tick(blah As Form1)
        If ticks >= MAX_TICKS Then
            blah.Unspawn(Me)
            Return
        End If
        Me.ticks += 1
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
        Dim i = 0
        Dim rekt = False
        While i < blah.Asteroids.Count
            If Me.Bounds.IntersectsWith(blah.Asteroids(i).Bounds) Then
                Console.WriteLine("RIP Asteroid")
                blah.Asteroids(i).MissileCollision()
                rekt = True
                Exit While ' break
            End If
            i += 1
        End While
        If rekt Then
            blah.Unspawn(Me)
        End If
    End Sub
End Class
