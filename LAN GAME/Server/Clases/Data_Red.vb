

' Clases para
' Almacenar datos de red




Public Class R_MiniPlayer

    Public Property Color As Color = Color.Transparent
    Public Property Nombre As String
    Public Property Puntaje As UShort

    Public Property X As Short
    Public Property Y As Short
    Public Property W As UShort = 30
    Public Property H As UShort = 30

    Public Property Angle As Short
    Public Property Precision As Byte = 30
    Public Property Vel As Short

    Public Property Vida As UShort = 100

End Class

Public Class R_Disparo

    Public Property Color As Color

    Public Property X As Short
    Public Property Y As Short
    Public Property W As Byte = 10
    Public Property H As Byte = 10

    Public Property xVel As Short
    Public Property yVel As Short

    Public Property Used As Boolean = False
    Public Property Daño As Byte = 10

End Class

