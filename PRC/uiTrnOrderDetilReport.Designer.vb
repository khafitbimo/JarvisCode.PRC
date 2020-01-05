<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnOrderDetilReport
    Inherits uiBase

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnOrderDetilReport))
        Me.ftabmain = New FlatTabControl.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PnlReport = New System.Windows.Forms.Panel()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.obj_strukturunit_id = New System.Windows.Forms.TextBox()
        Me.btnDepartment = New System.Windows.Forms.Button()
        Me.obj_strukturunit_name = New System.Windows.Forms.TextBox()
        Me.chk_dept_search = New System.Windows.Forms.CheckBox()
        Me.obj_currency_srch = New System.Windows.Forms.ComboBox()
        Me.btnVendor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_bookdate_search_akhir = New System.Windows.Forms.DateTimePicker()
        Me.obj_bookdate_search_awal = New System.Windows.Forms.DateTimePicker()
        Me.chk_periode_srch = New System.Windows.Forms.CheckBox()
        Me.chk_type_srch = New System.Windows.Forms.CheckBox()
        Me.chk_currency_srch = New System.Windows.Forms.CheckBox()
        Me.obj_vendor_srch = New System.Windows.Forms.TextBox()
        Me.chk_vendor_srch = New System.Windows.Forms.CheckBox()
        Me.cboTypeSearch = New System.Windows.Forms.ComboBox()
        Me.ftabmain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabmain
        '
        Me.ftabmain.Controls.Add(Me.TabPage1)
        Me.ftabmain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabmain.Location = New System.Drawing.Point(0, 25)
        Me.ftabmain.myBackColor = System.Drawing.Color.LightSteelBlue
        Me.ftabmain.Name = "ftabmain"
        Me.ftabmain.SelectedIndex = 0
        Me.ftabmain.Size = New System.Drawing.Size(992, 523)
        Me.ftabmain.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.PnlReport)
        Me.TabPage1.Controls.Add(Me.PnlDfSearch)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(984, 494)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report"
        '
        'PnlReport
        '
        Me.PnlReport.BackColor = System.Drawing.Color.DarkGray
        Me.PnlReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlReport.Location = New System.Drawing.Point(3, 128)
        Me.PnlReport.Name = "PnlReport"
        Me.PnlReport.Padding = New System.Windows.Forms.Padding(3)
        Me.PnlReport.Size = New System.Drawing.Size(978, 363)
        Me.PnlReport.TabIndex = 4
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.obj_strukturunit_id)
        Me.PnlDfSearch.Controls.Add(Me.btnDepartment)
        Me.PnlDfSearch.Controls.Add(Me.obj_strukturunit_name)
        Me.PnlDfSearch.Controls.Add(Me.chk_dept_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_currency_srch)
        Me.PnlDfSearch.Controls.Add(Me.btnVendor)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.obj_bookdate_search_akhir)
        Me.PnlDfSearch.Controls.Add(Me.obj_bookdate_search_awal)
        Me.PnlDfSearch.Controls.Add(Me.chk_periode_srch)
        Me.PnlDfSearch.Controls.Add(Me.chk_type_srch)
        Me.PnlDfSearch.Controls.Add(Me.chk_currency_srch)
        Me.PnlDfSearch.Controls.Add(Me.obj_vendor_srch)
        Me.PnlDfSearch.Controls.Add(Me.chk_vendor_srch)
        Me.PnlDfSearch.Controls.Add(Me.cboTypeSearch)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(978, 125)
        Me.PnlDfSearch.TabIndex = 3
        '
        'obj_strukturunit_id
        '
        Me.obj_strukturunit_id.Location = New System.Drawing.Point(116, 98)
        Me.obj_strukturunit_id.Name = "obj_strukturunit_id"
        Me.obj_strukturunit_id.ReadOnly = True
        Me.obj_strukturunit_id.Size = New System.Drawing.Size(68, 20)
        Me.obj_strukturunit_id.TabIndex = 63
        Me.obj_strukturunit_id.TabStop = False
        '
        'btnDepartment
        '
        Me.btnDepartment.Location = New System.Drawing.Point(458, 98)
        Me.btnDepartment.Name = "btnDepartment"
        Me.btnDepartment.Size = New System.Drawing.Size(30, 21)
        Me.btnDepartment.TabIndex = 62
        Me.btnDepartment.Text = "..."
        Me.btnDepartment.UseVisualStyleBackColor = True
        '
        'obj_strukturunit_name
        '
        Me.obj_strukturunit_name.Location = New System.Drawing.Point(190, 98)
        Me.obj_strukturunit_name.Name = "obj_strukturunit_name"
        Me.obj_strukturunit_name.ReadOnly = True
        Me.obj_strukturunit_name.Size = New System.Drawing.Size(262, 20)
        Me.obj_strukturunit_name.TabIndex = 61
        Me.obj_strukturunit_name.TabStop = False
        '
        'chk_dept_search
        '
        Me.chk_dept_search.AutoSize = True
        Me.chk_dept_search.Location = New System.Drawing.Point(17, 100)
        Me.chk_dept_search.Name = "chk_dept_search"
        Me.chk_dept_search.Size = New System.Drawing.Size(81, 17)
        Me.chk_dept_search.TabIndex = 60
        Me.chk_dept_search.Text = "Department"
        Me.chk_dept_search.UseVisualStyleBackColor = True
        '
        'obj_currency_srch
        '
        Me.obj_currency_srch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_currency_srch.FormattingEnabled = True
        Me.obj_currency_srch.Items.AddRange(New Object() {"GQ", "NQ", "RQ", "TQ"})
        Me.obj_currency_srch.Location = New System.Drawing.Point(116, 52)
        Me.obj_currency_srch.Name = "obj_currency_srch"
        Me.obj_currency_srch.Size = New System.Drawing.Size(121, 21)
        Me.obj_currency_srch.TabIndex = 59
        '
        'btnVendor
        '
        Me.btnVendor.Location = New System.Drawing.Point(340, 6)
        Me.btnVendor.Name = "btnVendor"
        Me.btnVendor.Size = New System.Drawing.Size(30, 21)
        Me.btnVendor.TabIndex = 58
        Me.btnVendor.Text = "..."
        Me.btnVendor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(200, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "s/d"
        '
        'obj_bookdate_search_akhir
        '
        Me.obj_bookdate_search_akhir.CustomFormat = "dd/MM/yyyy"
        Me.obj_bookdate_search_akhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_bookdate_search_akhir.Location = New System.Drawing.Point(222, 29)
        Me.obj_bookdate_search_akhir.Name = "obj_bookdate_search_akhir"
        Me.obj_bookdate_search_akhir.Size = New System.Drawing.Size(82, 20)
        Me.obj_bookdate_search_akhir.TabIndex = 56
        '
        'obj_bookdate_search_awal
        '
        Me.obj_bookdate_search_awal.CustomFormat = "dd/MM/yyyy"
        Me.obj_bookdate_search_awal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_bookdate_search_awal.Location = New System.Drawing.Point(115, 29)
        Me.obj_bookdate_search_awal.Name = "obj_bookdate_search_awal"
        Me.obj_bookdate_search_awal.Size = New System.Drawing.Size(84, 20)
        Me.obj_bookdate_search_awal.TabIndex = 55
        '
        'chk_periode_srch
        '
        Me.chk_periode_srch.AutoSize = True
        Me.chk_periode_srch.Location = New System.Drawing.Point(17, 31)
        Me.chk_periode_srch.Name = "chk_periode_srch"
        Me.chk_periode_srch.Size = New System.Drawing.Size(62, 17)
        Me.chk_periode_srch.TabIndex = 53
        Me.chk_periode_srch.Text = "Periode"
        Me.chk_periode_srch.UseVisualStyleBackColor = True
        '
        'chk_type_srch
        '
        Me.chk_type_srch.AutoSize = True
        Me.chk_type_srch.Location = New System.Drawing.Point(17, 77)
        Me.chk_type_srch.Name = "chk_type_srch"
        Me.chk_type_srch.Size = New System.Drawing.Size(79, 17)
        Me.chk_type_srch.TabIndex = 52
        Me.chk_type_srch.Text = "Order Type"
        Me.chk_type_srch.UseVisualStyleBackColor = True
        '
        'chk_currency_srch
        '
        Me.chk_currency_srch.AutoSize = True
        Me.chk_currency_srch.Location = New System.Drawing.Point(17, 54)
        Me.chk_currency_srch.Name = "chk_currency_srch"
        Me.chk_currency_srch.Size = New System.Drawing.Size(68, 17)
        Me.chk_currency_srch.TabIndex = 50
        Me.chk_currency_srch.Text = "Currency"
        Me.chk_currency_srch.UseVisualStyleBackColor = True
        '
        'obj_vendor_srch
        '
        Me.obj_vendor_srch.Location = New System.Drawing.Point(115, 6)
        Me.obj_vendor_srch.Name = "obj_vendor_srch"
        Me.obj_vendor_srch.ReadOnly = True
        Me.obj_vendor_srch.Size = New System.Drawing.Size(219, 20)
        Me.obj_vendor_srch.TabIndex = 49
        Me.obj_vendor_srch.TabStop = False
        '
        'chk_vendor_srch
        '
        Me.chk_vendor_srch.AutoSize = True
        Me.chk_vendor_srch.Location = New System.Drawing.Point(17, 8)
        Me.chk_vendor_srch.Name = "chk_vendor_srch"
        Me.chk_vendor_srch.Size = New System.Drawing.Size(60, 17)
        Me.chk_vendor_srch.TabIndex = 48
        Me.chk_vendor_srch.Text = "Vendor"
        Me.chk_vendor_srch.UseVisualStyleBackColor = True
        '
        'cboTypeSearch
        '
        Me.cboTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeSearch.FormattingEnabled = True
        Me.cboTypeSearch.Items.AddRange(New Object() {"RO", "PO", "NO", "TO"})
        Me.cboTypeSearch.Location = New System.Drawing.Point(116, 75)
        Me.cboTypeSearch.Name = "cboTypeSearch"
        Me.cboTypeSearch.Size = New System.Drawing.Size(121, 21)
        Me.cboTypeSearch.TabIndex = 39
        '
        'uiTrnOrderDetilReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ftabmain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiTrnOrderDetilReport"
        Me.Size = New System.Drawing.Size(992, 548)
        Me.Controls.SetChildIndex(Me.ftabmain, 0)
        Me.ftabmain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabmain As FlatTabControl.FlatTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents chk_type_srch As System.Windows.Forms.CheckBox
    Friend WithEvents chk_currency_srch As System.Windows.Forms.CheckBox
    Friend WithEvents chk_vendor_srch As System.Windows.Forms.CheckBox
    Friend WithEvents cboTypeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents obj_bookdate_search_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_bookdate_search_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents chk_periode_srch As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_vendor_srch As System.Windows.Forms.TextBox
    Friend WithEvents btnVendor As System.Windows.Forms.Button
    Friend WithEvents obj_currency_srch As System.Windows.Forms.ComboBox
    Friend WithEvents btnDepartment As System.Windows.Forms.Button
    Friend WithEvents obj_strukturunit_name As System.Windows.Forms.TextBox
    Friend WithEvents chk_dept_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_strukturunit_id As System.Windows.Forms.TextBox
    Friend WithEvents PnlReport As System.Windows.Forms.Panel

End Class
