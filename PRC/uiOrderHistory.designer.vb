<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiOrderHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiOrderHistory))
        Me.FlatTabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvToExport = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lb_export = New System.Windows.Forms.Label()
        Me.pb_export = New System.Windows.Forms.ProgressBar()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.Panel4 = New DevExpress.XtraEditors.PanelControl()
        Me.chk_order_id = New DevExpress.XtraEditors.CheckEdit()
        Me.txt_order_id = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New DevExpress.XtraEditors.GroupControl()
        Me.chk_requestdate = New DevExpress.XtraEditors.CheckEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chk_request_id = New DevExpress.XtraEditors.CheckEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_request_id = New System.Windows.Forms.TextBox()
        Me.dtpReqDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpReqDateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboReportName = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        CType(Me.Panel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.chk_order_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.chk_requestdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_request_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
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
        Me.Panel3.Location = New System.Drawing.Point(3, 123)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(733, 365)
        Me.Panel3.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvToExport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(733, 330)
        Me.Panel2.TabIndex = 179
        '
        'dgvToExport
        '
        Me.dgvToExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvToExport.Location = New System.Drawing.Point(0, 0)
        Me.dgvToExport.Name = "dgvToExport"
        Me.dgvToExport.Size = New System.Drawing.Size(733, 330)
        Me.dgvToExport.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lb_export)
        Me.Panel1.Controls.Add(Me.pb_export)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 330)
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
        Me.PnlDfSearch.BackColor = System.Drawing.Color.Honeydew
        Me.PnlDfSearch.Controls.Add(Me.Panel4)
        Me.PnlDfSearch.Controls.Add(Me.TextBox1)
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDfSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 120)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chk_order_id)
        Me.Panel4.Controls.Add(Me.txt_order_id)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.cboReportName)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(733, 120)
        Me.Panel4.TabIndex = 195
        '
        'chk_order_id
        '
        Me.chk_order_id.Location = New System.Drawing.Point(21, 61)
        Me.chk_order_id.Name = "chk_order_id"
        Me.chk_order_id.Properties.Caption = "Order ID"
        Me.chk_order_id.Size = New System.Drawing.Size(75, 19)
        Me.chk_order_id.TabIndex = 198
        '
        'txt_order_id
        '
        Me.txt_order_id.Location = New System.Drawing.Point(121, 60)
        Me.txt_order_id.Name = "txt_order_id"
        Me.txt_order_id.Size = New System.Drawing.Size(153, 20)
        Me.txt_order_id.TabIndex = 195
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_requestdate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chk_request_id)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_request_id)
        Me.GroupBox1.Controls.Add(Me.dtpReqDateEnd)
        Me.GroupBox1.Controls.Add(Me.dtpReqDateStart)
        Me.GroupBox1.Location = New System.Drawing.Point(350, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 110)
        Me.GroupBox1.TabIndex = 197
        Me.GroupBox1.Text = "Request Filter"
        '
        'chk_requestdate
        '
        Me.chk_requestdate.Location = New System.Drawing.Point(12, 55)
        Me.chk_requestdate.Name = "chk_requestdate"
        Me.chk_requestdate.Properties.Caption = "Request Date"
        Me.chk_requestdate.Size = New System.Drawing.Size(98, 19)
        Me.chk_requestdate.TabIndex = 199
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "Start Date"
        '
        'chk_request_id
        '
        Me.chk_request_id.Location = New System.Drawing.Point(12, 32)
        Me.chk_request_id.Name = "chk_request_id"
        Me.chk_request_id.Properties.Caption = "Request ID"
        Me.chk_request_id.Size = New System.Drawing.Size(75, 19)
        Me.chk_request_id.TabIndex = 199
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_request_id
        '
        Me.txt_request_id.Location = New System.Drawing.Point(150, 32)
        Me.txt_request_id.Name = "txt_request_id"
        Me.txt_request_id.Size = New System.Drawing.Size(153, 20)
        Me.txt_request_id.TabIndex = 196
        '
        'dtpReqDateEnd
        '
        Me.dtpReqDateEnd.CustomFormat = "dd/MM/yyyy"
        Me.dtpReqDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReqDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReqDateEnd.Location = New System.Drawing.Point(284, 82)
        Me.dtpReqDateEnd.Name = "dtpReqDateEnd"
        Me.dtpReqDateEnd.Size = New System.Drawing.Size(85, 21)
        Me.dtpReqDateEnd.TabIndex = 12
        '
        'dtpReqDateStart
        '
        Me.dtpReqDateStart.CustomFormat = "dd/MM/yyyy"
        Me.dtpReqDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReqDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReqDateStart.Location = New System.Drawing.Point(114, 82)
        Me.dtpReqDateStart.Name = "dtpReqDateStart"
        Me.dtpReqDateStart.Size = New System.Drawing.Size(96, 21)
        Me.dtpReqDateStart.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 170
        Me.Label6.Text = "Report Name"
        '
        'cboReportName
        '
        Me.cboReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(121, 35)
        Me.cboReportName.MaxDropDownItems = 12
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(201, 21)
        Me.cboReportName.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(536, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 194
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(442, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 193
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Report Name"
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.Enabled = False
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(109, 5)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(201, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(11, 7)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Company"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "http://insosys_start.trans7.co.id/ema.chm"
        '
        'uiOrderHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.DSNFiles = resources.GetString("$this.DSNFiles")
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "uiOrderHistory"
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvToExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        CType(Me.Panel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.chk_order_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.chk_requestdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_request_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlatTabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pb_export As System.Windows.Forms.ProgressBar
    Friend WithEvents lb_export As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvToExport As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents txt_request_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_order_id As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpReqDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReqDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupBox1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chk_order_id As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chk_requestdate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chk_request_id As DevExpress.XtraEditors.CheckEdit

End Class
