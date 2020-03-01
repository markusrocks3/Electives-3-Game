Imports Winsock_Orcas

Public Class Server

    Dim r As New Random


#Region " Data Up/Down - Server ON/OFF"


    Dim bUp As UInteger = 0
    Dim bDown As UInteger = 0



    ' Data Up/Down - Clientes Conectados - Vaiar buffer antiguo
    Private Sub tData_Tick(sender As Object, e As EventArgs) Handles tData.Tick

        'For Each w As Winsock In Clientes.Values
        '    While w.HasData : w.Get() : End While
        'Next


        ' -- Mode: Show every seconds --
        downBytes.Text = bDown & " bytes/s"
        upBytes.Text = bUp & " bytes/s"
        bUp = 0
        bDown = 0

        Application.DoEvents()

    End Sub

    ' Server ON/OFF
    Private Sub ServerOnOff() Handles LinkLabel1.LinkClicked
        Try
            If wsk.State = Winsock_Orcas.WinsockStates.Closed Then
                wsk.Listen()
            Else
                wsk.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If wsk.State = Winsock_Orcas.WinsockStates.Listening Then
                LinkLabel1.Text = "Server: ON"
            Else
                LinkLabel1.Text = "Server: OFF"
            End If
        End Try
    End Sub


    ' Load: Encender Servidor
    Private Sub Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        ServerOnOff()
    End Sub


#End Region

#Region " Game Property "

    Dim GameSize As New Size(800, 600)

#End Region


#Region " Clientes.Eventos "

    Friend WithEvents Clientes As New Winsock_Orcas.WinsockCollection(True)
    Dim Jugadores As New List(Of R_MiniPlayer)

    ' -- Intento de Conexion
    Private Sub wsk_ConnectionRequest(sender As Object, e As WinsockConnectionRequestEventArgs) Handles wsk.ConnectionRequest
        Clientes.Accept(e.Client)
    End Sub

    ' -- Conexion
    Private Sub Clientes_Connected(sender As Winsock, e As WinsockConnectedEventArgs) Handles Clientes.Connected

        HayConexion(e.SourceIP)

        '' Enviar jugadores remotos al recien ingresado
        'For Each k As R_MiniPlayer In Jugadores

        '    Dim z As New Data_Get
        '    z.TipoDato = TipoDato.NewPlayer
        '    z.Value = k

        '    ' Send
        '    sender.Send(DataGet_Converter.dataToString(z))

        '    ' Clear 
        '    z = Nothing

        'Next

        'Jugadores.Add(New R_MiniPlayer)


    End Sub
    ' -- Desconexion
    Private Sub Clientes_Disconnected(sender As Object, e As EventArgs) Handles Clientes.Disconnected

        HayDesconexion()

        'For Each J As vPlayer In Panel3.Controls
        '    J.En = False
        'Next
        'Panel3.Invalidate(True)

        'For Each wk As Winsock In Clientes.Values
        '    If wk.State = WinsockStates.Connected Then
        '        ' Enviar Cambios de MiJugador
        '        Dim k As New DataIn With {.TipoDato = TipoDato.ResetPlayers}
        '        wk.Send(DataInConverter.dataToString(k))
        '        k = Nothing
        '    End If
        'Next

    End Sub
    ' -- Error
    Private Sub Clientes_ErrorReceived(sender As Object, e As WinsockErrorReceivedEventArgs) Handles Clientes.ErrorReceived

        If wsk.State = WinsockStates.Closed Then HayDesconexion()
        ' MsgBox("Error en Servidor" & vbCrLf & e.Message, MsgBoxStyle.Critical, "Error")

    End Sub

    ' -- Enviar Datos
    Private Sub Clientes_SendComplete(sender As Object, e As WinsockSendEventArgs) Handles Clientes.SendComplete
        bUp += e.BytesSent

    End Sub
    ' -- Recibir Datos 
    Private Sub Clientes_DataArrival(sender As Winsock, e As WinsockDataArrivalEventArgs) Handles Clientes.DataArrival
        bDown += e.TotalBytes ' Contador de Bytes

        Dim d = sender.Get(Of String)()

        For Each wk As Winsock In Clientes.Values
            If wk IsNot sender Then wk.Send(d)
        Next





        'Dim dI = DataGet_Converter.dataFromString(d)
        'Select Case dI.TipoDato
        '    Case TipoDato.NewPlayer
        '        Dim m = CType(dI.Value, R_MiniPlayer)
        '        For i = 0 To Jugadores.Count - 1 'Each k As R_MiniPlayer In Jugadores
        '            If Jugadores(i).Color = m.Color Then
        '                Jugadores(i) = m
        '            End If
        '        Next




        'End Select



        'd = Nothing


    End Sub



    Sub HayConexion(ip As String)

        ' Informar al Administrador de Servidor
        'MsgBox("> Servidor <" & vbCrLf & "Conexion: " & ip)

    End Sub
    Sub HayDesconexion()

        '  MsgBox("> Servidor <" & vbCrLf & "Desconexion de Jugador.", MsgBoxStyle.Information, "Servidor")

    End Sub





    Private Sub Send_Gun()
        Dim x As New S_Gun
        x.X = r.Next(60, GameSize.Width - 60)
        x.Y = r.Next(60, GameSize.Height - 60)
        x.Gun = r.Next(0, 6)
        Dim z As New Data_Get
        z.TipoDato = TipoDato.Gun
        z.Value = x
        Dim data = DataGet_Converter.dataToString(z)


        For Each w As Winsock In Clientes.Values
            w.Send(data)
        Next

        x = Nothing
        z = Nothing
        data = Nothing

    End Sub
    Private Sub Send_ResetGun()
        Dim z As New Data_Get
        z.TipoDato = TipoDato.ResetGuns
        z.Value = Nothing
        Dim data = DataGet_Converter.dataToString(z)


        For Each w As Winsock In Clientes.Values
            w.Send(data)
        Next

        z = Nothing
        data = Nothing
    End Sub



    Sub Desconectar(ip As String)

        For i = Clientes.Values.Count - 1 To 0 Step -1 ' Each w As Winsock In Clientes
            Dim w As Winsock = Clientes.Values(i)
            If w.State = WinsockStates.Connected Then
                If w.RemoteHost = ip Then
                    Clientes.Remove(index:=i)
                End If
            End If
            w = Nothing
        Next

    End Sub

    Dim GunOk As Boolean = False
    Private Sub tGun_Tick(sender As Object, e As EventArgs) Handles tGun.Tick
        If GunOk Then
            Send_ResetGun()
        Else
            Send_Gun()
        End If


    End Sub



#End Region


End Class
