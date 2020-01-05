<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiOrderExpView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiOrderExpView))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FlatTabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvToExport = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.lbl_querybuilder = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Clear = New DevExpress.XtraEditors.LabelControl()
        Me.chkSearchAdv = New DevExpress.XtraEditors.CheckEdit()
        Me.txtSearchAdv = New DevExpress.XtraEditors.MemoEdit()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblDateType = New System.Windows.Forms.Label()
        Me.cboDateType = New System.Windows.Forms.ComboBox()
        Me.lboSearchLocation = New System.Windows.Forms.ListBox()
        Me.dtpHiddenDate2 = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchAccrDate = New System.Windows.Forms.Label()
        Me.dtpSearchAccrDate = New System.Windows.Forms.DateTimePicker()
        Me.chkSearchLocation = New System.Windows.Forms.CheckBox()
        Me.lblSearchDate2 = New System.Windows.Forms.Label()
        Me.lblSearchDate1 = New System.Windows.Forms.Label()
        Me.dtpSearchDate2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpSearchDate1 = New System.Windows.Forms.DateTimePicker()
        Me.cboSearchRekanan = New System.Windows.Forms.ComboBox()
        Me.txtSearchBudget = New System.Windows.Forms.TextBox()
        Me.chkSearchCategory = New System.Windows.Forms.CheckBox()
        Me.cboSearchCategory = New System.Windows.Forms.ComboBox()
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox()
        Me.chkSearchBudget = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboReportName = New System.Windows.Forms.ComboBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.lblLocationInfo = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
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
        Me.FlatTabMain.Size = New System.Drawing.Size(996, 517)
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
        Me.TabPage1.Size = New System.Drawing.Size(988, 491)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report Viewer"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 132)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(982, 356)
        Me.Panel3.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvToExport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(982, 321)
        Me.Panel2.TabIndex = 179
        '
        'dgvToExport
        '
        Me.dgvToExport.AllowUserToAddRows = False
        Me.dgvToExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvToExport.Location = New System.Drawing.Point(0, 0)
        Me.dgvToExport.Name = "dgvToExport"
        Me.dgvToExport.ReadOnly = True
        Me.dgvToExport.Size = New System.Drawing.Size(982, 321)
        Me.dgvToExport.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblProgress)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 321)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(982, 35)
        Me.Panel1.TabIndex = 178
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.DarkRed
        Me.lblProgress.Location = New System.Drawing.Point(13, 10)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(163, 13)
        Me.lblProgress.TabIndex = 176
        Me.lblProgress.Text = "Exporting 0 of 0 records"
        Me.lblProgress.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ProgressBar1.Location = New System.Drawing.Point(195, 10)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(526, 16)
        Me.ProgressBar1.TabIndex = 177
        Me.ProgressBar1.Visible = False
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlDfSearch.Controls.Add(Me.lbl_querybuilder)
        Me.PnlDfSearch.Controls.Add(Me.lbl_Clear)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchAdv)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchAdv)
        Me.PnlDfSearch.Controls.Add(Me.Button1)
        Me.PnlDfSearch.Controls.Add(Me.lblDateType)
        Me.PnlDfSearch.Controls.Add(Me.cboDateType)
        Me.PnlDfSearch.Controls.Add(Me.lboSearchLocation)
        Me.PnlDfSearch.Controls.Add(Me.dtpHiddenDate2)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchAccrDate)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchAccrDate)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchLocation)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate1)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchDate1)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchBudget)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchCategory)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchCategory)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchBudget)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cboReportName)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.lblLocationInfo)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDfSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(982, 129)
        Me.PnlDfSearch.TabIndex = 0
        '
        'lbl_querybuilder
        '
        Me.lbl_querybuilder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lbl_querybuilder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_querybuilder.Location = New System.Drawing.Point(896, 109)
        Me.lbl_querybuilder.Name = "lbl_querybuilder"
        Me.lbl_querybuilder.Size = New System.Drawing.Size(65, 13)
        Me.lbl_querybuilder.TabIndex = 200
        Me.lbl_querybuilder.Text = "Query Builder"
        '
        'lbl_Clear
        '
        Me.lbl_Clear.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lbl_Clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Clear.Location = New System.Drawing.Point(747, 109)
        Me.lbl_Clear.Name = "lbl_Clear"
        Me.lbl_Clear.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Clear.TabIndex = 199
        Me.lbl_Clear.Text = "Clear"
        '
        'chkSearchAdv
        '
        Me.chkSearchAdv.Location = New System.Drawing.Point(728, 6)
        Me.chkSearchAdv.Name = "chkSearchAdv"
        Me.chkSearchAdv.Properties.Caption = "Adv. Search"
        Me.chkSearchAdv.Size = New System.Drawing.Size(87, 19)
        Me.chkSearchAdv.TabIndex = 198
        '
        'txtSearchAdv
        '
        Me.txtSearchAdv.Location = New System.Drawing.Point(747, 26)
        Me.txtSearchAdv.Name = "txtSearchAdv"
        Me.txtSearchAdv.Size = New System.Drawing.Size(214, 77)
        Me.txtSearchAdv.TabIndex = 197
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(711, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 22)
        Me.Button1.TabIndex = 184
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lblDateType
        '
        Me.lblDateType.AutoSize = True
        Me.lblDateType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateType.Location = New System.Drawing.Point(353, 56)
        Me.lblDateType.Name = "lblDateType"
        Me.lblDateType.Size = New System.Drawing.Size(57, 13)
        Me.lblDateType.TabIndex = 183
        Me.lblDateType.Text = "Date Type"
        '
        'cboDateType
        '
        Me.cboDateType.FormattingEnabled = True
        Me.cboDateType.Items.AddRange(New Object() {"By Order Date", "By Utilizing/Shooting Date"})
        Me.cboDateType.Location = New System.Drawing.Point(438, 52)
        Me.cboDateType.MaxDropDownItems = 12
        Me.cboDateType.Name = "cboDateType"
        Me.cboDateType.Size = New System.Drawing.Size(267, 21)
        Me.cboDateType.TabIndex = 182
        Me.cboDateType.Text = "By Order Date"
        '
        'lboSearchLocation
        '
        Me.lboSearchLocation.FormattingEnabled = True
        Me.lboSearchLocation.Location = New System.Drawing.Point(143, 52)
        Me.lboSearchLocation.Name = "lboSearchLocation"
        Me.lboSearchLocation.Size = New System.Drawing.Size(201, 69)
        Me.lboSearchLocation.TabIndex = 181
        '
        'dtpHiddenDate2
        '
        Me.dtpHiddenDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpHiddenDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHiddenDate2.Location = New System.Drawing.Point(24, 73)
        Me.dtpHiddenDate2.Name = "dtpHiddenDate2"
        Me.dtpHiddenDate2.Size = New System.Drawing.Size(85, 20)
        Me.dtpHiddenDate2.TabIndex = 180
        Me.dtpHiddenDate2.Visible = False
        '
        'lblSearchAccrDate
        '
        Me.lblSearchAccrDate.AutoSize = True
        Me.lblSearchAccrDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchAccrDate.Location = New System.Drawing.Point(541, 79)
        Me.lblSearchAccrDate.Name = "lblSearchAccrDate"
        Me.lblSearchAccrDate.Size = New System.Drawing.Size(73, 13)
        Me.lblSearchAccrDate.TabIndex = 179
        Me.lblSearchAccrDate.Text = "Accrued Date"
        '
        'dtpSearchAccrDate
        '
        Me.dtpSearchAccrDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchAccrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchAccrDate.Location = New System.Drawing.Point(620, 76)
        Me.dtpSearchAccrDate.Name = "dtpSearchAccrDate"
        Me.dtpSearchAccrDate.Size = New System.Drawing.Size(85, 20)
        Me.dtpSearchAccrDate.TabIndex = 178
        '
        'chkSearchLocation
        '
        Me.chkSearchLocation.AutoSize = True
        Me.chkSearchLocation.Location = New System.Drawing.Point(27, 55)
        Me.chkSearchLocation.Name = "chkSearchLocation"
        Me.chkSearchLocation.Size = New System.Drawing.Size(92, 17)
        Me.chkSearchLocation.TabIndex = 13
        Me.chkSearchLocation.Text = "Shooting Loc."
        Me.chkSearchLocation.UseVisualStyleBackColor = True
        '
        'lblSearchDate2
        '
        Me.lblSearchDate2.AutoSize = True
        Me.lblSearchDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDate2.Location = New System.Drawing.Point(562, 33)
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
        Me.lblSearchDate1.Location = New System.Drawing.Point(353, 33)
        Me.lblSearchDate1.Name = "lblSearchDate1"
        Me.lblSearchDate1.Size = New System.Drawing.Size(55, 13)
        Me.lblSearchDate1.TabIndex = 171
        Me.lblSearchDate1.Text = "Start Date"
        '
        'dtpSearchDate2
        '
        Me.dtpSearchDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate2.Location = New System.Drawing.Point(620, 29)
        Me.dtpSearchDate2.Name = "dtpSearchDate2"
        Me.dtpSearchDate2.Size = New System.Drawing.Size(85, 20)
        Me.dtpSearchDate2.TabIndex = 12
        '
        'dtpSearchDate1
        '
        Me.dtpSearchDate1.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate1.Location = New System.Drawing.Point(438, 29)
        Me.dtpSearchDate1.Name = "dtpSearchDate1"
        Me.dtpSearchDate1.Size = New System.Drawing.Size(96, 20)
        Me.dtpSearchDate1.TabIndex = 11
        '
        'cboSearchRekanan
        '
        Me.cboSearchRekanan.FormattingEnabled = True
        Me.cboSearchRekanan.Location = New System.Drawing.Point(438, 99)
        Me.cboSearchRekanan.Name = "cboSearchRekanan"
        Me.cboSearchRekanan.Size = New System.Drawing.Size(267, 21)
        Me.cboSearchRekanan.TabIndex = 4
        '
        'txtSearchBudget
        '
        Me.txtSearchBudget.Location = New System.Drawing.Point(438, 76)
        Me.txtSearchBudget.MaxLength = 8
        Me.txtSearchBudget.Name = "txtSearchBudget"
        Me.txtSearchBudget.Size = New System.Drawing.Size(96, 20)
        Me.txtSearchBudget.TabIndex = 6
        '
        'chkSearchCategory
        '
        Me.chkSearchCategory.AutoSize = True
        Me.chkSearchCategory.Location = New System.Drawing.Point(27, 33)
        Me.chkSearchCategory.Name = "chkSearchCategory"
        Me.chkSearchCategory.Size = New System.Drawing.Size(68, 17)
        Me.chkSearchCategory.TabIndex = 7
        Me.chkSearchCategory.Text = "Category"
        Me.chkSearchCategory.UseVisualStyleBackColor = True
        '
        'cboSearchCategory
        '
        Me.cboSearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchCategory.FormattingEnabled = True
        Me.cboSearchCategory.Location = New System.Drawing.Point(143, 29)
        Me.cboSearchCategory.Name = "cboSearchCategory"
        Me.cboSearchCategory.Size = New System.Drawing.Size(201, 21)
        Me.cboSearchCategory.TabIndex = 8
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(356, 101)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchRekanan.TabIndex = 3
        Me.chkSearchRekanan.Text = "Vendor"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
        '
        'chkSearchBudget
        '
        Me.chkSearchBudget.AutoSize = True
        Me.chkSearchBudget.Location = New System.Drawing.Point(356, 79)
        Me.chkSearchBudget.Name = "chkSearchBudget"
        Me.chkSearchBudget.Size = New System.Drawing.Size(74, 17)
        Me.chkSearchBudget.TabIndex = 5
        Me.chkSearchBudget.Text = "Budget ID"
        Me.chkSearchBudget.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(353, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Report Name"
        '
        'cboReportName
        '
        Me.cboReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(438, 6)
        Me.cboReportName.MaxDropDownItems = 12
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(267, 21)
        Me.cboReportName.TabIndex = 2
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.Enabled = False
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(143, 6)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(201, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(27, 9)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'lblLocationInfo
        '
        Me.lblLocationInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationInfo.Location = New System.Drawing.Point(5, 88)
        Me.lblLocationInfo.Name = "lblLocationInfo"
        Me.lblLocationInfo.Size = New System.Drawing.Size(134, 32)
        Me.lblLocationInfo.TabIndex = 175
        Me.lblLocationInfo.Text = "Use Shift Key or Alt Key to select more than one Locations"
        Me.lblLocationInfo.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "http://insosys_start.trans7.co.id/ema.chm"
        '
        'uiOrderExpView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiOrderExpView"
        Me.Size = New System.Drawing.Size(997, 548)
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
    Friend WithEvents lblLocationInfo As System.Windows.Forms.Label
    Friend WithEvents chkSearchLocation As System.Windows.Forms.CheckBox
    Friend WithEvents lblSearchDate2 As System.Windows.Forms.Label
    Friend WithEvents lblSearchDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSearchDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSearchRekanan As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchBudget As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchCategory As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchCategory As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchBudget As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents lblSearchAccrDate As System.Windows.Forms.Label
    Friend WithEvents dtpSearchAccrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHiddenDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents lboSearchLocation As System.Windows.Forms.ListBox
    Friend WithEvents cboDateType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateType As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvToExport As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_querybuilder As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Clear As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSearchAdv As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSearchAdv As DevExpress.XtraEditors.MemoEdit

End Class
