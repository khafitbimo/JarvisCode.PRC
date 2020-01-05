<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class hapus_uiOrderComplete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(hapus_uiOrderComplete))
        Me.FlatTabMain = New FlatTabControl.FlatTabControl()
        Me.fTabList = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DgvOrderComplete = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.obj_ordertype_search = New System.Windows.Forms.ComboBox()
        Me.chk_ordertype_search = New System.Windows.Forms.CheckBox()
        Me.rekananidtxt = New System.Windows.Forms.TextBox()
        Me.btnVendor = New System.Windows.Forms.Button()
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox()
        Me.obj_status_search = New System.Windows.Forms.ComboBox()
        Me.chk_status_search = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSearchOrderID = New System.Windows.Forms.TextBox()
        Me.chkSearchOrderID = New System.Windows.Forms.CheckBox()
        Me.fTabData = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.fTabDetilMain = New FlatTabControl.FlatTabControl()
        Me.fTabDataNotesProc = New System.Windows.Forms.TabPage()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.dgv_orderdetilproc = New System.Windows.Forms.DataGridView()
        Me.fTabDataDetil = New System.Windows.Forms.TabPage()
        Me.DgvOrderCompleteDetil = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_noteusage = New System.Windows.Forms.DataGridView()
        Me.dgv_orderdetilusage = New System.Windows.Forms.DataGridView()
        Me.obj_enddate = New System.Windows.Forms.DateTimePicker()
        Me.obj_startdate = New System.Windows.Forms.DateTimePicker()
        Me.obj_setdate = New System.Windows.Forms.DateTimePicker()
        Me.obj_orderdate = New System.Windows.Forms.DateTimePicker()
        Me.obj_department = New System.Windows.Forms.ComboBox()
        Me.obj_rekanan = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.obj_ordertype = New System.Windows.Forms.TextBox()
        Me.obj_programtype = New System.Windows.Forms.TextBox()
        Me.obj_channel = New System.Windows.Forms.TextBox()
        Me.obj_descr = New System.Windows.Forms.TextBox()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.obj_statusdate = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.obj_statusby = New System.Windows.Forms.TextBox()
        Me.obj_status = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.obj_order_id = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlatTabMain.SuspendLayout()
        Me.fTabList.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvOrderComplete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.fTabData.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.fTabDetilMain.SuspendLayout()
        Me.fTabDataNotesProc.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.dgv_orderdetilproc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabDataDetil.SuspendLayout()
        CType(Me.DgvOrderCompleteDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_noteusage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_orderdetilusage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel15.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlatTabMain
        '
        Me.FlatTabMain.Controls.Add(Me.fTabList)
        Me.FlatTabMain.Controls.Add(Me.fTabData)
        Me.FlatTabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlatTabMain.Location = New System.Drawing.Point(0, 25)
        Me.FlatTabMain.myBackColor = System.Drawing.SystemColors.Control
        Me.FlatTabMain.Name = "FlatTabMain"
        Me.FlatTabMain.SelectedIndex = 0
        Me.FlatTabMain.Size = New System.Drawing.Size(753, 523)
        Me.FlatTabMain.TabIndex = 1
        '
        'fTabList
        '
        Me.fTabList.Controls.Add(Me.Panel1)
        Me.fTabList.Controls.Add(Me.Panel3)
        Me.fTabList.Controls.Add(Me.PnlDfSearch)
        Me.fTabList.Location = New System.Drawing.Point(4, 25)
        Me.fTabList.Name = "fTabList"
        Me.fTabList.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabList.Size = New System.Drawing.Size(745, 494)
        Me.fTabList.TabIndex = 0
        Me.fTabList.Text = "List"
        Me.fTabList.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.DgvOrderComplete)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(739, 362)
        Me.Panel1.TabIndex = 0
        '
        'DgvOrderComplete
        '
        Me.DgvOrderComplete.AllowUserToAddRows = False
        Me.DgvOrderComplete.AllowUserToDeleteRows = False
        Me.DgvOrderComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOrderComplete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvOrderComplete.Location = New System.Drawing.Point(0, 0)
        Me.DgvOrderComplete.Name = "DgvOrderComplete"
        Me.DgvOrderComplete.ReadOnly = True
        Me.DgvOrderComplete.Size = New System.Drawing.Size(739, 362)
        Me.DgvOrderComplete.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 452)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(739, 39)
        Me.Panel3.TabIndex = 1
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.obj_ordertype_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_ordertype_search)
        Me.PnlDfSearch.Controls.Add(Me.rekananidtxt)
        Me.PnlDfSearch.Controls.Add(Me.btnVendor)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.obj_status_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_status_search)
        Me.PnlDfSearch.Controls.Add(Me.Label16)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchOrderID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchOrderID)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(739, 87)
        Me.PnlDfSearch.TabIndex = 1
        '
        'obj_ordertype_search
        '
        Me.obj_ordertype_search.FormattingEnabled = True
        Me.obj_ordertype_search.Items.AddRange(New Object() {"RO", "PO", "MO"})
        Me.obj_ordertype_search.Location = New System.Drawing.Point(687, 3)
        Me.obj_ordertype_search.Name = "obj_ordertype_search"
        Me.obj_ordertype_search.Size = New System.Drawing.Size(49, 21)
        Me.obj_ordertype_search.TabIndex = 98
        '
        'chk_ordertype_search
        '
        Me.chk_ordertype_search.AutoSize = True
        Me.chk_ordertype_search.Location = New System.Drawing.Point(602, 4)
        Me.chk_ordertype_search.Name = "chk_ordertype_search"
        Me.chk_ordertype_search.Size = New System.Drawing.Size(79, 17)
        Me.chk_ordertype_search.TabIndex = 97
        Me.chk_ordertype_search.Text = "Order Type"
        Me.chk_ordertype_search.UseVisualStyleBackColor = True
        '
        'rekananidtxt
        '
        Me.rekananidtxt.Location = New System.Drawing.Point(392, 4)
        Me.rekananidtxt.MaxLength = 4
        Me.rekananidtxt.Name = "rekananidtxt"
        Me.rekananidtxt.Size = New System.Drawing.Size(58, 20)
        Me.rekananidtxt.TabIndex = 96
        '
        'btnVendor
        '
        Me.btnVendor.Location = New System.Drawing.Point(456, 4)
        Me.btnVendor.Name = "btnVendor"
        Me.btnVendor.Size = New System.Drawing.Size(30, 20)
        Me.btnVendor.TabIndex = 95
        Me.btnVendor.Text = "..."
        Me.btnVendor.UseVisualStyleBackColor = True
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(319, 6)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(74, 17)
        Me.chkSearchRekanan.TabIndex = 94
        Me.chkSearchRekanan.Text = "Vendor ID"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
        '
        'obj_status_search
        '
        Me.obj_status_search.FormattingEnabled = True
        Me.obj_status_search.Items.AddRange(New Object() {"COMPLETE", "INCOMPLETE"})
        Me.obj_status_search.Location = New System.Drawing.Point(391, 30)
        Me.obj_status_search.Name = "obj_status_search"
        Me.obj_status_search.Size = New System.Drawing.Size(95, 21)
        Me.obj_status_search.TabIndex = 93
        '
        'chk_status_search
        '
        Me.chk_status_search.AutoSize = True
        Me.chk_status_search.Location = New System.Drawing.Point(319, 32)
        Me.chk_status_search.Name = "chk_status_search"
        Me.chk_status_search.Size = New System.Drawing.Size(56, 17)
        Me.chk_status_search.TabIndex = 92
        Me.chk_status_search.Text = "Status"
        Me.chk_status_search.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(50, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(263, 12)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtSearchOrderID
        '
        Me.txtSearchOrderID.Location = New System.Drawing.Point(52, 4)
        Me.txtSearchOrderID.Multiline = True
        Me.txtSearchOrderID.Name = "txtSearchOrderID"
        Me.txtSearchOrderID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchOrderID.Size = New System.Drawing.Size(261, 45)
        Me.txtSearchOrderID.TabIndex = 90
        '
        'chkSearchOrderID
        '
        Me.chkSearchOrderID.AutoSize = True
        Me.chkSearchOrderID.Location = New System.Drawing.Point(5, 4)
        Me.chkSearchOrderID.Name = "chkSearchOrderID"
        Me.chkSearchOrderID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchOrderID.TabIndex = 89
        Me.chkSearchOrderID.Text = "ID(s)"
        Me.chkSearchOrderID.UseVisualStyleBackColor = True
        '
        'fTabData
        '
        Me.fTabData.Controls.Add(Me.Panel4)
        Me.fTabData.Controls.Add(Me.Panel5)
        Me.fTabData.Controls.Add(Me.Panel2)
        Me.fTabData.Controls.Add(Me.Panel15)
        Me.fTabData.Location = New System.Drawing.Point(4, 25)
        Me.fTabData.Name = "fTabData"
        Me.fTabData.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabData.Size = New System.Drawing.Size(745, 494)
        Me.fTabData.TabIndex = 1
        Me.fTabData.Text = "Data"
        Me.fTabData.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.fTabDetilMain)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 178)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(739, 301)
        Me.Panel4.TabIndex = 0
        '
        'fTabDetilMain
        '
        Me.fTabDetilMain.Controls.Add(Me.fTabDataNotesProc)
        Me.fTabDetilMain.Controls.Add(Me.fTabDataDetil)
        Me.fTabDetilMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fTabDetilMain.Location = New System.Drawing.Point(0, 0)
        Me.fTabDetilMain.myBackColor = System.Drawing.SystemColors.Control
        Me.fTabDetilMain.Name = "fTabDetilMain"
        Me.fTabDetilMain.SelectedIndex = 0
        Me.fTabDetilMain.Size = New System.Drawing.Size(739, 301)
        Me.fTabDetilMain.TabIndex = 0
        '
        'fTabDataNotesProc
        '
        Me.fTabDataNotesProc.Controls.Add(Me.Panel12)
        Me.fTabDataNotesProc.Location = New System.Drawing.Point(4, 25)
        Me.fTabDataNotesProc.Name = "fTabDataNotesProc"
        Me.fTabDataNotesProc.Size = New System.Drawing.Size(731, 272)
        Me.fTabDataNotesProc.TabIndex = 2
        Me.fTabDataNotesProc.Text = "Notes Proc"
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.dgv_orderdetilproc)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(731, 272)
        Me.Panel12.TabIndex = 0
        '
        'dgv_orderdetilproc
        '
        Me.dgv_orderdetilproc.AllowUserToAddRows = False
        Me.dgv_orderdetilproc.AllowUserToDeleteRows = False
        Me.dgv_orderdetilproc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_orderdetilproc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_orderdetilproc.Location = New System.Drawing.Point(0, 0)
        Me.dgv_orderdetilproc.Name = "dgv_orderdetilproc"
        Me.dgv_orderdetilproc.Size = New System.Drawing.Size(731, 272)
        Me.dgv_orderdetilproc.TabIndex = 0
        '
        'fTabDataDetil
        '
        Me.fTabDataDetil.BackColor = System.Drawing.SystemColors.Control
        Me.fTabDataDetil.Controls.Add(Me.DgvOrderCompleteDetil)
        Me.fTabDataDetil.Location = New System.Drawing.Point(4, 25)
        Me.fTabDataDetil.Name = "fTabDataDetil"
        Me.fTabDataDetil.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabDataDetil.Size = New System.Drawing.Size(178, 0)
        Me.fTabDataDetil.TabIndex = 0
        Me.fTabDataDetil.Text = "Order Detil With RV"
        '
        'DgvOrderCompleteDetil
        '
        Me.DgvOrderCompleteDetil.AllowUserToAddRows = False
        Me.DgvOrderCompleteDetil.AllowUserToDeleteRows = False
        Me.DgvOrderCompleteDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOrderCompleteDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvOrderCompleteDetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvOrderCompleteDetil.Name = "DgvOrderCompleteDetil"
        Me.DgvOrderCompleteDetil.ReadOnly = True
        Me.DgvOrderCompleteDetil.Size = New System.Drawing.Size(172, 0)
        Me.DgvOrderCompleteDetil.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 479)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(739, 12)
        Me.Panel5.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.dgv_noteusage)
        Me.Panel2.Controls.Add(Me.dgv_orderdetilusage)
        Me.Panel2.Controls.Add(Me.obj_enddate)
        Me.Panel2.Controls.Add(Me.obj_startdate)
        Me.Panel2.Controls.Add(Me.obj_setdate)
        Me.Panel2.Controls.Add(Me.obj_orderdate)
        Me.Panel2.Controls.Add(Me.obj_department)
        Me.Panel2.Controls.Add(Me.obj_rekanan)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.obj_ordertype)
        Me.Panel2.Controls.Add(Me.obj_programtype)
        Me.Panel2.Controls.Add(Me.obj_channel)
        Me.Panel2.Controls.Add(Me.obj_descr)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(739, 141)
        Me.Panel2.TabIndex = 0
        '
        'dgv_noteusage
        '
        Me.dgv_noteusage.AllowUserToAddRows = False
        Me.dgv_noteusage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_noteusage.Location = New System.Drawing.Point(648, 112)
        Me.dgv_noteusage.Name = "dgv_noteusage"
        Me.dgv_noteusage.Size = New System.Drawing.Size(75, 15)
        Me.dgv_noteusage.TabIndex = 0
        Me.dgv_noteusage.Visible = False
        '
        'dgv_orderdetilusage
        '
        Me.dgv_orderdetilusage.AllowUserToAddRows = False
        Me.dgv_orderdetilusage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_orderdetilusage.Location = New System.Drawing.Point(648, 89)
        Me.dgv_orderdetilusage.Name = "dgv_orderdetilusage"
        Me.dgv_orderdetilusage.Size = New System.Drawing.Size(75, 17)
        Me.dgv_orderdetilusage.TabIndex = 0
        Me.dgv_orderdetilusage.Visible = False
        '
        'obj_enddate
        '
        Me.obj_enddate.CustomFormat = "dd/MM/yyyy"
        Me.obj_enddate.Enabled = False
        Me.obj_enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_enddate.Location = New System.Drawing.Point(219, 113)
        Me.obj_enddate.Name = "obj_enddate"
        Me.obj_enddate.Size = New System.Drawing.Size(83, 20)
        Me.obj_enddate.TabIndex = 3
        '
        'obj_startdate
        '
        Me.obj_startdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_startdate.Enabled = False
        Me.obj_startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_startdate.Location = New System.Drawing.Point(74, 113)
        Me.obj_startdate.Name = "obj_startdate"
        Me.obj_startdate.Size = New System.Drawing.Size(83, 20)
        Me.obj_startdate.TabIndex = 3
        '
        'obj_setdate
        '
        Me.obj_setdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_setdate.Enabled = False
        Me.obj_setdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_setdate.Location = New System.Drawing.Point(74, 86)
        Me.obj_setdate.Name = "obj_setdate"
        Me.obj_setdate.Size = New System.Drawing.Size(83, 20)
        Me.obj_setdate.TabIndex = 3
        '
        'obj_orderdate
        '
        Me.obj_orderdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_orderdate.Enabled = False
        Me.obj_orderdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_orderdate.Location = New System.Drawing.Point(74, 5)
        Me.obj_orderdate.Name = "obj_orderdate"
        Me.obj_orderdate.Size = New System.Drawing.Size(83, 20)
        Me.obj_orderdate.TabIndex = 3
        '
        'obj_department
        '
        Me.obj_department.Enabled = False
        Me.obj_department.FormattingEnabled = True
        Me.obj_department.Location = New System.Drawing.Point(74, 32)
        Me.obj_department.Name = "obj_department"
        Me.obj_department.Size = New System.Drawing.Size(185, 21)
        Me.obj_department.TabIndex = 2
        '
        'obj_rekanan
        '
        Me.obj_rekanan.Enabled = False
        Me.obj_rekanan.FormattingEnabled = True
        Me.obj_rekanan.Location = New System.Drawing.Point(74, 60)
        Me.obj_rekanan.Name = "obj_rekanan"
        Me.obj_rekanan.Size = New System.Drawing.Size(185, 21)
        Me.obj_rekanan.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(624, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Order Type"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(625, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Prog. Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(625, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Channel"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "End Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Start Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Set Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rekanan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Order Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Department"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(271, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Description"
        '
        'obj_ordertype
        '
        Me.obj_ordertype.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_ordertype.Location = New System.Drawing.Point(690, 34)
        Me.obj_ordertype.Name = "obj_ordertype"
        Me.obj_ordertype.ReadOnly = True
        Me.obj_ordertype.Size = New System.Drawing.Size(45, 20)
        Me.obj_ordertype.TabIndex = 0
        '
        'obj_programtype
        '
        Me.obj_programtype.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_programtype.Location = New System.Drawing.Point(690, 60)
        Me.obj_programtype.Name = "obj_programtype"
        Me.obj_programtype.ReadOnly = True
        Me.obj_programtype.Size = New System.Drawing.Size(45, 20)
        Me.obj_programtype.TabIndex = 0
        '
        'obj_channel
        '
        Me.obj_channel.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_channel.Location = New System.Drawing.Point(690, 6)
        Me.obj_channel.Name = "obj_channel"
        Me.obj_channel.ReadOnly = True
        Me.obj_channel.Size = New System.Drawing.Size(45, 20)
        Me.obj_channel.TabIndex = 0
        '
        'obj_descr
        '
        Me.obj_descr.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_descr.Location = New System.Drawing.Point(337, 9)
        Me.obj_descr.Multiline = True
        Me.obj_descr.Name = "obj_descr"
        Me.obj_descr.ReadOnly = True
        Me.obj_descr.Size = New System.Drawing.Size(281, 124)
        Me.obj_descr.TabIndex = 0
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel15.Controls.Add(Me.Label17)
        Me.Panel15.Controls.Add(Me.obj_statusdate)
        Me.Panel15.Controls.Add(Me.Label15)
        Me.Panel15.Controls.Add(Me.obj_statusby)
        Me.Panel15.Controls.Add(Me.obj_status)
        Me.Panel15.Controls.Add(Me.Label10)
        Me.Panel15.Controls.Add(Me.obj_order_id)
        Me.Panel15.Controls.Add(Me.Label1)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(3, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(739, 34)
        Me.Panel15.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(588, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Date"
        '
        'obj_statusdate
        '
        Me.obj_statusdate.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_statusdate.Location = New System.Drawing.Point(624, 7)
        Me.obj_statusdate.Name = "obj_statusdate"
        Me.obj_statusdate.ReadOnly = True
        Me.obj_statusdate.Size = New System.Drawing.Size(108, 20)
        Me.obj_statusdate.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(449, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "By"
        '
        'obj_statusby
        '
        Me.obj_statusby.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_statusby.Location = New System.Drawing.Point(474, 7)
        Me.obj_statusby.Name = "obj_statusby"
        Me.obj_statusby.ReadOnly = True
        Me.obj_statusby.Size = New System.Drawing.Size(108, 20)
        Me.obj_statusby.TabIndex = 4
        '
        'obj_status
        '
        Me.obj_status.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_status.Location = New System.Drawing.Point(337, 7)
        Me.obj_status.Name = "obj_status"
        Me.obj_status.ReadOnly = True
        Me.obj_status.Size = New System.Drawing.Size(106, 20)
        Me.obj_status.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(271, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Status"
        '
        'obj_order_id
        '
        Me.obj_order_id.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.obj_order_id.Location = New System.Drawing.Point(74, 7)
        Me.obj_order_id.Name = "obj_order_id"
        Me.obj_order_id.ReadOnly = True
        Me.obj_order_id.Size = New System.Drawing.Size(118, 20)
        Me.obj_order_id.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Order Id"
        '
        'uiOrderComplete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlatTabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiOrderComplete"
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.fTabList.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvOrderComplete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.fTabData.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.fTabDetilMain.ResumeLayout(False)
        Me.fTabDataNotesProc.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.dgv_orderdetilproc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabDataDetil.ResumeLayout(False)
        CType(Me.DgvOrderCompleteDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_noteusage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_orderdetilusage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlatTabMain As FlatTabControl.FlatTabControl
    Friend WithEvents fTabList As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DgvOrderComplete As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents fTabData As System.Windows.Forms.TabPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents obj_startdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_setdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_orderdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_rekanan As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_channel As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_id As System.Windows.Forms.TextBox
    Friend WithEvents fTabDetilMain As FlatTabControl.FlatTabControl
    Friend WithEvents fTabDataDetil As System.Windows.Forms.TabPage
    Friend WithEvents DgvOrderCompleteDetil As System.Windows.Forms.DataGridView
    Friend WithEvents obj_enddate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_department As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents obj_programtype As System.Windows.Forms.TextBox
    Friend WithEvents obj_descr As System.Windows.Forms.TextBox
    Friend WithEvents obj_status As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents obj_ordertype As System.Windows.Forms.TextBox
    Friend WithEvents dgv_orderdetilusage As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_noteusage As System.Windows.Forms.DataGridView
    Friend WithEvents fTabDataNotesProc As System.Windows.Forms.TabPage
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents dgv_orderdetilproc As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSearchOrderID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchOrderID As System.Windows.Forms.CheckBox
    Friend WithEvents obj_status_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_status_search As System.Windows.Forms.CheckBox
    Friend WithEvents rekananidtxt As System.Windows.Forms.TextBox
    Friend WithEvents btnVendor As System.Windows.Forms.Button
    Friend WithEvents chkSearchRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents obj_ordertype_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_ordertype_search As System.Windows.Forms.CheckBox
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents obj_statusdate As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents obj_statusby As System.Windows.Forms.TextBox

End Class
