<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGetRequest
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCheckAll = New System.Windows.Forms.Button()
        Me.lblHalfBma = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.TxtFullBma = New System.Windows.Forms.Label()
        Me.lblFullBma = New System.Windows.Forms.Label()
        Me.txtHalfBma = New System.Windows.Forms.Label()
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl()
        Me.ftabDataReq_Header = New System.Windows.Forms.TabPage()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.cboexpired = New System.Windows.Forms.ComboBox()
        Me.chk_status = New System.Windows.Forms.CheckBox()
        Me.chk_request_id = New System.Windows.Forms.CheckBox()
        Me.obj_request_id = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvRequestList = New System.Windows.Forms.DataGridView()
        Me.chk_rekanan = New System.Windows.Forms.CheckBox()
        Me.obj_rekanan = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataReq_Header.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvRequestList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnCheckAll)
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
        'BtnCheckAll
        '
        Me.BtnCheckAll.Location = New System.Drawing.Point(218, 7)
        Me.BtnCheckAll.Name = "BtnCheckAll"
        Me.BtnCheckAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnCheckAll.TabIndex = 50
        Me.BtnCheckAll.Text = "Check All"
        Me.BtnCheckAll.UseVisualStyleBackColor = True
        Me.BtnCheckAll.Visible = False
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
        Me.btnCancel.Location = New System.Drawing.Point(489, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
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
        Me.ftabDataDetil.Controls.Add(Me.ftabDataReq_Header)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftabDataDetil.Location = New System.Drawing.Point(0, 0)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(657, 490)
        Me.ftabDataDetil.TabIndex = 102
        '
        'ftabDataReq_Header
        '
        Me.ftabDataReq_Header.BackColor = System.Drawing.Color.White
        Me.ftabDataReq_Header.Controls.Add(Me.btnLoadData)
        Me.ftabDataReq_Header.Controls.Add(Me.cboexpired)
        Me.ftabDataReq_Header.Controls.Add(Me.chk_status)
        Me.ftabDataReq_Header.Controls.Add(Me.chk_request_id)
        Me.ftabDataReq_Header.Controls.Add(Me.obj_request_id)
        Me.ftabDataReq_Header.Controls.Add(Me.Panel2)
        Me.ftabDataReq_Header.Controls.Add(Me.chk_rekanan)
        Me.ftabDataReq_Header.Controls.Add(Me.obj_rekanan)
        Me.ftabDataReq_Header.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataReq_Header.Name = "ftabDataReq_Header"
        Me.ftabDataReq_Header.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataReq_Header.Size = New System.Drawing.Size(649, 461)
        Me.ftabDataReq_Header.TabIndex = 0
        Me.ftabDataReq_Header.Text = "Request Header"
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(385, 39)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 51
        Me.btnLoadData.Text = "Load Data"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'cboexpired
        '
        Me.cboexpired.AutoCompleteCustomSource.AddRange(New String() {"Not Expired", "Expired"})
        Me.cboexpired.FormattingEnabled = True
        Me.cboexpired.Items.AddRange(New Object() {"Not Expired", "Expired"})
        Me.cboexpired.Location = New System.Drawing.Point(385, 3)
        Me.cboexpired.Name = "cboexpired"
        Me.cboexpired.Size = New System.Drawing.Size(121, 22)
        Me.cboexpired.TabIndex = 16
        '
        'chk_status
        '
        Me.chk_status.AutoSize = True
        Me.chk_status.Checked = True
        Me.chk_status.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_status.Enabled = False
        Me.chk_status.Location = New System.Drawing.Point(322, 7)
        Me.chk_status.Name = "chk_status"
        Me.chk_status.Size = New System.Drawing.Size(57, 18)
        Me.chk_status.TabIndex = 15
        Me.chk_status.Text = "Status"
        Me.chk_status.UseVisualStyleBackColor = True
        '
        'chk_request_id
        '
        Me.chk_request_id.AutoSize = True
        Me.chk_request_id.Location = New System.Drawing.Point(8, 13)
        Me.chk_request_id.Name = "chk_request_id"
        Me.chk_request_id.Size = New System.Drawing.Size(78, 18)
        Me.chk_request_id.TabIndex = 12
        Me.chk_request_id.Text = "Request ID"
        Me.chk_request_id.UseVisualStyleBackColor = True
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
        Me.Panel2.Controls.Add(Me.dgvRequestList)
        Me.Panel2.Location = New System.Drawing.Point(-4, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(653, 398)
        Me.Panel2.TabIndex = 10
        '
        'dgvRequestList
        '
        Me.dgvRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequestList.Location = New System.Drawing.Point(4, 3)
        Me.dgvRequestList.Name = "dgvRequestList"
        Me.dgvRequestList.Size = New System.Drawing.Size(649, 395)
        Me.dgvRequestList.TabIndex = 7
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
        'dlgGetRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 524)
        Me.Controls.Add(Me.ftabDataDetil)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "dlgGetRequest"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Request"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataReq_Header.ResumeLayout(False)
        Me.ftabDataReq_Header.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvRequestList, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ftabDataReq_Header As System.Windows.Forms.TabPage
    Friend WithEvents dgvRequestList As System.Windows.Forms.DataGridView
    Friend WithEvents chk_rekanan As System.Windows.Forms.CheckBox
    Friend WithEvents obj_rekanan As System.Windows.Forms.TextBox
    Friend WithEvents chk_request_id As System.Windows.Forms.CheckBox
    Friend WithEvents obj_request_id As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnCheckAll As System.Windows.Forms.Button
    Friend WithEvents cboexpired As System.Windows.Forms.ComboBox
    Friend WithEvents chk_status As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
End Class
