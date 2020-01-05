<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgOrderPackageItemDetil
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_OK = New DevExpress.XtraEditors.SimpleButton()
        Me.GC_DetilPackage = New DevExpress.XtraGrid.GridControl()
        Me.GV_DetilPackage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GC_DetilPackage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV_DetilPackage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_OK)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 293)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(472, 33)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_OK
        '
        Me.btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.Location = New System.Drawing.Point(392, 5)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 0
        Me.btn_OK.Text = "OK"
        '
        'GC_DetilPackage
        '
        Me.GC_DetilPackage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_DetilPackage.Location = New System.Drawing.Point(0, 0)
        Me.GC_DetilPackage.MainView = Me.GV_DetilPackage
        Me.GC_DetilPackage.Name = "GC_DetilPackage"
        Me.GC_DetilPackage.Size = New System.Drawing.Size(472, 293)
        Me.GC_DetilPackage.TabIndex = 2
        Me.GC_DetilPackage.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV_DetilPackage})
        '
        'GV_DetilPackage
        '
        Me.GV_DetilPackage.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CItem, Me.CQty, Me.CDescription})
        Me.GV_DetilPackage.GridControl = Me.GC_DetilPackage
        Me.GV_DetilPackage.Name = "GV_DetilPackage"
        Me.GV_DetilPackage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GV_DetilPackage.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GV_DetilPackage.OptionsBehavior.AutoPopulateColumns = False
        Me.GV_DetilPackage.OptionsBehavior.Editable = False
        Me.GV_DetilPackage.OptionsBehavior.ReadOnly = True
        Me.GV_DetilPackage.OptionsView.ColumnAutoWidth = False
        Me.GV_DetilPackage.OptionsView.ShowGroupPanel = False
        '
        'CItem
        '
        Me.CItem.Caption = "Item"
        Me.CItem.FieldName = "item_name"
        Me.CItem.Name = "CItem"
        Me.CItem.Visible = True
        Me.CItem.VisibleIndex = 0
        Me.CItem.Width = 124
        '
        'CQty
        '
        Me.CQty.Caption = "Qty"
        Me.CQty.FieldName = "qty"
        Me.CQty.Name = "CQty"
        Me.CQty.Visible = True
        Me.CQty.VisibleIndex = 1
        Me.CQty.Width = 43
        '
        'CDescription
        '
        Me.CDescription.Caption = "Description"
        Me.CDescription.FieldName = "requestdetil_descr"
        Me.CDescription.Name = "CDescription"
        Me.CDescription.Visible = True
        Me.CDescription.VisibleIndex = 2
        Me.CDescription.Width = 371
        '
        'dlgOrderPackageItemDetil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 326)
        Me.ControlBox = False
        Me.Controls.Add(Me.GC_DetilPackage)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "dlgOrderPackageItemDetil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Package Item Detil"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GC_DetilPackage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV_DetilPackage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GC_DetilPackage As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV_DetilPackage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CDescription As DevExpress.XtraGrid.Columns.GridColumn
End Class
