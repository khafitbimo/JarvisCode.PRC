<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAttachmentDescr
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
        Me.Btn_OK = New DevExpress.XtraEditors.SimpleButton()
        Me.obj_attachmentdscr = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_doctype = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.obj_attachmentdscr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_doctype.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_OK
        '
        Me.Btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_OK.Location = New System.Drawing.Point(190, 64)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.Btn_OK.TabIndex = 0
        Me.Btn_OK.Text = "OK"
        '
        'obj_attachmentdscr
        '
        Me.obj_attachmentdscr.Location = New System.Drawing.Point(7, 38)
        Me.obj_attachmentdscr.Name = "obj_attachmentdscr"
        Me.obj_attachmentdscr.Size = New System.Drawing.Size(258, 20)
        Me.obj_attachmentdscr.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(7, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Document Type"
        '
        'obj_doctype
        '
        Me.obj_doctype.Location = New System.Drawing.Point(88, 12)
        Me.obj_doctype.Name = "obj_doctype"
        Me.obj_doctype.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.obj_doctype.Properties.Items.AddRange(New Object() {"--Pilih--", "Comparative Sheet", "Other", "KTP", "NPWP", "Passport", "Contract", "Log Report"})
        Me.obj_doctype.Size = New System.Drawing.Size(177, 20)
        Me.obj_doctype.TabIndex = 4
        '
        'dlgAttachmentDescr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.obj_doctype)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.obj_attachmentdscr)
        Me.Controls.Add(Me.Btn_OK)
        Me.Name = "dlgAttachmentDescr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attachment Description"
        CType(Me.obj_attachmentdscr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_doctype.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents obj_attachmentdscr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_doctype As DevExpress.XtraEditors.ComboBoxEdit
End Class
