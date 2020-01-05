Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel


Public Class hapus_uiOrderComplete


    Private Const mUiName As String = "uiOrderComplete"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean
    Private COMBO_ISFILLED As Boolean = False

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_MstUser As DataTable = clsDataset2.CreateTblMstUser()
    Private tbl_MstChannel As DataTable = clsDataset2.CreateTblMstChannel()
    Private tbl_MstPeriode As DataTable = clsDataset2.CreateTblMstPeriode()
    Private tbl_MstCurrency As DataTable = clsDataset2.CreateTblMstCurrency()
    Private tbl_TrnBudget As DataTable = clsDataset2.CreateTblTrnBudget()
    Private tbl_MstProgram As DataTable = clsDataset2.CreateTblMstRentalprogram()
    Private tbl_MstRekanan As DataTable = clsDataset2.CreateTblMstrekanan()
    Private tbl_MstRekanan_contact As DataTable = clsDataset2.CreateTblMstrekanan_contact()
    Private tbl_MstItem As DataTable = clsDataset2.CreateTblMstItem()
    Private tbl_MstUnit As DataTable = clsDataset2.CreateTblMstUnit()
    Private tbl_mstStrukturUnit As DataTable = clsDataset2.CreateTblStrukturUnit()

    Private tbl_OrderComplete As DataTable = clsDataset2.CreateTblOrderCompleteList()
    Private tbl_OrderComplete_temp As DataTable = clsDataset2.CreateTblOrderCompleteList()
    Private tbl_OrderCompleteDetil As DataTable = clsDataset2.CreateTblOrderCompleteDetil()
    Private tbl_OrderCompleteOrderDetilUse As DataTable = clsDataset2.CreateTblTrnOrderdetiluse()
    Private tbl_OrderCompleteDetilProc As DataTable = clsDataset2.CreateTblOrderCompleteDetilProc()
    Private tbl_OrderCompleteDetilUseProc As DataTable = clsDataset2.CreateTblOrderCompleteDetilUseProc()
    Private tbl_OrderCompleteProc_temp As DataTable = clsDataset2.CreateTblOrderCompleteProc()




    Friend WithEvents btnComplete As ToolStripButton = New ToolStripButton

#Region " Window Parameter "

    'Private _FORMMODE As String = "ENTRY"       '[ENTRY, VIEW, APPROVAL, UNAPPROVAL]
    Private _CHANNEL As String = "NTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = True
    Private _CHANNEL_CANBE_BROWSED As Boolean = True

    'Private _RPT_CYCLE As String = "MONTHLY"    '[DAILY, MONTHLY, YEARLY]
    'Private _RPT_TYPE As String = "SUMM"        '[LIST, SUMM]
    'Private _ORDER_SOURCE As String = "RQ"
    Private _ORDERTYPE_ID As String = "MO" '[RO,PO,MO]
    'Private _ORDER_AUTHNAME As String = "Febriansyah"
    'Private _ORDER_AUTHPOS As String = "Procurement Dept. Head"
    'Private _ORDER_AUTHNAME2 As String = "Warnedy"
    'Private _ORDER_AUTHPOS2 As String = "Finance Director"
    'Private _PROGRAMTYPE As String = "PG" '[PG = PROGRAM, NP = NON PROGRAM]
    Private _USERSTRUKTURUNIT As Decimal = Department.Procurement

    Private _USERNAME As String = "System"

#End Region

    Private Enum Department As Integer
        Procurement = 5507
        BMA = 5559
        IT = 5517
        TSV = 5554
        BEN = 5560
        TALENT = 2360
        NEWS = 3501
        HC = 5514

    End Enum


    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Dim tbl_Approved As New DataTable
        'Dim row_type As DataRow
        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            'Me._ORDER_SOURCE = Me.GetValueFromParameter(objParameters, "ORDER_SOURCE")
            Me._ORDERTYPE_ID = Me.GetValueFromParameter(objParameters, "ORDERTYPE_ID")
            'Me._ORDER_AUTHNAME = Me.GetValueFromParameter(objParameters, "ORDER_AUTHNAME")
            'Me._ORDER_AUTHPOS = Me.GetValueFromParameter(objParameters, "ORDER_AUTHPOS")
            'Me._ORDER_AUTHNAME2 = Me.GetValueFromParameter(objParameters, "ORDER_AUTHNAME2")
            'Me._ORDER_AUTHPOS2 = Me.GetValueFromParameter(objParameters, "ORDER_AUTHPOS2")

            'Me._FORMMODE = Me.GetValueFromParameter(objParameters, "FORMMODE")
            'Me._PROGRAMTYPE = Me.GetValueFromParameter(objParameters, "PROGRAMTYPE")

            Me.DataFill(Me.tbl_MstUser, "cq_MstUser_Select", String.Format("username = '{0}'", Me.UserName))
            Me._USERSTRUKTURUNIT = Me.tbl_MstUser.Rows(0)("strukturunit_id")
            Me._USERNAME = Me.tbl_MstUser.Rows(0)("username")

        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then

            Me.tbl_mstStrukturUnit.Clear()
            Me.ComboFill(Me.obj_department, "strukturunit_id", "strukturunit_name", Me.tbl_mstStrukturUnit, "ms_MstStrukturUnit_Select", "")

            Me.tbl_MstRekanan.Clear()
            Me.ComboFill(Me.obj_rekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")

            Me.tbl_MstItem.Clear()
            Me.DataFill(Me.tbl_MstItem, "pr_MstItem_Select", "")
            Me.tbl_MstItem.DefaultView.Sort = "item_name"

            Me.chk_ordertype_search.Checked = True
            Me.chk_ordertype_search.Enabled = False
            Me.obj_ordertype_search.Enabled = False

            If _ORDERTYPE_ID = "RO" Then
                Me.obj_ordertype_search.SelectedIndex = 0
            ElseIf _ORDERTYPE_ID = "PO" Then
                Me.obj_ordertype_search.SelectedIndex = 1
            Else
                Me.obj_ordertype_search.SelectedIndex = 2
            End If

            Me.obj_status_search.SelectedIndex = 0

            Me.btnComplete.ToolTipText = "COMPLETE/INCOMPLETE ORDER"
            Me.ToolStrip1.Items.Add(Me.btnComplete)
            Me.btnComplete.Visible = False
            Me.btnComplete.Text = "COMPLETE"

            Me.tbtnNew.Enabled = False
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True


            Me.DgvOrderComplete.DataSource = Me.tbl_OrderComplete

            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()
        End If
    End Sub

    Private Sub uiOrderComplete_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

#Region " Layout & Init UI "

    Private Function FormatDgvOrderComplete(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnOrder Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corder_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrder_setdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizeddatestart As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizeddateend As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrdertype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrder_rekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_Status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 85
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True
        cOrder_id.Frozen = True

        cOrder_Status.Name = "status"
        cOrder_Status.HeaderText = "Status"
        cOrder_Status.DataPropertyName = "status"
        cOrder_Status.Width = 85
        cOrder_Status.Visible = True
        cOrder_Status.ReadOnly = True
        cOrder_Status.Frozen = True

        corder_date.Name = "order_date"
        corder_date.HeaderText = "Date"
        corder_date.DataPropertyName = "order_date"
        corder_date.Width = 75
        corder_date.Visible = True
        corder_date.ReadOnly = True

        cOrder_descr.Name = "order_descr"
        cOrder_descr.HeaderText = "Description"
        cOrder_descr.DataPropertyName = "order_descr"
        cOrder_descr.Width = 250
        cOrder_descr.Visible = True
        cOrder_descr.ReadOnly = True

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True
        cRekanan_id.DataSource = Me.tbl_MstRekanan
        cRekanan_id.AutoComplete = True
        cRekanan_id.ValueMember = "rekanan_id"
        cRekanan_id.DisplayMember = "rekanan_name"
        cRekanan_id.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        cRekanan_id.DisplayStyleForCurrentCellOnly = True
        cRekanan_id.DefaultCellStyle.BackColor = Color.Khaki


        cOrder_setdate.Name = "order_setdate"
        cOrder_setdate.HeaderText = "Set Date"
        cOrder_setdate.DataPropertyName = "order_setdate"
        cOrder_setdate.Width = 85
        cOrder_setdate.Visible = True
        cOrder_setdate.ReadOnly = True


        cOrder_utilizeddatestart.Name = "order_utilizeddatestart"
        cOrder_utilizeddatestart.HeaderText = "Start Date"
        cOrder_utilizeddatestart.DataPropertyName = "order_utilizeddatestart"
        cOrder_utilizeddatestart.Width = 95
        cOrder_utilizeddatestart.Visible = True
        cOrder_utilizeddatestart.ReadOnly = True

        cOrder_utilizeddateend.Name = "order_utilizeddateend"
        cOrder_utilizeddateend.HeaderText = "End Date"
        cOrder_utilizeddateend.DataPropertyName = "order_utilizeddateend"
        cOrder_utilizeddateend.Width = 95
        cOrder_utilizeddateend.Visible = True
        cOrder_utilizeddateend.ReadOnly = True

        cOrdertype_id.Name = "ordertype_id"
        cOrdertype_id.HeaderText = "Type ID"
        cOrdertype_id.DataPropertyName = "ordertype_id"
        cOrdertype_id.Width = 100
        cOrdertype_id.Visible = False
        cOrdertype_id.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel ID"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 200
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = True
        cStrukturunit_id.DataSource = Me.tbl_mstStrukturUnit
        cStrukturunit_id.AutoComplete = True
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayMember = "strukturunit_name"
        cStrukturunit_id.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True
        cStrukturunit_id.DefaultCellStyle.BackColor = Color.Khaki


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_Status, _
        cOrder_id, _
        corder_date, _
        cOrder_descr, _
        cRekanan_id, _
        cOrder_utilizeddatestart, _
        cOrder_utilizeddateend, _
        cOrdertype_id, _
        cChannel_id, _
        cStrukturunit_id})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.Dock = DockStyle.Fill
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
        objDgv.AutoGenerateColumns = False
    End Function

    Private Function FormatDgvOrderCompleteDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnOrder Columns 
        Dim cStatus As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_bpj As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderDetil_Descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_Usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_approved As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerima_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerima_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerima_Dscr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerima_Usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True
        cOrder_id.DefaultCellStyle.BackColor = Color.Khaki

        cStatus.Name = "status"
        cStatus.HeaderText = "Status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 35
        cStatus.Visible = False
        cStatus.ReadOnly = True

        cOrderdetil_bpj.Name = "orderdetil_bpj"
        cOrderdetil_bpj.HeaderText = "RV"
        cOrderdetil_bpj.DataPropertyName = "orderdetil_bpj"
        cOrderdetil_bpj.Width = 35
        cOrderdetil_bpj.Visible = False
        cOrderdetil_bpj.ReadOnly = True
        cOrderdetil_bpj.DefaultCellStyle.BackColor = Color.Khaki

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.DefaultCellStyle.BackColor = Color.Khaki

        cItem_name.Name = "item_name"
        cItem_name.HeaderText = "Item"
        cItem_name.DataPropertyName = "item_name"
        cItem_name.Width = 100
        cItem_name.Visible = True
        cItem_name.ReadOnly = True
        cItem_name.DefaultCellStyle.BackColor = Color.Khaki

        cOrderDetil_Descr.Name = "orderdetil_descr"
        cOrderDetil_Descr.HeaderText = "Descr"
        cOrderDetil_Descr.DataPropertyName = "orderdetil_descr"
        cOrderDetil_Descr.Width = 150
        cOrderDetil_Descr.Visible = True
        cOrderDetil_Descr.ReadOnly = True
        cOrderDetil_Descr.DefaultCellStyle.BackColor = Color.Khaki

        cOrderdetil_Usage.Name = "orderdetil_usage"
        cOrderdetil_Usage.HeaderText = "Usage"
        cOrderdetil_Usage.DataPropertyName = "orderdetil_usage"
        cOrderdetil_Usage.Width = 50
        cOrderdetil_Usage.Visible = True
        cOrderdetil_Usage.ReadOnly = True
        cOrderdetil_Usage.DefaultCellStyle.Format = "N0"
        cOrderdetil_Usage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_Usage.DefaultCellStyle.BackColor = Color.Khaki

        cOrder_approved.Name = "order_approved"
        cOrder_approved.HeaderText = "Order App"
        cOrder_approved.DataPropertyName = "order_approved"
        cOrder_approved.Width = 75
        cOrder_approved.Visible = True
        cOrder_approved.ReadOnly = True
        cOrder_approved.DefaultCellStyle.BackColor = Color.Khaki
        cOrder_approved.DividerWidth = 4
        'cOrder_approved.CellTemplate.Style.BackColor = Color.LightGray

        cTerima_id.Name = "terima_id"
        cTerima_id.HeaderText = "RV Id"
        cTerima_id.DataPropertyName = "terima_id"
        cTerima_id.Width = 100
        cTerima_id.Visible = True
        cTerima_id.ReadOnly = True

        cTerima_line.Name = "terima_line"
        cTerima_line.HeaderText = "RV Line"
        cTerima_line.DataPropertyName = "terima_line"
        cTerima_line.Width = 100
        cTerima_line.Visible = True
        cTerima_line.ReadOnly = True

        cTerima_Dscr.Name = "terima_descr"
        cTerima_Dscr.HeaderText = "RV Descr"
        cTerima_Dscr.DataPropertyName = "terima_descr"
        cTerima_Dscr.Width = 150
        cTerima_Dscr.Visible = True
        cTerima_Dscr.ReadOnly = True

        cTerima_Usage.Name = "terima_usage"
        cTerima_Usage.HeaderText = "RVUsage"
        cTerima_Usage.DataPropertyName = "terima_usage"
        cTerima_Usage.Width = 80
        cTerima_Usage.Visible = True
        cTerima_Usage.ReadOnly = True
        cTerima_Usage.DefaultCellStyle.Format = "N0"
        cTerima_Usage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cStatus, cOrderdetil_bpj, cOrder_id, _
         cOrderdetil_line, cItem_name, cOrderDetil_Descr, _
         cOrderdetil_Usage, cOrder_approved, cTerima_id, _
         cTerima_line, cTerima_Dscr, cTerima_Usage})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.Dock = DockStyle.Fill
        'objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
        objDgv.AutoGenerateColumns = False
    End Function

    Private Function FormatDgvOrderComplete_OrderDetilUsage(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_checked As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrderdetiluse_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_actual As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_actualnote As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 60
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.Frozen = True

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "Utlzd Line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 50
        cOrderdetiluse_line.Visible = True
        cOrderdetiluse_line.ReadOnly = True
        cOrderdetiluse_line.Frozen = True

        cOrderdetiluse_checked.Name = "orderdetiluse_checked"
        cOrderdetiluse_checked.HeaderText = "Use"
        cOrderdetiluse_checked.DataPropertyName = "orderdetiluse_checked"
        cOrderdetiluse_checked.Width = 30
        cOrderdetiluse_checked.Visible = False
        cOrderdetiluse_checked.ReadOnly = True

        cOrderdetiluse_date.Name = "orderdetiluse_date"
        cOrderdetiluse_date.HeaderText = "Date"
        cOrderdetiluse_date.DataPropertyName = "orderdetiluse_date"
        cOrderdetiluse_date.Width = 70
        cOrderdetiluse_date.Visible = True
        cOrderdetiluse_date.ReadOnly = False

        cOrderdetiluse_descr.Name = "orderdetiluse_descr"
        cOrderdetiluse_descr.HeaderText = "Descr"
        cOrderdetiluse_descr.DataPropertyName = "orderdetiluse_descr"
        cOrderdetiluse_descr.Width = 100
        cOrderdetiluse_descr.Visible = True
        cOrderdetiluse_descr.ReadOnly = False

        cOrderdetiluse_qty.Name = "orderdetiluse_qty"
        cOrderdetiluse_qty.HeaderText = "Qty"
        cOrderdetiluse_qty.DataPropertyName = "orderdetiluse_qty"
        cOrderdetiluse_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_qty.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_qty.Width = 40
        cOrderdetiluse_qty.Visible = True
        cOrderdetiluse_qty.ReadOnly = False

        cOrderdetiluse_idr.Name = "orderdetiluse_idr"
        cOrderdetiluse_idr.HeaderText = "IDR"
        cOrderdetiluse_idr.DataPropertyName = "orderdetiluse_idr"
        cOrderdetiluse_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_idr.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetiluse_idr.Width = 70
        cOrderdetiluse_idr.Visible = False
        cOrderdetiluse_idr.ReadOnly = True

        cOrderdetiluse_actual.Name = "orderdetiluse_actual"
        cOrderdetiluse_actual.HeaderText = "orderdetiluse_actual"
        cOrderdetiluse_actual.DataPropertyName = "orderdetiluse_actual"
        cOrderdetiluse_actual.Width = 100
        cOrderdetiluse_actual.Visible = False
        cOrderdetiluse_actual.ReadOnly = False

        cOrderdetiluse_actualnote.Name = "orderdetiluse_actualnote"
        cOrderdetiluse_actualnote.HeaderText = "orderdetiluse_actualnote"
        cOrderdetiluse_actualnote.DataPropertyName = "orderdetiluse_actualnote"
        cOrderdetiluse_actualnote.Width = 100
        cOrderdetiluse_actualnote.Visible = False
        cOrderdetiluse_actualnote.ReadOnly = False


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.AutoGenerateColumns = False
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
            cOrderdetil_line, _
            cOrderdetiluse_line, _
            cOrderdetiluse_checked, _
            cOrderdetiluse_date, _
            cOrderdetiluse_descr, _
            cOrderdetiluse_qty, _
            cOrderdetiluse_idr, _
            cOrderdetiluse_actual, _
            cOrderdetiluse_actualnote _
        })

    End Function

    Private Function FormatDgvOrderCompleteDetilProc(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnOrder Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        'Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrderDetil_Descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderDetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderDetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderDetil_usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQtyDetilProc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDaysDetilProc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsageProc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbatas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim btnDaysOrder As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim btnDaysProc As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn


        btnDaysOrder.Name = "btnDaysOrder"
        btnDaysOrder.HeaderText = ""
        btnDaysOrder.Text = "..."
        btnDaysOrder.UseColumnTextForButtonValue = True
        btnDaysOrder.CellTemplate.Style.BackColor = Color.LightGray
        btnDaysOrder.Width = 30
        btnDaysOrder.DividerWidth = 0
        btnDaysOrder.Visible = True
        btnDaysOrder.ReadOnly = False

        btnDaysProc.Name = "btnDaysProc"
        btnDaysProc.HeaderText = ""
        btnDaysProc.Text = "..."
        btnDaysProc.UseColumnTextForButtonValue = True
        btnDaysProc.CellTemplate.Style.BackColor = Color.LightGray
        btnDaysProc.Width = 30
        btnDaysProc.DividerWidth = 0
        btnDaysProc.Visible = True
        btnDaysProc.ReadOnly = False

        cbatas.Name = "batas"
        cbatas.HeaderText = ""
        cbatas.DataPropertyName = "batas"
        cbatas.Width = 0
        cbatas.Visible = True
        cbatas.ReadOnly = True
        cbatas.DefaultCellStyle.BackColor = Color.Gray
        cbatas.DividerWidth = 3

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True
        cOrder_id.DefaultCellStyle.BackColor = Color.Khaki

        cOrderDetil_Descr.Name = "orderdetil_descr"
        cOrderDetil_Descr.HeaderText = "Descr"
        cOrderDetil_Descr.DataPropertyName = "orderdetil_descr"
        cOrderDetil_Descr.Width = 100
        cOrderDetil_Descr.Visible = True
        cOrderDetil_Descr.ReadOnly = True
        cOrderDetil_Descr.DefaultCellStyle.BackColor = Color.Khaki


        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 35
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.DefaultCellStyle.BackColor = Color.Khaki


        'cItem_id.Name = "item_id"
        'cItem_id.HeaderText = "Item"
        'cItem_id.DataPropertyName = "item_id"
        'cItem_id.Width = 80
        'cItem_id.Visible = True
        'cItem_id.ReadOnly = True
        'cItem_id.DefaultCellStyle.BackColor = Color.Khaki

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "Item"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 130
        cItem_id.Visible = True
        cItem_id.ReadOnly = True
        cItem_id.DataSource = Me.tbl_MstItem
        cItem_id.AutoComplete = True
        cItem_id.ValueMember = "item_id"
        cItem_id.DisplayMember = "item_name"
        cItem_id.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        cItem_id.DisplayStyleForCurrentCellOnly = True
        cItem_id.DefaultCellStyle.BackColor = Color.Khaki

        cOrderDetil_qty.Name = "orderdetil_qty"
        cOrderDetil_qty.HeaderText = "Qty"
        cOrderDetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderDetil_qty.Width = 35
        cOrderDetil_qty.Visible = True
        cOrderDetil_qty.ReadOnly = True
        cOrderDetil_qty.DefaultCellStyle.BackColor = Color.Khaki
        cOrderDetil_qty.DefaultCellStyle.Format = "N0"
        cOrderDetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cOrderDetil_days.Name = "orderdetil_days"
        cOrderDetil_days.HeaderText = "Days"
        cOrderDetil_days.DataPropertyName = "orderdetil_days"
        cOrderDetil_days.Width = 35
        cOrderDetil_days.Visible = True
        cOrderDetil_days.ReadOnly = True
        cOrderDetil_days.DefaultCellStyle.BackColor = Color.Khaki
        cOrderDetil_days.DefaultCellStyle.Format = "N0"
        cOrderDetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cOrderDetil_usage.Name = "orderdetil_usage"
        cOrderDetil_usage.HeaderText = "Usage"
        cOrderDetil_usage.DataPropertyName = "orderdetil_usage"
        cOrderDetil_usage.Width = 40
        cOrderDetil_usage.Visible = True
        cOrderDetil_usage.ReadOnly = True
        cOrderDetil_usage.DefaultCellStyle.BackColor = Color.Khaki
        cOrderDetil_usage.DefaultCellStyle.Format = "N0"
        cOrderDetil_usage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cQtyDetilProc.Name = "qtydetilproc"
        cQtyDetilProc.HeaderText = "Qty Proc"
        cQtyDetilProc.DataPropertyName = "qtydetilproc"
        cQtyDetilProc.Width = 75
        cQtyDetilProc.Visible = True
        cQtyDetilProc.ReadOnly = False
        cQtyDetilProc.DefaultCellStyle.Format = "N0"
        cQtyDetilProc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cDaysDetilProc.Name = "daysdetilproc"
        cDaysDetilProc.HeaderText = "DaysProc"
        cDaysDetilProc.DataPropertyName = "daysdetilproc"
        cDaysDetilProc.Width = 65
        cDaysDetilProc.Visible = True
        cDaysDetilProc.ReadOnly = True
        cDaysDetilProc.DefaultCellStyle.Format = "N0"
        cDaysDetilProc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cUsageProc.Name = "usageproc"
        cUsageProc.HeaderText = "UsageProc"
        cUsageProc.DataPropertyName = "usageproc"
        cUsageProc.Width = 75
        cUsageProc.Visible = True
        cUsageProc.ReadOnly = False
        cUsageProc.DefaultCellStyle.Format = "N0"
        cUsageProc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cStatus.Name = "status"
        cStatus.HeaderText = "Status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 80
        cStatus.Visible = True
        cStatus.ReadOnly = False

        cStatus.Items.Add("OK")
        cStatus.Items.Add("Cancel")

        cModified_by.Name = "modified_by"
        cModified_by.HeaderText = "Modified By"
        cModified_by.DataPropertyName = "modified_by"
        cModified_by.Width = 100
        cModified_by.Visible = False
        cModified_by.ReadOnly = True

        cModified_date.Name = "modified_date"
        cModified_date.HeaderText = "Modified Date"
        cModified_date.DataPropertyName = "modified_date"
        cModified_date.Width = 100
        cModified_date.Visible = False
        cModified_date.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, cOrderdetil_line, cItem_id, cOrderDetil_Descr, cOrderDetil_qty, _
         cOrderDetil_days, btnDaysOrder, cOrderDetil_usage, cbatas, cQtyDetilProc, _
         cDaysDetilProc, btnDaysProc, cUsageProc, cStatus, cModified_by, cModified_date})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = True
        objDgv.ReadOnly = False
        objDgv.Dock = DockStyle.Fill
        'objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
        objDgv.AutoGenerateColumns = False
    End Function

    Private Function InitLayoutUI() As Boolean

        Me.FlatTabMain.Anchor = AnchorStyles.Bottom
        Me.FlatTabMain.Anchor += AnchorStyles.Top
        Me.FlatTabMain.Anchor += AnchorStyles.Right
        Me.FlatTabMain.Anchor += AnchorStyles.Left

        Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False

        Me.FormatDgvOrderComplete(Me.DgvOrderComplete)
        Me.FormatDgvOrderCompleteDetil(Me.DgvOrderCompleteDetil)
        Me.FormatDgvOrderComplete_OrderDetilUsage(Me.dgv_orderdetilusage)
        Me.FormatDgvOrderCompleteDetilProc(Me.dgv_orderdetilproc)
        'Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)

        'For i = 0 To (Me.fTabData.TabCount - 1)
        '    Me.fTabData.TabPages.Item(i).BackColor = Color.Gainsboro
        'Next
        'Me.fTabData.TabPages.Item(0).BackColor = Color.White

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_order_id.DataBindings.Clear()
        Me.obj_orderdate.DataBindings.Clear()
        Me.obj_department.DataBindings.Clear()
        Me.obj_rekanan.DataBindings.Clear()
        Me.obj_setdate.DataBindings.Clear()
        Me.obj_startdate.DataBindings.Clear()
        Me.obj_enddate.DataBindings.Clear()
        Me.obj_status.DataBindings.Clear()
        Me.obj_descr.DataBindings.Clear()
        Me.obj_programtype.DataBindings.Clear()
        Me.obj_channel.DataBindings.Clear()
        Me.obj_ordertype.DataBindings.Clear()
        'Me.obj_statusby.DataBindings.Clear()
        'Me.obj_statusdate.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding

        Me.obj_order_id.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_id"))
        Me.obj_orderdate.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_date"))
        Me.obj_department.DataBindings.Add(New Binding("SelectedValue", Me.tbl_OrderComplete_temp, "strukturunit_id"))
        Me.obj_rekanan.DataBindings.Add(New Binding("SelectedValue", Me.tbl_OrderComplete_temp, "rekanan_id"))
        Me.obj_setdate.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_setdate"))
        Me.obj_startdate.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_utilizeddatestart"))
        Me.obj_enddate.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_utilizeddateend"))
        Me.obj_status.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "status"))
        Me.obj_descr.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_descr"))
        Me.obj_programtype.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "order_programtype"))
        Me.obj_channel.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "channel_id"))
        Me.obj_ordertype.DataBindings.Add(New Binding("Text", Me.tbl_OrderComplete_temp, "ordertype_id"))

        'Me.obj_statusby.DataBindings.Add(New Binding("Text", Me.tbl_OrderCompleteProc_temp, "rv_statusdate"))
        ' Me.obj_statusby.DataBindings.Add(New Binding("Text", Me.tbl_OrderCompleteProc_temp, "rv_statusby"))

    End Function
#End Region

#Region " Overrides "
    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        If Me.FlatTabMain.SelectedIndex = 0 Then
            'Me.NewData = True
            Me.FlatTabMain.SelectedIndex = 1
        End If
        'Me.uiTrnRentalOrder3_confirmNew()
        'Me.uiTrnRentalOrder3_NewData()
        'Me.ReservedItem = False
        'Me.uiTrnRentalOrder3_GetOrderSource()
        Me.tbtnSave.Visible = True
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiOrderComplete_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        'If Me.uiTrnRentalOrder3_FormError() Then
        '    Return True
        'End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiOrderComplete_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnRentalOrder3_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnRentalOrder3_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnRentalOrder3_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnRentalOrder3_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        ' Me.uiTrnRentalOrder3_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnRentalOrder3_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnRentalOrder3_Last()
        Me.Cursor = Cursors.Arrow

        Return MyBase.btnLast_Click()
    End Function
#End Region

#Region " User Defined Function "

    Private Function uiTrnPurchaseOrder3_LoadDataCombo() As Boolean
        Dim criteria As String = ""

        Try

            Me.tbl_MstStrukturUnit.Clear()
            Me.ComboFill(Me.obj_department, "strukturunit_id", "strukturunit_name", Me.tbl_mstStrukturUnit, "ms_MstStrukturUnit_Select", "")


            Me.tbl_MstRekanan.Clear()
            Me.ComboFill(Me.obj_rekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")

            'Me.tbl_MstProgram.Clear()
            'Me.ComboFill(Me.cbo_Old_program_name, "old_program_id", "program_name", Me.tbl_MstProgram, "pr_MstRentalprogram_Select", "")
            '' Me.ComboFillFromDataTable(Me.cboSearchRekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan)

            'Me.tbl_MstItem.Clear()
            'Me.DataFill(Me.tbl_MstItem, "pr_MstItem_Select", criteria)
            'Me.tbl_MstItem.DefaultView.Sort = "item_name"

            'Me.tbl_MstUnit.Clear()
            'Me.DataFill(Me.tbl_MstUnit, "pr_MstUnit_Select", criteria)
            'Me.tbl_MstUnit.DefaultView.Sort = "unit_name"

            'Me.tbl_MstCurrency.Clear()
            'Me.DataFill(Me.tbl_MstCurrency, "pr_MstCurrency_Select", criteria)
            'Me.tbl_MstCurrency.DefaultView.Sort = "currency_shortname"
            'Me.ComboFill(Me.cbo_Currency, "currency_id", "currency_shortname", Me.tbl_MstCurrency, "pr_MstCurrency_Select", "")

            'buat test develop (approve sebagai spv).------------------------------------------------------------------
            'If Me.Browser Is Nothing Then
            '    Me.DataFill(Me.tbl_MstUser, "cq_MstUser_Select", String.Format("username = '{0}'", "devproc"))
            'End If
            '------------------------------------------------------------------------------------------------

            Me.COMBO_ISFILLED = True
        Catch ex As Exception
            Me.COMBO_ISFILLED = False
            MsgBox(ex.Message)
        End Try
    End Function


    Private Function uiOrderComplete_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""

        'If Me.chkSearchOrderID.Checked Then
        '    If criteria = "" Then
        '        criteria = "a.order_id = '" & Me.txtSearchOrderID.Text & "'"
        '    Else
        '        criteria = criteria + "a.order_id = '" & Me.txtSearchOrderID.Text & "'"
        '    End If
        'End If

        If Me.chkSearchOrderID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("a.order_id", Me.txtSearchOrderID)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        If Me.chk_status_search.Checked = True Then
            If Me.obj_status_search.SelectedText = "COMPLETE" Then
                txtSearchCriteria = "a.status= 1"
            Else
                txtSearchCriteria = "a.status= 0"
            End If

            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        If Me.chkSearchRekanan.Checked Then
            txtSearchCriteria = String.Format(" b.rekanan_id = '{0}' ", Me.rekananidtxt.Text)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        If Me.chk_ordertype_search.Checked Then
            txtSearchCriteria = String.Format(" b.ordertype_id = '{0}' ", Me.obj_ordertype_search.Text)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        criteria = txtCondition

        ' TODO: Parse Criteria using clsProc.RefParser()
        Me.tbl_OrderComplete.Clear()
        Try
            Me.DataFill(Me.tbl_OrderComplete, "tr_OrderCompleteList", criteria)

            For a As Integer = 0 To Me.DgvOrderComplete.Rows.Count - 1
                If Me.DgvOrderComplete.Rows(a).Cells("status").Value = "COMPLETE" Then
                    Me.DgvOrderComplete.Rows(a).DefaultCellStyle.BackColor = Color.LemonChiffon
                ElseIf Me.DgvOrderComplete.Rows(a).Cells("status").Value = "INCOMPLETE" Then
                    Me.DgvOrderComplete.Rows(a).DefaultCellStyle.BackColor = Color.White
                End If
            Next


            ' Me.DataFillLimit(Me.tbl_OrderComplete, "tr_OrderCompleteList", criteria, Me.nudSearchRowLimit.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiOrderComplete_Save() As Boolean
        'save data
        'Dim tbl_Mhs_Temp_Changes As DataTable
        Dim tbl_OrderCompleteDetilProc_Changes As DataTable
        Dim tbl_OrderCompleteDetilUseProc_Changes As DataTable

        Dim success As Boolean
        Dim order_id As Object = New Object
        'Dim orderdetil_line As Object = New Object


        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(order_id)

        'Me.DgvMhsdetilmatkul.EndEdit()
        Me.BindingContext(Me.tbl_OrderCompleteDetilProc).EndCurrentEdit()
        tbl_OrderCompleteDetilProc_Changes = Me.tbl_OrderCompleteDetilProc.GetChanges()


        Me.BindingContext(Me.tbl_OrderCompleteDetilUseProc).EndCurrentEdit()
        tbl_OrderCompleteDetilUseProc_Changes = Me.tbl_OrderCompleteDetilUseProc.GetChanges()

        'If tbl_Mhs_Temp_Changes IsNot Nothing Or tbl_Mhsdetilmatkul_Changes IsNot Nothing Then
        If tbl_OrderCompleteDetilProc_Changes IsNot Nothing Or tbl_OrderCompleteDetilUseProc_Changes IsNot Nothing Then

            Try

                'MasterDataState = tbl_Mhs_Temp.Rows(0).RowState
                'mhs_id = tbl_Mhs_Temp.Rows(0).Item("mhs_id")

                'If tbl_Mhs_Temp_Changes IsNot Nothing Then
                '    success = Me.mahasiswa_SaveMaster(mhs_id, tbl_Mhs_Temp_Changes, MasterDataState)
                '    If Not success Then Throw New Exception("Error: Saving Master Data at Me.mahasiswa_SaveMaster(tbl_Mhs_Temp_Changes)")
                '    Me.tbl_Mhs_Temp.AcceptChanges()
                'End If

                MasterDataState = tbl_OrderCompleteDetilProc.Rows(0).RowState
                order_id = tbl_OrderCompleteDetilProc.Rows(0).Item("order_id")
                'orderdetil_line = tbl_OrderCompleteDetilProc.Rows(0).Item("order_id")

                If tbl_OrderCompleteDetilProc_Changes IsNot Nothing Then
                    'For i = 0 To Me.tbl_OrderCompleteDetilProc.Rows.Count - 1
                    '    If Me.tbl_OrderCompleteDetilProc.Rows(i).RowState = DataRowState.Added Then
                    '        Me.tbl_OrderCompleteDetilProc.Rows(i).Item("order_id") = order_id
                    '    End If
                    'Next
                    success = Me.OrderCompleteDetilProc_SaveDetil(order_id, tbl_OrderCompleteDetilProc_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.OrderCompleteDetilProc_SaveDetil(tbl_OrderCompleteDetilProc_Changes)")
                    Me.tbl_OrderCompleteDetilProc.AcceptChanges()
                End If

                If tbl_OrderCompleteDetilUseProc_Changes IsNot Nothing Then
                    'For i = 0 To Me.tbl_OrderCompleteDetilProc.Rows.Count - 1
                    '    If Me.tbl_OrderCompleteDetilProc.Rows(i).RowState = DataRowState.Added Then
                    '        Me.tbl_OrderCompleteDetilProc.Rows(i).Item("order_id") = order_id
                    '    End If
                    'Next
                    success = Me.OrderCompleteDetilUseProc_SaveDetil(order_id, tbl_OrderCompleteDetilUseProc_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.OrderCompleteDetilUseProc_SaveDetil(tbl_OrderCompleteDetilUseProc_Changes)")
                    Me.tbl_OrderCompleteDetilUseProc.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(order_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function OrderCompleteDetilProc_SaveDetil(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        'Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        'dbCmdInsert = New OleDb.OleDbCommand("mdp_Mhsdetilmatkul_Insert", dbConn)
        'dbCmdInsert.CommandType = CommandType.StoredProcedure
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_iddetil", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_iddetil"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_matkulid", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_matkulid"))
        'dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("tr_TrnOrderdetilProc_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_item", System.Data.OleDb.OleDbType.VarWChar, 100, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 100, "orderdetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Integer, 4, "qtydetilproc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Integer, 4, "daysdetilproc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_usage", System.Data.OleDb.OleDbType.Integer, 4, "usageproc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status", System.Data.OleDb.OleDbType.VarWChar, 100, "status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100, "modified_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_date", System.Data.OleDb.OleDbType.Date, 100, "modified_date"))
        dbCmdUpdate.Parameters("@modified_by").Value = Me._USERNAME
        dbCmdUpdate.Parameters("@order_id").Value = order_id

        '===
        'dbCmdDelete = New OleDb.OleDbCommand("mdp_Mhsdetilmatkul_Delete", dbConn)
        'dbCmdDelete.CommandType = CommandType.StoredProcedure
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_iddetil", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_iddetil"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_matkulid", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_matkulid"))
        'dbCmdDelete.Parameters("@mhs_id").Value = mhs_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        'dbDA.InsertCommand = dbCmdInsert
        'dbDA.DeleteCommand = dbCmdDelete

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function OrderCompleteDetilUseProc_SaveDetil(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        'Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        'dbCmdInsert = New OleDb.OleDbCommand("mdp_Mhsdetilmatkul_Insert", dbConn)
        'dbCmdInsert.CommandType = CommandType.StoredProcedure
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_iddetil", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_iddetil"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_matkulid", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_matkulid"))
        'dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("tr_TrnOrderdetiluseProc_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, "orderdetiluse_checked"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_date", System.Data.OleDb.OleDbType.Date, "orderdetiluse_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, "orderdetiluse_qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@remark", System.Data.OleDb.OleDbType.VarWChar, 100, "remark"))

        dbCmdUpdate.Parameters("@order_id").Value = order_id


        'dbCmdDelete = New OleDb.OleDbCommand("mdp_Mhsdetilmatkul_Delete", dbConn)
        'dbCmdDelete.CommandType = CommandType.StoredProcedure
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_iddetil", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_iddetil"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@mhs_matkulid", System.Data.OleDb.OleDbType.VarWChar, 100, "mhs_matkulid"))
        'dbCmdDelete.Parameters("@mhs_id").Value = mhs_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        'dbDA.InsertCommand = dbCmdInsert
        'dbDA.DeleteCommand = dbCmdDelete

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiOrderComplete_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim order_id As String

        order_id = Me.DgvOrderComplete.Rows(rowIndex).Cells("order_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Try
            dbConn.Open()
            Me.uiOrderComplete_OpenRowMaster(order_id, dbConn)
            Me.uiOrderComplete_OpenRowDetil(order_id, dbConn)
            Me.uiOrderComplete_OpenRow_OrderDetiluse(order_id, dbConn)
            Me.uiOrderComplete_OpenRowDetilProc(order_id, dbConn)
            Me.uiOrderComplete_OpenRow_OrderDetilUse_Proc(order_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiOrderComplete_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(order_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiOrderComplete_OpenRowMaster(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        Dim dbCmd1 As OleDb.OleDbCommand
        Dim dbDA1 As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("tr_OrderCompleteList", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("a.order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_OrderComplete_temp.Clear()


        dbCmd1 = New OleDb.OleDbCommand("tr_OrderCompleteListStatusProc", dbConn)
        dbCmd1.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd1.Parameters.Add("@Order_type", Data.OleDb.OleDbType.VarChar)
        dbCmd1.Parameters("@Criteria").Value = String.Format("a.order_id='{0}'", order_id)
        dbCmd1.Parameters("@Order_type").Value = Me._ORDERTYPE_ID
        dbCmd1.CommandType = CommandType.StoredProcedure
        dbDA1 = New OleDb.OleDbDataAdapter(dbCmd1)

        Me.tbl_OrderCompleteProc_temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_OrderComplete_temp)
            dbDA1.Fill(Me.tbl_OrderCompleteProc_temp)
            Me.BindingStart()

            If Me.tbl_OrderCompleteProc_temp.Rows.Count <> 0 Then
                Me.obj_statusby.Text = Me.tbl_OrderCompleteProc_temp.Rows(0).Item("rv_statusby").ToString
                Me.obj_statusdate.Text = Me.tbl_OrderCompleteProc_temp.Rows(0).Item("rv_statusdate").ToString
            Else
                Me.obj_statusby.Text = ""
                Me.obj_statusdate.Text = ""
            End If


        Catch ex As Exception
            Throw New Exception(mUiName & ": uiOrderComplete_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiOrderComplete_OpenRowDetil(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        dbCmd = New OleDb.OleDbCommand("tr_OrderCompleteDetil", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_OrderCompleteDetil.Clear()

        Me.tbl_OrderCompleteDetil = clsDataset2.CreateTblOrderCompleteDetil()
        Me.tbl_OrderCompleteDetil.Columns("order_id").DefaultValue = order_id
        'Me.tbl_OrderCompleteDetil.Columns("mhs_iddetil").DefaultValue = DBNull.Value
        'Me.tbl_OrderCompleteDetil.Columns("mhs_iddetil").AutoIncrement = True
        'Me.tbl_OrderCompleteDetil.Columns("mhs_iddetil").AutoIncrementSeed = 10
        'Me.tbl_OrderCompleteDetil.Columns("mhs_iddetil").AutoIncrementStep = 10


        Try
            dbDA.Fill(Me.tbl_OrderCompleteDetil)
            Me.DgvOrderCompleteDetil.DataSource = Me.tbl_OrderCompleteDetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiOrderComplete_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiOrderComplete_OpenRow_OrderDetiluse(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetiluse_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_OrderCompleteOrderDetilUse.Clear()

        Me.tbl_OrderCompleteOrderDetilUse = clsDataset2.CreateTblTrnOrderdetiluse()
        Me.tbl_OrderCompleteOrderDetilUse.Columns("order_id").DefaultValue = order_id
        Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").AutoIncrement = True
        Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_OrderCompleteOrderDetilUse)
            Me.dgv_orderdetilusage.DataSource = Me.tbl_OrderCompleteOrderDetilUse
            'Me.tbl_OrderCompleteOrderDetilUse.DefaultView.RowFilter = "orderdetiluse_checked=1"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiOrderComplete_OpenRow_OrderDetiluse()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiOrderComplete_OpenRowDetilProc(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        dbCmd = New OleDb.OleDbCommand("tr_OrderCompleteDetilProc", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_OrderCompleteDetilProc.Clear()

        Me.tbl_OrderCompleteDetilProc = clsDataset2.CreateTblOrderCompleteDetilProc()
        Me.tbl_OrderCompleteDetilProc.Columns("order_id").DefaultValue = order_id

        Try
            dbDA.Fill(Me.tbl_OrderCompleteDetilProc)
            Me.dgv_orderdetilproc.DataSource = Me.tbl_OrderCompleteDetilProc
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiOrderComplete_OpenRowDetilProc()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiOrderComplete_OpenRow_OrderDetilUse_Proc(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("tr_OrderCompleteDetilProcUse", dbConn)
        'dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_OrderCompleteDetilUseProc.Clear()

        Me.tbl_OrderCompleteDetilUseProc = clsDataset2.CreateTblOrderCompleteDetilUseProc()
        Me.tbl_OrderCompleteDetilUseProc.Columns("order_id").DefaultValue = order_id
        'Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        'Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").AutoIncrement = True
        'Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        'Me.tbl_OrderCompleteOrderDetilUse.Columns("orderdetiluse_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_OrderCompleteDetilUseProc)
            Me.dgv_orderdetilusage.DataSource = Me.tbl_OrderCompleteDetilUseProc
            'Me.tbl_OrderCompleteOrderDetilUse.DefaultView.RowFilter = "orderdetiluse_checked=1"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiOrderComplete_OpenRow_OrderDetilUse_Proc()" & vbCrLf & ex.Message)
        End Try

    End Function

#End Region

    Private Sub FlatTabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FlatTabMain.SelectedIndexChanged
        Select Case FlatTabMain.SelectedIndex
            Case 0
                Me.tbtnNew.Enabled = False
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True

                If Me.DgvOrderComplete.Rows.Count <= 0 Then
                    Me.btnComplete.Visible = False
                Else
                    Me.btnComplete.Visible = True
                End If

                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.White
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnNew.Enabled = False
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.btnComplete.Visible = False
                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.White

                'Me.fTabDetilMain.TabPages.Item(2).Dispose()

                If Me.DgvOrderComplete.CurrentRow IsNot Nothing Then
                    Me.uiOrderComplete_OpenRow(Me.DgvOrderComplete.CurrentRow.Index)
                Else

                End If

        End Select
    End Sub

    Private Sub DgvOrderComplete_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOrderComplete.CellClick
        If Me.tbl_OrderComplete.Rows.Count > 0 Then
            If DgvOrderComplete.CurrentRow.Cells("status").Value = "INCOMPLETE" Then
                Me.btnComplete.Enabled = True
                Me.btnComplete.Visible = True
                Me.btnComplete.Text = "COMPLETE"

            ElseIf DgvOrderComplete.CurrentRow.Cells("status").Value = "COMPLETE" Then
                Me.btnComplete.Enabled = True
                Me.btnComplete.Visible = True
                Me.btnComplete.Text = "INCOMPLETE"
            End If

        End If

    End Sub

    Private Sub DgvOrderComplete_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOrderComplete.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvOrderComplete.CurrentRow IsNot Nothing Then
            Me.FlatTabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub dgv_orderdetilproc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_orderdetilproc.CellClick
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Dim retObj As Integer
        Select Case e.ColumnIndex
            Case Me.dgv_orderdetilproc.Columns("btnDaysOrder").Index
                If e.RowIndex < 0 Then
                    Exit Sub
                End If

                If Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("btnDaysOrder").ReadOnly = False Then
                    Dim order_id As String = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("order_id").Value
                    Dim orderdetil_line As Integer = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("orderdetil_line").Value
                    Dim item_id As String = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("item_id").Value
                    Dim source As String = "Usage Order"
                    Dim dlg As dlgSelectDaysProc = New dlgSelectDaysProc(order_id, orderdetil_line, item_id, Me.tbl_OrderCompleteOrderDetilUse, Me.DSN, source)

                    dlg.ShowDialog()

                End If

            Case Me.dgv_orderdetilproc.Columns("btnDaysProc").Index
                If e.RowIndex < 0 Then
                    Exit Sub
                End If

                If Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("btnDaysProc").ReadOnly = False Then
                    Dim order_id As String = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("order_id").Value
                    Dim orderdetil_line As Integer = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("orderdetil_line").Value
                    Dim item_id As String = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("item_id").Value
                    Dim source As String = "Usage Notes"
                    Dim dlg As dlgSelectDaysProc = New dlgSelectDaysProc(order_id, orderdetil_line, item_id, Me.tbl_OrderCompleteDetilUseProc, Me.DSN, source)
                    'Dim dlg As dlgSelectDaysProc = New dlgSelectDaysProc(order_id, orderdetil_line, item_id, Me.tbl_OrderCompleteOrderDetilUse, Me.DSN, source)

                    dlg.ShowDialog()

                    If dlg.DialogResult = DialogResult.OK Then
                        Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("daysdetilproc").Value = dlg.lbl_days.Text
                    End If

                End If
        End Select

    End Sub

    Private Sub dgv_orderdetilproc_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_orderdetilproc.CellFormatting
        Dim orderdetil_usage As Integer
        Dim orderdetil_qty As Integer
        Dim orderdetil_days As Integer

        orderdetil_qty = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("orderdetil_qty").Value
        orderdetil_days = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("orderdetil_days").Value
        orderdetil_usage = orderdetil_qty * orderdetil_days
        Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("orderdetil_usage").Value = orderdetil_usage

        'orderdetil_qty_proc = clsUtil.IsDbNull(Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("qtydetilproc").Value, 0)
        'orderdetil_days_proc = clsUtil.IsDbNull(Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("daysdetilproc").Value, 0)
        'orderdetil_usage_proc = orderdetil_qty_proc * orderdetil_days_proc
        'Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("usageproc").Value = orderdetil_usage_proc

    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click

        If Me.DgvOrderComplete.Rows.Count <= 0 Then
            MsgBox("Tidak ada data yg dipilih", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        If Me.DgvOrderComplete.Rows(Me.DgvOrderComplete.CurrentRow.Index).Cells("status").Value = "INCOMPLETE" Then
            Me.uiOrderComplete_Complete("COMPLETE")

            'Me.btnComplete.Text = "INCOMPLETE"
            'Me.btnComplete.Visible = True
            'Me.btnComplete.Enabled = True
        Else
            Me.uiOrderComplete_Complete("INCOMPLETE")

            'Me.btnComplete.Text = "COMPLETE"
            'Me.btnComplete.Visible = True
            'Me.btnComplete.Enabled = True
        End If

    End Sub

    Private Sub uiOrderComplete_Complete(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTransaction As OleDb.OleDbTransaction

        Try
            dbConn.Open()
            dbTransaction = dbConn.BeginTransaction

            Dim oCm As New OleDb.OleDbCommand("tr_OrderComplete_ProcCompleted", dbConn, dbTransaction)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Me.DgvOrderComplete.Item("order_id", DgvOrderComplete.CurrentRow.Index).Value
            oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me._ORDERTYPE_ID
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status
            oCm.ExecuteNonQuery()
            oCm.Dispose()
            dbTransaction.Commit()

            If status = "COMPLETE" Then

                Me.DgvOrderComplete.Item("status", DgvOrderComplete.CurrentRow.Index).Value = "COMPLETE"
                MessageBox.Show("Data Has Been Completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnComplete.Text = "INCOMPLETE"
            Else
                Me.DgvOrderComplete.Item("status", DgvOrderComplete.CurrentRow.Index).Value = "INCOMPLETE"
                MessageBox.Show("Data Has Been Incompleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnComplete.Text = "COMPLETE"
            End If

        Catch ex As Data.OleDb.OleDbException
            dbTransaction.Rollback()
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()

        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgvOrderComplete_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvOrderComplete.KeyDown
        If Me.tbl_OrderComplete.Rows.Count > 0 Then
            If DgvOrderComplete.CurrentRow.Cells("status").Value = "INCOMPLETE" Then
                Me.btnComplete.Enabled = True
                Me.btnComplete.Visible = True
                Me.btnComplete.Text = "COMPLETE"

            ElseIf DgvOrderComplete.CurrentRow.Cells("status").Value = "COMPLETE" Then
                Me.btnComplete.Enabled = True
                Me.btnComplete.Visible = True
                Me.btnComplete.Text = "INCOMPLETE"
            End If

        End If
    End Sub

    Private Sub DgvOrderComplete_KeyUp(sender As Object, e As KeyEventArgs) Handles DgvOrderComplete.KeyUp
        If Me.tbl_OrderComplete.Rows.Count > 0 Then
            If DgvOrderComplete.CurrentRow.Cells("status").Value = "INCOMPLETE" Then
                Me.btnComplete.Enabled = True
                Me.btnComplete.Visible = True
                Me.btnComplete.Text = "COMPLETE"

            ElseIf DgvOrderComplete.CurrentRow.Cells("status").Value = "COMPLETE" Then
                Me.btnComplete.Enabled = True
                Me.btnComplete.Visible = True
                Me.btnComplete.Text = "INCOMPLETE"
            End If

        End If
    End Sub

    Private Sub btnVendor_Click(sender As Object, e As EventArgs) Handles btnVendor.Click
        Dim dlg As dlgSelectVendor = New dlgSelectVendor(Me.DSN)
        Dim rekanan_id As String
        rekanan_id = dlg.OpenDialog(Me)
        Me.rekananidtxt.Text = rekanan_id
    End Sub

    Private Sub dgv_orderdetilproc_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_orderdetilproc.CellValueChanged
        'Me.DgvOrderComplete.Rows(e.RowIndex).Cells("qtydetilproc").Value

        Select Case e.ColumnIndex
            Case Me.dgv_orderdetilproc.Columns("qtydetilproc").Index
                Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("usageproc").Value = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("qtydetilproc").Value * Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("daysdetilproc").Value

            Case Me.dgv_orderdetilproc.Columns("daysdetilproc").Index
                Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("usageproc").Value = Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("qtydetilproc").Value * Me.dgv_orderdetilproc.Rows(e.RowIndex).Cells("daysdetilproc").Value
        End Select
    End Sub



End Class

