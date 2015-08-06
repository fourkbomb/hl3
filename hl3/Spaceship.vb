
Public Class Spaceship
    Inherits Tickable

    Public Enum Direction
        UP
        DOWN
        LEFT
        RIGHT
    End Enum
    Private ImageUp As Image = My.Resources.spaceship
    Private Facing As Direction = Direction.UP
    Private FramesSinceLastShot = 30
    Private FramesSinceLastAster = 30
    Private Const MISSILE_SPEED = 9
    Private Const SLOWDOWN = 0.98
    Private Angle As Integer = 0
    Private Lives As Integer = 3
    Private InvincibilityFrames As Integer = 0
    Private Spawning As Boolean = True

    Dim curXChange As Single = 0
    Dim curYChange As Single = 0

    Public Sub New()
        Me.Image = My.Resources.spaceship
    End Sub

    Private Sub HandleMovement(d As Direction)

        Dim sv = GetSpeedVector()
        Me.curYChange = sv.Y * 7
        Me.curXChange = sv.X * 7

    End Sub

    Private Sub HandleRotation(dir As Direction)
        If dir = Direction.LEFT Then
            Me.Angle -= 5
        Else
            Me.Angle += 5
        End If
        If Me.Angle < 0 Then
            Me.Angle = 360 - Math.Abs(Me.Angle)
        End If
        Me.Angle = Me.Angle Mod 360
        Me.Image = GraphicsUtil.RotateImage(My.Resources.spaceship, Me.Angle)
        'Dim speedVector = GetSpeedVector()
        'Me.curXChange = speedVector.X * 5
        'Me.curYChange = speedVector.Y * 5
    End Sub

    Private Function GetCentre() As Point
        Dim centreX = (Me.Left + Me.Right) / 2
        Dim centreY = (Me.Top + Me.Bottom) / 2
        Return New Point(centreX, centreY)
    End Function

    Public Function Overlaps(r As Rectangle) As Boolean ' TODO make this better
        If r.Contains(GetCentre()) Then
            Return True
        End If
        Return False
    End Function

    Public Sub Collided()
        If Spawning Then
            Return
        End If
        Lives -= 1
        CType(Me.Parent, Form1).ded(Lives)
        If Lives >= 0 Then
            ' teleport somewhere safe
            'Dim p As Form1 = CType(Me.Parent, Form1)
            Spawning = True
        End If
    End Sub

    Private Function GetSpeedVector() As PointF
        Dim yChange = Math.Abs(Math.Cos(Math.PI * Me.Angle / 180))
        Dim xChange = Math.Abs(Math.Sin(Math.PI * Me.Angle / 180))
        If Me.Angle < 90 Then
            yChange = -yChange
        ElseIf Me.Angle < 180 Then
            ' Do nothing
        ElseIf Me.Angle < 270 Then
            xChange = -xChange
        Else
            xChange = -xChange
            yChange = -yChange
        End If
        Return New PointF(xChange, yChange)
    End Function

    Private Sub Shoot()
        ' We know the hypotenuse and the angle. sin(myAngle) * 7 = y change cos(myAngle) * 7 = x change
        Dim vec = GetSpeedVector()
        Dim xChange = vec.X * MISSILE_SPEED
        Dim yChange = vec.Y * MISSILE_SPEED
        Console.WriteLine("Will Change by: (Angle => " & Me.Angle & ") " & xChange & ", " & yChange)
        Dim missile = New Missile(xChange, yChange)
        Console.WriteLine("Pos: " & Me.Left & ", " & Me.Top & " -- Missile dimensions: " & missile.Height & " x " & missile.Width)
        Dim y = (Me.Top + Me.Bottom) \ 2
        Dim x = (Me.Left + Me.Right) \ 2
        y -= missile.Height \ 2
        x -= missile.Width \ 2
        Form1.INSTANCE.Spawn(missile, x, y)
    End Sub

    Public Overrides Sub Tick(form1 As Form1)
        ' Called 20-30 times every second
        If Spawning Then
            ' Flash on and off
            ' Return to a safe place/be invincible or something
            If InvincibilityFrames Mod 5 = 0 Then
                Me.Visible = Not Me.Visible
            End If
            InvincibilityFrames += 1
            If InvincibilityFrames > 60 Then
                Me.Visible = True
                Spawning = False
                InvincibilityFrames = 0
            End If
        End If
        Me.Top += Me.curYChange
        Me.Left += Me.curXChange
        ' slow down a little bit
        Me.curXChange *= SLOWDOWN
        Me.curYChange *= SLOWDOWN

        If (Me.Left + Me.Width / 2) > Parent.Width And Me.curXChange > 0 Then ' gone off-screen, come back on the other side
            Me.Left = -Me.Width / 2
        ElseIf Me.Right < 0 And Me.curYChange < 0 Then
            Me.Left = Parent.Width - Me.Width / 2
        ElseIf Me.Top < 0 And Me.curYChange < 0 Then
            Me.Top = Parent.Height - Me.Height / 2
        ElseIf (Me.Top - Me.Height / 2) > Parent.Height And Me.curYChange > 0 Then
            Me.Top = -Me.Height / 2
        End If
        If Not Me.Visible Then
            FramesSinceLastAster += 1
            FramesSinceLastShot += 1
            Return
        End If
        If form1.IsKeyPressed(Keys.Space) And FramesSinceLastShot > 15 Then
            FramesSinceLastShot = 0
            Shoot()
        End If
        If form1.IsKeyPressed(Keys.S) Then
            HandleMovement(Direction.DOWN)
        End If

        If form1.IsKeyPressed(Keys.W) Then
            HandleMovement(Direction.UP)
        End If

        If form1.IsKeyPressed(Keys.D) Then
            'HandleMovement(Direction.RIGHT)
            HandleRotation(Direction.RIGHT)
        End If

        If form1.IsKeyPressed(Keys.A) Then
            HandleRotation(Direction.LEFT)
        End If

        If form1.IsKeyPressed(Keys.Z) And FramesSinceLastAster > 15 Then
            Dim vector = GetSpeedVector()
            FramesSinceLastAster = 0
            Dim aster = New Asteroid(vector.X * 4, vector.Y * 4)
            Form1.INSTANCE.Spawn(aster, 60, 60)
        End If
        FramesSinceLastAster += 1
        FramesSinceLastShot += 1
    End Sub
End Class
