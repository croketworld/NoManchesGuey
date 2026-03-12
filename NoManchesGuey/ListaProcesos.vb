Imports System.Collections.ObjectModel

Public Class ListaProcesos
    Inherits List(Of Proceso)



    Public Sub New(lista As ListaProcesos)
        Me.AddRange(lista)
    End Sub

    Public Sub New(lista As Collection(Of Proceso))
        Me.AddRange(lista)
    End Sub

    Public Sub New()

    End Sub


End Class
