<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiROReportViewer
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
        Me.FlatTabMain = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.dtpHiddenDate2 = New System.Windows.Forms.DateTimePicker
        Me.dtpSearchAccrDate = New System.Windows.Forms.DateTimePicker
        Me.lblLocation = New System.Windows.Forms.Label
        Me.lboSearchLocation = New System.Windows.Forms.ListBox
        Me.chkSearchLocation = New System.Windows.Forms.CheckBox
        Me.txtSearchYear = New System.Windows.Forms.TextBox
        Me.lblSearchDate2 = New System.Windows.Forms.Label
        Me.txtSearchPeriode = New System.Windows.Forms.TextBox
        Me.lblSearchDate1 = New System.Windows.Forms.Label
        Me.dtpSearchDate2 = New System.Windows.Forms.DateTimePicker
        Me.dtpSearchDate1 = New System.Windows.Forms.DateTimePicker
        Me.cboSearchRekanan = New System.Windows.Forms.ComboBox
        Me.txtSearchBudget = New System.Windows.Forms.TextBox
        Me.chkSearchCategory = New System.Windows.Forms.CheckBox
        Me.cboSearchCategory = New System.Windows.Forms.ComboBox
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox
        Me.chkSearchBudget = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboReportName = New System.Windows.Forms.ComboBox
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.lblReportType = New System.Windows.Forms.Label
        Me.chkAccruedDate = New System.Windows.Forms.CheckBox
        Me.FlatTabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlatTabMain
        '
        Me.FlatTabMain.Controls.Add(Me.TabPage1)
        Me.FlatTabMain.Location = New System.Drawing.Point(3, 28)
        Me.FlatTabMain.Name = "FlatTabMain"
        Me.FlatTabMain.SelectedIndex = 0
        Me.FlatTabMain.Size = New System.Drawing.Size(747, 517)
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
        Me.TabPage1.Size = New System.Drawing.Size(739, 491)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report Viewer"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ReportViewer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 159)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(733, 329)
        Me.Panel3.TabIndex = 3
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(733, 329)
        Me.ReportViewer1.TabIndex = 3
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.PapayaWhip
        Me.PnlDfSearch.Controls.Add(Me.chkAccruedDate)
        Me.PnlDfSearch.Controls.Add(Me.dtpHiddenDate2)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchAccrDate)
        Me.PnlDfSearch.Controls.Add(Me.lblLocation)
        Me.PnlDfSearch.Controls.Add(Me.lboSearchLocation)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchLocation)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchYear)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchPeriode)
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
        Me.PnlDfSearch.Controls.Add(Me.lblReportType)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 156)
        Me.PnlDfSearch.TabIndex = 0
        '
        'dtpHiddenDate2
        '
        Me.dtpHiddenDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpHiddenDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHiddenDate2.Location = New System.Drawing.Point(599, 55)
        Me.dtpHiddenDate2.Name = "dtpHiddenDate2"
        Me.dtpHiddenDate2.Size = New System.Drawing.Size(106, 20)
        Me.dtpHiddenDate2.TabIndex = 184
        Me.dtpHiddenDate2.Visible = False
        '
        'dtpSearchAccrDate
        '
        Me.dtpSearchAccrDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchAccrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchAccrDate.Location = New System.Drawing.Point(411, 55)
        Me.dtpSearchAccrDate.Name = "dtpSearchAccrDate"
        Me.dtpSearchAccrDate.Size = New System.Drawing.Size(106, 20)
        Me.dtpSearchAccrDate.TabIndex = 182
        '
        'lblLocation
        '
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(291, 103)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(114, 44)
        Me.lblLocation.TabIndex = 175
        Me.lblLocation.Text = "Use Shift Key or Alt Key to select more than one Locations"
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.lblLocation.Visible = False
        '
        'lboSearchLocation
        '
        Me.lboSearchLocation.FormattingEnabled = True
        Me.lboSearchLocation.Location = New System.Drawing.Point(411, 78)
        Me.lboSearchLocation.Name = "lboSearchLocation"
        Me.lboSearchLocation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lboSearchLocation.Size = New System.Drawing.Size(293, 69)
        Me.lboSearchLocation.TabIndex = 14
        '
        'chkSearchLocation
        '
        Me.chkSearchLocation.AutoSize = True
        Me.chkSearchLocation.Location = New System.Drawing.Point(292, 79)
        Me.chkSearchLocation.Name = "chkSearchLocation"
        Me.chkSearchLocation.Size = New System.Drawing.Size(112, 17)
        Me.chkSearchLocation.TabIndex = 13
        Me.chkSearchLocation.Text = "Shooting Location"
        Me.chkSearchLocation.UseVisualStyleBackColor = True
        '
        'txtSearchYear
        '
        Me.txtSearchYear.Location = New System.Drawing.Point(411, 32)
        Me.txtSearchYear.MaxLength = 4
        Me.txtSearchYear.Name = "txtSearchYear"
        Me.txtSearchYear.Size = New System.Drawing.Size(106, 20)
        Me.txtSearchYear.TabIndex = 9
        '
        'lblSearchDate2
        '
        Me.lblSearchDate2.AutoSize = True
        Me.lblSearchDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDate2.Location = New System.Drawing.Point(554, 35)
        Me.lblSearchDate2.Name = "lblSearchDate2"
        Me.lblSearchDate2.Size = New System.Drawing.Size(20, 13)
        Me.lblSearchDate2.TabIndex = 172
        Me.lblSearchDate2.Text = "To"
        '
        'txtSearchPeriode
        '
        Me.txtSearchPeriode.Location = New System.Drawing.Point(411, 32)
        Me.txtSearchPeriode.MaxLength = 4
        Me.txtSearchPeriode.Name = "txtSearchPeriode"
        Me.txtSearchPeriode.Size = New System.Drawing.Size(106, 20)
        Me.txtSearchPeriode.TabIndex = 10
        '
        'lblSearchDate1
        '
        Me.lblSearchDate1.AutoSize = True
        Me.lblSearchDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDate1.Location = New System.Drawing.Point(289, 35)
        Me.lblSearchDate1.Name = "lblSearchDate1"
        Me.lblSearchDate1.Size = New System.Drawing.Size(104, 13)
        Me.lblSearchDate1.TabIndex = 171
        Me.lblSearchDate1.Text = "'Shooting Start' From"
        '
        'dtpSearchDate2
        '
        Me.dtpSearchDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate2.Location = New System.Drawing.Point(599, 32)
        Me.dtpSearchDate2.Name = "dtpSearchDate2"
        Me.dtpSearchDate2.Size = New System.Drawing.Size(106, 20)
        Me.dtpSearchDate2.TabIndex = 12
        '
        'dtpSearchDate1
        '
        Me.dtpSearchDate1.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate1.Location = New System.Drawing.Point(411, 32)
        Me.dtpSearchDate1.Name = "dtpSearchDate1"
        Me.dtpSearchDate1.Size = New System.Drawing.Size(106, 20)
        Me.dtpSearchDate1.TabIndex = 11
        '
        'cboSearchRekanan
        '
        Me.cboSearchRekanan.FormattingEnabled = True
        Me.cboSearchRekanan.Location = New System.Drawing.Point(110, 32)
        Me.cboSearchRekanan.Name = "cboSearchRekanan"
        Me.cboSearchRekanan.Size = New System.Drawing.Size(158, 21)
        Me.cboSearchRekanan.TabIndex = 4
        '
        'txtSearchBudget
        '
        Me.txtSearchBudget.Location = New System.Drawing.Point(110, 55)
        Me.txtSearchBudget.MaxLength = 4
        Me.txtSearchBudget.Name = "txtSearchBudget"
        Me.txtSearchBudget.Size = New System.Drawing.Size(158, 20)
        Me.txtSearchBudget.TabIndex = 6
        '
        'chkSearchCategory
        '
        Me.chkSearchCategory.AutoSize = True
        Me.chkSearchCategory.Location = New System.Drawing.Point(27, 79)
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
        Me.cboSearchCategory.Location = New System.Drawing.Point(110, 77)
        Me.cboSearchCategory.Name = "cboSearchCategory"
        Me.cboSearchCategory.Size = New System.Drawing.Size(158, 21)
        Me.cboSearchCategory.TabIndex = 8
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(27, 34)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchRekanan.TabIndex = 3
        Me.chkSearchRekanan.Text = "Vendor"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
        '
        'chkSearchBudget
        '
        Me.chkSearchBudget.AutoSize = True
        Me.chkSearchBudget.Location = New System.Drawing.Point(27, 56)
        Me.chkSearchBudget.Name = "chkSearchBudget"
        Me.chkSearchBudget.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchBudget.TabIndex = 5
        Me.chkSearchBudget.Text = "Budget"
        Me.chkSearchBudget.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(289, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Report Name"
        '
        'cboReportName
        '
        Me.cboReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(411, 9)
        Me.cboReportName.MaxDropDownItems = 12
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(294, 21)
        Me.cboReportName.TabIndex = 2
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.Enabled = False
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(110, 9)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(158, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(27, 11)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'lblReportType
        '
        Me.lblReportType.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblReportType.ForeColor = System.Drawing.Color.Maroon
        Me.lblReportType.Location = New System.Drawing.Point(3, 127)
        Me.lblReportType.Name = "lblReportType"
        Me.lblReportType.Size = New System.Drawing.Size(282, 20)
        Me.lblReportType.TabIndex = 116
        Me.lblReportType.Text = "lblReportType"
        Me.lblReportType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAccruedDate
        '
        Me.chkAccruedDate.AutoSize = True
        Me.chkAccruedDate.Location = New System.Drawing.Point(292, 58)
        Me.chkAccruedDate.Name = "chkAccruedDate"
        Me.chkAccruedDate.Size = New System.Drawing.Size(92, 17)
        Me.chkAccruedDate.TabIndex = 185
        Me.chkAccruedDate.Text = "Accrued Date"
        Me.chkAccruedDate.UseVisualStyleBackColor = True
        '
        'uiROReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.Name = "uiROReportViewer"
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlatTabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents lblReportType As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lboSearchLocation As System.Windows.Forms.ListBox
    Friend WithEvents chkSearchLocation As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchYear As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchDate2 As System.Windows.Forms.Label
    Friend WithEvents txtSearchPeriode As System.Windows.Forms.TextBox
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
    Friend WithEvents dtpSearchAccrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHiddenDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkAccruedDate As System.Windows.Forms.CheckBox

End Class
