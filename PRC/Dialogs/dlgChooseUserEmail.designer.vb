<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChooseUserEmail
    Inherits System.Windows.Forms.Form

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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lueUsername = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnKirimEmail = New System.Windows.Forms.Button()
        Me.txtAlamatEmail = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        CType(Me.lueUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Email To : "
        '
        'lueUsername
        '
        Me.lueUsername.Location = New System.Drawing.Point(113, 22)
        Me.lueUsername.Name = "lueUsername"
        Me.lueUsername.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueUsername.Properties.NullText = ""
        Me.lueUsername.Size = New System.Drawing.Size(283, 20)
        Me.lueUsername.TabIndex = 1
        '
        'btnKirimEmail
        '
        Me.btnKirimEmail.Location = New System.Drawing.Point(112, 74)
        Me.btnKirimEmail.Name = "btnKirimEmail"
        Me.btnKirimEmail.Size = New System.Drawing.Size(75, 23)
        Me.btnKirimEmail.TabIndex = 2
        Me.btnKirimEmail.Text = "Send"
        Me.btnKirimEmail.UseVisualStyleBackColor = True
        '
        'txtAlamatEmail
        '
        Me.txtAlamatEmail.Location = New System.Drawing.Point(113, 48)
        Me.txtAlamatEmail.Name = "txtAlamatEmail"
        Me.txtAlamatEmail.ReadOnly = True
        Me.txtAlamatEmail.Size = New System.Drawing.Size(283, 20)
        Me.txtAlamatEmail.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 51)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Email Address :"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(113, 48)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(283, 20)
        Me.txtUsername.TabIndex = 8
        Me.txtUsername.Visible = False
        '
        'dlgChooseUserEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 119)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtAlamatEmail)
        Me.Controls.Add(Me.btnKirimEmail)
        Me.Controls.Add(Me.lueUsername)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgChooseUserEmail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Send Email"
        CType(Me.lueUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueUsername As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnKirimEmail As System.Windows.Forms.Button
    Friend WithEvents txtAlamatEmail As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox

End Class
