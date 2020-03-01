Namespace My

    Partial Friend Class MyApplication

        Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            'MsgBox("Shit! Unhandled exception:" & vbCrLf & e.Exception.Message, MsgBoxStyle.Critical, "Error en Jugador Local")
            e.ExitApplication = False
        End Sub
    End Class


End Namespace

