'================================================== 
' Irhantoro E
' Trans7
' Created Date: 2/18/2008 9:32:39 AM


Public Class uiTrnMaintenanceOrder
    Private Const mUiName As String = "Maintenance Order"
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

    Private tbl_TrnOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnOrder_Temp As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnOrderdetil As DataTable = clsDataset.CreateTblTrnOrderdetil()
    Private tbl_TrnOrderPaymReq As DataTable = clsDataset.CreateTblTrnOrderpaymreq()

    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriode()
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency()
    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblTrnBudget()
    Private tbl_MstProgram As DataTable = clsDataset.CreateTblMstRentalprogram()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekanan()
    Private tbl_MstRekanan_contact As DataTable = clsDataset.CreateTblMstrekanan_contact()
    Private tbl_MstItem As DataTable = clsDataset.CreateTblMstItem()
    Private tbl_MstUnit As DataTable = clsDataset.CreateTblMstUnit()
    Private tbl_StrukturUnit As DataTable = clsDataset.CreateTblStrukturUnit()
    Private tbl_TrnMaintenanceRequest As DataTable = clsDataset.CreateTblRequestdetil


    Private tbl_TrnOrderAmount_perBudget As DataTable = clsDataset.CreateTblOrderAmount_perBudget()

    'Public Shared mChannel_id As String
    'Public Shared mOrder_source As String
    'Public Shared mOrdertype_id As String
    'Public Shared mCreateBy As String
    'Public Shared mModifyBy As String

    Dim prd, lmdate As String


#Region " Window Parameter "

    Private _FORMMODE As String = "ENTRY"       '[ENTRY, VIEW, APPROVAL, UNAPPROVAL]
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = True
    Private _CHANNEL_CANBE_BROWSED As Boolean = True

    Private _RPT_CYCLE As String = "MONTHLY"    '[DAILY, MONTHLY, YEARLY]
    Private _RPT_TYPE As String = "SUMM"        '[LIST, SUMM]
    Private _ORDER_SOURCE As String = "Manual"
    Private _ORDERTYPE_ID As String = "MO"
    Private _ORDER_AUTHNAME As String = "Febriansyah"
    Private _ORDER_AUTHPOS As String = "Kepala Unit Procurement"
    Private _PROGRAMTYPE As String = "NP"


#End Region

#Region " Local Parameter "


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
            Me.FlatTabMain.SelectedIndex = 1
        End If
        Me.uiTrnMaintenanceOrder_NewData()
        Me.uiTrnMaintenanceOrder_GetOrderSource()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()

    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnMaintenanceOrder_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceOrder_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Property "

    Private mTotalDetil As Decimal
    Private mTotalDetilPPH As Decimal
    Private mTotalDetilPPN As Decimal

    Public Property TotalDetil() As Decimal
        Get
            Return mTotalDetil
        End Get
        Set(ByVal value As Decimal)
            mTotalDetil = value
            Me.calc_Order_subtotal.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property TotalDetilPPH() As Decimal
        Get
            Return mTotalDetilPPH
        End Get
        Set(ByVal value As Decimal)
            mTotalDetilPPH = value
            Me.calc_Order_PPH.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property TotalDetilPPN() As Decimal
        Get
            Return mTotalDetilPPN
        End Get
        Set(ByVal value As Decimal)
            mTotalDetilPPN = value
            Me.calc_Order_PPN.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnOrder(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnOrder Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corder_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_spkdesc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_spkworktype As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOld_program_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_prognm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_progsch As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_setdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_settime As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_setlocation As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizeddatestart As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizeddateend As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizedtimestart As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizedtimeend As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_utilizedlocation As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_pph_percent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_ppn_percent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_insurancecost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_transportationcost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_operatorcost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_othercost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_authname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_authposition As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_canceled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrder_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_createdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_modifyby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_modifydate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_source As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrdertype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOld_category_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOld_apref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_revno As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_revdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_revdesc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_approved As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPeriode_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_spkrequired As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cNew_apref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvrname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvraddr1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvraddr2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvraddr3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvrtelp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvrfax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_dlvrhp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_note As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_intref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 80
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        corder_date.Name = "order_date"
        corder_date.HeaderText = "Date"
        corder_date.DataPropertyName = "order_date"
        corder_date.Width = 75
        corder_date.Visible = True
        corder_date.ReadOnly = False

        cOrder_descr.Name = "order_descr"
        cOrder_descr.HeaderText = "Description"
        cOrder_descr.DataPropertyName = "order_descr"
        cOrder_descr.Width = 150
        cOrder_descr.Visible = True
        cOrder_descr.ReadOnly = False

        cOrder_spkdesc.Name = "order_spkdesc"
        cOrder_spkdesc.HeaderText = "SPK Note"
        cOrder_spkdesc.DataPropertyName = "order_spkdesc"
        cOrder_spkdesc.Width = 150
        cOrder_spkdesc.Visible = True
        cOrder_spkdesc.ReadOnly = False

        cOrder_spkworktype.Name = "order_spkworktype"
        cOrder_spkworktype.HeaderText = "SPK WorkType"
        cOrder_spkworktype.DataPropertyName = "order_spkworktype"
        cOrder_spkworktype.Width = 150
        cOrder_spkworktype.Visible = True
        cOrder_spkworktype.ReadOnly = False

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "RequestID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 80
        cRequest_id.Visible = True
        cRequest_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "RekananID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 70
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = False

        cOld_program_id.Name = "old_program_id"
        cOld_program_id.HeaderText = "ProgID"
        cOld_program_id.DataPropertyName = "old_program_id"
        cOld_program_id.Width = 100
        cOld_program_id.Visible = True
        cOld_program_id.ReadOnly = False

        cOrder_prognm.Name = "order_prognm"
        cOrder_prognm.HeaderText = "Program Name"
        cOrder_prognm.DataPropertyName = "order_prognm"
        cOrder_prognm.Width = 150
        cOrder_prognm.Visible = True
        cOrder_prognm.ReadOnly = False

        cOrder_progsch.Name = "order_progsch"
        cOrder_progsch.HeaderText = "Program Sch"
        cOrder_progsch.DataPropertyName = "order_progsch"
        cOrder_progsch.Width = 100
        cOrder_progsch.Visible = True
        cOrder_progsch.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "BudgetID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 80
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = False

        cOrder_eps.Name = "order_eps"
        cOrder_eps.HeaderText = "Episode"
        cOrder_eps.DataPropertyName = "order_eps"
        cOrder_eps.Width = 100
        cOrder_eps.Visible = True
        cOrder_eps.ReadOnly = False

        cOrder_setdate.Name = "order_setdate"
        cOrder_setdate.HeaderText = "Set Date"
        cOrder_setdate.DataPropertyName = "order_setdate"
        cOrder_setdate.Width = 85
        cOrder_setdate.Visible = True
        cOrder_setdate.ReadOnly = False

        cOrder_settime.Name = "order_settime"
        cOrder_settime.HeaderText = "Set Time"
        cOrder_settime.DataPropertyName = "order_settime"
        cOrder_settime.Width = 85
        cOrder_settime.Visible = True
        cOrder_settime.ReadOnly = False

        cOrder_setlocation.Name = "order_setlocation"
        cOrder_setlocation.HeaderText = "Set Location"
        cOrder_setlocation.DataPropertyName = "order_setlocation"
        cOrder_setlocation.Width = 100
        cOrder_setlocation.Visible = True
        cOrder_setlocation.ReadOnly = False

        cOrder_utilizeddatestart.Name = "order_utilizeddatestart"
        cOrder_utilizeddatestart.HeaderText = "Utlz Date1"
        cOrder_utilizeddatestart.DataPropertyName = "order_utilizeddatestart"
        cOrder_utilizeddatestart.Width = 95
        cOrder_utilizeddatestart.Visible = True
        cOrder_utilizeddatestart.ReadOnly = False

        cOrder_utilizeddateend.Name = "order_utilizeddateend"
        cOrder_utilizeddateend.HeaderText = "Utlzd Date2"
        cOrder_utilizeddateend.DataPropertyName = "order_utilizeddateend"
        cOrder_utilizeddateend.Width = 95
        cOrder_utilizeddateend.Visible = True
        cOrder_utilizeddateend.ReadOnly = False

        cOrder_utilizedtimestart.Name = "order_utilizedtimestart"
        cOrder_utilizedtimestart.HeaderText = "Utlz Time1"
        cOrder_utilizedtimestart.DataPropertyName = "order_utilizedtimestart"
        cOrder_utilizedtimestart.Width = 85
        cOrder_utilizedtimestart.Visible = True
        cOrder_utilizedtimestart.ReadOnly = False

        cOrder_utilizedtimeend.Name = "order_utilizedtimeend"
        cOrder_utilizedtimeend.HeaderText = "Utlz Time2"
        cOrder_utilizedtimeend.DataPropertyName = "order_utilizedtimeend"
        cOrder_utilizedtimeend.Width = 85
        cOrder_utilizedtimeend.Visible = True
        cOrder_utilizedtimeend.ReadOnly = False

        cOrder_utilizedlocation.Name = "order_utilizedlocation"
        cOrder_utilizedlocation.HeaderText = "Utlz Location"
        cOrder_utilizedlocation.DataPropertyName = "order_utilizedlocation"
        cOrder_utilizedlocation.Width = 100
        cOrder_utilizedlocation.Visible = True
        cOrder_utilizedlocation.ReadOnly = False

        cOrder_pph_percent.Name = "order_pph_percent"
        cOrder_pph_percent.HeaderText = "% PPH"
        cOrder_pph_percent.DataPropertyName = "order_pph_percent"
        cOrder_pph_percent.Width = 50
        cOrder_pph_percent.Visible = True
        cOrder_pph_percent.ReadOnly = False

        cOrder_ppn_percent.Name = "order_ppn_percent"
        cOrder_ppn_percent.HeaderText = "% PPN"
        cOrder_ppn_percent.DataPropertyName = "order_ppn_percent"
        cOrder_ppn_percent.Width = 50
        cOrder_ppn_percent.Visible = True
        cOrder_ppn_percent.ReadOnly = False

        cOrder_insurancecost.Name = "order_insurancecost"
        cOrder_insurancecost.HeaderText = "Insurance"
        cOrder_insurancecost.DataPropertyName = "order_insurancecost"
        cOrder_insurancecost.Width = 80
        cOrder_insurancecost.Visible = True
        cOrder_insurancecost.ReadOnly = False

        cOrder_transportationcost.Name = "order_transportationcost"
        cOrder_transportationcost.HeaderText = "Transport"
        cOrder_transportationcost.DataPropertyName = "order_transportationcost"
        cOrder_transportationcost.Width = 80
        cOrder_transportationcost.Visible = True
        cOrder_transportationcost.ReadOnly = False

        cOrder_operatorcost.Name = "order_operatorcost"
        cOrder_operatorcost.HeaderText = "Operator"
        cOrder_operatorcost.DataPropertyName = "order_operatorcost"
        cOrder_operatorcost.Width = 80
        cOrder_operatorcost.Visible = True
        cOrder_operatorcost.ReadOnly = False

        cOrder_othercost.Name = "order_othercost"
        cOrder_othercost.HeaderText = "Other Cost"
        cOrder_othercost.DataPropertyName = "order_othercost"
        cOrder_othercost.Width = 90
        cOrder_othercost.Visible = True
        cOrder_othercost.ReadOnly = False

        cOrder_authname.Name = "order_authname"
        cOrder_authname.HeaderText = "Auth Name"
        cOrder_authname.DataPropertyName = "order_authname"
        cOrder_authname.Width = 100
        cOrder_authname.Visible = True
        cOrder_authname.ReadOnly = False

        cOrder_authposition.Name = "order_authposition"
        cOrder_authposition.HeaderText = "Auth Position"
        cOrder_authposition.DataPropertyName = "order_authposition"
        cOrder_authposition.Width = 100
        cOrder_authposition.Visible = True
        cOrder_authposition.ReadOnly = False

        cOrder_canceled.Name = "order_canceled"
        cOrder_canceled.HeaderText = "Canceled"
        cOrder_canceled.DataPropertyName = "order_canceled"
        cOrder_canceled.Width = 75
        cOrder_canceled.Visible = True
        cOrder_canceled.ReadOnly = False

        cOrder_createby.Name = "order_createby"
        cOrder_createby.HeaderText = "CreateBy"
        cOrder_createby.DataPropertyName = "order_createby"
        cOrder_createby.Width = 85
        cOrder_createby.Visible = True
        cOrder_createby.ReadOnly = False

        cOrder_createdate.Name = "order_createdate"
        cOrder_createdate.HeaderText = "Create Date"
        cOrder_createdate.DataPropertyName = "order_createdate"
        cOrder_createdate.Width = 95
        cOrder_createdate.Visible = True
        cOrder_createdate.ReadOnly = False

        cOrder_modifyby.Name = "order_modifyby"
        cOrder_modifyby.HeaderText = "Modify By"
        cOrder_modifyby.DataPropertyName = "order_modifyby"
        cOrder_modifyby.Width = 85
        cOrder_modifyby.Visible = True
        cOrder_modifyby.ReadOnly = False

        cOrder_modifydate.Name = "order_modifydate"
        cOrder_modifydate.HeaderText = "Modify Date"
        cOrder_modifydate.DataPropertyName = "order_modifydate"
        cOrder_modifydate.Width = 95
        cOrder_modifydate.Visible = True
        cOrder_modifydate.ReadOnly = False

        cOrder_discount.Name = "order_discount"
        cOrder_discount.HeaderText = "Discount"
        cOrder_discount.DataPropertyName = "order_discount"
        cOrder_discount.Width = 100
        cOrder_discount.Visible = True
        cOrder_discount.ReadOnly = False

        cOrder_source.Name = "order_source"
        cOrder_source.HeaderText = "Source"
        cOrder_source.DataPropertyName = "order_source"
        cOrder_source.Width = 100
        cOrder_source.Visible = True
        cOrder_source.ReadOnly = False

        cOrdertype_id.Name = "ordertype_id"
        cOrdertype_id.HeaderText = "Type ID"
        cOrdertype_id.DataPropertyName = "ordertype_id"
        cOrdertype_id.Width = 100
        cOrdertype_id.Visible = False
        cOrdertype_id.ReadOnly = False

        cOld_category_id.Name = "old_category_id"
        cOld_category_id.HeaderText = "Category ID"
        cOld_category_id.DataPropertyName = "old_category_id"
        cOld_category_id.Width = 100
        cOld_category_id.Visible = False
        cOld_category_id.ReadOnly = False

        cOld_apref.Name = "old_apref"
        cOld_apref.HeaderText = "AP Ref (old)"
        cOld_apref.DataPropertyName = "old_apref"
        cOld_apref.Width = 100
        cOld_apref.Visible = True
        cOld_apref.ReadOnly = False

        cNew_apref.Name = "paymreq_id"
        cNew_apref.HeaderText = "Paymreq ID"
        cNew_apref.DataPropertyName = "paymreq_id"
        cNew_apref.Width = 100
        cNew_apref.Visible = True
        cNew_apref.ReadOnly = False

        cOrder_revno.Name = "order_revno"
        cOrder_revno.HeaderText = "Rev No"
        cOrder_revno.DataPropertyName = "order_revno"
        cOrder_revno.Width = 100
        cOrder_revno.Visible = False
        cOrder_revno.ReadOnly = False

        cOrder_revdate.Name = "order_revdate"
        cOrder_revdate.HeaderText = "Rev Date"
        cOrder_revdate.DataPropertyName = "order_revdate"
        cOrder_revdate.Width = 95
        cOrder_revdate.Visible = False
        cOrder_revdate.ReadOnly = False

        cOrder_revdesc.Name = "order_revdesc"
        cOrder_revdesc.HeaderText = "Rev Desc"
        cOrder_revdesc.DataPropertyName = "order_revdesc"
        cOrder_revdesc.Width = 100
        cOrder_revdesc.Visible = False
        cOrder_revdesc.ReadOnly = False

        cOrder_approved.Name = "order_approved"
        cOrder_approved.HeaderText = "Approved"
        cOrder_approved.DataPropertyName = "order_approved"
        cOrder_approved.Width = 100
        cOrder_approved.Visible = False
        cOrder_approved.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel ID"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cPeriode_id.Name = "periode_id"
        cPeriode_id.HeaderText = "Periode ID"
        cPeriode_id.DataPropertyName = "periode_id"
        cPeriode_id.Width = 100
        cPeriode_id.Visible = False
        cPeriode_id.ReadOnly = False

        cOrder_spkrequired.Name = "order_spkrequired"
        cOrder_spkrequired.HeaderText = "Spkrequired"
        cOrder_spkrequired.DataPropertyName = "order_spkrequired"
        cOrder_spkrequired.Width = 100
        cOrder_spkrequired.Visible = False
        cOrder_spkrequired.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Unit ID"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 85
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = False

        cOrder_dlvrname.Name = "order_dlvrname"
        cOrder_dlvrname.HeaderText = "Delivery Name"
        cOrder_dlvrname.DataPropertyName = "order_dlvrname"
        cOrder_dlvrname.Width = 130
        cOrder_dlvrname.Visible = True
        cOrder_dlvrname.ReadOnly = False

        cOrder_dlvraddr1.Name = "order_dlvraddr1"
        cOrder_dlvraddr1.HeaderText = "Delivery Address1"
        cOrder_dlvraddr1.DataPropertyName = "order_dlvraddr1"
        cOrder_dlvraddr1.Width = 130
        cOrder_dlvraddr1.Visible = True
        cOrder_dlvraddr1.ReadOnly = False

        cOrder_dlvraddr2.Name = "order_dlvraddr2"
        cOrder_dlvraddr2.HeaderText = "Delivery Address2"
        cOrder_dlvraddr2.DataPropertyName = "order_dlvraddr2"
        cOrder_dlvraddr2.Width = 130
        cOrder_dlvraddr2.Visible = True
        cOrder_dlvraddr2.ReadOnly = False

        cOrder_dlvraddr3.Name = "order_dlvraddr3"
        cOrder_dlvraddr3.HeaderText = "Delivery Address3"
        cOrder_dlvraddr3.DataPropertyName = "order_dlvraddr3"
        cOrder_dlvraddr3.Width = 130
        cOrder_dlvraddr3.Visible = True
        cOrder_dlvraddr3.ReadOnly = False

        cOrder_dlvrtelp.Name = "order_dlvtelp"
        cOrder_dlvrtelp.HeaderText = "Delivery Telpon"
        cOrder_dlvrtelp.DataPropertyName = "order_dlvrtelp"
        cOrder_dlvrtelp.Width = 130
        cOrder_dlvrtelp.Visible = True
        cOrder_dlvrtelp.ReadOnly = False

        cOrder_dlvrfax.Name = "order_dlvfax"
        cOrder_dlvrfax.HeaderText = "Delivery Fax"
        cOrder_dlvrfax.DataPropertyName = "order_dlvrfax"
        cOrder_dlvrfax.Width = 130
        cOrder_dlvrfax.Visible = True
        cOrder_dlvrfax.ReadOnly = False

        cOrder_dlvrhp.Name = "order_dlvhp"
        cOrder_dlvrhp.HeaderText = "Delivery HP"
        cOrder_dlvrhp.DataPropertyName = "order_dlvrhp"
        cOrder_dlvrhp.Width = 130
        cOrder_dlvrhp.Visible = True
        cOrder_dlvrhp.ReadOnly = False

        cOrder_note.Name = "order_note"
        cOrder_note.HeaderText = "Note"
        cOrder_note.DataPropertyName = "order_note"
        cOrder_note.Width = 70
        cOrder_note.Visible = True
        cOrder_note.ReadOnly = False

        cOrder_intref.Name = "order_intref"
        cOrder_intref.HeaderText = "Internal Reference"
        cOrder_intref.DataPropertyName = "order_intref"
        cOrder_intref.Width = 130
        cOrder_intref.Visible = True
        cOrder_intref.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, _
        corder_date, _
        cOrder_descr, _
        cOrder_spkdesc, _
        cOrder_spkworktype, _
        cRequest_id, _
        cRekanan_id, _
        cOld_program_id, _
        cOrder_prognm, _
        cOrder_progsch, _
        cBudget_id, _
        cOrder_eps, _
        cOrder_setdate, _
        cOrder_settime, _
        cOrder_setlocation, _
        cOrder_utilizeddatestart, _
        cOrder_utilizeddateend, _
        cOrder_utilizedtimestart, _
        cOrder_utilizedtimeend, _
        cOrder_utilizedlocation, _
        cOrder_pph_percent, cOrder_ppn_percent, _
        cOrder_insurancecost, cOrder_transportationcost, _
        cOrder_operatorcost, cOrder_othercost, _
        cOrder_authname, cOrder_authposition, _
        cOrder_canceled, _
        cOrder_createby, cOrder_createdate, _
        cOrder_modifyby, cOrder_modifydate, _
        cOrder_discount, cOrder_source, cOrdertype_id, _
        cOld_category_id, cOld_apref, cNew_apref, _
        cOrder_revno, cOrder_revdate, cOrder_revdesc, cOrder_approved, _
        cChannel_id, cPeriode_id, cOrder_spkrequired, cStrukturunit_id, cOrder_dlvrname, _
        cOrder_dlvraddr1, cOrder_dlvraddr2, cOrder_dlvraddr3, cOrder_dlvrtelp, _
        cOrder_dlvrfax, cOrder_dlvrhp, cOrder_note, cOrder_intref})

        ' DgvTrnOrder Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.Dock = DockStyle.Fill
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
    End Function

    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        'formating DgvTrnOrderdetil
        Dim cbOrderdetil_type As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbItem_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCategory_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbUnit_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cbCurrency As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrderdetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_subtotal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_total As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pphpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign_pphpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign_ppnpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        'hidden column
        Dim cCategory_spktype As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetaccount_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOld_orderdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_actual As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_actualnote As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cbOrderdetil_type.Name = "orderdetil_type"
        cbOrderdetil_type.HeaderText = "Type"
        cbOrderdetil_type.DataPropertyName = "orderdetil_type"
        cbOrderdetil_type.Width = 50
        cbOrderdetil_type.Visible = True
        cbOrderdetil_type.ReadOnly = False
        cbOrderdetil_type.ValueMember = "orderdetil_type"
        cbOrderdetil_type.DisplayMember = "orderdetil_type"
        cbOrderdetil_type.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        cbOrderdetil_type.DisplayStyleForCurrentCellOnly = True
        cbOrderdetil_type.AutoComplete = True
        cbOrderdetil_type.Items.Clear()
        cbOrderdetil_type.Items.Add("Item")
        cbOrderdetil_type.Items.Add("Descr")

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 30
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        cbItem_name.Name = "item_id"
        cbItem_name.HeaderText = "Item"
        cbItem_name.DataPropertyName = "item_id"
        cbItem_name.Width = 130
        cbItem_name.Visible = True
        cbItem_name.ReadOnly = False
        cbItem_name.ValueMember = "item_id"
        cbItem_name.DisplayMember = "item_name"
        cbItem_name.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        cbItem_name.DisplayStyleForCurrentCellOnly = True
        cbItem_name.AutoComplete = True
        cbItem_name.DataSource = Me.tbl_MstItem

        cbUnit_name.Name = "unit_id"
        cbUnit_name.HeaderText = "Unit"
        cbUnit_name.DataPropertyName = "unit_id"
        cbUnit_name.Width = 55
        cbUnit_name.Visible = True
        cbUnit_name.ReadOnly = False
        cbUnit_name.ValueMember = "unit_id"
        cbUnit_name.DisplayMember = "unit_shortname"
        cbUnit_name.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        cbUnit_name.DisplayStyleForCurrentCellOnly = True
        cbUnit_name.AutoComplete = True
        cbUnit_name.DataSource = Me.tbl_MstUnit

        cbCurrency.Name = "currency_id"
        cbCurrency.HeaderText = "Curr"
        cbCurrency.DataPropertyName = "currency_id"
        cbCurrency.Width = 55
        cbCurrency.Visible = True
        cbCurrency.ReadOnly = False
        cbCurrency.ValueMember = "currency_id"
        cbCurrency.DisplayMember = "currency_shortname"
        cbCurrency.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        cbCurrency.DisplayStyleForCurrentCellOnly = True
        cbCurrency.AutoComplete = True
        cbCurrency.DataSource = Me.tbl_MstCurrency

        cCategory_name.Name = "category_name"
        cCategory_name.HeaderText = "Category"
        cCategory_name.DataPropertyName = "category_name"
        cCategory_name.Width = 130
        cCategory_name.Visible = False
        cCategory_name.ReadOnly = True

        cCategory_spktype.Name = "category_spktype"
        cCategory_spktype.HeaderText = "SPK Type"
        cCategory_spktype.DataPropertyName = "category_spktype"
        cCategory_spktype.Width = 130
        cCategory_spktype.Visible = False
        cCategory_spktype.ReadOnly = True

        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Description"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 150
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = False

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_qty.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_qty.Width = 50
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = False

        cOrderdetil_idr.Name = "orderdetil_idr"
        cOrderdetil_idr.HeaderText = "Amount(IDR)"
        cOrderdetil_idr.DataPropertyName = "orderdetil_idr"
        cOrderdetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_idr.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_idr.Width = 95
        cOrderdetil_idr.Visible = True
        cOrderdetil_idr.ReadOnly = False

        cOrderdetil_subtotal.Name = "orderdetil_rowsubtotal"
        cOrderdetil_subtotal.HeaderText = "Sub Total"
        cOrderdetil_subtotal.DataPropertyName = "orderdetil_rowsubtotal"
        cOrderdetil_subtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_subtotal.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_subtotal.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_subtotal.Width = 90
        cOrderdetil_subtotal.Visible = False
        cOrderdetil_subtotal.ReadOnly = True

        cOrderdetil_discount.Name = "orderdetil_discount"
        cOrderdetil_discount.HeaderText = "Disc."
        cOrderdetil_discount.DataPropertyName = "orderdetil_discount"
        cOrderdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_discount.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_discount.Width = 85
        cOrderdetil_discount.Visible = True
        cOrderdetil_discount.ReadOnly = False

        cOrderdetil_total.Name = "orderdetil_rowtotal"
        cOrderdetil_total.HeaderText = "Total"
        cOrderdetil_total.DataPropertyName = "orderdetil_rowtotal"
        cOrderdetil_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_total.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_total.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_total.Width = 90
        cOrderdetil_total.Visible = True
        cOrderdetil_total.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "ItemID"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 100
        cItem_id.Visible = False
        cItem_id.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "Unit"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 30
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_days.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_days.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_days.Width = 35
        cOrderdetil_days.Visible = False
        cOrderdetil_days.ReadOnly = True

        cOrderdetil_foreign.Name = "orderdetil_foreign"
        cOrderdetil_foreign.HeaderText = "Frgn Amount"
        cOrderdetil_foreign.DataPropertyName = "orderdetil_foreign"
        cOrderdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreign.Width = 110
        cOrderdetil_foreign.Visible = True
        cOrderdetil_foreign.ReadOnly = False

        cOrderdetil_foreignrate.Name = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.HeaderText = "Rate"
        cOrderdetil_foreignrate.DataPropertyName = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreignrate.Width = 100
        cOrderdetil_foreignrate.Visible = True
        cOrderdetil_foreignrate.ReadOnly = False

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "Budget Line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 100
        cBudgetdetil_line.Visible = False
        cBudgetdetil_line.ReadOnly = False

        cBudgetaccount_id.Name = "budgetaccount_id"
        cBudgetaccount_id.HeaderText = "Budget Acc"
        cBudgetaccount_id.DataPropertyName = "budgetaccount_id"
        cBudgetaccount_id.Width = 100
        cBudgetaccount_id.Visible = False
        cBudgetaccount_id.ReadOnly = False

        cOld_orderdetil_id.Name = "old_orderdetil_id"
        cOld_orderdetil_id.HeaderText = "old_orderdetil_id"
        cOld_orderdetil_id.DataPropertyName = "old_orderdetil_id"
        cOld_orderdetil_id.Width = 100
        cOld_orderdetil_id.Visible = False
        cOld_orderdetil_id.ReadOnly = False

        cOrderdetil_actual.Name = "orderdetil_actual"
        cOrderdetil_actual.HeaderText = "orderdetil_actual"
        cOrderdetil_actual.DataPropertyName = "orderdetil_actual"
        cOrderdetil_actual.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_actual.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_actual.Width = 100
        cOrderdetil_actual.Visible = False
        cOrderdetil_actual.ReadOnly = False

        cOrderdetil_actualnote.Name = "orderdetil_actualnote"
        cOrderdetil_actualnote.HeaderText = "orderdetil_actualnote"
        cOrderdetil_actualnote.DataPropertyName = "orderdetil_actualnote"
        cOrderdetil_actualnote.Width = 100
        cOrderdetil_actualnote.Visible = False
        cOrderdetil_actualnote.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cOrderdetil_pphpercent.Name = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.HeaderText = "PPH(%)"
        cOrderdetil_pphpercent.DataPropertyName = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pphpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_pphpercent.Width = 80
        cOrderdetil_pphpercent.Visible = True
        cOrderdetil_pphpercent.ReadOnly = False

        cOrderdetil_pph.Name = "orderdetil_pph"
        cOrderdetil_pph.HeaderText = "PPH Amount"
        cOrderdetil_pph.DataPropertyName = "orderdetil_pph"
        cOrderdetil_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pph.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_pph.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_pph.Width = 100
        cOrderdetil_pph.Visible = True
        cOrderdetil_pph.ReadOnly = True

        cOrderdetil_ppnpercent.Name = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.HeaderText = "PPN(%)"
        cOrderdetil_ppnpercent.DataPropertyName = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppnpercent.Width = 80
        cOrderdetil_ppnpercent.Visible = True
        cOrderdetil_ppnpercent.ReadOnly = False

        cOrderdetil_ppn.Name = "orderdetil_ppn"
        cOrderdetil_ppn.HeaderText = "PPN Amount"
        cOrderdetil_ppn.DataPropertyName = "orderdetil_ppn"
        cOrderdetil_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppn.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppn.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_ppn.Width = 100
        cOrderdetil_ppn.Visible = True
        cOrderdetil_ppn.ReadOnly = True

        cOrderdetil_foreign_pphpercent.Name = "orderdetil_foreign_pphpercent"
        cOrderdetil_foreign_pphpercent.HeaderText = "Frgn PPH(%)"
        cOrderdetil_foreign_pphpercent.DataPropertyName = "orderdetil_foreign_pphpercent"
        cOrderdetil_foreign_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign_pphpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreign_pphpercent.Width = 100
        cOrderdetil_foreign_pphpercent.Visible = True
        cOrderdetil_foreign_pphpercent.ReadOnly = False

        cOrderdetil_foreign_pph.Name = "orderdetil_foreign_pph"
        cOrderdetil_foreign_pph.HeaderText = "Frgn PPH Amount"
        cOrderdetil_foreign_pph.DataPropertyName = "orderdetil_foreign_pph"
        cOrderdetil_foreign_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign_pph.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreign_pph.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_foreign_pph.Width = 120
        cOrderdetil_foreign_pph.Visible = True
        cOrderdetil_foreign_pph.ReadOnly = True

        cOrderdetil_foreign_ppnpercent.Name = "orderdetil_foreign_ppnpercent"
        cOrderdetil_foreign_ppnpercent.HeaderText = "Frgn PPN(%)"
        cOrderdetil_foreign_ppnpercent.DataPropertyName = "orderdetil_foreign_ppnpercent"
        cOrderdetil_foreign_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign_ppnpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreign_ppnpercent.Width = 100
        cOrderdetil_foreign_ppnpercent.Visible = True
        cOrderdetil_foreign_ppnpercent.ReadOnly = False

        cOrderdetil_foreign_ppn.Name = "orderdetil_foreign_ppn"
        cOrderdetil_foreign_ppn.HeaderText = "Frgn PPN Amount"
        cOrderdetil_foreign_ppn.DataPropertyName = "orderdetil_foreign_ppn"
        cOrderdetil_foreign_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign_ppn.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreign_ppn.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_foreign_ppn.Width = 120
        cOrderdetil_foreign_ppn.Visible = True
        cOrderdetil_foreign_ppn.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.AutoGenerateColumns = False
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { _
            cbOrderdetil_type, _
            cOrderdetil_line, _
            cbItem_name, _
            cOrderdetil_descr, _
            cOrderdetil_qty, _
            cbUnit_name, _
            cbCurrency, _
            cOrderdetil_idr, _
            cOrderdetil_subtotal, _
            cOrderdetil_discount, _
            cOrderdetil_total, _
            cOrderdetil_pphpercent, cOrderdetil_pph, _
            cOrderdetil_ppnpercent, cOrderdetil_ppn, _
            cOrderdetil_foreign, cOrderdetil_foreignrate, _
            cOrderdetil_foreign_pphpercent, cOrderdetil_foreign_pph, _
            cOrderdetil_foreign_ppnpercent, cOrderdetil_foreign_ppn, _
            cCategory_name, _
            cCategory_spktype, _
            cOrder_id, cItem_id, cUnit_id, cCurrency_id, cOrderdetil_days, _
            cBudgetdetil_line, cBudgetaccount_id, _
            cOld_orderdetil_id, cOrderdetil_actual, cOrderdetil_actualnote, _
            cChannel_id})

        objDgv.Dock = DockStyle.Fill

    End Function

    Private Function FormatDgvTrnOrderpaymreq(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnOrderpaymreq
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderpaymreq_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymentreq_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderpaymreq_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderpaymreq_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderpaymreq_line.Name = "orderpaymreq_line"
        cOrderpaymreq_line.HeaderText = "Line"
        cOrderpaymreq_line.DataPropertyName = "orderpaymreq_line"
        cOrderpaymreq_line.Width = 40
        cOrderpaymreq_line.Visible = True
        cOrderpaymreq_line.ReadOnly = True

        cPaymentreq_id.Name = "paymentreq_id"
        cPaymentreq_id.HeaderText = "PA Ref"
        cPaymentreq_id.DataPropertyName = "paymentreq_id"
        cPaymentreq_id.Width = 80
        cPaymentreq_id.Visible = True
        cPaymentreq_id.ReadOnly = False

        cOrderpaymreq_descr.Name = "orderpaymreq_descr"
        cOrderpaymreq_descr.HeaderText = "Description"
        cOrderpaymreq_descr.DataPropertyName = "orderpaymreq_descr"
        cOrderpaymreq_descr.Width = 180
        cOrderpaymreq_descr.Visible = True
        cOrderpaymreq_descr.ReadOnly = False

        cOrderpaymreq_amount.Name = "orderpaymreq_amount"
        cOrderpaymreq_amount.HeaderText = "Amount"
        cOrderpaymreq_amount.DataPropertyName = "orderpaymreq_amount"
        cOrderpaymreq_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderpaymreq_amount.DefaultCellStyle.Format = "#,##0.00"
        cOrderpaymreq_amount.Width = 100
        cOrderpaymreq_amount.Visible = True
        cOrderpaymreq_amount.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrderpaymreq_line, _
            cOrder_id, _
            cPaymentreq_id, _
            cOrderpaymreq_descr, _
            cOrderpaymreq_amount, _
            cChannel_id})

        objDgv.Dock = DockStyle.Fill

    End Function

    Private Function FormatDgvTrnPurchaseReq(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cRequest_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_ordered As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRequestdetil_selected As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRequestdetil_added As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRequest_strukturunitid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_strukturunitname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_itemid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_itemname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_foreignreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "Request ID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 100
        cRequest_id.Visible = True
        cRequest_id.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 65
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "BudgetDetil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 85
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True

        cOrder_id.Name = "requestdetil_refreference"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "requestdetil_refreference"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cRequest_strukturunitid.Name = "strukturunit_id"
        cRequest_strukturunitid.HeaderText = "strukturunit_id"
        cRequest_strukturunitid.DataPropertyName = "strukturunit_id"
        cRequest_strukturunitid.Width = 100
        cRequest_strukturunitid.Visible = False
        cRequest_strukturunitid.ReadOnly = True

        cRequest_strukturunitname.Name = "strukturunit_name"
        cRequest_strukturunitname.HeaderText = "Dept"
        cRequest_strukturunitname.DataPropertyName = "strukturunit_name"
        cRequest_strukturunitname.Width = 130
        cRequest_strukturunitname.Visible = True
        cRequest_strukturunitname.ReadOnly = True

        cRequestdetil_ordered.Name = "requestdetil_ordered"
        cRequestdetil_ordered.HeaderText = "Select"
        cRequestdetil_ordered.DataPropertyName = "requestdetil_ordered"
        cRequestdetil_ordered.Width = 50
        cRequestdetil_ordered.Visible = True
        cRequestdetil_ordered.ReadOnly = False

        cRequestdetil_selected.Name = "requestdetil_selected"
        cRequestdetil_selected.HeaderText = "Select"
        cRequestdetil_selected.DataPropertyName = "requestdetil_selected"
        cRequestdetil_selected.Width = 50
        cRequestdetil_selected.Visible = False
        cRequestdetil_selected.ReadOnly = False

        cRequestdetil_added.Name = "requestdetil_added"
        cRequestdetil_added.HeaderText = "Added"
        cRequestdetil_added.DataPropertyName = "requestdetil_added"
        cRequestdetil_added.Width = 50
        cRequestdetil_added.Visible = False
        cRequestdetil_added.ReadOnly = False

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "Line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 35
        cRequestdetil_line.Visible = True
        cRequestdetil_line.ReadOnly = True

        cRequestdetil_itemid.Name = "item_id"
        cRequestdetil_itemid.HeaderText = "item_id"
        cRequestdetil_itemid.DataPropertyName = "item_id"
        cRequestdetil_itemid.Width = 100
        cRequestdetil_itemid.Visible = False
        cRequestdetil_itemid.ReadOnly = True

        cRequestdetil_itemname.Name = "item_name"
        cRequestdetil_itemname.HeaderText = "Item"
        cRequestdetil_itemname.DataPropertyName = "item_name"
        cRequestdetil_itemname.Width = 130
        cRequestdetil_itemname.Visible = True
        cRequestdetil_itemname.ReadOnly = True

        cunit_id.Name = "unit_id"
        cunit_id.HeaderText = "unit_id"
        cunit_id.DataPropertyName = "unit_id"
        cunit_id.Width = 100
        cunit_id.Visible = False
        cunit_id.ReadOnly = True

        cUnit_name.Name = "unit_name"
        cUnit_name.HeaderText = "Unit"
        cUnit_name.DataPropertyName = "unit_name"
        cUnit_name.Width = 40
        cUnit_name.Visible = True
        cUnit_name.ReadOnly = True

        cRequestdetil_descr.Name = "requestdetil_descr"
        cRequestdetil_descr.HeaderText = "Unit"
        cRequestdetil_descr.DataPropertyName = "requestdetil_descr"
        cRequestdetil_descr.Width = 120
        cRequestdetil_descr.Visible = True
        cRequestdetil_descr.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cCurrency_name.Name = "currency_id"
        cCurrency_name.HeaderText = "Curr"
        cCurrency_name.DataPropertyName = "currency_id"
        cCurrency_name.Width = 50
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = False
        cCurrency_name.ValueMember = "currency_id"
        cCurrency_name.DisplayMember = "currency_shortname"
        cCurrency_name.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        cCurrency_name.DisplayStyleForCurrentCellOnly = True
        cCurrency_name.AutoComplete = True
        cCurrency_name.DataSource = Me.tbl_MstCurrency

        cRequest_date.Name = "request_bookdt"
        cRequest_date.HeaderText = "Date"
        cRequest_date.DataPropertyName = "request_bookdt"
        cRequest_date.DefaultCellStyle.Format = "dd/MM/yyyy"
        cRequest_date.Width = 80
        cRequest_date.Visible = True
        cRequest_date.ReadOnly = True

        cRequestdetil_qty.Name = "requestdetil_qty"
        cRequestdetil_qty.HeaderText = "Qty"
        cRequestdetil_qty.DataPropertyName = "requestdetil_qty"
        cRequestdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_qty.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_qty.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_qty.Width = 40
        cRequestdetil_qty.Visible = True
        cRequestdetil_qty.ReadOnly = True

        cRequestdetil_foreignreal.Name = "requestdetil_foreignreal"
        cRequestdetil_foreignreal.HeaderText = "Amount"
        cRequestdetil_foreignreal.DataPropertyName = "requestdetil_foreignreal"
        cRequestdetil_foreignreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_foreignreal.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_foreignreal.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_foreignreal.Width = 100
        cRequestdetil_foreignreal.Visible = True
        cRequestdetil_foreignreal.ReadOnly = True

        cRequestdetil_discount.Name = "requestdetil_discount"
        cRequestdetil_discount.HeaderText = "Discount"
        cRequestdetil_discount.DataPropertyName = "requestdetil_discount"
        cRequestdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_discount.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_discount.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_discount.Width = 100
        cRequestdetil_discount.Visible = True
        cRequestdetil_discount.ReadOnly = True

        cRequestdetil_foreignrate.Name = "requestdetil_foreignrate"
        cRequestdetil_foreignrate.HeaderText = "Rate"
        cRequestdetil_foreignrate.DataPropertyName = "requestdetil_foreignrate"
        cRequestdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_foreignrate.Width = 70
        cRequestdetil_foreignrate.Visible = True
        cRequestdetil_foreignrate.ReadOnly = True

        cRequestdetil_idr.Name = "requestdetil_idr"
        cRequestdetil_idr.HeaderText = "Amount IDR"
        cRequestdetil_idr.DataPropertyName = "requestdetil_idr"
        cRequestdetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_idr.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_idr.Width = 100
        cRequestdetil_idr.Visible = True
        cRequestdetil_idr.ReadOnly = True

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ScrollBars = ScrollBars.Both
        objDgv.Dock = DockStyle.Fill
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
            cRequestdetil_ordered, _
            cRequestdetil_selected, _
            cRequestdetil_added, _
            cRequest_id, _
            cRequest_date, _
            cRequestdetil_line, _
            cRequestdetil_itemname, _
            cRequestdetil_descr, _
            cUnit_id, _
            cUnit_name, _
            cRequestdetil_itemid, _
            cRequestdetil_qty, _
            cCurrency_id, _
            cCurrency_name, _
            cRequestdetil_foreignreal, _
            cRequestdetil_discount, _
            cRequestdetil_foreignrate, _
            cRequestdetil_idr, _
            cRequest_strukturunitid, _
            cRequest_strukturunitname, _
            cOrder_id, _
            cBudget_id, _
            cBudgetdetil_id _
        })

    End Function

    Private Function InitLayoutUI() As Boolean
        Dim i As Byte

        Me.FlatTabMain.Anchor = AnchorStyles.Bottom
        Me.FlatTabMain.Anchor += AnchorStyles.Top
        Me.FlatTabMain.Anchor += AnchorStyles.Right
        Me.FlatTabMain.Anchor += AnchorStyles.Left

        Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnOrder.Dock = DockStyle.Fill
        Me.DgvTrnOrderdetil.Dock = DockStyle.Fill
        Me.DgvTrnOrderPaymReq.Dock = DockStyle.Fill
        Me.dgvTrnMaintReq.Dock = DockStyle.Fill

        Me.FormatDgvTrnOrder(Me.DgvTrnOrder)
        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
        Me.FormatDgvTrnOrderpaymreq(Me.DgvTrnOrderPaymReq)
        Me.FormatDgvTrnPurchaseReq(Me.dgvTrnMaintReq)

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.Gainsboro
        Next
        Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.White

        'Set Form as ReadOnly when parameter _FORMMODE = "VIEW"
        If Me._FORMMODE = "VIEW" Then
            Me.uiTrnMaintenanceOrder_SetViewOnly()
        End If

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Order_id.DataBindings.clear()
        Me.dtp_order_date.DataBindings.Clear()
        Me.obj_Order_descr.DataBindings.Clear()
        Me.obj_order_note.DataBindings.Clear()
        Me.obj_Request_id.DataBindings.Clear()
        Me.obj_Old_program_id.DataBindings.Clear()
        Me.obj_Budget_id.DataBindings.Clear()
        'Me.obj_Order_pph_percent.DataBindings.Clear()
        'Me.obj_Order_ppn_percent.DataBindings.Clear()
        Me.obj_Order_insurancecost.DataBindings.Clear()
        Me.obj_Order_transportationcost.DataBindings.Clear()
        Me.obj_Order_operatorcost.DataBindings.Clear()
        Me.obj_Order_othercost.DataBindings.Clear()
        Me.obj_Order_authname.DataBindings.Clear()
        Me.obj_Order_authposition.DataBindings.Clear()
        Me.obj_Order_canceled.DataBindings.Clear()
        Me.obj_Order_createby.DataBindings.Clear()
        Me.obj_Order_createdate.DataBindings.Clear()
        Me.obj_Order_modifyby.DataBindings.Clear()
        Me.obj_Order_modifydate.DataBindings.Clear()
        Me.obj_Order_discount.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()
        'Me.obj_Order_source.Clear()
        'Me.obj_Ordertype_id.Clear()

        Me.obj_Order_revno.DataBindings.Clear()
        Me.dtp_order_revdate.DataBindings.Clear()
        Me.obj_order_revdesc.DataBindings.Clear()

        Me.obj_Rekanan_id.DataBindings.Clear()
        Me.obj_Old_program_id.DataBindings.Clear()
        Me.obj_Budget_id.DataBindings.Clear()

        Me.cbo_Periode_id.DataBindings.Clear()
        Me.cbo_Budget_name.DataBindings.Clear()
        Me.cbo_Budget_amount.DataBindings.Clear()
        Me.cbo_Rekanan_name.DataBindings.Clear()
        Me.cbo_Rekanan_contact.DataBindings.Clear()
        Me.cbo_Old_program_name.DataBindings.Clear()
        Me.cbo_Deptname.DataBindings.Clear()

        'Me.obj_Order_subtotal.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_id"))
        Me.dtp_order_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_date"))
        Me.obj_Order_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_descr"))
        Me.obj_Order_note.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_note"))
        Me.obj_Request_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "request_id"))
        'Me.obj_Order_pph_percent.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_pph_percent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Order_ppn_percent.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_ppn_percent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_insurancecost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_insurancecost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_transportationcost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_transportationcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_operatorcost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_operatorcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_othercost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_othercost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_authname.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authname"))
        Me.obj_Order_authposition.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authposition"))
        Me.obj_Order_canceled.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_canceled"))
        Me.obj_Order_createby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_createby"))
        Me.obj_Order_createdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_createdate"))
        Me.obj_Order_modifyby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_modifyby"))
        Me.obj_Order_modifydate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_modifydate"))
        Me.obj_Order_discount.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_discount", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "channel_id"))
        'Me.obj_Order_source.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_source"))
        'Me.obj_Ordertype_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "ordertype_id"))

        'Me.obj_cp.DataBindings.Add(New Binding("Text", Me.tbl_MstRekanan, "rekanan_cp"))

        Me.obj_Order_revno.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revno"))
        Me.dtp_order_revdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revdate"))
        Me.obj_order_revdesc.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revdesc"))

        Me.obj_Budget_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "budget_id"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "rekanan_id"))
        Me.obj_Old_program_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "old_program_id"))

        Me.cbo_Periode_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "periode_id"))
        Me.cbo_Budget_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "budget_id"))
        Me.cbo_Budget_amount.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "budget_id"))
        Me.cbo_Rekanan_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "rekanan_id"))
        'Me.cbo_Rekanan_contact.DataBindings.Add(New Binding("SelectedText", Me.tbl_TrnOrder_Temp, "order_rekanan_contact"))
        Me.cbo_Old_program_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "old_program_id"))
        Me.cbo_Deptname.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "strukturunit_id"))

        'Me.obj_Order_subtotal.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_subtotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiTrnMaintenanceOrder_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnOrder_Temp
        Me.tbl_TrnOrder_Temp.Clear()
        Me.tbl_TrnOrder_Temp.Columns("order_id").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_date").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_descr").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_note").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_intref").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("request_id").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("rekanan_id").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_prognm").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_progsch").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("budget_id").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_eps").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_setdate").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_settime").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_setlocation").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_utilizeddatestart").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_utilizeddateend").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_utilizedtimestart").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_utilizedtimeend").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_utilizedlocation").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_pph_percent").DefaultValue = 4.5
        Me.tbl_TrnOrder_Temp.Columns("order_ppn_percent").DefaultValue = 10
        Me.tbl_TrnOrder_Temp.Columns("order_insurancecost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_transportationcost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_operatorcost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_othercost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_authname").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_authposition").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_canceled").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_createby").DefaultValue = Me.UserName
        Me.tbl_TrnOrder_Temp.Columns("order_createdate").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_modifyby").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_modifydate").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_discount").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_source").DefaultValue = Me._ORDER_SOURCE
        Me.tbl_TrnOrder_Temp.Columns("ordertype_id").DefaultValue = Me._ORDERTYPE_ID
        Me.tbl_TrnOrder_Temp.Columns("order_revno").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_revdate").DefaultValue = Now()
        Me.tbl_TrnOrder_Temp.Columns("order_revdesc").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_approved").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnOrder_Temp.Columns("periode_id").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_spkrequired").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_spkworktype").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_spkdesc").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrname").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvraddr1").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvraddr2").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvraddr3").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrtelp").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrfax").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrhp").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("old_program_id").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("old_category_id").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("old_apref").DefaultValue = ""


        ' TODO: Set Default Value for tbl_TrnOrderdetil
        Me.tbl_TrnOrderdetil.Clear()
        Me.tbl_TrnOrderdetil = clsDataset.CreateTblTrnOrderdetil()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = 0
        Me.tbl_TrnOrderdetil.Columns("orderdetil_type").DefaultValue = "Item"
        Me.tbl_TrnOrderdetil.Columns("orderdetil_qty").DefaultValue = 1
        Me.tbl_TrnOrderdetil.Columns("orderdetil_days").DefaultValue = 1
        Me.tbl_TrnOrderdetil.Columns("unit_id").DefaultValue = 1
        Me.tbl_TrnOrderdetil.Columns("orderdetil_pphpercent").DefaultValue = 4.5
        Me.tbl_TrnOrderdetil.Columns("orderdetil_ppnpercent").DefaultValue = 10

        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10
        Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderdetil
        Me.DgvTrnOrderPaymReq.DataSource = Me.tbl_TrnOrderPaymReq

        Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnOrder_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_GetOrderSource() As Boolean
        Dim tbl_TrnRequest As New DataTable '= clsDataset.CreateTblRequest()
        Dim dlgRequest As New dlgGetRequest()
        Dim mDataFiller As New clsDataFiller(Me.DSN)

        Try
            '[PQ = Purchase Request; RQ = Rental Request; MQ = Maintenance Request]
            'tbl_TrnRequest.Clear()
            'Me.DataFill(tbl_TrnRequest, "pr_TrnRequest_Select", "jurnaltype_id = 'MQ'")

            Dim criteria As String = " LEFT(transaksi_requestdetil.request_id, 2) = 'MQ' AND requestdetil_remark = 1 AND request_canceled = 0 AND request_approved1 = 1 AND request_approved2 = 1 AND request_programtype = 'NP' AND (requestdetil_refreference = NULL OR requestdetil_refreference = '')"
            Dim channel_id As String = "TTV"

            tbl_TrnRequest.Clear()
            Try
                mDataFiller.DataFill(tbl_TrnRequest, "cq_TrnRequestdetil_Select", criteria)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            With dlgRequest
                .dgvRequestList.DataSource = tbl_TrnRequest
                .Text = "Get Request"
                .ProgType = "NP"
                .ShowDialog()
                If .DialogResult = DialogResult.OK Then

                    Me._ORDER_SOURCE = "FromRequest"
                    Dim reqIndex As Integer = .dgvRequestList.CurrentRow.Index

                    With .dgvRequestList
                        Me.obj_Request_id.Text = .Item("request_id", reqIndex).Value
                        Me.cbo_Deptname.SelectedValue = clsUtil.IsDbNull(.Item("strukturunit_id", reqIndex).Value, 0)
                        Me.cbo_Budget_name.SelectedValue = clsUtil.IsDbNull(.Item("budget_id", reqIndex).Value, 0)
                        Me.obj_Budget_id.Text = clsUtil.IsDbNull(.Item("budget_id", reqIndex).Value, 0)
                        Me.obj_Order_source.Text = Me._ORDER_SOURCE


                    End With

                    'DETIL         
                    Dim i As Integer
                    Dim type As String = ""
                    Dim rowdetil As DataRow

                    For i = 0 To .dgvRequestList.Rows.Count - 1
                        If .dgvRequestList.Rows(i).Cells("requestdetil_ordered").Value = 1 Then

                            If clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("requestdetil_type"), 1) = 1 Then
                                type = "Item"
                            Else
                                type = "Descr"
                            End If
                            rowdetil = Me.tbl_TrnOrderdetil.NewRow()
                            rowdetil("orderdetil_type") = type
                            rowdetil("item_id") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("item_id"), 0)
                            rowdetil("orderdetil_qty") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("requestdetil_qty"), 0)
                            rowdetil("currency_id") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("currency_id"), 1)
                            rowdetil("unit_id") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("unit_id"), 0)
                            rowdetil("orderdetil_idr") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("requestdetil_idr"), 0)
                            rowdetil("orderdetil_foreign") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("requestdetil_foreign"), 0)
                            rowdetil("orderdetil_foreignrate") = clsUtil.IsDbNull(tbl_TrnRequest.Rows(i).Item("requestdetil_foreignrate"), 0)
                            Me.tbl_TrnOrderdetil.Rows.Add(rowdetil)
                        End If

                    Next




                    '    Dim reqid As String = .dgvRequestList.Item("request_id", reqIndex).Value
                    '    tbl_TrnRequestDetil.Clear()
                    '    Me.DataFill(tbl_TrnRequestDetil, "pr_TrnRequestdetil_Select", "request_id = '" & reqid & "'")

                    '    If tbl_TrnRequestDetil.Rows.Count > 0 Then
                    '        Dim i As Byte
                    '        For i = 0 To tbl_TrnRequestDetil.Rows.Count - 1
                    '            Me.tbl_TrnOrderdetil.Rows.Add()
                    '            If tbl_TrnRequestDetil.Rows(i).Item("item_id").ToString <> "" Then
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_type") = "Item"
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_qty") = tbl_TrnRequestDetil.Rows(i).Item("requestdetil_qty")
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_idr") = tbl_TrnRequestDetil.Rows(i).Item("requestdetil_idr")
                    '                'Me.tbl_TrnOrderdetil.Rows(i).Item("unit_id") = tbl_TrnRequestDetil.Rows(i).Item("unit_id")
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("unit_id") = tbl_TrnRequestDetil.Rows(i).Item("requestdetil_unit")
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("item_id") = tbl_TrnRequestDetil.Rows(i).Item("item_id")
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("req_line") = tbl_TrnRequestDetil.Rows(i).Item("requestdetil_line")

                    '            Else
                    '                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_type") = "Descr"
                    '            End If
                    '            Me.tbl_TrnOrderdetil.Rows(i).Item("req_line") = tbl_TrnRequestDetil.Rows(i).Item("requestdetil_line")

                    '        Next

                    '    End If
                    'Else
                Else
                    Me.obj_Order_source.Text = Me._ORDER_SOURCE
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Source + " - " + ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""

        txtCondition = " ordertype_id='" & Me._ORDERTYPE_ID & "' and channel_id='" & Me._CHANNEL + "'"

        '-- From last month
        Dim bulan As Byte = Month(Now)
        Dim tahun As Integer = Year(Now)

        If bulan = 1 Then
            bulan = 12
            tahun = tahun - 1
        Else
            bulan = bulan - 1
        End If

        Dim datestart = bulan & "/1" & "/" & tahun

        If Me.chkSearchLast2Periode.Checked Then
            txtSearchCriteria = " order_date >='" + datestart + "'"
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Periode
        If Me.chkSearchPeriode.Checked Then
            txtSearchCriteria = String.Format(" periode_id = '{0}' ", Me.txtSearchPeriode.Text)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If


        '-- OrderID
        If Me.chkSearchOrderID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("order_id", Me.txtSearchOrderID)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Budget ID
        If Me.chkSearchBudgetCode.Checked Then
            txtSearchCriteria = String.Format(" budget_id = '{0}' ", Me.txtSearchBudgetCode.Text)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Vendor
        If Me.chkSearchRekanan.Checked Then
            txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.cboSearchRekanan.SelectedValue)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        criteria = txtCondition

        Me.tbl_TrnOrder.Clear()
        Try
            Me.DataFill(Me.tbl_TrnOrder, "pr_TrnOrder_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Not Me.COMBO_ISFILLED Then
            Me.uiTrnMaintenanceOrder_LoadDataCombo()
        End If

        'uiTrnMaintenanceOrder_GetOrderCreator()

    End Function

    Private Function uiTrnMaintenanceOrder_Save() As Boolean
        'save data
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim channel_id As String
        Dim line As Integer
        Dim idr As Decimal
        Dim rowFilter As String

        channel_id = Me._CHANNEL

        Dim tbl_TrnOrder_Temp_Changes As DataTable
        Dim tbl_TrnOrderdetil_Changes As DataTable
        Dim tbl_TrnOrderpaymreq_Changes As DataTable

        Dim success As Boolean
        Dim order_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(order_id)

        Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
        tbl_TrnOrder_Temp_Changes = Me.tbl_TrnOrder_Temp.GetChanges()

        Me.DgvTrnOrderdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
        tbl_TrnOrderdetil_Changes = Me.tbl_TrnOrderdetil.GetChanges()

        Me.DgvTrnOrderPaymReq.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderPaymReq).EndCurrentEdit()
        tbl_TrnOrderpaymreq_Changes = Me.tbl_TrnOrderPaymReq.GetChanges()

        If tbl_TrnOrderdetil_Changes IsNot Nothing Then
            For i = 0 To tbl_TrnOrderdetil_Changes.Rows.Count - 1
                If tbl_TrnOrderdetil_Changes.Rows(i).RowState <> DataRowState.Deleted Then
                    line = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_line")
                    idr = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_idr")
                    rowFilter = String.Format("orderdetil_line={0}", line)
                End If
            Next
        End If

        If tbl_TrnOrder_Temp_Changes IsNot Nothing _
            Or tbl_TrnOrderdetil_Changes IsNot Nothing _
                Or tbl_TrnOrderpaymreq_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnOrder_Temp.Rows(0).RowState
                order_id = tbl_TrnOrder_Temp.Rows(0).Item("order_id")

                If tbl_TrnOrder_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnMaintenanceOrder_SaveMaster(order_id, tbl_TrnOrder_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnMaintenanceOrder_SaveMaster(tbl_TrnOrder_Temp_Changes)")
                    Me.tbl_TrnOrder_Temp.AcceptChanges()
                End If

                If tbl_TrnOrderdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                        If Me.tbl_TrnOrderdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderdetil.Rows(i).Item("order_id") = order_id
                        End If
                    Next

                    success = Me.uiTrnMaintenanceOrder_SaveDetil(order_id, tbl_TrnOrderdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnMaintenanceOrder_SaveDetil(tbl_TrnOrderdetil_Changes)")
                    Me.tbl_TrnOrderdetil.AcceptChanges()
                End If

                Me.uiTrnMaintenanceOrder_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN)
                Me.uiTrnMaintenanceOrder_TotalCalculate()

                If tbl_TrnOrderpaymreq_Changes IsNot Nothing Then
                    success = Me.uiTrnMaintenanceOrder_SaveDetilPaymReq(order_id, tbl_TrnOrderpaymreq_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Payment Request Data at Me.uiTrnMaintenanceOrder_SavePaymentreqreference(tbl_TrnPaymentreqreference_Changes)")
                    Me.tbl_TrnOrderPaymReq.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.uiTrnMaintenanceOrder_OpenRowDetil(channel_id, order_id, dbConn)
                    Me.uiTrnMaintenanceOrder_OpenRowPaymReq(channel_id, order_id, dbConn)

                    Me.uiTrnMaintenanceOrder_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN)
                    Me.uiTrnMaintenanceOrder_TotalCalculate()
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.uiTrnMaintenanceOrder_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN)
                Me.uiTrnMaintenanceOrder_TotalCalculate()

            End If
        End If

        RaiseEvent FormAfterSave(order_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnMaintenanceOrder_SaveMaster(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer
        ' Save data: transaksi_order
        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrder_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "order_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_note", System.Data.OleDb.OleDbType.VarWChar, 510, "order_note"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_intref", System.Data.OleDb.OleDbType.VarWChar, 200, "order_intref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 24, "request_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200, "order_prognm"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30, "order_progsch"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4, "budget_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "order_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_setdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_settime", System.Data.OleDb.OleDbType.VarWChar, 10, "order_settime"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setlocation", System.Data.OleDb.OleDbType.VarWChar, 100, "order_setlocation"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddatestart", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_utilizeddatestart"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddateend", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_utilizeddateend"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimestart", System.Data.OleDb.OleDbType.VarWChar, 10, "order_utilizedtimestart"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimeend", System.Data.OleDb.OleDbType.VarWChar, 10, "order_utilizedtimeend"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedlocation", System.Data.OleDb.OleDbType.VarWChar, 100, "order_utilizedlocation"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_pph_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_pph_percent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_ppn_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_ppn_percent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_insurancecost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_transportationcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_operatorcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_othercost", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname", System.Data.OleDb.OleDbType.VarWChar, 40, "order_authname"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition", System.Data.OleDb.OleDbType.VarWChar, 60, "order_authposition"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname", Me._ORDER_AUTHNAME))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition", Me._ORDER_AUTHPOS))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "order_canceled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_createby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_createdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_modifyby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_modifydate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_discount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", System.Data.OleDb.OleDbType.VarWChar, 40, "order_source"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 40, "ordertype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", Me._ORDER_SOURCE))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", Me._ORDERTYPE_ID))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revno", System.Data.OleDb.OleDbType.VarWChar, 8, "order_revno"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_revdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_revdesc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.Boolean, 1, "order_approved"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkrequired", System.Data.OleDb.OleDbType.Boolean, 1, "order_spkrequired"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkworktype", System.Data.OleDb.OleDbType.VarWChar, 510, "order_spkworktype"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_spkdesc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrname", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrname"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr1", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr2", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr2"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr3", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr3"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrtelp", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrtelp"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrfax", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrfax"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrhp", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrhp"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_program_id", System.Data.OleDb.OleDbType.Integer, 4, "old_program_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_category_id", System.Data.OleDb.OleDbType.VarWChar, 24, "old_category_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_apref", System.Data.OleDb.OleDbType.VarWChar, 18, "old_apref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_programtype", Me._PROGRAMTYPE))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_singlebudget", System.Data.OleDb.OleDbType.Boolean, 1, "order_singlebudget"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsstart", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsstart", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsend", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsend", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrder_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "order_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_note", System.Data.OleDb.OleDbType.VarWChar, 510, "order_note"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_intref", System.Data.OleDb.OleDbType.VarWChar, 200, "order_intref"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 24, "request_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200, "order_prognm"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30, "order_progsch"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4, "budget_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "order_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_setdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_settime", System.Data.OleDb.OleDbType.VarWChar, 10, "order_settime"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setlocation", System.Data.OleDb.OleDbType.VarWChar, 100, "order_setlocation"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddatestart", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_utilizeddatestart"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddateend", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_utilizeddateend"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimestart", System.Data.OleDb.OleDbType.VarWChar, 10, "order_utilizedtimestart"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimeend", System.Data.OleDb.OleDbType.VarWChar, 10, "order_utilizedtimeend"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedlocation", System.Data.OleDb.OleDbType.VarWChar, 100, "order_utilizedlocation"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_pph_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_pph_percent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_ppn_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_ppn_percent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_insurancecost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_transportationcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_operatorcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_othercost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname", System.Data.OleDb.OleDbType.VarWChar, 40, "order_authname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition", System.Data.OleDb.OleDbType.VarWChar, 60, "order_authposition"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "order_canceled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_createdate"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_modifyby"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_modifydate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", Me.UserName))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", Now()))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", System.Data.OleDb.OleDbType.VarWChar, 40, "order_source"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 40, "ordertype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revno", System.Data.OleDb.OleDbType.VarWChar, 8, "order_revno"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_revdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_revdesc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.Boolean, 1, "order_approved"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkrequired", System.Data.OleDb.OleDbType.Boolean, 1, "order_spkrequired"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkworktype", System.Data.OleDb.OleDbType.VarWChar, 510, "order_spkworktype"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_spkdesc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrname", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr1", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr2", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr3", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr3"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrtelp", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrtelp"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrfax", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrfax"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrhp", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrhp"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_program_id", System.Data.OleDb.OleDbType.Integer, 4, "old_program_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_category_id", System.Data.OleDb.OleDbType.VarWChar, 24, "old_category_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_apref", System.Data.OleDb.OleDbType.VarWChar, 18, "old_apref"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_programtype", Me._PROGRAMTYPE))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_singlebudget", System.Data.OleDb.OleDbType.Boolean, 1, "order_singlebudget"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsstart", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsstart", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsend", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsend", System.Data.DataRowVersion.Current, Nothing))


        'dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrder_Update", dbConn)
        'dbCmdUpdate.CommandType = CommandType.StoredProcedure
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_date"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "order_descr"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_note", System.Data.OleDb.OleDbType.VarWChar, 510, "order_note"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_intref", System.Data.OleDb.OleDbType.VarWChar, 200, "order_intref"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 24, "request_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200, "order_prognm"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30, "order_progsch"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4, "budget_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "order_eps"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_setdate"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_settime", System.Data.OleDb.OleDbType.VarWChar, 10, "order_settime"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setlocation", System.Data.OleDb.OleDbType.VarWChar, 100, "order_setlocation"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddatestart", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_utilizeddatestart"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddateend", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_utilizeddateend"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimestart", System.Data.OleDb.OleDbType.VarWChar, 10, "order_utilizedtimestart"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimeend", System.Data.OleDb.OleDbType.VarWChar, 10, "order_utilizedtimeend"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedlocation", System.Data.OleDb.OleDbType.VarWChar, 100, "order_utilizedlocation"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_pph_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_pph_percent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_ppn_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_ppn_percent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_insurancecost", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_transportationcost", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_operatorcost", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_othercost", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname", System.Data.OleDb.OleDbType.VarWChar, 40, "order_authname"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition", System.Data.OleDb.OleDbType.VarWChar, 60, "order_authposition"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "order_canceled"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_createby"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_createdate"))
        ''dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_modifyby"))
        ''dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_modifydate"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", Me.UserName))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", Now()))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_discount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", System.Data.OleDb.OleDbType.VarWChar, 40, "order_source"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 40, "ordertype_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revno", System.Data.OleDb.OleDbType.VarWChar, 8, "order_revno"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_revdate"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_revdesc"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.Boolean, 1, "order_approved"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkrequired", System.Data.OleDb.OleDbType.Boolean, 1, "order_spkrequired"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkworktype", System.Data.OleDb.OleDbType.VarWChar, 510, "order_spkworktype"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_spkdesc"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrname", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrname"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr1", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr1"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr2", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr2"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr3", System.Data.OleDb.OleDbType.VarWChar, 200, "order_dlvraddr3"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrtelp", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrtelp"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrfax", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrfax"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrhp", System.Data.OleDb.OleDbType.VarWChar, 100, "order_dlvrhp"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_program_id", System.Data.OleDb.OleDbType.Integer, 4, "old_program_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_category_id", System.Data.OleDb.OleDbType.VarWChar, 24, "old_category_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_apref", System.Data.OleDb.OleDbType.VarWChar, 18, "old_apref"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            order_id = objTbl.Rows(0).Item("order_id")
            Me.tbl_TrnOrder_Temp.Clear()
            Me.tbl_TrnOrder_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnOrder.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnOrder).Position
            Me.tbl_TrnOrder.Rows.RemoveAt(curpos)
            Me.tbl_TrnOrder.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnOrder).Position = Me.BindingContext(Me.tbl_TrnOrder).Count

        Return True
    End Function

    Private Function uiTrnMaintenanceOrder_SaveDetil(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        ' Save data: transaksi_orderdetil
        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_requestid_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "orderdetil_requestid_ref"))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_requestid_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "orderdetil_requestid_ref"))
        dbCmdUpdate.Parameters("@order_id").Value = order_id


        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_requestid_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "orderdetil_requestid_ref"))
        dbCmdDelete.Parameters("@order_id").Value = order_id


        '' Save data: transaksi_orderdetil
        'dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderdetil_Insert", dbConn)
        'dbCmdInsert.CommandType = CommandType.StoredProcedure
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 40, "item_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        ''dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters("@order_id").Value = order_id


        'dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil_Update", dbConn)
        'dbCmdUpdate.CommandType = CommandType.StoredProcedure
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 40, "item_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters("@order_id").Value = order_id

        'dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderdetil_Delete", dbConn)
        'dbCmdDelete.CommandType = CommandType.StoredProcedure
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 40, "item_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters("@order_id").Value = order_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

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

    Private Function uiTrnMaintenanceOrder_SaveUse(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderdetiluse_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "orderdetiluse_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetiluse_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "orderdetiluse_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters("@order_id").Value = order_id

        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderdetiluse_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "orderdetiluse_date"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters("@order_id").Value = order_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


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

    Private Function uiTrnMaintenanceOrder_SaveDetilPaymReq(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderpaymreq
        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters("@order_id").Value = order_id


        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters("@order_id").Value = order_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


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

    Private Function uiTrnMaintenanceOrder_SaveDetilStrukturUnit(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderpaymreq
        dbCmdInsert = New OleDb.OleDbCommand("ms_MstStrukturunit_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))

        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_name", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        ''dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        'dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("ms_MstStrukturunit_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_name", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdUpdate.Parameters("@order_id").Value = order_id


        dbCmdDelete = New OleDb.OleDbCommand("ms_MstStrukturunit_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_name", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdDelete.Parameters("@order_id").Value = order_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


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

    Private Function uiTrnMaintenanceOrder_PrintPreview() As Boolean
        'print data

        Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim channel_id As String = ""

        Dim frmPrint As dlgViewRptRO = New dlgViewRptRO(Me.DSN)
        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
            MsgBox("Pilih data dulu..")
            Exit Function
        End If

        'ambil row yang dipilih di datagrid
        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
            row = Me.DgvTrnOrder.SelectedRows(i)
            order_id = row.Cells("order_id").Value
            channel_id = row.Cells("channel_id").Value

            If criteria = "" Then
                criteria = String.Format(" order_id = '{0}' ", order_id)
            Else
                criteria = String.Format(" {1} or order_id = '{0}' ", order_id, criteria)
            End If
        Next

        If criteria <> String.Empty Then
            criteria &= " and channel_id='" + channel_id + "'"
        End If

        frmPrint.SetIDCriteria(criteria)

        frmPrint.ShowDialog(Me)

        'Dim i As Integer
        'Dim row As DataGridViewRow
        'Dim order_id As String
        'Dim criteria As String = ""

        Dim frmPrintSPK As dlgViewRptROSPK = New dlgViewRptROSPK(Me.DSN)
        frmPrintSPK.ShowInTaskbar = False
        frmPrintSPK.StartPosition = FormStartPosition.CenterParent

        If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
            MsgBox("Pilih data dulu..")
            Exit Function
        End If

        'ambil row yang dipilih di datagrid
        criteria = String.Empty
        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
            row = Me.DgvTrnOrder.SelectedRows(i)
            If row.Cells("order_spkrequired").Value Then
                order_id = row.Cells("order_id").Value
                channel_id = row.Cells("channel_id").Value

                If criteria = "" Then
                    criteria = String.Format(" order_id = '{0}' ", order_id)
                Else
                    criteria = String.Format(" {1} or order_id = '{0}' ", order_id, criteria)
                End If
            End If
        Next

        If criteria <> String.Empty Then
            criteria &= " and channel_id='" + channel_id + "'"
            frmPrintSPK.SetIDCriteria(criteria)
            frmPrintSPK.ShowDialog(Me)
        End If

    End Function

    Private Function uiTrnMaintenanceOrder_Print() As Boolean

        Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim channel_id As String = ""

        Dim oPrint As clsPrintRO = New clsPrintRO(Me.DSN)
        'frmPrint.ShowInTaskbar = False
        'frmPrint.StartPosition = FormStartPosition.CenterParent

        If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
            MsgBox("Pilih data dulu..")
            Exit Function
        End If

        'ambil row yang dipilih di datagrid
        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
            row = Me.DgvTrnOrder.SelectedRows(i)
            order_id = row.Cells("order_id").Value
            channel_id = row.Cells("channel_id").Value

            If criteria = "" Then
                criteria = String.Format(" order_id = '{0}' ", order_id)
            Else
                criteria = String.Format(" {1} or order_id = '{0}' ", order_id, criteria)
            End If
        Next

        If criteria <> String.Empty Then
            criteria &= " and channel_id='" + channel_id + "'"
        End If

        oPrint.SetIDCriteria(criteria)

        oPrint.Cetak()

        ''Dim i As Integer
        ''Dim row As DataGridViewRow
        ''Dim order_id As String
        ''Dim criteria As String = ""

        Dim OPrintSPK As clsPrintROSPK = New clsPrintROSPK(Me.DSN)
        If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
            MsgBox("Pilih data dulu..")
            Exit Function
        End If

        'ambil row yang dipilih di datagrid
        criteria = String.Empty
        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
            row = Me.DgvTrnOrder.SelectedRows(i)
            If row.Cells("order_spkrequired").Value Then
                order_id = row.Cells("order_id").Value
                channel_id = row.Cells("channel_id").Value

                If criteria = "" Then
                    criteria = String.Format(" order_id = '{0}' ", order_id)
                Else
                    criteria = String.Format(" {1} or order_id = '{0}' ", order_id, criteria)
                End If
            End If
        Next

        If criteria <> String.Empty Then
            criteria &= " and channel_id='" + channel_id + "'"
            OPrintSPK.SetIDCriteria(criteria)
            OPrintSPK.Cetak()
        End If

    End Function

    Private Function uiTrnMaintenanceOrder_Delete() As Boolean
        Dim res As String = ""
        Dim order_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(order_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnMaintenanceOrder_DeleteRow(Me.DgvTrnOrder.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(order_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnMaintenanceOrder_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim order_id As String
        Dim NewRowIndex As Integer

        order_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("order_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrder_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@order_id").Value = order_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_date").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_descr", System.Data.OleDb.OleDbType.VarWChar, 4000))
        dbCmdDelete.Parameters("@order_descr").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_note", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdDelete.Parameters("@order_note").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_intref", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdDelete.Parameters("@order_intref").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@request_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@rekanan_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdDelete.Parameters("@order_prognm").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@order_progsch").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@budget_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_eps").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_setdate").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_settime", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@order_settime").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setlocation", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_setlocation").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddatestart", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_utilizeddatestart").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddateend", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_utilizeddateend").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimestart", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@order_utilizedtimestart").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimeend", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@order_utilizedtimeend").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedlocation", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_utilizedlocation").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_pph_percent", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_pph_percent").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_ppn_percent", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_ppn_percent").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_insurancecost").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_transportationcost").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_operatorcost").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_othercost").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@order_authname").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@order_authposition").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_canceled", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@order_canceled").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createby", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@order_createby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_createdate").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@order_modifyby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_modifydate").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_discount", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@order_discount").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@order_source").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@ordertype_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revno", System.Data.OleDb.OleDbType.VarWChar, 8))
        dbCmdDelete.Parameters("@order_revno").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@order_revdate").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdesc", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdDelete.Parameters("@order_revdesc").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@order_approved").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8))
        dbCmdDelete.Parameters("@periode_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkrequired", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@order_spkrequired").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkworktype", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdDelete.Parameters("@order_spkworktype").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkdesc", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdDelete.Parameters("@order_spkdesc").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrname", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_dlvrname").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr1", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdDelete.Parameters("@order_dlvraddr1").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr2", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdDelete.Parameters("@order_dlvraddr2").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr3", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdDelete.Parameters("@order_dlvraddr3").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrtelp", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_dlvrtelp").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrfax", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_dlvrfax").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrhp", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@order_dlvrhp").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_program_id", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@old_program_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_category_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@old_category_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_apref", System.Data.OleDb.OleDbType.VarWChar, 18))
        dbCmdDelete.Parameters("@old_apref").Value = DBNull.Value



        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnOrder.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnMaintenanceOrder_OpenRow(NewRowIndex)
                    Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnOrder.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnMaintenanceOrder_OpenRow(NewRowIndex)
                    Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)
                    Me.uiTrnMaintenanceOrder_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnOrder_Temp.Clear()
                Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)

            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            dbConn.Close()
        End Try
    End Function

    Private Function uiTrnMaintenanceOrder_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim order_id As String
        Dim channel_id As String

        order_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("order_id").Value
        channel_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Try
            dbConn.Open()
            Me.uiTrnMaintenanceOrder_OpenRowMaster(channel_id, order_id, dbConn)
            Me.uiTrnMaintenanceOrder_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnMaintenanceOrder_OpenRowPaymReq(channel_id, order_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnMaintenanceOrder_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(order_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnMaintenanceOrder_OpenRowMaster(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrder_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.Parameters("@Criteria").Value = "order_id='" + order_id + "' and channel_id='" + Me._CHANNEL + "'"
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrder_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnOrder_Temp)

            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMaintenanceOrder_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetil_Select", dbConn)

        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.Parameters("@Criteria").Value = "order_id='" + order_id + "' and channel_id='" + Me._CHANNEL + "'"

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderdetil.Clear()

        Me.tbl_TrnOrderdetil = clsDataset.CreateTblTrnOrderdetil()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnOrderdetil)
            Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMaintenanceOrder_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_OpenRowPaymReq(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderPaymReq.Clear()

        Me.tbl_TrnOrderPaymReq = clsDataset.CreateTblTrnOrderpaymreq()
        Me.tbl_TrnOrderPaymReq.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").AutoIncrement = True
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnOrderPaymReq)
            Me.DgvTrnOrderPaymReq.DataSource = Me.tbl_TrnOrderPaymReq
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMaintenanceOrder_OpenRowPaymReq()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_OpenRowPurchaseReq(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnRequestHD_Select", dbConn)
        'dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("requestdetil_refreference='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnMaintenanceRequest.Clear()

        Me.tbl_TrnMaintenanceRequest = clsDataset.CreateTblRequestdetil
        Me.tbl_TrnMaintenanceRequest.Columns("requestdetil_refreference").DefaultValue = order_id
        Me.tbl_TrnMaintenanceRequest.Columns("requestdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnMaintenanceRequest.Columns("requestdetil_line").AutoIncrement = True
        Me.tbl_TrnMaintenanceRequest.Columns("requestdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnMaintenanceRequest.Columns("requestdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnMaintenanceRequest)
            Me.dgvTrnMaintReq.DataSource = Me.tbl_TrnMaintenanceRequest
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder_OpenRowPurchaseReq()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceOrder_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, 0)
            Me.uiTrnMaintenanceOrder_RefreshPosition()
        End If
    End Function

    Private Function uiTrnMaintenanceOrder_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceOrder_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOrder.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, DgvTrnOrder.CurrentCell.RowIndex - 1)
                Me.uiTrnMaintenanceOrder_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnMaintenanceOrder_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceOrder_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOrder.CurrentCell.RowIndex < Me.DgvTrnOrder.Rows.Count - 1 Then
                Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, DgvTrnOrder.CurrentCell.RowIndex + 1)
                Me.uiTrnMaintenanceOrder_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnMaintenanceOrder_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceOrder_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, Me.DgvTrnOrder.Rows.Count - 1)
            Me.uiTrnMaintenanceOrder_RefreshPosition()
        End If
    End Function

    Private Function uiTrnMaintenanceOrder_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            Me.uiTrnMaintenanceOrder_OpenRow(Me.DgvTrnOrder.CurrentRow.Index)
            Me.uiTrnMaintenanceOrder_GetOrderCreator()
            Me.txtAllPOAmount_perBudget.Text = String.Format("{0:#,##0.00}", 0)
            Me.txtAllROAmount_perBudget.Text = String.Format("{0:#,##0.00}", 0)
            Me.txtRO_plus_PO.Text = String.Format("{0:#,##0.00}", 0)
        End If

    End Function

    Private Function uiTrnMaintenanceOrder_GetOrderCreator() As Boolean
        Dim createby, modifyby As String
        Dim createdate, modifydate As String

        Try
            createby = clsUtil.IsDbNull(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_createby").ToString, "")
            modifyby = clsUtil.IsDbNull(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_modifyby").ToString, "")

            If createby = "" Then createby = "Created: " Else createby = "Created by: " & createby
            If modifyby = "" Then modifyby = "Modified: " Else modifyby = "Modified by: " & modifyby

            createdate = Format(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_createdate"), "dd/MM/yyyy")
            modifydate = Format(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_modifydate"), "dd/MM/yyyy")

            createby = createby & " [" & createdate & "] "
            modifyby = modifyby & " [" & modifydate & "] "

            Me.lbl_createby.Text = createby & modifyby
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceOrder_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnOrder_Temp_Changes As DataTable
        Dim tbl_TrnOrderdetil_Changes As DataTable
        Dim tbl_TrnOrderpaymreq_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult

        'Dim success As Boolean
        Dim i As Integer = 0
        'Dim MasterDataState As System.Data.DataRowState
        Dim order_id As Object = New Object
        Dim move As Boolean = False
        'Dim result As FormSaveResult

        If Me.DgvTrnOrder.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
            tbl_TrnOrder_Temp_Changes = Me.tbl_TrnOrder_Temp.GetChanges()

            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
            tbl_TrnOrderdetil_Changes = Me.tbl_TrnOrderdetil.GetChanges()

            Me.DgvTrnOrderPaymReq.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderPaymReq).EndCurrentEdit()
            tbl_TrnOrderpaymreq_Changes = Me.tbl_TrnOrderPaymReq.GetChanges()

            If tbl_TrnOrder_Temp_Changes IsNot Nothing _
                Or tbl_TrnOrderdetil_Changes IsNot Nothing _
                Or tbl_TrnOrderpaymreq_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes
                        Me.uiTrnMaintenanceOrder_Save()
                        move = True
                    Case DialogResult.No
                        move = True
                    Case DialogResult.Cancel
                        move = False
                End Select
            Else
                move = True
            End If

        End If

        Return move

    End Function

    Private Function uiTrnMaintenanceOrder_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            'cek periode sudah diisi
            If Me.cbo_Periode_id.SelectedValue = 0 Then
                ErrorMessage = "Periode belum diisi"
                Me.objFormError.SetError(Me.cbo_Periode_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Periode_id, "")
            End If

            'cek Dept_name sudah diisi
            'If Me.cbo_Dept_name.SelectedValue = 0 Then
            '    ErrorMessage = "Nama Department belum diisi"
            '    Me.objFormError.SetError(Me.cbo_Dept_name, ErrorMessage)
            '    Throw New Exception(ErrorMessage)
            'Else
            '    Me.objFormError.SetError(Me.cbo_Dept_name, "")
            'End If

            'cek rekanan
            If Me.cbo_Rekanan_name.SelectedValue = 0 Then
                ErrorMessage = "Rekanan belum diisi"
                Me.objFormError.SetError(Me.cbo_Rekanan_name, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Rekanan_name, "")
            End If

            'Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try

        Return False

    End Function

    Private Function uiTrnMaintenanceOrder_DetilCalculate(ByVal dgv As DataGridView, ByRef sumdetil As Decimal, ByRef sumPPH As Decimal, ByRef sumPPN As Decimal) As Boolean
        Dim i As Integer
        Dim cPPN, cPPH, cSubtotal, cDiscount, cTotal, totalrow As Decimal

        sumdetil = 0
        sumPPH = 0
        sumPPN = 0

        For i = 0 To dgv.Rows.Count - 1
            cPPH = dgv.Rows(i).Cells("orderdetil_pph").Value
            cPPN = dgv.Rows(i).Cells("orderdetil_ppn").Value
            cSubtotal = dgv.Rows(i).Cells("orderdetil_rowsubtotal").Value
            cTotal = dgv.Rows(i).Cells("orderdetil_rowtotal").Value

            If i < dgv.Rows.Count - 1 Then
                cDiscount = dgv.Rows(i).Cells("orderdetil_discount").Value
                totalrow = cSubtotal - clsUtil.IsDbNull(cDiscount, 0)
                sumdetil = sumdetil + totalrow
                sumPPH = sumPPH + cPPH
                sumPPN = sumPPN + cPPN
            End If
        Next

    End Function

    Private Function uiTrnMaintenanceOrder_TotalCalculate() As Boolean
        'Calculate Cost, Tax, and Total
        Dim [insurance], [transport], [operator], [other], [additional] As Decimal
        Dim [discount], [subtotal], [ppn], [pph] As Decimal
        Dim [gtotal] As Decimal

        If Me.tbl_TrnOrder_Temp.Rows.Count > 0 Then
            [insurance] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_insurancecost")
            [transport] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_transportationcost")
            [operator] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_operatorcost")
            [other] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_othercost")
            [discount] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_discount")
        Else
            [insurance] = 0
            [transport] = 0
            [operator] = 0
            [other] = 0
            [discount] = 0
        End If

        [subtotal] = clsUtil.IsEmptyText(Me.calc_Order_subtotal.Text, 0)
        [additional] = [insurance] + [transport] + [operator] + [other]

        [pph] = Me.calc_Order_PPH.Text
        [ppn] = Me.calc_Order_PPN.Text

        [gtotal] = ([subtotal] - [discount] + [additional]) + ([ppn] - [pph])

        If Me.obj_Order_canceled.Checked Then
            Me.calc_Order_GTotal.Text = String.Format("{0:#,##0.00}", 0)
        Else
            Me.calc_Order_GTotal.Text = String.Format("{0:#,##0.00}", [gtotal])
        End If


    End Function

    Private Function uiTrnMaintenanceOrder_SPKGen(ByVal dgv As DataGridView, ByRef spktype As String) As Boolean
        Dim i, j As Integer
        Dim cSPKType As String
        Dim bSPKType As String

        j = 0
        spktype = ""
        cSPKType = ""
        bSPKType = ""

        For i = 0 To dgv.Rows.Count - 1
            bSPKType = cSPKType
            cSPKType = clsUtil.IsEmptyText(dgv.Rows(i).Cells("category_spktype").Value, "--")

            If i < dgv.Rows.Count - 1 Then
                j += 1
                If j > 1 Then
                    If cSPKType = bSPKType Then
                        cSPKType = ""
                        spktype &= ""
                    Else
                        spktype &= ", "
                    End If
                End If

                'If i = dgv.Rows.Count - 2 Then
                '    If cSPKType <> bSPKType Then spktype &= " dan " + cSPKType
                'Else
                spktype &= cSPKType
                'End If

            End If
        Next

    End Function

#End Region

    Private Sub uiTrnMaintenanceOrder_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Me.uiTrnMaintenanceOrder_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN)
        Me.uiTrnMaintenanceOrder_TotalCalculate()

        Me.DgvTrnOrderdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()

    End Sub

    Private Sub uiTrnMaintenanceOrder_FormBeforeNew() Handles Me.FormBeforeNew
        If Me._FORMMODE = "ENTRY" Then
            Me.calc_Order_GTotal.Text = "0.00"
            Me.calc_Order_subtotal.Text = "0.00"
            Me.calc_Order_PPH.Text = "0.00"
            Me.calc_Order_PPN.Text = "0.00"

            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True

            Me.DgvTrnOrderdetil.ReadOnly = False
            Me.DgvTrnOrderdetil.AllowUserToDeleteRows = True
            Me.DgvTrnOrderdetil.AllowUserToAddRows = True
        End If

    End Sub

    Private Function uiTrnMaintenanceOrder_LoadDataCombo() As Boolean
        Dim criteria As String = ""

        Try
            Me.tbl_MstChannel.Clear()
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")

            Me.tbl_MstPeriode.Clear()
            Me.ComboFill(Me.cbo_Periode_id, "periode_id", "periode_name", Me.tbl_MstPeriode, "pr_MstPeriode_Select", "")

            Me.tbl_StrukturUnit.Clear()
            Me.ComboFill(Me.cbo_Deptname, "strukturunit_id", "strukturunit_name", Me.tbl_StrukturUnit, "ms_MstStrukturUnit_Select", "")

            'Me.tbl_StrukturUnit.Clear()
            'Me.DataFill(Me.tbl_MstUnit, "ms_MstStrukturUnit_Select", criteria)
            'Me.tbl_StrukturUnit.DefaultView.Sort = "strukturunit_name"

            Me.tbl_TrnBudget.Clear()
            Me.ComboFill(Me.cbo_Budget_name, "budget_id", "budget_name", Me.tbl_TrnBudget, "pr_TrnBudget_Select", "")
            Me.ComboFillNumeric(Me.cbo_Budget_amount, "budget_id", "budget_amount", Me.tbl_TrnBudget, "pr_TrnBudget_Select", "")

            Me.tbl_MstRekanan.Clear()
            Me.ComboFill(Me.cbo_Rekanan_name, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")

            Me.tbl_MstProgram.Clear()
            Me.ComboFill(Me.cbo_Old_program_name, "old_program_id", "program_name", Me.tbl_MstProgram, "pr_MstRentalprogram_Select", "")
            Me.ComboFillFromDataTable(Me.cboSearchRekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan)

            Me.tbl_MstItem.Clear()
            Me.DataFill(Me.tbl_MstItem, "pr_MstItem_Select", criteria)
            Me.tbl_MstItem.DefaultView.Sort = "item_name"

            Me.tbl_MstUnit.Clear()
            Me.DataFill(Me.tbl_MstUnit, "pr_MstUnit_Select", criteria)
            Me.tbl_MstUnit.DefaultView.Sort = "unit_name"

            Me.tbl_MstCurrency.Clear()
            Me.DataFill(Me.tbl_MstCurrency, "pr_MstCurrency_Select", criteria)
            Me.tbl_MstCurrency.DefaultView.Sort = "currency_shortname"

            Me.COMBO_ISFILLED = True

        Catch ex As Exception
            Me.COMBO_ISFILLED = False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub uiTrnMaintenanceOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._ORDER_SOURCE = Me.GetValueFromParameter(objParameters, "ORDER_SOURCE")
            Me._ORDERTYPE_ID = Me.GetValueFromParameter(objParameters, "ORDERTYPE_ID")
            Me._ORDER_AUTHNAME = Me.GetValueFromParameter(objParameters, "ORDER_AUTHNAME")
            Me._ORDER_AUTHPOS = Me.GetValueFromParameter(objParameters, "ORDER_AUTHPOS")
            Me._FORMMODE = Me.GetValueFromParameter(objParameters, "FORMMODE")

            'Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            'Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")

        End If

        Me.DgvTrnOrder.DataSource = Me.tbl_TrnOrder

        Me.BindingStop()
        Me.BindingStart()

        Me.uiTrnMaintenanceOrder_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED

        Me.cboSearchChannel.SelectedValue = Me._CHANNEL

        'Application Info
        Me.txt_usrname.Text = Me.UserName
        Me.txt_channel_name.Text = Me._CHANNEL
        Me.obj_Order_source.Text = Me._ORDER_SOURCE
        Me.obj_Ordertype_id.Text = Me._ORDERTYPE_ID


        Me.InitLayoutUI()

    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlatTabMain.SelectedIndexChanged, FlatTabMain.SelectedIndexChanged

        Select Case FlatTabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.White
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                If Me._FORMMODE = "ENTRY" Then
                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                    Me.tbtnLoad.Enabled = False
                    Me.tbtnQuery.Enabled = False
                ElseIf Me._FORMMODE = "VIEW" Then
                    Me.tbtnSave.Enabled = False
                    Me.tbtnDel.Enabled = False
                    Me.tbtnLoad.Enabled = False
                    Me.tbtnQuery.Enabled = False
                End If

                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then
                    Me.uiTrnMaintenanceOrder_OpenRow(Me.DgvTrnOrder.CurrentRow.Index)
                Else
                    Me.uiTrnMaintenanceOrder_NewData()
                End If
        End Select

    End Sub

    Private Sub DgvTrnOrder_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrder.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then
            Me.FlatTabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub chkSearchChannel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchChannel.CheckedChanged
        If Me.chkSearchChannel.Checked = True Then
            If Me._CHANNEL_CANBE_BROWSED = True Then
                Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Else
                Me.cboSearchChannel.Enabled = Not Me._CHANNEL_CANBE_BROWSED
            End If
        Else
            If Me._CHANNEL_CANBE_BROWSED = True Then
                Me.cboSearchChannel.Enabled = Not Me._CHANNEL_CANBE_BROWSED
            Else
                Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            End If
        End If
    End Sub

    Private Sub DgvTrnOrderdetil_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        Dim dgv As DataGridView = sender

        If dgv.Rows.Count > 0 Then
            Me.uiTrnMaintenanceOrder_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN)
            Me.uiTrnMaintenanceOrder_TotalCalculate()
            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()

        End If

    End Sub

    Private Sub obj_Order_pph_percent_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.uiTrnMaintenanceOrder_TotalCalculate()
    End Sub

    Private Sub obj_Order_ppn_percent_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.uiTrnMaintenanceOrder_TotalCalculate()
    End Sub

    Private Sub btn_FindBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim popUpFind As frmPopUpFind

        popUpFind = New frmPopUpFind(Me.DSN, "BUDGET", 1, "Budget", " ")

        popUpFind.ShowDialog()
    End Sub

    Private Sub cbo_Budget_name_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Budget_name.Validated
        Me.obj_Budget_id.Text = Me.cbo_Budget_name.SelectedValue
    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.Gainsboro
            'Me.ftabDataDetil.TabPages.Item(i).Font.Style = FontStyle.Regular
        Next
        activetab = Me.ftabDataDetil.SelectedIndex
        Me.ftabDataDetil.TabPages.Item(activetab).BackColor = Color.White
        'Me.ftabDataDetil.TabPages.Item(activetab).Font.Style = FontStyle.Bold

    End Sub

    'Private Sub cbo_Rekanan_name_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Rekanan_name.Validated
    '    Me.tbl_MstRekanan_contact.Clear()
    '    Me.tbl_MstRekanan_contact = clsDataset.CreateTblMstrekanan_contact()

    '    Try
    '        Me.ComboFill(Me.cbo_Rekanan_contact, "rekanan_id", "rekanancontact_name", Me.tbl_MstRekanan_contact, "pr_MstRekanan_contact_Select", " rekanan_id = " & Me.obj_Rekanan_id.Text)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub obj_Order_canceled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.obj_Order_canceled.Checked = True Then
            Me.ftabDataDetil_Additional.Enabled = False
            Me.ftabDataDetil_Budget.Enabled = False
            Me.ftabDataDetil_Detil.Enabled = False
            Me.ftabDataDetil_Info.Enabled = False
            Me.ftabDataDetil_PaymReq.Enabled = False
            Me.ftabDataDetil_Sign.Enabled = False

            Me.tbtnDel.Enabled = False
            Me.tbtnEdit.Enabled = False
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False

        Else
            Me.ftabDataDetil_Additional.Enabled = True
            Me.ftabDataDetil_Budget.Enabled = True
            Me.ftabDataDetil_Detil.Enabled = True
            Me.ftabDataDetil_Info.Enabled = True
            Me.ftabDataDetil_PaymReq.Enabled = True
            Me.ftabDataDetil_Sign.Enabled = True

            Me.tbtnDel.Enabled = True
            Me.tbtnEdit.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True

        End If
    End Sub

    Private Sub obj_Budget_id_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Budget_id.Validated
        Me.cbo_Budget_name.SelectedValue = Me.obj_Budget_id.Text
    End Sub

    Private Sub btnCheckAll_OrderAmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAll_OrderAmt.Click
        Dim criteria, budget_id As String
        Dim ro_amount As Decimal
        Dim rowindex As Integer

        If Me.DgvTrnOrder.RowCount > 0 Then
            Try
                rowindex = Me.DgvTrnOrder.CurrentRow.Index
                budget_id = clsUtil.IsDbNull(Me.DgvTrnOrder.Rows(rowindex).Cells("budget_id").Value, "")

                If Not budget_id = "" Then
                    criteria = " budget_id ='" & budget_id & "' and ordertype_id='" & Me._ORDERTYPE_ID & "' and channel_id='" & Me._CHANNEL + "'"
                    Me.tbl_TrnOrderAmount_perBudget.Clear()
                    Try
                        Me.DataFill(Me.tbl_TrnOrderAmount_perBudget, "pr_SumOrderPerBudget_Select", criteria)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    If Me.tbl_TrnOrderAmount_perBudget.Rows.Count > 0 Then
                        ro_amount = Me.tbl_TrnOrderAmount_perBudget.Rows(0)("ordertotal_perbudget")
                        Me.txtAllROAmount_perBudget.Text = String.Format("{0:#,##0.00}", ro_amount)
                        Me.txtRO_plus_PO.Text = String.Format("{0:#,##0.00}", ro_amount)
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub obj_Order_descr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Order_descr.TextChanged
        Dim i As Integer
        Dim j, rMaxLine As Byte

        i = 2000 - Me.obj_Order_descr.Text.Length
        If i <= 0 Then
            Me.obj_Order_descr.Text = Mid(Me.obj_Order_descr.Text, 1, 2000)
        End If
        Me.Label4.Text = "Chars Left: " & i

        rMaxLine = 36 - Math.Ceiling(Me.DgvTrnOrderdetil.RowCount * 1.5)

        Try
            j = rMaxLine - Me.obj_Order_descr.Lines.Length
        Catch ex As Exception
            'MessageBox.Show("Jumlah baris tidak boleh lebih dari 35", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Me.Label4.Text = Me.Label2.Text & " // Recommendation Lines Left: " & j

    End Sub

    Private Function uiTrnMaintenanceOrder_SetViewOnly() As Boolean
        'NavigationButton
        Me.tbtnDel.Enabled = False
        Me.tbtnEdit.Enabled = False
        Me.tbtnNew.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False

        'PnlDataMaster1
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.BackColor = Color.Coral
        Me.obj_Order_id.ForeColor = Color.Black

        Me.obj_Request_id.ReadOnly = True
        Me.obj_Request_id.BackColor = Color.White
        Me.obj_Request_id.ForeColor = Color.Black

        Me.cbo_Periode_id.Enabled = False
        Me.dtp_order_date.Enabled = False
        Me.cbo_Deptname.Enabled = False

        'PnlDataMaster2
        Me.cbo_Rekanan_name.Enabled = False
        Me.cbo_Rekanan_name.BackColor = Color.White
        Me.cbo_Rekanan_name.ForeColor = Color.Black

        Me.obj_Budget_id.ReadOnly = True
        Me.obj_Budget_id.BackColor = Color.White
        Me.obj_Budget_id.ForeColor = Color.Black

        Me.cbo_Budget_name.Enabled = False

        Me.gboRevision.Enabled = False

        'PnlDataFooter1
        Me.obj_Order_descr.ReadOnly = True
        Me.obj_Order_descr.BackColor = Color.White
        Me.obj_Order_descr.ForeColor = Color.Black

        Me.obj_Order_canceled.Enabled = False

        Me.obj_Order_discount.ReadOnly = True
        Me.obj_Order_discount.BackColor = Color.White
        Me.obj_Order_discount.ForeColor = Color.Black

        'Me.obj_Order_pph_percent.ReadOnly = True
        'Me.obj_Order_pph_percent.BackColor = Color.White
        'Me.obj_Order_pph_percent.ForeColor = Color.Black

        'Me.obj_Order_ppn_percent.ReadOnly = True
        'Me.obj_Order_ppn_percent.BackColor = Color.White
        'Me.obj_Order_ppn_percent.ForeColor = Color.Black

        'fTabDataDetil
        Me.DgvTrnOrderdetil.Enabled = False
        Me.DgvTrnOrderPaymReq.Enabled = False

        'AdditionalCost
        Me.obj_Order_insurancecost.ReadOnly = True
        Me.obj_Order_insurancecost.BackColor = Color.White
        Me.obj_Order_insurancecost.ForeColor = Color.Black

        Me.obj_Order_operatorcost.ReadOnly = True
        Me.obj_Order_operatorcost.BackColor = Color.White
        Me.obj_Order_operatorcost.ForeColor = Color.Black

        Me.obj_Order_transportationcost.ReadOnly = True
        Me.obj_Order_transportationcost.BackColor = Color.White
        Me.obj_Order_transportationcost.ForeColor = Color.Black

        Me.obj_Order_othercost.ReadOnly = True
        Me.obj_Order_othercost.BackColor = Color.White
        Me.obj_Order_othercost.ForeColor = Color.Black

    End Function

    Private Sub DgvTrnOrderdetil_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrderdetil.CellValueChanged
        Dim dgv As DataGridView = sender
        Dim colName As String = dgv.Columns(e.ColumnIndex).Name

        If (colName = "orderdetil_idr" Or colName = "orderdetil_days" Or colName = "orderdetil_qty" Or colName = "orderdetil_discount" Or colName = "orderdetil_foreign" Or colName = "orderdetil_foreignrate") Then
            Me.uiTrnMaintenanceOrder_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN)
            Me.uiTrnMaintenanceOrder_TotalCalculate()

            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
        End If

        If colName = "orderdetil_type" Then
            If dgv.CurrentRow.Cells("orderdetil_type").Value = "Descr" Then
                dgv.CurrentRow.Cells("item_id").Value = ""
                dgv.CurrentRow.Cells("unit_id").Value = 0
                dgv.CurrentRow.Cells("orderdetil_qty").Value = 0
                dgv.CurrentRow.Cells("orderdetil_days").Value = 0
                dgv.CurrentRow.Cells("orderdetil_idr").Value = 0
                dgv.CurrentRow.Cells("orderdetil_discount").Value = 0
                dgv.CurrentRow.Cells("orderdetil_pphpercent").Value = 0
                dgv.CurrentRow.Cells("orderdetil_pph").Value = 0
                dgv.CurrentRow.Cells("orderdetil_ppnpercent").Value = 0
                dgv.CurrentRow.Cells("orderdetil_ppn").Value = 0
                dgv.CurrentRow.Cells("orderdetil_foreign").Value = 0
                dgv.CurrentRow.Cells("orderdetil_foreignrate").Value = 0
                dgv.CurrentRow.Cells("orderdetil_foreign_pphpercent").Value = 0
                dgv.CurrentRow.Cells("orderdetil_foreign_pph").Value = 0
                dgv.CurrentRow.Cells("orderdetil_foreign_ppnpercent").Value = 0
                dgv.CurrentRow.Cells("orderdetil_foreign_ppn").Value = 0
                dgv.CurrentRow.Cells("orderdetil_actual").Value = 0

            ElseIf dgv.CurrentRow.Cells("orderdetil_type").Value = "Item" Then
                dgv.CurrentRow.Cells("orderdetil_days").Value = 1
            End If
        End If

    End Sub

    Private Sub DgvTrnOrderdetil_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOrderdetil.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        If dgv.RowCount > 1 Then
            If objRow.Cells("orderdetil_type").Value = "Descr" Then
                objRow.Cells("item_id").ReadOnly = True
                objRow.Cells("item_id").Style.BackColor = Color.LightGray
                objRow.Cells("item_id").Style.ForeColor = Color.LightGray
                objRow.Cells("item_id").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_line").ReadOnly = True
                objRow.Cells("orderdetil_line").Style.BackColor = Color.LightGray

                objRow.Cells("unit_id").ReadOnly = True
                objRow.Cells("unit_id").Style.BackColor = Color.LightGray
                objRow.Cells("unit_id").Style.ForeColor = Color.LightGray
                objRow.Cells("unit_id").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_qty").ReadOnly = True
                objRow.Cells("orderdetil_qty").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_qty").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_qty").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("currency_id").ReadOnly = True
                objRow.Cells("currency_id").Style.BackColor = Color.LightGray
                objRow.Cells("currency_id").Style.ForeColor = Color.LightGray
                objRow.Cells("currency_id").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_idr").ReadOnly = True
                objRow.Cells("orderdetil_idr").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_idr").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_idr").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_discount").ReadOnly = True
                objRow.Cells("orderdetil_discount").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_discount").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_discount").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_ppnpercent").ReadOnly = True
                objRow.Cells("orderdetil_ppnpercent").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_ppnpercent").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_ppnpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_pphpercent").ReadOnly = True
                objRow.Cells("orderdetil_pphpercent").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_pphpercent").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_pphpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                'objRow.Cells("orderdetil_ppn").ReadOnly = True
                objRow.Cells("orderdetil_ppn").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_ppn").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_ppn").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                'objRow.Cells("orderdetil_pph").ReadOnly = True
                objRow.Cells("orderdetil_pph").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_pph").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_pph").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_foreign").ReadOnly = True
                objRow.Cells("orderdetil_foreign").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_foreign").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_foreign").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_foreignrate").ReadOnly = True
                objRow.Cells("orderdetil_foreignrate").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_foreignrate").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_foreignrate").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_foreign_ppnpercent").ReadOnly = True
                objRow.Cells("orderdetil_foreign_ppnpercent").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_ppnpercent").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_ppnpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                objRow.Cells("orderdetil_foreign_pphpercent").ReadOnly = True
                objRow.Cells("orderdetil_foreign_pphpercent").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_pphpercent").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_pphpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                'objRow.Cells("orderdetil_foreign_ppn").ReadOnly = True
                objRow.Cells("orderdetil_foreign_ppn").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_ppn").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_ppn").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                'objRow.Cells("orderdetil_foreign_pph").ReadOnly = True
                objRow.Cells("orderdetil_foreign_pph").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_pph").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_foreign_pph").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                'objRow.Cells("orderdetil_rowtotal").ReadOnly = True
                objRow.Cells("orderdetil_rowtotal").Style.BackColor = Color.LightGray
                objRow.Cells("orderdetil_rowtotal").Style.ForeColor = Color.LightGray
                objRow.Cells("orderdetil_rowtotal").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

            Else
                dgv.CurrentRow.Cells("item_id").ReadOnly = False
                objRow.Cells("item_id").Style.BackColor = Color.White
                objRow.Cells("item_id").Style.ForeColor = Color.Black
                objRow.Cells("item_id").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_line").ReadOnly = False
                objRow.Cells("orderdetil_line").Style.BackColor = Color.White

                objRow.Cells("unit_id").ReadOnly = False
                objRow.Cells("unit_id").Style.BackColor = Color.White
                objRow.Cells("unit_id").Style.ForeColor = Color.Black
                objRow.Cells("unit_id").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_qty").ReadOnly = False
                objRow.Cells("orderdetil_qty").Style.BackColor = Color.White
                objRow.Cells("orderdetil_qty").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_qty").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("currency_id").ReadOnly = False
                objRow.Cells("currency_id").Style.BackColor = Color.White
                objRow.Cells("currency_id").Style.ForeColor = Color.Black
                objRow.Cells("currency_id").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_idr").ReadOnly = False
                objRow.Cells("orderdetil_idr").Style.BackColor = Color.White
                objRow.Cells("orderdetil_idr").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_idr").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_ppnpercent").ReadOnly = False
                objRow.Cells("orderdetil_ppnpercent").Style.BackColor = Color.White
                objRow.Cells("orderdetil_ppnpercent").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_ppnpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_pphpercent").ReadOnly = False
                objRow.Cells("orderdetil_pphpercent").Style.BackColor = Color.White
                objRow.Cells("orderdetil_pphpercent").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_pphpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                'objRow.Cells("orderdetil_ppn").ReadOnly = False
                'objRow.Cells("orderdetil_ppn").Style.BackColor = Color.White
                'objRow.Cells("orderdetil_ppn").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_ppn").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                'objRow.Cells("orderdetil_pph").ReadOnly = False
                'objRow.Cells("orderdetil_pph").Style.BackColor = Color.White
                'objRow.Cells("orderdetil_pph").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_pph").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_discount").ReadOnly = False
                objRow.Cells("orderdetil_discount").Style.BackColor = Color.White
                objRow.Cells("orderdetil_discount").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_discount").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_foreign").ReadOnly = False
                objRow.Cells("orderdetil_foreign").Style.BackColor = Color.White
                objRow.Cells("orderdetil_foreign").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_foreign").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_foreignrate").ReadOnly = False
                objRow.Cells("orderdetil_foreignrate").Style.BackColor = Color.White
                objRow.Cells("orderdetil_foreignrate").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_foreignrate").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_foreign_ppnpercent").ReadOnly = False
                objRow.Cells("orderdetil_foreign_ppnpercent").Style.BackColor = Color.White
                objRow.Cells("orderdetil_foreign_ppnpercent").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_foreign_ppnpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                objRow.Cells("orderdetil_foreign_pphpercent").ReadOnly = False
                objRow.Cells("orderdetil_foreign_pphpercent").Style.BackColor = Color.White
                objRow.Cells("orderdetil_foreign_pphpercent").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_foreign_pphpercent").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                'objRow.Cells("orderdetil_foreign_ppn").ReadOnly = False
                'objRow.Cells("orderdetil_foreign_ppn").Style.BackColor = Color.White
                'objRow.Cells("orderdetil_foreign_ppn").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_foreign_ppn").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                'objRow.Cells("orderdetil_foreign_pph").ReadOnly = False
                'objRow.Cells("orderdetil_foreign_pph").Style.BackColor = Color.White
                'objRow.Cells("orderdetil_foreign_pph").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_foreign_pph").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                'objRow.Cells("orderdetil_rowtotal").ReadOnly = False
                'objRow.Cells("orderdetil_rowtotal").Style.BackColor = Color.White
                'objRow.Cells("orderdetil_rowtotal").Style.ForeColor = Color.Black
                objRow.Cells("orderdetil_rowtotal").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")


            End If

            If objRow.Cells("currency_id").Value = 1 Then       'IDR

            Else

            End If

        End If

    End Sub

    Private Sub DgvTrnOrder_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOrder.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objRow.Index Mod 2 = 0 Then
                objRow.DefaultCellStyle.BackColor = Color.PapayaWhip
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class

