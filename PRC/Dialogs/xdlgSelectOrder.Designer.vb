<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xdlgSelectOrder
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
        Me.btnOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.objSearchOrder = New DevExpress.XtraEditors.TextEdit()
        Me.lborder_id = New DevExpress.XtraEditors.LabelControl()
        Me.gcSelectOrder = New DevExpress.XtraGrid.GridControl()
        Me.gvSelectOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOrderID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekananName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderSetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderUtilizeddatestart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderUtilizeddateend = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnPick = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.objSearchOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcSelectOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvSelectOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnOrder)
        Me.PanelControl1.Controls.Add(Me.objSearchOrder)
        Me.PanelControl1.Controls.Add(Me.lborder_id)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(742, 55)
        Me.PanelControl1.TabIndex = 0
        '
        'btnOrder
        '
        Me.btnOrder.Location = New System.Drawing.Point(199, 16)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(75, 23)
        Me.btnOrder.TabIndex = 2
        Me.btnOrder.Text = "Load"
        '
        'objSearchOrder
        '
        Me.objSearchOrder.Location = New System.Drawing.Point(70, 17)
        Me.objSearchOrder.Name = "objSearchOrder"
        Me.objSearchOrder.Size = New System.Drawing.Size(123, 20)
        Me.objSearchOrder.TabIndex = 1
        '
        'lborder_id
        '
        Me.lborder_id.Location = New System.Drawing.Point(12, 20)
        Me.lborder_id.Name = "lborder_id"
        Me.lborder_id.Size = New System.Drawing.Size(42, 13)
        Me.lborder_id.TabIndex = 0
        Me.lborder_id.Text = "Order ID"
        '
        'gcSelectOrder
        '
        Me.gcSelectOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcSelectOrder.Location = New System.Drawing.Point(0, 55)
        Me.gcSelectOrder.MainView = Me.gvSelectOrder
        Me.gcSelectOrder.Name = "gcSelectOrder"
        Me.gcSelectOrder.Size = New System.Drawing.Size(742, 281)
        Me.gcSelectOrder.TabIndex = 1
        Me.gcSelectOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvSelectOrder})
        '
        'gvSelectOrder
        '
        Me.gvSelectOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOrderID, Me.colOrderDate, Me.colOrderDescr, Me.colOrderNote, Me.colCurrencyName, Me.colRekananName, Me.colBudgetID, Me.colBudgetName, Me.colOrderSetDate, Me.colOrderUtilizeddatestart, Me.colOrderUtilizeddateend})
        Me.gvSelectOrder.GridControl = Me.gcSelectOrder
        Me.gvSelectOrder.Name = "gvSelectOrder"
        Me.gvSelectOrder.OptionsBehavior.Editable = False
        Me.gvSelectOrder.OptionsBehavior.ReadOnly = True
        Me.gvSelectOrder.OptionsView.ColumnAutoWidth = False
        Me.gvSelectOrder.OptionsView.ShowGroupPanel = False
        '
        'colOrderID
        '
        Me.colOrderID.Caption = "Order ID"
        Me.colOrderID.FieldName = "order_id"
        Me.colOrderID.Name = "colOrderID"
        Me.colOrderID.OptionsColumn.AllowEdit = False
        Me.colOrderID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colOrderID.OptionsColumn.ReadOnly = True
        Me.colOrderID.Visible = True
        Me.colOrderID.VisibleIndex = 0
        Me.colOrderID.Width = 86
        '
        'colOrderDate
        '
        Me.colOrderDate.Caption = "Order Date"
        Me.colOrderDate.FieldName = "order_date"
        Me.colOrderDate.Name = "colOrderDate"
        Me.colOrderDate.OptionsColumn.AllowEdit = False
        Me.colOrderDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colOrderDate.OptionsColumn.ReadOnly = True
        Me.colOrderDate.Visible = True
        Me.colOrderDate.VisibleIndex = 1
        Me.colOrderDate.Width = 96
        '
        'colOrderDescr
        '
        Me.colOrderDescr.Caption = "Description"
        Me.colOrderDescr.FieldName = "order_descr"
        Me.colOrderDescr.Name = "colOrderDescr"
        Me.colOrderDescr.Visible = True
        Me.colOrderDescr.VisibleIndex = 2
        Me.colOrderDescr.Width = 154
        '
        'colOrderNote
        '
        Me.colOrderNote.Caption = "Note"
        Me.colOrderNote.FieldName = "order_note"
        Me.colOrderNote.Name = "colOrderNote"
        Me.colOrderNote.Visible = True
        Me.colOrderNote.VisibleIndex = 3
        Me.colOrderNote.Width = 147
        '
        'colCurrencyName
        '
        Me.colCurrencyName.Caption = "Currency"
        Me.colCurrencyName.FieldName = "currency_name"
        Me.colCurrencyName.Name = "colCurrencyName"
        Me.colCurrencyName.Visible = True
        Me.colCurrencyName.VisibleIndex = 4
        '
        'colRekananName
        '
        Me.colRekananName.Caption = "Partner"
        Me.colRekananName.FieldName = "rekanan_name"
        Me.colRekananName.Name = "colRekananName"
        Me.colRekananName.Visible = True
        Me.colRekananName.VisibleIndex = 5
        Me.colRekananName.Width = 132
        '
        'colBudgetID
        '
        Me.colBudgetID.Caption = "Budget ID"
        Me.colBudgetID.FieldName = "budget_id"
        Me.colBudgetID.Name = "colBudgetID"
        Me.colBudgetID.Visible = True
        Me.colBudgetID.VisibleIndex = 6
        '
        'colBudgetName
        '
        Me.colBudgetName.Caption = "Budget Name"
        Me.colBudgetName.FieldName = "budget_name"
        Me.colBudgetName.Name = "colBudgetName"
        Me.colBudgetName.Visible = True
        Me.colBudgetName.VisibleIndex = 7
        Me.colBudgetName.Width = 152
        '
        'colOrderSetDate
        '
        Me.colOrderSetDate.Caption = "Set Date"
        Me.colOrderSetDate.FieldName = "order_setdate"
        Me.colOrderSetDate.Name = "colOrderSetDate"
        Me.colOrderSetDate.Visible = True
        Me.colOrderSetDate.VisibleIndex = 8
        '
        'colOrderUtilizeddatestart
        '
        Me.colOrderUtilizeddatestart.Caption = "Used Date Start"
        Me.colOrderUtilizeddatestart.FieldName = "order_utilizeddatestart"
        Me.colOrderUtilizeddatestart.Name = "colOrderUtilizeddatestart"
        Me.colOrderUtilizeddatestart.Visible = True
        Me.colOrderUtilizeddatestart.VisibleIndex = 9
        Me.colOrderUtilizeddatestart.Width = 98
        '
        'colOrderUtilizeddateend
        '
        Me.colOrderUtilizeddateend.Caption = "Used Date End"
        Me.colOrderUtilizeddateend.FieldName = "order_utilizeddateend"
        Me.colOrderUtilizeddateend.Name = "colOrderUtilizeddateend"
        Me.colOrderUtilizeddateend.Visible = True
        Me.colOrderUtilizeddateend.VisibleIndex = 10
        Me.colOrderUtilizeddateend.Width = 89
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnPick)
        Me.PanelControl2.Controls.Add(Me.btnCancel)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 336)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(742, 42)
        Me.PanelControl2.TabIndex = 2
        '
        'btnPick
        '
        Me.btnPick.Location = New System.Drawing.Point(565, 7)
        Me.btnPick.Name = "btnPick"
        Me.btnPick.Size = New System.Drawing.Size(75, 23)
        Me.btnPick.TabIndex = 3
        Me.btnPick.Text = "Pick"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(655, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        '
        'xdlgSelectOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 378)
        Me.Controls.Add(Me.gcSelectOrder)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Name = "xdlgSelectOrder"
        Me.Text = "Select Order "
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.objSearchOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcSelectOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvSelectOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gcSelectOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvSelectOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents objSearchOrder As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lborder_id As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colOrderID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekananName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderSetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderUtilizeddatestart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderUtilizeddateend As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
End Class
