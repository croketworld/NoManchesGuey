Imports System.Collections.Immutable
Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports System.Reflection.Metadata.Ecma335

''' <summary>
''' Clase que es una <see cref="List(Of T)">Lista</see> lista de <see cref="Proceso">Proceso</see>
''' </summary>
Public Class ListaProcesos
    Inherits List(Of Proceso)

#Region "funciones de datos"

    ''' <summary>
    ''' Devuelve los procesos que están marcados para bloquear
    ''' </summary>
    ''' <returns></returns>
    Public Function GetmarkedForBlocking() As ListaProcesos
        Return New ListaProcesos(Me.Where(Function(o)
                                              Return o.Estado = True
                                          End Function))
    End Function

    ''' <summary>
    ''' Devuelve los procesos que tienen desactivado el bloqueo
    ''' </summary>
    ''' <returns></returns>
    Public Function GetdisabledForBlocking() As ListaProcesos
        Return New ListaProcesos(Me.Where(Function(o)
                                              Return o.Estado = False
                                          End Function))
    End Function
#End Region

#Region "constructores"

    Public Sub New(lista As ListaProcesos)
        Me.AddRange(lista)
    End Sub
    Public Sub New(lista As IEnumerable(Of Proceso))
        Me.AddRange(lista)
    End Sub
    Public Sub New(lista As Collection(Of Proceso))
        Me.AddRange(lista)
    End Sub

    Public Sub New()

    End Sub

#End Region

#Region "operadores"

    ''' <summary>
    ''' Determina si la clase instanciada actual es igual a la que le llega cómo argumento genérico
    ''' </summary>
    ''' <param name="obj">El objeto del tipo <see cref="ListaProcesos">ListProceso</see> a comparar</param>
    ''' <returns>Devuelve True si tiene los mismos elementos aunque sea en diferente orden</returns>
    ''' <remarks>Se apoya en el operador = (o == en C#) </remarks>
    ''' <exception cref="NullReferenceException">Seguramente peta si le pasas un argumento no instanciado</exception>
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim v2 As ListaProcesos = CType(obj, ListaProcesos)
        Return (v2 = Me)
    End Function

    ''' <summary>
    ''' Convierte el objeto a string usando <see cref="ToString()">ToString</see> y luego usando el método GetHashCode de la clase <see cref="String">String</see>
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function GetHashCode() As Integer
        Return Me.ToString()?.GetHashCode(StringComparison.InvariantCulture)
    End Function

    ''' <summary>
    ''' Determina si dos listas de procesos son iguales, aunque tengan un orden elementos diferentes
    ''' </summary>
    ''' <param name="v1"></param>
    ''' <param name="v2"></param>
    ''' <returns>Devuelve false si alguna de las listas no están instanciadas o tiene distinto número de elementos con respecto a la otra lista.</returns>
    Public Shared Operator =(v1 As ListaProcesos, v2 As ListaProcesos) As Boolean
        If (v1 IsNot Nothing = False) Or (v2 IsNot Nothing = False) Then Return False
        If v1?.Count <> v2?.Count Then Return False
        Dim esigual As Boolean = False
        For i As Integer = 0 To v1.Count - 1
            If v2.Contains(v1.Item(i)) = False Then
                Exit For
            End If
            esigual = True
        Next

        Return esigual
    End Operator

    ''' <summary>
    ''' Se apoya en el operador de igualdad = (o == en C#) para no duplicar lógica aunque sea de forma invertida y mantener consistencia de lo que se considera igual o diferente
    ''' </summary>
    ''' <param name="v1">La clase instanciada a comprobar</param>
    ''' <param name="v2">La clase instanciada para comparar</param>
    ''' <returns></returns>
    Public Shared Operator <>(v1 As ListaProcesos, v2 As ListaProcesos) As Boolean
        Return ((v1 = v2) = False)
    End Operator

    ''' <summary>
    ''' Devuelve una lista immutable de <see cref="String">String</see>.
    ''' </summary>
    ''' <param name="v1">La lista de procesos a convertir en lista immutable de cadena</param>
    ''' <returns>Se apoya en la función <see cref="ToImmutableList()">ToImmutableList</see></returns>
    Public Shared Widening Operator CType(v1 As ListaProcesos) As ImmutableList(Of String)
        Return v1?.ToImmutableList()
    End Operator
    ''' <summary>
    ''' Convierte la lista actual en una lista immutable de cadenas.
    ''' </summary>
    ''' <returns>Devuelve una lista immutable de <see cref="String">String</see></returns>
    Public Function ToImmutableList() As ImmutableList(Of String)
        Dim ls As New List(Of String)
        Me.ForEach(Sub(ll)
                       ls.Add(ll.Nombre)
                   End Sub)
        Return ls.ToImmutableList()
    End Function

    ''' <summary>
    ''' Devuelve una cadena que es una lista separado por nuevas líneas (o CrLf).
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks> Se apoya en la función <see cref="ToString(String)">ToString(separador)</see> invocándola con <see cref="Environment.NewLine">Environment.NewLine</see></remarks>
    Public Overrides Function ToString() As String
        Return Me.ToString(Environment.NewLine)
    End Function

    ''' <summary>
    '''  Devuelve una cadena que es una lista separado por el separador indicado en el parámetro de entrada.
    ''' </summary>
    ''' <param name="separator">El separador a usar</param>
    ''' <returns></returns>
    Public Overloads Function ToString(separator As String) As String
        Return String.Join(separator, Me.Select(Of String)(Function(f) f.Nombre).ToList())
    End Function

#End Region

End Class
