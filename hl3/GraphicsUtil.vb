Public Class GraphicsUtil
    Public Shared Function RotateImage(img As Image, angle As Double) As Bitmap
        If IsNothing(img) Then
            Throw New ArgumentNullException("img")
        End If
        Dim rotated = New Bitmap(img.Width, img.Height)
        rotated.SetResolution(img.HorizontalResolution, img.VerticalResolution)

        Dim g = Graphics.FromImage(rotated)

        Dim offset = New PointF(img.Height / 2, img.Width / 2)

        g.TranslateTransform(offset.X, offset.Y)
        g.RotateTransform(angle)
        g.TranslateTransform(-offset.X, -offset.Y)
        g.DrawImage(img, New PointF(0, 0))
        Return rotated
    End Function
End Class
