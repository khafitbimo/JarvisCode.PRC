<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGetOrder
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
        Me.lblHalfBma = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.TxtFullBma = New System.Windows.Forms.Label
        Me.lblFullBma = New System.Windows.Forms.Label
        Me.txtHalfBma = New System.Windows.Forms.Label
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataOrder_Header = New System.Windows.Forms.TabPage
        Me.chk_order_id = New System.Windows.Forms.CheckBox
        Me.obj_request_id = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvOrderList = New System.Windows.Forms.DataGridView
        Me.chk_rekanan = New System.Windows.Forms.CheckBox
        Me.obj_rekanan = New System.Windows.Forms.TextBox
        Me.ftabDataOrder_Detil = New System.Windows.Forms.TabPage
        Me.dgvOrderDetilList = New System.Windows.Forms.DataGridView
        Me.ftabDataRequest_Detil = New System.Windows.Forms.TabPage
        Me.DgvRequestdetilList = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataOrder_Header.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataOrder_Detil.SuspendLayout()
        CType(Me.dgvOrderDetilList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataRequest_Detil.SuspendLayout()
        CType(Me.DgvRequestdetilList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblHalfBma)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.TxtFullBma)
        Me.Panel1.Controls.Add(Me.lblFullBma)
        Me.Panel1.Controls.Add(Me.txtHalfBma)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 490)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(657, 34)
        Me.Panel1.TabIndex = 1
        '
        'lblHalfBma
        '
        Me.lblHalfBma.BackColor = System.Drawing.Color.White
        Me.lblHalfBma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHalfBma.Location = New System.Drawing.Point(112, 9)
        Me.lblHalfBma.Name = "lblHalfBma"
        Me.lblHalfBma.Size = New System.Drawing.Size(15, 15)
        Me.lblHalfBma.TabIndex = 49
        Me.lblHalfBma.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(489, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(570, 7)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TxtFullBma
        '
        Me.TxtFullBma.AutoSize = True
        Me.TxtFullBma.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.TxtFullBma.Location = New System.Drawing.Point(27, 10)
        Me.TxtFullBma.Name = "TxtFullBma"
        Me.TxtFullBma.Size = New System.Drawing.Size(69, 13)
        Me.TxtFullBma.TabIndex = 46
        Me.TxtFullBma.Text = "Full App.Bma"
        Me.TxtFullBma.Visible = False
        '
        'lblFullBma
        '
        Me.lblFullBma.BackColor = System.Drawing.Color.GreenYellow
        Me.lblFullBma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFullBma.Location = New System.Drawing.Point(9, 8)
        Me.lblFullBma.Name = "lblFullBma"
        Me.lblFullBma.Size = New System.Drawing.Size(15, 15)
        Me.lblFullBma.TabIndex = 48
        Me.lblFullBma.Visible = False
        '
        'txtHalfBma
        '
        Me.txtHalfBma.AutoSize = True
        Me.txtHalfBma.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.txtHalfBma.Location = New System.Drawing.Point(130, 10)
        Me.txtHalfBma.Name = "txtHalfBma"
        Me.txtHalfBma.Size = New System.Drawing.Size(71, 13)
        Me.txtHalfBma.TabIndex = 47
        Me.txtHalfBma.Text = "Half App.Bma"
        Me.txtHalfBma.Visible = False
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataOrder_Header)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataOrder_Detil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataRequest_Detil)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftabDataDetil.Location = New System.Drawing.Point(0, 0)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(657, 490)
        Me.ftabDataDetil.TabIndex = 102
        '
        'ftabDataOrder_Header
        '
        Me.ftabDataOrder_Header.BackColor = System.Drawing.Color.White
        Me.ftabDataOrder_Header.Controls.Add(Me.chk_order_id)
        Me.ftabDataOrder_Header.Controls.Add(Me.obj_request_id)
        Me.ftabDataOrder_Header.Controls.Add(Me.Panel2)
        Me.ftabDataOrder_Header.Controls.Add(Me.chk_rekanan)
        Me.ftabDataOrder_Header.Controls.Add(Me.obj_rekanan)
        Me.ftabDataOrder_Header.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataOrder_Header.Name = "ftabDataOrder_Header"
        Me.ftabDataOrder_Header.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataOrder_Header.Size = New System.Drawing.Size(649, 461)
        Me.ftabDataOrder_Header.TabIndex = 0
        Me.ftabDataOrder_Header.Text = "Order Header"
        '
        'chk_order_id
        '
        Me.chk_order_id.AutoSize = True
        Me.chk_order_id.Location = New System.Drawing.Point(8, 13)
        Me.chk_order_id.Name = "chk_order_id"
        Me.chk_order_id.Size = New System.Drawing.Size(66, 18)
        Me.chk_order_id.TabIndex = 12
        Me.chk_order_id.Text = "Order ID"
        Me.chk_order_id.UseVisualStyleBackColor = True
        '
        'obj_request_id
        '
        Me.obj_request_id.Location = New System.Drawing.Point(114, 12)
        Me.obj_request_id.Name = "obj_request_id"
        Me.obj_request_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_request_id.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvOrderList)
        Me.Panel2.Location = New System.Drawing.Point(-4, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(653, 398)
        Me.Panel2.TabIndex = 10
        '
        'dgvOrderList
        '
        Me.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderList.Location = New System.Drawing.Point(4, 3)
        Me.dgvOrderList.Name = "dgvOrderList"
        Me.dgvOrderList.Size = New System.Drawing.Size(649, 395)
        Me.dgvOrderList.TabIndex = 7
        '
        'chk_rekanan
        '
        Me.chk_rekanan.AutoSize = True
        Me.chk_rekanan.Location = New System.Drawing.Point(8, 39)
        Me.chk_rekanan.Name = "chk_rekanan"
        Me.chk_rekanan.Size = New System.Drawing.Size(98, 18)
        Me.chk_rekanan.TabIndex = 9
        Me.chk_rekanan.Text = "Rekanan Name"
        Me.chk_rekanan.UseVisualStyleBackColor = True
        '
        'obj_rekanan
        '
        Me.obj_rekanan.Location = New System.Drawing.Point(114, 38)
        Me.obj_rekanan.Name = "obj_rekanan"
        Me.obj_rekanan.Size = New System.Drawing.Size(195, 20)
        Me.obj_rekanan.TabIndex = 8
        '
        'ftabDataOrder_Detil
        '
        Me.ftabDataOrder_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataOrder_Detil.Controls.Add(Me.dgvOrderDetilList)
        Me.ftabDataOrder_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataOrder_Detil.Name = "ftabDataOrder_Detil"
        Me.ftabDataOrder_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataOrder_Detil.Size = New System.Drawing.Size(649, 461)
        Me.ftabDataOrder_Detil.TabIndex = 3
        Me.ftabDataOrder_Detil.Text = "Order Detil"
        '
        'dgvOrderDetilList
        '
        Me.dgvOrderDetilList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderDetilList.Location = New System.Drawing.Point(0, 0)
        Me.dgvOrderDetilList.Name = "dgvOrderDetilList"
        Me.dgvOrderDetilList.Size = New System.Drawing.Size(653, 461)
        Me.dgvOrderDetilList.TabIndex = 4
        '
        'ftabDataRequest_Detil
        '
        Me.ftabDataRequest_Detil.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ftabDataRequest_Detil.Controls.Add(Me.DgvRequestdetilList)
        Me.ftabDataRequest_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataRequest_Detil.Name = "ftabDataRequest_Detil"
        Me.ftabDataRequest_Detil.Size = New System.Drawing.Size(649, 461)
        Me.ftabDataRequest_Detil.TabIndex = 4
        Me.ftabDataRequest_Detil.Text = "Request Detil"
        '
        'DgvRequestdetilList
        '
        Me.DgvRequestdetilList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRequestdetilList.Location = New System.Drawing.Point(-2, 0)
        Me.DgvRequestdetilList.Name = "DgvRequestdetilList"
        Me.DgvRequestdetilList.Size = New System.Drawing.Size(653, 461)
        Me.DgvRequestdetilList.TabIndex = 5
        '
        'dlgGetOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 524)
        Me.Controls.Add(Me.ftabDataDetil)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "dlgGetOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Order"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataOrder_Header.ResumeLayout(False)
        Me.ftabDataOrder_Header.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataOrder_Detil.ResumeLayout(False)
        CType(Me.dgvOrderDetilList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataRequest_Detil.ResumeLayout(False)
        CType(Me.DgvRequestdetilList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblHalfBma As System.Windows.Forms.Label
    Friend WithEvents lblFullBma As System.Windows.Forms.Label
    Friend WithEvents txtHalfBma As System.Windows.Forms.Label
    Friend WithEvents TxtFullBma As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataOrder_Header As System.Windows.Forms.TabPage
    Friend WithEvents dgvOrderList As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataOrder_Detil As System.Windows.Forms.TabPage
    Friend WithEvents dgvOrderDetilList As System.Windows.Forms.DataGridView
    Friend WithEvents chk_rekanan As System.Windows.Forms.CheckBox
    Friend WithEvents obj_rekanan As System.Windows.Forms.TextBox
    Friend WithEvents chk_order_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_request_id As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ftabDataRequest_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvRequestdetilList As System.Windows.Forms.DataGridView
End Class
