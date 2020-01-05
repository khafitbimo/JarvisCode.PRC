<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTOPPercentTools
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
        Me.btn_cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_OK = New DevExpress.XtraEditors.SimpleButton()
        Me.obj_percent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_amount_order = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_amountaftpercent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.obj_percent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_amount_order.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_amountaftpercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_cancel)
        Me.PanelControl1.Controls.Add(Me.btn_OK)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 85)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(255, 33)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Location = New System.Drawing.Point(175, 5)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 1
        Me.btn_cancel.Text = "Cancel"
        '
        'btn_OK
        '
        Me.btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.Location = New System.Drawing.Point(94, 5)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 0
        Me.btn_OK.Text = "OK"
        '
        'obj_percent
        '
        Me.obj_percent.Location = New System.Drawing.Point(125, 32)
        Me.obj_percent.Name = "obj_percent"
        Me.obj_percent.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_percent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_percent.Properties.Mask.EditMask = "n2"
        Me.obj_percent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.obj_percent.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.obj_percent.Size = New System.Drawing.Size(122, 20)
        Me.obj_percent.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Percent (%)"
        '
        'obj_amount_order
        '
        Me.obj_amount_order.Location = New System.Drawing.Point(125, 6)
        Me.obj_amount_order.Name = "obj_amount_order"
        Me.obj_amount_order.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_amount_order.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_amount_order.Properties.Mask.EditMask = "n2"
        Me.obj_amount_order.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.obj_amount_order.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.obj_amount_order.Properties.ReadOnly = True
        Me.obj_amount_order.Size = New System.Drawing.Size(122, 20)
        Me.obj_amount_order.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 9)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Amount Order"
        '
        'obj_amountaftpercent
        '
        Me.obj_amountaftpercent.Location = New System.Drawing.Point(125, 58)
        Me.obj_amountaftpercent.Name = "obj_amountaftpercent"
        Me.obj_amountaftpercent.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_amountaftpercent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_amountaftpercent.Properties.EditFormat.FormatString = "n2"
        Me.obj_amountaftpercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_amountaftpercent.Properties.Mask.EditMask = "n2"
        Me.obj_amountaftpercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.obj_amountaftpercent.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.obj_amountaftpercent.Properties.ReadOnly = True
        Me.obj_amountaftpercent.Size = New System.Drawing.Size(122, 20)
        Me.obj_amountaftpercent.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 63)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(105, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Amount After Percent"
        '
        'dlgTOPPercentTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 118)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.obj_amountaftpercent)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.obj_amount_order)
        Me.Controls.Add(Me.obj_percent)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "dlgTOPPercentTools"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Percent Change"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.obj_percent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_amount_order.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_amountaftpercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents obj_percent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_amount_order As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_amountaftpercent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
