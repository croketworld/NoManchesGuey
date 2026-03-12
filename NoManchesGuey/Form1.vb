Public Class Form1

    Public EnMarcha As Boolean

    Private ListaProcesos As ListaProcesos

#Region "acciones de usuario"

    Public Sub IniciarDetenerProceso()
        If EnMarcha Then
            DetenerProceso()
        Else
            IniciarProceso()
        End If

    End Sub


    Public Sub IniciarProceso()
        EnMarcha = True

    End Sub

    Public Sub DetenerProceso()
        EnMarcha = False
    End Sub

    Public Sub RemoveItem()

    End Sub

    Public Sub AddItem()



    End Sub

#End Region

#Region "Proceso"

    Private Sub Proceso_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)


    End Sub

    Private Sub Proceso_FinalizedWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)


    End Sub



#End Region


#Region "construccion"



    Public Sub New()
        InitializeComponent()
        Me.ListaProcesos = New ListaProcesos
        AddHandler btn_AddItem.Click, AddressOf AddItem
        AddHandler btn_RemoveItem.Click, AddressOf RemoveItem
        AddHandler Button1.Click, AddressOf IniciarDetenerProceso

    End Sub


#End Region

End Class
