Public Class Form1
    Public Shared INSTANCE As Form1

    Private Objects As List(Of Tickable) = New List(Of Tickable)
    Public Asteroids As List(Of Asteroid) = New List(Of Asteroid)
    Public Ship As Spaceship
    Public Missiles As List(Of Missile) = New List(Of Missile)

    Private KeyStatuses As Dictionary(Of Keys, Boolean) = New Dictionary(Of Keys, Boolean)

    Private FPSCounterThread As Threading.Thread
    Public FramesDone = 0
    Private LastFPS As Integer = 0
    Private CurFPS As Integer = 30
    Private MaxAsteroids As Integer = 5
    Private FramesSinceLastAsteroid = 30
    Private Const ASTEROID_SPEED = 5

    Public StartTime = New Date()
    Private InLoop = False
    Private ToSpawn = New List(Of Tickable)
    Private ToUnspawn = New List(Of Tickable)

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        INSTANCE = Me
        FPSCounterThread = New System.Threading.Thread(AddressOf Thread_FPSCounter)
    End Sub

    Private Sub RandomlySpawnAsteroid()
        Dim r = New Random()
        Dim x = r.Next() Mod Me.Width
        Dim y = r.Next() Mod Me.Height
        Dim xChange = r.NextDouble()
        Dim yChange = Math.Sqrt(1 - Math.Pow(xChange, 2))
        yChange *= ASTEROID_SPEED
        xChange *= ASTEROID_SPEED
        Dim asteroid = New Asteroid(xChange, yChange)
        Spawn(asteroid, x, y)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Console.WriteLine(e.KeyCode.ToString() & " down")
        If Me.KeyStatuses.ContainsKey(e.KeyCode) Then
            Me.KeyStatuses.Remove(e.KeyCode)
        End If

        Me.KeyStatuses.Add(e.KeyCode, True)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        'Console.WriteLine(e.KeyCode.ToString() & " up")
        If Me.KeyStatuses.ContainsKey(e.KeyCode) Then
            Me.KeyStatuses.Remove(e.KeyCode)
        End If
        Me.KeyStatuses.Add(e.KeyCode, False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EventTimer.Interval = 1000 / 40
        EventTimer.Start()
        StartTime = New Date()
        FPSCounterThread.Start()
        'Dim s As Asteroid = New Asteroid()
        Dim s = New Spaceship()
        Spawn(s, 20, 20)
        'Spawn(s, 20, 20)
    End Sub

    Private Sub Thread_FPSCounter()
        While True
            Threading.Thread.Sleep(1000)
            CurFPS = (FramesDone)
            FramesDone = 0
        End While
    End Sub

    Public Function IsKeyPressed(k As Keys) As Boolean
        If Me.KeyStatuses.ContainsKey(k) Then
            Dim r = False
            Me.KeyStatuses.TryGetValue(k, r)
            Return r
        End If
        Return False
    End Function


    Public Sub Spawn(t As Tickable, x As Integer, y As Integer)
        t.Top = y
        t.Left = x
        Console.WriteLine("Spawning " & t.GetType().ToString() & " at " & x & ", " & y)
        If Me.InLoop Then
            ToSpawn.Add(t)
        Else
            Objects.Add(t)
        End If
        If TypeOf t Is Asteroid Then
            Asteroids.Add(t)
        ElseIf TypeOf t Is Spaceship Then
            Ship = t
        ElseIf TypeOf t Is Missile Then
            Missiles.Add(t)
        End If
        ' TODO: individual objects should decide this, not the main thread
        t.Height = 32
        t.Width = 32
        Me.Controls.Add(t)
    End Sub

    Public Sub ded(livesLeft As Integer)
        If livesLeft < 0 Then
            If Form2.Visible Then
                Return
            End If
            Form2.ShowDialog()
            End
        End If
        LblLives.Text = "Lives: " & livesLeft
    End Sub

    Public Sub Unspawn(t As Tickable)
        Me.Controls.Remove(t)
        If Me.InLoop Then
            ToUnspawn.Add(t)
        Else
            Objects.Remove(t)
        End If
        If TypeOf t Is Asteroid Then
            Asteroids.Remove(t)
        ElseIf TypeOf t Is Spaceship Then
            Ship = Nothing
            Console.WriteLine("Deleting the Ship!")
        ElseIf TypeOf t Is Missile Then
            Missiles.Remove(t)
        End If
    End Sub

    Private Sub EventTimer_Tick(sender As Object, e As EventArgs) Handles EventTimer.Tick
        If Asteroids.Count < MaxAsteroids And FramesSinceLastAsteroid > 60 Then
            RandomlySpawnAsteroid()
            FramesSinceLastAsteroid = -1
        End If
        Me.InLoop = True
        For Each I In Objects
            I.Tick(Me)
        Next
        Me.InLoop = False
        For Each I In ToSpawn
            Objects.Add(I)
        Next
        For Each I In ToUnspawn
            Console.WriteLine("UNSPAWN")
            Objects.Remove(I)
        Next
        ToUnspawn = New List(Of Tickable)
        ToSpawn = New List(Of Tickable)
        If LastFPS <> CurFPS Then
            Me.LblFPSCounter.Text = CurFPS
            LastFPS = CurFPS
        End If
        FramesDone += 1
        FramesSinceLastAsteroid += 1
    End Sub

    Private Sub LblLives_Click(sender As Object, e As EventArgs) Handles LblLives.Click

    End Sub

End Class
