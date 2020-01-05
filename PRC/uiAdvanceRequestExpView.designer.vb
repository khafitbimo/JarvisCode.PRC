<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiAdvanceRequestExpView
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvToExport = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lb_export = New System.Windows.Forms.Label
        Me.pb_export = New System.Windows.Forms.ProgressBar
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.cbodate_shoot = New System.Windows.Forms.CheckBox
        Me.lblSearchDate2 = New System.Windows.Forms.Label
        Me.lblSearchDate1 = New System.Windows.Forms.Label
        Me.dtpSearchDate2 = New System.Windows.Forms.DateTimePicker
        Me.dtpSearchDate1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboReportName = New System.Windows.Forms.ComboBox
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.txtSearchRequestID = New System.Windows.Forms.TextBox
        Me.chkSearchRequestID = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.FlatTabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvToExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(733, 388)
        Me.Panel3.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvToExport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(733, 353)
        Me.Panel2.TabIndex = 179
        '
        'dgvToExport
        '
        Me.dgvToExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvToExport.Location = New System.Drawing.Point(0, 0)
        Me.dgvToExport.Name = "dgvToExport"
        Me.dgvToExport.Size = New System.Drawing.Size(733, 353)
        Me.dgvToExport.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lb_export)
        Me.Panel1.Controls.Add(Me.pb_export)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 353)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 35)
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
        Me.PnlDfSearch.BackColor = System.Drawing.Color.LightCyan
        Me.PnlDfSearch.Controls.Add(Me.Label5)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchRequestID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRequestID)
        Me.PnlDfSearch.Controls.Add(Me.cbodate_shoot)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.lblSearchDate1)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchDate2)
        Me.PnlDfSearch.Controls.Add(Me.dtpSearchDate1)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cboReportName)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDfSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 97)
        Me.PnlDfSearch.TabIndex = 0
        '
        'cbodate_shoot
        '
        Me.cbodate_shoot.AutoSize = True
        Me.cbodate_shoot.Location = New System.Drawing.Point(373, 31)
        Me.cbodate_shoot.Name = "cbodate_shoot"
        Me.cbodate_shoot.Size = New System.Drawing.Size(49, 17)
        Me.cbodate_shoot.TabIndex = 192
        Me.cbodate_shoot.Text = "Date"
        Me.cbodate_shoot.UseVisualStyleBackColor = True
        '
        'lblSearchDate2
        '
        Me.lblSearchDate2.AutoSize = True
        Me.lblSearchDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDate2.Location = New System.Drawing.Point(579, 56)
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
        Me.lblSearchDate1.Location = New System.Drawing.Point(370, 56)
        Me.lblSearchDate1.Name = "lblSearchDate1"
        Me.lblSearchDate1.Size = New System.Drawing.Size(55, 13)
        Me.lblSearchDate1.TabIndex = 171
        Me.lblSearchDate1.Text = "Start Date"
        '
        'dtpSearchDate2
        '
        Me.dtpSearchDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate2.Location = New System.Drawing.Point(637, 53)
        Me.dtpSearchDate2.Name = "dtpSearchDate2"
        Me.dtpSearchDate2.Size = New System.Drawing.Size(85, 20)
        Me.dtpSearchDate2.TabIndex = 12
        '
        'dtpSearchDate1
        '
        Me.dtpSearchDate1.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDate1.Location = New System.Drawing.Point(455, 53)
        Me.dtpSearchDate1.Name = "dtpSearchDate1"
        Me.dtpSearchDate1.Size = New System.Drawing.Size(83, 20)
        Me.dtpSearchDate1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(370, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Report Name"
        '
        'cboReportName
        '
        Me.cboReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(455, 6)
        Me.cboReportName.MaxDropDownItems = 12
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(267, 21)
        Me.cboReportName.TabIndex = 2
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.Enabled = False
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(93, 6)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(83, 21)
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
        'txtSearchRequestID
        '
        Me.txtSearchRequestID.Location = New System.Drawing.Point(93, 33)
        Me.txtSearchRequestID.Multiline = True
        Me.txtSearchRequestID.Name = "txtSearchRequestID"
        Me.txtSearchRequestID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchRequestID.Size = New System.Drawing.Size(250, 45)
        Me.txtSearchRequestID.TabIndex = 194
        '
        'chkSearchRequestID
        '
        Me.chkSearchRequestID.AutoSize = True
        Me.chkSearchRequestID.Location = New System.Drawing.Point(11, 35)
        Me.chkSearchRequestID.Name = "chkSearchRequestID"
        Me.chkSearchRequestID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchRequestID.TabIndex = 193
        Me.chkSearchRequestID.Text = "ID(s)"
        Me.chkSearchRequestID.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(95, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(263, 12)
        Me.Label5.TabIndex = 195
        Me.Label5.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'uiAdvanceRequestExpView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.Name = "uiAdvanceRequestExpView"
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvToExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents pb_export As System.Windows.Forms.ProgressBar
    Friend WithEvents lb_export As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvToExport As System.Windows.Forms.DataGridView
    Friend WithEvents cbodate_shoot As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtSearchRequestID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchRequestID As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
