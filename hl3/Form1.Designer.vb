<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.EventTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LblFPSCounter = New System.Windows.Forms.Label()
        Me.LblLives = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'EventTimer
        '
        '
        'LblFPSCounter
        '
        Me.LblFPSCounter.AutoSize = True
        Me.LblFPSCounter.Location = New System.Drawing.Point(19, 20)
        Me.LblFPSCounter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFPSCounter.Name = "LblFPSCounter"
        Me.LblFPSCounter.Size = New System.Drawing.Size(18, 20)
        Me.LblFPSCounter.TabIndex = 0
        Me.LblFPSCounter.Text = "0"
        '
        'LblLives
        '
        Me.LblLives.AutoSize = True
        Me.LblLives.Location = New System.Drawing.Point(114, 20)
        Me.LblLives.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLives.Name = "LblLives"
        Me.LblLives.Size = New System.Drawing.Size(89, 20)
        Me.LblLives.TabIndex = 1
        Me.LblLives.Text = "Lives: 9001"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1569, 860)
        Me.Controls.Add(Me.LblLives)
        Me.Controls.Add(Me.LblFPSCounter)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EventTimer As System.Windows.Forms.Timer
    Friend WithEvents LblFPSCounter As Label
    Friend WithEvents LblLives As Label
End Class
