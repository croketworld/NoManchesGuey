Public NotInheritable Class HelperFunciones
    ''' <summary>
    ''' Devuelve el nombre de archivo con extensión desde la ruta completa de un archivo
    ''' </summary>
    ''' <param name="rutaCompleta">Ruta completa al archivo</param>
    ''' <returns>Devuelve el nombre con extensión, por ejemplo dllhost.exe</returns>
    Public Shared Function GetProcessName(rutaCompleta As String) As String
        If IO.File.Exists(rutaCompleta) = False Then Return String.Empty
        Dim ff As IO.FileInfo = Nothing
        Try
            ff = New IO.FileInfo(rutaCompleta)
        Catch

        End Try
        If ff IsNot Nothing Then Return ff.Name
        Return String.Empty
    End Function


    Public Shared Function GetRunningProccessesNames() As List(Of String)
        Dim resultado As New List(Of String)
        Dim todos = System.Diagnostics.Process.GetProcesses()
        For Each procesillo As Process In todos
            resultado.Add(HelperFunciones.GetProcessName(procesillo.ProcessName))
        Next
        Return resultado
    End Function

End Class
