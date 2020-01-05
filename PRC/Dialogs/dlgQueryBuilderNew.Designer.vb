<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgQueryBuilderNew
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
        Me.ListOperator = New DevExpress.XtraEditors.ListBoxControl()
        Me.ListLogical = New DevExpress.XtraEditors.ListBoxControl()
        Me.ListFields = New DevExpress.XtraEditors.ListBoxControl()
        Me.txtQuery = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_OK = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_clear = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.ListOperator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListLogical, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListOperator
        '
        Me.ListOperator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListOperator.Location = New System.Drawing.Point(2, 21)
        Me.ListOperator.Name = "ListOperator"
        Me.ListOperator.Size = New System.Drawing.Size(156, 147)
        Me.ListOperator.TabIndex = 0
        '
        'ListLogical
        '
        Me.ListLogical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListLogical.Location = New System.Drawing.Point(2, 21)
        Me.ListLogical.Name = "ListLogical"
        Me.ListLogical.Size = New System.Drawing.Size(156, 175)
        Me.ListLogical.TabIndex = 1
        '
        'ListFields
        '
        Me.ListFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListFields.Location = New System.Drawing.Point(2, 21)
        Me.ListFields.Name = "ListFields"
        Me.ListFields.Size = New System.Drawing.Size(160, 349)
        Me.ListFields.TabIndex = 2
        '
        'txtQuery
        '
        Me.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQuery.Location = New System.Drawing.Point(2, 44)
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(304, 326)
        Me.txtQuery.TabIndex = 4
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btn_OK)
        Me.PanelControl2.Controls.Add(Me.btn_clear)
        Me.PanelControl2.Controls.Add(Me.btn_Cancel)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 372)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(636, 30)
        Me.PanelControl2.TabIndex = 5
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(475, 3)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 2
        Me.btn_OK.Text = "OK"
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(330, 2)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 23)
        Me.btn_clear.TabIndex = 1
        Me.btn_clear.Text = "Clear Query"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(556, 3)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 0
        Me.btn_Cancel.Text = "Cancel"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.ListOperator)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(160, 170)
        Me.GroupControl1.TabIndex = 6
        Me.GroupControl1.Text = "Operator"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.ListLogical)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(2, 172)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(160, 198)
        Me.GroupControl2.TabIndex = 6
        Me.GroupControl2.Text = "Logical"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.ListFields)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(164, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(164, 372)
        Me.GroupControl3.TabIndex = 6
        Me.GroupControl3.Text = "Fields"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.txtQuery)
        Me.GroupControl4.Controls.Add(Me.btnAdd)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupControl4.Location = New System.Drawing.Point(328, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(308, 372)
        Me.GroupControl4.TabIndex = 7
        Me.GroupControl4.Text = "Query Condition"
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAdd.Location = New System.Drawing.Point(2, 21)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(304, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GroupControl2)
        Me.PanelControl1.Controls.Add(Me.GroupControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(164, 372)
        Me.PanelControl1.TabIndex = 8
        '
        'dlgQueryBuilderNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 402)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.PanelControl2)
        Me.Name = "dlgQueryBuilderNew"
        Me.Text = "Query Builder"
        CType(Me.ListOperator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListLogical, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListOperator As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents ListLogical As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents ListFields As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents txtQuery As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_clear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_OK As DevExpress.XtraEditors.SimpleButton
End Class
