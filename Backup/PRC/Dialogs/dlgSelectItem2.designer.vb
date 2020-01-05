<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectItem2
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.tctItemName = New System.Windows.Forms.Label
        Me.tctItemDesc = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.txtItemDesc = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(313, 68)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(232, 68)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'tctItemName
        '
        Me.tctItemName.AutoSize = True
        Me.tctItemName.Location = New System.Drawing.Point(14, 15)
        Me.tctItemName.Name = "tctItemName"
        Me.tctItemName.Size = New System.Drawing.Size(58, 13)
        Me.tctItemName.TabIndex = 7
        Me.tctItemName.Text = "Item Name"
        '
        'tctItemDesc
        '
        Me.tctItemDesc.AutoSize = True
        Me.tctItemDesc.Location = New System.Drawing.Point(14, 40)
        Me.tctItemDesc.Name = "tctItemDesc"
        Me.tctItemDesc.Size = New System.Drawing.Size(58, 13)
        Me.tctItemDesc.TabIndex = 8
        Me.tctItemDesc.Text = "Item Desc."
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(85, 10)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(301, 20)
        Me.txtItemName.TabIndex = 9
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Location = New System.Drawing.Point(85, 39)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(301, 20)
        Me.txtItemDesc.TabIndex = 10
        '
        'dlgSelectItem2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 101)
        Me.Controls.Add(Me.txtItemDesc)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.tctItemDesc)
        Me.Controls.Add(Me.tctItemName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSelectItem2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgSelectItem2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tctItemName As System.Windows.Forms.Label
    Friend WithEvents tctItemDesc As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
End Class
