<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgItemChildRequest
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
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_unit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_qty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_requestdetil_line = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_request_id = New DevExpress.XtraEditors.TextEdit()
        Me.obj_descr = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_item = New DevExpress.XtraEditors.TextEdit()
        Me.obj_orderdetilline = New DevExpress.XtraEditors.TextEdit()
        Me.GC_RequestDetilChild = New DevExpress.XtraGrid.GridControl()
        Me.GV_RequestDetilChild = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.request_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.requestdetil_line = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.item_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.item_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.unit_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.unit_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.days = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.usage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.descr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_OK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.obj_unit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_qty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_requestdetil_line.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_request_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_descr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_item.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_orderdetilline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GC_RequestDetilChild, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV_RequestDetilChild, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.obj_unit)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.obj_qty)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.obj_requestdetil_line)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.obj_request_id)
        Me.PanelControl1.Controls.Add(Me.obj_descr)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.obj_item)
        Me.PanelControl1.Controls.Add(Me.obj_orderdetilline)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(639, 83)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(279, 35)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl7.TabIndex = 144
        Me.LabelControl7.Text = "Unit"
        '
        'obj_unit
        '
        Me.obj_unit.Location = New System.Drawing.Point(303, 32)
        Me.obj_unit.Name = "obj_unit"
        Me.obj_unit.Properties.ReadOnly = True
        Me.obj_unit.Size = New System.Drawing.Size(80, 20)
        Me.obj_unit.TabIndex = 143
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(201, 35)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl6.TabIndex = 142
        Me.LabelControl6.Text = "Qty"
        '
        'obj_qty
        '
        Me.obj_qty.Location = New System.Drawing.Point(225, 32)
        Me.obj_qty.Name = "obj_qty"
        Me.obj_qty.Properties.ReadOnly = True
        Me.obj_qty.Size = New System.Drawing.Size(48, 20)
        Me.obj_qty.TabIndex = 141
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(431, 35)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl5.TabIndex = 140
        Me.LabelControl5.Text = "Ref. Request Line"
        '
        'obj_requestdetil_line
        '
        Me.obj_requestdetil_line.Location = New System.Drawing.Point(523, 32)
        Me.obj_requestdetil_line.Name = "obj_requestdetil_line"
        Me.obj_requestdetil_line.Properties.ReadOnly = True
        Me.obj_requestdetil_line.Size = New System.Drawing.Size(52, 20)
        Me.obj_requestdetil_line.TabIndex = 139
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(431, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl4.TabIndex = 138
        Me.LabelControl4.Text = "Ref. Request Id"
        '
        'obj_request_id
        '
        Me.obj_request_id.Location = New System.Drawing.Point(523, 9)
        Me.obj_request_id.Name = "obj_request_id"
        Me.obj_request_id.Properties.ReadOnly = True
        Me.obj_request_id.Size = New System.Drawing.Size(110, 20)
        Me.obj_request_id.TabIndex = 137
        '
        'obj_descr
        '
        Me.obj_descr.Location = New System.Drawing.Point(49, 55)
        Me.obj_descr.Name = "obj_descr"
        Me.obj_descr.Properties.ReadOnly = True
        Me.obj_descr.Size = New System.Drawing.Size(584, 20)
        Me.obj_descr.TabIndex = 136
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 58)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl3.TabIndex = 135
        Me.LabelControl3.Text = "Descr."
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 35)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Item"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Line"
        '
        'obj_item
        '
        Me.obj_item.Location = New System.Drawing.Point(49, 32)
        Me.obj_item.Name = "obj_item"
        Me.obj_item.Properties.ReadOnly = True
        Me.obj_item.Size = New System.Drawing.Size(146, 20)
        Me.obj_item.TabIndex = 1
        '
        'obj_orderdetilline
        '
        Me.obj_orderdetilline.Location = New System.Drawing.Point(49, 9)
        Me.obj_orderdetilline.Name = "obj_orderdetilline"
        Me.obj_orderdetilline.Properties.ReadOnly = True
        Me.obj_orderdetilline.Size = New System.Drawing.Size(48, 20)
        Me.obj_orderdetilline.TabIndex = 0
        '
        'GC_RequestDetilChild
        '
        Me.GC_RequestDetilChild.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_RequestDetilChild.Location = New System.Drawing.Point(0, 83)
        Me.GC_RequestDetilChild.MainView = Me.GV_RequestDetilChild
        Me.GC_RequestDetilChild.Name = "GC_RequestDetilChild"
        Me.GC_RequestDetilChild.Size = New System.Drawing.Size(639, 230)
        Me.GC_RequestDetilChild.TabIndex = 1
        Me.GC_RequestDetilChild.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV_RequestDetilChild})
        '
        'GV_RequestDetilChild
        '
        Me.GV_RequestDetilChild.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.request_id, Me.requestdetil_line, Me.item_id, Me.item_name, Me.unit_id, Me.unit_name, Me.qty, Me.days, Me.usage, Me.descr})
        Me.GV_RequestDetilChild.GridControl = Me.GC_RequestDetilChild
        Me.GV_RequestDetilChild.Name = "GV_RequestDetilChild"
        Me.GV_RequestDetilChild.OptionsBehavior.AutoPopulateColumns = False
        Me.GV_RequestDetilChild.OptionsBehavior.ReadOnly = True
        Me.GV_RequestDetilChild.OptionsView.ColumnAutoWidth = False
        Me.GV_RequestDetilChild.OptionsView.ShowGroupPanel = False
        '
        'request_id
        '
        Me.request_id.Caption = "request_id"
        Me.request_id.FieldName = "request_id"
        Me.request_id.Name = "request_id"
        '
        'requestdetil_line
        '
        Me.requestdetil_line.Caption = "Req. Line"
        Me.requestdetil_line.FieldName = "requestdetil_line"
        Me.requestdetil_line.Name = "requestdetil_line"
        Me.requestdetil_line.Visible = True
        Me.requestdetil_line.VisibleIndex = 0
        Me.requestdetil_line.Width = 63
        '
        'item_id
        '
        Me.item_id.Caption = "item_id"
        Me.item_id.FieldName = "item_id"
        Me.item_id.Name = "item_id"
        '
        'item_name
        '
        Me.item_name.Caption = "Item Name"
        Me.item_name.FieldName = "item_name"
        Me.item_name.Name = "item_name"
        Me.item_name.Visible = True
        Me.item_name.VisibleIndex = 1
        Me.item_name.Width = 183
        '
        'unit_id
        '
        Me.unit_id.Caption = "unit_id"
        Me.unit_id.FieldName = "unit_id"
        Me.unit_id.Name = "unit_id"
        '
        'unit_name
        '
        Me.unit_name.Caption = "Unit"
        Me.unit_name.FieldName = "unit_name"
        Me.unit_name.Name = "unit_name"
        Me.unit_name.Visible = True
        Me.unit_name.VisibleIndex = 2
        Me.unit_name.Width = 70
        '
        'qty
        '
        Me.qty.Caption = "Qty"
        Me.qty.FieldName = "qty"
        Me.qty.Name = "qty"
        Me.qty.Visible = True
        Me.qty.VisibleIndex = 3
        Me.qty.Width = 52
        '
        'days
        '
        Me.days.Caption = "Days"
        Me.days.FieldName = "days"
        Me.days.Name = "days"
        '
        'usage
        '
        Me.usage.Caption = "usage"
        Me.usage.FieldName = "usage"
        Me.usage.Name = "usage"
        '
        'descr
        '
        Me.descr.Caption = "Description"
        Me.descr.FieldName = "descr"
        Me.descr.Name = "descr"
        Me.descr.Visible = True
        Me.descr.VisibleIndex = 4
        Me.descr.Width = 262
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btn_OK)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 313)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(639, 31)
        Me.PanelControl2.TabIndex = 2
        '
        'btn_OK
        '
        Me.btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.Location = New System.Drawing.Point(559, 3)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 0
        Me.btn_OK.Text = "OK"
        '
        'dlgItemChildRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 344)
        Me.ControlBox = False
        Me.Controls.Add(Me.GC_RequestDetilChild)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "dlgItemChildRequest"
        Me.Text = "Detail Item Child"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.obj_unit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_qty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_requestdetil_line.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_request_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_descr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_item.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_orderdetilline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GC_RequestDetilChild, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV_RequestDetilChild, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_requestdetil_line As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_request_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_descr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_item As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_orderdetilline As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GC_RequestDetilChild As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV_RequestDetilChild As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents request_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents requestdetil_line As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents item_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents item_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents unit_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents unit_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents days As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents usage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents descr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_unit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_qty As DevExpress.XtraEditors.TextEdit
End Class
