<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnRentalOrder_SelectDays_2
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtp_Order_setdate = New System.Windows.Forms.DateTimePicker
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.obj_Orderdetil_descr = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.obj_Orderdetil_qty = New System.Windows.Forms.TextBox
        Me.obj_RentalItem_id = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.obj_Orderdetil_idr = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_Orderdetil_line = New System.Windows.Forms.TextBox
        Me.dtp_Order_utilizeddateend = New System.Windows.Forms.DateTimePicker
        Me.dtp_Order_utilizeddatestart = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lnkClearAll = New System.Windows.Forms.LinkLabel
        Me.lnkCheckAll = New System.Windows.Forms.LinkLabel
        Me.chkItemDescr = New System.Windows.Forms.CheckBox
        Me.txtItemDescr = New System.Windows.Forms.TextBox
        Me.DgvOrderdetiluse = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvOrderdetiluse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(348, 13)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(429, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 391)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(514, 43)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.dtp_Order_setdate)
        Me.GroupBox3.Controls.Add(Me.btnGenerate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.obj_Orderdetil_descr)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.obj_Orderdetil_qty)
        Me.GroupBox3.Controls.Add(Me.obj_RentalItem_id)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.obj_Orderdetil_idr)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.obj_Orderdetil_line)
        Me.GroupBox3.Controls.Add(Me.dtp_Order_utilizeddateend)
        Me.GroupBox3.Controls.Add(Me.dtp_Order_utilizeddatestart)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(514, 115)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Set Up"
        '
        'dtp_Order_setdate
        '
        Me.dtp_Order_setdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_setdate.Enabled = False
        Me.dtp_Order_setdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_setdate.Location = New System.Drawing.Point(61, 38)
        Me.dtp_Order_setdate.Name = "dtp_Order_setdate"
        Me.dtp_Order_setdate.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_setdate.TabIndex = 80
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGenerate.Location = New System.Drawing.Point(392, 86)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(112, 23)
        Me.btnGenerate.TabIndex = 79
        Me.btnGenerate.Text = "&Apply Changes"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(187, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Descr"
        '
        'obj_Orderdetil_descr
        '
        Me.obj_Orderdetil_descr.Location = New System.Drawing.Point(228, 38)
        Me.obj_Orderdetil_descr.Name = "obj_Orderdetil_descr"
        Me.obj_Orderdetil_descr.Size = New System.Drawing.Size(276, 20)
        Me.obj_Orderdetil_descr.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(187, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Qty"
        '
        'obj_Orderdetil_qty
        '
        Me.obj_Orderdetil_qty.Enabled = False
        Me.obj_Orderdetil_qty.Location = New System.Drawing.Point(228, 60)
        Me.obj_Orderdetil_qty.Name = "obj_Orderdetil_qty"
        Me.obj_Orderdetil_qty.Size = New System.Drawing.Size(78, 20)
        Me.obj_Orderdetil_qty.TabIndex = 75
        Me.obj_Orderdetil_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_RentalItem_id
        '
        Me.obj_RentalItem_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.obj_RentalItem_id.FormattingEnabled = True
        Me.obj_RentalItem_id.Location = New System.Drawing.Point(228, 15)
        Me.obj_RentalItem_id.Name = "obj_RentalItem_id"
        Me.obj_RentalItem_id.Size = New System.Drawing.Size(276, 21)
        Me.obj_RentalItem_id.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(187, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Item"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(321, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Amount IDR"
        '
        'obj_Orderdetil_idr
        '
        Me.obj_Orderdetil_idr.Enabled = False
        Me.obj_Orderdetil_idr.Location = New System.Drawing.Point(392, 60)
        Me.obj_Orderdetil_idr.Name = "obj_Orderdetil_idr"
        Me.obj_Orderdetil_idr.Size = New System.Drawing.Size(112, 20)
        Me.obj_Orderdetil_idr.TabIndex = 71
        Me.obj_Orderdetil_idr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Line"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "End"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Start"
        '
        'obj_Orderdetil_line
        '
        Me.obj_Orderdetil_line.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_Orderdetil_line.Location = New System.Drawing.Point(61, 15)
        Me.obj_Orderdetil_line.Name = "obj_Orderdetil_line"
        Me.obj_Orderdetil_line.ReadOnly = True
        Me.obj_Orderdetil_line.Size = New System.Drawing.Size(98, 20)
        Me.obj_Orderdetil_line.TabIndex = 67
        Me.obj_Orderdetil_line.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtp_Order_utilizeddateend
        '
        Me.dtp_Order_utilizeddateend.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_utilizeddateend.Enabled = False
        Me.dtp_Order_utilizeddateend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_utilizeddateend.Location = New System.Drawing.Point(61, 82)
        Me.dtp_Order_utilizeddateend.Name = "dtp_Order_utilizeddateend"
        Me.dtp_Order_utilizeddateend.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_utilizeddateend.TabIndex = 66
        '
        'dtp_Order_utilizeddatestart
        '
        Me.dtp_Order_utilizeddatestart.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_utilizeddatestart.Enabled = False
        Me.dtp_Order_utilizeddatestart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_utilizeddatestart.Location = New System.Drawing.Point(61, 60)
        Me.dtp_Order_utilizeddatestart.Name = "dtp_Order_utilizeddatestart"
        Me.dtp_Order_utilizeddatestart.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_utilizeddatestart.TabIndex = 65
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lnkClearAll)
        Me.GroupBox2.Controls.Add(Me.lnkCheckAll)
        Me.GroupBox2.Controls.Add(Me.chkItemDescr)
        Me.GroupBox2.Controls.Add(Me.txtItemDescr)
        Me.GroupBox2.Controls.Add(Me.DgvOrderdetiluse)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(514, 276)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        '
        'lnkClearAll
        '
        Me.lnkClearAll.AutoSize = True
        Me.lnkClearAll.Location = New System.Drawing.Point(80, 206)
        Me.lnkClearAll.Name = "lnkClearAll"
        Me.lnkClearAll.Size = New System.Drawing.Size(45, 13)
        Me.lnkClearAll.TabIndex = 58
        Me.lnkClearAll.TabStop = True
        Me.lnkClearAll.Text = "Clear All"
        '
        'lnkCheckAll
        '
        Me.lnkCheckAll.AutoSize = True
        Me.lnkCheckAll.Location = New System.Drawing.Point(13, 206)
        Me.lnkCheckAll.Name = "lnkCheckAll"
        Me.lnkCheckAll.Size = New System.Drawing.Size(52, 13)
        Me.lnkCheckAll.TabIndex = 57
        Me.lnkCheckAll.TabStop = True
        Me.lnkCheckAll.Text = "Check All"
        '
        'chkItemDescr
        '
        Me.chkItemDescr.AutoSize = True
        Me.chkItemDescr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkItemDescr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkItemDescr.Location = New System.Drawing.Point(355, 205)
        Me.chkItemDescr.Name = "chkItemDescr"
        Me.chkItemDescr.Size = New System.Drawing.Size(149, 17)
        Me.chkItemDescr.TabIndex = 56
        Me.chkItemDescr.Text = "Generate Item Description"
        Me.chkItemDescr.UseVisualStyleBackColor = True
        '
        'txtItemDescr
        '
        Me.txtItemDescr.Location = New System.Drawing.Point(10, 226)
        Me.txtItemDescr.Multiline = True
        Me.txtItemDescr.Name = "txtItemDescr"
        Me.txtItemDescr.Size = New System.Drawing.Size(494, 42)
        Me.txtItemDescr.TabIndex = 55
        '
        'DgvOrderdetiluse
        '
        Me.DgvOrderdetiluse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOrderdetiluse.Location = New System.Drawing.Point(10, 15)
        Me.DgvOrderdetiluse.Name = "DgvOrderdetiluse"
        Me.DgvOrderdetiluse.Size = New System.Drawing.Size(494, 186)
        Me.DgvOrderdetiluse.TabIndex = 54
        '
        'dlgTrnRentalOrder_SelectDays_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 439)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "dlgTrnRentalOrder_SelectDays_2"
        Me.ShowInTaskbar = False
        Me.Text = "Select Days"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvOrderdetiluse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_Orderdetil_descr As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents obj_Orderdetil_qty As System.Windows.Forms.TextBox
    Friend WithEvents obj_RentalItem_id As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_Orderdetil_idr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_Orderdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Order_utilizeddateend As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Order_utilizeddatestart As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkClearAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkCheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents chkItemDescr As System.Windows.Forms.CheckBox
    Friend WithEvents txtItemDescr As System.Windows.Forms.TextBox
    Friend WithEvents DgvOrderdetiluse As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtp_Order_setdate As System.Windows.Forms.DateTimePicker
End Class
