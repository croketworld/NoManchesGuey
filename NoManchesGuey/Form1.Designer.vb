<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()

        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        Button1 = New Button()
        btn_AddItem = New Button()
        btn_RemoveItem = New Button()
        MenuStrip1 = New MenuStrip()
        StatusStrip1 = New StatusStrip()
        SplitContainer1 = New SplitContainer()
        btn_DeactivateItem = New Button()
        ToolTip1 = New ToolTip(components)
        ListaProcesosBindingSource = New BindingSource(components)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(ListaProcesosBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2})
        ListView1.DataBindings.Add(New Binding("DataContext", ListaProcesosBindingSource, "Nombre", True))
        ListView1.GridLines = True
        ListView1.Location = New Point(0, 3)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(691, 722)
        ListView1.TabIndex = 0
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Nombre"
        ColumnHeader1.Width = 560
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Bloqueado"
        ColumnHeader2.Width = 180
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(54, 47)
        Button1.Name = "Button1"
        Button1.Size = New Size(150, 46)
        Button1.TabIndex = 1
        Button1.Text = "Iniciar"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' btn_AddItem
        ' 
        btn_AddItem.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btn_AddItem.Location = New Point(697, 3)
        btn_AddItem.Name = "btn_AddItem"
        btn_AddItem.Size = New Size(48, 48)
        btn_AddItem.TabIndex = 2
        btn_AddItem.Text = "+"
        ToolTip1.SetToolTip(btn_AddItem, "Añadir un proceso a la lista de bloqueados")
        btn_AddItem.UseVisualStyleBackColor = True
        ' 
        ' btn_RemoveItem
        ' 
        btn_RemoveItem.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btn_RemoveItem.Enabled = False
        btn_RemoveItem.Location = New Point(697, 57)
        btn_RemoveItem.Name = "btn_RemoveItem"
        btn_RemoveItem.Size = New Size(48, 48)
        btn_RemoveItem.TabIndex = 3
        btn_RemoveItem.Text = "-"
        ToolTip1.SetToolTip(btn_RemoveItem, "Quitar un proceso de la lista de bloqueados")
        btn_RemoveItem.UseVisualStyleBackColor = True
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(32, 32)
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1012, 24)
        MenuStrip1.TabIndex = 4
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Location = New Point(0, 749)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1012, 22)
        StatusStrip1.TabIndex = 5
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 24)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(btn_DeactivateItem)
        SplitContainer1.Panel1.Controls.Add(ListView1)
        SplitContainer1.Panel1.Controls.Add(btn_AddItem)
        SplitContainer1.Panel1.Controls.Add(btn_RemoveItem)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(Button1)
        SplitContainer1.Size = New Size(1012, 725)
        SplitContainer1.SplitterDistance = 748
        SplitContainer1.TabIndex = 6
        ' 
        ' btn_DeactivateItem
        ' 
        btn_DeactivateItem.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btn_DeactivateItem.Enabled = False
        btn_DeactivateItem.Location = New Point(697, 131)
        btn_DeactivateItem.Name = "btn_DeactivateItem"
        btn_DeactivateItem.Size = New Size(48, 48)
        btn_DeactivateItem.TabIndex = 4
        btn_DeactivateItem.Text = "X"
        ToolTip1.SetToolTip(btn_DeactivateItem, "Activa o desactiva el bloqueo de un proceso")
        btn_DeactivateItem.UseVisualStyleBackColor = True
        ' 
        ' ListaProcesosBindingSource
        ' 
        ListaProcesosBindingSource.DataSource = GetType(ListaProcesos)
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1012, 771)
        Controls.Add(SplitContainer1)
        Controls.Add(StatusStrip1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Form1"
        Text = "No Manches Guey"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(ListaProcesosBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_AddItem As Button
    Friend WithEvents btn_RemoveItem As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents btn_DeactivateItem As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ListaProcesosBindingSource As BindingSource

End Class
