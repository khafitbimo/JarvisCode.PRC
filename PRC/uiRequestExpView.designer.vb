<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiRequestExpView
    Inherits PRC.uiBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiRequestExpView))
        Me.FlatTabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvToExport = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lb_export = New System.Windows.Forms.Label()
        Me.pb_export = New System.Windows.Forms.ProgressBar()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.lbl_querybuilder = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Clear = New DevExpress.XtraEditors.LabelControl()
        Me.chkSearchAdv = New DevExpress.XtraEditors.CheckEdit()
        Me.txtSearchAdv = New DevExpress.XtraEditors.MemoEdit()
        Me.cbodate_shoot = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboSearchItem = New System.Windows.Forms.ComboBox()
        Me.chkSearchAppKadiv = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpSearchApoKadiv2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpSearchApoKadiv1 = New System.Windows.Forms.DateTimePicker()
        Me.cboDateType = New System.Windows.Forms.ComboBox()
        Me.lblSearchDate2 = New System.Windows.Forms.Label()
        Me.lblSearchDate1 = New System.Windows.Forms.Label()
        Me.dtpSearchDate2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpSearchDate1 = New System.Windows.Forms.DateTimePicker()
        Me.cboSearchStruktur = New System.Windows.Forms.ComboBox()
        Me.chkSearchCategory = New System.Windows.Forms.CheckBox()
        Me.cboSearchCategory = New System.Windows.Forms.ComboBox()
        Me.chkSearchStruktur = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboReportName = New System.Windows.Forms.ComboBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FlatTabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvToExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        CType(Me.chkSearchAdv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearchAdv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlatTabMain
        '
        Me.FlatTabMain.Controls.Add(Me.TabPage1)
        Me.FlatTabMain.Location = New System.Drawing.Point(3, 28)
        Me.FlatTabMain.Name = "FlatTabMain"
        Me.FlatTabMain.SelectedIndex = 0
        Me.FlatTabMain.Size = New System.Drawing.Size(970, 517)
        Me.FlatTabMain.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.PnlDfSearch)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(962, 491)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report Viewer"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 138)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(956, 350)
        Me.Panel3.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvToExport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(956, 315)
        Me.Panel2.TabIndex = 179
        '
        'dgvToExport
        '
        Me.dgvToExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvToExport.Location = New System.Drawing.Point(0, 0)
        Me.dgvToExport.Name = "dgvToExport"
        Me.dgvToExport.Size = New System.Drawing.Size(956, 315)
        Me.dgvToExport.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lb_export)
        Me.Panel1.Controls.Add(Me.pb_export)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 315)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(956, 35)
        Me.Panel1.TabIndex = 178
        '
        'lb_export
        '
        Me.lb_export.BackColor = System.Drawing.Color.Transparent
        Me.lb_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_export.ForeColor = System.Drawing.Color.DarkRed
        Me.lb_export.Location = New System.Drawing.Point(13, 10)
        Me.lb_export.Name = "lb_export"
        Me.lb_export.Size = New System.Drawing.Size(163, 13)
        Me.lb_export.TabIndex = 176
        Me.lb_export.Text = "Exporting 0 of 0 records"
        Me.lb_export.Visible = False
        '
        'pb_export
        '
        Me.pb_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.pb_export.Location = New System.Drawing.Point(195, 10)
        Me.pb_export.Name = "pb_export"
        Me.pb_export.Size = New System.Drawing.Size(526, 16)
        Me.pb_export.TabIndex = 177
        Me.pb_export.Visible = False
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlDfSearch.Controls.Add(Me.lbl_querybuilder)
        Me.PnlDfSearch.Controls.Add(Me.lbl_Clear)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchAdv)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchAdv)
        Me.PnlDfSearch.Controls.Add(Me.cbodate_shoot)
        Me.PnlDfSearch.Controls.Add(Me.Label4)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchItem)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchAppKadiv)
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchApoKadiv2)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchApoKadiv1)
        Me.PnlDfSearch.Controls.Add(Me.cboDateType)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate1)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchDate1)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchStruktur)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchCategory)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchCategory)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchStruktur)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cboReportName)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDfSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(956, 135)
        Me.PnlDfSearch.TabIndex = 0
        '
        'lbl_querybuilder
        '
        Me.lbl_querybuilder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lbl_querybuilder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_querybuilder.Location = New System.Drawing.Point(882, 111)
        Me.lbl_querybuilder.Name = "lbl_querybuilder"
        Me.lbl_querybuilder.Size = New System.Drawing.Size(65, 13)
        Me.lbl_querybuilder.TabIndex = 196
        Me.lbl_querybuilder.Text = "Query Builder"
        Me.lbl_querybuilder.Visible = False
        '
        'lbl_Clear
        '
        Me.lbl_Clear.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lbl_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Clear.Location = New System.Drawing.Point(733, 111)
        Me.lbl_Clear.Name = "lbl_Clear"
        Me.lbl_Clear.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Clear.TabIndex = 195
        Me.lbl_Clear.Text = "Clear"
        Me.lbl_Clear.Visible = False
        '
        'chkSearchAdv
        '
        Me.chkSearchAdv.Location = New System.Drawing.Point(714, 8)
        Me.chkSearchAdv.Name = "chkSearchAdv"
        Me.chkSearchAdv.Properties.Caption = "Adv. Search"
        Me.chkSearchAdv.Size = New System.Drawing.Size(87, 19)
        Me.chkSearchAdv.TabIndex = 194
        Me.chkSearchAdv.Visible = False
        '
        'txtSearchAdv
        '
        Me.txtSearchAdv.Location = New System.Drawing.Point(733, 28)
        Me.txtSearchAdv.Name = "txtSearchAdv"
        Me.txtSearchAdv.Size = New System.Drawing.Size(214, 77)
        Me.txtSearchAdv.TabIndex = 193
        Me.txtSearchAdv.Visible = False
        '
        'cbodate_shoot
        '
        Me.cbodate_shoot.AutoSize = True
        Me.cbodate_shoot.Location = New System.Drawing.Point(354, 35)
        Me.cbodate_shoot.Name = "cbodate_shoot"
        Me.cbodate_shoot.Size = New System.Drawing.Size(49, 17)
        Me.cbodate_shoot.TabIndex = 192
        Me.cbodate_shoot.Text = "Date"
        Me.cbodate_shoot.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "Item Name"
        '
        'cboSearchItem
        '
        Me.cboSearchItem.FormattingEnabled = True
        Me.cboSearchItem.Location = New System.Drawing.Point(137, 99)
        Me.cboSearchItem.Name = "cboSearchItem"
        Me.cboSearchItem.Size = New System.Drawing.Size(201, 21)
        Me.cboSearchItem.TabIndex = 190
        '
        'chkSearchAppKadiv
        '
        Me.chkSearchAppKadiv.AutoSize = True
        Me.chkSearchAppKadiv.Location = New System.Drawing.Point(11, 30)
        Me.chkSearchAppKadiv.Name = "chkSearchAppKadiv"
        Me.chkSearchAppKadiv.Size = New System.Drawing.Size(115, 17)
        Me.chkSearchAppKadiv.TabIndex = 188
        Me.chkSearchAppKadiv.Text = "Approval by Kadiv."
        Me.chkSearchAppKadiv.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 187
        Me.Label2.Text = "Approval Date End"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Approval Date Start"
        '
        'dtpSearchApoKadiv2
        '
        Me.dtpSearchApoKadiv2.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchApoKadiv2.Enabled = False
        Me.dtpSearchApoKadiv2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchApoKadiv2.Location = New System.Drawing.Point(137, 74)
        Me.dtpSearchApoKadiv2.Name = "dtpSearchApoKadiv2"
        Me.dtpSearchApoKadiv2.Size = New System.Drawing.Size(96, 20)
        Me.dtpSearchApoKadiv2.TabIndex = 185
        '
        'dtpSearchApoKadiv1
        '
        Me.dtpSearchApoKadiv1.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchApoKadiv1.Enabled = False
        Me.dtpSearchApoKadiv1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchApoKadiv1.Location = New System.Drawing.Point(137, 50)
        Me.dtpSearchApoKadiv1.Name = "dtpSearchApoKadiv1"
        Me.dtpSearchApoKadiv1.Size = New System.Drawing.Size(96, 20)
        Me.dtpSearchApoKadiv1.TabIndex = 184
        '
        'cboDateType
        '
        Me.cboDateType.Enabled = False
        Me.cboDateType.FormattingEnabled = True
        Me.cboDateType.Items.AddRange(New Object() {"By Utilizing/Shooting Date"})
        Me.cboDateType.Location = New System.Drawing.Point(436, 33)
        Me.cboDateType.MaxDropDownItems = 12
        Me.cboDateType.Name = "cboDateType"
        Me.cboDateType.Size = New System.Drawing.Size(267, 21)
        Me.cboDateType.TabIndex = 182
        Me.cboDateType.Text = "By Utilizing/Shooting Date"
        '
        'lblSearchDate2
        '
        Me.lblSearchDate2.AutoSize = True
        Me.lblSearchDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDate2.Location = New System.Drawing.Point(560, 60)
        Me.lblSearchDate2.Name = "lblSearchDate2"
        Me.lblSearchDate2.Size = New System.Drawing.Size(52, 13)
        Me.lblSearchDate2.TabIndex = 172
        Me.lblSearchDate2.Text = "End Date"
        Me.lblSearchDate2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSearchDate1
        '
        Me.lblSearchDate1.AutoSize = True
        Me.lblSearchDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDate1.Location = New System.Drawing.Point(351, 60)
        Me.lblSearchDate1.Name = "lblSearchDate1"
        Me.lblSearchDate1.Size = New System.Drawing.Size(55, 13)
        Me.lblSearchDate1.TabIndex = 171
        Me.lblSearchDate1.Text = "Start Date"
        '
        'dtpSearchDate2
        '
        Me.dtpSearchDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate2.Location = New System.Drawing.Point(618, 57)
        Me.dtpSearchDate2.Name = "dtpSearchDate2"
        Me.dtpSearchDate2.Size = New System.Drawing.Size(85, 20)
        Me.dtpSearchDate2.TabIndex = 12
        '
        'dtpSearchDate1
        '
        Me.dtpSearchDate1.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate1.Location = New System.Drawing.Point(436, 57)
        Me.dtpSearchDate1.Name = "dtpSearchDate1"
        Me.dtpSearchDate1.Size = New System.Drawing.Size(96, 20)
        Me.dtpSearchDate1.TabIndex = 11
        '
        'cboSearchStruktur
        '
        Me.cboSearchStruktur.FormattingEnabled = True
        Me.cboSearchStruktur.Location = New System.Drawing.Point(436, 105)
        Me.cboSearchStruktur.Name = "cboSearchStruktur"
        Me.cboSearchStruktur.Size = New System.Drawing.Size(267, 21)
        Me.cboSearchStruktur.TabIndex = 4
        '
        'chkSearchCategory
        '
        Me.chkSearchCategory.AutoSize = True
        Me.chkSearchCategory.Location = New System.Drawing.Point(354, 82)
        Me.chkSearchCategory.Name = "chkSearchCategory"
        Me.chkSearchCategory.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchCategory.TabIndex = 7
        Me.chkSearchCategory.Text = "Budget"
        Me.chkSearchCategory.UseVisualStyleBackColor = True
        '
        'cboSearchCategory
        '
        Me.cboSearchCategory.FormattingEnabled = True
        Me.cboSearchCategory.Location = New System.Drawing.Point(436, 81)
        Me.cboSearchCategory.Name = "cboSearchCategory"
        Me.cboSearchCategory.Size = New System.Drawing.Size(267, 21)
        Me.cboSearchCategory.TabIndex = 8
        '
        'chkSearchStruktur
        '
        Me.chkSearchStruktur.AutoSize = True
        Me.chkSearchStruktur.Location = New System.Drawing.Point(354, 107)
        Me.chkSearchStruktur.Name = "chkSearchStruktur"
        Me.chkSearchStruktur.Size = New System.Drawing.Size(81, 17)
        Me.chkSearchStruktur.TabIndex = 3
        Me.chkSearchStruktur.Text = "Department"
        Me.chkSearchStruktur.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(351, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Report Name"
        '
        'cboReportName
        '
        Me.cboReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(436, 6)
        Me.cboReportName.MaxDropDownItems = 12
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(267, 21)
        Me.cboReportName.TabIndex = 2
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.Enabled = False
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(137, 6)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(201, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(11, 9)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "http://insosys_start.trans7.co.id/ema.chm"
        '
        'uiRequestExpView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiRequestExpView"
        Me.Size = New System.Drawing.Size(972, 548)
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvToExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        CType(Me.chkSearchAdv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearchAdv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlatTabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblSearchDate2 As System.Windows.Forms.Label
    Friend WithEvents lblSearchDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSearchDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSearchStruktur As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchCategory As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchCategory As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchStruktur As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents pb_export As System.Windows.Forms.ProgressBar
    Friend WithEvents lb_export As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cboDateType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvToExport As System.Windows.Forms.DataGridView
    Friend WithEvents chkSearchAppKadiv As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchApoKadiv2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSearchApoKadiv1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSearchItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbodate_shoot As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_querybuilder As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Clear As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSearchAdv As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSearchAdv As DevExpress.XtraEditors.MemoEdit

End Class
