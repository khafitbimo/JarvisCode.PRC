<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSelectStrukturunit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_strukturunit_name = New System.Windows.Forms.TextBox()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.DgvStrukturUnit = New System.Windows.Forms.DataGridView()
        Me.colStruktuunitID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStrukturunitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnlHeader.SuspendLayout()
        Me.PnlFooter.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        CType(Me.DgvStrukturUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.Controls.Add(Me.Label1)
        Me.PnlHeader.Controls.Add(Me.obj_strukturunit_name)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(409, 40)
        Me.PnlHeader.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Department"
        '
        'obj_strukturunit_name
        '
        Me.obj_strukturunit_name.Location = New System.Drawing.Point(80, 10)
        Me.obj_strukturunit_name.Name = "obj_strukturunit_name"
        Me.obj_strukturunit_name.Size = New System.Drawing.Size(239, 20)
        Me.obj_strukturunit_name.TabIndex = 0
        '
        'PnlFooter
        '
        Me.PnlFooter.Controls.Add(Me.btnOK)
        Me.PnlFooter.Controls.Add(Me.btnCancel)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 383)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(409, 34)
        Me.PnlFooter.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(244, 6)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(325, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PnlBody
        '
        Me.PnlBody.Controls.Add(Me.DgvStrukturUnit)
        Me.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBody.Location = New System.Drawing.Point(0, 40)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Padding = New System.Windows.Forms.Padding(3)
        Me.PnlBody.Size = New System.Drawing.Size(409, 343)
        Me.PnlBody.TabIndex = 3
        '
        'DgvStrukturUnit
        '
        Me.DgvStrukturUnit.AllowUserToAddRows = False
        Me.DgvStrukturUnit.AllowUserToDeleteRows = False
        Me.DgvStrukturUnit.AllowUserToResizeRows = False
        Me.DgvStrukturUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvStrukturUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStrukturUnit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStruktuunitID, Me.colStrukturunitName})
        Me.DgvStrukturUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvStrukturUnit.Location = New System.Drawing.Point(3, 3)
        Me.DgvStrukturUnit.Name = "DgvStrukturUnit"
        Me.DgvStrukturUnit.ReadOnly = True
        Me.DgvStrukturUnit.RowHeadersVisible = False
        Me.DgvStrukturUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvStrukturUnit.Size = New System.Drawing.Size(403, 337)
        Me.DgvStrukturUnit.TabIndex = 0
        '
        'colStruktuunitID
        '
        Me.colStruktuunitID.DataPropertyName = "strukturunit_id"
        Me.colStruktuunitID.HeaderText = "ID"
        Me.colStruktuunitID.Name = "colStruktuunitID"
        Me.colStruktuunitID.ReadOnly = True
        '
        'colStrukturunitName
        '
        Me.colStrukturunitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStrukturunitName.DataPropertyName = "strukturunit_name"
        Me.colStrukturunitName.HeaderText = "Department"
        Me.colStrukturunitName.Name = "colStrukturunitName"
        Me.colStrukturunitName.ReadOnly = True
        '
        'DlgSelectStrukturunit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 417)
        Me.Controls.Add(Me.PnlBody)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.PnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgSelectStrukturunit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Department"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        CType(Me.DgvStrukturUnit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_strukturunit_name As System.Windows.Forms.TextBox
    Friend WithEvents PnlFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents DgvStrukturUnit As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents colStruktuunitID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStrukturunitName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
