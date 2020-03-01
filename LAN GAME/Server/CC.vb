Public Class CC


    Public Puntos As New List(Of List(Of Integer))
    Public Colors As New List(Of Color)

    Public Property Maximun As Integer = 100
    Public Property AutoMax As Boolean = True

    Public Property LineColor As Color = Color.DimGray
    Public Property LineWidth As Integer = 2


    Private Sub SetMax()

        Dim max As Integer = Maximun
        For Each V As List(Of Integer) In Puntos
            For Each b As Integer In V
                max = Math.Max(max, b)
            Next
        Next
        If AutoMax Then Maximun = max

    End Sub

    Sub DrawLine(index As Integer, ByRef g As Graphics)

        Dim x = (Width / Puntos(index).Count)
        Dim p As New Pen(Colors(index), LineWidth)
        For i = 0 To Puntos(index).Count - 2

            g.DrawLine(p, CSng(i * x), Height - CSng((Puntos(index)(i) * Height) / Maximun), CSng((i + 1) * x), Height - CSng((Puntos(index)(i + 1) * Height) / Maximun))

        Next
        p = Nothing

    End Sub

    Private Sub Chart_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        If Puntos(0).Count = 0 Then Exit Sub

        SetMax()
        For i = 0 To Puntos.Count - 1
            DrawLine(i, e.Graphics)
        Next

    End Sub



End Class
