<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPurchaseOrder3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnPurchaseOrder3))
        Me.FlatTabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnOrder = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.TxtCanceled = New System.Windows.Forms.Label
        Me.Txt_Disapp = New System.Windows.Forms.Label
        Me.Txt_appKadept = New System.Windows.Forms.Label
        Me.lblNew = New System.Windows.Forms.Label
        Me.TxtNew = New System.Windows.Forms.Label
        Me.lblCanceled = New System.Windows.Forms.Label
        Me.lbl_disApp = New System.Windows.Forms.Label
        Me.lbl_appKadiv = New System.Windows.Forms.Label
        Me.lblTotalRows = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.rekananidtxt = New System.Windows.Forms.TextBox
        Me.btnVendor = New System.Windows.Forms.Button
        Me.chkSrchStatus = New System.Windows.Forms.CheckBox
        Me.cboSearchStatus = New System.Windows.Forms.ComboBox
        Me.cboSearchApproved = New System.Windows.Forms.ComboBox
        Me.chkSearchApproved = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudSearchRowLimit = New System.Windows.Forms.NumericUpDown
        Me.txtSearchBudgetCode = New System.Windows.Forms.TextBox
        Me.chkSearchBudgetCode = New System.Windows.Forms.CheckBox
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox
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
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblProgType = New System.Windows.Forms.Label
        Me.btnDelDesc = New System.Windows.Forms.Button
        Me.btnAddDesc = New System.Windows.Forms.Button
        Me.btnAddItem = New System.Windows.Forms.Button
        Me.ftabDataDetil_PurchReq = New System.Windows.Forms.TabPage
        Me.DgvTrnRequestdetil = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_PaymReq = New System.Windows.Forms.TabPage
        Me.DgvTrnOrderPaymReq = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Dlvr = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.obj_order_dlvrhp = New System.Windows.Forms.TextBox
        Me.obj_order_dlvrtelp = New System.Windows.Forms.TextBox
        Me.obj_order_dlvrfax = New System.Windows.Forms.TextBox
        Me.obj_order_dlvraddr1 = New System.Windows.Forms.TextBox
        Me.obj_order_dlvrname = New System.Windows.Forms.TextBox
        Me.obj_order_dlvraddr2 = New System.Windows.Forms.TextBox
        Me.obj_order_dlvraddr3 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.ftabDataDetil_Sign = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.obj_Order_authname = New System.Windows.Forms.TextBox
        Me.obj_Order_authposition = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.obj_Order_authposition2 = New System.Windows.Forms.TextBox
        Me.chkApproved = New System.Windows.Forms.CheckBox
        Me.obj_Order_authname2 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage
        Me.cbo_old_program_name = New System.Windows.Forms.ComboBox
        Me.cbo_budget_amount = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.obj_appstatus = New System.Windows.Forms.TextBox
        Me.obj_appby = New System.Windows.Forms.TextBox
        Me.obj_appdate = New System.Windows.Forms.TextBox
        Me.obj_Order_createby = New System.Windows.Forms.TextBox
        Me.obj_Order_modifydate = New System.Windows.Forms.TextBox
        Me.obj_Order_modifyby = New System.Windows.Forms.TextBox
        Me.obj_Order_createdate = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.obj_Order_isprinted = New System.Windows.Forms.CheckBox
        Me.lbl_Order_modifydate = New System.Windows.Forms.Label
        Me.lbl_Order_modifyby = New System.Windows.Forms.Label
        Me.lbl_Order_createdate = New System.Windows.Forms.Label
        Me.lbl_Order_createby = New System.Windows.Forms.Label
        Me.ftabDataDetil_Respond = New System.Windows.Forms.TabPage
        Me.dgvtrnBPB = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_DocCirculation = New System.Windows.Forms.TabPage
        Me.DgvDocCirculation = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_InvRec = New System.Windows.Forms.TabPage
        Me.DgvInvReceipt = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Advance = New System.Windows.Forms.TabPage
        Me.dgvAdvance = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Episode = New System.Windows.Forms.TabPage
        Me.dgvepisode = New System.Windows.Forms.DataGridView
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.PnlDataFooter_note = New System.Windows.Forms.Panel
        Me.lblApproved = New System.Windows.Forms.Label
        Me.obj_order_note = New System.Windows.Forms.TextBox
        Me.chkOrder_canceled = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.PnlDataFooter_total = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.calc_Order_GTotal = New System.Windows.Forms.TextBox
        Me.calc_Order_PPN = New System.Windows.Forms.TextBox
        Me.calc_Order_PPH = New System.Windows.Forms.TextBox
        Me.calc_Order_subtotal = New System.Windows.Forms.TextBox
        Me.lbl_Order_pph_percent = New System.Windows.Forms.Label
        Me.lbl_Order_ppn_percent = New System.Windows.Forms.Label
        Me.calc_Order_Discount = New System.Windows.Forms.TextBox
        Me.lbl_order_discount = New System.Windows.Forms.Label
        Me.PnlDataMaster1 = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.dtp_order_setdate = New System.Windows.Forms.DateTimePicker
        Me.mtb_Order_utilizedtimeend = New System.Windows.Forms.MaskedTextBox
        Me.mtb_Order_utilizedtimestart = New System.Windows.Forms.MaskedTextBox
        Me.dtp_Order_utilizeddateend = New System.Windows.Forms.DateTimePicker
        Me.dtp_Order_utilizeddatestart = New System.Windows.Forms.DateTimePicker
        Me.dtp_Order_Dlvrdate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl_Order_descr = New System.Windows.Forms.Label
        Me.chkSingleBudget = New System.Windows.Forms.CheckBox
        Me.obj_Order_descr = New System.Windows.Forms.TextBox
        Me.cbo_Currency = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.obj_Order_intref = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_FindBudget = New System.Windows.Forms.Button
        Me.cbo_Budget_name = New System.Windows.Forms.ComboBox
        Me.cbo_Rekanan_name = New System.Windows.Forms.ComboBox
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox
        Me.lbl_rekanan_id = New System.Windows.Forms.Label
        Me.obj_Budget_id = New System.Windows.Forms.TextBox
        Me.lbl_Budget_id = New System.Windows.Forms.Label
        Me.PnlDataMaster2 = New System.Windows.Forms.Panel
        Me.cbo_Deptname = New System.Windows.Forms.ComboBox
        Me.lbl_Dept_name = New System.Windows.Forms.Label
        Me.gboRevision = New System.Windows.Forms.GroupBox
        Me.dtp_order_revdate = New System.Windows.Forms.DateTimePicker
        Me.obj_order_revdesc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_Order_revdesc = New System.Windows.Forms.Label
        Me.obj_Order_revno = New System.Windows.Forms.TextBox
        Me.lbl_Order_revno = New System.Windows.Forms.Label
        Me.dtp_order_date = New System.Windows.Forms.DateTimePicker
        Me.cbo_Periode_id = New System.Windows.Forms.ComboBox
        Me.lbl_Periode_id = New System.Windows.Forms.Label
        Me.obj_Order_id = New System.Windows.Forms.TextBox
        Me.lbl_order_date = New System.Windows.Forms.Label
        Me.lbl_Order_id = New System.Windows.Forms.Label
        Me.obj_Request_id = New System.Windows.Forms.TextBox
        Me.lbl_Request_id = New System.Windows.Forms.Label
        Me.PnlDataMaster3 = New System.Windows.Forms.Panel
        Me.obj_Order_setlocation = New System.Windows.Forms.TextBox
        Me.obj_Order_utilizedlocation = New System.Windows.Forms.TextBox
        Me.mtb_Order_2 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_Order_3 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_Order_1 = New System.Windows.Forms.MaskedTextBox
        Me.dtp_Order_2 = New System.Windows.Forms.DateTimePicker
        Me.dtp_Order_3 = New System.Windows.Forms.DateTimePicker
        Me.dtp_Order_1 = New System.Windows.Forms.DateTimePicker
        Me.lbl_Order_setdate = New System.Windows.Forms.Label
        Me.lbl_Order_setlocation = New System.Windows.Forms.Label
        Me.lbl_Order_utilizeddatestart = New System.Windows.Forms.Label
        Me.lbl_Order_utilizeddateend = New System.Windows.Forms.Label
        Me.lbl_Order_utilizedlocation = New System.Windows.Forms.Label
        Me.FlatTabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        CType(Me.nudSearchRowLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvTrnOrderdetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.ftabDataDetil_PurchReq.SuspendLayout()
        CType(Me.DgvTrnRequestdetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_PaymReq.SuspendLayout()
        CType(Me.DgvTrnOrderPaymReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Dlvr.SuspendLayout()
        Me.ftabDataDetil_Sign.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ftabDataDetil_Info.SuspendLayout()
        Me.ftabDataDetil_Respond.SuspendLayout()
        CType(Me.dgvtrnBPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_DocCirculation.SuspendLayout()
        CType(Me.DgvDocCirculation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_InvRec.SuspendLayout()
        CType(Me.DgvInvReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Advance.SuspendLayout()
        CType(Me.dgvAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Episode.SuspendLayout()
        CType(Me.dgvepisode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDataFooter.SuspendLayout()
        Me.PnlDataFooter_note.SuspendLayout()
        Me.PnlDataFooter_total.SuspendLayout()
        Me.PnlDataMaster1.SuspendLayout()
        Me.PnlDataMaster2.SuspendLayout()
        Me.gboRevision.SuspendLayout()
        Me.PnlDataMaster3.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlatTabMain
        '
        Me.FlatTabMain.Controls.Add(Me.ftabMain_List)
        Me.FlatTabMain.Controls.Add(Me.ftabMain_Data)
        Me.FlatTabMain.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.PnlDfFooter.Controls.Add(Me.TxtCanceled)
        Me.PnlDfFooter.Controls.Add(Me.Txt_Disapp)
        Me.PnlDfFooter.Controls.Add(Me.Txt_appKadept)
        Me.PnlDfFooter.Controls.Add(Me.lblNew)
        Me.PnlDfFooter.Controls.Add(Me.TxtNew)
        Me.PnlDfFooter.Controls.Add(Me.lblCanceled)
        Me.PnlDfFooter.Controls.Add(Me.lbl_disApp)
        Me.PnlDfFooter.Controls.Add(Me.lbl_appKadiv)
        Me.PnlDfFooter.Controls.Add(Me.lblTotalRows)
        Me.PnlDfFooter.Controls.Add(Me.Label18)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(741, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'TxtCanceled
        '
        Me.TxtCanceled.AutoSize = True
        Me.TxtCanceled.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.TxtCanceled.Location = New System.Drawing.Point(669, 16)
        Me.TxtCanceled.Name = "TxtCanceled"
        Me.TxtCanceled.Size = New System.Drawing.Size(51, 13)
        Me.TxtCanceled.TabIndex = 52
        Me.TxtCanceled.Text = "Canceled"
        '
        'Txt_Disapp
        '
        Me.Txt_Disapp.AutoSize = True
        Me.Txt_Disapp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.Txt_Disapp.Location = New System.Drawing.Point(554, 16)
        Me.Txt_Disapp.Name = "Txt_Disapp"
        Me.Txt_Disapp.Size = New System.Drawing.Size(70, 13)
        Me.Txt_Disapp.TabIndex = 51
        Me.Txt_Disapp.Text = "Disapproved "
        '
        'Txt_appKadept
        '
        Me.Txt_appKadept.AutoSize = True
        Me.Txt_appKadept.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.Txt_appKadept.Location = New System.Drawing.Point(455, 16)
        Me.Txt_appKadept.Name = "Txt_appKadept"
        Me.Txt_appKadept.Size = New System.Drawing.Size(56, 13)
        Me.Txt_appKadept.TabIndex = 50
        Me.Txt_appKadept.Text = "Approved "
        '
        'lblNew
        '
        Me.lblNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNew.Location = New System.Drawing.Point(371, 14)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(15, 15)
        Me.lblNew.TabIndex = 49
        '
        'TxtNew
        '
        Me.TxtNew.AutoSize = True
        Me.TxtNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNew.Location = New System.Drawing.Point(392, 16)
        Me.TxtNew.Name = "TxtNew"
        Me.TxtNew.Size = New System.Drawing.Size(28, 13)
        Me.TxtNew.TabIndex = 48
        Me.TxtNew.Text = "New"
        '
        'lblCanceled
        '
        Me.lblCanceled.BackColor = System.Drawing.Color.LightYellow
        Me.lblCanceled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCanceled.Location = New System.Drawing.Point(533, 14)
        Me.lblCanceled.Name = "lblCanceled"
        Me.lblCanceled.Size = New System.Drawing.Size(15, 15)
        Me.lblCanceled.TabIndex = 47
        '
        'lbl_disApp
        '
        Me.lbl_disApp.BackColor = System.Drawing.Color.MistyRose
        Me.lbl_disApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_disApp.Location = New System.Drawing.Point(648, 14)
        Me.lbl_disApp.Name = "lbl_disApp"
        Me.lbl_disApp.Size = New System.Drawing.Size(15, 15)
        Me.lbl_disApp.TabIndex = 46
        '
        'lbl_appKadiv
        '
        Me.lbl_appKadiv.BackColor = System.Drawing.Color.LightCyan
        Me.lbl_appKadiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_appKadiv.Location = New System.Drawing.Point(434, 14)
        Me.lbl_appKadiv.Name = "lbl_appKadiv"
        Me.lbl_appKadiv.Size = New System.Drawing.Size(15, 15)
        Me.lbl_appKadiv.TabIndex = 45
        '
        'lblTotalRows
        '
        Me.lblTotalRows.Location = New System.Drawing.Point(76, 12)
        Me.lblTotalRows.Name = "lblTotalRows"
        Me.lblTotalRows.Size = New System.Drawing.Size(83, 14)
        Me.lblTotalRows.TabIndex = 1
        Me.lblTotalRows.Text = "0 Row(s)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 14)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Total Data = "
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.rekananidtxt)
        Me.PnlDfSearch.Controls.Add(Me.btnVendor)
        Me.PnlDfSearch.Controls.Add(Me.chkSrchStatus)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchStatus)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchApproved)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchApproved)
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.nudSearchRowLimit)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchBudgetCode)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchBudgetCode)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRekanan)
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
        'rekananidtxt
        '
        Me.rekananidtxt.Location = New System.Drawing.Point(503, 62)
        Me.rekananidtxt.MaxLength = 4
        Me.rekananidtxt.Name = "rekananidtxt"
        Me.rekananidtxt.Size = New System.Drawing.Size(85, 20)
        Me.rekananidtxt.TabIndex = 88
        '
        'btnVendor
        '
        Me.btnVendor.Location = New System.Drawing.Point(594, 61)
        Me.btnVendor.Name = "btnVendor"
        Me.btnVendor.Size = New System.Drawing.Size(30, 23)
        Me.btnVendor.TabIndex = 87
        Me.btnVendor.Text = "..."
        Me.btnVendor.UseVisualStyleBackColor = True
        '
        'chkSrchStatus
        '
        Me.chkSrchStatus.AutoSize = True
        Me.chkSrchStatus.Location = New System.Drawing.Point(395, 88)
        Me.chkSrchStatus.Name = "chkSrchStatus"
        Me.chkSrchStatus.Size = New System.Drawing.Size(57, 18)
        Me.chkSrchStatus.TabIndex = 86
        Me.chkSrchStatus.Text = "Status"
        Me.chkSrchStatus.UseVisualStyleBackColor = True
        '
        'cboSearchStatus
        '
        Me.cboSearchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchStatus.FormattingEnabled = True
        Me.cboSearchStatus.Location = New System.Drawing.Point(503, 86)
        Me.cboSearchStatus.Name = "cboSearchStatus"
        Me.cboSearchStatus.Size = New System.Drawing.Size(121, 22)
        Me.cboSearchStatus.TabIndex = 85
        '
        'cboSearchApproved
        '
        Me.cboSearchApproved.FormattingEnabled = True
        Me.cboSearchApproved.Items.AddRange(New Object() {"Approved", "Not Approved, Yet"})
        Me.cboSearchApproved.Location = New System.Drawing.Point(503, 13)
        Me.cboSearchApproved.Name = "cboSearchApproved"
        Me.cboSearchApproved.Size = New System.Drawing.Size(196, 22)
        Me.cboSearchApproved.TabIndex = 84
        '
        'chkSearchApproved
        '
        Me.chkSearchApproved.AutoSize = True
        Me.chkSearchApproved.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSearchApproved.Location = New System.Drawing.Point(395, 15)
        Me.chkSearchApproved.Name = "chkSearchApproved"
        Me.chkSearchApproved.Size = New System.Drawing.Size(104, 18)
        Me.chkSearchApproved.TabIndex = 83
        Me.chkSearchApproved.Text = "Approval Status"
        Me.chkSearchApproved.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Row Limit"
        '
        'nudSearchRowLimit
        '
        Me.nudSearchRowLimit.Location = New System.Drawing.Point(304, 37)
        Me.nudSearchRowLimit.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.nudSearchRowLimit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSearchRowLimit.Name = "nudSearchRowLimit"
        Me.nudSearchRowLimit.Size = New System.Drawing.Size(61, 20)
        Me.nudSearchRowLimit.TabIndex = 37
        Me.nudSearchRowLimit.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'txtSearchBudgetCode
        '
        Me.txtSearchBudgetCode.Location = New System.Drawing.Point(104, 38)
        Me.txtSearchBudgetCode.MaxLength = 4
        Me.txtSearchBudgetCode.Name = "txtSearchBudgetCode"
        Me.txtSearchBudgetCode.Size = New System.Drawing.Size(61, 20)
        Me.txtSearchBudgetCode.TabIndex = 33
        '
        'chkSearchBudgetCode
        '
        Me.chkSearchBudgetCode.AutoSize = True
        Me.chkSearchBudgetCode.Location = New System.Drawing.Point(17, 40)
        Me.chkSearchBudgetCode.Name = "chkSearchBudgetCode"
        Me.chkSearchBudgetCode.Size = New System.Drawing.Size(88, 18)
        Me.chkSearchBudgetCode.TabIndex = 32
        Me.chkSearchBudgetCode.Text = "Budget Code"
        Me.chkSearchBudgetCode.UseVisualStyleBackColor = True
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(395, 62)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(73, 18)
        Me.chkSearchRekanan.TabIndex = 30
        Me.chkSearchRekanan.Text = "Vendor ID"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
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
        Me.txtSearchOrderID.Location = New System.Drawing.Point(104, 61)
        Me.txtSearchOrderID.Multiline = True
        Me.txtSearchOrderID.Name = "txtSearchOrderID"
        Me.txtSearchOrderID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchOrderID.Size = New System.Drawing.Size(261, 45)
        Me.txtSearchOrderID.TabIndex = 27
        '
        'chkSearchOrderID
        '
        Me.chkSearchOrderID.AutoSize = True
        Me.chkSearchOrderID.Location = New System.Drawing.Point(17, 61)
        Me.chkSearchOrderID.Name = "chkSearchOrderID"
        Me.chkSearchOrderID.Size = New System.Drawing.Size(49, 18)
        Me.chkSearchOrderID.TabIndex = 26
        Me.chkSearchOrderID.Text = "ID(s)"
        Me.chkSearchOrderID.UseVisualStyleBackColor = True
        '
        'txtSearchPeriode
        '
        Me.txtSearchPeriode.Location = New System.Drawing.Point(503, 38)
        Me.txtSearchPeriode.MaxLength = 6
        Me.txtSearchPeriode.Name = "txtSearchPeriode"
        Me.txtSearchPeriode.Size = New System.Drawing.Size(61, 20)
        Me.txtSearchPeriode.TabIndex = 25
        '
        'chkSearchPeriode
        '
        Me.chkSearchPeriode.AutoSize = True
        Me.chkSearchPeriode.Location = New System.Drawing.Point(395, 38)
        Me.chkSearchPeriode.Name = "chkSearchPeriode"
        Me.chkSearchPeriode.Size = New System.Drawing.Size(62, 18)
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
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 22)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 15)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 18)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster1)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster2)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster3)
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
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_PurchReq)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_PaymReq)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Dlvr)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Sign)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Info)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Respond)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_DocCirculation)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_InvRec)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Advance)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Episode)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 204)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(741, 148)
        Me.ftabDataDetil.TabIndex = 101
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvTrnOrderdetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.pnlButton)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvTrnOrderdetil
        '
        Me.DgvTrnOrderdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnOrderdetil.Location = New System.Drawing.Point(119, 6)
        Me.DgvTrnOrderdetil.Name = "DgvTrnOrderdetil"
        Me.DgvTrnOrderdetil.Size = New System.Drawing.Size(584, 96)
        Me.DgvTrnOrderdetil.TabIndex = 7
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.Transparent
        Me.pnlButton.Controls.Add(Me.Panel5)
        Me.pnlButton.Controls.Add(Me.btnDelDesc)
        Me.pnlButton.Controls.Add(Me.btnAddDesc)
        Me.pnlButton.Controls.Add(Me.btnAddItem)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(3, 85)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(727, 31)
        Me.pnlButton.TabIndex = 6
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblProgType)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(528, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(199, 31)
        Me.Panel5.TabIndex = 142
        '
        'lblProgType
        '
        Me.lblProgType.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgType.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblProgType.Location = New System.Drawing.Point(19, 5)
        Me.lblProgType.Name = "lblProgType"
        Me.lblProgType.Size = New System.Drawing.Size(177, 20)
        Me.lblProgType.TabIndex = 141
        Me.lblProgType.Text = "tipe program"
        Me.lblProgType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelDesc
        '
        Me.btnDelDesc.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDelDesc.Location = New System.Drawing.Point(155, 4)
        Me.btnDelDesc.Name = "btnDelDesc"
        Me.btnDelDesc.Size = New System.Drawing.Size(75, 23)
        Me.btnDelDesc.TabIndex = 2
        Me.btnDelDesc.Text = "[ -- ] Desc"
        Me.btnDelDesc.UseVisualStyleBackColor = False
        '
        'btnAddDesc
        '
        Me.btnAddDesc.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAddDesc.Location = New System.Drawing.Point(79, 4)
        Me.btnAddDesc.Name = "btnAddDesc"
        Me.btnAddDesc.Size = New System.Drawing.Size(75, 23)
        Me.btnAddDesc.TabIndex = 1
        Me.btnAddDesc.Text = "[ + ] Desc"
        Me.btnAddDesc.UseVisualStyleBackColor = False
        '
        'btnAddItem
        '
        Me.btnAddItem.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAddItem.Location = New System.Drawing.Point(3, 4)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(75, 23)
        Me.btnAddItem.TabIndex = 0
        Me.btnAddItem.Text = "[ + ] Item"
        Me.btnAddItem.UseVisualStyleBackColor = False
        '
        'ftabDataDetil_PurchReq
        '
        Me.ftabDataDetil_PurchReq.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_PurchReq.Controls.Add(Me.DgvTrnRequestdetil)
        Me.ftabDataDetil_PurchReq.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_PurchReq.Name = "ftabDataDetil_PurchReq"
        Me.ftabDataDetil_PurchReq.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_PurchReq.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_PurchReq.TabIndex = 3
        Me.ftabDataDetil_PurchReq.Text = "Purchase Request"
        '
        'DgvTrnRequestdetil
        '
        Me.DgvTrnRequestdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnRequestdetil.Location = New System.Drawing.Point(20, 17)
        Me.DgvTrnRequestdetil.Name = "DgvTrnRequestdetil"
        Me.DgvTrnRequestdetil.Size = New System.Drawing.Size(511, 129)
        Me.DgvTrnRequestdetil.TabIndex = 4
        '
        'ftabDataDetil_PaymReq
        '
        Me.ftabDataDetil_PaymReq.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_PaymReq.Controls.Add(Me.DgvTrnOrderPaymReq)
        Me.ftabDataDetil_PaymReq.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_PaymReq.Name = "ftabDataDetil_PaymReq"
        Me.ftabDataDetil_PaymReq.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_PaymReq.Size = New System.Drawing.Size(733, 119)
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
        'ftabDataDetil_Dlvr
        '
        Me.ftabDataDetil_Dlvr.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label15)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvrhp)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvrtelp)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvrfax)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvraddr1)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvrname)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvraddr2)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.obj_order_dlvraddr3)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label13)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.lblName)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label10)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label11)
        Me.ftabDataDetil_Dlvr.Controls.Add(Me.Label12)
        Me.ftabDataDetil_Dlvr.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Dlvr.Name = "ftabDataDetil_Dlvr"
        Me.ftabDataDetil_Dlvr.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Dlvr.TabIndex = 9
        Me.ftabDataDetil_Dlvr.Text = "Delivery Address"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(417, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 14)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Ext."
        '
        'obj_order_dlvrhp
        '
        Me.obj_order_dlvrhp.Location = New System.Drawing.Point(473, 98)
        Me.obj_order_dlvrhp.Name = "obj_order_dlvrhp"
        Me.obj_order_dlvrhp.Size = New System.Drawing.Size(222, 20)
        Me.obj_order_dlvrhp.TabIndex = 48
        '
        'obj_order_dlvrtelp
        '
        Me.obj_order_dlvrtelp.Location = New System.Drawing.Point(473, 32)
        Me.obj_order_dlvrtelp.Name = "obj_order_dlvrtelp"
        Me.obj_order_dlvrtelp.Size = New System.Drawing.Size(222, 20)
        Me.obj_order_dlvrtelp.TabIndex = 45
        '
        'obj_order_dlvrfax
        '
        Me.obj_order_dlvrfax.Location = New System.Drawing.Point(473, 76)
        Me.obj_order_dlvrfax.Name = "obj_order_dlvrfax"
        Me.obj_order_dlvrfax.Size = New System.Drawing.Size(222, 20)
        Me.obj_order_dlvrfax.TabIndex = 46
        '
        'obj_order_dlvraddr1
        '
        Me.obj_order_dlvraddr1.Location = New System.Drawing.Point(113, 54)
        Me.obj_order_dlvraddr1.Name = "obj_order_dlvraddr1"
        Me.obj_order_dlvraddr1.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvraddr1.TabIndex = 42
        '
        'obj_order_dlvrname
        '
        Me.obj_order_dlvrname.Location = New System.Drawing.Point(113, 32)
        Me.obj_order_dlvrname.Name = "obj_order_dlvrname"
        Me.obj_order_dlvrname.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvrname.TabIndex = 41
        '
        'obj_order_dlvraddr2
        '
        Me.obj_order_dlvraddr2.Location = New System.Drawing.Point(113, 76)
        Me.obj_order_dlvraddr2.Name = "obj_order_dlvraddr2"
        Me.obj_order_dlvraddr2.Size = New System.Drawing.Size(284, 20)
        Me.obj_order_dlvraddr2.TabIndex = 43
        '
        'obj_order_dlvraddr3
        '
        Me.obj_order_dlvraddr3.Location = New System.Drawing.Point(473, 54)
        Me.obj_order_dlvraddr3.Name = "obj_order_dlvraddr3"
        Me.obj_order_dlvraddr3.Size = New System.Drawing.Size(222, 20)
        Me.obj_order_dlvraddr3.TabIndex = 44
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(417, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 14)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "HP"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(42, 35)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(34, 14)
        Me.lblName.TabIndex = 39
        Me.lblName.Text = "Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 14)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Address"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(417, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 14)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Phone"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(417, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 14)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Fax"
        '
        'ftabDataDetil_Sign
        '
        Me.ftabDataDetil_Sign.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Sign.Controls.Add(Me.Panel1)
        Me.ftabDataDetil_Sign.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Sign.Name = "ftabDataDetil_Sign"
        Me.ftabDataDetil_Sign.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Sign.TabIndex = 6
        Me.ftabDataDetil_Sign.Text = "Signature"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.obj_Order_authname)
        Me.Panel1.Controls.Add(Me.obj_Order_authposition)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.obj_Order_authposition2)
        Me.Panel1.Controls.Add(Me.chkApproved)
        Me.Panel1.Controls.Add(Me.obj_Order_authname2)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 160)
        Me.Panel1.TabIndex = 151
        '
        'obj_Order_authname
        '
        Me.obj_Order_authname.Location = New System.Drawing.Point(9, 21)
        Me.obj_Order_authname.Name = "obj_Order_authname"
        Me.obj_Order_authname.Size = New System.Drawing.Size(138, 20)
        Me.obj_Order_authname.TabIndex = 28
        Me.obj_Order_authname.TabStop = False
        '
        'obj_Order_authposition
        '
        Me.obj_Order_authposition.Location = New System.Drawing.Point(153, 21)
        Me.obj_Order_authposition.Name = "obj_Order_authposition"
        Me.obj_Order_authposition.Size = New System.Drawing.Size(370, 20)
        Me.obj_Order_authposition.TabIndex = 29
        Me.obj_Order_authposition.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 14)
        Me.Label16.TabIndex = 141
        Me.Label16.Text = "Procurement Dept. Head"
        '
        'obj_Order_authposition2
        '
        Me.obj_Order_authposition2.BackColor = System.Drawing.SystemColors.Window
        Me.obj_Order_authposition2.Location = New System.Drawing.Point(153, 53)
        Me.obj_Order_authposition2.Name = "obj_Order_authposition2"
        Me.obj_Order_authposition2.Size = New System.Drawing.Size(370, 20)
        Me.obj_Order_authposition2.TabIndex = 84
        Me.obj_Order_authposition2.TabStop = False
        '
        'chkApproved
        '
        Me.chkApproved.AutoSize = True
        Me.chkApproved.Enabled = False
        Me.chkApproved.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkApproved.Location = New System.Drawing.Point(8, 79)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.Size = New System.Drawing.Size(80, 18)
        Me.chkApproved.TabIndex = 82
        Me.chkApproved.Text = "Approved"
        Me.chkApproved.UseVisualStyleBackColor = True
        Me.chkApproved.Visible = False
        '
        'obj_Order_authname2
        '
        Me.obj_Order_authname2.BackColor = System.Drawing.SystemColors.Window
        Me.obj_Order_authname2.Location = New System.Drawing.Point(9, 53)
        Me.obj_Order_authname2.Name = "obj_Order_authname2"
        Me.obj_Order_authname2.Size = New System.Drawing.Size(138, 20)
        Me.obj_Order_authname2.TabIndex = 83
        Me.obj_Order_authname2.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Enabled = False
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 14)
        Me.Label17.TabIndex = 142
        Me.Label17.Text = "Director In Charge"
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Info.Controls.Add(Me.cbo_old_program_name)
        Me.ftabDataDetil_Info.Controls.Add(Me.cbo_budget_amount)
        Me.ftabDataDetil_Info.Controls.Add(Me.Label21)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_appstatus)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_appby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_appdate)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_createby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_modifydate)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_modifyby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_createdate)
        Me.ftabDataDetil_Info.Controls.Add(Me.Label19)
        Me.ftabDataDetil_Info.Controls.Add(Me.Label20)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Order_isprinted)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_modifydate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_modifyby)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_createdate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Order_createby)
        Me.ftabDataDetil_Info.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Info.TabIndex = 5
        Me.ftabDataDetil_Info.Text = "Order Info"
        '
        'cbo_old_program_name
        '
        Me.cbo_old_program_name.FormattingEnabled = True
        Me.cbo_old_program_name.Location = New System.Drawing.Point(589, 127)
        Me.cbo_old_program_name.Name = "cbo_old_program_name"
        Me.cbo_old_program_name.Size = New System.Drawing.Size(121, 22)
        Me.cbo_old_program_name.TabIndex = 158
        Me.cbo_old_program_name.Visible = False
        '
        'cbo_budget_amount
        '
        Me.cbo_budget_amount.FormattingEnabled = True
        Me.cbo_budget_amount.Location = New System.Drawing.Point(589, 99)
        Me.cbo_budget_amount.Name = "cbo_budget_amount"
        Me.cbo_budget_amount.Size = New System.Drawing.Size(121, 22)
        Me.cbo_budget_amount.TabIndex = 157
        Me.cbo_budget_amount.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(411, 76)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 14)
        Me.Label21.TabIndex = 155
        Me.Label21.Text = "Status"
        '
        'obj_appstatus
        '
        Me.obj_appstatus.Location = New System.Drawing.Point(507, 73)
        Me.obj_appstatus.Name = "obj_appstatus"
        Me.obj_appstatus.ReadOnly = True
        Me.obj_appstatus.Size = New System.Drawing.Size(203, 20)
        Me.obj_appstatus.TabIndex = 156
        '
        'obj_appby
        '
        Me.obj_appby.Location = New System.Drawing.Point(507, 22)
        Me.obj_appby.Name = "obj_appby"
        Me.obj_appby.ReadOnly = True
        Me.obj_appby.Size = New System.Drawing.Size(203, 20)
        Me.obj_appby.TabIndex = 153
        '
        'obj_appdate
        '
        Me.obj_appdate.Location = New System.Drawing.Point(507, 48)
        Me.obj_appdate.Name = "obj_appdate"
        Me.obj_appdate.ReadOnly = True
        Me.obj_appdate.Size = New System.Drawing.Size(203, 20)
        Me.obj_appdate.TabIndex = 154
        '
        'obj_Order_createby
        '
        Me.obj_Order_createby.Location = New System.Drawing.Point(123, 23)
        Me.obj_Order_createby.Name = "obj_Order_createby"
        Me.obj_Order_createby.ReadOnly = True
        Me.obj_Order_createby.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_createby.TabIndex = 38
        '
        'obj_Order_modifydate
        '
        Me.obj_Order_modifydate.Location = New System.Drawing.Point(123, 86)
        Me.obj_Order_modifydate.Name = "obj_Order_modifydate"
        Me.obj_Order_modifydate.ReadOnly = True
        Me.obj_Order_modifydate.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_modifydate.TabIndex = 41
        '
        'obj_Order_modifyby
        '
        Me.obj_Order_modifyby.Location = New System.Drawing.Point(123, 65)
        Me.obj_Order_modifyby.Name = "obj_Order_modifyby"
        Me.obj_Order_modifyby.ReadOnly = True
        Me.obj_Order_modifyby.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_modifyby.TabIndex = 40
        '
        'obj_Order_createdate
        '
        Me.obj_Order_createdate.Location = New System.Drawing.Point(123, 44)
        Me.obj_Order_createdate.Name = "obj_Order_createdate"
        Me.obj_Order_createdate.ReadOnly = True
        Me.obj_Order_createdate.Size = New System.Drawing.Size(203, 20)
        Me.obj_Order_createdate.TabIndex = 39
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(411, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 14)
        Me.Label19.TabIndex = 151
        Me.Label19.Text = "Approve Date"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(411, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 14)
        Me.Label20.TabIndex = 152
        Me.Label20.Text = "Approved By"
        '
        'obj_Order_isprinted
        '
        Me.obj_Order_isprinted.AutoSize = True
        Me.obj_Order_isprinted.Enabled = False
        Me.obj_Order_isprinted.Location = New System.Drawing.Point(20, 113)
        Me.obj_Order_isprinted.Name = "obj_Order_isprinted"
        Me.obj_Order_isprinted.Size = New System.Drawing.Size(59, 18)
        Me.obj_Order_isprinted.TabIndex = 19
        Me.obj_Order_isprinted.Text = "Printed"
        Me.obj_Order_isprinted.UseVisualStyleBackColor = True
        '
        'lbl_Order_modifydate
        '
        Me.lbl_Order_modifydate.AutoSize = True
        Me.lbl_Order_modifydate.Location = New System.Drawing.Point(17, 85)
        Me.lbl_Order_modifydate.Name = "lbl_Order_modifydate"
        Me.lbl_Order_modifydate.Size = New System.Drawing.Size(64, 14)
        Me.lbl_Order_modifydate.TabIndex = 14
        Me.lbl_Order_modifydate.Text = "Modify Date"
        '
        'lbl_Order_modifyby
        '
        Me.lbl_Order_modifyby.AutoSize = True
        Me.lbl_Order_modifyby.Location = New System.Drawing.Point(17, 64)
        Me.lbl_Order_modifyby.Name = "lbl_Order_modifyby"
        Me.lbl_Order_modifyby.Size = New System.Drawing.Size(55, 14)
        Me.lbl_Order_modifyby.TabIndex = 11
        Me.lbl_Order_modifyby.Text = "Modify By"
        '
        'lbl_Order_createdate
        '
        Me.lbl_Order_createdate.AutoSize = True
        Me.lbl_Order_createdate.Location = New System.Drawing.Point(17, 43)
        Me.lbl_Order_createdate.Name = "lbl_Order_createdate"
        Me.lbl_Order_createdate.Size = New System.Drawing.Size(64, 14)
        Me.lbl_Order_createdate.TabIndex = 12
        Me.lbl_Order_createdate.Text = "Create Date"
        '
        'lbl_Order_createby
        '
        Me.lbl_Order_createby.AutoSize = True
        Me.lbl_Order_createby.Location = New System.Drawing.Point(17, 22)
        Me.lbl_Order_createby.Name = "lbl_Order_createby"
        Me.lbl_Order_createby.Size = New System.Drawing.Size(55, 14)
        Me.lbl_Order_createby.TabIndex = 13
        Me.lbl_Order_createby.Text = "Create By"
        '
        'ftabDataDetil_Respond
        '
        Me.ftabDataDetil_Respond.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Respond.Controls.Add(Me.dgvtrnBPB)
        Me.ftabDataDetil_Respond.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Respond.Name = "ftabDataDetil_Respond"
        Me.ftabDataDetil_Respond.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Respond.TabIndex = 10
        Me.ftabDataDetil_Respond.Text = "BPB"
        '
        'dgvtrnBPB
        '
        Me.dgvtrnBPB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtrnBPB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvtrnBPB.Location = New System.Drawing.Point(0, 0)
        Me.dgvtrnBPB.Name = "dgvtrnBPB"
        Me.dgvtrnBPB.Size = New System.Drawing.Size(733, 119)
        Me.dgvtrnBPB.TabIndex = 8
        '
        'ftabDataDetil_DocCirculation
        '
        Me.ftabDataDetil_DocCirculation.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_DocCirculation.Controls.Add(Me.DgvDocCirculation)
        Me.ftabDataDetil_DocCirculation.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_DocCirculation.Name = "ftabDataDetil_DocCirculation"
        Me.ftabDataDetil_DocCirculation.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_DocCirculation.TabIndex = 11
        Me.ftabDataDetil_DocCirculation.Text = "Doc.Circulation"
        '
        'DgvDocCirculation
        '
        Me.DgvDocCirculation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDocCirculation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDocCirculation.Location = New System.Drawing.Point(0, 0)
        Me.DgvDocCirculation.Name = "DgvDocCirculation"
        Me.DgvDocCirculation.Size = New System.Drawing.Size(733, 119)
        Me.DgvDocCirculation.TabIndex = 9
        '
        'ftabDataDetil_InvRec
        '
        Me.ftabDataDetil_InvRec.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_InvRec.Controls.Add(Me.DgvInvReceipt)
        Me.ftabDataDetil_InvRec.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_InvRec.Name = "ftabDataDetil_InvRec"
        Me.ftabDataDetil_InvRec.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_InvRec.TabIndex = 12
        Me.ftabDataDetil_InvRec.Text = "Invoice.Receipt"
        '
        'DgvInvReceipt
        '
        Me.DgvInvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvInvReceipt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvInvReceipt.Location = New System.Drawing.Point(0, 0)
        Me.DgvInvReceipt.Name = "DgvInvReceipt"
        Me.DgvInvReceipt.Size = New System.Drawing.Size(733, 119)
        Me.DgvInvReceipt.TabIndex = 10
        '
        'ftabDataDetil_Advance
        '
        Me.ftabDataDetil_Advance.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ftabDataDetil_Advance.Controls.Add(Me.dgvAdvance)
        Me.ftabDataDetil_Advance.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Advance.Name = "ftabDataDetil_Advance"
        Me.ftabDataDetil_Advance.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Advance.TabIndex = 13
        Me.ftabDataDetil_Advance.Text = "Advance"
        '
        'dgvAdvance
        '
        Me.dgvAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdvance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAdvance.Location = New System.Drawing.Point(0, 0)
        Me.dgvAdvance.Name = "dgvAdvance"
        Me.dgvAdvance.Size = New System.Drawing.Size(733, 119)
        Me.dgvAdvance.TabIndex = 11
        '
        'ftabDataDetil_Episode
        '
        Me.ftabDataDetil_Episode.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ftabDataDetil_Episode.Controls.Add(Me.dgvepisode)
        Me.ftabDataDetil_Episode.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Episode.Name = "ftabDataDetil_Episode"
        Me.ftabDataDetil_Episode.Size = New System.Drawing.Size(733, 119)
        Me.ftabDataDetil_Episode.TabIndex = 14
        Me.ftabDataDetil_Episode.Text = "Episode Detil"
        '
        'dgvepisode
        '
        Me.dgvepisode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvepisode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvepisode.Location = New System.Drawing.Point(0, 0)
        Me.dgvepisode.Name = "dgvepisode"
        Me.dgvepisode.Size = New System.Drawing.Size(733, 119)
        Me.dgvepisode.TabIndex = 12
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.BackColor = System.Drawing.Color.MistyRose
        Me.PnlDataFooter.Controls.Add(Me.PnlDataFooter_note)
        Me.PnlDataFooter.Controls.Add(Me.PnlDataFooter_total)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 352)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(741, 133)
        Me.PnlDataFooter.TabIndex = 100
        '
        'PnlDataFooter_note
        '
        Me.PnlDataFooter_note.Controls.Add(Me.lblApproved)
        Me.PnlDataFooter_note.Controls.Add(Me.obj_order_note)
        Me.PnlDataFooter_note.Controls.Add(Me.chkOrder_canceled)
        Me.PnlDataFooter_note.Controls.Add(Me.Label14)
        Me.PnlDataFooter_note.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataFooter_note.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDataFooter_note.Location = New System.Drawing.Point(0, 0)
        Me.PnlDataFooter_note.Name = "PnlDataFooter_note"
        Me.PnlDataFooter_note.Size = New System.Drawing.Size(535, 133)
        Me.PnlDataFooter_note.TabIndex = 150
        '
        'lblApproved
        '
        Me.lblApproved.AutoSize = True
        Me.lblApproved.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApproved.ForeColor = System.Drawing.Color.Maroon
        Me.lblApproved.Location = New System.Drawing.Point(11, 110)
        Me.lblApproved.Name = "lblApproved"
        Me.lblApproved.Size = New System.Drawing.Size(10, 14)
        Me.lblApproved.TabIndex = 141
        Me.lblApproved.Text = "."
        Me.lblApproved.Visible = False
        '
        'obj_order_note
        '
        Me.obj_order_note.BackColor = System.Drawing.SystemColors.Window
        Me.obj_order_note.Location = New System.Drawing.Point(14, 25)
        Me.obj_order_note.Multiline = True
        Me.obj_order_note.Name = "obj_order_note"
        Me.obj_order_note.Size = New System.Drawing.Size(509, 79)
        Me.obj_order_note.TabIndex = 14
        '
        'chkOrder_canceled
        '
        Me.chkOrder_canceled.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkOrder_canceled.Location = New System.Drawing.Point(408, 109)
        Me.chkOrder_canceled.Name = "chkOrder_canceled"
        Me.chkOrder_canceled.Size = New System.Drawing.Size(115, 17)
        Me.chkOrder_canceled.TabIndex = 15
        Me.chkOrder_canceled.Text = "Order Canceled"
        Me.chkOrder_canceled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOrder_canceled.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 14)
        Me.Label14.TabIndex = 146
        Me.Label14.Text = "Note"
        '
        'PnlDataFooter_total
        '
        Me.PnlDataFooter_total.BackColor = System.Drawing.Color.Pink
        Me.PnlDataFooter_total.Controls.Add(Me.Label1)
        Me.PnlDataFooter_total.Controls.Add(Me.calc_Order_GTotal)
        Me.PnlDataFooter_total.Controls.Add(Me.calc_Order_PPN)
        Me.PnlDataFooter_total.Controls.Add(Me.calc_Order_PPH)
        Me.PnlDataFooter_total.Controls.Add(Me.calc_Order_subtotal)
        Me.PnlDataFooter_total.Controls.Add(Me.lbl_Order_pph_percent)
        Me.PnlDataFooter_total.Controls.Add(Me.lbl_Order_ppn_percent)
        Me.PnlDataFooter_total.Controls.Add(Me.calc_Order_Discount)
        Me.PnlDataFooter_total.Controls.Add(Me.lbl_order_discount)
        Me.PnlDataFooter_total.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlDataFooter_total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDataFooter_total.Location = New System.Drawing.Point(535, 0)
        Me.PnlDataFooter_total.Name = "PnlDataFooter_total"
        Me.PnlDataFooter_total.Size = New System.Drawing.Size(206, 133)
        Me.PnlDataFooter_total.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Sub Total"
        '
        'calc_Order_GTotal
        '
        Me.calc_Order_GTotal.BackColor = System.Drawing.Color.PapayaWhip
        Me.calc_Order_GTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calc_Order_GTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.calc_Order_GTotal.Location = New System.Drawing.Point(18, 98)
        Me.calc_Order_GTotal.Name = "calc_Order_GTotal"
        Me.calc_Order_GTotal.ReadOnly = True
        Me.calc_Order_GTotal.Size = New System.Drawing.Size(176, 26)
        Me.calc_Order_GTotal.TabIndex = 37
        Me.calc_Order_GTotal.TabStop = False
        Me.calc_Order_GTotal.Text = "9,999,999,999.99"
        Me.calc_Order_GTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'calc_Order_PPN
        '
        Me.calc_Order_PPN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calc_Order_PPN.Location = New System.Drawing.Point(89, 75)
        Me.calc_Order_PPN.Name = "calc_Order_PPN"
        Me.calc_Order_PPN.ReadOnly = True
        Me.calc_Order_PPN.Size = New System.Drawing.Size(105, 20)
        Me.calc_Order_PPN.TabIndex = 35
        Me.calc_Order_PPN.TabStop = False
        Me.calc_Order_PPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'calc_Order_PPH
        '
        Me.calc_Order_PPH.BackColor = System.Drawing.SystemColors.Control
        Me.calc_Order_PPH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calc_Order_PPH.ForeColor = System.Drawing.Color.Blue
        Me.calc_Order_PPH.Location = New System.Drawing.Point(89, 53)
        Me.calc_Order_PPH.Name = "calc_Order_PPH"
        Me.calc_Order_PPH.ReadOnly = True
        Me.calc_Order_PPH.Size = New System.Drawing.Size(105, 20)
        Me.calc_Order_PPH.TabIndex = 34
        Me.calc_Order_PPH.TabStop = False
        Me.calc_Order_PPH.Text = "999,999.99"
        Me.calc_Order_PPH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'calc_Order_subtotal
        '
        Me.calc_Order_subtotal.BackColor = System.Drawing.SystemColors.Control
        Me.calc_Order_subtotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calc_Order_subtotal.Location = New System.Drawing.Point(89, 9)
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
        Me.lbl_Order_pph_percent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_pph_percent.Location = New System.Drawing.Point(14, 56)
        Me.lbl_Order_pph_percent.Name = "lbl_Order_pph_percent"
        Me.lbl_Order_pph_percent.Size = New System.Drawing.Size(26, 14)
        Me.lbl_Order_pph_percent.TabIndex = 29
        Me.lbl_Order_pph_percent.Text = "PPH"
        '
        'lbl_Order_ppn_percent
        '
        Me.lbl_Order_ppn_percent.AutoSize = True
        Me.lbl_Order_ppn_percent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_ppn_percent.Location = New System.Drawing.Point(14, 78)
        Me.lbl_Order_ppn_percent.Name = "lbl_Order_ppn_percent"
        Me.lbl_Order_ppn_percent.Size = New System.Drawing.Size(26, 14)
        Me.lbl_Order_ppn_percent.TabIndex = 28
        Me.lbl_Order_ppn_percent.Text = "PPN"
        '
        'calc_Order_Discount
        '
        Me.calc_Order_Discount.BackColor = System.Drawing.SystemColors.Control
        Me.calc_Order_Discount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calc_Order_Discount.ForeColor = System.Drawing.Color.Blue
        Me.calc_Order_Discount.Location = New System.Drawing.Point(89, 31)
        Me.calc_Order_Discount.Name = "calc_Order_Discount"
        Me.calc_Order_Discount.ReadOnly = True
        Me.calc_Order_Discount.Size = New System.Drawing.Size(105, 20)
        Me.calc_Order_Discount.TabIndex = 16
        Me.calc_Order_Discount.Text = "999,999.99"
        Me.calc_Order_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_order_discount
        '
        Me.lbl_order_discount.AutoSize = True
        Me.lbl_order_discount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_order_discount.Location = New System.Drawing.Point(14, 34)
        Me.lbl_order_discount.Name = "lbl_order_discount"
        Me.lbl_order_discount.Size = New System.Drawing.Size(49, 14)
        Me.lbl_order_discount.TabIndex = 27
        Me.lbl_order_discount.Text = "Discount"
        '
        'PnlDataMaster1
        '
        Me.PnlDataMaster1.AutoScroll = True
        Me.PnlDataMaster1.BackColor = System.Drawing.Color.Lavender
        Me.PnlDataMaster1.Controls.Add(Me.Label22)
        Me.PnlDataMaster1.Controls.Add(Me.dtp_order_setdate)
        Me.PnlDataMaster1.Controls.Add(Me.mtb_Order_utilizedtimeend)
        Me.PnlDataMaster1.Controls.Add(Me.mtb_Order_utilizedtimestart)
        Me.PnlDataMaster1.Controls.Add(Me.dtp_Order_utilizeddateend)
        Me.PnlDataMaster1.Controls.Add(Me.dtp_Order_utilizeddatestart)
        Me.PnlDataMaster1.Controls.Add(Me.dtp_Order_Dlvrdate)
        Me.PnlDataMaster1.Controls.Add(Me.Label6)
        Me.PnlDataMaster1.Controls.Add(Me.Label7)
        Me.PnlDataMaster1.Controls.Add(Me.Label8)
        Me.PnlDataMaster1.Controls.Add(Me.lbl_Order_descr)
        Me.PnlDataMaster1.Controls.Add(Me.chkSingleBudget)
        Me.PnlDataMaster1.Controls.Add(Me.obj_Order_descr)
        Me.PnlDataMaster1.Controls.Add(Me.cbo_Currency)
        Me.PnlDataMaster1.Controls.Add(Me.Label9)
        Me.PnlDataMaster1.Controls.Add(Me.obj_Order_intref)
        Me.PnlDataMaster1.Controls.Add(Me.Label4)
        Me.PnlDataMaster1.Controls.Add(Me.btn_FindBudget)
        Me.PnlDataMaster1.Controls.Add(Me.cbo_Budget_name)
        Me.PnlDataMaster1.Controls.Add(Me.cbo_Rekanan_name)
        Me.PnlDataMaster1.Controls.Add(Me.obj_Rekanan_id)
        Me.PnlDataMaster1.Controls.Add(Me.lbl_rekanan_id)
        Me.PnlDataMaster1.Controls.Add(Me.obj_Budget_id)
        Me.PnlDataMaster1.Controls.Add(Me.lbl_Budget_id)
        Me.PnlDataMaster1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDataMaster1.Location = New System.Drawing.Point(3, 81)
        Me.PnlDataMaster1.Name = "PnlDataMaster1"
        Me.PnlDataMaster1.Size = New System.Drawing.Size(741, 123)
        Me.PnlDataMaster1.TabIndex = 97
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(235, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 14)
        Me.Label22.TabIndex = 161
        Me.Label22.Text = "Set Date"
        '
        'dtp_order_setdate
        '
        Me.dtp_order_setdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_order_setdate.Enabled = False
        Me.dtp_order_setdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_order_setdate.Location = New System.Drawing.Point(296, 70)
        Me.dtp_order_setdate.Name = "dtp_order_setdate"
        Me.dtp_order_setdate.Size = New System.Drawing.Size(100, 20)
        Me.dtp_order_setdate.TabIndex = 160
        '
        'mtb_Order_utilizedtimeend
        '
        Me.mtb_Order_utilizedtimeend.Enabled = False
        Me.mtb_Order_utilizedtimeend.Location = New System.Drawing.Point(408, 94)
        Me.mtb_Order_utilizedtimeend.Mask = "00:00"
        Me.mtb_Order_utilizedtimeend.Name = "mtb_Order_utilizedtimeend"
        Me.mtb_Order_utilizedtimeend.Size = New System.Drawing.Size(40, 20)
        Me.mtb_Order_utilizedtimeend.TabIndex = 156
        Me.mtb_Order_utilizedtimeend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtb_Order_utilizedtimeend.ValidatingType = GetType(Date)
        '
        'mtb_Order_utilizedtimestart
        '
        Me.mtb_Order_utilizedtimestart.Location = New System.Drawing.Point(235, 94)
        Me.mtb_Order_utilizedtimestart.Mask = "00:00"
        Me.mtb_Order_utilizedtimestart.Name = "mtb_Order_utilizedtimestart"
        Me.mtb_Order_utilizedtimestart.Size = New System.Drawing.Size(40, 20)
        Me.mtb_Order_utilizedtimestart.TabIndex = 155
        Me.mtb_Order_utilizedtimestart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtb_Order_utilizedtimestart.ValidatingType = GetType(Date)
        '
        'dtp_Order_utilizeddateend
        '
        Me.dtp_Order_utilizeddateend.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_utilizeddateend.Enabled = False
        Me.dtp_Order_utilizeddateend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_utilizeddateend.Location = New System.Drawing.Point(296, 94)
        Me.dtp_Order_utilizeddateend.Name = "dtp_Order_utilizeddateend"
        Me.dtp_Order_utilizeddateend.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_utilizeddateend.TabIndex = 154
        '
        'dtp_Order_utilizeddatestart
        '
        Me.dtp_Order_utilizeddatestart.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_utilizeddatestart.Enabled = False
        Me.dtp_Order_utilizeddatestart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_utilizeddatestart.Location = New System.Drawing.Point(132, 94)
        Me.dtp_Order_utilizeddatestart.Name = "dtp_Order_utilizeddatestart"
        Me.dtp_Order_utilizeddatestart.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_utilizeddatestart.TabIndex = 153
        '
        'dtp_Order_Dlvrdate
        '
        Me.dtp_Order_Dlvrdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_Dlvrdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_Dlvrdate.Location = New System.Drawing.Point(132, 70)
        Me.dtp_Order_Dlvrdate.Name = "dtp_Order_Dlvrdate"
        Me.dtp_Order_Dlvrdate.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_Dlvrdate.TabIndex = 151
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 14)
        Me.Label6.TabIndex = 159
        Me.Label6.Text = "Delivery Order  Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 14)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "Use Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(279, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 14)
        Me.Label8.TabIndex = 158
        Me.Label8.Text = "to"
        '
        'lbl_Order_descr
        '
        Me.lbl_Order_descr.AutoSize = True
        Me.lbl_Order_descr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_descr.Location = New System.Drawing.Point(11, 53)
        Me.lbl_Order_descr.Name = "lbl_Order_descr"
        Me.lbl_Order_descr.Size = New System.Drawing.Size(61, 14)
        Me.lbl_Order_descr.TabIndex = 144
        Me.lbl_Order_descr.Text = "Description"
        '
        'chkSingleBudget
        '
        Me.chkSingleBudget.AutoSize = True
        Me.chkSingleBudget.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSingleBudget.Location = New System.Drawing.Point(353, 6)
        Me.chkSingleBudget.Name = "chkSingleBudget"
        Me.chkSingleBudget.Size = New System.Drawing.Size(92, 18)
        Me.chkSingleBudget.TabIndex = 150
        Me.chkSingleBudget.Text = "Single Budget"
        Me.chkSingleBudget.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkSingleBudget.UseVisualStyleBackColor = True
        '
        'obj_Order_descr
        '
        Me.obj_Order_descr.BackColor = System.Drawing.SystemColors.Window
        Me.obj_Order_descr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Order_descr.Location = New System.Drawing.Point(90, 50)
        Me.obj_Order_descr.Name = "obj_Order_descr"
        Me.obj_Order_descr.Size = New System.Drawing.Size(638, 20)
        Me.obj_Order_descr.TabIndex = 12
        '
        'cbo_Currency
        '
        Me.cbo_Currency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Currency.FormattingEnabled = True
        Me.cbo_Currency.Location = New System.Drawing.Point(529, 27)
        Me.cbo_Currency.Name = "cbo_Currency"
        Me.cbo_Currency.Size = New System.Drawing.Size(199, 22)
        Me.cbo_Currency.TabIndex = 149
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(468, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 14)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Currency"
        '
        'obj_Order_intref
        '
        Me.obj_Order_intref.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Order_intref.Location = New System.Drawing.Point(529, 5)
        Me.obj_Order_intref.Name = "obj_Order_intref"
        Me.obj_Order_intref.Size = New System.Drawing.Size(200, 20)
        Me.obj_Order_intref.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(468, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "Memo Ref"
        '
        'btn_FindBudget
        '
        Me.btn_FindBudget.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_FindBudget.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FindBudget.Location = New System.Drawing.Point(60, 4)
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
        Me.cbo_Budget_name.Enabled = False
        Me.cbo_Budget_name.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Budget_name.FormattingEnabled = True
        Me.cbo_Budget_name.ItemHeight = 14
        Me.cbo_Budget_name.Location = New System.Drawing.Point(132, 4)
        Me.cbo_Budget_name.Name = "cbo_Budget_name"
        Me.cbo_Budget_name.Size = New System.Drawing.Size(215, 22)
        Me.cbo_Budget_name.TabIndex = 11
        '
        'cbo_Rekanan_name
        '
        Me.cbo_Rekanan_name.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Rekanan_name.FormattingEnabled = True
        Me.cbo_Rekanan_name.Location = New System.Drawing.Point(90, 27)
        Me.cbo_Rekanan_name.Name = "cbo_Rekanan_name"
        Me.cbo_Rekanan_name.Size = New System.Drawing.Size(355, 22)
        Me.cbo_Rekanan_name.TabIndex = 8
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(99, 28)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.ReadOnly = True
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(52, 20)
        Me.obj_Rekanan_id.TabIndex = 142
        '
        'lbl_rekanan_id
        '
        Me.lbl_rekanan_id.AutoSize = True
        Me.lbl_rekanan_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rekanan_id.Location = New System.Drawing.Point(11, 31)
        Me.lbl_rekanan_id.Name = "lbl_rekanan_id"
        Me.lbl_rekanan_id.Size = New System.Drawing.Size(42, 14)
        Me.lbl_rekanan_id.TabIndex = 140
        Me.lbl_rekanan_id.Text = "Vendor"
        '
        'obj_Budget_id
        '
        Me.obj_Budget_id.Enabled = False
        Me.obj_Budget_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Budget_id.Location = New System.Drawing.Point(90, 5)
        Me.obj_Budget_id.Name = "obj_Budget_id"
        Me.obj_Budget_id.Size = New System.Drawing.Size(40, 20)
        Me.obj_Budget_id.TabIndex = 10
        '
        'lbl_Budget_id
        '
        Me.lbl_Budget_id.AutoSize = True
        Me.lbl_Budget_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Budget_id.Location = New System.Drawing.Point(11, 8)
        Me.lbl_Budget_id.Name = "lbl_Budget_id"
        Me.lbl_Budget_id.Size = New System.Drawing.Size(41, 14)
        Me.lbl_Budget_id.TabIndex = 141
        Me.lbl_Budget_id.Text = "Budget"
        '
        'PnlDataMaster2
        '
        Me.PnlDataMaster2.BackColor = System.Drawing.Color.PapayaWhip
        Me.PnlDataMaster2.Controls.Add(Me.cbo_Deptname)
        Me.PnlDataMaster2.Controls.Add(Me.lbl_Dept_name)
        Me.PnlDataMaster2.Controls.Add(Me.gboRevision)
        Me.PnlDataMaster2.Controls.Add(Me.dtp_order_date)
        Me.PnlDataMaster2.Controls.Add(Me.cbo_Periode_id)
        Me.PnlDataMaster2.Controls.Add(Me.lbl_Periode_id)
        Me.PnlDataMaster2.Controls.Add(Me.obj_Order_id)
        Me.PnlDataMaster2.Controls.Add(Me.lbl_order_date)
        Me.PnlDataMaster2.Controls.Add(Me.lbl_Order_id)
        Me.PnlDataMaster2.Controls.Add(Me.obj_Request_id)
        Me.PnlDataMaster2.Controls.Add(Me.lbl_Request_id)
        Me.PnlDataMaster2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDataMaster2.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster2.Name = "PnlDataMaster2"
        Me.PnlDataMaster2.Size = New System.Drawing.Size(741, 78)
        Me.PnlDataMaster2.TabIndex = 96
        '
        'cbo_Deptname
        '
        Me.cbo_Deptname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Deptname.FormattingEnabled = True
        Me.cbo_Deptname.Location = New System.Drawing.Point(90, 52)
        Me.cbo_Deptname.Name = "cbo_Deptname"
        Me.cbo_Deptname.Size = New System.Drawing.Size(355, 22)
        Me.cbo_Deptname.TabIndex = 80
        '
        'lbl_Dept_name
        '
        Me.lbl_Dept_name.AutoSize = True
        Me.lbl_Dept_name.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dept_name.Location = New System.Drawing.Point(11, 55)
        Me.lbl_Dept_name.Name = "lbl_Dept_name"
        Me.lbl_Dept_name.Size = New System.Drawing.Size(56, 14)
        Me.lbl_Dept_name.TabIndex = 81
        Me.lbl_Dept_name.Text = "Dept From"
        '
        'gboRevision
        '
        Me.gboRevision.BackColor = System.Drawing.Color.Transparent
        Me.gboRevision.Controls.Add(Me.dtp_order_revdate)
        Me.gboRevision.Controls.Add(Me.obj_order_revdesc)
        Me.gboRevision.Controls.Add(Me.Label3)
        Me.gboRevision.Controls.Add(Me.lbl_Order_revdesc)
        Me.gboRevision.Controls.Add(Me.obj_Order_revno)
        Me.gboRevision.Controls.Add(Me.lbl_Order_revno)
        Me.gboRevision.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboRevision.Location = New System.Drawing.Point(459, 3)
        Me.gboRevision.Name = "gboRevision"
        Me.gboRevision.Size = New System.Drawing.Size(278, 70)
        Me.gboRevision.TabIndex = 79
        Me.gboRevision.TabStop = False
        Me.gboRevision.Text = "Revision"
        '
        'dtp_order_revdate
        '
        Me.dtp_order_revdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_order_revdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_order_revdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_order_revdate.Location = New System.Drawing.Point(175, 17)
        Me.dtp_order_revdate.Name = "dtp_order_revdate"
        Me.dtp_order_revdate.Size = New System.Drawing.Size(95, 20)
        Me.dtp_order_revdate.TabIndex = 6
        '
        'obj_order_revdesc
        '
        Me.obj_order_revdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_order_revdesc.Location = New System.Drawing.Point(70, 42)
        Me.obj_order_revdesc.Name = "obj_order_revdesc"
        Me.obj_order_revdesc.Size = New System.Drawing.Size(199, 20)
        Me.obj_order_revdesc.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(130, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Date"
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
        Me.obj_Order_revno.Location = New System.Drawing.Point(70, 17)
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
        'dtp_order_date
        '
        Me.dtp_order_date.CustomFormat = "dd/MM/yyyy"
        Me.dtp_order_date.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_order_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_order_date.Location = New System.Drawing.Point(338, 30)
        Me.dtp_order_date.Name = "dtp_order_date"
        Me.dtp_order_date.Size = New System.Drawing.Size(107, 20)
        Me.dtp_order_date.TabIndex = 4
        '
        'cbo_Periode_id
        '
        Me.cbo_Periode_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Periode_id.FormattingEnabled = True
        Me.cbo_Periode_id.Location = New System.Drawing.Point(338, 6)
        Me.cbo_Periode_id.Name = "cbo_Periode_id"
        Me.cbo_Periode_id.Size = New System.Drawing.Size(107, 22)
        Me.cbo_Periode_id.TabIndex = 2
        '
        'lbl_Periode_id
        '
        Me.lbl_Periode_id.AutoSize = True
        Me.lbl_Periode_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Periode_id.Location = New System.Drawing.Point(281, 11)
        Me.lbl_Periode_id.Name = "lbl_Periode_id"
        Me.lbl_Periode_id.Size = New System.Drawing.Size(43, 14)
        Me.lbl_Periode_id.TabIndex = 76
        Me.lbl_Periode_id.Text = "Periode"
        '
        'obj_Order_id
        '
        Me.obj_Order_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Order_id.Location = New System.Drawing.Point(88, 6)
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.Size = New System.Drawing.Size(185, 20)
        Me.obj_Order_id.TabIndex = 1
        '
        'lbl_order_date
        '
        Me.lbl_order_date.AutoSize = True
        Me.lbl_order_date.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_order_date.Location = New System.Drawing.Point(281, 33)
        Me.lbl_order_date.Name = "lbl_order_date"
        Me.lbl_order_date.Size = New System.Drawing.Size(29, 14)
        Me.lbl_order_date.TabIndex = 74
        Me.lbl_order_date.Text = "Date"
        '
        'lbl_Order_id
        '
        Me.lbl_Order_id.AutoSize = True
        Me.lbl_Order_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Order_id.Location = New System.Drawing.Point(11, 11)
        Me.lbl_Order_id.Name = "lbl_Order_id"
        Me.lbl_Order_id.Size = New System.Drawing.Size(52, 14)
        Me.lbl_Order_id.TabIndex = 75
        Me.lbl_Order_id.Text = "Order ID"
        '
        'obj_Request_id
        '
        Me.obj_Request_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Request_id.Location = New System.Drawing.Point(90, 30)
        Me.obj_Request_id.Name = "obj_Request_id"
        Me.obj_Request_id.ReadOnly = True
        Me.obj_Request_id.Size = New System.Drawing.Size(185, 20)
        Me.obj_Request_id.TabIndex = 3
        '
        'lbl_Request_id
        '
        Me.lbl_Request_id.AutoSize = True
        Me.lbl_Request_id.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Request_id.Location = New System.Drawing.Point(11, 33)
        Me.lbl_Request_id.Name = "lbl_Request_id"
        Me.lbl_Request_id.Size = New System.Drawing.Size(59, 14)
        Me.lbl_Request_id.TabIndex = 71
        Me.lbl_Request_id.Text = "Request ID"
        '
        'PnlDataMaster3
        '
        Me.PnlDataMaster3.Controls.Add(Me.obj_Order_setlocation)
        Me.PnlDataMaster3.Controls.Add(Me.obj_Order_utilizedlocation)
        Me.PnlDataMaster3.Controls.Add(Me.mtb_Order_2)
        Me.PnlDataMaster3.Controls.Add(Me.mtb_Order_3)
        Me.PnlDataMaster3.Controls.Add(Me.mtb_Order_1)
        Me.PnlDataMaster3.Controls.Add(Me.dtp_Order_2)
        Me.PnlDataMaster3.Controls.Add(Me.dtp_Order_3)
        Me.PnlDataMaster3.Controls.Add(Me.dtp_Order_1)
        Me.PnlDataMaster3.Controls.Add(Me.lbl_Order_setdate)
        Me.PnlDataMaster3.Controls.Add(Me.lbl_Order_setlocation)
        Me.PnlDataMaster3.Controls.Add(Me.lbl_Order_utilizeddatestart)
        Me.PnlDataMaster3.Controls.Add(Me.lbl_Order_utilizeddateend)
        Me.PnlDataMaster3.Controls.Add(Me.lbl_Order_utilizedlocation)
        Me.PnlDataMaster3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster3.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster3.Name = "PnlDataMaster3"
        Me.PnlDataMaster3.Size = New System.Drawing.Size(741, 482)
        Me.PnlDataMaster3.TabIndex = 102
        '
        'obj_Order_setlocation
        '
        Me.obj_Order_setlocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_Order_setlocation.Location = New System.Drawing.Point(511, 5)
        Me.obj_Order_setlocation.Name = "obj_Order_setlocation"
        Me.obj_Order_setlocation.Size = New System.Drawing.Size(210, 20)
        Me.obj_Order_setlocation.TabIndex = 17
        '
        'obj_Order_utilizedlocation
        '
        Me.obj_Order_utilizedlocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_Order_utilizedlocation.Location = New System.Drawing.Point(511, 28)
        Me.obj_Order_utilizedlocation.Name = "obj_Order_utilizedlocation"
        Me.obj_Order_utilizedlocation.Size = New System.Drawing.Size(210, 20)
        Me.obj_Order_utilizedlocation.TabIndex = 22
        '
        'mtb_Order_2
        '
        Me.mtb_Order_2.Location = New System.Drawing.Point(398, 27)
        Me.mtb_Order_2.Mask = "00:00"
        Me.mtb_Order_2.Name = "mtb_Order_2"
        Me.mtb_Order_2.Size = New System.Drawing.Size(40, 20)
        Me.mtb_Order_2.TabIndex = 21
        Me.mtb_Order_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtb_Order_2.ValidatingType = GetType(Date)
        '
        'mtb_Order_3
        '
        Me.mtb_Order_3.Location = New System.Drawing.Point(211, 27)
        Me.mtb_Order_3.Mask = "00:00"
        Me.mtb_Order_3.Name = "mtb_Order_3"
        Me.mtb_Order_3.Size = New System.Drawing.Size(40, 20)
        Me.mtb_Order_3.TabIndex = 20
        Me.mtb_Order_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtb_Order_3.ValidatingType = GetType(Date)
        '
        'mtb_Order_1
        '
        Me.mtb_Order_1.Location = New System.Drawing.Point(211, 5)
        Me.mtb_Order_1.Mask = "00:00"
        Me.mtb_Order_1.Name = "mtb_Order_1"
        Me.mtb_Order_1.Size = New System.Drawing.Size(40, 20)
        Me.mtb_Order_1.TabIndex = 16
        Me.mtb_Order_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtb_Order_1.ValidatingType = GetType(Date)
        '
        'dtp_Order_2
        '
        Me.dtp_Order_2.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_2.Location = New System.Drawing.Point(247, 27)
        Me.dtp_Order_2.Name = "dtp_Order_2"
        Me.dtp_Order_2.Size = New System.Drawing.Size(149, 20)
        Me.dtp_Order_2.TabIndex = 19
        '
        'dtp_Order_3
        '
        Me.dtp_Order_3.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_3.Location = New System.Drawing.Point(110, 27)
        Me.dtp_Order_3.Name = "dtp_Order_3"
        Me.dtp_Order_3.Size = New System.Drawing.Size(100, 20)
        Me.dtp_Order_3.TabIndex = 18
        '
        'dtp_Order_1
        '
        Me.dtp_Order_1.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Order_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Order_1.Location = New System.Drawing.Point(20, 93)
        Me.dtp_Order_1.Name = "dtp_Order_1"
        Me.dtp_Order_1.Size = New System.Drawing.Size(92, 20)
        Me.dtp_Order_1.TabIndex = 15
        '
        'lbl_Order_setdate
        '
        Me.lbl_Order_setdate.AutoSize = True
        Me.lbl_Order_setdate.Location = New System.Drawing.Point(10, 9)
        Me.lbl_Order_setdate.Name = "lbl_Order_setdate"
        Me.lbl_Order_setdate.Size = New System.Drawing.Size(71, 14)
        Me.lbl_Order_setdate.TabIndex = 129
        Me.lbl_Order_setdate.Text = "Delivery Date"
        '
        'lbl_Order_setlocation
        '
        Me.lbl_Order_setlocation.AutoSize = True
        Me.lbl_Order_setlocation.Location = New System.Drawing.Point(457, 9)
        Me.lbl_Order_setlocation.Name = "lbl_Order_setlocation"
        Me.lbl_Order_setlocation.Size = New System.Drawing.Size(48, 14)
        Me.lbl_Order_setlocation.TabIndex = 123
        Me.lbl_Order_setlocation.Text = "Location"
        '
        'lbl_Order_utilizeddatestart
        '
        Me.lbl_Order_utilizeddatestart.AutoSize = True
        Me.lbl_Order_utilizeddatestart.Location = New System.Drawing.Point(10, 31)
        Me.lbl_Order_utilizeddatestart.Name = "lbl_Order_utilizeddatestart"
        Me.lbl_Order_utilizeddatestart.Size = New System.Drawing.Size(78, 14)
        Me.lbl_Order_utilizeddatestart.TabIndex = 122
        Me.lbl_Order_utilizeddatestart.Text = "Use Date From"
        '
        'lbl_Order_utilizeddateend
        '
        Me.lbl_Order_utilizeddateend.AutoSize = True
        Me.lbl_Order_utilizeddateend.Location = New System.Drawing.Point(263, 31)
        Me.lbl_Order_utilizeddateend.Name = "lbl_Order_utilizeddateend"
        Me.lbl_Order_utilizeddateend.Size = New System.Drawing.Size(16, 14)
        Me.lbl_Order_utilizeddateend.TabIndex = 125
        Me.lbl_Order_utilizeddateend.Text = "to"
        '
        'lbl_Order_utilizedlocation
        '
        Me.lbl_Order_utilizedlocation.AutoSize = True
        Me.lbl_Order_utilizedlocation.Location = New System.Drawing.Point(457, 31)
        Me.lbl_Order_utilizedlocation.Name = "lbl_Order_utilizedlocation"
        Me.lbl_Order_utilizedlocation.Size = New System.Drawing.Size(48, 14)
        Me.lbl_Order_utilizedlocation.TabIndex = 126
        Me.lbl_Order_utilizedlocation.Text = "Location"
        '
        'uiTrnPurchaseOrder3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.FlatTabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiTrnPurchaseOrder3"
        Me.Size = New System.Drawing.Size(764, 550)
        Me.Controls.SetChildIndex(Me.FlatTabMain, 0)
        Me.FlatTabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        CType(Me.nudSearchRowLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvTrnOrderdetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ftabDataDetil_PurchReq.ResumeLayout(False)
        CType(Me.DgvTrnRequestdetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_PaymReq.ResumeLayout(False)
        CType(Me.DgvTrnOrderPaymReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Dlvr.ResumeLayout(False)
        Me.ftabDataDetil_Dlvr.PerformLayout()
        Me.ftabDataDetil_Sign.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        Me.ftabDataDetil_Respond.ResumeLayout(False)
        CType(Me.dgvtrnBPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_DocCirculation.ResumeLayout(False)
        CType(Me.DgvDocCirculation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_InvRec.ResumeLayout(False)
        CType(Me.DgvInvReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Advance.ResumeLayout(False)
        CType(Me.dgvAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Episode.ResumeLayout(False)
        CType(Me.dgvepisode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.PnlDataFooter_note.ResumeLayout(False)
        Me.PnlDataFooter_note.PerformLayout()
        Me.PnlDataFooter_total.ResumeLayout(False)
        Me.PnlDataFooter_total.PerformLayout()
        Me.PnlDataMaster1.ResumeLayout(False)
        Me.PnlDataMaster1.PerformLayout()
        Me.PnlDataMaster2.ResumeLayout(False)
        Me.PnlDataMaster2.PerformLayout()
        Me.gboRevision.ResumeLayout(False)
        Me.gboRevision.PerformLayout()
        Me.PnlDataMaster3.ResumeLayout(False)
        Me.PnlDataMaster3.PerformLayout()
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
    Friend WithEvents txtSearchBudgetCode As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchBudgetCode As System.Windows.Forms.CheckBox
    Friend WithEvents PnlDataMaster1 As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster2 As System.Windows.Forms.Panel
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
    Friend WithEvents obj_Order_intref As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_Order_descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_descr As System.Windows.Forms.Label
    Friend WithEvents btn_FindBudget As System.Windows.Forms.Button
    Friend WithEvents cbo_Budget_name As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Rekanan_name As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rekanan_id As System.Windows.Forms.Label
    Friend WithEvents obj_Budget_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Budget_id As System.Windows.Forms.Label
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter_total As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents calc_Order_GTotal As System.Windows.Forms.TextBox
    Friend WithEvents calc_Order_PPN As System.Windows.Forms.TextBox
    Friend WithEvents calc_Order_PPH As System.Windows.Forms.TextBox
    Friend WithEvents calc_Order_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_pph_percent As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_ppn_percent As System.Windows.Forms.Label
    Friend WithEvents calc_Order_Discount As System.Windows.Forms.TextBox
    Friend WithEvents lbl_order_discount As System.Windows.Forms.Label
    Friend WithEvents cbo_Deptname As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Dept_name As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_Currency As System.Windows.Forms.ComboBox
    Friend WithEvents chkSingleBudget As System.Windows.Forms.CheckBox
    Friend WithEvents PnlDataFooter_note As System.Windows.Forms.Panel
    Friend WithEvents obj_order_note As System.Windows.Forms.TextBox
    Friend WithEvents chkOrder_canceled As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents nudSearchRowLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSearchApproved As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchApproved As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproved As System.Windows.Forms.Label
    Friend WithEvents chkSrchStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotalRows As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtCanceled As System.Windows.Forms.Label
    Friend WithEvents Txt_Disapp As System.Windows.Forms.Label
    Friend WithEvents Txt_appKadept As System.Windows.Forms.Label
    Friend WithEvents lblNew As System.Windows.Forms.Label
    Friend WithEvents TxtNew As System.Windows.Forms.Label
    Friend WithEvents lblCanceled As System.Windows.Forms.Label
    Friend WithEvents lbl_disApp As System.Windows.Forms.Label
    Friend WithEvents lbl_appKadiv As System.Windows.Forms.Label
    Friend WithEvents btnVendor As System.Windows.Forms.Button
    Friend WithEvents rekananidtxt As System.Windows.Forms.TextBox
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnOrderdetil As System.Windows.Forms.DataGridView
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblProgType As System.Windows.Forms.Label
    Friend WithEvents btnDelDesc As System.Windows.Forms.Button
    Friend WithEvents btnAddDesc As System.Windows.Forms.Button
    Friend WithEvents btnAddItem As System.Windows.Forms.Button
    Friend WithEvents ftabDataDetil_PurchReq As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnRequestdetil As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_PaymReq As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnOrderPaymReq As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_Dlvr As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents obj_order_dlvrhp As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvrtelp As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvrfax As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvraddr1 As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvrname As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvraddr2 As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_dlvraddr3 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Sign As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents obj_Order_authname As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_authposition As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents obj_Order_authposition2 As System.Windows.Forms.TextBox
    Friend WithEvents chkApproved As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Order_authname2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Info As System.Windows.Forms.TabPage
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents obj_appstatus As System.Windows.Forms.TextBox
    Friend WithEvents obj_appby As System.Windows.Forms.TextBox
    Friend WithEvents obj_appdate As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_createby As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_modifydate As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_modifyby As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_createdate As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents obj_Order_isprinted As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Order_modifydate As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_modifyby As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_createdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_createby As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Respond As System.Windows.Forms.TabPage
    Friend WithEvents dgvtrnBPB As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_old_program_name As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_budget_amount As System.Windows.Forms.ComboBox
    Friend WithEvents ftabDataDetil_DocCirculation As System.Windows.Forms.TabPage
    Friend WithEvents DgvDocCirculation As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_InvRec As System.Windows.Forms.TabPage
    Friend WithEvents DgvInvReceipt As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_Advance As System.Windows.Forms.TabPage
    Friend WithEvents dgvAdvance As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDataMaster3 As System.Windows.Forms.Panel
    Friend WithEvents obj_Order_setlocation As System.Windows.Forms.TextBox
    Friend WithEvents obj_Order_utilizedlocation As System.Windows.Forms.TextBox
    Friend WithEvents mtb_Order_2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_Order_3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_Order_1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtp_Order_2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Order_3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Order_1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Order_setdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_setlocation As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_utilizeddatestart As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_utilizeddateend As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_utilizedlocation As System.Windows.Forms.Label
    Friend WithEvents mtb_Order_utilizedtimeend As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_Order_utilizedtimestart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtp_Order_utilizeddateend As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Order_utilizeddatestart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Order_Dlvrdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtp_order_setdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Episode As System.Windows.Forms.TabPage
    Friend WithEvents dgvepisode As System.Windows.Forms.DataGridView

End Class

