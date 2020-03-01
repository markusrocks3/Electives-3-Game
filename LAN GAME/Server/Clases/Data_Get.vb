


Public Class Data_Get

    Public Property TipoDato As TipoDato
    Public Property Value As Object

End Class

Public Enum TipoDato
    Location
    ChangeAngle

    Muerte
    Mensaje
    Pausa

    Disparo
    Nombre
    NewPlayer

    Gun
    ResetGuns

End Enum

Public Enum TipoArma
    x99x
    M14
    M9
    Rifle
    R49
    Sub55


End Enum

Public Module DataGet_Converter

    Public Function dataToString(ByRef dt As Data_Get) As String
        Dim values As New List(Of String) ' Valores a enviar
        values.Add(dt.TipoDato)

        Select Case dt.TipoDato
            Case TipoDato.Location
                Dim k As S_Location = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(k.X)
                    .Add(k.Y)
                End With
                k = Nothing

            Case TipoDato.ChangeAngle
                Dim k As S_ChangeAngle = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(k.Angle)
                End With
                k = Nothing

            Case TipoDato.Muerte
                Dim k As S_Muerte = dt.Value
                With values
                    .Add(k.Asesino.ToArgb)
                    .Add(k.Victima.ToArgb)
                End With
                k = Nothing

            Case TipoDato.Mensaje
                Dim k As S_Mensaje = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(k.Msg)
                End With
                k = Nothing

            Case TipoDato.Pausa
                Dim k As S_Pausa = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(IIf(k.Pausa, 1, 0))
                End With
                k = Nothing

            Case TipoDato.Disparo
                Dim k As R_Disparo = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(k.X)
                    .Add(k.Y)
                    .Add(k.W)
                    .Add(k.H)
                    .Add(k.xVel)
                    .Add(k.yVel)
                    .Add(IIf(k.Used, 1, 0))
                    .Add(k.Daño)
                End With
                k = Nothing

            Case TipoDato.Nombre
                Dim k As S_Nombre = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(k.Nombre)
                End With
                k = Nothing

            Case TipoDato.NewPlayer
                Dim k As R_MiniPlayer = dt.Value
                With values
                    .Add(k.Color.ToArgb)
                    .Add(k.Nombre)
                    .Add(k.Puntaje)
                    .Add(k.X)
                    .Add(k.Y)
                    .Add(k.W)
                    .Add(k.H)
                    .Add(k.Angle)
                    .Add(k.Precision)
                    .Add(k.Vel)
                    .Add(k.Vida)
                End With
                k = Nothing



            Case TipoDato.Gun
                Dim k As S_Gun = dt.Value
                With values
                    .Add(k.X)
                    .Add(k.Y)
                    .Add(k.Gun)
                End With
                k = Nothing

            Case TipoDato.ResetGuns
                ' Do not nothing



        End Select

        Dim x As String = String.Join("|", values)
        values = Nothing
        Return x
    End Function

    Public Function dataFromString(ByRef str As String) As Data_Get
        Dim values = str.Split("|")
        Dim x As New Data_Get


        x.TipoDato = CType(values(0), TipoDato)
        Select Case x.TipoDato

            Case TipoDato.Location
                Dim k As New S_Location
                With k
                    .Color = Color.FromArgb(values(1))
                    .X = values(2)
                    .Y = values(3)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.ChangeAngle
                Dim k As New S_ChangeAngle
                With k
                    .Color = Color.FromArgb(values(1))
                    .Angle = values(2)
                End With
                x.Value = k
                k = Nothing



            Case TipoDato.Muerte
                Dim k As New S_Muerte
                With k
                    .Asesino = Color.FromArgb(values(1))
                    .Victima = Color.FromArgb(values(2))
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.Mensaje
                Dim k As New S_Mensaje
                With k
                    .Color = Color.FromArgb(values(1))
                    .Msg = values(2)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.Pausa
                Dim k As New S_Pausa
                With k
                    .Color = Color.FromArgb(values(1))
                    .Pausa = values(2)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.Disparo
                Dim k As New R_Disparo
                With k
                    .Color = Color.FromArgb(values(1))
                    .X = values(2)
                    .Y = values(3)
                    .W = values(4)
                    .H = values(5)
                    .xVel = values(6)
                    .yVel = values(7)
                    .Used = values(8)
                    .Daño = values(9)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.Nombre
                Dim k As New S_Nombre
                With k
                    .Color = Color.FromArgb(values(1))
                    .Nombre = values(2)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.NewPlayer
                Dim k As New R_MiniPlayer
                With k
                    .Color = Color.FromArgb(values(1))
                    .Nombre = values(2)
                    .Puntaje = values(3)
                    .X = values(4)
                    .Y = values(5)
                    .W = values(6)
                    .H = values(7)
                    .Angle = values(8)
                    .Precision = values(9)
                    .Vel = values(10)
                    .Vida = values(11)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.Gun
                Dim k As New S_Gun
                With k
                    .X = values(1)
                    .Y = values(2)
                    .Gun = values(3)
                End With
                x.Value = k
                k = Nothing

            Case TipoDato.ResetGuns
                ' Do not nothing


        End Select



        values = Nothing
        Return x
    End Function


End Module

