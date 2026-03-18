Imports System.Collections.Immutable
Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports System.Reflection.Metadata.Ecma335

Public Class ListaProcesos
    Inherits List(Of Proceso)

#Region "constructores"
    Public Sub New(lista As ListaProcesos)
        Me.AddRange(lista)
    End Sub

    Public Sub New(lista As Collection(Of Proceso))
        Me.AddRange(lista)
    End Sub

    Public Sub New()

    End Sub

#End Region


#Region "operadores"

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim v2 As ListaProcesos = CType(obj, ListaProcesos)
        Return (v2 = Me)
    End Function
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

    Public Shared Operator <>(v1 As ListaProcesos, v2 As ListaProcesos) As Boolean
        Return ((v1 = v2) = False)
    End Operator


    Public Shared Widening Operator CType(v1 As ListaProcesos) As ImmutableList(Of String)
        Return v1?.ToImmutableList()
    End Operator

    Public Function ToImmutableList() As ImmutableList(Of String)
        Dim ls As New List(Of String)
        Me.ForEach(Sub(ll)
                       ls.Add(ll.Nombre)
                   End Sub)
        Return ls.ToImmutableList()
    End Function

    Public Overrides Function ToString() As String
        Return Me.ToString(Environment.NewLine)
    End Function

    Public Overloads Function ToString(separator As String) As String
        Return String.Join(separator, Me.Select(Of String)(Function(f) f.Nombre).ToList())
    End Function

#End Region

End Class
