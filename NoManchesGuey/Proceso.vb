
''' <summary>
''' Modelo que representa un proceso definido para bloquear
''' </summary>
Public Class Proceso

    ''' <summary>
    ''' Nombre del proceso
    ''' </summary>
    ''' <returns></returns>
    Public Property Nombre As String

    ''' <summary>
    ''' Si esta marcado para bloquear o no
    ''' </summary>
    ''' <returns>Devuelve True si está marcado para bloquear</returns>
    Public Property Estado As Boolean


    Public Sub New()

    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If (obj IsNot Nothing) = False Then Return False
        If Me.GetType().Equals(obj.GetType()) Then
            Dim procesoEntrante As Proceso = CType(obj, Proceso)
            Return procesoEntrante IsNot Nothing And procesoEntrante.Nombre = Me.Nombre
        End If
        Return False
    End Function

    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

End Class