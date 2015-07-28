
Public Class Missile
    Inherits Tickable
    Private xc As Integer
    Private yc As Integer
    Public Sub New(xChange As Integer, yChange As Integer)
        Me.xc = xChange
        Me.yc = yChange
        Me.BackgroundImage = My.Resources.missile
        Me.Height = 32
        Me.Width = 32
    End Sub

    Public Overrides Sub Tick(blah As Form1)
        Me.Left += Me.xc
        Me.Top += Me.yc
        If Me.Left > Me.Parent.Width Or Me.Right < 0 Or Me.Top > Me.Parent.Height Or Me.Bottom < 0 Then
            blah.Unspawn(Me)
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
