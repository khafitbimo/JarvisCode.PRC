<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopUpFind
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvMain = New System.Windows.Forms.DataGridView
        Me.txtKeyWord = New System.Windows.Forms.TextBox
        Me.lblFind = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Linen
        Me.Panel1.Controls.Add(Me.dgvMain)
        Me.Panel1.Controls.Add(Me.txtKeyWord)
        Me.Panel1.Controls.Add(Me.lblFind)
        Me.Panel1.Location = New System.Drawing.Point(10, 9)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 346)
        Me.Panel1.TabIndex = 4
        '
        'dgvMain
        '
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Location = New System.Drawing.Point(17, 52)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.Size = New System.Drawing.Size(388, 275)
        Me.dgvMain.TabIndex = 3
        '
        'txtKeyWord
        '
        Me.txtKeyWord.Location = New System.Drawing.Point(47, 13)
        Me.txtKeyWord.Name = "txtKeyWord"
        Me.txtKeyWord.Size = New System.Drawing.Size(296, 20)
        Me.txtKeyWord.TabIndex = 0
        '
        'lblFind
        '
        Me.lblFind.AutoSize = True
        Me.lblFind.Location = New System.Drawing.Point(14, 16)
        Me.lblFind.Name = "lblFind"
        Me.lblFind.Size = New System.Drawing.Size(27, 13)
        Me.lblFind.TabIndex = 2
        Me.lblFind.Text = "Find"
        '
        'frmPopUpFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(442, 365)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPopUpFind"
        Me.Text = "frmPopUpFind"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvMain As System.Windows.Forms.DataGridView
    Friend WithEvents txtKeyWord As System.Windows.Forms.TextBox
    Friend WithEvents lblFind As System.Windows.Forms.Label
End Class
