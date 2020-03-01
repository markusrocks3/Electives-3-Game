
Public Class vPlayer

    Public Property En As Boolean = True

    Public Property Color As Color = Color.Gray
        Public Property Angle As Short = 0
    Public Property Precision As Byte = 10

    Public Property Nombre As String
            Get
                Return Label1.Text
            End Get
            Set(value As String)
                Label1.Text = value
            End Set
        End Property
        Public Property IP As String
            Get
                Return Label2.Text
            End Get
            Set(value As String)
                Label2.Text = value
            End Set
        End Property

        Private Sub vPlayer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
            With e.Graphics


                ' ------------------- Gráficos al Máximo  ----------------
                .CompositingMode = Drawing2D.CompositingMode.SourceOver
                .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                .TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit



                .TranslateTransform(37.5F, 37.5F)
            Using pp As New Pen(CType(IIf(En, Color, ControlPaint.Light(Me.BackColor, 25)), Color), 4)

                Label1.ForeColor = pp.Color
                Label2.ForeColor = pp.Color

                .FillEllipse(pp.Brush, -15, -15, 30, 30)
                .DrawArc(pp, -25, -25, 50, 50, Angle - CSng(Precision / 2), Precision)


                .TranslateTransform(-37.5F, -37.5F)
                .FillRectangle(pp.Brush, 20, Height - 2, Width - 40, 2)
            End Using




        End With


        End Sub

    Private Sub vPlayer_Load(sender As Object, e As EventArgs) Handles Me.Load
        DoubleBuffered = True
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If En Then
            En = False
            Invalidate()
            RaiseEvent Disconect(IP)
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If En Then
            btnDel.Text = "Desconectar"
        Else
            btnDel.Text = "Eliminar"
        End If
    End Sub

    Public Event Disconect(thisIP As String)

End Class