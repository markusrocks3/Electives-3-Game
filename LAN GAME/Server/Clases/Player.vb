
Public Class Player

    Public R As Random

#Region " MiniPlayer "

    Public Property Color As Color
    Public Property Nombre As String
    Public Property Puntaje As UShort

    Public Property X As Short
    Public Property Y As Short
    Public Property W As UShort = 30
    Public Property H As UShort = 30

    Public Property Angle As Short
    Public Property Precision As Byte = 30

    Public Property Vida As UShort = 100

    Public Function GetMiniPlayer() As R_MiniPlayer
        Dim k As New R_MiniPlayer With {
            .Nombre = Nombre,
            .Color = Color,
            .Puntaje = Puntaje,
            .X = X,
            .Y = Y,
            .W = W,
            .H = H,
            .Angle = Angle,
            .vel = Vel,
            .Precision = Precision,
            .Vida = Vida
        }
        Return k
    End Function

#End Region

#Region " Propiedades "

    Public Disparos As New List(Of R_Disparo)

#Region "       Disparos "

    Public Property D_Presicion As Byte = 4

    Public Property D_MinVel As Byte = MaxVel
    Public Property D_MaxVel As Byte = 25

    Public Property D_MaxW As Byte = 15
    Public Property D_MaxH As Byte = 15
    Public Property D_MinW As Byte = 3
    Public Property D_MinH As Byte = 3

    Public Property D_CantidadPer As Byte = 1
    Public Property D_Actual As Byte = 10
    Public Property D_Max As Byte = 10

    Public Property D_MinDaño As Byte = 5
    Public Property D_MaxDaño As Byte = 10


#End Region

#Region "       Area de Juego "

    ' Area de Juego
    Public Property GameLocation As New Point
    Public Property GameSize As Size = New Size(800, 600)


#End Region

#Region "       Control "

    ' Teclas
    Public Property UseMouseControls As Boolean = True
    Public Property KeyUp As Keys = Keys.Up
    Public Property KeyLeft As Keys = Keys.Left
    Public Property KeyRight As Keys = Keys.Right
    Public Property KeyDown As Keys = Keys.Down

    ' Velocidad
    Public Property RotVel As Short = 5
    Public Property Vel As Short = 0
    Public Property MaxVel As Short = 10
    Public Property MinVel As Short = -10
    Public Property Aceleracion As Short = 2
    Public Property Desaceleracion As Short = 1
    Public Property Freno As Short = 5

#End Region

#End Region

#Region " Eventos "

    Public Event Refresh(ByRef sender As Player)
    Public Event Disparo(ByRef sender As Player, ByRef e As R_Disparo)

    Public Event StartMove(ByRef sender As Player)
    Public Event StopMove(ByRef sender As Player)
    Public Event ChangeAngle(ByRef sender As Player)


#End Region

#Region " Procedimientos "

#Region "       Teclado  "
    Dim Tecla(4) As Boolean
    Public Sub KeysDown(e As KeyEventArgs)
        Select Case e.KeyData
            Case KeyUp : Tecla(0) = True
            Case KeyLeft : Tecla(1) = True
            Case KeyRight : Tecla(2) = True
            Case KeyDown : Tecla(3) = True
        End Select
    End Sub
    Public Sub KeysUp(e As KeyEventArgs)
        Select Case e.KeyData
            Case KeyUp : Tecla(0) = False
            Case KeyLeft : Tecla(1) = False
            Case KeyRight : Tecla(2) = False
            Case KeyDown : Tecla(3) = False
        End Select
    End Sub
#End Region

#Region "       Disparos  "

    Public Sub MoverDisparos()
        If Disparos.Count = 0 Then Exit Sub


        Dim z As R_Disparo
        For i = Disparos.Count - 1 To 0 Step -1
            z = Disparos(i)
            z.X += z.xVel
            z.Y += z.yVel

            If z.X < z.W Or
               z.X > GameSize.Width Or
               z.Y < z.H Or
               z.Y > GameSize.Height Then

                Disparos.RemoveAt(i)

            End If
        Next



    End Sub
    Public Sub Disparar()

        ' Si no hay balas, recargar.
        If D_Actual = 0 Then D_Actual = D_Max : Exit Sub

        ' Disparar la cantidad de balas que se permita por vez
        For i = 1 To D_CantidadPer

            ' Si ya no hay mas balas que tirar, salir.
            If D_Actual = 0 Then Exit Sub
            D_Actual -= 1

            ' Crear Bala a Disparar
            Dim k As New R_Disparo
            k.Color = Me.Color
            k.Daño = R.Next(D_MinDaño, D_MaxDaño)
            k.W = R.Next(D_MinW, D_MaxW)
            k.H = k.W
            k.X = (X + (W / 2)) - (k.W / 2)
            k.Y = (Y + (H / 2)) - (k.H / 2)
            k.Used = False
            k.xVel = R.Next(D_MinVel, D_MaxVel) * Math.Cos((R.Next(Angle - (D_Presicion / 2), Angle + (D_Presicion / 2))) * (Math.PI / 180))
            k.yVel = R.Next(D_MinVel, D_MaxVel) * Math.Sin((R.Next(Angle - (D_Presicion / 2), Angle + (D_Presicion / 2))) * (Math.PI / 180))


            Disparos.Add(k)
            RaiseEvent Disparo(Me, k)
            k = Nothing

        Next

        Vel = Math.Max(Vel - (Freno * 3), MinVel)
    End Sub

#End Region

#Region "       Movimiento  "


    Private Sub SetFromTeclas()

        ' Left
        If Tecla(1) Then
            Angle -= RotVel '((Vel * RotVel) / MaxVel) 'For Car Physics
            If Angle < 0 Then Angle = Angle - 360
        End If
        ' Rigth
        If Tecla(2) Then
            Angle += RotVel '((Vel * RotVel) / MaxVel) 'For Car Physics
            If Angle >= 360 Then Angle -= 360
        End If


        ' Up
        If Tecla(0) Then
            If Vel < 0 Then : Vel = Math.Min(Vel + Freno, 0)
            Else : Vel = Math.Min(Vel + Aceleracion, MaxVel) : End If
        End If
        ' Down
        If Tecla(3) Then
            If Vel > 0 Then : Vel = Math.Max(Vel - Freno, 0)
            Else : Vel = Math.Max(Vel - Aceleracion, MinVel) : End If
        End If


    End Sub
    Private Sub MoveThis()

        X += Vel * Math.Cos((Angle) * (Math.PI / 180))
        Y += Vel * Math.Sin((Angle) * (Math.PI / 180))

        If Tecla(0) = False And Tecla(3) = False Then

            If Vel < 0 Then
                Vel = Math.Min(Vel + Desaceleracion, 0)
            Else
                Vel = Math.Max(Vel - Desaceleracion, 0)
            End If
        End If


        X = Math.Max(GameLocation.X, X)
        X = Math.Min(X, GameSize.Width - W)
        Y = Math.Max(GameLocation.Y, Y)
        Y = Math.Min(Y, GameSize.Height - H)


    End Sub


    Public Sub Move()

        Dim tempVel = Vel
        Dim tempAngle = Angle
        Dim refr As Boolean = False

        SetFromTeclas()
        If Vel <> 0 Then MoveThis()


        If tempAngle <> Angle Then
            RaiseEvent ChangeAngle(Me)
            refr = True
        End If
        If tempVel <> Vel Then

            If Vel = 0 Then : RaiseEvent StopMove(Me)
            ElseIf tempVel = 0 Then : RaiseEvent StartMove(Me) : End If
            refr = True
        End If

        If refr Then RaiseEvent Refresh(Me)

    End Sub


#End Region

#End Region


End Class
