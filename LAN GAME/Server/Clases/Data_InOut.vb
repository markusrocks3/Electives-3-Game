

' Clases para
' Enviar y recibir informacion

Public Class S_Location

    Public Property Color As Color
    Public Property X As Short
    Public Property Y As Short

End Class

Public Class S_ChangeAngle

    Public Property Color As Color
    Public Property Angle As Short

End Class

Public Class S_Muerte

    Public Property Asesino As Color
    Public Property Victima As Color

End Class

Public Class S_Pausa

    Public Property Color As Color
    Public Property Pausa As Boolean

End Class

Public Class S_Mensaje

    Public Property Color As Color
    Public Property Msg As String

End Class

Public Class S_Nombre

    Public Property Color As Color
    Public Property Nombre As String

End Class

Public Class S_Gun

    Public Property X As Short
    Public Property Y As Short
    Public Property Gun As TipoArma = TipoArma.M9

End Class
