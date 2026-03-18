
''' <summary>
''' Modelo que representa un proceso definido para bloquear.
''' </summary>
''' <remarks>Para manejar una colección de procesos, puedes usar la clase <see cref="ListaProcesos">ListaProcesos</see>, que hereda de <see cref="List(Of T)">List(Of Proceso)</see> e incluye funcionalidad adicional.</remarks>
Public Class Proceso

#Region "propiedades"

    ''' <summary>
    ''' Nombre del proceso.
    ''' </summary>
    ''' <returns></returns>
    Public Property Nombre As String

    ''' <summary>
    ''' Si esta marcado para bloquear o no.
    ''' </summary>
    ''' <returns>Devuelve True si está marcado para bloquear.</returns>
    Public Property Estado As Boolean
#End Region

#Region "operadores"

    ''' <summary>
    ''' Determina si dos procesos son iguales.
    ''' </summary>
    ''' <param name="v1">El proceso a comprobar.</param>
    ''' <param name="v2">El proceso para comparar.</param>
    ''' <returns>Devuelve false si el nombre es diferente.</returns>
    ''' <remarks>Deben ser clases instanciadas los argumentos.</remarks>
    Public Shared Operator =(v1 As Proceso, v2 As Proceso) As Boolean
        If (v1 IsNot Nothing = False) Or (v2 IsNot Nothing = False) Then Return False
        Return v1?.Nombre = v2?.Nombre
    End Operator

    ''' <summary>
    ''' Se apoya en el operador de igualdad = (o == en C#) para no duplicar lógica aunque sea de forma invertida y mantener consistencia de lo que se considera igual o diferente
    ''' </summary>
    ''' <param name="v1">El proceso a comprobar.</param>
    ''' <param name="v2">El proceso para comparar.</param>
    ''' <returns>Devuelve true si el nombre es diferente.</returns>
    ''' <remarks>Deben ser clases instanciadas los argumentos.</remarks>
    Public Shared Operator <>(v1 As Proceso, v2 As Proceso) As Boolean
        Return ((v1 = v2) = False)
    End Operator



    ''' <summary>
    ''' Determina si un procesos tiene el nombre de la cadena a comparar.
    ''' </summary>
    ''' <param name="v1">El proceso a comprobar.</param>
    ''' <param name="v2">La cadena de texto para comparar.</param>
    ''' <returns>Devuelve false si el nombre es diferente.</returns>
    ''' <remarks> v1 debe ser una clase instanciada y v2 no puede ser nulo o vacío.</remarks>
    Public Shared Operator =(v1 As Proceso, v2 As String) As Boolean
        If (v1 IsNot Nothing = False) Or (String.IsNullOrEmpty(v2)) Then Return False
        Return v1?.Nombre = v2
    End Operator

    ''' <summary>
    ''' Se apoya en el operador de igualdad = (o == en C#) para no duplicar lógica aunque sea de forma invertida y mantener consistencia de lo que se considera igual o diferente
    ''' </summary>
    ''' <param name="v1">El proceso a comprobar.</param>
    ''' <param name="v2">La cadena de texto para comparar.</param>
    ''' <returns>Devuelve true si el nombre es diferente.</returns>
    ''' <remarks> v1 debe ser una clase instanciada y v2 no puede ser nulo o vacío.</remarks>
    Public Shared Operator <>(v1 As Proceso, v2 As String) As Boolean
        Return ((v1 = v2) = False)
    End Operator


    ''' <summary>
    ''' Sólo invoca el GetHashCode de su clase base <see cref="Object">Object</see>.
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    ''' <summary>
    ''' Determina si un objeto que entra cómo argumento es un proceso y además tiene el mismo nombre.
    ''' </summary>
    ''' <param name="obj">El objeto <see cref="Proceso">Proceso</see> instanciado a comprobar.</param>
    ''' <returns></returns>
    ''' <remarks>No comprueba si se diferencian en el estado.</remarks>
    Public Overrides Function Equals(obj As Object) As Boolean
        If (obj IsNot Nothing) = False Then Return False
        If Me.GetType().Equals(obj?.GetType()) Then
            Dim procesoEntrante As Proceso = CType(obj, Proceso)
            Return procesoEntrante IsNot Nothing And procesoEntrante.Nombre = Me.Nombre
        End If
        Return False
    End Function

    ''' <summary>
    ''' Devuelve el <see cref="Nombre">Nombre</see> del proceso.
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return Me.Nombre
    End Function

#End Region

#Region "constructores"

    ''' <summary>
    ''' Instancia la clase estableciendo el estado en True y estableciendo la propiedad <see cref="Nombre">Nombre</see> con el parámetro de entrada.
    ''' </summary>
    ''' <param name="nombreIntroducido">El nombre a establecer.</param>
    Public Sub New(nombreIntroducido As String)
        Me.Nombre = nombreIntroducido
        Me.Estado = True
    End Sub

    ''' <summary>
    ''' Constructor por defecto sin parámetros, necesario en algunos casos para el Runtime y serializaciones.
    ''' </summary>
    ''' <remarks>Establece la propiedad <see cref="Estado">Estado</see> en True</remarks>.
    Public Sub New()
        Me.Estado = True
    End Sub
#End Region

End Class