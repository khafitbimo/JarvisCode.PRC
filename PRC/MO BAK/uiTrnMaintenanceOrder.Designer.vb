<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnMaintenanceOrder
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
        Me.FlatTabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnOrder = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.chkSearchLast2Periode = New System.Windows.Forms.CheckBox
        Me.txtSearchBudgetCode = New System.Windows.Forms.TextBox
        Me.chkSearchBudgetCode = New System.Windows.Forms.CheckBox
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox
        Me.cboSearchRekanan = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSearchOrderID = New System.Windows.Forms.TextBox
        Me.chkSearchOrderID = New System.Windows.Forms.CheckBox
        Me.txtSearchPeriode = New System.Windows.Forms.TextBox
        Me.chkSearchPeriode = New System.Windows.Forms.CheckBox
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvTrnOrderdetil = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_PaymReq = New System.Windows.Forms.TabPage
        Me.DgvTrnOrderPaymReq = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_PurchReq = New System.Windows.Forms.TabPage
        Me.dgvTrnMaintReq = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Dlvr = New System.Windows.Forms.TabPage
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.obj_order_dlvrtelp = New System.Windows.Forms.TextBox
        Me.order_dlvrfax = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.obj_order_dlvraddr1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.obj_order_dlvrname = New System.Windows.Forms.TextBox
        Me.obj_order_dlvraddr2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.obj_order_dlvraddr3 = New System.Windows.Forms.TextBox
        Me.ftabDataDetil_Sign = New System.Windows.Forms.TabPage
        Me.obj_Order_authname = New System.Windows.Forms.TextBox
        Me.obj_Order_authposition = New System.Windows.Forms.TextBox
        Me.lbl_Order_authname = New System.Windows.Forms.Label
        Me.ftabDataDetil_Additional = New System.Windows.Forms.TabPage
        Me.lbl_Order_insurancecost = New System.Windows.Forms.Label
        Me.obj_Order_transportationcost = New System.Windows.Forms.TextBox
        Me.lbl_Order_transportationcost = New System.Windows.Forms.Label
        Me.obj_Order_insurancecost = New System.Windows.Forms.TextBox
        Me.obj_Order_operatorcost = New System.Windows.Forms.TextBox
        Me.lbl_Order_operatorcost = New System.Windows.Forms.Label
        Me.lbl_Order_othercost = New System.Windows.Forms.Label
        Me.obj_Order_othercost = New System.Windows.Forms.TextBox
        Me.ftabDataDetil_Budget = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRO_plus_PO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAllPOAmount_perBudget = New System.Windows.Forms.TextBox
        Me.btnCheckAll_OrderAmt = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAllROAmount_perBudget = New System.Windows.Forms.TextBox
        Me.cbo_Budget_amount = New System.Windows.Forms.ComboBox
        Me.lbl_BgtAmt = New System.Windows.Forms.Label
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage
        Me.lbl_Ordertype_id = New System.Windows.Forms.Label
        Me.obj_Ordertype_id = New System.Windows.Forms.TextBox
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.obj_Order_source = New System.Windows.Forms.TextBox
        Me.txt_channel_name = New System.Windows.Forms.TextBox
        Me.txt_usrname = New System.Windows.Forms.TextBox
        Me.lbl_Order_Source = New System.Windows.Forms.Label
        Me.lbl_Channel = New System.Windows.Forms.Label
        Me.lbl_Login = New System.Windows.Forms.Label
        Me.cbo_Old_program_name = New System.Windows.Forms.ComboBox
        Me.lbl_Old_program_name = New System.Windows.Forms.Label
        Me.obj_Old_program_id = New System.Windows.Forms.TextBox
        Me.obj_Order_isprinted = New System.Windows.Forms.CheckBox
        Me.obj_Order_createby = New System.Windows.Forms.TextBox
        Me.lbl_Order_modifydate = New System.Windows.Forms.Label
        Me.obj_Order_modifydate = New System.Windows.Forms.TextBox
        Me.lbl_Order_modifyby = New System.Windows.Forms.Label
        Me.obj_Order_modifyby = New System.Windows.Forms.TextBox
        Me.lbl_Order_createdate = New System.Windows.Forms.Label
        Me.obj_Order_createdate = New System.Windows.Forms.TextBox
        Me.lbl_Order_createby = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.obj_order_note = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.calc_Order_GTotal = New System.Windows.Forms.TextBox
        Me.calc_Order_PPN = New System.Windows.Forms.TextBox
        Me.calc_Order_PPH = New System.Windows.Forms.TextBox
        Me.calc_Order_subtotal = New System.Windows.Forms.TextBox
        Me.lbl_Order_pph_percent = New System.Windows.Forms.Label
        Me.lbl_Order_ppn_percent = New System.Windows.Forms.Label
        Me.obj_Order_discount = New System.Windows.Forms.TextBox
        Me.lbl_order_discount = New System.Windows.Forms.Label
        Me.lbl_createby = New System.Windows.Forms.Label
        Me.obj_Order_canceled = New System.Windows.Forms.CheckBox
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.obj_Order_descr = New System.Windows.Forms.TextBox
        Me.lbl_Order_descr = New System.Windows.Forms.Label
        Me.btn_FindBudget = New System.Windows.Forms.Button
        Me.cbo_Budget_name = New System.Windows.Forms.ComboBox
        Me.cbo_Rekanan_contact = New System.Windows.Forms.ComboBox
        Me.cbo_Rekanan_name = New System.Windows.Forms.ComboBox
        Me.lbl_cp = New System.Windows.Forms.Label
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox
        Me.lbl_rekanan_id = New System.Windows.Forms.Label
        Me.obj_Budget_id = New System.Windows.Forms.TextBox
        Me.lbl_Budget_id = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cbo_Deptname = New System.Windows.Forms.ComboBox
        Me.lbl_Dept_name = New System.Windows.Forms.Label
        Me.gboRevision = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtp_order_revdate = New System.Windows.Forms.DateTimePicker
        Me.lbl_Order_revdesc = New System.Windows.Forms.Label
        Me.obj_Order_revno = New System.Windows.Forms.TextBox
        Me.lbl_Order_revno = New System.Windows.Forms.Label
        Me.obj_order_revdesc = New System.Windows.Forms.TextBox
        Me.dtp_order_date = New System.Windows.Forms.DateTimePicker
        Me.cbo_Periode_id = New System.Windows.Forms.ComboBox
        Me.lbl_Periode_id = New System.Windows.Forms.Label
        Me.obj_Order_id = New System.Windows.Forms.TextBox
        Me.lbl_order_date = New System.Windows.Forms.Label
        Me.lbl_Order_id = New System.Windows.Forms.Label
        Me.obj_Request_id = New System.Windows.Forms.TextBox
        Me.lbl_Request_id = New System.Windows.Forms.Label
        Me.FlatTabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvTrnOrderdetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_PaymReq.SuspendLayout()
        CType(Me.DgvTrnOrderPaymReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_PurchReq.SuspendLayout()
        CType(Me.dgvTrnMaintReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Dlvr.SuspendLayout()
        Me.ftabDataDetil_Sign.SuspendLayout()
        Me.ftabDataDetil_Additional.SuspendLayout()
        Me.ftabDataDetil_Budget.SuspendLayout()
        Me.ftabDataDetil_Info.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gboRevision.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlatTabMain
        '
        Me.FlatTabMain.Controls.Add(Me.ftabMain_List)
        Me.FlatTabMain.Controls.Add(Me.ftabMain_Data)
        Me.FlatTabMain.Location = New System.Drawing.Point(3, 28)
        Me.FlatTabMain.myBackColor = System.Drawing.Color.White
        Me.FlatTabMain.Name = "FlatTabMain"
        Me.FlatTabMain.SelectedIndex = 0
        Me.FlatTabMain.Size = New System.Drawing.Size(755, 517)
        Me.FlatTabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(747, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvTrnOrder)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnOrder
        '
        Me.DgvTrnOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnOrder.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnOrder.Name = "DgvTrnOrder"
        Me.DgvTrnOrder.Size = New System.Drawing.Size(704, 296)
        Me.DgvTrnOrder.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(741, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.chkSearchLast2Periode)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchBudgetCode)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchBudgetCode)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.Label5)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchOrderID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchOrderID)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchPeriode)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchPeriode)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(741, 122)
        Me.PnlDfSearch.TabIndex = 0
        '
        'chkSearchLast2Periode
        '
        Me.chkSearchLast2Periode.AutoSize = True
        Me.chkSearchLast2Periode.Checked = True
        Me.chkSearchLast2Periode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchLast2Periode.Location = New System.Drawing.Point(594, 13)
        Me.chkSearchLast2Periode.Name = "chkSearchLast2Periode"
        Me.chkSearchLast2Periode.Size = New System.Drawing.Size(108, 17)
        Me.chkSearchLast2Periode.TabIndex = 35
        Me.chkSearchLast2Periode.Text = "Last Two Months"
        Me.chkSearchLast2Periode.UseVisualStyleBackColor = True
        '
        'txtSearchBudgetCode
        '
        Me.txtSearchBudgetCode.Location = New System.Drawing.Point(506, 35)
        Me.txtSearchBudgetCode.MaxLength = 4
        Me.txtSearchBudgetCode.Name = "txtSearchBudgetCode"
        Me.txtSearchBudgetCode.Size = New System.Drawing.Size(61, 20)
        Me.txtSearchBudgetCode.TabIndex = 33
        '
        'chkSearchBudgetCode
        '
        Me.chkSearchBudgetCode.AutoSize = True
        Me.chkSearchBudgetCode.Location = New System.Drawing.Point(400, 37)
        Me.chkSearchBudgetCode.Name = "chkSearchBudgetCode"
        Me.chkSearchBudgetCode.Size = New System.Drawing.Size(88, 17)
        Me.chkSearchBudgetCode.TabIndex = 32
        Me.chkSearchBudgetCode.Text = "Budget Code"
        Me.chkSearchBudgetCode.UseVisualStyleBackColor = True
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(400, 60)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchRekanan.TabIndex = 30
        Me.chkSearchRekanan.Text = "Vendor"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
        '
        'cboSearchRekanan
        '
        Me.cboSearchRekanan.FormattingEnabled = True
        Me.cboSearchRekanan.Location = New System.Drawing.Point(506, 58)
        Me.cboSearchRekanan.Name = "cboSearchRekanan"
        Me.cboSearchRekanan.Size = New System.Drawing.Size(196, 21)
        Me.cboSearchRekanan.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(102, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(263, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtSearchOrderID
        '
        Me.txtSearchOrderID.Location = New System.Drawing.Point(104, 40)
        Me.txtSearchOrderID.Multiline = True
        Me.txtSearchOrderID.Name = "txtSearchOrderID"
        Me.txtSearchOrderID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchOrderID.Size = New System.Drawing.Size(261, 64)
        Me.txtSearchOrderID.TabIndex = 27
        '
        'chkSearchOrderID
        '
        Me.chkSearchOrderID.AutoSize = True
        Me.chkSearchOrderID.Location = New System.Drawing.Point(17, 38)
        Me.chkSearchOrderID.Name = "chkSearchOrderID"
        Me.chkSearchOrderID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchOrderID.TabIndex = 26
        Me.chkSearchOrderID.Text = "ID(s)"
        Me.chkSearchOrderID.UseVisualStyleBackColor = True
        '
        'txtSearchPeriode
        '
        Me.txtSearchPeriode.Location = New System.Drawing.Point(506, 11)
        Me.txtSearchPeriode.MaxLength = 4
        Me.txtSearchPeriode.Name = "txtSearchPeriode"
        Me.txtSearchPeriode.Size = New System.Drawing.Size(61, 20)
        Me.txtSearchPeriode.TabIndex = 25
        '
        'chkSearchPeriode
        '
        Me.chkSearchPeriode.AutoSize = True
        Me.chkSearchPeriode.Location = New System.Drawing.Point(400, 14)
        Me.chkSearchPeriode.Name = "chkSearchPeriode"
        Me.chkSearchPeriode.Size = New System.Drawing.Size(62, 17)
        Me.chkSearchPeriode.TabIndex = 24
        Me.chkSearchPeriode.Text = "Periode"
        Me.chkSearchPeriode.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.Enabled = False
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(104, 13)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 15)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.Panel2)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(747, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_PaymReq)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_PurchReq)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Dlvr)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Sign)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Additional)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Budget)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Info)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 174)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(741, 182)
        Me.ftabDataDetil.TabIndex = 101
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvTrnOrderdetil)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(733, 153)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvTrnOrderdetil
        '
        Me.DgvTrnOrderdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnOrderdetil.Location = New System.Drawing.Point(30, 29)
        Me.DgvTrnOrderdetil.Name = "DgvTrnOrderdetil"
        Me.DgvTrnOrderdetil.Size = New System.Drawing.Size(665, 105)
        Me.DgvTrnOrderdetil.TabIndex = 1
        '
        'ftabDataDetil_PaymReq
        '
        Me.ftabDataDetil_PaymReq.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_PaymReq.Controls.Add(Me.DgvTrnOrderPaymReq)
        Me.ftabDataDetil_PaymReq.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_PaymReq.Name = "ftabDataDetil_PaymReq"
        Me.ftabDataDetil_PaymReq.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_PaymReq.Size = New System.Drawing.Size(733, 153)
        Me.ftabDataDetil_PaymReq.TabIndex = 2
        Me.ftabDataDetil_PaymReq.Text = "Payment Request"
        '
        'DgvTrnOrderPaymReq
        '
        Me.DgvTrnOrderPaymReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnOrderPaymReq.Location = New System.Drawing.Point(62, 20)
        Me.DgvTrnOrderPaymReq.Name = "DgvTrnOrderPaymReq"
        Me.DgvTrnOrderPaymReq.Size = New System.Drawing.Size(667, 110)
        Me.DgvTrnOrderPaymReq.TabIndex = 1
        '
        'ftabDataDetil_PurchReq
        '
        Me.ftabDataDetil_PurchReq.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_PurchReq.Controls.Add(Me.dgvTrnMaintReq)
        Me.ftabDataDetil_PurchReq.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_PurchReq.Name = "ftabDataDetil_PurchReq"
        Me.ftabDataDetil_PurchReq.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_PurchReq.Size = New System.Drawing.Size(733, 153)
        Me.ftabDataDetil_PurchReq.TabIndex = 3
        Me.ftabDataDetil_PurchReq.Text = "Maintenance Request"
        '
        'dgvTrnMaintReq
        '
        Me.dgvTrnMaintReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrnMaintReq.Location = New System.Drawing.Point(34, 26)
        Me.dgvTrnMaintReq.Name = "dgvTrnMaintReq"
        Me.dgvTrnMaintReq.Size = New System.Drawing.Size(667, 110)
        Me.dgvTrnMaintReq.TabIndex = 2
        '
        'ftabDataDetil_Dlvr
        '
        Me.ftabDataDetil_Dlvr.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.TextBox2)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label13)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvrtelp)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.order_dlvrfax)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label2)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvraddr1)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label10)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvrname)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvraddr2)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label11)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label12)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvraddr3)
        Me.ftabDataDetil_Dlvr.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Dlvr.Name = "ftabDataDetil_Dlvr"
        Me.ftabDataDetil_Dlvr.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Dlvr.TabIndex = 9
        Me.ftabDataDetil_Dlvr.Text = "Delivery Address"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(487, 98)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(187, 20)
        Me.TextBox2.TabIndex = 48
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(431, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "HP"
        '
        'obj_order_dlvrtelp
        '
        Me.obj_order_dlvrtelp.Location = New System.Drawing.Point(487, 54)
        Me.obj_order_dlvrtelp.Name = "obj_order_dlvrtelp"
        Me.obj_order_dlvrtelp.Size = New System.Drawing.Size(187, 20)
        Me.obj_order_dlvrtelp.TabIndex = 45
        Me.obj_order_dlvrtelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'order_dlvrfax
        '
        Me.order_dlvrfax.Location = New System.Drawing.Point(487, 76)
        Me.order_dlvrfax.Name = "order_dlvrfax"
        Me.order_dlvrfax.Size = New System.Drawing.Size(187, 20)
        Me.order_dlvrfax.TabIndex = 46
        Me.order_dlvrfax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Name"
        '
        'obj_order_dlvraddr1
        '
        Me.obj_order_dlvraddr1.Location = New System.Drawing.Point(113, 54)
        Me.obj_order_dlvraddr1.Name = "obj_order_dlvraddr1"
        Me.obj_order_dlvraddr1.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvraddr1.TabIndex = 42
        Me.obj_order_dlvraddr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Address"
        '
        'obj_order_dlvrname
        '
        Me.obj_order_dlvrname.Location = New System.Drawing.Point(113, 32)
        Me.obj_order_dlvrname.Name = "obj_order_dlvrname"
        Me.obj_order_dlvrname.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvrname.TabIndex = 41
        Me.obj_order_dlvrname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_order_dlvraddr2
        '
        Me.obj_order_dlvraddr2.Location = New System.Drawing.Point(113, 76)
        Me.obj_order_dlvraddr2.Name = "obj_order_dlvraddr2"
        Me.obj_order_dlvraddr2.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvraddr2.TabIndex = 43
        Me.obj_order_dlvraddr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(431, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Phone"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(431, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Fax"
        '
        'obj_order_dlvraddr3
        '
        Me.obj_order_dlvraddr3.Location = New System.Drawing.Point(113, 98)
        Me.obj_order_dlvraddr3.Name = "obj_order_dlvraddr3"
        Me.obj_order_dlvraddr3.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvraddr3.TabIndex = 44
        Me.obj_order_dlvraddr3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ftabDataDetil_Sign
        '
        Me.ftabDataDetil_Sign.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Sign.Controls.Add(Me.obj_Order_authname)
        Me.ftabDataDetil_Sign.Controls.Add(Me.obj_Order_authposition)
        Me.ftabDataDetil_Sign.Controls.Add(Me.lbl_Order_authname)
        Me.ftabDataDetil_Sign.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Sign.Name = "ftabDataDetil_Sign"
        Me.ftabDataDetil_Sign.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Sign.TabIndex = 6
        Me.ftabDataDetil_Sign.Text = "Signature"
        '
        'obj_Order_authname
        '
        Me.obj_Order_authname.Location = New System.Drawing.Point(31, 39)
        Me.obj_Order_authname.Name = "obj_Order_authname"
        Me.obj_Order_authname.ReadOnly = True
        Me.obj_Order_authname.Size = New System.Drawing.Size(108, 20)
        Me.obj_Order_authname.TabIndex = 28
        Me.obj_Order_authname.TabStop = False
        '
        'obj_Order_authposition
        '
        Me.obj_Order_authposition.Location = New System.Drawing.Point(145, 39)
        Me.obj_Order_authposition.Name = "obj_Order_authposition"
        Me.obj_Order_authposition.ReadOnly = True
        Me.obj_Order_authposition.Size = New System.Drawing.Size(197, 20)
        Me.obj_Order_authposition.TabIndex = 29
        Me.obj_Order_authposition.TabStop = False
        '
        'lbl_Order_authname
        '
        Me.lbl_Order_authname.AutoSize = True
        Me.lbl_Order_authname.Location = New System.Drawing.Point(28, 23)
        Me.lbl_Order_authname.Name = "lbl_Order_authname"
        Me.lbl_Order_authname.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Order_authname.TabIndex = 32
        Me.lbl_Order_authname.Text = "Approval"
        '
        'ftabDataDetil_Additional
        '
        Me.ftabDataDetil_Additional.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Additional.Controls.Add(Me.lbl_Order_insurancecost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.obj_Order_transportationcost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.lbl_Order_transportationcost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.obj_Order_insurancecost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.obj_Order_operatorcost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.lbl_Order_operatorcost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.lbl_Order_othercost)
        Me.ftabDataDetil_Additional.Controls.Add(Me.obj_Order_othercost)
        Me.ftabDataDetil_Additional.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Additional.Name = "ftabDataDetil_Additional"
        Me.ftabDataDetil_Additional.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Additional.TabIndex = 7
        Me.ftabDataDetil_Additional.Text = "Additional Cost"
        '
        'lbl_Order_insurancecost
        '
        Me.lbl_Order_insurancecost.AutoSize = True
        Me.lbl_Order_insurancecost.Location = New System.Drawing.Point(33, 28)
        Me.lbl_Order_insurancecost.Name = "lbl_Order_insurancecost"
        Me.lbl_Order_insurancecost.Size = New System.Drawing.Size(54, 13)
        Me.lbl_Order_insurancecost.TabIndex = 0
        Me.lbl_Order_insurancecost.Text = "Insurance"
        '
        'obj_Order_transportationcost
        '
        Me.obj_Order_transportationcost.Location = New System.Drawing.Point(123, 47)
        Me.obj_Order_transportationcost.Name = "obj_Order_transportationcost"
        Me.obj_Order_transportationcost.Size = New System.Drawing.Size(100, 20)
        Me.obj_Order_transportationcost.TabIndex = 34
        Me.obj_Order_transportationcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Order_transportationcost
        '
        Me.lbl_Order_transportationcost.AutoSize = True
        Me.lbl_Order_transportationcost.Location = New System.Drawing.Point(33, 50)
        Me.lbl_Order_transportationcost.Name = "lbl_Order_transportationcost"
        Me.lbl_Order_transportationcost.Size = New System.Drawing.Size(75, 13)
        Me.lbl_Order_transportationcost.TabIndex = 0
        Me.lbl_Order_transportationcost.Text = "Transportation"
        '
        'obj_Order_insurancecost
        '
        Me.obj_Order_insurancecost.Location = New System.Drawing.Point(123, 25)
        Me.obj_Order_insurancecost.Name = "obj_Order_insurancecost"
        Me.obj_Order_insurancecost.Size = New System.Drawing.Size(100, 20)
        Me.obj_Order_insurancecost.TabIndex = 33
        Me.obj_Order_insurancecost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_Order_operatorcost
        '
        Me.obj_Order_operatorcost.Location = New System.Drawing.Point(123, 69)
        Me.obj_Order_operatorcost.Name = "obj_Order_operatorcost"
        Me.obj_Order_operatorcost.Size = New System.Drawing.Size(100, 20)
        Me.obj_Order_operatorcost.TabIndex = 35
        Me.obj_Order_operatorcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Order_operatorcost
        '
        Me.lbl_Order_operatorcost.AutoSize = True
        Me.lbl_Order_operatorcost.Location = New System.Drawing.Point(33, 72)
        Me.lbl_Order_operatorcost.Name = "lbl_Order_operatorcost"
        Me.lbl_Order_operatorcost.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Order_operatorcost.TabIndex = 0
        Me.lbl_Order_operatorcost.Text = "Operator"
        '
        'lbl_Order_othercost
        '
        Me.lbl_Order_othercost.AutoSize = True
        Me.lbl_Order_othercost.Location = New System.Drawing.Point(33, 94)
        Me.lbl_Order_othercost.Name = "lbl_Order_othercost"
        Me.lbl_Order_othercost.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Order_othercost.TabIndex = 0
        Me.lbl_Order_othercost.Text = "Other"
        '
        'obj_Order_othercost
        '
        Me.obj_Order_othercost.Location = New System.Drawing.Point(123, 91)
        Me.obj_Order_othercost.Name = "obj_Order_othercost"
        Me.obj_Order_othercost.Size = New System.Drawing.Size(100, 20)
        Me.obj_Order_othercost.TabIndex = 36
        Me.obj_Order_othercost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ftabDataDetil_Budget
        '
        Me.ftabDataDetil_Budget.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Budget.Controls.Add(Me.Label8)
        Me.ftabDataDetil_Budget.Controls.Add(Me.txtRO_plus_PO)
        Me.ftabDataDetil_Budget.Controls.Add(Me.Label7)
        Me.ftabDataDetil_Budget.Controls.Add(Me.txtAllPOAmount_perBudget)
        Me.ftabDataDetil_Budget.Controls.Add(Me.btnCheckAll_OrderAmt)
        Me.ftabDataDetil_Budget.Controls.Add(Me.Label6)
        Me.ftabDataDetil_Budget.Controls.Add(Me.txtAllROAmount_perBudget)
        Me.ftabDataDetil_Budget.Controls.Add(Me.cbo_Budget_amount)
        Me.ftabDataDetil_Budget.Controls.Add(Me.lbl_BgtAmt)
        Me.ftabDataDetil_Budget.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Budget.Name = "ftabDataDetil_Budget"
        Me.ftabDataDetil_Budget.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Budget.TabIndex = 8
        Me.ftabDataDetil_Budget.Text = "Budget"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(143, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "RO + PO"
        '
        'txtRO_plus_PO
        '
        Me.txtRO_plus_PO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRO_plus_PO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRO_plus_PO.Location = New System.Drawing.Point(365, 108)
        Me.txtRO_plus_PO.Name = "txtRO_plus_PO"
        Me.txtRO_plus_PO.ReadOnly = True
        Me.txtRO_plus_PO.Size = New System.Drawing.Size(129, 13)
        Me.txtRO_plus_PO.TabIndex = 54
        Me.txtRO_plus_PO.Text = "0.00"
        Me.txtRO_plus_PO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Total PO Amount for Selected Budget"
        '
        'txtAllPOAmount_perBudget
        '
        Me.txtAllPOAmount_perBudget.BackColor = System.Drawing.SystemColors.Window
        Me.txtAllPOAmount_perBudget.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAllPOAmount_perBudget.Location = New System.Drawing.Point(365, 85)
        Me.txtAllPOAmount_perBudget.Name = "txtAllPOAmount_perBudget"
        Me.txtAllPOAmount_perBudget.ReadOnly = True
        Me.txtAllPOAmount_perBudget.Size = New System.Drawing.Size(129, 13)
        Me.txtAllPOAmount_perBudget.TabIndex = 52
        Me.txtAllPOAmount_perBudget.Text = "0.00"
        Me.txtAllPOAmount_perBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCheckAll_OrderAmt
        '
        Me.btnCheckAll_OrderAmt.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCheckAll_OrderAmt.Location = New System.Drawing.Point(515, 29)
        Me.btnCheckAll_OrderAmt.Name = "btnCheckAll_OrderAmt"
        Me.btnCheckAll_OrderAmt.Size = New System.Drawing.Size(75, 23)
        Me.btnCheckAll_OrderAmt.TabIndex = 51
        Me.btnCheckAll_OrderAmt.Text = "Check"
        Me.btnCheckAll_OrderAmt.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Total RO Amount for Selected Budget"
        '
        'txtAllROAmount_perBudget
        '
        Me.txtAllROAmount_perBudget.BackColor = System.Drawing.SystemColors.Window
        Me.txtAllROAmount_perBudget.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAllROAmount_perBudget.Location = New System.Drawing.Point(365, 60)
        Me.txtAllROAmount_perBudget.Name = "txtAllROAmount_perBudget"
        Me.txtAllROAmount_perBudget.ReadOnly = True
        Me.txtAllROAmount_perBudget.Size = New System.Drawing.Size(129, 13)
        Me.txtAllROAmount_perBudget.TabIndex = 49
        Me.txtAllROAmount_perBudget.Text = "0.00"
        Me.txtAllROAmount_perBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_Budget_amount
        '
        Me.cbo_Budget_amount.BackColor = System.Drawing.SystemColors.Window
        Me.cbo_Budget_amount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbo_Budget_amount.FormatString = "#,##0.00"
        Me.cbo_Budget_amount.FormattingEnabled = True
        Me.cbo_Budget_amount.Location = New System.Drawing.Point(365, 30)
        Me.cbo_Budget_amount.Name = "cbo_Budget_amount"
        Me.cbo_Budget_amount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbo_Budget_amount.Size = New System.Drawing.Size(130, 21)
        Me.cbo_Budget_amount.TabIndex = 48
        Me.cbo_Budget_amount.TabStop = False
        '
        'lbl_BgtAmt
        '
        Me.lbl_BgtAmt.AutoSize = True
        Me.lbl_BgtAmt.Location = New System.Drawing.Point(143, 33)
        Me.lbl_BgtAmt.Name = "lbl_BgtAmt"
        Me.lbl_BgtAmt.Size = New System.Drawing.Size(125, 13)
        Me.lbl_BgtAmt.TabIndex = 47
        Me.lbl_BgtAmt.Text = "Selected Budget Amount"
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Ordertype_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Ordertype_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Channel_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_source)
        Me.ftabDataDetil_Info.Controls.Add(Me.txt_channel_name)
        Me.ftabDataDetil_Info.Controls.Add(Me.txt_usrname)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_Source)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Channel)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Login)
        Me.ftabDataDetil_Info.Controls.Add(Me.cbo_Old_program_name)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Old_program_name)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Old_program_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_isprinted)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_createby)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_modifydate)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_modifydate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_modifyby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_modifyby)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_createdate)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_createdate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_createby)
        Me.ftabDataDetil_Info.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Info.TabIndex = 5
        Me.ftabDataDetil_Info.Text = "Order Info"
        '
        'lbl_Ordertype_id
        '
        Me.lbl_Ordertype_id.AutoSize = True
        Me.lbl_Ordertype_id.Location = New System.Drawing.Point(349, 110)
        Me.lbl_Ordertype_id.Name = "lbl_Ordertype_id"
        Me.lbl_Ordertype_id.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Ordertype_id.TabIndex = 48
        Me.lbl_Ordertype_id.Text = "Order Type ID"
        '
        'obj_Ordertype_id
        '
        Me.obj_Ordertype_id.Location = New System.Drawing.Point(461, 107)
        Me.obj_Ordertype_id.Name = "obj_Ordertype_id"
        Me.obj_Ordertype_id.ReadOnly = True
        Me.obj_Ordertype_id.Size = New System.Drawing.Size(265, 20)
        Me.obj_Ordertype_id.TabIndex = 47
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Location = New System.Drawing.Point(461, 65)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(39, 20)
        Me.obj_Channel_id.TabIndex = 44
        '
        'obj_Order_source
        '
        Me.obj_Order_source.Location = New System.Drawing.Point(461, 86)
        Me.obj_Order_source.Name = "obj_Order_source"
        Me.obj_Order_source.ReadOnly = True
        Me.obj_Order_source.Size = New System.Drawing.Size(265, 20)
        Me.obj_Order_source.TabIndex = 46
        '
        'txt_channel_name
        '
        Me.txt_channel_name.Location = New System.Drawing.Point(503, 65)
        Me.txt_channel_name.Name = "txt_channel_name"
        Me.txt_channel_name.ReadOnly = True
        Me.txt_channel_name.Size = New System.Drawing.Size(223, 20)
        Me.txt_channel_name.TabIndex = 45
        '
        'txt_usrname
        '
        Me.txt_usrname.Location = New System.Drawing.Point(461, 44)
        Me.txt_usrname.Name = "txt_usrname"
        Me.txt_usrname.ReadOnly = True
        Me.txt_usrname.Size = New System.Drawing.Size(265, 20)
        Me.txt_usrname.TabIndex = 43
        '
        'lbl_Order_Source
        '
        Me.lbl_Order_Source.AutoSize = True
        Me.lbl_Order_Source.Location = New System.Drawing.Point(349, 89)
        Me.lbl_Order_Source.Name = "lbl_Order_Source"
        Me.lbl_Order_Source.Size = New System.Drawing.Size(70, 13)
        Me.lbl_Order_Source.TabIndex = 25
        Me.lbl_Order_Source.Text = "Order Source"
        '
        'lbl_Channel
        '
        Me.lbl_Channel.AutoSize = True
        Me.lbl_Channel.Location = New System.Drawing.Point(349, 68)
        Me.lbl_Channel.Name = "lbl_Channel"
        Me.lbl_Channel.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Channel.TabIndex = 24
        Me.lbl_Channel.Text = "Channel ID"
        '
        'lbl_Login
        '
        Me.lbl_Login.AutoSize = True
        Me.lbl_Login.Location = New System.Drawing.Point(349, 47)
        Me.lbl_Login.Name = "lbl_Login"
        Me.lbl_Login.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Login.TabIndex = 23
        Me.lbl_Login.Text = "User Name"
        '
        'cbo_Old_program_name
        '
        Me.cbo_Old_program_name.Enabled = False
        Me.cbo_Old_program_name.FormattingEnabled = True
        Me.cbo_Old_program_name.Location = New System.Drawing.Point(461, 22)
        Me.cbo_Old_program_name.Name = "cbo_Old_program_name"
        Me.cbo_Old_program_name.Size = New System.Drawing.Size(265, 21)
        Me.cbo_Old_program_name.TabIndex = 42
        '
        'lbl_Old_program_name
        '
        Me.lbl_Old_program_name.AutoSize = True
        Me.lbl_Old_program_name.Location = New System.Drawing.Point(349, 25)
        Me.lbl_Old_program_name.Name = "lbl_Old_program_name"
        Me.lbl_Old_program_name.Size = New System.Drawing.Size(102, 13)
        Me.lbl_Old_program_name.TabIndex = 21
        Me.lbl_Old_program_name.Text = "Program Name (Old)"
        '
        'obj_Old_program_id
        '
        Me.obj_Old_program_id.Location = New System.Drawing.Point(676, 23)
        Me.obj_Old_program_id.Name = "obj_Old_program_id"
        Me.obj_Old_program_id.Size = New System.Drawing.Size(24, 20)
        Me.obj_Old_program_id.TabIndex = 20
        Me.obj_Old_program_id.Visible = False
        '
        'obj_Order_isprinted
        '
        Me.obj_Order_isprinted.AutoSize = True
        Me.obj_Order_isprinted.Enabled = False
        Me.obj_Order_isprinted.Location = New System.Drawing.Point(20, 113)
        Me.obj_Order_isprinted.Name = "obj_Order_isprinted"
        Me.obj_Order_isprinted.Size = New System.Drawing.Size(59, 17)
        Me.obj_Order_isprinted.TabIndex = 19
        Me.obj_Order_isprinted.Text = "Printed"
        Me.obj_Order_isprinted.UseVisualStyleBackColor = True
        '
        'obj_Order_createby
        '
        Me.obj_Order_createby.Location = New System.Drawing.Point(123, 23)
        Me.obj_Order_createby.Name = "obj_Order_createby"
        Me.obj_Order_createby.ReadOnly = True
        Me.obj_Order_createby.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_createby.TabIndex = 38
        '
        'lbl_Order_modifydate
        '
        Me.lbl_Order_modifydate.AutoSize = True
        Me.lbl_Order_modifydate.Location = New System.Drawing.Point(17, 85)
        Me.lbl_Order_modifydate.Name = "lbl_Order_modifydate"
        Me.lbl_Order_modifydate.Size = New System.Drawing.Size(64, 13)
        Me.lbl_Order_modifydate.TabIndex = 14
        Me.lbl_Order_modifydate.Text = "Modify Date"
        '
        'obj_Order_modifydate
        '
        Me.obj_Order_modifydate.Location = New System.Drawing.Point(123, 86)
        Me.obj_Order_modifydate.Name = "obj_Order_modifydate"
        Me.obj_Order_modifydate.ReadOnly = True
        Me.obj_Order_modifydate.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_modifydate.TabIndex = 41
        '
        'lbl_Order_modifyby
        '
        Me.lbl_Order_modifyby.AutoSize = True
        Me.lbl_Order_modifyby.Location = New System.Drawing.Point(17, 64)
        Me.lbl_Order_modifyby.Name = "lbl_Order_modifyby"
        Me.lbl_Order_modifyby.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Order_modifyby.TabIndex = 11
        Me.lbl_Order_modifyby.Text = "Modify By"
        '
        'obj_Order_modifyby
        '
        Me.obj_Order_modifyby.Location = New System.Drawing.Point(123, 65)
        Me.obj_Order_modifyby.Name = "obj_Order_modifyby"
        Me.obj_Order_modifyby.ReadOnly = True
        Me.obj_Order_modifyby.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_modifyby.TabIndex = 40
        '
        'lbl_Order_createdate
        '
        Me.lbl_Order_createdate.AutoSize = True
        Me.lbl_Order_createdate.Location = New System.Drawing.Point(17, 43)
        Me.lbl_Order_createdate.Name = "lbl_Order_createdate"
        Me.lbl_Order_createdate.Size = New System.Drawing.Size(64, 13)
        Me.lbl_Order_createdate.TabIndex = 12
        Me.lbl_Order_createdate.Text = "Create Date"
        '
        'obj_Order_createdate
        '
        Me.obj_Order_createdate.Location = New System.Drawing.Point(123, 44)
        Me.obj_Order_createdate.Name = "obj_Order_createdate"
        Me.obj_Order_createdate.ReadOnly = True
        Me.obj_Order_createdate.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_createdate.TabIndex = 39
        '
        'lbl_Order_createby
        '
        Me.lbl_Order_createby.AutoSize = True
        Me.lbl_Order_createby.Location = New System.Drawing.Point(17, 22)
        Me.lbl_Order_createby.Name = "lbl_Order_createby"
        Me.lbl_Order_createby.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Order_createby.TabIndex = 13
        Me.lbl_Order_createby.Text = "Create By"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.obj_order_note)
        Me.PnlDataFooter.Controls.Add(Me.Label14)
        Me.PnlDataFooter.Controls.Add(Me.Panel1)
        Me.PnlDataFooter.Controls.Add(Me.lbl_createby)
        Me.PnlDataFooter.Controls.Add(Me.obj_Order_canceled)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 356)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(741, 129)
        Me.PnlDataFooter.TabIndex = 100
        '
        'obj_order_note
        '
        Me.obj_order_note.Location = New System.Drawing.Point(12, 27)
        Me.obj_order_note.Multiline = True
        Me.obj_order_note.Name = "obj_order_note"
        Me.obj_order_note.Size = New System.Drawing.Size(482, 66)
        Me.obj_order_note.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 146
        Me.Label14.Text = "Note"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MistyRose
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.calc_Order_GTotal)
        Me.Panel1.Controls.Add(Me.calc_Order_PPN)
        Me.Panel1.Controls.Add(Me.calc_Order_PPH)
        Me.Panel1.Controls.Add(Me.calc_Order_subtotal)
        Me.Panel1.Controls.Add(Me.lbl_Order_pph_percent)
        Me.Panel1.Controls.Add(Me.lbl_Order_ppn_percent)
        Me.Panel1.Controls.Add(Me.obj_Order_discount)
        Me.Panel1.Controls.Add(Me.lbl_order_discount)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(511, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 129)
        Me.Panel1.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Sub Total"
        '
        'calc_Order_GTotal
        '
        Me.calc_Order_GTotal.BackColor = System.Drawing.Color.PapayaWhip
        Me.calc_Order_GTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calc_Order_GTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.calc_Order_GTotal.Location = New System.Drawing.Point(25, 92)
        Me.calc_Order_GTotal.Name = "calc_Order_GTotal"
        Me.calc_Order_GTotal.ReadOnly = True
        Me.calc_Order_GTotal.Size = New System.Drawing.Size(195, 24)
        Me.calc_Order_GTotal.TabIndex = 37
        Me.calc_Order_GTotal.TabStop = False
        Me.calc_Order_GTotal.Text = "9,999,999,999.99"
        Me.calc_Order_GTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'calc_Order_PPN
        '
        Me.calc_Order_PPN.Location = New System.Drawing.Point(115, 71)
        Me.calc_Order_PPN.Name = "calc_Order_PPN"
        Me.calc_Order_PPN.ReadOnly = True
        Me.calc_Order_PPN.Size = New System.Drawing.Size(105, 20)
        Me.calc_Order_PPN.TabIndex = 35
        Me.calc_Order_PPN.TabStop = False
        Me.calc_Order_PPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'calc_Order_PPH
        '
        Me.calc_Order_PPH.Location = New System.Drawing.Point(115, 49)
        Me.calc_Order_PPH.Name = "calc_Order_PPH"
        Me.calc_Order_PPH.ReadOnly = True
        Me.calc_Order_PPH.Size = New System.Drawing.Size(105, 20)
        Me.calc_Order_PPH.TabIndex = 34
        Me.calc_Order_PPH.TabStop = False
        Me.calc_Order_PPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'calc_Order_subtotal
        '
        Me.calc_Order_subtotal.Location = New System.Drawing.Point(115, 5)
        Me.calc_Order_subtotal.Name = "calc_Order_subtotal"
        Me.calc_Order_subtotal.ReadOnly = True
        Me.calc_Order_subtotal.Size = New System.Drawing.Size(105, 20)
        Me.calc_Order_subtotal.TabIndex = 31
        Me.calc_Order_subtotal.TabStop = False
        Me.calc_Order_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Order_pph_percent
        '
        Me.lbl_Order_pph_percent.AutoSize = True
        Me.lbl_Order_pph_percent.Location = New System.Drawing.Point(16, 52)
        Me.lbl_Order_pph_percent.Name = "lbl_Order_pph_percent"
        Me.lbl_Order_pph_percent.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Order_pph_percent.TabIndex = 29
        Me.lbl_Order_pph_percent.Text = "PPH"
        '
        'lbl_Order_ppn_percent
        '
        Me.lbl_Order_ppn_percent.AutoSize = True
        Me.lbl_Order_ppn_percent.Location = New System.Drawing.Point(16, 74)
        Me.lbl_Order_ppn_percent.Name = "lbl_Order_ppn_percent"
        Me.lbl_Order_ppn_percent.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Order_ppn_percent.TabIndex = 28
        Me.lbl_Order_ppn_percent.Text = "PPN"
        '
        'obj_Order_discount
        '
        Me.obj_Order_discount.Location = New System.Drawing.Point(115, 27)
        Me.obj_Order_discount.Name = "obj_Order_discount"
        Me.obj_Order_discount.Size = New System.Drawing.Size(105, 20)
        Me.obj_Order_discount.TabIndex = 16
        Me.obj_Order_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_order_discount
        '
        Me.lbl_order_discount.AutoSize = True
        Me.lbl_order_discount.Location = New System.Drawing.Point(16, 30)
        Me.lbl_order_discount.Name = "lbl_order_discount"
        Me.lbl_order_discount.Size = New System.Drawing.Size(49, 13)
        Me.lbl_order_discount.TabIndex = 27
        Me.lbl_order_discount.Text = "Discount"
        '
        'lbl_createby
        '
        Me.lbl_createby.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_createby.Location = New System.Drawing.Point(8, 96)
        Me.lbl_createby.Name = "lbl_createby"
        Me.lbl_createby.Size = New System.Drawing.Size(384, 17)
        Me.lbl_createby.TabIndex = 108
        Me.lbl_createby.Text = "createby"
        Me.lbl_createby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'obj_Order_canceled
        '
        Me.obj_Order_canceled.AutoSize = True
        Me.obj_Order_canceled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_Order_canceled.Location = New System.Drawing.Point(394, 96)
        Me.obj_Order_canceled.Name = "obj_Order_canceled"
        Me.obj_Order_canceled.Size = New System.Drawing.Size(100, 17)
        Me.obj_Order_canceled.TabIndex = 15
        Me.obj_Order_canceled.Text = "Order Canceled"
        Me.obj_Order_canceled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_Order_canceled.UseVisualStyleBackColor = True
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.Lavender
        Me.PnlDataMaster.Controls.Add(Me.Label4)
        Me.PnlDataMaster.Controls.Add(Me.obj_Order_descr)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Order_descr)
        Me.PnlDataMaster.Controls.Add(Me.btn_FindBudget)
        Me.PnlDataMaster.Controls.Add(Me.cbo_Budget_name)
        Me.PnlDataMaster.Controls.Add(Me.cbo_Rekanan_contact)
        Me.PnlDataMaster.Controls.Add(Me.cbo_Rekanan_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_cp)
        Me.PnlDataMaster.Controls.Add(Me.obj_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Budget_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Budget_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 83)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(741, 91)
        Me.PnlDataMaster.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(455, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'obj_Order_descr
        '
        Me.obj_Order_descr.Location = New System.Drawing.Point(108, 50)
        Me.obj_Order_descr.Multiline = True
        Me.obj_Order_descr.Name = "obj_Order_descr"
        Me.obj_Order_descr.Size = New System.Drawing.Size(328, 35)
        Me.obj_Order_descr.TabIndex = 12
        '
        'lbl_Order_descr
        '
        Me.lbl_Order_descr.AutoSize = True
        Me.lbl_Order_descr.Location = New System.Drawing.Point(10, 53)
        Me.lbl_Order_descr.Name = "lbl_Order_descr"
        Me.lbl_Order_descr.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Order_descr.TabIndex = 144
        Me.lbl_Order_descr.Text = "Description"
        '
        'btn_FindBudget
        '
        Me.btn_FindBudget.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_FindBudget.Location = New System.Drawing.Point(73, 26)
        Me.btn_FindBudget.Name = "btn_FindBudget"
        Me.btn_FindBudget.Size = New System.Drawing.Size(25, 21)
        Me.btn_FindBudget.TabIndex = 139
        Me.btn_FindBudget.Text = "..."
        Me.btn_FindBudget.UseVisualStyleBackColor = False
        Me.btn_FindBudget.Visible = False
        '
        'cbo_Budget_name
        '
        Me.cbo_Budget_name.BackColor = System.Drawing.SystemColors.Window
        Me.cbo_Budget_name.FormattingEnabled = True
        Me.cbo_Budget_name.ItemHeight = 13
        Me.cbo_Budget_name.Location = New System.Drawing.Point(150, 28)
        Me.cbo_Budget_name.Name = "cbo_Budget_name"
        Me.cbo_Budget_name.Size = New System.Drawing.Size(286, 21)
        Me.cbo_Budget_name.TabIndex = 11
        '
        'cbo_Rekanan_contact
        '
        Me.cbo_Rekanan_contact.Enabled = False
        Me.cbo_Rekanan_contact.FormattingEnabled = True
        Me.cbo_Rekanan_contact.Location = New System.Drawing.Point(511, 6)
        Me.cbo_Rekanan_contact.Name = "cbo_Rekanan_contact"
        Me.cbo_Rekanan_contact.Size = New System.Drawing.Size(210, 21)
        Me.cbo_Rekanan_contact.TabIndex = 9
        '
        'cbo_Rekanan_name
        '
        Me.cbo_Rekanan_name.FormattingEnabled = True
        Me.cbo_Rekanan_name.Location = New System.Drawing.Point(108, 6)
        Me.cbo_Rekanan_name.Name = "cbo_Rekanan_name"
        Me.cbo_Rekanan_name.Size = New System.Drawing.Size(328, 21)
        Me.cbo_Rekanan_name.TabIndex = 8
        '
        'lbl_cp
        '
        Me.lbl_cp.AutoSize = True
        Me.lbl_cp.Location = New System.Drawing.Point(455, 9)
        Me.lbl_cp.Name = "lbl_cp"
        Me.lbl_cp.Size = New System.Drawing.Size(21, 13)
        Me.lbl_cp.TabIndex = 143
        Me.lbl_cp.Text = "CP"
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(117, 6)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.ReadOnly = True
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(52, 20)
        Me.obj_Rekanan_id.TabIndex = 142
        '
        'lbl_rekanan_id
        '
        Me.lbl_rekanan_id.AutoSize = True
        Me.lbl_rekanan_id.Location = New System.Drawing.Point(11, 9)
        Me.lbl_rekanan_id.Name = "lbl_rekanan_id"
        Me.lbl_rekanan_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_rekanan_id.TabIndex = 140
        Me.lbl_rekanan_id.Text = "Vendor"
        '
        'obj_Budget_id
        '
        Me.obj_Budget_id.Location = New System.Drawing.Point(108, 28)
        Me.obj_Budget_id.Name = "obj_Budget_id"
        Me.obj_Budget_id.Size = New System.Drawing.Size(40, 20)
        Me.obj_Budget_id.TabIndex = 10
        '
        'lbl_Budget_id
        '
        Me.lbl_Budget_id.AutoSize = True
        Me.lbl_Budget_id.Location = New System.Drawing.Point(11, 30)
        Me.lbl_Budget_id.Name = "lbl_Budget_id"
        Me.lbl_Budget_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Budget_id.TabIndex = 141
        Me.lbl_Budget_id.Text = "Budget"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel2.Controls.Add(Me.cbo_Deptname)
        Me.Panel2.Controls.Add(Me.lbl_Dept_name)
        Me.Panel2.Controls.Add(Me.gboRevision)
        Me.Panel2.Controls.Add(Me.dtp_order_date)
        Me.Panel2.Controls.Add(Me.cbo_Periode_id)
        Me.Panel2.Controls.Add(Me.lbl_Periode_id)
        Me.Panel2.Controls.Add(Me.obj_Order_id)
        Me.Panel2.Controls.Add(Me.lbl_order_date)
        Me.Panel2.Controls.Add(Me.lbl_Order_id)
        Me.Panel2.Controls.Add(Me.obj_Request_id)
        Me.Panel2.Controls.Add(Me.lbl_Request_id)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(741, 80)
        Me.Panel2.TabIndex = 96
        '
        'cbo_Deptname
        '
        Me.cbo_Deptname.FormattingEnabled = True
        Me.cbo_Deptname.Location = New System.Drawing.Point(108, 52)
        Me.cbo_Deptname.Name = "cbo_Deptname"
        Me.cbo_Deptname.Size = New System.Drawing.Size(328, 21)
        Me.cbo_Deptname.TabIndex = 80
        '
        'lbl_Dept_name
        '
        Me.lbl_Dept_name.AutoSize = True
        Me.lbl_Dept_name.Location = New System.Drawing.Point(11, 55)
        Me.lbl_Dept_name.Name = "lbl_Dept_name"
        Me.lbl_Dept_name.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Dept_name.TabIndex = 81
        Me.lbl_Dept_name.Text = "Department"
        '
        'gboRevision
        '
        Me.gboRevision.BackColor = System.Drawing.Color.Transparent
        Me.gboRevision.Controls.Add(Me.Label3)
        Me.gboRevision.Controls.Add(Me.dtp_order_revdate)
        Me.gboRevision.Controls.Add(Me.lbl_Order_revdesc)
        Me.gboRevision.Controls.Add(Me.obj_Order_revno)
        Me.gboRevision.Controls.Add(Me.lbl_Order_revno)
        Me.gboRevision.Controls.Add(Me.obj_order_revdesc)
        Me.gboRevision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboRevision.Location = New System.Drawing.Point(446, 3)
        Me.gboRevision.Name = "gboRevision"
        Me.gboRevision.Size = New System.Drawing.Size(287, 70)
        Me.gboRevision.TabIndex = 79
        Me.gboRevision.TabStop = False
        Me.gboRevision.Text = "Revision"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(134, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Date"
        '
        'dtp_order_revdate
        '
        Me.dtp_order_revdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_order_revdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_order_revdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_order_revdate.Location = New System.Drawing.Point(188, 17)
        Me.dtp_order_revdate.Name = "dtp_order_revdate"
        Me.dtp_order_revdate.Size = New System.Drawing.Size(85, 20)
        Me.dtp_order_revdate.TabIndex = 6
        '
        'lbl_Order_revdesc
        '
        Me.lbl_Order_revdesc.AutoSize = True
        Me.lbl_Order_revdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_revdesc.Location = New System.Drawing.Point(9, 45)
        Me.lbl_Order_revdesc.Name = "lbl_Order_revdesc"
        Me.lbl_Order_revdesc.Size = New System.Drawing.Size(32, 13)
        Me.lbl_Order_revdesc.TabIndex = 100
        Me.lbl_Order_revdesc.Text = "Desc"
        '
        'obj_Order_revno
        '
        Me.obj_Order_revno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Order_revno.Location = New System.Drawing.Point(63, 17)
        Me.obj_Order_revno.Name = "obj_Order_revno"
        Me.obj_Order_revno.Size = New System.Drawing.Size(58, 20)
        Me.obj_Order_revno.TabIndex = 5
        '
        'lbl_Order_revno
        '
        Me.lbl_Order_revno.AutoSize = True
        Me.lbl_Order_revno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_revno.Location = New System.Drawing.Point(9, 20)
        Me.lbl_Order_revno.Name = "lbl_Order_revno"
        Me.lbl_Order_revno.Size = New System.Drawing.Size(21, 13)
        Me.lbl_Order_revno.TabIndex = 40
        Me.lbl_Order_revno.Text = "No"
        '
        'obj_order_revdesc
        '
        Me.obj_order_revdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_order_revdesc.Location = New System.Drawing.Point(63, 42)
        Me.obj_order_revdesc.Name = "obj_order_revdesc"
        Me.obj_order_revdesc.Size = New System.Drawing.Size(210, 20)
        Me.obj_order_revdesc.TabIndex = 7
        '
        'dtp_order_date
        '
        Me.dtp_order_date.CustomFormat = "dd/MM/yyyy"
        Me.dtp_order_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_order_date.Location = New System.Drawing.Point(301, 30)
        Me.dtp_order_date.Name = "dtp_order_date"
        Me.dtp_order_date.Size = New System.Drawing.Size(135, 20)
        Me.dtp_order_date.TabIndex = 4
        '
        'cbo_Periode_id
        '
        Me.cbo_Periode_id.FormattingEnabled = True
        Me.cbo_Periode_id.Location = New System.Drawing.Point(301, 8)
        Me.cbo_Periode_id.Name = "cbo_Periode_id"
        Me.cbo_Periode_id.Size = New System.Drawing.Size(135, 21)
        Me.cbo_Periode_id.TabIndex = 2
        '
        'lbl_Periode_id
        '
        Me.lbl_Periode_id.AutoSize = True
        Me.lbl_Periode_id.Location = New System.Drawing.Point(243, 10)
        Me.lbl_Periode_id.Name = "lbl_Periode_id"
        Me.lbl_Periode_id.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Periode_id.TabIndex = 76
        Me.lbl_Periode_id.Text = "Periode"
        '
        'obj_Order_id
        '
        Me.obj_Order_id.Location = New System.Drawing.Point(108, 7)
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.Size = New System.Drawing.Size(126, 20)
        Me.obj_Order_id.TabIndex = 1
        '
        'lbl_order_date
        '
        Me.lbl_order_date.AutoSize = True
        Me.lbl_order_date.Location = New System.Drawing.Point(243, 33)
        Me.lbl_order_date.Name = "lbl_order_date"
        Me.lbl_order_date.Size = New System.Drawing.Size(30, 13)
        Me.lbl_order_date.TabIndex = 74
        Me.lbl_order_date.Text = "Date"
        '
        'lbl_Order_id
        '
        Me.lbl_Order_id.AutoSize = True
        Me.lbl_Order_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_id.Location = New System.Drawing.Point(11, 11)
        Me.lbl_Order_id.Name = "lbl_Order_id"
        Me.lbl_Order_id.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Order_id.TabIndex = 75
        Me.lbl_Order_id.Text = "Order ID"
        '
        'obj_Request_id
        '
        Me.obj_Request_id.Location = New System.Drawing.Point(108, 29)
        Me.obj_Request_id.Name = "obj_Request_id"
        Me.obj_Request_id.Size = New System.Drawing.Size(126, 20)
        Me.obj_Request_id.TabIndex = 3
        '
        'lbl_Request_id
        '
        Me.lbl_Request_id.AutoSize = True
        Me.lbl_Request_id.Location = New System.Drawing.Point(11, 33)
        Me.lbl_Request_id.Name = "lbl_Request_id"
        Me.lbl_Request_id.Size = New System.Drawing.Size(61, 13)
        Me.lbl_Request_id.TabIndex = 71
        Me.lbl_Request_id.Text = "Request ID"
        '
        'uiTrnMaintenanceOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.Name = "uiTrnMaintenanceOrder"
        Me.Size = New System.Drawing.Size(764, 550)
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvTrnOrderdetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_PaymReq.ResumeLayout(False)
        CType(Me.DgvTrnOrderPaymReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_PurchReq.ResumeLayout(False)
        CType(Me.dgvTrnMaintReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Dlvr.ResumeLayout(False)
        Me.ftabDataDetil_Dlvr.PerformLayout()
        Me.ftabDataDetil_Sign.ResumeLayout(False)
        Me.ftabDataDetil_Sign.PerformLayout()
        Me.ftabDataDetil_Additional.ResumeLayout(False)
        Me.ftabDataDetil_Additional.PerformLayout()
        Me.ftabDataDetil_Budget.ResumeLayout(False)
        Me.ftabDataDetil_Budget.PerformLayout()
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.PnlDataFooter.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gboRevision.ResumeLayout(False)
        Me.gboRevision.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlatTabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents DgvTrnOrder As System.Windows.Forms.DataGridView
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchPeriode As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchPeriode As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSearchOrderID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchOrderID As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchRekanan As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchBudgetCode As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchBudgetCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchLast2Periode As System.Windows.Forms.CheckBox
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents gboRevision As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_order_revdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Order_revdesc As System.Windows.Forms.Label
    Friend WithEvents obj_Order_revno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_revno As System.Windows.Forms.Label
    Friend WithEvents obj_order_revdesc As System.Windows.Forms.TextBox
    Friend WithEvents dtp_order_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_Periode_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Periode_id As System.Windows.Forms.Label
    Friend WithEvents obj_Order_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_order_date As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_id As System.Windows.Forms.Label
    Friend WithEvents obj_Request_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Request_id As System.Windows.Forms.Label
    Friend WithEvents obj_Order_descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_descr As System.Windows.Forms.Label
    Friend WithEvents btn_FindBudget As System.Windows.Forms.Button
    Friend WithEvents cbo_Budget_name As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Rekanan_contact As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Rekanan_name As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_cp As System.Windows.Forms.Label
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rekanan_id As System.Windows.Forms.Label
    Friend WithEvents obj_Budget_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Budget_id As System.Windows.Forms.Label
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents obj_order_note As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents calc_Order_GTotal As System.Windows.Forms.TextBox
    Friend WithEvents calc_Order_PPN As System.Windows.Forms.TextBox
    Friend WithEvents calc_Order_PPH As System.Windows.Forms.TextBox
    Friend WithEvents calc_Order_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_pph_percent As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_ppn_percent As System.Windows.Forms.Label
    Friend WithEvents obj_Order_discount As System.Windows.Forms.TextBox
    Friend WithEvents lbl_order_discount As System.Windows.Forms.Label
    Friend WithEvents lbl_createby As System.Windows.Forms.Label
    Friend WithEvents obj_Order_canceled As System.Windows.Forms.CheckBox
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnOrderdetil As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_PaymReq As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnOrderPaymReq As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_PurchReq As System.Windows.Forms.TabPage
    Friend WithEvents dgvTrnMaintReq As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_Dlvr As System.Windows.Forms.TabPage
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents obj_order_dlvrtelp As System.Windows.Forms.TextBox
    Friend WithEvents order_dlvrfax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_order_dlvraddr1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents obj_order_dlvrname As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvraddr2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents obj_order_dlvraddr3 As System.Windows.Forms.TextBox
    Friend WithEvents ftabDataDetil_Sign As System.Windows.Forms.TabPage
    Friend WithEvents obj_Order_authname As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_authposition As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_authname As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Additional As System.Windows.Forms.TabPage
    Friend WithEvents lbl_Order_insurancecost As System.Windows.Forms.Label
    Friend WithEvents obj_Order_transportationcost As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_transportationcost As System.Windows.Forms.Label
    Friend WithEvents obj_Order_insurancecost As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_operatorcost As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_operatorcost As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_othercost As System.Windows.Forms.Label
    Friend WithEvents obj_Order_othercost As System.Windows.Forms.TextBox
    Friend WithEvents ftabDataDetil_Budget As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRO_plus_PO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAllPOAmount_perBudget As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckAll_OrderAmt As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAllROAmount_perBudget As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Budget_amount As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_BgtAmt As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Info As System.Windows.Forms.TabPage
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_source As System.Windows.Forms.TextBox
    Friend WithEvents txt_channel_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_usrname As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_Source As System.Windows.Forms.Label
    Friend WithEvents lbl_Channel As System.Windows.Forms.Label
    Friend WithEvents lbl_Login As System.Windows.Forms.Label
    Friend WithEvents cbo_Old_program_name As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Old_program_name As System.Windows.Forms.Label
    Friend WithEvents obj_Old_program_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_isprinted As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Order_createby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_modifydate As System.Windows.Forms.Label
    Friend WithEvents obj_Order_modifydate As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_modifyby As System.Windows.Forms.Label
    Friend WithEvents obj_Order_modifyby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_createdate As System.Windows.Forms.Label
    Friend WithEvents obj_Order_createdate As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_createby As System.Windows.Forms.Label
    Friend WithEvents cbo_Deptname As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Dept_name As System.Windows.Forms.Label
    Friend WithEvents lbl_Ordertype_id As System.Windows.Forms.Label
    Friend WithEvents obj_Ordertype_id As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class

