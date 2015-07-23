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
        Me.EventTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LblFPSCounter = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'EventTimer
        '
        '
        'LblFPSCounter
        '
        Me.LblFPSCounter.AutoSize = True
        Me.LblFPSCounter.Location = New System.Drawing.Point(13, 13)
        Me.LblFPSCounter.Name = "LblFPSCounter"
        Me.LblFPSCounter.Size = New System.Drawing.Size(13, 13)
        Me.LblFPSCounter.TabIndex = 0
        Me.LblFPSCounter.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 384)
        Me.Controls.Add(Me.LblFPSCounter)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EventTimer As System.Windows.Forms.Timer
    Friend WithEvents LblFPSCounter As Label
End Class
