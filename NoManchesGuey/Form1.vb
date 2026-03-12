Imports System.CodeDom
Imports System.ComponentModel
Imports System.Net.Security

Public Class Form1

    Public EnMarcha As Boolean

    Private ListaProcesosABloquearPorUsuario As ListaProcesos

    Private bg As BackgroundWorker

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
        Button1.Text = "Detener"
        If bg IsNot Nothing Then
            If bg.IsBusy Then bg.CancelAsync()
            bg.Dispose()
            bg = Nothing
        End If
        bg = New BackgroundWorker
        AddHandler bg.RunWorkerCompleted, AddressOf Proceso_FinalizedWork
        AddHandler bg.DoWork, AddressOf Proceso_DoWork
        bg.WorkerSupportsCancellation = True

        bg.RunWorkerAsync(ListaProcesosABloquearPorUsuario.Where(Function(proce)
                                                                     Return proce.Estado = True
                                                                 End Function).Select(Of String)(Function(ooo)
                                                                                                     Return ooo.Nombre
                                                                                                 End Function).ToList())
    End Sub

    Public Sub DetenerProceso()
        EnMarcha = False
        If bg IsNot Nothing And bg.WorkerSupportsCancellation Then bg.CancelAsync()
    End Sub

    Public Sub RemoveItem()
        Dim itemsToRemove = GetSelectedItems()
        If itemsToRemove IsNot Nothing And itemsToRemove.Count > 0 Then
            Dim indices As New List(Of Integer)
            For Each item As ListViewItem In itemsToRemove
                indices.Add(item.Index)
                ListaProcesosABloquearPorUsuario.Remove(ListaProcesosABloquearPorUsuario.Where(Function(procesillo)
                                                                                                   Return procesillo.Nombre = item.Text
                                                                                               End Function).FirstOrDefault())
            Next
            indices.OrderByDescending(Of Integer) _
                (Function(o)
                     Return o
                 End Function).ToList() _
                .ForEach(Sub(indice)
                             ListView1.Items.RemoveAt(indice)
                         End Sub)
        End If

    End Sub

    Public Sub AddItem()
        Dim nombreIntroducido As String = InputBox("Introduce el nombre de un proceso, por ejemplo dllhost.exe", "Proceso a bloquear")
        If String.IsNullOrEmpty(nombreIntroducido) Then Exit Sub
        If ListView1.Items.ContainsKey(nombreIntroducido) Then Exit Sub
        ListaProcesosABloquearPorUsuario.Add(New Proceso(nombreIntroducido))

        Dim listviewitemNuevo As New ListViewItem(nombreIntroducido)
        listviewitemNuevo.SubItems.Add("True")
        ListView1.Items.Add(nombreIntroducido)
        ListView1.Refresh()
    End Sub

    Public Sub DeactivateItem()
        Dim itemsToRemove = GetSelectedItems()
        If itemsToRemove IsNot Nothing And itemsToRemove.Count > 0 Then
            For Each elementoSeleccionado In itemsToRemove
                Dim p As Proceso = ListaProcesosABloquearPorUsuario.Where(Function(elementoEnLista)
                                                                              Return elementoEnLista.Nombre = CType(elementoSeleccionado, ListViewItem).Text
                                                                          End Function).FirstOrDefault()
                p.Estado = False
            Next
        End If
    End Sub

#End Region

#Region "funciones internas"

    Private Function GetSelectedItems() As ListView.SelectedListViewItemCollection
        If ListView1.SelectedItems.Count <= 0 Then Return Nothing
        Return ListView1.SelectedItems
    End Function

    Public Function RutaConfigFile() As String
        Return IO.Path.Join(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName & ".json")
    End Function

#End Region


#Region "archivo lista procesos"

    Public Sub CargarListaProcesosBloqueados()

        Dim js As New System.Runtime.Serialization.Json.DataContractJsonSerializer(Me.ListaProcesosABloquearPorUsuario.GetType())
        Dim fs As IO.FileStream = Nothing
        Try
            fs = New IO.FileStream(RutaConfigFile, IO.FileMode.OpenOrCreate)
            Me.ListaProcesosABloquearPorUsuario = js.ReadObject(fs)
        Catch

        End Try
        If fs IsNot Nothing Then
            fs.Close()
            fs.Dispose()
        End If
    End Sub
    Public Sub GuardarListaProcesosBloqueados()
        Dim js As New System.Runtime.Serialization.Json.DataContractJsonSerializer(Me.ListaProcesosABloquearPorUsuario.GetType())
        Dim fs As IO.FileStream = Nothing
        Try
            fs = New IO.FileStream(RutaConfigFile, IO.FileMode.Create)
            js.WriteObject(fs, Me.ListaProcesosABloquearPorUsuario)
        Catch

        End Try
        If fs IsNot Nothing Then
            fs.Close()
            fs.Dispose()
        End If
    End Sub



#End Region

#Region "Proceso"


    Private Sub Proceso_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim bgw As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim cuentaVueltas As Integer = 0
        Dim maximoVueltas As Integer = 100
        Dim listaBloqueos As List(Of String) = CType(e.Argument, List(Of String))
        Do While e.Cancel = False
            If (bgw IsNot Nothing And bgw.CancellationPending) Or e.Cancel = True Then
                Exit Do
            End If
            cuentaVueltas += 1
            If cuentaVueltas >= maximoVueltas Then
                e.Result = cuentaVueltas
                Exit Sub
            End If
            System.Threading.Thread.Sleep(3000)
            Dim listaProcesos As List(Of String) = HelperFunciones.GetRunningProccessesNames()
            For Each procesoABloquear As String In listaBloqueos
                If listaProcesos.Contains(procesoABloquear) Then Dim procesilloEnEJecuccionABloquear = Process.GetProcessesByName(procesoABloquear)
            Next
        Loop
        e.Result = Nothing
    End Sub

    Private Sub Proceso_FinalizedWork(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If e.Result IsNot Nothing Then
            IniciarProceso()
        ElseIf e.Cancelled Then
            Button1.Text = "Iniciar"
        End If

    End Sub



#End Region


#Region "construccion"



    Public Sub New()
        InitializeComponent()
        Me.ListaProcesosABloquearPorUsuario = New ListaProcesos
        AddHandler btn_AddItem.Click, AddressOf AddItem
        AddHandler btn_RemoveItem.Click, AddressOf RemoveItem
        AddHandler Button1.Click, AddressOf IniciarDetenerProceso
        AddHandler btn_DeactivateItem.Click, AddressOf DeactivateItem

        ListView1.DataContext = ListaProcesosABloquearPorUsuario
        CargarListaProcesosBloqueados()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim tieneItemsSeleccionados As Boolean = ListView1.SelectedItems.Count > 0
        btn_RemoveItem.Enabled = tieneItemsSeleccionados
        btn_DeactivateItem.Enabled = tieneItemsSeleccionados
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing
        GuardarListaProcesosBloqueados()
    End Sub

#End Region

End Class
