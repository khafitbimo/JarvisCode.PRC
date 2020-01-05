'================================================= 
' Created Date: 2/18/2008 9:32:39 AM



Public Class uiTrnRentalOrder3
    Private Const mUiName As String = "Rental Order"
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

    Private tbl_TrnOrder As DataTable = clsDataset2.CreateTblTrnOrder()
    Private tbl_TrnOrder_Temp As DataTable = clsDataset2.CreateTblTrnOrder()
    Private tbl_TrnOrderdetil As DataTable = clsDataset2.CreateTblTrnOrderdetil2()
    Private tbl_TrnOrderPaymReq As DataTable = clsDataset2.CreateTblTrnOrderpaymreq()
    Private tbl_RequestSelect As DataTable = clsDataset2.CreateTblRequest()
    Private tbl_RequestdetilSelect As DataTable = clsDataset2.CreateTblRequestdetilSelect()
    Private tbl_RequestdetilEps As DataTable = clsDataset2.CreateTblTrnRequestdetileps()
    Private tbl_RequestdetilUseSelect As DataTable = clsDataset2.CreateTblRequestdetilUse()
    Private tbl_RequestdetilUseSelected As DataTable = clsDataset2.CreateTblRequestdetilUse()
    Private tbl_TrnRequestdetil As DataTable = clsDataset2.CreateTblRequestdetil()
    Private tbl_TrnOrderApproval As DataTable = clsDataset2.CreateTblTrnorderApproval()

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
    Private tbl_TrnOrderdetiluse As DataTable = clsDataset2.CreateTblTrnOrderdetiluse()
    Private tbl_TrnOrderdetileps As DataTable = clsDataset2.CreateTblTrnOrderdetileps()

    Private tbl_TrnOrderAmount_perBudget As DataTable = clsDataset2.CreateTblOrderAmount_perBudget()

    'Public Shared mChannel_id As String
    'Public Shared mOrder_source As String
    'Public Shared mOrdertype_id As String
    'Public Shared mCreateBy As String
    'Public Shared mModifyBy As String

    Dim ReservedItem As Boolean
    Dim prd, lmdate As String
    Private errorpa As Boolean = False
    Private WithEvents btnApp As New ToolStripButton
    Private order_total As Decimal
    Private NewData As Boolean = False

#Region " Window Parameter "

    Private _FORMMODE As String = "ENTRY"       '[ENTRY, VIEW, APPROVAL, UNAPPROVAL]
    Private _CHANNEL As String = "NTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = True
    Private _CHANNEL_CANBE_BROWSED As Boolean = True

    Private _RPT_CYCLE As String = "MONTHLY"    '[DAILY, MONTHLY, YEARLY]
    Private _RPT_TYPE As String = "SUMM"        '[LIST, SUMM]
    Private _ORDER_SOURCE As String = "RQ"
    Private _ORDERTYPE_ID As String = "RO"
    Private _ORDER_AUTHNAME As String = "Febriansyah"
    Private _ORDER_AUTHPOS As String = "Procurement Dept. Head"
    Private _ORDER_AUTHNAME2 As String = "Warnedy"
    Private _ORDER_AUTHPOS2 As String = "Finance Director"
    Private _PROGRAMTYPE As String = "PG" '[PG = PROGRAM, NP = NON PROGRAM]


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
            Me.NewData = True
            Me.FlatTabMain.SelectedIndex = 1
        End If
        'Me.uiTrnRentalOrder3_confirmNew()
        Me.uiTrnRentalOrder3_NewData()
        Me.ReservedItem = False
        Me.uiTrnRentalOrder3_GetOrderSource()
        Me.tbtnSave.Visible = True
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnRentalOrder3_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnRentalOrder3_Last()
        Me.Cursor = Cursors.Arrow

        Return MyBase.btnLast_Click()
    End Function
#End Region

#Region " Property "

    Private mTotalDetil As Decimal
    Private mTotalDetilDisc As Decimal
    Private mOrderDisc As Decimal
    Private mTotalDetilPPH As Decimal
    Private mTotalDetilPPN As Decimal
    Private mSPKType As String
    'Private mTotalBiayaLainLain As Decimal

    Public Property TotalDetil() As Decimal
        Get
            Return mTotalDetil
        End Get
        Set(ByVal value As Decimal)
            mTotalDetil = value
            Me.calc_Order_subtotal.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property TotalDetilDisc() As Decimal
        Get
            Return mTotalDetilDisc
        End Get
        Set(ByVal value As Decimal)
            mTotalDetilDisc = value
            Me.calc_Order_subdiscount.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property OrderDisc() As Decimal
        Get
            Return mOrderDisc
        End Get
        Set(ByVal value As Decimal)
            mOrderDisc = value
            Me.calc_Order_discount.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property TotalDetilPPH() As Decimal
        Get
            Return mTotalDetilPPH
        End Get
        Set(ByVal value As Decimal)
            mTotalDetilPPH = value
            Me.calc_Order_subPPH.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property TotalDetilPPN() As Decimal
        Get
            Return mTotalDetilPPN
        End Get
        Set(ByVal value As Decimal)
            mTotalDetilPPN = value
            Me.calc_Order_subPPN.Text = String.Format("{0:#,##0.00}", value)
        End Set
    End Property

    Public Property SPKWorktype() As String
        Get
            Return mSPKType
        End Get
        Set(ByVal value As String)
            mSPKType = value
            Me.obj_Order_spkworktype.Text = value
        End Set
    End Property

    'Public Property TotalBiayaLainLain() As Decimal
    '    Get
    '        Return mTotalBiayaLainLain
    '    End Get
    '    Set(ByVal value As Decimal)
    '        mTotalBiayaLainLain = value
    '    End Set
    'End Property

    Friend Class SelectDaysDialogReturn
        Private m_orderdetil_line As Integer
        Private m_orderdetil_descr As String
        Private m_orderdetil_idr As Decimal
        Private m_orderdetil_qty As Decimal
        Private m_orderdetil_days As Decimal
        Private m_item_id As String
        Private m_order_utilizeddatestart As Date
        Private m_order_utilizeddateend As Date

        Private m_order_setdate As Date

        Public Property orderdetil_line() As Integer
            Get
                Return m_orderdetil_line
            End Get
            Set(ByVal value As Integer)
                m_orderdetil_line = value
            End Set
        End Property

        Public Property orderdetil_descr() As String
            Get
                Return m_orderdetil_descr
            End Get
            Set(ByVal value As String)
                m_orderdetil_descr = value
            End Set
        End Property

        Public Property orderdetil_idr() As Decimal
            Get
                Return m_orderdetil_idr
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_idr = value
            End Set
        End Property

        Public Property orderdetil_days() As Decimal
            Get
                Return m_orderdetil_days
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_days = value
            End Set
        End Property

        Public Property orderdetil_qty() As Decimal
            Get
                Return m_orderdetil_qty
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_qty = value
            End Set
        End Property


        Public Property item_id() As String
            Get
                Return m_item_id
            End Get
            Set(ByVal value As String)
                m_item_id = value
            End Set
        End Property

        Public Property order_utilizeddatestart() As Date
            Get
                Return m_order_utilizeddatestart
            End Get
            Set(ByVal value As Date)
                m_order_utilizeddatestart = value
            End Set
        End Property

        Public Property order_utilizeddateend() As Date
            Get
                Return m_order_utilizeddateend
            End Get
            Set(ByVal value As Date)
                m_order_utilizeddateend = value
            End Set
        End Property

        Public Property order_setdate() As Date
            Get
                Return m_order_setdate
            End Get
            Set(ByVal value As Date)
                m_order_setdate = value
            End Set
        End Property
    End Class

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
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cOrder_authname2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_authposition2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cOrderdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_approved2 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrder_rekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 105
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

        cOrder_rekanan.Name = "rekanan"
        cOrder_rekanan.HeaderText = "Rekanan Name"
        cOrder_rekanan.DataPropertyName = "rekanan"
        cOrder_rekanan.Width = 150
        cOrder_rekanan.Visible = True
        cOrder_rekanan.ReadOnly = False


        cOrder_spkdesc.Name = "order_spkdesc"
        cOrder_spkdesc.HeaderText = "SPK Note"
        cOrder_spkdesc.DataPropertyName = "order_spkdesc"
        cOrder_spkdesc.Width = 150
        cOrder_spkdesc.Visible = False
        cOrder_spkdesc.ReadOnly = False

        cOrder_spkworktype.Name = "order_spkworktype"
        cOrder_spkworktype.HeaderText = "SPK WorkType"
        cOrder_spkworktype.DataPropertyName = "order_spkworktype"
        cOrder_spkworktype.Width = 150
        cOrder_spkworktype.Visible = False
        cOrder_spkworktype.ReadOnly = False

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "RequestID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 80
        cRequest_id.Visible = True
        cRequest_id.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency ID"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "RekananID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 70
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cOld_program_id.Name = "old_program_id"
        cOld_program_id.HeaderText = "ProgID"
        cOld_program_id.DataPropertyName = "old_program_id"
        cOld_program_id.Width = 100
        cOld_program_id.Visible = False
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
        cOrder_progsch.Visible = False
        cOrder_progsch.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "BudgetID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 80
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True

        cOrder_eps.Name = "order_eps"
        cOrder_eps.HeaderText = "Episode"
        cOrder_eps.DataPropertyName = "order_eps"
        cOrder_eps.Width = 100
        cOrder_eps.Visible = False
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
        cOrder_settime.Visible = False
        cOrder_settime.ReadOnly = False

        cOrder_setlocation.Name = "order_setlocation"
        cOrder_setlocation.HeaderText = "Set Location"
        cOrder_setlocation.DataPropertyName = "order_setlocation"
        cOrder_setlocation.Width = 100
        cOrder_setlocation.Visible = False
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
        cOrder_utilizedtimestart.Visible = False
        cOrder_utilizedtimestart.ReadOnly = False

        cOrder_utilizedtimeend.Name = "order_utilizedtimeend"
        cOrder_utilizedtimeend.HeaderText = "Utlz Time2"
        cOrder_utilizedtimeend.DataPropertyName = "order_utilizedtimeend"
        cOrder_utilizedtimeend.Width = 85
        cOrder_utilizedtimeend.Visible = False
        cOrder_utilizedtimeend.ReadOnly = False

        cOrder_utilizedlocation.Name = "order_utilizedlocation"
        cOrder_utilizedlocation.HeaderText = "Utlz Location"
        cOrder_utilizedlocation.DataPropertyName = "order_utilizedlocation"
        cOrder_utilizedlocation.Width = 100
        cOrder_utilizedlocation.Visible = False
        cOrder_utilizedlocation.ReadOnly = False

        cOrder_pph_percent.Name = "order_pph_percent"
        cOrder_pph_percent.HeaderText = "% PPH"
        cOrder_pph_percent.DataPropertyName = "order_pph_percent"
        cOrder_pph_percent.Width = 50
        cOrder_pph_percent.Visible = False
        cOrder_pph_percent.ReadOnly = False

        cOrder_ppn_percent.Name = "order_ppn_percent"
        cOrder_ppn_percent.HeaderText = "% PPN"
        cOrder_ppn_percent.DataPropertyName = "order_ppn_percent"
        cOrder_ppn_percent.Width = 50
        cOrder_ppn_percent.Visible = False
        cOrder_ppn_percent.ReadOnly = False

        cOrder_insurancecost.Name = "order_insurancecost"
        cOrder_insurancecost.HeaderText = "Insurance"
        cOrder_insurancecost.DataPropertyName = "order_insurancecost"
        cOrder_insurancecost.Width = 80
        cOrder_insurancecost.Visible = False
        cOrder_insurancecost.ReadOnly = False

        cOrder_transportationcost.Name = "order_transportationcost"
        cOrder_transportationcost.HeaderText = "Transport"
        cOrder_transportationcost.DataPropertyName = "order_transportationcost"
        cOrder_transportationcost.Width = 80
        cOrder_transportationcost.Visible = False
        cOrder_transportationcost.ReadOnly = False

        cOrder_operatorcost.Name = "order_operatorcost"
        cOrder_operatorcost.HeaderText = "Operator"
        cOrder_operatorcost.DataPropertyName = "order_operatorcost"
        cOrder_operatorcost.Width = 80
        cOrder_operatorcost.Visible = False
        cOrder_operatorcost.ReadOnly = False

        cOrder_othercost.Name = "order_othercost"
        cOrder_othercost.HeaderText = "Other Cost"
        cOrder_othercost.DataPropertyName = "order_othercost"
        cOrder_othercost.Width = 90
        cOrder_othercost.Visible = False
        cOrder_othercost.ReadOnly = False

        cOrder_authname.Name = "order_authname"
        cOrder_authname.HeaderText = "Auth Name"
        cOrder_authname.DataPropertyName = "order_authname"
        cOrder_authname.Width = 100
        cOrder_authname.Visible = False
        cOrder_authname.ReadOnly = False

        cOrder_authposition.Name = "order_authposition"
        cOrder_authposition.HeaderText = "Auth Position"
        cOrder_authposition.DataPropertyName = "order_authposition"
        cOrder_authposition.Width = 100
        cOrder_authposition.Visible = False
        cOrder_authposition.ReadOnly = False

        cOrder_authname2.Name = "order_authname2"
        cOrder_authname2.HeaderText = "Auth Name2"
        cOrder_authname2.DataPropertyName = "order_authname2"
        cOrder_authname2.Width = 100
        cOrder_authname2.Visible = False
        cOrder_authname2.ReadOnly = False

        cOrder_authposition2.Name = "order_authposition2"
        cOrder_authposition2.HeaderText = "Auth Position2"
        cOrder_authposition2.DataPropertyName = "order_authposition2"
        cOrder_authposition2.Width = 100
        cOrder_authposition2.Visible = False
        cOrder_authposition2.ReadOnly = False

        cOrder_canceled.Name = "order_canceled"
        cOrder_canceled.HeaderText = "Canceled"
        cOrder_canceled.DataPropertyName = "order_canceled"
        cOrder_canceled.Width = 75
        cOrder_canceled.Visible = False
        cOrder_canceled.ReadOnly = False

        cOrder_createby.Name = "order_createby"
        cOrder_createby.HeaderText = "CreateBy"
        cOrder_createby.DataPropertyName = "order_createby"
        cOrder_createby.Width = 85
        cOrder_createby.Visible = False
        cOrder_createby.ReadOnly = False

        cOrder_createdate.Name = "order_createdate"
        cOrder_createdate.HeaderText = "Create Date"
        cOrder_createdate.DataPropertyName = "order_createdate"
        cOrder_createdate.Width = 95
        cOrder_createdate.Visible = False
        cOrder_createdate.ReadOnly = False

        cOrder_modifyby.Name = "order_modifyby"
        cOrder_modifyby.HeaderText = "Modify By"
        cOrder_modifyby.DataPropertyName = "order_modifyby"
        cOrder_modifyby.Width = 85
        cOrder_modifyby.Visible = False
        cOrder_modifyby.ReadOnly = False

        cOrder_modifydate.Name = "order_modifydate"
        cOrder_modifydate.HeaderText = "Modify Date"
        cOrder_modifydate.DataPropertyName = "order_modifydate"
        cOrder_modifydate.Width = 95
        cOrder_modifydate.Visible = False
        cOrder_modifydate.ReadOnly = False

        cOrder_discount.Name = "order_discount"
        cOrder_discount.HeaderText = "Discount"
        cOrder_discount.DataPropertyName = "order_discount"
        cOrder_discount.Width = 100
        cOrder_discount.Visible = False
        cOrder_discount.ReadOnly = False

        cOrder_source.Name = "order_source"
        cOrder_source.HeaderText = "Source"
        cOrder_source.DataPropertyName = "order_source"
        cOrder_source.Width = 100
        cOrder_source.Visible = False
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
        cOld_apref.Visible = False
        cOld_apref.ReadOnly = False

        cNew_apref.Name = "paymreq_id"
        cNew_apref.HeaderText = "Paymreq ID"
        cNew_apref.DataPropertyName = "paymreq_id"
        cNew_apref.Width = 100
        cNew_apref.Visible = False
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


        cOrder_approved2.Name = "order_approved2"
        cOrder_approved2.HeaderText = "Approved2"
        cOrder_approved2.DataPropertyName = "order_approved2"
        cOrder_approved2.Width = 100
        cOrder_approved2.Visible = False
        cOrder_approved2.ReadOnly = False

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
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cOrder_dlvrname.Name = "order_dlvrname"
        cOrder_dlvrname.HeaderText = "Delivery Name"
        cOrder_dlvrname.DataPropertyName = "order_dlvrname"
        cOrder_dlvrname.Width = 130
        cOrder_dlvrname.Visible = False
        cOrder_dlvrname.ReadOnly = False

        cOrder_dlvraddr1.Name = "order_dlvraddr1"
        cOrder_dlvraddr1.HeaderText = "Delivery Address1"
        cOrder_dlvraddr1.DataPropertyName = "order_dlvraddr1"
        cOrder_dlvraddr1.Width = 130
        cOrder_dlvraddr1.Visible = False
        cOrder_dlvraddr1.ReadOnly = False

        cOrder_dlvraddr2.Name = "order_dlvraddr2"
        cOrder_dlvraddr2.HeaderText = "Delivery Address2"
        cOrder_dlvraddr2.DataPropertyName = "order_dlvraddr2"
        cOrder_dlvraddr2.Width = 130
        cOrder_dlvraddr2.Visible = False
        cOrder_dlvraddr2.ReadOnly = False

        cOrder_dlvraddr3.Name = "order_dlvraddr3"
        cOrder_dlvraddr3.HeaderText = "Delivery Address3"
        cOrder_dlvraddr3.DataPropertyName = "order_dlvraddr3"
        cOrder_dlvraddr3.Width = 130
        cOrder_dlvraddr3.Visible = False
        cOrder_dlvraddr3.ReadOnly = False

        cOrder_dlvrtelp.Name = "order_dlvtelp"
        cOrder_dlvrtelp.HeaderText = "Delivery Telpon"
        cOrder_dlvrtelp.DataPropertyName = "order_dlvrtelp"
        cOrder_dlvrtelp.Width = 130
        cOrder_dlvrtelp.Visible = False
        cOrder_dlvrtelp.ReadOnly = False

        cOrder_dlvrfax.Name = "order_dlvfax"
        cOrder_dlvrfax.HeaderText = "Delivery Fax"
        cOrder_dlvrfax.DataPropertyName = "order_dlvrfax"
        cOrder_dlvrfax.Width = 130
        cOrder_dlvrfax.Visible = False
        cOrder_dlvrfax.ReadOnly = False

        cOrder_dlvrhp.Name = "order_dlvhp"
        cOrder_dlvrhp.HeaderText = "Delivery HP"
        cOrder_dlvrhp.DataPropertyName = "order_dlvrhp"
        cOrder_dlvrhp.Width = 130
        cOrder_dlvrhp.Visible = False
        cOrder_dlvrhp.ReadOnly = False

        cOrder_note.Name = "order_note"
        cOrder_note.HeaderText = "Note"
        cOrder_note.DataPropertyName = "order_note"
        cOrder_note.Width = 70
        cOrder_note.Visible = False
        cOrder_note.ReadOnly = False

        cOrder_intref.Name = "order_intref"
        cOrder_intref.HeaderText = "Internal Reference"
        cOrder_intref.DataPropertyName = "order_intref"
        cOrder_intref.Width = 130
        cOrder_intref.Visible = False
        cOrder_intref.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, _
        corder_date, _
        cOrder_descr, _
        cOrder_spkdesc, _
        cOrder_spkworktype, _
        cCurrency_id, _
        cRekanan_id, _
        cOld_program_id, _
        cOrder_prognm, _
        cOrder_utilizeddatestart, _
        cOrder_utilizeddateend, _
        cOrder_rekanan, _
        cRequest_id, _
        cOrder_progsch, _
        cBudget_id, _
        cOrder_eps, _
        cOrder_setdate, _
        cOrder_settime, _
        cOrder_setlocation, _
        cOrder_utilizedtimestart, _
        cOrder_utilizedtimeend, _
        cOrder_utilizedlocation, _
        cOrder_pph_percent, cOrder_ppn_percent, _
        cOrder_insurancecost, cOrder_transportationcost, _
        cOrder_operatorcost, cOrder_othercost, _
        cOrder_authname, cOrder_authposition, _
        cOrder_authname2, cOrder_authposition2, _
        cOrder_canceled, _
        cOrder_createby, cOrder_createdate, _
        cOrder_modifyby, cOrder_modifydate, _
        cOrder_discount, cOrder_source, cOrdertype_id, _
        cOld_category_id, cOld_apref, cNew_apref, _
        cOrder_revno, cOrder_revdate, cOrder_revdesc, cOrder_approved, _
        cChannel_id, cPeriode_id, cOrder_spkrequired, cStrukturunit_id, cOrder_dlvrname, _
        cOrder_dlvraddr1, cOrder_dlvraddr2, cOrder_dlvraddr3, cOrder_dlvrtelp, _
        cOrder_dlvrfax, cOrder_dlvrhp, cOrder_note, cOrder_intref, cOrder_approved2})

        ' DgvTrnOrder Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.Dock = DockStyle.Fill
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
        objDgv.AutoGenerateColumns = False
    End Function
    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        'formating DgvTrnOrderdetil
        Dim cBtnBudget As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBtnBudgetDetil As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cbOrderdetil_type As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbItem_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCategory_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbUnit_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cbCurrency As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrderdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corderdetil_rowtotalidr_incldisc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corderdetil_rowtotalforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corderdetil_rowtotalforeign_incldisc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_rowtotalidr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pphpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        'Dim corderdetil_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        'Dim corderdetil_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_daysbutton As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cOrderdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim corderdetil_rowtotalforeign_incltax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_rowtotalidr_incltax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_outstd As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_amountsum As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cCategory_spktype As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetaccount_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOld_orderdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_actual As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_actualnote As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_requestid_ref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pphforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        ' Dim cOrderdetil_discountforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cbOrderdetil_type.Name = "orderdetil_type"
        cbOrderdetil_type.HeaderText = "Type"
        cbOrderdetil_type.DataPropertyName = "orderdetil_type"
        cbOrderdetil_type.Width = 50
        cbOrderdetil_type.Visible = True
        cbOrderdetil_type.ReadOnly = True
        cbOrderdetil_type.Frozen = True
        cbOrderdetil_type.ValueMember = "orderdetil_type"
        cbOrderdetil_type.DisplayMember = "orderdetil_type"
        cbOrderdetil_type.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        'cbOrderdetil_type.DisplayStyleForCurrentCellOnly = True
        cbOrderdetil_type.AutoComplete = True
        cbOrderdetil_type.Items.Clear()
        cbOrderdetil_type.Items.Add("Item")
        cbOrderdetil_type.Items.Add("Descr")

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_line.Width = 30
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.Frozen = True


        cbItem_name.Name = "item_id"
        cbItem_name.HeaderText = "Item"
        cbItem_name.DataPropertyName = "item_id"
        cbItem_name.Width = 130
        cbItem_name.Visible = True
        cbItem_name.ReadOnly = True
        cbItem_name.Frozen = True
        cbItem_name.ValueMember = "item_id"
        cbItem_name.DisplayMember = "item_name"
        cbItem_name.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        'cbItem_name.DisplayStyleForCurrentCellOnly = True
        cbItem_name.AutoComplete = True
        cbItem_name.DataSource = Me.tbl_MstItem

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "ItemID"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 100
        cItem_id.Visible = False
        cItem_id.ReadOnly = False

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "ReqLine"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.DefaultCellStyle.BackColor = Color.LightGray
        cRequestdetil_line.Width = 30
        cRequestdetil_line.Visible = True
        cRequestdetil_line.ReadOnly = True

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "Unit"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False


        cbUnit_name.Name = "unit_id"
        cbUnit_name.HeaderText = "Unit"
        cbUnit_name.DataPropertyName = "unit_id"
        cbUnit_name.Width = 50
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
        cbCurrency.Width = 50
        cbCurrency.Visible = True
        cbCurrency.ReadOnly = True
        cbCurrency.ValueMember = "currency_id"
        cbCurrency.DisplayMember = "currency_shortname"
        cbCurrency.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
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
        cOrderdetil_descr.Width = 225
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = False


        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_qty.DefaultCellStyle.Format = "#,##0.00"
        'cOrderdetil_qty.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_qty.Width = 35
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = True


        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 30
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cOrderdetil_foreign.Name = "orderdetil_foreign"
        cOrderdetil_foreign.HeaderText = "Amount"
        cOrderdetil_foreign.DataPropertyName = "orderdetil_foreign"
        cOrderdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        'cOrderdetil_foreign.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_foreign.Width = 110
        cOrderdetil_foreign.Visible = True
        cOrderdetil_foreign.ReadOnly = True


        cOrderdetil_foreignrate.Name = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.HeaderText = "Rate"
        cOrderdetil_foreignrate.DataPropertyName = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        'cOrderdetil_foreignrate.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_foreignrate.Width = 50
        cOrderdetil_foreignrate.Visible = True
        cOrderdetil_foreignrate.ReadOnly = True


        cOrderdetil_discount.Name = "orderdetil_discount"
        cOrderdetil_discount.HeaderText = "Disc."
        cOrderdetil_discount.DataPropertyName = "orderdetil_discount"
        cOrderdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_discount.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_discount.Width = 85
        cOrderdetil_discount.Visible = True
        cOrderdetil_discount.ReadOnly = True


        corderdetil_rowtotalforeign.Name = "orderdetil_rowtotalforeign"
        corderdetil_rowtotalforeign.HeaderText = "SubTotal Original Excl.Disc"
        corderdetil_rowtotalforeign.DataPropertyName = "orderdetil_rowtotalforeign"
        corderdetil_rowtotalforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        corderdetil_rowtotalforeign.DefaultCellStyle.Format = "#,##0.00"
        corderdetil_rowtotalforeign.DefaultCellStyle.BackColor = Color.LightGray
        corderdetil_rowtotalforeign.Width = 130
        corderdetil_rowtotalforeign.Visible = False
        corderdetil_rowtotalforeign.ReadOnly = True


        corderdetil_rowtotalforeign_incldisc.Name = "orderdetil_rowtotalforeign_incldisc"
        corderdetil_rowtotalforeign_incldisc.HeaderText = "SubTotal Original"
        corderdetil_rowtotalforeign_incldisc.DataPropertyName = "orderdetil_rowtotalforeign_incldisc"
        corderdetil_rowtotalforeign_incldisc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        corderdetil_rowtotalforeign_incldisc.DefaultCellStyle.Format = "#,##0.00"
        corderdetil_rowtotalforeign_incldisc.DefaultCellStyle.BackColor = Color.LightGray
        corderdetil_rowtotalforeign_incldisc.Width = 125
        corderdetil_rowtotalforeign_incldisc.Visible = True
        corderdetil_rowtotalforeign_incldisc.ReadOnly = True


        corderdetil_rowtotalidr_incldisc.Name = "orderdetil_rowtotalidr_incldisc"
        corderdetil_rowtotalidr_incldisc.HeaderText = "SubTotal IDR"
        corderdetil_rowtotalidr_incldisc.DataPropertyName = "orderdetil_rowtotalidr_incldisc"
        corderdetil_rowtotalidr_incldisc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        corderdetil_rowtotalidr_incldisc.DefaultCellStyle.Format = "#,##0"
        corderdetil_rowtotalidr_incldisc.DefaultCellStyle.BackColor = Color.LightGray
        corderdetil_rowtotalidr_incldisc.Width = 135
        corderdetil_rowtotalidr_incldisc.Visible = True
        corderdetil_rowtotalidr_incldisc.ReadOnly = True

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_days.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_days.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_days.Width = 35
        cOrderdetil_days.Visible = True
        cOrderdetil_days.ReadOnly = True

        cOrderdetil_daysbutton.Name = "orderdetil_daysbutton"
        cOrderdetil_daysbutton.HeaderText = ""
        cOrderdetil_daysbutton.Text = "..."
        cOrderdetil_daysbutton.UseColumnTextForButtonValue = True
        'cOrderdetil_daysbutton.FlatStyle = FlatStyle.Flat
        cOrderdetil_daysbutton.CellTemplate.Style.BackColor = Color.LightGray
        cOrderdetil_daysbutton.Width = 30
        cOrderdetil_daysbutton.DividerWidth = 3
        cOrderdetil_daysbutton.ReadOnly = True


        cOrderdetil_pphpercent.Name = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.HeaderText = "PPH(%)"
        cOrderdetil_pphpercent.DataPropertyName = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pphpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_pphpercent.Width = 50
        cOrderdetil_pphpercent.Visible = True
        cOrderdetil_pphpercent.ReadOnly = False


        cOrderdetil_pph.Name = "orderdetil_pph"
        cOrderdetil_pph.HeaderText = "PPH Amount"
        cOrderdetil_pph.DataPropertyName = "orderdetil_pph"
        cOrderdetil_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pph.DefaultCellStyle.Format = "#,##0"
        cOrderdetil_pph.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_pph.Width = 100
        cOrderdetil_pph.Visible = True
        cOrderdetil_pph.ReadOnly = True


        cOrderdetil_ppnpercent.Name = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.HeaderText = "PPN(%)"
        cOrderdetil_ppnpercent.DataPropertyName = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppnpercent.Width = 50
        cOrderdetil_ppnpercent.Visible = True
        cOrderdetil_ppnpercent.ReadOnly = False

        cOrderdetil_ppn.Name = "orderdetil_ppn"
        cOrderdetil_ppn.HeaderText = "PPN Amount"
        cOrderdetil_ppn.DataPropertyName = "orderdetil_ppn"
        cOrderdetil_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppn.DefaultCellStyle.Format = "#,##0"
        cOrderdetil_ppn.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_ppn.Width = 100
        cOrderdetil_ppn.Visible = True
        cOrderdetil_ppn.ReadOnly = True


        corderdetil_rowtotalforeign_incltax.Name = "orderdetil_rowtotalforeign_incltax"
        corderdetil_rowtotalforeign_incltax.HeaderText = "SubTotal Ori.Incl.Tax"
        corderdetil_rowtotalforeign_incltax.DataPropertyName = "orderdetil_rowtotalforeign_incltax"
        corderdetil_rowtotalforeign_incltax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        corderdetil_rowtotalforeign_incltax.DefaultCellStyle.Format = "#,##0.00"
        corderdetil_rowtotalforeign_incltax.DefaultCellStyle.BackColor = Color.LightGray
        corderdetil_rowtotalforeign_incltax.Width = 140
        corderdetil_rowtotalforeign_incltax.Visible = True
        corderdetil_rowtotalforeign_incltax.ReadOnly = True


        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 125
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOld_orderdetil_id.Name = "old_orderdetil_id"
        cOld_orderdetil_id.HeaderText = "old_orderdetil_id"
        cOld_orderdetil_id.DataPropertyName = "old_orderdetil_id"
        cOld_orderdetil_id.Width = 100
        cOld_orderdetil_id.Visible = False
        cOld_orderdetil_id.ReadOnly = True

        cOrderdetil_actual.Name = "orderdetil_actual"
        cOrderdetil_actual.HeaderText = "orderdetil_actual"
        cOrderdetil_actual.DataPropertyName = "orderdetil_actual"
        cOrderdetil_actual.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_actual.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_actual.Width = 100
        cOrderdetil_actual.Visible = False
        cOrderdetil_actual.ReadOnly = True

        cOrderdetil_actualnote.Name = "orderdetil_actualnote"
        cOrderdetil_actualnote.HeaderText = "orderdetil_actualnote"
        cOrderdetil_actualnote.DataPropertyName = "orderdetil_actualnote"
        cOrderdetil_actualnote.Width = 100
        cOrderdetil_actualnote.Visible = False
        cOrderdetil_actualnote.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget Header"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 50
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 130
        cBudget_name.ReadOnly = True

        cBtnBudget.Name = "btn_budget"
        cBtnBudget.HeaderText = String.Empty
        cBtnBudget.UseColumnTextForButtonValue = True
        cBtnBudget.FlatStyle = FlatStyle.Flat
        cBtnBudget.CellTemplate.Style.BackColor = Color.Gainsboro
        cBtnBudget.Width = 30
        cBtnBudget.Text = "..."

        If Me._PROGRAMTYPE = "PG" Then
            cBtnBudget.ReadOnly = True
            cBtnBudget.Visible = False
            cBudget_name.Visible = False
        Else
            cBtnBudget.ReadOnly = False
            cBtnBudget.Visible = True
            cBudget_name.Visible = True
        End If

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "budgetdetil_id"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = False

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 130
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = True

        cBtnBudgetDetil.Name = "btn_budgetdetil"
        cBtnBudgetDetil.HeaderText = String.Empty
        cBtnBudgetDetil.UseColumnTextForButtonValue = True
        cBtnBudgetDetil.FlatStyle = FlatStyle.Flat
        cBtnBudgetDetil.CellTemplate.Style.BackColor = Color.Gainsboro
        cBtnBudgetDetil.Width = 30
        cBtnBudgetDetil.Text = "..."
        cBtnBudgetDetil.ReadOnly = True
        'Tampilkan yang di remark di dgvTrnOrderdetil_cellClick


        cBudgetdetil_amount.Name = "budgetdetil_amount"
        cBudgetdetil_amount.HeaderText = "Budget Detil Amt."
        cBudgetdetil_amount.DataPropertyName = "budgetdetil_amount"
        cBudgetdetil_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_amount.DefaultCellStyle.Format = "#,##0.00"
        cBudgetdetil_amount.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetdetil_amount.Width = 120
        cBudgetdetil_amount.Visible = True
        cBudgetdetil_amount.ReadOnly = True

        cBudgetdetil_outstd.Name = "budgetdetil_outstd"
        cBudgetdetil_outstd.HeaderText = "Outstd Budget"
        cBudgetdetil_outstd.DataPropertyName = "budgetdetil_outstd"
        cBudgetdetil_outstd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_outstd.DefaultCellStyle.Format = "#,##0.00"
        cBudgetdetil_outstd.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetdetil_outstd.Width = 120
        cBudgetdetil_outstd.Visible = True
        cBudgetdetil_outstd.ReadOnly = True

        cOrderdetil_amountsum.Name = "orderdetil_amountsum"
        cOrderdetil_amountsum.HeaderText = "Item Ordered Accum."
        cOrderdetil_amountsum.DataPropertyName = "orderdetil_amountsum"
        cOrderdetil_amountsum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_amountsum.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_amountsum.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_amountsum.Width = 135
        cOrderdetil_amountsum.Visible = True
        cOrderdetil_amountsum.ReadOnly = True

        cBudgetdetil_remark.Name = "budgetdetil_remark"
        cBudgetdetil_remark.HeaderText = "Remark"
        cBudgetdetil_remark.DataPropertyName = "budgetdetil_remark"
        cBudgetdetil_remark.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetdetil_remark.Width = 70
        cBudgetdetil_remark.Visible = True
        cBudgetdetil_remark.ReadOnly = True

        cBudgetaccount_id.Name = "budgetaccount_id"
        cBudgetaccount_id.HeaderText = "Budget Acc"
        cBudgetaccount_id.DataPropertyName = "budgetaccount_id"
        cBudgetaccount_id.Width = 100
        cBudgetaccount_id.Visible = False
        cBudgetaccount_id.ReadOnly = True

        cOrderdetil_requestid_ref.Name = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.HeaderText = "RequestID"
        cOrderdetil_requestid_ref.DataPropertyName = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_requestid_ref.Width = 150
        cOrderdetil_requestid_ref.Visible = True
        cOrderdetil_requestid_ref.ReadOnly = True

        cOrderdetil_rowtotalidr.Name = "orderdetil_rowtotalidr"
        cOrderdetil_rowtotalidr.HeaderText = "orderdetil_rowtotalidr"
        cOrderdetil_rowtotalidr.DataPropertyName = "orderdetil_rowtotalidr"
        cOrderdetil_rowtotalidr.Width = 100
        cOrderdetil_rowtotalidr.Visible = False
        cOrderdetil_rowtotalidr.DefaultCellStyle.Format = "#,##0"
        cOrderdetil_rowtotalidr.ReadOnly = True



        cOrderdetil_rowtotalidr_incltax.Name = "orderdetil_rowtotalidr_incltax"
        cOrderdetil_rowtotalidr_incltax.HeaderText = "orderdetil_rowtotalidr_incltax"
        cOrderdetil_rowtotalidr_incltax.DataPropertyName = "orderdetil_rowtotalidr_incltax"
        cOrderdetil_rowtotalidr_incltax.Width = 100
        cOrderdetil_rowtotalidr_incltax.Visible = False
        cOrderdetil_rowtotalidr.DefaultCellStyle.Format = "#,##0"
        cOrderdetil_rowtotalidr_incltax.ReadOnly = False

        cOrderdetil_pphforeign.Name = "orderdetil_pphforeign"
        cOrderdetil_pphforeign.HeaderText = "PPH Amount Foreign"
        cOrderdetil_pphforeign.DataPropertyName = "orderdetil_pphforeign"
        cOrderdetil_pphforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pphforeign.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_pphforeign.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_pphforeign.Width = 100
        cOrderdetil_pphforeign.Visible = True
        cOrderdetil_pphforeign.ReadOnly = True

        cOrderdetil_ppnforeign.Name = "orderdetil_ppnforeign"
        cOrderdetil_ppnforeign.HeaderText = "PPN Amount Foreign"
        cOrderdetil_ppnforeign.DataPropertyName = "orderdetil_ppnforeign"
        cOrderdetil_ppnforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnforeign.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppnforeign.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_ppnforeign.Width = 100
        cOrderdetil_ppnforeign.Visible = True
        cOrderdetil_ppnforeign.ReadOnly = True

        'cOrderdetil_discountforeign.Name = "orderdetil_discountforeign"
        'cOrderdetil_discountforeign.HeaderText = "Disc.Foreign"
        'cOrderdetil_discountforeign.DataPropertyName = "orderdetil_discountforeign"
        'cOrderdetil_discountforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'cOrderdetil_discountforeign.DefaultCellStyle.Format = "#,##0.00"
        'cOrderdetil_discountforeign.Width = 85
        'cOrderdetil_discountforeign.Visible = True
        'cOrderdetil_discountforeign.ReadOnly = True
        cOrderdetil_eps.Name = "eps"
        cOrderdetil_eps.HeaderText = "Eps."
        cOrderdetil_eps.DataPropertyName = "eps"
        cOrderdetil_eps.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_eps.Width = 30
        cOrderdetil_eps.Visible = True
        cOrderdetil_eps.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Dock = DockStyle.Fill
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToOrderColumns = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { _
            cbOrderdetil_type, _
            cOrderdetil_line, _
            cbItem_name, _
            cOrderdetil_descr, _
            cOrderdetil_qty, _
             cOrderdetil_eps, _
            cOrderdetil_days, _
            cOrderdetil_daysbutton, _
            cbUnit_name, _
            cbCurrency, _
            cOrderdetil_foreignrate, _
            cOrderdetil_foreign, _
            cOrderdetil_discount, _
            corderdetil_rowtotalforeign, _
            corderdetil_rowtotalforeign_incldisc, _
            corderdetil_rowtotalidr_incldisc, _
            cOrderdetil_pphpercent, cOrderdetil_pph, cOrderdetil_pphforeign, _
            cOrderdetil_ppnpercent, cOrderdetil_ppn, cOrderdetil_ppnforeign, _
            corderdetil_rowtotalforeign_incltax, _
            cOrderdetil_rowtotalidr, _
            cBudget_id, _
            cBudget_name, _
            cBtnBudget, _
            cBudgetdetil_id, _
            cBudgetdetil_name, _
            cBtnBudgetDetil, _
            cBudgetdetil_amount, _
            cOrderdetil_amountsum, _
            cBudgetdetil_outstd, _
            cBudgetdetil_remark, _
            cCategory_name, _
            cCategory_spktype, _
            cOrder_id, cItem_id, cUnit_id, cCurrency_id, _
            cBudgetaccount_id, _
            cOld_orderdetil_id, cOrderdetil_actual, cOrderdetil_actualnote, _
            cChannel_id, cOrderdetil_requestid_ref, cRequestdetil_line, cOrderdetil_rowtotalidr_incltax})

    End Function
    Private Function FormatDgvTrnOrderdetiluse(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
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
        cOrderdetil_line.HeaderText = "Item`s Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "Utlzd Line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 50
        cOrderdetiluse_line.Visible = True
        cOrderdetiluse_line.ReadOnly = True

        cOrderdetiluse_checked.Name = "orderdetiluse_checked"
        cOrderdetiluse_checked.HeaderText = "Use"
        cOrderdetiluse_checked.DataPropertyName = "orderdetiluse_checked"
        cOrderdetiluse_checked.Width = 30
        cOrderdetiluse_checked.Visible = True
        cOrderdetiluse_checked.ReadOnly = False

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
        cOrderdetiluse_idr.Visible = True
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
    Private Function FormatDgvTrnRentalReq(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
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
        Dim cRequestdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_foreignreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = True

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
        cRequest_date.DefaultCellStyle.Format = "MMM dd, yyyy"
        cRequest_date.Width = 80
        cRequest_date.Visible = True
        cRequest_date.ReadOnly = True

        cRequestdetil_days.Name = "requestdetil_days"
        cRequestdetil_days.HeaderText = "Days"
        cRequestdetil_days.DataPropertyName = "requestdetil_days"
        cRequestdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_days.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_days.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_days.Width = 35
        cRequestdetil_days.Visible = True
        cRequestdetil_days.ReadOnly = True

        cRequestdetil_qty.Name = "requestdetil_qty"
        cRequestdetil_qty.HeaderText = "Qty"
        cRequestdetil_qty.DataPropertyName = "requestdetil_qty"
        cRequestdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_qty.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_qty.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_qty.Width = 35
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

        cRequestdetil_foreignrate.Name = "requestdetil_foreignrate"
        cRequestdetil_foreignrate.HeaderText = "Rate"
        cRequestdetil_foreignrate.DataPropertyName = "requestdetil_foreignrate"
        cRequestdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_foreignrate.Width = 35
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

        cRequestdetil_discount.Name = "requestdetil_discount"
        cRequestdetil_discount.HeaderText = "Discount"
        cRequestdetil_discount.DataPropertyName = "requestdetil_discount"
        cRequestdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_discount.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_discount.DefaultCellStyle.BackColor = Color.Gainsboro
        cRequestdetil_discount.Width = 100
        cRequestdetil_discount.Visible = True
        cRequestdetil_discount.ReadOnly = True


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
            cRequestdetil_days, _
            cCurrency_id, _
            cCurrency_name, _
            cRequestdetil_foreignreal, _
            cRequestdetil_foreignrate, _
            cRequestdetil_idr, _
            cRequestdetil_discount, _
            cRequest_strukturunitid, _
            cRequest_strukturunitname, _
            cOrder_id, _
            cBudget_id, _
            cBudgetdetil_id _
        })

    End Function
    Private Function FormatDgvTrnTalentorder(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnTalentorder Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_approved As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrder_approvedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_approveddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_canceled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrder_approvedname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cOrder_approved.Name = "order_approved"
        cOrder_approved.HeaderText = "Approved"
        cOrder_approved.DataPropertyName = "order_approved"
        cOrder_approved.Width = 100
        cOrder_approved.Visible = False
        cOrder_approved.ReadOnly = False

        cOrder_approvedby.Name = "order_approvedby"
        cOrder_approvedby.HeaderText = "Approved by."
        cOrder_approvedby.DataPropertyName = "order_approvedby"
        cOrder_approvedby.Width = 100
        cOrder_approvedby.Visible = True
        cOrder_approvedby.ReadOnly = False

        cOrder_approveddt.Name = "order_approveddt"
        cOrder_approveddt.HeaderText = "Approved Date"
        cOrder_approveddt.DataPropertyName = "order_approveddt"
        cOrder_approveddt.Width = 100
        cOrder_approveddt.Visible = True
        cOrder_approveddt.ReadOnly = False

        cOrder_canceled.Name = "order_canceled"
        cOrder_canceled.HeaderText = "Order Canceled"
        cOrder_canceled.DataPropertyName = "order_canceled"
        cOrder_canceled.Width = 100
        cOrder_canceled.Visible = False
        cOrder_canceled.ReadOnly = False

        cOrder_approvedname.Name = "order_approvedname"
        cOrder_approvedname.HeaderText = "Approved"
        cOrder_approvedname.DataPropertyName = "order_approvedname"
        cOrder_approvedname.Width = 100
        cOrder_approvedname.Visible = True
        cOrder_approvedname.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, cOrder_approved, cOrder_approvedby, cOrder_approveddt, cOrder_canceled, cOrder_approvedname})



        ' DgvTrnTalentorder Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvTrnTerimajasa(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnTerimajasa Columns 
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_qtyitem As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_qtyrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_statusrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_location As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_notes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_nosuratjalan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_isdisabled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_createdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_modifiedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_modifieddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appuser As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_appuser_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appuser_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appspv As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_appspv_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appspv_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appbma As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_appbma_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appbma_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_cetakbpj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "ID"
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.Visible = True
        cTerimajasa_id.ReadOnly = False

        cTerimajasa_date.Name = "terimajasa_date"
        cTerimajasa_date.HeaderText = "Date"
        cTerimajasa_date.DataPropertyName = "terimajasa_date"
        cTerimajasa_date.Width = 100
        cTerimajasa_date.Visible = True
        cTerimajasa_date.ReadOnly = False

        cTerimajasa_type.Name = "terimajasa_type"
        cTerimajasa_type.HeaderText = "Type"
        cTerimajasa_type.DataPropertyName = "terimajasa_type"
        cTerimajasa_type.Width = 100
        cTerimajasa_type.Visible = True
        cTerimajasa_type.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Rekanan Id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = False

        cEmployee_id_owner.Name = "employee_id_owner"
        cEmployee_id_owner.HeaderText = "Owner ID"
        cEmployee_id_owner.DataPropertyName = "employee_id_owner"
        cEmployee_id_owner.Width = 100
        cEmployee_id_owner.Visible = True
        cEmployee_id_owner.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cTerimajasa_qtyitem.Name = "terimajasa_qtyitem"
        cTerimajasa_qtyitem.HeaderText = "Qty Item"
        cTerimajasa_qtyitem.DataPropertyName = "terimajasa_qtyitem"
        cTerimajasa_qtyitem.Width = 100
        cTerimajasa_qtyitem.Visible = True
        cTerimajasa_qtyitem.ReadOnly = False

        cTerimajasa_qtyrealization.Name = "terimajasa_qtyrealization"
        cTerimajasa_qtyrealization.HeaderText = "Qty Realization"
        cTerimajasa_qtyrealization.DataPropertyName = "terimajasa_qtyrealization"
        cTerimajasa_qtyrealization.Width = 100
        cTerimajasa_qtyrealization.Visible = True
        cTerimajasa_qtyrealization.ReadOnly = False

        cOrder_qty.Name = "order_qty"
        cOrder_qty.HeaderText = "Order Qty"
        cOrder_qty.DataPropertyName = "order_qty"
        cOrder_qty.Width = 100
        cOrder_qty.Visible = True
        cOrder_qty.ReadOnly = False

        cTerimajasa_status.Name = "terimajasa_status"
        cTerimajasa_status.HeaderText = "Status"
        cTerimajasa_status.DataPropertyName = "terimajasa_status"
        cTerimajasa_status.Width = 100
        cTerimajasa_status.Visible = True
        cTerimajasa_status.ReadOnly = False

        cTerimajasa_statusrealization.Name = "terimajasa_statusrealization"
        cTerimajasa_statusrealization.HeaderText = "Status Realization"
        cTerimajasa_statusrealization.DataPropertyName = "terimajasa_statusrealization"
        cTerimajasa_statusrealization.Width = 100
        cTerimajasa_statusrealization.Visible = True
        cTerimajasa_statusrealization.ReadOnly = False

        cTerimajasa_location.Name = "terimajasa_location"
        cTerimajasa_location.HeaderText = "Loc."
        cTerimajasa_location.DataPropertyName = "terimajasa_location"
        cTerimajasa_location.Width = 100
        cTerimajasa_location.Visible = True
        cTerimajasa_location.ReadOnly = False

        cTerimajasa_notes.Name = "terimajasa_notes"
        cTerimajasa_notes.HeaderText = "terimajasa_notes"
        cTerimajasa_notes.DataPropertyName = "terimajasa_notes"
        cTerimajasa_notes.Width = 100
        cTerimajasa_notes.Visible = False
        cTerimajasa_notes.ReadOnly = False

        cTerimajasa_nosuratjalan.Name = "terimajasa_nosuratjalan"
        cTerimajasa_nosuratjalan.HeaderText = "terimajasa_nosuratjalan"
        cTerimajasa_nosuratjalan.DataPropertyName = "terimajasa_nosuratjalan"
        cTerimajasa_nosuratjalan.Width = 100
        cTerimajasa_nosuratjalan.Visible = False
        cTerimajasa_nosuratjalan.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimajasa_isdisabled.Name = "terimajasa_isdisabled"
        cTerimajasa_isdisabled.HeaderText = "terimajasa_isdisabled"
        cTerimajasa_isdisabled.DataPropertyName = "terimajasa_isdisabled"
        cTerimajasa_isdisabled.Width = 100
        cTerimajasa_isdisabled.Visible = True
        cTerimajasa_isdisabled.ReadOnly = False

        cTerimajasa_createby.Name = "terimajasa_createby"
        cTerimajasa_createby.HeaderText = "Create By"
        cTerimajasa_createby.DataPropertyName = "terimajasa_createby"
        cTerimajasa_createby.Width = 100
        cTerimajasa_createby.Visible = True
        cTerimajasa_createby.ReadOnly = False

        cTerimajasa_createdt.Name = "terimajasa_createdt"
        cTerimajasa_createdt.HeaderText = "Create Date"
        cTerimajasa_createdt.DataPropertyName = "terimajasa_createdt"
        cTerimajasa_createdt.Width = 100
        cTerimajasa_createdt.Visible = True
        cTerimajasa_createdt.ReadOnly = False

        cTerimajasa_modifiedby.Name = "terimajasa_modifiedby"
        cTerimajasa_modifiedby.HeaderText = "Modified By"
        cTerimajasa_modifiedby.DataPropertyName = "terimajasa_modifiedby"
        cTerimajasa_modifiedby.Width = 100
        cTerimajasa_modifiedby.Visible = True
        cTerimajasa_modifiedby.ReadOnly = False

        cTerimajasa_modifieddt.Name = "terimajasa_modifieddt"
        cTerimajasa_modifieddt.HeaderText = "Modified Date"
        cTerimajasa_modifieddt.DataPropertyName = "terimajasa_modifieddt"
        cTerimajasa_modifieddt.Width = 100
        cTerimajasa_modifieddt.Visible = True
        cTerimajasa_modifieddt.ReadOnly = False

        cTerimajasa_appuser.Name = "terimajasa_appuser"
        cTerimajasa_appuser.HeaderText = "App User"
        cTerimajasa_appuser.DataPropertyName = "terimajasa_appuser"
        cTerimajasa_appuser.Width = 100
        cTerimajasa_appuser.Visible = True
        cTerimajasa_appuser.ReadOnly = False

        cTerimajasa_appuser_by.Name = "terimajasa_appuser_by"
        cTerimajasa_appuser_by.HeaderText = "App User By"
        cTerimajasa_appuser_by.DataPropertyName = "terimajasa_appuser_by"
        cTerimajasa_appuser_by.Width = 100
        cTerimajasa_appuser_by.Visible = True
        cTerimajasa_appuser_by.ReadOnly = False

        cTerimajasa_appuser_dt.Name = "terimajasa_appuser_dt"
        cTerimajasa_appuser_dt.HeaderText = "App User Date"
        cTerimajasa_appuser_dt.DataPropertyName = "terimajasa_appuser_dt"
        cTerimajasa_appuser_dt.Width = 100
        cTerimajasa_appuser_dt.Visible = True
        cTerimajasa_appuser_dt.ReadOnly = False

        cTerimajasa_appspv.Name = "terimajasa_appspv"
        cTerimajasa_appspv.HeaderText = "App Spv"
        cTerimajasa_appspv.DataPropertyName = "terimajasa_appspv"
        cTerimajasa_appspv.Width = 100
        cTerimajasa_appspv.Visible = True
        cTerimajasa_appspv.ReadOnly = False

        cTerimajasa_appspv_by.Name = "terimajasa_appspv_by"
        cTerimajasa_appspv_by.HeaderText = "App Spv By"
        cTerimajasa_appspv_by.DataPropertyName = "terimajasa_appspv_by"
        cTerimajasa_appspv_by.Width = 100
        cTerimajasa_appspv_by.Visible = True
        cTerimajasa_appspv_by.ReadOnly = False

        cTerimajasa_appspv_dt.Name = "terimajasa_appspv_dt"
        cTerimajasa_appspv_dt.HeaderText = "App Spv Date"
        cTerimajasa_appspv_dt.DataPropertyName = "terimajasa_appspv_dt"
        cTerimajasa_appspv_dt.Width = 100
        cTerimajasa_appspv_dt.Visible = True
        cTerimajasa_appspv_dt.ReadOnly = False

        cTerimajasa_appbma.Name = "terimajasa_appbma"
        cTerimajasa_appbma.HeaderText = "App Bma"
        cTerimajasa_appbma.DataPropertyName = "terimajasa_appbma"
        cTerimajasa_appbma.Width = 100
        cTerimajasa_appbma.Visible = True
        cTerimajasa_appbma.ReadOnly = False

        cTerimajasa_appbma_by.Name = "terimajasa_appbma_by"
        cTerimajasa_appbma_by.HeaderText = "App BMA By"
        cTerimajasa_appbma_by.DataPropertyName = "terimajasa_appbma_by"
        cTerimajasa_appbma_by.Width = 100
        cTerimajasa_appbma_by.Visible = True
        cTerimajasa_appbma_by.ReadOnly = False

        cTerimajasa_appbma_dt.Name = "terimajasa_appbma_dt"
        cTerimajasa_appbma_dt.HeaderText = "App BMA Date"
        cTerimajasa_appbma_dt.DataPropertyName = "terimajasa_appbma_dt"
        cTerimajasa_appbma_dt.Width = 100
        cTerimajasa_appbma_dt.Visible = True
        cTerimajasa_appbma_dt.ReadOnly = False

        cTerimajasa_foreign.Name = "terimajasa_foreign"
        cTerimajasa_foreign.HeaderText = "Foreign"
        cTerimajasa_foreign.DataPropertyName = "terimajasa_foreign"
        cTerimajasa_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimajasa_foreign.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasa_foreign.Width = 100
        cTerimajasa_foreign.Visible = True
        cTerimajasa_foreign.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cTerimajasa_foreignrate.Name = "terimajasa_foreignrate"
        cTerimajasa_foreignrate.HeaderText = "Foreign Rate"
        cTerimajasa_foreignrate.DataPropertyName = "terimajasa_foreignrate"
        cTerimajasa_foreignrate.Width = 100
        cTerimajasa_foreignrate.Visible = True
        cTerimajasa_foreignrate.ReadOnly = False

        cTerimajasa_idrreal.Name = "terimajasa_idrreal"
        cTerimajasa_idrreal.HeaderText = "IDR"
        cTerimajasa_idrreal.DataPropertyName = "terimajasa_idrreal"
        cTerimajasa_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimajasa_idrreal.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasa_idrreal.Width = 110
        cTerimajasa_idrreal.Visible = True
        cTerimajasa_idrreal.ReadOnly = False

        cTerimajasa_pph.Name = "terimajasa_pph"
        cTerimajasa_pph.HeaderText = "PPh"
        cTerimajasa_pph.DataPropertyName = "terimajasa_pph"
        cTerimajasa_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimajasa_pph.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasa_pph.Width = 100
        cTerimajasa_pph.Visible = True
        cTerimajasa_pph.ReadOnly = False

        cTerimajasa_ppn.Name = "terimajasa_ppn"
        cTerimajasa_ppn.HeaderText = "PPn"
        cTerimajasa_ppn.DataPropertyName = "terimajasa_ppn"
        cTerimajasa_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimajasa_ppn.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasa_ppn.Width = 100
        cTerimajasa_ppn.Visible = True
        cTerimajasa_ppn.ReadOnly = False

        cTerimajasa_disc.Name = "terimajasa_disc"
        cTerimajasa_disc.HeaderText = "Disc"
        cTerimajasa_disc.DataPropertyName = "terimajasa_disc"
        cTerimajasa_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimajasa_disc.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasa_disc.Width = 100
        cTerimajasa_disc.Visible = True
        cTerimajasa_disc.ReadOnly = False

        cTerimajasa_cetakbpj.Name = "terimajasa_cetakbpj"
        cTerimajasa_cetakbpj.HeaderText = "terimajasa_cetakbpj"
        cTerimajasa_cetakbpj.DataPropertyName = "terimajasa_cetakbpj"
        cTerimajasa_cetakbpj.Width = 100
        cTerimajasa_cetakbpj.Visible = False
        cTerimajasa_cetakbpj.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasa_id, cTerimajasa_date, cTerimajasa_type, cOrder_id, cBudget_id, cRekanan_id, cEmployee_id_owner, cStrukturunit_id, cTerimajasa_qtyitem, cTerimajasa_qtyrealization, cOrder_qty, cTerimajasa_status, cTerimajasa_statusrealization, cTerimajasa_location, cTerimajasa_notes, cTerimajasa_nosuratjalan, cChannel_id, cTerimajasa_isdisabled, cTerimajasa_createby, cTerimajasa_createdt, cTerimajasa_modifiedby, cTerimajasa_modifieddt, cTerimajasa_appuser, cTerimajasa_appuser_by, cTerimajasa_appuser_dt, cTerimajasa_appspv, cTerimajasa_appspv_by, cTerimajasa_appspv_dt, cTerimajasa_appbma, cTerimajasa_appbma_by, cTerimajasa_appbma_dt, cTerimajasa_foreign, cCurrency_id, cTerimajasa_foreignrate, cTerimajasa_idrreal, cTerimajasa_pph, cTerimajasa_ppn, cTerimajasa_disc, cTerimajasa_cetakbpj})



        ' DgvTrnTerimajasa Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvDocCirculation(ByRef objDgv As DataGridView) As Boolean
        ' Format DgvN Columns 
        Dim cCirculation_id As New DataGridViewTextBoxColumn
        Dim cCirculationdetil_ref As New DataGridViewTextBoxColumn
        Dim cCirculation_createby As New DataGridViewTextBoxColumn
        Dim cCirculation_createdt As New DataGridViewTextBoxColumn
        Dim cStrukturunit_id As New DataGridViewTextBoxColumn
        Dim cDepartment_from As New DataGridViewTextBoxColumn
        Dim cCirculation_sendto As New DataGridViewTextBoxColumn
        Dim cCirculation_senddt As New DataGridViewTextBoxColumn
        Dim cCirculation_sendtodeptid As New DataGridViewTextBoxColumn
        Dim cDepartment_to As New DataGridViewTextBoxColumn
        Dim cChannel_id As New DataGridViewTextBoxColumn



        cCirculation_id.Name = "circulation_id"
        cCirculation_id.HeaderText = "ID"
        cCirculation_id.DataPropertyName = "circulation_id"
        cCirculation_id.Width = 100
        cCirculation_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_id.Visible = True
        cCirculation_id.ReadOnly = True

        cCirculationdetil_ref.Name = "circulationdetil_ref"
        cCirculationdetil_ref.HeaderText = "Req. ID"
        cCirculationdetil_ref.DataPropertyName = "circulationdetil_ref"
        cCirculationdetil_ref.Width = 100
        cCirculationdetil_ref.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculationdetil_ref.Visible = True
        cCirculationdetil_ref.ReadOnly = True

        cCirculation_createby.Name = "circulation_createby"
        cCirculation_createby.HeaderText = "Create By"
        cCirculation_createby.DataPropertyName = "circulation_createby"
        cCirculation_createby.Width = 150
        cCirculation_createby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_createby.Visible = True
        cCirculation_createby.ReadOnly = True

        cCirculation_createdt.Name = "circulation_createdt"
        cCirculation_createdt.HeaderText = "Create Date"
        cCirculation_createdt.DataPropertyName = "circulation_createdt"
        cCirculation_createdt.Width = 100
        cCirculation_createdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_createdt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cCirculation_createdt.Visible = True
        cCirculation_createdt.ReadOnly = True

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = True

        cDepartment_from.Name = "department_from"
        cDepartment_from.HeaderText = "Department From"
        cDepartment_from.DataPropertyName = "department_from"
        cDepartment_from.Width = 150
        cDepartment_from.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepartment_from.Visible = True
        cDepartment_from.ReadOnly = True

        cCirculation_sendto.Name = "circulation_sendto"
        cCirculation_sendto.HeaderText = "Send To"
        cCirculation_sendto.DataPropertyName = "circulation_sendto"
        cCirculation_sendto.Width = 150
        cCirculation_sendto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_sendto.Visible = True
        cCirculation_sendto.ReadOnly = True

        cCirculation_senddt.Name = "circulation_senddt"
        cCirculation_senddt.HeaderText = "Send Date"
        cCirculation_senddt.DataPropertyName = "circulation_senddt"
        cCirculation_senddt.Width = 100
        cCirculation_senddt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_senddt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cCirculation_senddt.Visible = True
        cCirculation_senddt.ReadOnly = True

        cCirculation_sendtodeptid.Name = "circulation_sendtodeptid"
        cCirculation_sendtodeptid.HeaderText = "circulation_sendtodeptid"
        cCirculation_sendtodeptid.DataPropertyName = "circulation_sendtodeptid"
        cCirculation_sendtodeptid.Width = 100
        cCirculation_sendtodeptid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_sendtodeptid.Visible = False
        cCirculation_sendtodeptid.ReadOnly = True

        cDepartment_to.Name = "department_to"
        cDepartment_to.HeaderText = "Department To"
        cDepartment_to.DataPropertyName = "department_to"
        cDepartment_to.Width = 150
        cDepartment_to.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepartment_to.Visible = True
        cDepartment_to.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cCirculation_id, cCirculationdetil_ref, _
        cCirculation_createby, cCirculation_createdt, _
        cStrukturunit_id, cDepartment_from, _
        cCirculation_sendto, cCirculation_senddt, _
        cCirculation_sendtodeptid, cDepartment_to, cChannel_id})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True

    End Function
    Private Function FormatDgvTandaTerimaDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvN Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRemaks As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cFaktur_pajak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSurat_jalan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cCreate_date.Name = "create_date"
        cCreate_date.HeaderText = "Create Date"
        cCreate_date.DataPropertyName = "create_date"
        cCreate_date.Width = 100
        cCreate_date.Visible = True
        cCreate_date.ReadOnly = False

        cRemaks.Name = "remaks"
        cRemaks.HeaderText = "Invoice No."
        cRemaks.DataPropertyName = "remaks"
        cRemaks.Width = 100
        cRemaks.Visible = True
        cRemaks.ReadOnly = False

        cFaktur_pajak.Name = "faktur_pajak"
        cFaktur_pajak.HeaderText = "Faktur Pajak"
        cFaktur_pajak.DataPropertyName = "faktur_pajak"
        cFaktur_pajak.Width = 100
        cFaktur_pajak.Visible = True
        cFaktur_pajak.ReadOnly = False

        cSurat_jalan.Name = "surat_jalan"
        cSurat_jalan.HeaderText = "Surat Jalan"
        cSurat_jalan.DataPropertyName = "surat_jalan"
        cSurat_jalan.Width = 100
        cSurat_jalan.Visible = True
        cSurat_jalan.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, cCreate_date, cRemaks, cFaktur_pajak, cSurat_jalan})



        ' DgvN Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvTrnAdvance(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnAdvance Columns 
        Dim cAdvance_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_advance As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutstanding_approved As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_isrequest As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvance_requestid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_requestid_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPph_persen_settlement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_persen_settlement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_discount_settlement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_intercompany_settlement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlement_nettforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlement_nett As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlementreimburseforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlementreimburse As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlementrefundforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_settlementrefund As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSettlement_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsername As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSettlement_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSettlement_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_isreimburse As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvance_reimburseid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_fromsettlement As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvancedetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPph_persen As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_persen As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_subtotalforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_subtotal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cFaktur_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_intercompany As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutstanding_settlement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDescr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "Advance ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.Visible = True
        cAdvance_id.ReadOnly = False

        cDescr.Name = "Descr"
        cDescr.HeaderText = "Descr"
        cDescr.DataPropertyName = "Descr"
        cDescr.Width = 150
        cDescr.Visible = True
        cDescr.ReadOnly = False

        cAdvancedetil_line.Name = "advancedetil_line"
        cAdvancedetil_line.HeaderText = "Line"
        cAdvancedetil_line.DataPropertyName = "advancedetil_line"
        cAdvancedetil_line.Width = 35
        cAdvancedetil_line.Visible = False
        cAdvancedetil_line.ReadOnly = False

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "budgetdetil_line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 100
        cBudgetdetil_line.Visible = False
        cBudgetdetil_line.ReadOnly = False

        cAdvancedetil_type.Name = "advancedetil_type"
        cAdvancedetil_type.HeaderText = "Type"
        cAdvancedetil_type.DataPropertyName = "advancedetil_type"
        cAdvancedetil_type.Width = 100
        cAdvancedetil_type.Visible = False
        cAdvancedetil_type.ReadOnly = False

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 100
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cBudgetdetil_eps.Name = "budgetdetil_eps"
        cBudgetdetil_eps.HeaderText = "budgetdetil_eps"
        cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
        cBudgetdetil_eps.Width = 100
        cBudgetdetil_eps.Visible = False
        cBudgetdetil_eps.ReadOnly = False

        cBudgetdetil_days.Name = "budgetdetil_days"
        cBudgetdetil_days.HeaderText = "budgetdetil_days"
        cBudgetdetil_days.DataPropertyName = "budgetdetil_days"
        cBudgetdetil_days.Width = 100
        cBudgetdetil_days.Visible = False
        cBudgetdetil_days.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "acc_id"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False


        cAmount_advance.Name = "amount_advance"
        cAmount_advance.HeaderText = "Amount"
        cAmount_advance.DataPropertyName = "amount_advance"
        cAmount_advance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_advance.DefaultCellStyle.Format = "#,##0.00"
        cAmount_advance.Width = 150
        cAmount_advance.Visible = True
        cAmount_advance.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "budgetdetil_id"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = False

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budgetdetil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 150
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = False

        cAdvancedetil_foreignrate.Name = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.HeaderText = "Foreign Rate"
        cAdvancedetil_foreignrate.DataPropertyName = "advancedetil_foreignrate"

        cAdvancedetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cAdvancedetil_foreignrate.Width = 100
        cAdvancedetil_foreignrate.Visible = True
        cAdvancedetil_foreignrate.ReadOnly = False

        cAmount_idrreal.Name = "amount_idrreal"
        cAmount_idrreal.HeaderText = "IDR"
        cAmount_idrreal.DataPropertyName = "amount_idrreal"

        cAmount_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_idrreal.DefaultCellStyle.Format = "#,##0.00"
        cAmount_idrreal.Width = 100
        cAmount_idrreal.Visible = True
        cAmount_idrreal.ReadOnly = False

        cOutstanding_approved.Name = "outstanding_approved"
        cOutstanding_approved.HeaderText = "Out.App"
        cOutstanding_approved.DataPropertyName = "outstanding_approved"
        cOutstanding_approved.Width = 100
        cOutstanding_approved.Visible = False
        cOutstanding_approved.ReadOnly = False

        cAdvance_isrequest.Name = "advance_isrequest"
        cAdvance_isrequest.HeaderText = "Is Req."
        cAdvance_isrequest.DataPropertyName = "advance_isrequest"
        cAdvance_isrequest.Width = 35
        cAdvance_isrequest.Visible = False
        cAdvance_isrequest.ReadOnly = False

        cAdvance_requestid.Name = "advance_requestid"
        cAdvance_requestid.HeaderText = "Req.ID"
        cAdvance_requestid.DataPropertyName = "advance_requestid"
        cAdvance_requestid.Width = 100
        cAdvance_requestid.Visible = False
        cAdvance_requestid.ReadOnly = False

        cAdvance_requestid_line.Name = "advance_requestid_line"
        cAdvance_requestid_line.HeaderText = "Req.Line"
        cAdvance_requestid_line.DataPropertyName = "advance_requestid_line"
        cAdvance_requestid_line.Width = 35
        cAdvance_requestid_line.Visible = False
        cAdvance_requestid_line.ReadOnly = False

        cAmount_settlement.Name = "amount_settlement"
        cAmount_settlement.HeaderText = "Amount Settlement"
        cAmount_settlement.DataPropertyName = "amount_settlement"
        cAmount_settlement.Width = 100
        cAmount_settlement.Visible = False
        cAmount_settlement.ReadOnly = False

        cPph_persen_settlement.Name = "pph_persen_settlement"
        cPph_persen_settlement.HeaderText = "PPH Settle"
        cPph_persen_settlement.DataPropertyName = "pph_persen_settlement"
        cPph_persen_settlement.Width = 100
        cPph_persen_settlement.Visible = False
        cPph_persen_settlement.ReadOnly = False

        cPpn_persen_settlement.Name = "ppn_persen_settlement"
        cPpn_persen_settlement.HeaderText = "PPn Settle"
        cPpn_persen_settlement.DataPropertyName = "ppn_persen_settlement"
        cPpn_persen_settlement.Width = 100
        cPpn_persen_settlement.Visible = False
        cPpn_persen_settlement.ReadOnly = False

        cAmount_discount_settlement.Name = "amount_discount_settlement"
        cAmount_discount_settlement.HeaderText = "Disc.Settle"
        cAmount_discount_settlement.DataPropertyName = "amount_discount_settlement"
        cAmount_discount_settlement.Width = 100
        cAmount_discount_settlement.Visible = False
        cAmount_discount_settlement.ReadOnly = False

        cAmount_intercompany_settlement.Name = "amount_intercompany_settlement"
        cAmount_intercompany_settlement.HeaderText = "amount_intercompany_settlement"
        cAmount_intercompany_settlement.DataPropertyName = "amount_intercompany_settlement"
        cAmount_intercompany_settlement.Width = 100
        cAmount_intercompany_settlement.Visible = False
        cAmount_intercompany_settlement.ReadOnly = False

        cAmount_settlement_nettforeign.Name = "amount_settlement_nettforeign"
        cAmount_settlement_nettforeign.HeaderText = "amount_settlement_nettforeign"
        cAmount_settlement_nettforeign.DataPropertyName = "amount_settlement_nettforeign"
        cAmount_settlement_nettforeign.Width = 100
        cAmount_settlement_nettforeign.Visible = False
        cAmount_settlement_nettforeign.ReadOnly = False

        cAmount_settlement_nett.Name = "amount_settlement_nett"
        cAmount_settlement_nett.HeaderText = "Amount Nett"
        cAmount_settlement_nett.DataPropertyName = "amount_settlement_nett"
        cAmount_settlement_nett.Width = 100
        cAmount_settlement_nett.Visible = False
        cAmount_settlement_nett.ReadOnly = False

        cAmount_settlementreimburseforeign.Name = "amount_settlementreimburseforeign"
        cAmount_settlementreimburseforeign.HeaderText = "amount_settlementreimburseforeign"
        cAmount_settlementreimburseforeign.DataPropertyName = "amount_settlementreimburseforeign"
        cAmount_settlementreimburseforeign.Width = 100
        cAmount_settlementreimburseforeign.Visible = False
        cAmount_settlementreimburseforeign.ReadOnly = False

        cAmount_settlementreimburse.Name = "amount_settlementreimburse"
        cAmount_settlementreimburse.HeaderText = "amount_settlementreimburse"
        cAmount_settlementreimburse.DataPropertyName = "amount_settlementreimburse"
        cAmount_settlementreimburse.Width = 100
        cAmount_settlementreimburse.Visible = False
        cAmount_settlementreimburse.ReadOnly = False

        cAmount_settlementrefundforeign.Name = "amount_settlementrefundforeign"
        cAmount_settlementrefundforeign.HeaderText = "amount_settlementrefundforeign"
        cAmount_settlementrefundforeign.DataPropertyName = "amount_settlementrefundforeign"
        cAmount_settlementrefundforeign.Width = 100
        cAmount_settlementrefundforeign.Visible = False
        cAmount_settlementrefundforeign.ReadOnly = False

        cAmount_settlementrefund.Name = "amount_settlementrefund"
        cAmount_settlementrefund.HeaderText = "amount_settlementrefund"
        cAmount_settlementrefund.DataPropertyName = "amount_settlementrefund"
        cAmount_settlementrefund.Width = 100
        cAmount_settlementrefund.Visible = False
        cAmount_settlementrefund.ReadOnly = False

        cSettlement_id.Name = "settlement_id"
        cSettlement_id.HeaderText = "Settle ID"
        cSettlement_id.DataPropertyName = "settlement_id"
        cSettlement_id.Width = 100
        cSettlement_id.Visible = False
        cSettlement_id.ReadOnly = False

        cUsername.Name = "username"
        cUsername.HeaderText = "User"
        cUsername.DataPropertyName = "username"
        cUsername.Width = 100
        cUsername.Visible = False
        cUsername.ReadOnly = False

        cSettlement_rate.Name = "settlement_rate"
        cSettlement_rate.HeaderText = "Rate"
        cSettlement_rate.DataPropertyName = "settlement_rate"
        cSettlement_rate.Width = 100
        cSettlement_rate.Visible = False
        cSettlement_rate.ReadOnly = False

        cSettlement_foreign.Name = "settlement_foreign"
        cSettlement_foreign.HeaderText = "Foreign"
        cSettlement_foreign.DataPropertyName = "settlement_foreign"
        cSettlement_foreign.Width = 100
        cSettlement_foreign.Visible = False
        cSettlement_foreign.ReadOnly = False

        cAdvance_isreimburse.Name = "advance_isreimburse"
        cAdvance_isreimburse.HeaderText = "advance_isreimburse"
        cAdvance_isreimburse.DataPropertyName = "advance_isreimburse"
        cAdvance_isreimburse.Width = 100
        cAdvance_isreimburse.Visible = False
        cAdvance_isreimburse.ReadOnly = False

        cAdvance_reimburseid.Name = "advance_reimburseid"
        cAdvance_reimburseid.HeaderText = "advance_reimburseid"
        cAdvance_reimburseid.DataPropertyName = "advance_reimburseid"
        cAdvance_reimburseid.Width = 100
        cAdvance_reimburseid.Visible = False
        cAdvance_reimburseid.ReadOnly = False

        cAdvancedetil_fromsettlement.Name = "advancedetil_fromsettlement"
        cAdvancedetil_fromsettlement.HeaderText = "advancedetil_fromsettlement"
        cAdvancedetil_fromsettlement.DataPropertyName = "advancedetil_fromsettlement"
        cAdvancedetil_fromsettlement.Width = 100
        cAdvancedetil_fromsettlement.Visible = False
        cAdvancedetil_fromsettlement.ReadOnly = False

        cAdvancedetil_discount.Name = "advancedetil_discount"
        cAdvancedetil_discount.HeaderText = "advancedetil_discount"
        cAdvancedetil_discount.DataPropertyName = "advancedetil_discount"
        cAdvancedetil_discount.Width = 100
        cAdvancedetil_discount.Visible = False
        cAdvancedetil_discount.ReadOnly = False

        cPph_persen.Name = "pph_persen"
        cPph_persen.HeaderText = "pph_persen"
        cPph_persen.DataPropertyName = "pph_persen"
        cPph_persen.Width = 100
        cPph_persen.Visible = False
        cPph_persen.ReadOnly = False

        cPpn_persen.Name = "ppn_persen"
        cPpn_persen.HeaderText = "ppn_persen"
        cPpn_persen.DataPropertyName = "ppn_persen"
        cPpn_persen.Width = 100
        cPpn_persen.Visible = False
        cPpn_persen.ReadOnly = False

        cAmount_subtotalforeign.Name = "amount_subtotalforeign"
        cAmount_subtotalforeign.HeaderText = "Sub Foreign"
        cAmount_subtotalforeign.DataPropertyName = "amount_subtotalforeign"
        cAmount_subtotalforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_subtotalforeign.DefaultCellStyle.Format = "#,##0.00"
        cAmount_subtotalforeign.Width = 100
        cAmount_subtotalforeign.Visible = True
        cAmount_subtotalforeign.ReadOnly = False

        cAmount_subtotal.Name = "amount_subtotal"
        cAmount_subtotal.HeaderText = "Subtotal"
        cAmount_subtotal.DataPropertyName = "amount_subtotal"
        cAmount_subtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_subtotal.DefaultCellStyle.Format = "#,##0.00"
        cAmount_subtotal.Width = 100
        cAmount_subtotal.Visible = True
        cAmount_subtotal.ReadOnly = False

        cFaktur_id.Name = "faktur_id"
        cFaktur_id.HeaderText = "faktur_id"
        cFaktur_id.DataPropertyName = "faktur_id"
        cFaktur_id.Width = 100
        cFaktur_id.Visible = False
        cFaktur_id.ReadOnly = False

        cAmount_intercompany.Name = "amount_intercompany"
        cAmount_intercompany.HeaderText = "amount_intercompany"
        cAmount_intercompany.DataPropertyName = "amount_intercompany"
        cAmount_intercompany.Width = 100
        cAmount_intercompany.Visible = False
        cAmount_intercompany.ReadOnly = False

        cOutstanding_settlement.Name = "outstanding_settlement"
        cOutstanding_settlement.HeaderText = "outstanding_settlement"
        cOutstanding_settlement.DataPropertyName = "outstanding_settlement"
        cOutstanding_settlement.Width = 100
        cOutstanding_settlement.Visible = False
        cOutstanding_settlement.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cAdvance_id, cAdvancedetil_line, cDescr, cBudgetdetil_line, cAdvancedetil_type, cBudget_name, cCurrency_id, cBudgetdetil_eps, cBudgetdetil_days, cAcc_id, cChannel_id, cStrukturunit_id, cAmount_advance, cBudget_id, cBudgetdetil_id, cBudgetdetil_name, cAdvancedetil_foreignrate, cAmount_idrreal, cOutstanding_approved, cAdvance_isrequest, cAdvance_requestid, cAdvance_requestid_line, cAmount_settlement, cPph_persen_settlement, cPpn_persen_settlement, cAmount_discount_settlement, cAmount_intercompany_settlement, cAmount_settlement_nettforeign, cAmount_settlement_nett, cAmount_settlementreimburseforeign, cAmount_settlementreimburse, cAmount_settlementrefundforeign, cAmount_settlementrefund, cSettlement_id, cUsername, cSettlement_rate, cSettlement_foreign, cAdvance_isreimburse, cAdvance_reimburseid, cAdvancedetil_fromsettlement, cAdvancedetil_discount, cPph_persen, cPpn_persen, cAmount_subtotalforeign, cAmount_subtotal, cFaktur_id, cAmount_intercompany, cOutstanding_settlement})



        ' DgvTrnAdvance Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvTrnOrderdetileps(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnOrderdetileps Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_checked As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrderdetiluse_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_actual As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_actualnote As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 80
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "Use Line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 50
        cOrderdetiluse_line.Visible = True
        cOrderdetiluse_line.ReadOnly = False

        cOrderdetiluse_checked.Name = "orderdetiluse_checked"
        cOrderdetiluse_checked.HeaderText = "Use"
        cOrderdetiluse_checked.DataPropertyName = "orderdetiluse_checked"
        cOrderdetiluse_checked.Width = 40
        cOrderdetiluse_checked.Visible = True
        cOrderdetiluse_checked.ReadOnly = False

        cOrderdetiluse_eps.Name = "orderdetiluse_eps"
        cOrderdetiluse_eps.HeaderText = "Eps."
        cOrderdetiluse_eps.DataPropertyName = "orderdetiluse_eps"
        cOrderdetiluse_eps.Width = 50
        cOrderdetiluse_eps.Visible = True
        cOrderdetiluse_eps.ReadOnly = False

        cOrderdetiluse_descr.Name = "orderdetiluse_descr"
        cOrderdetiluse_descr.HeaderText = "Descr"
        cOrderdetiluse_descr.DataPropertyName = "orderdetiluse_descr"
        cOrderdetiluse_descr.Width = 125
        cOrderdetiluse_descr.Visible = True
        cOrderdetiluse_descr.ReadOnly = False

        cOrderdetiluse_qty.Name = "orderdetiluse_qty"
        cOrderdetiluse_qty.HeaderText = "Qty"
        cOrderdetiluse_qty.DataPropertyName = "orderdetiluse_qty"
        cOrderdetiluse_qty.Width = 75
        cOrderdetiluse_qty.Visible = True
        cOrderdetiluse_qty.ReadOnly = False

        cOrderdetiluse_idr.Name = "orderdetiluse_idr"
        cOrderdetiluse_idr.HeaderText = "IDR"
        cOrderdetiluse_idr.DataPropertyName = "orderdetiluse_idr"
        cOrderdetiluse_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_idr.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetiluse_idr.Width = 70
        cOrderdetiluse_idr.Visible = True
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

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, cOrderdetil_line, cOrderdetiluse_line, cOrderdetiluse_checked, cOrderdetiluse_eps, cOrderdetiluse_descr, cOrderdetiluse_qty, cOrderdetiluse_idr, cOrderdetiluse_actual, cOrderdetiluse_actualnote, cChannel_id})



        ' DgvTrnOrderdetileps Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

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
        Me.DgvTrnOrderdetiluse.Dock = DockStyle.Fill
        Me.DgvTrnOrderPaymReq.Dock = DockStyle.Fill
        Me.DgvTrnRequestdetil.Dock = DockStyle.Fill

        Me.FormatDgvTrnOrder(Me.DgvTrnOrder)
        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
        Me.FormatDgvTrnOrderdetiluse(Me.DgvTrnOrderdetiluse)
        Me.FormatDgvTrnOrderpaymreq(Me.DgvTrnOrderPaymReq)
        Me.FormatDgvTrnRentalReq(Me.DgvTrnRequestdetil)
        Me.FormatDgvTrnTerimajasa(Me.dgvTrnBPJ)
        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.Gainsboro
        Next
        Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.White

        'Set Form as ReadOnly when parameter _FORMMODE = "VIEW"
        If Me._FORMMODE = "VIEW" Then
            Me.uiTrnRentalOrder3_SetViewOnly()
        End If

        'If Me._PROGRAMTYPE = "NP" Then
        '    'Dim componen As Control
        '    'For Each componen In Me.PnlDataMaster3.Controls
        '    'Next
        '    Me.PnlDataMaster3.Enabled = False
        'Else
        '    Me.PnlDataMaster3.Enabled = True
        'End If
        Me.btnApp.Text = "Approve"
        MyBase.ToolStrip1.Items.Add(Me.btnApp)
    End Function
    Private Sub Approve(ByVal value As Int16)
        Select Case value
            Case 0
                Me.app = Approves.Approved
                Me.btnApp.Text = "Approve"
            Case 1
                Me.app = Approves.DisApprove
                Me.btnApp.Text = "Disapprove"
            Case 2
                Me.app = Approves.Approved
                Me.btnApp.Text = "Approve"
        End Select
    End Sub
    Private Function BindingStop() As Boolean
        'stop binding
        'Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Order_id.DataBindings.Clear()
        Me.dtp_order_date.DataBindings.Clear()
        Me.obj_Order_descr.DataBindings.Clear()
        Me.obj_Request_id.DataBindings.Clear()
        ' Me.obj_Order_eps.DataBindings.Clear()
        'Me.obj_Order_jumeps.DataBindings.Clear()
        Me.dtp_Order_setdate.DataBindings.Clear()
        Me.mtb_Order_settime.DataBindings.Clear()
        Me.obj_Order_setlocation.DataBindings.Clear()
        Me.dtp_Order_utilizeddatestart.DataBindings.Clear()
        Me.dtp_Order_utilizeddateend.DataBindings.Clear()
        Me.mtb_Order_utilizedtimestart.DataBindings.Clear()
        Me.mtb_Order_utilizedtimeend.DataBindings.Clear()
        Me.obj_Order_utilizedlocation.DataBindings.Clear()
        Me.obj_Order_pph_percent.DataBindings.Clear()
        Me.obj_Order_ppn_percent.DataBindings.Clear()
        'Me.obj_Order_insurancecost.DataBindings.Clear()
        'Me.obj_Order_transportationcost.DataBindings.Clear()
        'Me.obj_Order_operatorcost.DataBindings.Clear()
        'Me.obj_Order_othercost.DataBindings.Clear()
        Me.obj_Order_authname.DataBindings.Clear()
        Me.obj_Order_authposition.DataBindings.Clear()
        Me.obj_Order_authname2.DataBindings.Clear()
        Me.obj_Order_authposition2.DataBindings.Clear()
        Me.chk_Order_canceled.DataBindings.Clear()
        Me.obj_Order_createby.DataBindings.Clear()
        Me.obj_Order_createdate.DataBindings.Clear()
        Me.obj_Order_modifyby.DataBindings.Clear()
        Me.obj_Order_modifydate.DataBindings.Clear()
        Me.obj_Order_discount.DataBindings.Clear()
        'Me.calc_Order_discount.DataBindings.Clear()
        'Me.obj_Order_source.DataBindings.Clear()
        'Me.obj_Ordertype_id.DataBindings.Clear()

        Me.obj_Order_spkdesc.DataBindings.Clear()
        Me.obj_Order_spkworktype.DataBindings.Clear()
        Me.obj_Order_spkrequired.DataBindings.Clear()

        Me.obj_Order_revno.DataBindings.Clear()
        Me.dtp_order_revdate.DataBindings.Clear()
        Me.obj_order_revdesc.DataBindings.Clear()

        Me.obj_Budget_id.DataBindings.Clear()
        Me.obj_Rekanan_id.DataBindings.Clear()
        'Me.obj_Old_program_id.DataBindings.Clear()
        Me.obj_Order_prognm.DataBindings.Clear()

        Me.cbo_Deptname.DataBindings.Clear()
        Me.cbo_Periode_id.DataBindings.Clear()
        Me.cbo_Budget_name.DataBindings.Clear()
        Me.cbo_Rekanan_name.DataBindings.Clear()
        'Me.cbo_Old_program_name.DataBindings.Clear()
        Me.cbo_Order_progsch.DataBindings.Clear()
        Me.cbo_Currency.DataBindings.Clear()

        Me.obj_Order_epsstart.DataBindings.Clear()
        Me.obj_Order_epsend.DataBindings.Clear()
        Me.chkApproved.DataBindings.Clear()
        Me.cboSearchStatus.DataBindings.Clear()
        Return True
    End Function
    Private Function BindingStart() As Boolean
        'start binding
        'Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "channel_id"))
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_id"))
        Me.dtp_order_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_date"))
        Me.obj_Order_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_descr"))
        Me.obj_Request_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "request_id"))
        'Me.obj_Order_eps.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_eps"))
        'Me.obj_Order_jumeps.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_episodenum"))
        Me.dtp_Order_setdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_setdate"))
        Me.mtb_Order_settime.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_settime"))
        Me.obj_Order_setlocation.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_setlocation"))
        Me.dtp_Order_utilizeddatestart.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizeddatestart"))
        Me.dtp_Order_utilizeddateend.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizeddateend"))
        Me.mtb_Order_utilizedtimestart.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizedtimestart"))
        Me.mtb_Order_utilizedtimeend.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizedtimeend"))
        Me.obj_Order_utilizedlocation.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizedlocation"))
        Me.obj_Order_pph_percent.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_pph_percent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_ppn_percent.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_ppn_percent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Order_insurancecost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_insurancecost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Order_transportationcost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_transportationcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Order_operatorcost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_operatorcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Order_othercost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_othercost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Order_authname.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authname"))
        Me.obj_Order_authposition.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authposition"))
        Me.obj_Order_authname2.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authname2"))
        Me.obj_Order_authposition2.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authposition2"))

        Me.chk_Order_canceled.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_canceled"))
        Me.obj_Order_createby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_createby"))
        Me.obj_Order_createdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_createdate"))
        Me.obj_Order_modifyby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_modifyby"))
        Me.obj_Order_modifydate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_modifydate"))
        Me.obj_Order_discount.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_discount", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.calc_Order_discount.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_discount", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Order_source.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_source"))
        'Me.obj_Ordertype_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "ordertype_id"))

        Me.obj_Order_spkdesc.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_spkdesc"))
        Me.obj_Order_spkworktype.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_spkworktype"))
        Me.obj_Order_spkrequired.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_spkrequired"))

        Me.obj_Order_revno.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revno"))
        Me.dtp_order_revdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revdate"))
        Me.obj_order_revdesc.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revdesc"))

        Me.obj_Budget_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "budget_id"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "rekanan_id"))
        'Me.obj_Old_program_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "old_program_id"))
        Me.obj_Order_prognm.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_prognm"))

        Me.cbo_Deptname.DataBindings.Add(New Binding("selectedValue", Me.tbl_TrnOrder_Temp, "strukturunit_id"))
        Me.cbo_Periode_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "periode_id"))
        Me.cbo_Budget_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "budget_id"))
        Me.cbo_Rekanan_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "rekanan_id"))
        'Me.cbo_Old_program_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "old_program_id"))
        Me.cbo_Order_progsch.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_progsch"))
        Me.cbo_Currency.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "currency_id"))

        Me.obj_Order_epsstart.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_epsstart", True, DataSourceUpdateMode.OnPropertyChanged, 0))
        Me.obj_Order_epsend.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_epsend", True, DataSourceUpdateMode.OnPropertyChanged, 0))

        Me.cboSearchStatus.DataBindings.Add(New Binding("Enabled", Me.chkSrchStatus, "Checked"))
        Me.chkApproved.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_approved"))
        Return True
    End Function
#End Region

#Region " Dialoged Control "

    Private Function uiTrnRentalOrder3_GetOrderSource() As Boolean
        Dim dlgRequest As New dlgGetRequest(Me.DSN)
      
        Try
            Select Case Me._PROGRAMTYPE
                Case "PG"
                    Dim i As Integer
                    Me.tbl_RequestSelect.Clear()
                    'Me.DataFill(Me.tbl_RequestSelect, "pr_TrnRequest_Select", "jurnaltype_id = 'RQ' AND request_ordered=0 AND request_programtype='" & Me._PROGRAMTYPE & "'")
                    Me.DataFill(Me.tbl_RequestSelect, "pr_TrnRequest_Select", "jurnaltype_id = 'RQ' AND request_programtype='" & Me._PROGRAMTYPE & _
                                "' AND requestdetil_ordered = 0  AND requestdetil_approvedbma = 1 AND requestdetil_canceled = 0 AND transaksi_requestdetil.rekanan_id <> 0 and transaksi_request.request_canceled = 0")

                    With dlgRequest
                        .tbl_RequestSelect = Me.tbl_RequestSelect
                        .ProgType = Me._PROGRAMTYPE
                        .dgvRequestList.DataSource = Me.tbl_RequestSelect
                        .ShowDialog()

                        If .chk_rekanan.Checked = True Or .chk_request_id.Checked = True Then
                            Me.tbl_RequestSelect = .tbl_RequestSelect
                            .dgvRequestList.DataSource = Me.tbl_RequestSelect
                        End If
                        If .DialogResult = DialogResult.OK Then
                            'If Me.cbo_Rekanan_name.SelectedValue <> 0 Then
                            '    If Me.CheckBedaVendor() = False Then
                            '        MsgBox("Vendor can't be different.", MsgBoxStyle.Exclamation)

                            '        Exit Function
                            '    End If
                            'End If

                            'If CheckCurrencyDetil() = False Then
                            '    MsgBox("currency on detail order can't be different", MsgBoxStyle.Exclamation)

                            '    Exit Function
                            'End If
                            'Me.DgvTrnRentalReq.Columns("requestdetil_ordered").Visible = False

                            Dim reqIndex As Integer = .dgvRequestList.CurrentRow.Index

                            With .dgvRequestList
                                Me.obj_Request_id.Text = .Item("request_id", reqIndex).Value
                                Me.cbo_Currency.SelectedValue = .Item("currency_id", reqIndex).Value
                                Me.obj_Budget_id.Text = .Item("budget_id", reqIndex).Value

                                Me.cbo_Budget_name.SelectedValue = .Item("budget_id", reqIndex).Value

                                Me.obj_Order_prognm.Text = .Item("budget_name", reqIndex).Value

                                Me.obj_Order_epsstart.Text = .Item("request_epsstart", reqIndex).Value
                                Me.obj_Order_epsend.Text = .Item("request_epsend", reqIndex).Value

                                Me.cbo_Deptname.SelectedValue = .Item("strukturunit_id", reqIndex).Value
                                Me.obj_Rekanan_id.Text = .Item("rekanan_id", reqIndex).Value
                                Me.cbo_Rekanan_name.SelectedValue = .Item("rekanan_id", reqIndex).Value

                                Me.dtp_Order_setdate.Value = clsUtil.IsDbNull(.Item("request_preparedt", reqIndex).Value, Now)
                                Me.mtb_Order_settime.Text = clsUtil.IsDbNull(Format(.Item("request_preparedt", reqIndex).Value, "HH:mm"), "")

                                Me.dtp_Order_utilizeddatestart.Value = clsUtil.IsDbNull(.Item("request_useddt", reqIndex).Value, Now)
                                Me.mtb_Order_utilizedtimestart.Text = clsUtil.IsDbNull(Format(.Item("request_useddt", reqIndex).Value, "HH:mm"), "")

                                Me.dtp_Order_utilizeddateend.Value = clsUtil.IsDbNull(.Item("request_useddt2", reqIndex).Value, Now)
                                Me.mtb_Order_utilizedtimeend.Text = clsUtil.IsDbNull(Format(.Item("request_useddt2", reqIndex).Value, "HH:mm"), "")

                                Me.obj_Order_setlocation.Text = clsUtil.IsDbNull(.Item("request_prepareloc", reqIndex).Value, "")
                                Me.obj_Order_utilizedlocation.Text = clsUtil.IsDbNull(.Item("request_usedloc", reqIndex).Value, "")

                                Me.obj_Order_descr.Text = clsUtil.IsDbNull(.Item("request_descr", reqIndex).Value, "") & vbCrLf & _
                                                            clsUtil.IsDbNull(.Item("request_descrproc", reqIndex).Value, "")
                                Me.cbo_Currency.SelectedValue = .Item("currency_id", reqIndex).Value
                            End With

                            Dim reqid As String = .dgvRequestList.Item("request_id", reqIndex).Value
                            Dim sift As String = " requestdetil_ordered=0 AND requestdetil_approvedbma = 1 AND requestdetil_canceled = 0 AND rekanan_id = " & Me.obj_Rekanan_id.Text & " AND request_id = '" & reqid & "'"
                            'Dim sift_eps As String = "request_id = '" & reqid & "'"


                            Me.tbl_RequestdetilSelect.Clear()
                            Me.DataFill(Me.tbl_RequestdetilSelect, "pr_TrnRequestdetil_Select", sift)



                            Me.DgvTrnRequestdetil.DataSource = Me.tbl_RequestdetilSelect

                            If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
                                For i = 0 To Me.tbl_RequestdetilSelect.Rows.Count - 1
                                    Me.tbl_RequestdetilSelect.Rows(i).Item("requestdetil_ordered") = 1
                                    Me.tbl_TrnOrderdetil.Rows.Add()
                                    If Me.tbl_RequestdetilSelect.Rows(i).Item("item_id").ToString <> "" Then
                                        Me.uiTrnRentalOrder3_SetItemDetil(i, i, Format(Me.dtp_Order_setdate.Value, "dd/MM/yyyy"), Format(Me.dtp_Order_utilizeddateend.Value, "dd/MM/yyyy")) ''''Format(Me.dtp_Order_utilizeddatestart.Value, "dd/MM/yyyy"), Format(Me.dtp_Order_utilizeddateend.Value, "dd/MM/yyyy"))

                                    Else
                                        Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_type") = "Descr"
                                    End If
                                Next
                            End If

                            ' Set detil Episode---========================================================================
                            Try
                                Dim a As Integer = 0
                                Dim b As Integer = 0
                                Dim c As Integer = 0

                                Dim eps_end As Integer = Me.obj_Order_epsend.Text

                                Dim tbl_RequestdetilEps_temp As DataTable = New DataTable
                                Dim tbl_OrderdetilEps_temp As DataTable = clsDataset2.CreateTblTrnOrderdetileps

                                Me.tbl_RequestdetilEps.Clear()
                                Me.tbl_TrnOrderdetileps.Clear()

                                For a = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                                    Dim sift_eps As String = "request_id = '" & Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_requestid_ref") & "' AND requestdetil_line = '" & Me.tbl_TrnOrderdetil.Rows(a).Item("requestdetil_line") & "'"
                                    tbl_RequestdetilEps_temp.Clear()
                                    tbl_OrderdetilEps_temp.Clear()
                                    Me.DataFill(tbl_RequestdetilEps_temp, "pr_TrnRequestdetil_SelectEps", sift_eps)
                                    b = 0
                                    Dim eps_start As Integer = Me.obj_Order_epsstart.Text
                                    Dim row_eps As Integer = (eps_end - eps_start)
                                    For c = 0 To row_eps
                                        Me.tbl_TrnOrderdetileps.Rows.Add()

                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetil_line") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_line")
                                        'tbl_OrderdetilEps_temp.Rows(b).Item("orderdetiluse_line") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_line")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_eps") = eps_start
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_descr") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_descr")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_qty") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_qty")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_idr") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_foreign")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_actual") = 0
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_actualnote") = 0
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("channel_id") = Me._CHANNEL

                                        If b < tbl_RequestdetilEps_temp.Rows.Count Then
                                            If Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_eps") = tbl_RequestdetilEps_temp.Rows(b).Item("requestdetil_eps") Then
                                                Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_checked") = 1
                                                b += 1
                                            Else
                                                Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_checked") = 0
                                            End If
                                        End If
                                        eps_start += 1
                                    Next

                                    ' Me.tbl_TrnOrderdetileps.Rows.Add()
                                    ' Me.tbl_TrnOrderdetileps.Merge(tbl_OrderdetilEps_temp)
                                    ' Me.tbl_TrnOrderdetileps.Merge(tbl_OrderdetilEps_temp)
                                Next

                            Catch ex As Exception
                                MessageBox.Show("Error occured when trying to get episode. " & ex.Message)
                            End Try

                            Me.FormatDgvTrnOrderdetileps(Me.DgvEpisode)
                            Me.DgvEpisode.DataSource = Me.tbl_TrnOrderdetileps
                            Me._ORDER_SOURCE = "RQ"
                            Me.cbo_Rekanan_name.Enabled = False
                            Me.cbo_Budget_name.Enabled = False
                            Me.obj_Budget_id.Enabled = False
                        Else
                            'Me._ORDER_SOURCE = "ML"
                            Me.cbo_Rekanan_name.Enabled = True
                            Me.cbo_Budget_name.Enabled = True
                            Me.obj_Budget_id.Enabled = True

                        End If
                    End With

                Case "NP"
                    Dim i, j, k As Integer

                    If Me.ReservedItem = False Then
                        Me.tbl_RequestdetilSelect.Clear()
                        Me.DataFill(Me.tbl_RequestdetilSelect, "pr_TrnRequestHD_Select", " jurnaltype_id = 'RQ' AND request_programtype='" & Me._PROGRAMTYPE & _
                        "' AND requestdetil_ordered=0  AND requestdetil_approvedbma = 1 AND requestdetil_canceled = 0 AND transaksi_requestdetil.rekanan_id <> 0 and transaksi_request.request_canceled = 0")
                        Me.tbl_RequestdetilSelect.DefaultView.RowFilter = Nothing
                    Else
                        Me.tbl_RequestdetilSelect.DefaultView.RowFilter = "requestdetil_selected=0"
                        Me.ReservedItem = False
                    End If

                    With dlgRequest
                        .tbl_RequestDetilSelect = Me.tbl_RequestdetilSelect
                        .ProgType = Me._PROGRAMTYPE
                        .dgvRequestList.DataSource = Me.tbl_RequestdetilSelect
                        .ShowDialog()

                        If .chk_rekanan.Checked = True Or .chk_request_id.Checked = True Then
                            Me.tbl_RequestdetilSelect = .tbl_RequestDetilSelect
                            .dgvRequestList.DataSource = Me.tbl_RequestdetilSelect
                        End If

                        If .DialogResult = DialogResult.OK Then
                            If Me.cbo_Rekanan_name.SelectedValue <> 0 Then
                                If Me.CheckBedaVendor() = False Then
                                    MsgBox("Vendor can't be different.", MsgBoxStyle.Exclamation)

                                    Exit Function
                                End If
                            End If

                            If CheckCurrencyDetil() = False Then
                                MsgBox("currency on detail order can't be different", MsgBoxStyle.Exclamation)

                                Exit Function
                            End If

                            Dim deptname, rekanan, budget, currency As Integer
                            Dim orderdescr, setdate, settime, usedate1, usetime1, usedate2, usetime2, req_id, order_epsstart, order_epsend As String
                            setdate = ""
                            settime = ""
                            usedate1 = ""
                            usetime1 = ""
                            usedate2 = ""
                            usetime2 = ""
                            orderdescr = ""

                            Try
                                'iterasi untuk ubah nilai selected = ordered
                                Dim count As Integer = 0

                                For i = 0 To Me.tbl_RequestdetilSelect.Rows.Count - 1
                                    If Me.tbl_RequestdetilSelect.Rows(i).Item("requestdetil_ordered") = True Then
                                        Me.tbl_RequestdetilSelect.Rows(i).Item("requestdetil_selected") = 1

                                        deptname = tbl_RequestdetilSelect.Rows(i).Item("strukturunit_id")
                                        rekanan = tbl_RequestdetilSelect.Rows(i).Item("rekanan_id")
                                        budget = tbl_RequestdetilSelect.Rows(i).Item("budget_id")
                                        req_id = tbl_RequestdetilSelect.Rows(i).Item("request_id")

                                        setdate = tbl_RequestdetilSelect.Rows(i).Item("request_preparedt")
                                        settime = clsUtil.IsDbNull(Format(tbl_RequestdetilSelect.Rows(i).Item("request_preparedt"), "HH:mm"), "")

                                        usedate1 = tbl_RequestdetilSelect.Rows(i).Item("request_useddt")
                                        usetime1 = clsUtil.IsDbNull(Format(tbl_RequestdetilSelect.Rows(i).Item("request_useddt"), "HH:mm"), "")

                                        usedate2 = tbl_RequestdetilSelect.Rows(i).Item("request_useddt2")
                                        usetime2 = clsUtil.IsDbNull(Format(tbl_RequestdetilSelect.Rows(i).Item("request_useddt2"), "HH:mm"), "")

                                        orderdescr = tbl_RequestdetilSelect.Rows(i).Item("request_descr") & vbCrLf & _
                                                            tbl_RequestdetilSelect.Rows(i).Item("request_descrproc")
                                        currency = tbl_RequestdetilSelect.Rows(i).Item("currency_id")

                                        ' order_epsstart = tbl_RequestdetilSelect.Rows(i).Item("request_epsstart")
                                        ' order_epsend = tbl_RequestdetilSelect.Rows(i).Item("request_epsend")

                                        count += 1
                                    End If
                                Next

                                If count = 0 Then
                                    Exit Function
                                End If

                                Me.DgvTrnRequestdetil.DataSource = Me.tbl_RequestdetilSelect
                                Me.tbl_RequestdetilSelect.DefaultView.RowFilter = "requestdetil_ordered=1"

                                Dim reqIndex As Integer = 0

                                'Pull request header to order header
                                Me.cbo_Deptname.SelectedValue = deptname
                                Me.obj_Rekanan_id.Text = rekanan
                                Me.cbo_Rekanan_name.SelectedValue = rekanan
                                Me.obj_Budget_id.Text = budget
                                Me.cbo_Budget_name.SelectedValue = budget
                                Me.cbo_Currency.SelectedValue = currency
                                Me.dtp_Order_setdate.Text = setdate
                                Me.mtb_Order_settime.Text = settime

                                Me.dtp_Order_utilizeddatestart.Text = usedate1
                                Me.mtb_Order_utilizedtimestart.Text = usetime1

                                Me.dtp_Order_utilizeddateend.Text = usedate2
                                Me.mtb_Order_utilizedtimeend.Text = usetime2

                                Me.obj_Order_descr.Text = orderdescr

                                Me.obj_Order_epsstart.Text = 1
                                Me.obj_Order_epsend.Text = 1

                                'Pull request detil to order detil
                                Dim newitem As Boolean
                                For i = 0 To Me.DgvTrnRequestdetil.Rows.Count - 1
                                    Dim xbudget_id As Integer = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(i).Cells("budget_id").Value, 0)
                                    Dim xrequest_id As String = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(i).Cells("request_id").Value, "")

                                    If Me.obj_Request_id.Text = "" Then
                                        Me.obj_Request_id.Text = xrequest_id
                                    Else
                                        If InStr(Me.obj_Request_id.Text, xrequest_id, CompareMethod.Text) = 0 Then _
                                        Me.obj_Request_id.Text = Me.obj_Request_id.Text + ", " + xrequest_id
                                    End If

                                    newitem = True
                                    If Me.tbl_TrnOrderdetil.Rows.Count = 0 Then
                                        Me.tbl_TrnOrderdetil.Rows.Add()
                                        Me.uiTrnRentalOrder3_SetItemDetil(i, i, Me.dtp_Order_utilizeddatestart.Value, Me.dtp_Order_utilizeddateend.Value)
                                    Else
                                        For j = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                                            Try
                                                'Dim cunit_id As Integer = clsUtil.IsDbNull(Me.tbl_TrnOrderdetil.Rows(j).Item("unit_id"), 0)
                                                Dim cbudget_id As Integer = clsUtil.IsDbNull(Me.tbl_TrnOrderdetil.Rows(j).Item("budget_id"), 0)
                                                'Dim crequest_id As String = clsUtil.IsDbNull(Me.tbl_TrnOrderdetil.Rows(j).Item("orderdetil_requestid_ref"), "")
                                                'Dim corderdetil_descr As String = clsUtil.IsDbNull(Me.tbl_TrnOrderdetil.Rows(j).Item("orderdetil_descr"), "")

                                                Dim item_added As Boolean = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(i).Cells("requestdetil_added").Value, 0)

                                                If xbudget_id <> cbudget_id Then
                                                    Me.obj_Budget_id.Text = "0"
                                                    Me.cbo_Budget_name.SelectedValue = 0
                                                End If

                                                'If xrequest_id <> crequest_id Then Me.obj_Request_id.Text = "MultiRequest"

                                                'no longer used, same items are not merge anymore -- irhantoro (December 2009)
                                                'If Me.DgvTrnRentalReq.Rows(i).Cells("item_id").Value = Me.tbl_TrnOrderdetil.Rows(j).Item("item_id") _
                                                '    And xunit_id = cunit_id And xrequestdetil_descr = corderdetil_descr Then
                                                '    newitem = False
                                                '    If item_added = False Then
                                                '        Me.tbl_TrnOrderdetil.Rows(j).Item("orderdetil_qty") += Me.DgvTrnRentalReq.Rows(i).Cells("requestdetil_qty").Value
                                                '    End If
                                                'End If

                                            Catch ex As Exception
                                                MessageBox.Show(ex.Message)
                                            End Try
                                        Next

                                        If newitem Then
                                            Me.tbl_TrnOrderdetil.Rows.Add()
                                            k = Me.tbl_TrnOrderdetil.Rows.Count - 1
                                            Me.uiTrnRentalOrder3_SetItemDetil(k, i, Me.dtp_Order_setdate.Value, Me.dtp_Order_utilizeddateend.Value) ''''Me.dtp_Order_utilizeddatestart.Value, Me.dtp_Order_utilizeddateend.Value)

                                        End If
                                    End If
                                    Me.DgvTrnRequestdetil.Rows(i).Cells("requestdetil_added").Value = True
                                Next



                                Me._ORDER_SOURCE = "RQ"
                                Me.cbo_Rekanan_name.Enabled = False
                                Me.obj_Budget_id.Enabled = False
                                Me.cbo_Budget_name.Enabled = False
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try


                            ' Set detil Episode---========================================================================
                            Try
                                Dim a As Integer = 0
                                Dim b As Integer = 0
                                Dim c As Integer = 0

                                Dim eps_end As Integer = Me.obj_Order_epsend.Text

                                Dim tbl_RequestdetilEps_temp As DataTable = New DataTable
                                Dim tbl_OrderdetilEps_temp As DataTable = clsDataset2.CreateTblTrnOrderdetileps

                                Me.tbl_RequestdetilEps.Clear()
                                Me.tbl_TrnOrderdetileps.Clear()

                                For a = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                                    Dim sift_eps As String = "request_id = '" & Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_requestid_ref") & "' AND requestdetil_line = '" & Me.tbl_TrnOrderdetil.Rows(a).Item("requestdetil_line") & "'"
                                    tbl_RequestdetilEps_temp.Clear()
                                    tbl_OrderdetilEps_temp.Clear()
                                    Me.DataFill(tbl_RequestdetilEps_temp, "pr_TrnRequestdetil_SelectEps", sift_eps)
                                    b = 0
                                    Dim eps_start As Integer = Me.obj_Order_epsstart.Text
                                    Dim row_eps As Integer = (eps_end - eps_start)
                                    For c = 0 To row_eps
                                        Me.tbl_TrnOrderdetileps.Rows.Add()

                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetil_line") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_line")
                                        'tbl_OrderdetilEps_temp.Rows(b).Item("orderdetiluse_line") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_line")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_eps") = eps_start
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_descr") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_descr")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_qty") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_qty")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_idr") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_foreign")
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_actual") = 0
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_actualnote") = 0
                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("channel_id") = Me._CHANNEL

                                        If b < tbl_RequestdetilEps_temp.Rows.Count Then
                                            If Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_eps") = tbl_RequestdetilEps_temp.Rows(b).Item("requestdetil_eps") Then
                                                Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_checked") = 1
                                                b += 1
                                            Else
                                                Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetiluse_checked") = 0
                                            End If
                                        End If
                                        eps_start += 1
                                    Next

                                    ' Me.tbl_TrnOrderdetileps.Rows.Add()
                                    ' Me.tbl_TrnOrderdetileps.Merge(tbl_OrderdetilEps_temp)
                                    ' Me.tbl_TrnOrderdetileps.Merge(tbl_OrderdetilEps_temp)
                                Next

                            Catch ex As Exception
                                MessageBox.Show("Error occured when trying to get episode. " & ex.Message)
                            End Try

                            Me.FormatDgvTrnOrderdetileps(Me.DgvEpisode)
                            Me.DgvEpisode.DataSource = Me.tbl_TrnOrderdetileps


                        Else
                            'Me._ORDER_SOURCE = "ML"
                            Me.cbo_Rekanan_name.Enabled = True
                            Me.obj_Budget_id.Enabled = True
                            Me.cbo_Budget_name.Enabled = True
                            'tbl_RequestdetilSelect.DefaultView.RowFilter = "requestdetil_ordered=1"
                        End If
                    End With

            End Select

            Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
            Me.FormatDgvTrnOrderdetiluse(Me.DgvTrnOrderdetiluse)
            'Me.IsiBudgetName()
            'Me.CekCurrencyDetil()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Function CheckCurrencyDetil() As Boolean
        Dim rows() As DataRow = Me.tbl_RequestdetilSelect.Select("requestdetil_ordered = 1")
        Dim rowsj() As DataRow = Me.tbl_TrnOrderdetil.Select("orderdetil_type = 'Item'")
        Dim currency_id As String
        Dim curtemp As String

        For Each row As DataRow In rows
            currency_id = row.Item("currency_id")

            For Each rowj As DataRow In rowsj
                curtemp = rowj.Item("currency_id")

                If currency_id <> curtemp Then
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    Private Function CheckBedaVendor() As Boolean
        Dim rows() As DataRow = Me.tbl_RequestdetilSelect.Select("requestdetil_ordered = 1")
        Dim rekanan_id As String

        For i As Integer = 0 To rows.Length - 1
            rekanan_id = rows(i).Item("rekanan_id")

            If rekanan_id <> Me.obj_Rekanan_id.Text Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Function uiTrnRentalOrder3_SetItemDetil(ByVal rowidx_a As Integer, ByVal rowidx As Integer, ByVal utilizeddate_start As Date, ByVal utilizeddate_end As Date) As Boolean
        Try
            'Note perhitungan total incl disc RO berbeda dengan PO  cek store pr_trnordetil2_select-------------
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_type") = "Item"
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("unit_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("unit_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("item_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("item_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_days") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_days").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("currency_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("currency_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreignrate") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_descr") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_descr").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_qty") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value
            'Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreign") = Math.Round(clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 0), MidpointRounding.AwayFromZero)
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreign") = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 0)

            'If Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("currency_id") = 1 Then
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_discount") = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0)
            'Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_discountforeign") = Math.Round(Me.DgvTrnRequestdetil.Rows(rowidx_a).Cells("requestdetil_discount").Value, 2, MidpointRounding.AwayFromZero)
            'Else
            'Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_discount") = Math.Round(clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx_a).Cells("requestdetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
            'End If

            '' Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_discount") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("budget_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("budget_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("budgetdetil_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("budgetdetil_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_requestid_ref") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("request_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("requestdetil_line") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_line").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_idr") = Math.Round(clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value * _
                                                                                               Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value, 0), MidpointRounding.AwayFromZero)

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc") = (Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value) * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_days").Value - _
                                                                                           (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0))
            'Math.Round(clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx_a).Cells("requestdetil_discount").Value, 0), MidpointRounding.AwayFromZero)


            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign") = Math.Round(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value * _
                                                                                     Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_days").Value * _
                                                                                     Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 2, MidpointRounding.AwayFromZero)


            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc") = Math.Round(Math.Round(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value * _
                                                                                               Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_days").Value * _
                                                                                              Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 2, MidpointRounding.AwayFromZero) - _
                                                                                              (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0)))


            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr") = Math.Round(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value * _
                                                                                 Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_days").Value * _
                                                                                  Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value * _
                                                                                  Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value, MidpointRounding.AwayFromZero)

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_pph") = Math.Round(Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_pphpercent") * 0.01 * Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc"), MidpointRounding.AwayFromZero)
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_ppn") = Math.Round(Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_ppnpercent") * 0.01 * Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc"), MidpointRounding.AwayFromZero)

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_pphforeign") = Math.Round(Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_pphpercent") * 0.01 * Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc"), 2, MidpointRounding.AwayFromZero)
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_ppnforeign") = Math.Round(Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_ppnpercent") * 0.01 * Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc"), 2, MidpointRounding.AwayFromZero)

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incltax") = Math.Round(Math.Round(Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc") - _
                                                                                                 Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_pphpercent") * 0.01 * _
                                                                                                 Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc"), 2) + _
                                                                                                 Math.Round(Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_ppnpercent") * 0.01 * _
                                                                                                 Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc"), 2), 2)

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incltax") = Math.Round((Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc") - _
                                                                                                 Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_pphpercent") * 0.01 * _
                                                                                                 Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc")) + _
                                                                                                 (Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_ppnpercent") * 0.01 * _
                                                                                                 Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc")), MidpointRounding.AwayFromZero)
            'Note perhitungan total incl disc RO berbeda dengan PO  cek store pr_trnordetil2_select---------------------------
        Catch ex As Exception
            MessageBox.Show("Error occured when trying to get requested items. " & ex.Message)
        End Try
        'CASE LEFT(order_id,2) WHEN 'RO' THEN 
        '                    (CEILING(ISNULL(dbo.transaksi_orderdetil.orderdetil_foreignrate, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) 
        '                    * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1) * ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0) 
        '                    - ISNULL(dbo.transaksi_orderdetil.orderdetil_discount, 0))) ELSE
        '                    (CEILING((ISNULL(dbo.transaksi_orderdetil.orderdetil_foreignrate, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) 
        '                    * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1)) * (ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0) 
        '                    - ISNULL(dbo.transaksi_orderdetil.orderdetil_discount, 0)))) END AS orderdetil_rowtotalidr_incldisc , 

        '                    CASE LEFT(order_id,2) WHEN 'RO' THEN 
        '                    (CEILING(ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) 
        '                    * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1) * ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0))) ELSE
        '                    (ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) 
        '                    * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1) * ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0)) END AS orderdetil_rowtotalforeign, 

        '                    CASE LEFT(order_id,2) WHEN 'RO' THEN 
        '                    (CEILING(ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1) 
        '                    * ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0) - ISNULL(dbo.transaksi_orderdetil.orderdetil_discount, 0))) ELSE
        '                    (ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1)) 
        '                    * (ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0) - ISNULL(dbo.transaksi_orderdetil.orderdetil_discount, 0)) END AS orderdetil_rowtotalforeign_incldisc, 

        '                    CASE LEFT(order_id,2) WHEN 'RO' THEN 
        '                    (CEILING((ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1)) 
        '                    * (ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_foreignrate, 0)))) ELSE
        '                    (CEILING((ISNULL(dbo.transaksi_orderdetil.orderdetil_qty, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_days, 1)) 
        '                    * (ISNULL(dbo.transaksi_orderdetil.orderdetil_foreign, 0) * ISNULL(dbo.transaksi_orderdetil.orderdetil_foreignrate, 0)))) END AS orderdetil_rowtotalidr, 
        Try
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim sift As String

            Dim utilized As Integer = 0
            Dim utilizeddt = utilizeddate_start
            Dim req_id = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("request_id").Value
            Dim reqdetil_line = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_line").Value

            j = Me.tbl_TrnOrderdetiluse.Rows.Count - 1
            If j < 0 Then j = 0
            For i = 0 To (DateDiff(DateInterval.Day, utilizeddate_start, utilizeddate_end)) + 1
                sift = " request_id='" & req_id & "' and requestdetil_line=" & reqdetil_line & " and requestdetiluse_date='" & Format(utilizeddt, "MM/dd/yyyy") & "'"
                Me.tbl_RequestdetilUseSelected.Clear()
                Me.DataFill(Me.tbl_RequestdetilUseSelected, "cq_TrnRequestdetiluse_Select", sift)
                If Me.tbl_RequestdetilUseSelected.Rows.Count > 0 Then utilized = 1 Else utilized = 0

                Me.tbl_TrnOrderdetiluse.Rows.Add()
                Me.uiTrnRentalOrder3_SetDetilUse(j, rowidx_a, utilizeddt, utilized)
                j += 1
                utilizeddt = utilizeddt.AddDays(1)
            Next
        Catch ex As Exception
            MessageBox.Show("Error occured when trying to get utilized date. " & ex.Message)
        End Try


    End Function
    Private Function uiTrnRentalOrder3_SetDetilUse(ByVal utilized_rowidx As Integer, ByVal item_rowidx As Integer, ByVal utilizeddate As Date, ByVal utilized As Integer) As Boolean
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetil_line") = Me.DgvTrnOrderdetil.Rows(item_rowidx).Cells("orderdetil_line").Value
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_checked") = utilized
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_date") = utilizeddate
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_descr") = Me.DgvTrnOrderdetil.Rows(item_rowidx).Cells("orderdetil_descr").Value
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_qty") = Me.DgvTrnOrderdetil.Rows(item_rowidx).Cells("orderdetil_qty").Value
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_idr") = Me.DgvTrnOrderdetil.Rows(item_rowidx).Cells("orderdetil_foreign").Value
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_actual") = 0
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("orderdetiluse_actualnote") = ""
        Me.tbl_TrnOrderdetiluse.Rows(utilized_rowidx).Item("channel_id") = Me._CHANNEL
    End Function


#End Region
#Region " User Defined Function "

    Private Function uiTrnRentalOrder3_NewData() As Boolean
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
        Me.tbl_TrnOrder_Temp.Columns("currency_id").DefaultValue = 1
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
        'Me.tbl_TrnOrder_Temp.Columns("order_pph_percent").DefaultValue = 4.5
        Me.tbl_TrnOrder_Temp.Columns("order_pph_percent").DefaultValue = 2
        Me.tbl_TrnOrder_Temp.Columns("order_ppn_percent").DefaultValue = 10
        Me.tbl_TrnOrder_Temp.Columns("order_insurancecost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_transportationcost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_operatorcost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_othercost").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_authname").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_authposition").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_authname2").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("order_authposition2").DefaultValue = ""
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


        'Set Default Value for tbl_TrnOrderdetil
        Me.tbl_TrnOrderdetil.Clear()
        Me.tbl_TrnOrderdetil = clsDataset2.CreateTblTrnOrderdetil2()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = ""
        Me.tbl_TrnOrderdetil.Columns("orderdetil_type").DefaultValue = "Item"
        Me.tbl_TrnOrderdetil.Columns("orderdetil_qty").DefaultValue = 0
        Me.tbl_TrnOrderdetil.Columns("orderdetil_days").DefaultValue = 0
        Me.tbl_TrnOrderdetil.Columns("unit_id").DefaultValue = 1
        Me.tbl_TrnOrderdetil.Columns("currency_id").DefaultValue = 1
        'Me.tbl_TrnOrderdetil.Columns("orderdetil_pphpercent").DefaultValue = 4.5
        Me.tbl_TrnOrderdetil.Columns("orderdetil_pphpercent").DefaultValue = 2
        Me.tbl_TrnOrderdetil.Columns("orderdetil_ppnpercent").DefaultValue = 10

        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10
        Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderdetil

        'Set Default Value for tbl_TrnOrderdetiluse
        Me.tbl_TrnOrderdetil.Clear()
        Me.tbl_TrnOrderdetiluse = clsDataset2.CreateTblTrnOrderdetiluse()
        Me.tbl_TrnOrderdetiluse.Columns("order_id").DefaultValue = ""
        Me.tbl_TrnOrderdetiluse.Columns("orderdetil_line").DefaultValue = 0
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").DefaultValue = 0
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_checked").DefaultValue = 0
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_date").DefaultValue = Now.Date
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_descr").DefaultValue = ""
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_qty").DefaultValue = 0
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_idr").DefaultValue = 0
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_actual").DefaultValue = 0
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_actualnote").DefaultValue = ""
        Me.tbl_TrnOrderdetiluse.Columns("channel_id").DefaultValue = Me._CHANNEL

        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrement = True
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrementStep = 10
        Me.DgvTrnOrderdetiluse.DataSource = Me.tbl_TrnOrderdetiluse

        'Set Default Value for tbl_TrnOrderPaymReq
        Me.tbl_TrnOrderPaymReq = clsDataset2.CreateTblTrnOrderpaymreq
        Me.tbl_TrnOrderPaymReq.Columns("order_id").DefaultValue = ""
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").DefaultValue = 0
        Me.tbl_TrnOrderPaymReq.Columns("paymentreq_id").DefaultValue = ""
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_descr").DefaultValue = ""
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_amount").DefaultValue = 0
        Me.tbl_TrnOrderPaymReq.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.DgvTrnOrderPaymReq.DataSource = Me.tbl_TrnOrderPaymReq


        'Set Default Value for tbl_TrnOrderdetilEps
        Me.tbl_TrnOrderdetileps.Clear()
        Me.tbl_TrnOrderdetileps = clsDataset2.CreateTblTrnOrderdetileps()
        Me.tbl_TrnOrderdetileps.Columns("order_id").DefaultValue = ""
        Me.tbl_TrnOrderdetileps.Columns("orderdetil_line").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_checked").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_eps").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_descr").DefaultValue = ""
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_qty").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_idr").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_actual").DefaultValue = 0
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_actualnote").DefaultValue = ""
        Me.tbl_TrnOrderdetileps.Columns("channel_id").DefaultValue = Me._CHANNEL

        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").AutoIncrement = True
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").AutoIncrementStep = 10
        Me.DgvEpisode.DataSource = Me.tbl_TrnOrderdetileps

        Me.DgvTrnRequestdetil.DataSource = "" 'Me.tbl_TrnRentalRequest

        Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnOrder_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnRentalOrder3_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""

        txtCondition = " ordertype_id='" & Me._ORDERTYPE_ID & _
                            "' and channel_id='" & Me._CHANNEL & _
                            "' and order_programtype='" & Me._PROGRAMTYPE & "'"

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
            txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.rekananidtxt.Text)
            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Status
        If Me.chkSrchStatus.Checked Then
            Select Case Me.cboSearchStatus.SelectedValue
                Case 0
                    txtSearchCriteria = " order_canceled = 0 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
                Case 1
                    txtSearchCriteria = " order_canceled = 1 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
            End Select
        End If

        If Me.chkSearchApproved.Checked Then
            Select Case Me.cboSearchApproved.SelectedValue
                Case 0
                    txtSearchCriteria = " order_approved = 0 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
                Case 1
                    txtSearchCriteria = " order_approved = 1 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
                Case 2
                    txtSearchCriteria = " order_approved = 2 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If

            End Select
        End If
        criteria = txtCondition

        Me.tbl_TrnOrder.Clear()
        Try
            'Me.DataFill(Me.tbl_TrnOrder, "pr_TrnOrder_Select", criteria)
            Me.DataFillLimit(Me.tbl_TrnOrder, "pr_TrnOrder_Select3", criteria, Me.nudSearchRowLimit.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Not Me.COMBO_ISFILLED Then
            Me.uiTrnRentalOrder3_LoadDataCombo()
        End If

        Me.lblTotalRows.Visible = True
        Me.lblTotalRows.Text = Me.DgvTrnOrder.Rows.Count & " " & "Row(s)"
        uiTrnRentalOrder3_GetOrderCreator()

    End Function
    Private Function uiTrnRentalOrder3_Save() As Boolean
        'save data
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim channel_id As String
        Dim line As Integer
        Dim amount As Decimal
        Dim rowFilter As String
        Dim rows() As DataRow
        Dim j As Integer

        channel_id = Me._CHANNEL

        Dim tbl_TrnOrder_Temp_Changes As DataTable
        Dim tbl_TrnOrderdetil_Changes As DataTable
        Dim tbl_TrnOrderdetiluse_Changes As DataTable
        Dim tbl_TrnOrderpaymreq_Changes As DataTable
        Dim tbl_TrnRequestdetil_Changes As DataTable
        Dim tbl_TrnOrderApproval_Changes As DataTable
        Dim tbl_TrnOrderdetileps_Changes As DataTable
        Dim success As Boolean

        Dim order_id As Object = New Object
        Dim request_id As Object = New Object
        Dim requestdetil_line As Int16

        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(order_id)

        If Me.tbtnSave.Visible = False Then
            MsgBox(" Data cannot be saved because this order is already canceled")
            Exit Function
        End If

        Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
        tbl_TrnOrder_Temp_Changes = Me.tbl_TrnOrder_Temp.GetChanges()

        Me.DgvTrnRequestdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnRequestdetil).EndCurrentEdit()
        tbl_TrnRequestdetil_Changes = Me.tbl_TrnRequestdetil.GetChanges()

        Me.BindingContext(Me.tbl_TrnOrderApproval).EndCurrentEdit()
        tbl_TrnOrderApproval_Changes = Me.tbl_TrnOrderApproval.GetChanges()

        Me.DgvTrnOrderdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
        tbl_TrnOrderdetil_Changes = Me.tbl_TrnOrderdetil.GetChanges()

        Me.DgvTrnOrderPaymReq.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderPaymReq).EndCurrentEdit()
        tbl_TrnOrderpaymreq_Changes = Me.tbl_TrnOrderPaymReq.GetChanges()

        Me.DgvEpisode.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetileps).EndCurrentEdit()
        tbl_TrnOrderdetileps_Changes = Me.tbl_TrnOrderdetileps.GetChanges()

        If tbl_TrnOrderdetil_Changes IsNot Nothing Then
            For i = 0 To tbl_TrnOrderdetil_Changes.Rows.Count - 1
                If tbl_TrnOrderdetil_Changes.Rows(i).RowState <> DataRowState.Deleted Then
                    line = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_line")
                    amount = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign")
                    rowFilter = String.Format("orderdetil_line={0}", line)
                    rows = Me.tbl_TrnOrderdetiluse.Select(rowFilter)
                    For j = 0 To rows.Length - 1
                        rows(j).Item("orderdetiluse_idr") = amount
                    Next
                End If

                '' menghitung amount amount---------------------------------------------------------------------------------------------------------------------------------------------
                'Note perhitungan total incl disc dan days RO berbeda dengan PO  cek store pr_trnordetil2_select--------
                'If Me.tbl_TrnOrderdetil.Rows(i).Item("currency_id") = 1 Then
                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount") = Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount")
                'Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discountforeign") = Math.Round(Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount").Value, 2, MidpointRounding.AwayFromZero)
                'Else
                'Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount") = Math.Round(Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount"), 2, MidpointRounding.AwayFromZero)
                'End If
                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc") = Math.Round((tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreignrate") * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty") * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_days") * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign")) - _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_discount"), MidpointRounding.AwayFromZero)

                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign") = Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty") * _
                                                                                       tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_days") * _
                                                                                       tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign"), 2, MidpointRounding.AwayFromZero)


                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc") = Math.Round(Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty") * _
                                                                                                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_days") * _
                                                                                                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign"), 2, MidpointRounding.AwayFromZero) - _
                                                                                                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_discount"), 2, MidpointRounding.AwayFromZero)


                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr") = Math.Round((tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty") * _
                                                                                   tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_days") * _
                                                                                   tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign") * _
                                                                                   tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreignrate")), MidpointRounding.AwayFromZero)


                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_pph") = Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_pphpercent") * 0.01 * tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc"), MidpointRounding.AwayFromZero)
                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_ppn") = Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_ppnpercent") * 0.01 * tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc"), MidpointRounding.AwayFromZero)

                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_pphforeign") = Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_pphpercent") * 0.01 * tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc"), 2, MidpointRounding.AwayFromZero)
                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_ppnforeign") = Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_ppnpercent") * 0.01 * tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc"), 2, MidpointRounding.AwayFromZero)

                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incltax") = Math.Round(Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc") - _
                                                                                               tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_pphpercent") * 0.01 * _
                                                                                               tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc"), 2) + _
                                                                                               Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_ppnpercent") * 0.01 * _
                                                                                               tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc"), 2, MidpointRounding.AwayFromZero), 2, MidpointRounding.AwayFromZero)

                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incltax") = Math.Round((tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc") - _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_pphpercent") * 0.01 * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc")) + _
                                                                                            Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_ppnpercent") * 0.01 * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc")), MidpointRounding.AwayFromZero)
                'Note perhitungan total incl disc dan days RO berbeda dengan PO  cek store pr_trnordetil2_select                                                                          tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc")), MidpointRounding.AwayFromZero)
                'end---------------------------------------------------------------------------------------------------------------------------------------------                    

            Next
        End If

        Me.DgvTrnOrderdetiluse.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetiluse).EndCurrentEdit()
        tbl_TrnOrderdetiluse_Changes = Me.tbl_TrnOrderdetiluse.GetChanges()

        If tbl_TrnOrder_Temp_Changes IsNot Nothing _
            Or tbl_TrnOrderdetil_Changes IsNot Nothing _
                Or tbl_TrnRequestdetil_Changes IsNot Nothing _
                    Or tbl_TrnOrderdetiluse_Changes IsNot Nothing _
                        Or tbl_TrnOrderpaymreq_Changes IsNot Nothing _
                            Or tbl_TrnOrderdetileps_Changes IsNot Nothing Then

            Try
                MasterDataState = tbl_TrnOrder_Temp.Rows(0).RowState
                order_id = tbl_TrnOrder_Temp.Rows(0).Item("order_id")

                If tbl_TrnOrder_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnRentalOrder3_SaveMaster(order_id, tbl_TrnOrder_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnRentalOrder3_SaveMaster(tbl_TrnOrder_Temp_Changes)")
                    Me.tbl_TrnOrder_Temp.AcceptChanges()
                End If

                'hanya untuk meng-cancel item yang tidak jadi di order

                If tbl_TrnRequestdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnRequestdetil.Rows.Count - 1
                        If Me.tbl_TrnRequestdetil.Rows(i).RowState = DataRowState.Modified And _
                            Me.tbl_TrnRequestdetil.Rows(i).Item("requestdetil_ordered") = 0 Then
                            Me.tbl_TrnRequestdetil.Rows(i).Item("request_id") = request_id
                            Me.tbl_TrnRequestdetil.Rows(i).Item("requestdetil_line") = requestdetil_line
                        End If
                    Next
                    success = Me.uiTrnRentalOrder3_CancelRequestDetil(request_id, requestdetil_line, tbl_TrnRequestdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save RequestDetil Data at Me.uiTrnRentalOrder3_CancelRequestDetil(tbl_TrnRequestdetil_Changes)")
                    Me.tbl_TrnRequestdetil.AcceptChanges()
                End If

                If tbl_TrnOrderdetiluse_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnOrderdetiluse.Rows.Count - 1
                        If Me.tbl_TrnOrderdetiluse.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderdetiluse.Rows(i).Item("order_id") = order_id
                        End If
                    Next
                    success = Me.uiTrnRentalOrder3_SaveUse(order_id, tbl_TrnOrderdetiluse_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Use Data at Me.uiTrnRentalOrder3_SaveUse(tbl_TrnOrderdetil_Changes)")
                    Me.tbl_TrnOrderdetiluse.AcceptChanges()
                End If

                If tbl_TrnOrderdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                        If Me.tbl_TrnOrderdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderdetil.Rows(i).Item("order_id") = order_id
                        End If
                    Next
                    success = Me.uiTrnRentalOrder3_SaveDetil(order_id, tbl_TrnOrderdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnRentalOrder3_SaveDetil(tbl_TrnOrderdetil_Changes)")
                    Me.tbl_TrnOrderdetil.AcceptChanges()
                End If

                If tbl_TrnOrderdetileps_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnOrderdetileps.Rows.Count - 1
                        If Me.tbl_TrnOrderdetileps.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderdetileps.Rows(i).Item("order_id") = order_id
                        End If
                    Next
                    success = Me.uiTrnRentalOrder3_SaveDetilEps(order_id, tbl_TrnOrderdetileps_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Use Data at Me.uiTrnRentalOrder3_SaveUse(tbl_TrnOrderdetil_Changes)")
                    Me.tbl_TrnOrderdetileps.AcceptChanges()
                End If

                Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
                Me.uiTrnRentalOrder3_TotalCalculate()

                If tbl_TrnOrderpaymreq_Changes IsNot Nothing Then
                    success = Me.uiTrnRentalOrder3_SaveDetilPaymReq(order_id, tbl_TrnOrderpaymreq_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Payment Request Data at Me.uiTrnRentalOrder3_SavePaymentreqreference(tbl_TrnPaymentreqreference_Changes)")
                    Me.tbl_TrnOrderPaymReq.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    'MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.uiTrnRentalOrder3_OpenRowDetil(channel_id, order_id, dbConn)
                    Me.uiTrnRentalOrder3_OpenRowDetiluse(channel_id, order_id, dbConn)
                    Me.uiTrnRentalOrder3_OpenRowPaymReq(channel_id, order_id, dbConn)
                    Me.uiTrnRentalOrder3_OpenRowRequestdetil(channel_id, order_id, dbConn)

                    Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
                    Me.uiTrnRentalOrder3_TotalCalculate()
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
                Me.uiTrnRentalOrder3_TotalCalculate()

            End If
        End If

        Me.ReservedItem = False

        'IsiBudgetName()
        RaiseEvent FormAfterSave(order_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnRentalOrder3_SaveMaster(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 300, "request_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200, "order_prognm"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30, "order_progsch"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4, "budget_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "order_eps"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_episodenum", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_episodenum", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname2", Me._ORDER_AUTHNAME2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition2", Me._ORDER_AUTHPOS2))

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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Numeric, 5, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_programtype", Me._PROGRAMTYPE))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_episodenum", System.Data.OleDb.OleDbType.Integer, 4, "order_episodenum"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_singlebudget", System.Data.OleDb.OleDbType.Boolean, 1, "order_singlebudget"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsstart", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsstart", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsend", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsend", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdelivery_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_createdate"))

        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrder_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "order_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_note", System.Data.OleDb.OleDbType.VarWChar, 510, "order_note"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_intref", System.Data.OleDb.OleDbType.VarWChar, 200, "order_intref"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 300, "request_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200, "order_prognm"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30, "order_progsch"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4, "budget_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "order_eps"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_episodenum", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_episodenum", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname2", System.Data.OleDb.OleDbType.VarWChar, 40, "order_authname2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition2", System.Data.OleDb.OleDbType.VarWChar, 60, "order_authposition2"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "order_canceled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_createdate"))
        'dbCmdUpdate.P       arameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", System.Data.OleDb.OleDbType.VarWChar, 40, "order_modifyby"))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_programtype", Me._PROGRAMTYPE))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_episodenum", System.Data.OleDb.OleDbType.Integer, 4, "order_episodenum"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_singlebudget", System.Data.OleDb.OleDbType.Boolean, 1, "order_singlebudget"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsstart", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsstart", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsend", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "order_epsend", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdelivery_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_createdate"))
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
    Private Function uiTrnRentalOrder3_SaveDetil(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        'Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderdetil2
        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Insert2", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_requestid_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "orderdetil_requestid_ref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetilqtyarrived", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetilqtyarrived", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_bpj", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetil_bpj"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "requestdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@isadvance", System.Data.OleDb.OleDbType.Integer, 4, "isadvance"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 510, "advance_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr_incldisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr_incldisc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign_incldisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign_incldisc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign_incltax", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign_incltax", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr_incltax", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr_incltax", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discountforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_discountforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Update2", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetilqtyarrived", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetilqtyarrived", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_bpj", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetil_bpj"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "requestdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@isadvance", System.Data.OleDb.OleDbType.Integer, 4, "isadvance"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 510, "advance_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr_incldisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr_incldisc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign_incldisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign_incldisc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign_incltax", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign_incltax", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr_incltax", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr_incltax", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discountforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_discountforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@order_id").Value = order_id


        '      dbCmdDelete = New OleDb.OleDbCommand("", dbConn)
        '      dbCmdDelete.CommandType = CommandType.StoredProcedure
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_type", System.Data.OleDb.OleDbType.VarWChar, 10, "orderdetil_type"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Integer, 4, "unit_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_descr"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_idr", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_actual", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetil_actualnote"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetaccount_id", System.Data.OleDb.OleDbType.VarWChar, 20, "budgetaccount_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_orderdetil_id", System.Data.OleDb.OleDbType.Integer, 4, "old_orderdetil_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_requestid_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "orderdetil_requestid_ref"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetilqtyarrived", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetilqtyarrived", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_bpj", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetil_bpj"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "requestdetil_line"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@isadvance", System.Data.OleDb.OleDbType.Integer, 4, "isadvance"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 510, "advance_id"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr_incldisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr_incldisc", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign_incldisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign_incldisc", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_pph", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_ppn", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalforeign_incltax", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_rowtotalforeign_incltax", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_rowtotalidr_incltax", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_rowtotalidr_incltax", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        '      dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters("@").Value = 


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
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
    Private Function uiTrnRentalOrder3_CancelRequestDetil(ByRef request_id As Object, ByRef requestdetil_line As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_requestdetil
        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil2_ReqDetilUpdate", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 30, "request_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "requestdetil_line"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate

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
    Private Function uiTrnRentalOrder3_SaveUse(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdUpdate.Parameters("@order_id").Value = order_id

        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderdetiluse_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "orderdetiluse_date"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
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
    Private Function uiTrnRentalOrder3_SaveDetilPaymReq(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
    Private Function uiTrnRentalOrder3_SaveDetilEps(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderdetileps
        dbCmdInsert = New OleDb.OleDbCommand("to_TrnOrderdetilEps_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_eps", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("to_TrnOrderdetilEps_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_eps", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdUpdate.Parameters("@order_id").Value = order_id


        dbCmdDelete = New OleDb.OleDbCommand("cp_TrnOrderdetileps_Delete", dbConn)
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_checked", System.Data.OleDb.OleDbType.Boolean, 1, "orderdetiluse_checked"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_eps", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_eps"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_descr"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actual", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetiluse_actual", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_actualnote", System.Data.OleDb.OleDbType.VarWChar, 510, "orderdetiluse_actualnote"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
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
    Private Function uiTrnRentalOrder3_ConfirmSaveBeforeAddItem(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnOrder_Temp_Changes As DataTable
        Dim tbl_TrnOrderdetil_Changes As DataTable
        Dim tbl_TrnOrderdetiluse_Changes As DataTable
        Dim tbl_TrnOrderpaymreq_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult

        Dim line As Integer
        Dim amount As Decimal
        Dim rowFilter As String
        Dim rows() As DataRow
        Dim j As Integer

        'Dim success As Boolean
        Dim i As Integer = 0
        Dim order_id As Object = New Object
        Dim move As Boolean = False

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
                    amount = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign")
                    rowFilter = String.Format("orderdetil_line={0}", line)
                    rows = Me.tbl_TrnOrderdetiluse.Select(rowFilter)
                    For j = 0 To rows.Length - 1
                        rows(j).Item("orderdetiluse_idr") = amount
                    Next
                End If
            Next
        End If

        Me.DgvTrnOrderdetiluse.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetiluse).EndCurrentEdit()
        tbl_TrnOrderdetiluse_Changes = Me.tbl_TrnOrderdetiluse.GetChanges()

        If tbl_TrnOrder_Temp_Changes IsNot Nothing _
            Or tbl_TrnOrderdetil_Changes IsNot Nothing _
                Or tbl_TrnOrderdetiluse_Changes IsNot Nothing _
                    Or tbl_TrnOrderpaymreq_Changes IsNot Nothing Then

            res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Select Case res
                Case DialogResult.Yes
                    If Me.uiTrnRentalOrder3_FormError() Then
                        Return False
                    End If
                    Me.uiTrnRentalOrder3_Save()
                    Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                    Me.tbl_RequestdetilSelect.Clear()
                    move = True
                Case DialogResult.No
                    move = False
                Case DialogResult.Cancel
                    move = False
            End Select
        Else
            move = True
        End If
        tbl_RequestdetilSelect.DefaultView.RowFilter = Nothing

        Return move

    End Function
    Private Function uiTrnRentalOrder3_PrintPreview() As Boolean
        'print data

        Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim channel_id As String = ""
        Dim criteria_history As String = ""
        Dim frmPrint As dlgViewRptRO_3 = New dlgViewRptRO_3(Me.DSN)
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
            criteria_history = String.Format(" order_id like '%{0}%' ", order_id)
        Next

        If criteria <> String.Empty Then
            criteria &= " and channel_id='" + channel_id + "'"
        End If

        frmPrint.SetIDCriteria(criteria, criteria_history)

        frmPrint.ShowDialog(Me)

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
    Private Function uiTrnRentalOrder3_Print() As Boolean

        Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim channel_id As String = ""
        Dim criteria_history As String = ""

        Dim oPrint As clsPrintRO_3 = New clsPrintRO_3(Me.DSN)
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
            criteria_history = String.Format(" order_id like '%{0}%' ", order_id)
        Next

        If criteria <> String.Empty Then
            criteria &= " and channel_id='" + channel_id + "'"
        End If

        oPrint.SetIDCriteria(criteria, criteria_history)

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
    Private Function uiTrnRentalOrder3_Delete() As Boolean
        Dim res As String = ""
        Dim order_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(order_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                'Me.uiTrnRentalOrder3_DeleteRow(Me.DgvTrnOrder.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(order_id)
        Me.Cursor = Cursors.Arrow

    End Function

    'Private Function uiTrnRentalOrder3_DeleteRow(ByVal rowIndex As Integer) As Boolean
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Dim dbCmdDelete As OleDb.OleDbCommand
    '    Dim order_id As String
    '    Dim NewRowIndex As Integer

    '    order_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("order_id").Value

    '    dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrder_Delete", dbConn)
    '    dbCmdDelete.CommandType = CommandType.StoredProcedure
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
    '    dbCmdDelete.Parameters("@order_id").Value = order_id
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_date").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_descr", System.Data.OleDb.OleDbType.VarWChar, 4000))
    '    dbCmdDelete.Parameters("@order_descr").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_note", System.Data.OleDb.OleDbType.VarWChar, 510))
    '    dbCmdDelete.Parameters("@order_note").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_intref", System.Data.OleDb.OleDbType.VarWChar, 200))
    '    dbCmdDelete.Parameters("@order_intref").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 300))
    '    dbCmdDelete.Parameters("@request_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@currency_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@rekanan_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_prognm", System.Data.OleDb.OleDbType.VarWChar, 200))
    '    dbCmdDelete.Parameters("@order_prognm").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_progsch", System.Data.OleDb.OleDbType.VarWChar, 30))
    '    dbCmdDelete.Parameters("@order_progsch").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Integer, 4))
    '    dbCmdDelete.Parameters("@budget_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_eps", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_eps").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_setdate").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_settime", System.Data.OleDb.OleDbType.VarWChar, 10))
    '    dbCmdDelete.Parameters("@order_settime").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_setlocation", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_setlocation").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddatestart", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_utilizeddatestart").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizeddateend", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_utilizeddateend").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimestart", System.Data.OleDb.OleDbType.VarWChar, 10))
    '    dbCmdDelete.Parameters("@order_utilizedtimestart").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedtimeend", System.Data.OleDb.OleDbType.VarWChar, 10))
    '    dbCmdDelete.Parameters("@order_utilizedtimeend").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_utilizedlocation", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_utilizedlocation").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_pph_percent", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_pph_percent").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_ppn_percent", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_ppn_percent").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_insurancecost").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_transportationcost").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_operatorcost").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_othercost").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname", System.Data.OleDb.OleDbType.VarWChar, 40))
    '    dbCmdDelete.Parameters("@order_authname").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition", System.Data.OleDb.OleDbType.VarWChar, 60))
    '    dbCmdDelete.Parameters("@order_authposition").Value = DBNull.Value

    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authname2", System.Data.OleDb.OleDbType.VarWChar, 40))
    '    dbCmdDelete.Parameters("@order_authname2").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_authposition2", System.Data.OleDb.OleDbType.VarWChar, 60))
    '    dbCmdDelete.Parameters("@order_authposition2").Value = DBNull.Value

    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_canceled", System.Data.OleDb.OleDbType.Boolean, 1))
    '    dbCmdDelete.Parameters("@order_canceled").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createby", System.Data.OleDb.OleDbType.VarWChar, 40))
    '    dbCmdDelete.Parameters("@order_createby").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_createdate").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", System.Data.OleDb.OleDbType.VarWChar, 40))
    '    dbCmdDelete.Parameters("@order_modifyby").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_modifydate").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_discount", System.Data.OleDb.OleDbType.Decimal, 9))
    '    dbCmdDelete.Parameters("@order_discount").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", System.Data.OleDb.OleDbType.VarWChar, 40))
    '    dbCmdDelete.Parameters("@order_source").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 40))
    '    dbCmdDelete.Parameters("@ordertype_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revno", System.Data.OleDb.OleDbType.VarWChar, 8))
    '    dbCmdDelete.Parameters("@order_revno").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
    '    dbCmdDelete.Parameters("@order_revdate").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdesc", System.Data.OleDb.OleDbType.VarWChar, 510))
    '    dbCmdDelete.Parameters("@order_revdesc").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.Boolean, 1))
    '    dbCmdDelete.Parameters("@order_approved").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
    '    dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8))
    '    dbCmdDelete.Parameters("@periode_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkrequired", System.Data.OleDb.OleDbType.Boolean, 1))
    '    dbCmdDelete.Parameters("@order_spkrequired").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkworktype", System.Data.OleDb.OleDbType.VarWChar, 510))
    '    dbCmdDelete.Parameters("@order_spkworktype").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_spkdesc", System.Data.OleDb.OleDbType.VarWChar, 510))
    '    dbCmdDelete.Parameters("@order_spkdesc").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrname", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_dlvrname").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr1", System.Data.OleDb.OleDbType.VarWChar, 200))
    '    dbCmdDelete.Parameters("@order_dlvraddr1").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr2", System.Data.OleDb.OleDbType.VarWChar, 200))
    '    dbCmdDelete.Parameters("@order_dlvraddr2").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvraddr3", System.Data.OleDb.OleDbType.VarWChar, 200))
    '    dbCmdDelete.Parameters("@order_dlvraddr3").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrtelp", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_dlvrtelp").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrfax", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_dlvrfax").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_dlvrhp", System.Data.OleDb.OleDbType.VarWChar, 100))
    '    dbCmdDelete.Parameters("@order_dlvrhp").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_program_id", System.Data.OleDb.OleDbType.Integer, 4))
    '    dbCmdDelete.Parameters("@old_program_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_category_id", System.Data.OleDb.OleDbType.VarWChar, 24))
    '    dbCmdDelete.Parameters("@old_category_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@old_apref", System.Data.OleDb.OleDbType.VarWChar, 18))
    '    dbCmdDelete.Parameters("@old_apref").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
    '    dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_programtype", System.Data.OleDb.OleDbType.VarWChar, 4))
    '    dbCmdDelete.Parameters("@order_programtype").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_episodenum", System.Data.OleDb.OleDbType.Decimal, 2))
    '    dbCmdDelete.Parameters("@order_episodenum").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_singlebudget", System.Data.OleDb.OleDbType.Boolean, 1))
    '    dbCmdDelete.Parameters("@order_singlebudget").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsstart", System.Data.OleDb.OleDbType.Decimal, 5))
    '    dbCmdDelete.Parameters("@order_epsstart").Value = DBNull.Value
    '    dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_epsend", System.Data.OleDb.OleDbType.Decimal, 5))
    '    dbCmdDelete.Parameters("@order_epsend").Value = DBNull.Value

    '    Try
    '        dbConn.Open()
    '        dbCmdDelete.ExecuteNonQuery()

    '        If Me.DgvTrnOrder.Rows.Count > 1 Then

    '            If rowIndex = 0 Then
    '                NewRowIndex = rowIndex + 1
    '                Me.uiTrnRentalOrder3_OpenRow(NewRowIndex)
    '                Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)
    '            ElseIf rowIndex = Me.DgvTrnOrder.Rows.Count - 1 Then
    '                NewRowIndex = rowIndex - 1
    '                Me.uiTrnRentalOrder3_OpenRow(NewRowIndex)
    '                Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)
    '            Else
    '                Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)
    '                Me.uiTrnRentalOrder3_OpenRow(rowIndex)
    '            End If

    '        Else

    '            Me.tbl_TrnOrder_Temp.Clear()
    '            Me.tbl_TrnOrder.Rows.RemoveAt(rowIndex)

    '        End If

    '    Catch ex As Data.OleDb.OleDbException
    '        MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Function
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Exit Function
    '    Finally
    '        dbConn.Close()
    '    End Try
    'End Function

    Private Function uiTrnRentalOrder3_confirmNew() As Boolean
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before input new data ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnRentalOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

    End Function

    Private Function uiTrnRentalOrder3_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim order_id As String
        Dim channel_id As String
        Dim row As DataGridViewRow
        Dim i As Integer
        Dim order_canceled As Boolean
        Dim order_approved As Integer = 0
        order_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("order_id").Value
        channel_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Try
            dbConn.Open()

            Dim tbl_jurnal As DataTable = New DataTable
            Dim error_messagebpj As Decimal = 0
            Dim error_messageadvance As Decimal = 0

            Me.uiTrnRentalOrder3_OpenRowMaster(channel_id, order_id, dbConn)
            Me.uiTrnRentalOrder3_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnRentalOrder3_OpenRowDetiluse(channel_id, order_id, dbConn)
            Me.uiTrnRentalOrder3_OpenRowPaymReq(channel_id, order_id, dbConn)
            Me.uiTrnRentalOrder3_OpenRowRequestdetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderApproval_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(channel_id, order_id, dbConn)
            'Me.uiTrnRentalOrder3OpenRow_DocCirc(channel_id, order_id, dbConn)
            'Me.uiTrnRentalOrder3OpenRow_InvReceipt(channel_id, order_id, dbConn)
            'Me.uiTrnRentalOrder3OpenRow_Advance(channel_id, order_id, dbConn)
            'Me.uiTrnRentalOrder3OpenRow_Episode(channel_id, order_id, dbConn)

            Dim h As Integer
            Dim y As Integer
            Dim tbl_orderAdvance As DataTable = New DataTable

            If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
                For h = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
                    If order_id <> String.Empty Then

                        tbl_jurnal.Clear()
                        Me.DataFill(tbl_jurnal, "to_TrnOrderdetil_SelectJurnal", String.Format("order_id = '{0}' AND orderdetil_line = {1}", order_id, clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)))

                        tbl_orderAdvance.Clear()
                        Me.DataFill(tbl_orderAdvance, "pr_TrnOrderdetilAdvanceForOrder_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND isadvance <> 0 and advance_canceled =0", order_id, clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)))

                        If tbl_jurnal.Rows.Count > 0 Or tbl_orderAdvance.Rows.Count > 0 Then
                            Dim u As Integer

                            For u = 0 To tbl_jurnal.Rows.Count - 1
                                If tbl_jurnal.Rows(u).Item("terimabarang_id") <> "" Or clsUtil.IsDbNull(tbl_jurnal.Rows(u).Item("isadvance"), 0) = 1 Then
                                    error_messagebpj += 1
                                End If
                            Next

                            For y = 0 To tbl_orderAdvance.Rows.Count - 1
                                If clsUtil.IsDbNull(tbl_orderAdvance.Rows(y).Item("isadvance"), 0) <> 0 Then
                                    error_messageadvance += 1

                                End If
                            Next
                        End If
                    End If
                Next

            End If
            If error_messageadvance > 0 Then
                Me.errorpa = True
            Else
                Me.errorpa = False
            End If
            If Me._FORMMODE <> "VIEW" Then
                'cek data approval
                If Me.DgvTrnOrder.Rows.Count <> 0 Then
                    row = Me.DgvTrnOrder.SelectedRows(i)
                    order_canceled = row.Cells("order_canceled").Value
                    order_approved = row.Cells("order_approved2").Value
                    If order_approved = 1 And order_canceled = False Then
                        Me.btnApp.Enabled = True
                        Me.chk_Order_canceled.Enabled = False
                        'ElseIf order_approved = 1 And order_canceled = True Then
                        '    Me.btnApp.Enabled = False
                        '    Me.chk_Order_canceled.Enabled = False
                    ElseIf order_approved = 0 And order_canceled = False Then
                        Me.btnApp.Enabled = True
                        Me.chk_Order_canceled.Enabled = True
                    ElseIf order_approved = 0 And order_canceled = True Then
                        Me.btnApp.Enabled = False
                        Me.chk_Order_canceled.Enabled = False

                    ElseIf order_approved = 2 And order_canceled = True Then
                        Me.btnApp.Enabled = False
                        Me.chk_Order_canceled.Enabled = False
                    ElseIf order_approved = 2 And order_canceled = False Then
                        Me.btnApp.Enabled = True
                        Me.chk_Order_canceled.Enabled = True
                    End If
                End If

                ' cek data BPJ dan PA
                If (error_messagebpj > 0 Or error_messageadvance > 0) Then
                    Me.chk_Order_canceled.Enabled = False
                    Me.btnApp.Enabled = False
                    Me.tbtnSave.Enabled = False
                    'Else
                    '    If order_canceled = True Then
                    '        Me.chkOrder_canceled.Enabled = False
                    '        Me.btnApp.Enabled = False
                    '        Me.tbtnSave.Enabled = False
                    '    Else
                    '        Me.chkOrder_canceled.Enabled = False
                    '        Me.btnApp.Enabled = True
                    '        Me.tbtnSave.Enabled = True
                    '    End If
                End If
                'If (error_messagebpj > 0 Or error_messageadvance > 0) And order_canceled = False Then
                '    'MsgBox("This Order has been have PA and BPJ")
                '    Me.chk_Order_canceled.Enabled = False
                '    Me.btnApp.Enabled = True
                '    Me.DgvTrnOrderdetil.ReadOnly = True
                '    Me.tbtnSave.Enabled = False
                'ElseIf (error_messagebpj > 0 Or error_messageadvance > 0) And order_canceled = True Then
                '    Me.chk_Order_canceled.Enabled = False
                '    Me.btnApp.Enabled = True
                '    Me.DgvTrnOrderdetil.ReadOnly = True
                '    Me.tbtnSave.Enabled = False
                'End If
            Else
                Me.btnApp.Visible = False
            End If
            ' Me.FormatDgvTrnTerimajasa(Me.dgvTrnBPJ)
            Me.IsiBudgetName()
            Me.uiTrnRentalOrder3_Lock()
            'Me.obj_Budget_id.Enabled = False
            'Me.cbo_Budget_name.Enabled = False
            Me._ORDER_SOURCE = Me.tbl_TrnOrder_Temp.Rows(0)("order_source").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnRentalOrder3_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(order_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function
    Private Function uiTrnRentalOrder3_OpenRowMaster(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrder_Select3", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@Limit", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.Parameters("@Limit").Value = Me.nudSearchRowLimit.Value
        'dbCmd.Parameters("@Criteria").Value = "order_id='" + order_id + "' and channel_id='" + Me._CHANNEL + "'"
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrder_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnOrder_Temp)

            Me.BindingStart()
            If Me._FORMMODE <> "VIEW" Then
                Me.Approve(Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved2"))
                If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved2") = 1 Then
                    Me.PnlDataMaster2.BackColor = Color.Tan
                    Me.tbtnSave.Enabled = False
                    Me.btnAddItem.Enabled = False
                    Me.tbtnDel.Enabled = False
                    Me.tbtnEdit.Enabled = False
                    Me.tbtnPrint.Enabled = True
                    Me.tbtnPrintPreview.Enabled = True
                    'If clsUtil.IsDbNull(Me.tbl_MstUser.Rows(0).Item("user_isauthorized_toapprove"), 0) <> 1 Then
                    Me.chk_Order_canceled.Enabled = False
                    'End If
                Else
                    Me.PnlDataMaster1.Enabled = True
                    Me.PnlDataMaster2.Enabled = True
                    Me.PnlDataFooter_Total.Enabled = True
                    Me.PnlDataMaster2.BackColor = Color.PapayaWhip
                    Me.tbtnSave.Enabled = True

                    If Me._PROGRAMTYPE = "PG" Then
                        Me.btnAddItem.Enabled = False
                    Else
                        Me.btnAddItem.Enabled = True
                    End If

                    Me.ftabDataDetil_Detil.Enabled = True
                    Me.ftabDataDetil_Info.Enabled = True
                    Me.ftabDataDetil_PaymReq.Enabled = True
                    Me.ftabDataDetil_Sign.Enabled = True
                    Me.tbtnDel.Enabled = True
                    Me.tbtnEdit.Enabled = True
                    Me.tbtnPrint.Enabled = True
                    Me.tbtnPrintPreview.Enabled = True
                    If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_canceled") = 0 Then
                        Me.chk_Order_canceled.Enabled = True
                    Else
                        Me.chk_Order_canceled.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Select2", dbConn)

        ''''dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetilVersi2_Select", dbConn)

        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        'tambahan
        ''''dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        ''''dbCmd.Parameters("@Criteria").Value = "order_id='" + order_id + "' and channel_id='" + Me._CHANNEL + "'"
        ''''dbCmd.Parameters("@order_id").Value = order_id

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderdetil.Clear()

        Me.tbl_TrnOrderdetil = clsDataset2.CreateTblTrnOrderdetil2()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_type").DefaultValue = "Item"

        Try
            dbDA.Fill(Me.tbl_TrnOrderdetil)
            Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderdetil

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try
        'If Me.DgvTrnOrder.Rows.Count <> 0 Then
        '    If Me.tbl_TrnOrder.Rows(0).Item("order_canceled") = 1 Then
        '        Me.chk_Order_canceled.Enabled = False
        '    Else
        '        Me.chk_Order_canceled.Enabled = True
        '    End If
        'End If
    End Function
    Private Function uiTrnRentalOrder3_OpenRowDetiluse(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetiluse_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderdetiluse.Clear()

        Me.tbl_TrnOrderdetiluse = clsDataset2.CreateTblTrnOrderdetiluse()
        Me.tbl_TrnOrderdetiluse.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrement = True
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnOrderdetiluse)
            Me.DgvTrnOrderdetiluse.DataSource = Me.tbl_TrnOrderdetiluse
            Me.tbl_TrnOrderdetiluse.DefaultView.RowFilter = "orderdetiluse_checked=1"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3_OpenRowDetiluse()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3_OpenRowPaymReq(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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

        Me.tbl_TrnOrderPaymReq = clsDataset2.CreateTblTrnOrderpaymreq()
        Me.tbl_TrnOrderPaymReq.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").AutoIncrement = True
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderPaymReq.Columns("orderpaymreq_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnOrderPaymReq)
            Me.DgvTrnOrderPaymReq.DataSource = Me.tbl_TrnOrderPaymReq
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3_OpenRowPaymReq()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3_OpenRowRequestdetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnRequestHD_Select", dbConn)
        'dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("requestdetil_refreference='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnRequestdetil.Clear()

        Me.tbl_TrnRequestdetil = clsDataset2.CreateTblRequestdetil()
        Me.tbl_TrnRequestdetil.Columns("requestdetil_refreference").DefaultValue = order_id
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").AutoIncrement = True
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnRequestdetil)
            Me.DgvTrnRequestdetil.DataSource = Me.tbl_TrnRequestdetil

            ''open Order Use---------
            'If Me.tbl_TrnOrderdetil.Rows.Count > 0 Then
            '    Dim tbl_test As DataTable = New DataTable
            '    Dim tbl_merge As DataTable = New DataTable
            '    tbl_merge.Clear()
            '    Dim i As Integer
            '    For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
            '        tbl_test.Clear()
            '        Me.DataFill(tbl_test, "order_revisi", "orderdetil_requestid_ref='" & Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_requestid_ref") & "' and requestdetil_line ='" & Me.tbl_TrnOrderdetil.Rows(i).Item("requestdetil_line") & "'")
            '        tbl_merge.Merge(tbl_test)
            '    Next
            'End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3_OpenRowRentalReq()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3OrderApproval_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim appby As String

        dbCmd = New OleDb.OleDbCommand("to_TalentorderApproved_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderApproval.Clear()

        Me.tbl_TrnOrderApproval = clsDataset2.CreateTblTrnorderApproval()


        Try
            dbDA.Fill(Me.tbl_TrnOrderApproval)
            ' Me.dgvTrnOrderApproval.DataSource = Me.tbl_TrnOrderApproval

            If Me.tbl_TrnOrderApproval.Rows.Count > 0 Then
                appby = Me.tbl_TrnOrderApproval.Rows(0).Item("order_approvedby").ToString

                Me.obj_appby.Text = appby
                Me.obj_appdate.Text = Me.tbl_TrnOrderApproval.Rows(0).Item("order_approveddt").ToString

                If Me.tbl_TrnOrderApproval.Rows(0).Item("order_approved") = 0 Then
                    Me.obj_appstatus.Text = "Not Yet Approved"
                ElseIf Me.tbl_TrnOrderApproval.Rows(0).Item("order_approved") = 1 Then
                    Me.obj_appstatus.Text = "Approved"
                Else
                    Me.obj_appstatus.Text = "Dissaproved"
                End If
            Else
                Me.obj_appby.Text = ""
                Me.obj_appdate.Text = ""
                Me.obj_appstatus.Text = "Not Yet Approved"
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OrderApproval_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tblBPJ As DataTable = New DataTable

        dbConn = New OleDb.OleDbConnection(Me.ASSET_DSN)

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_selectfororderRO ", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}' and terimajasa_isdisabled = 0", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tblBPJ.Clear()

        Try
            dbDA.Fill(tblBPJ)
            Me.FormatDgvTrnTerimajasa(Me.dgvTrnBPJ)
            Me.dgvTrnBPJ.DataSource = tblBPJ
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OrderBPB_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3OpenRow_DocCirc(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tblDocCrc As DataTable = New DataTable

        dbCmd = New OleDb.OleDbCommand("cq_TrnCrView_Select ", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("circulationdetil_ref='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tblDocCrc.Clear()
        Try
            dbDA.Fill(tblDocCrc)
            'If tblBPB.Rows.Count > 0 Then
            Me.FormatDgvDocCirculation(Me.DgvDocCirculation)
            Me.DgvDocCirculation.DataSource = tblDocCrc

            ' End If

            'Me.dgvTrnOrderApproval.DataSource = Me.tbl_TrnOrderApproval
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3OpenRow_DocCirc()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3OpenRow_InvReceipt(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tblInvReceipt As DataTable = New DataTable

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetilCRC_Select ", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tblInvReceipt.Clear()
        Try
            dbDA.Fill(tblInvReceipt)
            'If tblBPB.Rows.Count > 0 Then
            Me.FormatDgvTandaTerimaDetil(Me.DgvInvReceipt)
            Me.DgvInvReceipt.DataSource = tblInvReceipt

            ' End If

            'Me.dgvTrnOrderApproval.DataSource = Me.tbl_TrnOrderApproval
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder3OpenRow_InvReceipt()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3OpenRow_Advance(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tblAdvance As DataTable = New DataTable

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil_SelectSettlementForOrder ", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("and advance_requestid='{0}' and advance_canceled = 0", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tblAdvance.Clear()
        Try
            dbDA.Fill(tblAdvance)
            'If tblBPB.Rows.Count > 0 Then
            Me.FormatDgvTrnAdvance(Me.dgvAdvance)
            Me.dgvAdvance.DataSource = tblAdvance
            ' End If

            'Me.dgvTrnOrderApproval.DataSource = Me.tbl_TrnOrderApproval
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OpenRow_Advance()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnRentalOrder3OpenRow_Episode(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("to_TrnOrderdetilEps_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnOrderdetileps.Clear()
        Me.tbl_TrnOrderdetileps = clsDataset2.CreateTblTrnOrderdetileps()
        Me.tbl_TrnOrderdetileps.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").AutoIncrement = True
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetileps.Columns("orderdetiluse_line").AutoIncrementStep = 10
        Try
            dbDA.Fill(Me.tbl_TrnOrderdetileps)
            Me.tbl_TrnOrderdetileps.DefaultView.RowFilter = "orderdetiluse_checked=1"
            Me.FormatDgvTrnOrderdetileps(Me.DgvEpisode)
            Me.DgvEpisode.DataSource = Me.tbl_TrnOrderdetileps
        Catch ex As Exception
            Throw New Exception(mUiName & ": _OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnRentalOrder3_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnRentalOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, 0)
            Me.uiTrnRentalOrder3_RefreshPosition()
        End If
    End Function
    Private Function uiTrnRentalOrder3_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnRentalOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOrder.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, DgvTrnOrder.CurrentCell.RowIndex - 1)
                Me.uiTrnRentalOrder3_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnRentalOrder3_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnRentalOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOrder.CurrentCell.RowIndex < Me.DgvTrnOrder.Rows.Count - 1 Then
                Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, DgvTrnOrder.CurrentCell.RowIndex + 1)
                Me.uiTrnRentalOrder3_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnRentalOrder3_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnRentalOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, Me.DgvTrnOrder.Rows.Count - 1)
            Me.uiTrnRentalOrder3_RefreshPosition()
        End If
    End Function
    Private Function uiTrnRentalOrder3_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            Me.uiTrnRentalOrder3_OpenRow(Me.DgvTrnOrder.CurrentRow.Index)
            Me.uiTrnRentalOrder3_GetOrderCreator()
            IsiBudgetName()

            If Me.DgvTrnOrder.CurrentRow.Cells("order_source").Value = "ML" Then
                Me.cbo_Rekanan_name.Enabled = True
            Else
                Me.cbo_Rekanan_name.Enabled = False
            End If
        End If

    End Function
    Private Function uiTrnRentalOrder3_GetOrderCreator() As Boolean
        Dim createby, modifyby As String
        Dim createdate, modifydate As String

        If Me.tbl_TrnOrder.Rows.Count > 0 Or Me.tbl_TrnOrder_Temp.Rows.Count > 0 Then
            Try
                createby = clsUtil.IsDbNull(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_createby").ToString, "")
                modifyby = clsUtil.IsDbNull(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_modifyby").ToString, "")

                If createby = "" Then createby = "Created: " Else createby = "Created by: " & createby
                If modifyby = "" Then modifyby = "Modified: " Else modifyby = "Modified by: " & modifyby

                createdate = Format(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_createdate"), "dd/MM/yyyy")
                modifydate = Format(Me.tbl_TrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index)("order_modifydate"), "dd/MM/yyyy")

                createby = createby & " [" & createdate & "] "
                modifyby = modifyby & " [" & modifydate & "] "

                ' Me.lbl_createby.Text = createby & modifyby
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Function
    Private Function uiTrnRentalOrder3_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
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
                        Me.uiTrnRentalOrder3_Save()
                        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                        move = True
                    Case DialogResult.No
                        Me.DataFill(tbl_RequestSelect, "pr_TrnRequestHD_Select", "jurnaltype_id = 'RQ' AND requestdetil_ordered=0 AND request_programtype='" & Me._PROGRAMTYPE & "' AND requestdetil_qty>0 AND item_id<>'' ")
                        Me.ReservedItem = False
                        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                        move = True
                    Case DialogResult.Cancel
                        tbl_RequestSelect.Clear()
                        Me.DataFill(tbl_RequestSelect, "pr_TrnRequestHD_Select", "jurnaltype_id = 'RQ' AND requestdetil_ordered=0 AND request_programtype='" & Me._PROGRAMTYPE & "' AND requestdetil_qty>0 AND item_id<>'' ")
                        Me.ReservedItem = False
                        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                        move = False
                End Select
            Else
                move = True
            End If

        End If

        Return move

    End Function
    Private Function uiTrnRentalOrder3_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            'cek periode sudah diisi
            If Me.cbo_Periode_id.SelectedValue = 0 Then
                ErrorMessage = "Periode can`t be empty"
                Me.objFormError.SetError(Me.cbo_Periode_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Periode_id, "")
            End If

            'cek rental date dan bulan periode
            Dim dr() As DataRow = Me.tbl_MstPeriode.Select(String.Format("periode_id='{0}'", Me.cbo_Periode_id.SelectedValue))
            Dim tgl_start As Date = dr(0).Item("periode_datestart")
            Dim tgl_end As Date = dr(0).Item("periode_dateend")
            Dim tgl As Date = CDate(Me.dtp_Order_utilizeddatestart.Value).Date

            If tgl >= tgl_start And tgl <= tgl_end Then
                Me.objFormError.SetError(Me.cbo_Periode_id, "")
                Me.objFormError.SetError(Me.dtp_Order_utilizeddatestart, "")
            Else
                ErrorMessage = "Tanggal Shooting harus sesuai dengan Periode!!"
                Me.objFormError.SetError(Me.cbo_Periode_id, ErrorMessage)
                Me.objFormError.SetError(Me.dtp_Order_utilizeddatestart, ErrorMessage)
                Throw New Exception(ErrorMessage)
            End If

            'cek rekanan
            If Me.cbo_Rekanan_name.SelectedValue = 0 Then
                ErrorMessage = "Rekanan belum diisi"
                Me.objFormError.SetError(Me.cbo_Rekanan_name, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Rekanan_name, "")
            End If

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try

        Return False

    End Function
    Private Function uiTrnRentalOrder3_DetilCalculate(ByVal dgv As DataGridView, ByRef sumdetil As Decimal, ByRef sumPPH As Decimal, ByRef sumPPN As Decimal, ByRef sumDisc As Decimal) As Boolean


        Dim i As Integer
        Dim cSubPPN, cSubPPH, cSubDiscount, cSubtotal, totalrow As Decimal

        sumdetil = 0 : sumPPH = 0 : sumPPN = 0 : sumDisc = 0

        For i = 0 To dgv.Rows.Count - 1

            If Me.cbo_Currency.SelectedValue <> 1 Then
                cSubPPH = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_pphforeign").Value, 0)
                cSubPPN = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_ppnforeign").Value, 0)
                cSubDiscount = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_discount").Value, 0) 
                cSubtotal = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_rowtotalforeign").Value, 0)
            Else

                cSubPPH = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_pph").Value, 0)
                cSubPPN = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_ppn").Value, 0)
                cSubDiscount = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_discount").Value, 0) 
                cSubtotal = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_rowtotalidr").Value, 0)
            End If
            'cSubPPH = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_pph").Value, 0)
            'cSubPPN = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_ppn").Value, 0)
            'cSubDiscount = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_discount").Value, 0)
            'cSubtotal = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_rowtotalforeign").Value, 0)

            totalrow = cSubtotal
            sumdetil += totalrow : sumPPH += cSubPPH : sumPPN += cSubPPN : sumDisc += cSubDiscount
            'End If
        Next

    End Function
    'Private Function CekCurrencyDetil() As Boolean
    '    Dim distinctdt As New DataTable
    '    Dim dv As DataView

    '    dv = Me.tbl_TrnOrderdetil.GetChanges.DefaultView
    '    distinctdt.Columns.Add("currency_id")
    '    Dim mycolumn As DataColumn = New DataColumn
    '    Try
    '        distinctdt = dv.ToTable(True, "currency_id")
    '        If distinctdt.Rows.Count > 1 Then
    '            Dim errormessage As String = ""
    '            Dim errorfound As Boolean = False
    '            errormessage = "currency on detail order can't be different"
    '            Me.objFormError.SetError(Me.DgvTrnOrderdetil, errormessage)
    '            Throw New Exception(errormessage)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '        Return True
    '    End Try
    'End Function
    Private Function uiTrnRentalOrder3_TotalCalculate() As Boolean
        'Calculate Cost, Tax, and Total
        Dim [insurance], [transport], [operator], [other], [additional] As Decimal
        Dim [subdiscount], [subtotal], [ppn], [pph] As Decimal
        Dim [order_discount], [gtotal] As Decimal

        If Me.tbl_TrnOrder_Temp.Rows.Count > 0 Then
            [insurance] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_insurancecost")
            [transport] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_transportationcost")
            [operator] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_operatorcost")
            [other] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_othercost")
            [order_discount] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_discount") + _
                (Me.tbl_TrnOrder_Temp.Rows(0).Item("order_discount") * (Me.tbl_TrnOrder_Temp.Rows(0).Item("order_ppn_percent") / 100)) - _
                (Me.tbl_TrnOrder_Temp.Rows(0).Item("order_discount") * (Me.tbl_TrnOrder_Temp.Rows(0).Item("order_pph_percent") / 100))
        Else
            [insurance] = 0
            [transport] = 0
            [operator] = 0
            [other] = 0
            [order_discount] = 0
        End If

        [subtotal] = clsUtil.IsEmptyText(Me.calc_Order_subtotal.Text, 0)
        [additional] = [insurance] + [transport] + [operator] + [other]

        [pph] = Me.calc_Order_subPPH.Text
        [ppn] = Me.calc_Order_subPPN.Text
        [subdiscount] = clsUtil.IsEmptyText(Me.calc_Order_subdiscount.Text, 0)

        [gtotal] = ([subtotal] - [subdiscount] - [order_discount] + [additional]) + ([ppn] - [pph])

        order_total = [gtotal]

        If [order_discount] > 0 Then
            Me.calc_Order_discount.Text = String.Format("({0:#,##0.00})", [order_discount])
        Else
            Me.calc_Order_discount.Text = String.Format("{0:#,##0.00}", [order_discount])
        End If

        If [subdiscount] > 0 Then
            Me.calc_Order_subdiscount.Text = String.Format("({0:#,##0.00})", [subdiscount])
        Else
            Me.calc_Order_subdiscount.Text = String.Format("{0:#,##0.00}", [subdiscount])
        End If

        If [pph] > 0 Then
            Me.calc_Order_subPPH.Text = String.Format("({0:#,##0.00})", [pph])
        Else
            Me.calc_Order_subPPH.Text = String.Format("{0:#,##0.00}", [pph])
        End If

        If Me.chk_Order_canceled.Checked Then
            Me.calc_Order_GTotal.Text = String.Format("{0:#,##0.00}", 0)
        Else
            Me.calc_Order_GTotal.Text = String.Format("{0:#,##0.00}", [gtotal])
        End If


        If Me.tbl_TrnOrder_Temp.Rows(0).Item("currency_id") = 1 Then
            Me.calc_Order_subdiscount.Text = String.Format("({0:#,##0})", [subdiscount])
        Else
            Me.calc_Order_subdiscount.Text = String.Format("{0:#,##0.00}", [subdiscount])
        End If

    End Function
    Private Function uiTrnRentalOrder3_SPKGen(ByVal dgv As DataGridView, ByRef spktype As String) As Boolean
        Dim i, j As Integer
        Dim cSPKType As String
        Dim bSPKType As String

        j = 0
        spktype = ""
        cSPKType = ""
        bSPKType = ""

        For i = 0 To dgv.Rows.Count - 1
            bSPKType = cSPKType
            cSPKType = clsUtil.IsDbNull(dgv.Rows(i).Cells("category_name").Value, "")

            If i < dgv.Rows.Count Then
                j += 1
                If j > 1 Then
                    If cSPKType = bSPKType Then
                        cSPKType = ""
                        spktype &= ""
                    Else
                        spktype &= ", "
                    End If
                End If

                spktype &= cSPKType

            End If
        Next

        If Not spktype = "" Then
            spktype = "Penyewaan " & spktype
        End If

    End Function
    Private Function ConfirmSaveAddItem(ByVal type As String) As Boolean
        Dim move As Boolean
        Dim Message As String
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If type = "New" Then
            Message = "Data has been changed. " & vbCrLf & "Save data changes before input new data ?"
        Else
            Message = "Data has been changed. " & vbCrLf & "Save data changes before add new item?"
        End If

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnRentalOrder3_ConfirmSaveBeforeAddItem(Message)
            End If
        Else
            move = True
        End If

        If move = True Then
            If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
                Me.ReservedItem = True
            Else
                Me.ReservedItem = False
            End If
            Me.uiTrnRentalOrder3_GetOrderSource()
        End If

    End Function

#End Region

    Private Sub uiTrnRentalOrder3_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
        Me.uiTrnRentalOrder3_TotalCalculate()

        Me.DgvTrnOrderdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
    End Sub
    Private Sub uiTrnRentalOrder3_FormBeforeNew() Handles Me.FormBeforeNew
        If Me._FORMMODE = "ENTRY" Then
            Me.calc_Order_GTotal.Text = "0.00"
            Me.calc_Order_subtotal.Text = "0.00"
            Me.calc_Order_subPPH.Text = "0.00"
            Me.calc_Order_subPPN.Text = "0.00"

            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True

            Me.DgvTrnOrderdetil.ReadOnly = False
            Me.DgvTrnOrderdetil.AllowUserToDeleteRows = True
            Me.DgvTrnOrderdetil.AllowUserToAddRows = True
        End If

    End Sub
    Private Function uiTrnRentalOrder3_LoadSupportingData() As Boolean
        Dim tbl_TrnOrder_Status As New DataTable
        Dim tbl_trnOrder_StatusApproval As New DataTable

        Dim row_type As DataRow

        tbl_TrnOrder_Status.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
        tbl_TrnOrder_Status.Columns.Add(New DataColumn("display_type", GetType(System.String)))

        tbl_trnOrder_StatusApproval.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
        tbl_trnOrder_StatusApproval.Columns.Add(New DataColumn("display_type", GetType(System.String)))
        If tbl_TrnOrder_Status.Columns("display_type") IsNot Nothing Then
            row_type = tbl_TrnOrder_Status.NewRow
            row_type.Item("value_type") = 0
            row_type.Item("display_type") = "Not Canceled"
            tbl_TrnOrder_Status.Rows.InsertAt(row_type, 0)

            row_type = tbl_TrnOrder_Status.NewRow
            row_type.Item("value_type") = 1
            row_type.Item("display_type") = "Canceled"
            tbl_TrnOrder_Status.Rows.InsertAt(row_type, 1)
        End If
        If tbl_trnOrder_StatusApproval.Columns("display_type") IsNot Nothing Then
            row_type = tbl_trnOrder_StatusApproval.NewRow
            row_type.Item("value_type") = 0
            row_type.Item("display_type") = "Not Yet Approve"
            tbl_trnOrder_StatusApproval.Rows.InsertAt(row_type, 0)

            row_type = tbl_trnOrder_StatusApproval.NewRow
            row_type.Item("value_type") = 1
            row_type.Item("display_type") = "Approved"
            tbl_trnOrder_StatusApproval.Rows.InsertAt(row_type, 0)

            row_type = tbl_trnOrder_StatusApproval.NewRow
            row_type.Item("value_type") = 2
            row_type.Item("display_type") = "Dissaproved"
            tbl_trnOrder_StatusApproval.Rows.InsertAt(row_type, 1)
        End If

        Me.cboSearchStatus.DataSource = tbl_TrnOrder_Status
        Me.cboSearchStatus.ValueMember = "value_type"
        Me.cboSearchStatus.DisplayMember = "display_type"

        Me.cboSearchApproved.DataSource = tbl_trnOrder_StatusApproval
        Me.cboSearchApproved.ValueMember = "value_type"
        Me.cboSearchApproved.DisplayMember = "display_type"

        Me.cboSearchStatus.SelectedValue = 0
        Me.cboSearchApproved.SelectedValue = 1
    End Function
#Region "Approved"
    Private Enum Approves
        Approved
        DisApprove
    End Enum

    Private app As Approves = Approves.DisApprove

    Private Function UpdateApprove(ByVal order_id As String, ByVal approved As Integer, ByVal order_canceled As Integer) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Try
            dbConn.Open()

            cmd = New OleDb.OleDbCommand("to_TalentorderApproved_Update2", dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id
            cmd.Parameters.Add("@order_approved", OleDb.OleDbType.TinyInt, 1).Value = approved
            cmd.Parameters.Add("@order_approvedby", OleDb.OleDbType.VarChar, 200).Value = Me.UserName
            cmd.Parameters.Add("@order_approveddt", OleDb.OleDbType.DBTimeStamp, 4).Value = Date.Now
            cmd.Parameters.Add("@order_canceled", OleDb.OleDbType.TinyInt, 1).Value = order_canceled

            cmd.ExecuteNonQuery()

            result = True
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        End Try
        Return result
    End Function
    Private Function InsertApprove(ByVal order_id As String) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False

        Try
            dbConn.Open()

            cmd = New OleDb.OleDbCommand("to_TalentorderApproved_Insert2", dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id
            cmd.Parameters.Add("@order_approved", OleDb.OleDbType.TinyInt, 1).Value = 1
            cmd.Parameters.Add("@order_approvedby", OleDb.OleDbType.VarChar, 200).Value = Me.UserName
            cmd.Parameters.Add("@order_approveddt", OleDb.OleDbType.DBTimeStamp, 4).Value = Date.Now
            cmd.Parameters.Add("@order_canceled", OleDb.OleDbType.TinyInt, 1).Value = 0

            cmd.ExecuteNonQuery()

            result = True
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        End Try
        Return result
    End Function
    Private Function IsApproved(ByVal order_id As String) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim SQL As String = String.Format("select count(*) from E_FRM.DBO.transaksi_talentorder_approve where order_id = '{0}'", order_id)
        Dim result As Boolean = False
        Dim val As Integer

        Try
            dbConn.Open()

            cmd = New OleDb.OleDbCommand(SQL, dbConn)

            val = Integer.Parse(cmd.ExecuteScalar)

            If val = 0 Then
                result = False
            ElseIf val > 0 Then
                result = True
            End If
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        End Try

        Return result
    End Function
    Private Sub btnApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApp.Click
        Dim btn As ToolStripButton = sender
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim channel_id As String = ""
        Dim tblorderdetil_tempcek As DataTable = New DataTable
        Dim i As Integer
        Dim error_messageadvance As Decimal = 0
        Dim error_messagebpj As Decimal = 0
        Dim tbl_jurnal As DataTable = New DataTable
        'frmPrint.StartPosition = FormStartPosition.CenterParent

        If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
            MsgBox("Pilih data dulu..")
            Exit Sub
        End If

        'ambil row yang dipilih di datagrid
        If Me.DgvTrnOrder.Rows.Count > 0 Then
            For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
                row = Me.DgvTrnOrder.SelectedRows(i)
                order_id = row.Cells("order_id").Value
                channel_id = row.Cells("channel_id").Value
                criteria = String.Format("order_id='{0}' and orderdetil_type ='Item'", order_id)
                'CEK Data BPB dan BPJ----------------------------------------------------------------------------------------------------------
                tblorderdetil_tempcek.Clear()
                Me.DataFill(tblorderdetil_tempcek, "pr_TrnOrderDetil_SelectCek", criteria)

                Dim h As Integer
                Dim y As Integer
                Dim tbl_orderAdvance As DataTable = New DataTable

                If tblorderdetil_tempcek.Rows.Count > 0 Then

                    For h = 0 To tblorderdetil_tempcek.Rows.Count - 1
                        If order_id <> String.Empty Then
                            tbl_jurnal.Clear()
                            Me.DataFill(tbl_jurnal, "to_TrnOrderdetil_SelectJurnal", String.Format("order_id = '{0}' AND orderdetil_line = {1}", order_id, clsUtil.IsDbNull(tblorderdetil_tempcek.Rows(i).Item("orderdetil_line"), 0)))
                            tbl_orderAdvance.Clear()
                            Dim orderdetil_line As Integer = clsUtil.IsDbNull(tblorderdetil_tempcek.Rows(h).Item("orderdetil_line"), 0)
                            Me.DataFill(tbl_orderAdvance, "pr_TrnOrderdetilAdvanceForOrder_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND isadvance <> 0 and advance_canceled = 0", order_id, orderdetil_line))

                            If tbl_jurnal.Rows.Count > 0 Or tbl_orderAdvance.Rows.Count > 0 Then
                                Dim u As Integer

                                For u = 0 To tbl_jurnal.Rows.Count - 1
                                    If tbl_jurnal.Rows(u).Item("terimabarang_id") <> "" Or clsUtil.IsDbNull(tbl_jurnal.Rows(u).Item("isadvance"), 0) = 1 Then
                                        error_messagebpj += 1

                                    End If
                                Next
                                For y = 0 To tbl_orderAdvance.Rows.Count - 1
                                    If clsUtil.IsDbNull(tbl_orderAdvance.Rows(y).Item("isadvance"), 0) <> 0 Then
                                        error_messageadvance += 1

                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
                If error_messageadvance > 0 Then
                    Me.errorpa = True
                Else
                    Me.errorpa = False
                End If
                '--------------------------------------------------------------------------------------------------------------------------------------
              

                'Approve Order-------------------------------------------------------------------------------------------------------------------------
                If order_id = "" Then
                    'If Me.DgvTrnOrder.CurrentRow IsNot Nothing Or Me.FlatTabMain.SelectedIndex = 0 Then
                    MsgBox("Please Load Data...")
                    'Me.FlatTabMain.SelectedIndex = 1

                    'ElseIf Me.FlatTabMain.SelectedIndex = 0 Then
                    ';MsgBox("open detil for approve data...")
                ElseIf error_messagebpj > 0 Then
                    MsgBox("Sorry this order has been have a BPJ")
                    Exit Sub
                ElseIf error_messageadvance > 0 Then
                    MsgBox(" Sorry this order has been have a PA")
                    Exit Sub
                Else
                    Try
                        If app = Approves.Approved Then
                            If Me.IsApproved(order_id) = True Then
                                If Me.UpdateApprove(order_id, 1, 0) = True Then
                                    app = Approves.DisApprove
                                    btn.Text = "Disapprove"
                                End If
                            Else
                                If Me.InsertApprove(order_id) = True Then

                                    app = Approves.DisApprove
                                    If FlatTabMain.SelectedIndex = 1 Then
                                        btn.Text = "Disapprove"
                                    End If
                                End If
                            End If
                        ElseIf app = Approves.DisApprove Then
                            If Me.UpdateApprove(order_id, 2, 0) = True Then
                                app = Approves.Approved
                                btn.Text = "Approve"
                            End If
                        End If

                        'If btn.Text = "Approve" Then
                        '    If Me.IsApproved(Me.obj_Order_id.Text) = True Then
                        '        If Me.UpdateApprove(Me.obj_Order_id.Text, 2, 1) = True Then
                        '            btn.Text = "Disapprove"
                        '        End If
                        '    Else
                        '        If Me.InsertApprove(Me.obj_Order_id.Text) = True Then
                        '            btn.Text = "Disapprove"
                        '        End If
                        '    End If
                        'ElseIf btn.Text = "Disapprove" Then
                        '    If Me.UpdateApprove(Me.obj_Order_id.Text, 2, 1) = True Then
                        '        btn.Text = "Approve"
                        '    End If
                        'End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                    uiTrnRentalOrder3_Retrieve()
                End If

            Next
        End If
        '    Dim btn As ToolStripButton = sender

        '    If Me.obj_Order_id.Text = "" Then
        '        If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then
        '            MsgBox("open detil for approve data...")
        '            Me.FlatTabMain.SelectedIndex = 1
        '        End If
        '    ElseIf Me.FlatTabMain.SelectedIndex = 0 Then
        '        MsgBox("open detil for approve data...")
        '    ElseIf Me.dgvTrnBPJ.RowCount > 0 Then
        '        MsgBox("Sorry this order has been have a BPJ")
        '        Exit Sub
        '    ElseIf Me.errorPA = True Then
        '        MsgBox(" Sorry this order has been have a PA")
        '        Exit Sub
        '    Else
        '        Try
        '            If app = Approves.Approved Then
        '                If Me.IsApproved(Me.obj_Order_id.Text) = True Then
        '                    If Me.UpdateApprove(Me.obj_Order_id.Text, 1, 0) = True Then
        '                        app = Approves.DisApprove
        '                        btn.Text = "Disapprove"
        '                    End If
        '                Else
        '                    If Me.InsertApprove(Me.obj_Order_id.Text) = True Then
        '                        app = Approves.DisApprove
        '                        btn.Text = "Disapprove"
        '                    End If
        '                End If
        '            ElseIf app = Approves.DisApprove Then
        '                If Me.UpdateApprove(Me.obj_Order_id.Text, 2, 0) = True Then
        '                    app = Approves.Approved
        '                    btn.Text = "Approve"
        '                End If
        '            End If

        '            'If btn.Text = "Approve" Then
        '            '    If Me.IsApproved(Me.obj_Order_id.Text) = True Then
        '            '        If Me.UpdateApprove(Me.obj_Order_id.Text, 2, 1) = True Then
        '            '            btn.Text = "Disapprove"
        '            '        End If
        '            '    Else
        '            '        If Me.InsertApprove(Me.obj_Order_id.Text) = True Then
        '            '            btn.Text = "Disapprove"
        '            '        End If
        '            '    End If
        '            'ElseIf btn.Text = "Disapprove" Then
        '            '    If Me.UpdateApprove(Me.obj_Order_id.Text, 2, 1) = True Then
        '            '        btn.Text = "Approve"
        '            '    End If
        '            'End If
        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        End Try
        '    End If
    End Sub
#End Region
    Private Sub uiTrnRentalOrder3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objParameters As Collection = New Collection
        'Dim tbl_TrnOrder_Status As New DataTable
        'Dim row_type As DataRow
        'TODO: - Extract Parameter
        '      - Assign parameter

        Me.chkSrchStatus.Checked = True

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._ORDER_SOURCE = Me.GetValueFromParameter(objParameters, "ORDER_SOURCE")
            Me._ORDERTYPE_ID = Me.GetValueFromParameter(objParameters, "ORDERTYPE_ID")
            Me._ORDER_AUTHNAME = Me.GetValueFromParameter(objParameters, "ORDER_AUTHNAME")
            Me._ORDER_AUTHPOS = Me.GetValueFromParameter(objParameters, "ORDER_AUTHPOS")
            Me._ORDER_AUTHNAME2 = Me.GetValueFromParameter(objParameters, "ORDER_AUTHNAME2")
            Me._ORDER_AUTHPOS2 = Me.GetValueFromParameter(objParameters, "ORDER_AUTHPOS2")

            Me._FORMMODE = Me.GetValueFromParameter(objParameters, "FORMMODE")
            Me._PROGRAMTYPE = Me.GetValueFromParameter(objParameters, "PROGRAMTYPE")
            'Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            'Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
            Me.DataFill(Me.tbl_MstUser, "cq_MstUser_Select", String.Format("username = '{0}'", Me.UserName))


        End If
        If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then

            Me.uiTrnRentalOrder3_LoadSupportingData()
            If Not Me.COMBO_ISFILLED Then
                Me.uiTrnRentalOrder3_LoadDataCombo()
            End If
            'tbl_TrnOrder_Status.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
            'tbl_TrnOrder_Status.Columns.Add(New DataColumn("display_type", GetType(System.String)))

            'If tbl_TrnOrder_Status.Columns("display_type") IsNot Nothing Then
            '    row_type = tbl_TrnOrder_Status.NewRow
            '    row_type.Item("value_type") = 0
            '    row_type.Item("display_type") = "Not Canceled"
            '    tbl_TrnOrder_Status.Rows.InsertAt(row_type, 0)

            '    row_type = tbl_TrnOrder_Status.NewRow
            '    row_type.Item("value_type") = 1
            '    row_type.Item("display_type") = "Canceled"
            '    tbl_TrnOrder_Status.Rows.InsertAt(row_type, 1)
            'End If

            'Me.cboSearchStatus.DataSource = tbl_TrnOrder_Status
            'Me.cboSearchStatus.ValueMember = "value_type"
            'Me.cboSearchStatus.DisplayMember = "display_type"

            'Me.cboSearchStatus.SelectedValue = 0

            If Me._PROGRAMTYPE = "PG" Then
                Me.lblProgType.Text = "PROGRAM"
                'Me.btnAddItem.Enabled = False
            ElseIf Me._PROGRAMTYPE = "NP" Then
                Me.lblProgType.Text = "NON PROGRAM"
                'Me.btnAddItem.Enabled = True
            End If

            Me.DgvTrnOrder.DataSource = Me.tbl_TrnOrder

            Me.BindingStop()
            Me.BindingStart()
            Me.uiTrnRentalOrder3_Lock()
            Me.uiTrnRentalOrder3_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True

            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED

            Me.cboSearchChannel.SelectedValue = Me._CHANNEL

            'Application Info
            'Me.txt_usrname.Text = Me.UserName
            'Me.txt_channel_id.Text = Me._CHANNEL
            'Me.obj_Order_source.Text = Me._ORDERTYPE_ID

            Me.ReservedItem = False
            Me.InitLayoutUI()
        End If
        

    End Sub
    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlatTabMain.SelectedIndexChanged
        Select Case FlatTabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.White
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro
                Me.ftabDataDetil.SelectedIndex = 0
                Me.NewData = False
            Case 1
                If Me._FORMMODE = "ENTRY" Then
                    Me.tbtnSave.Enabled = True

                    If Me._PROGRAMTYPE = "PG" Then
                        Me.btnAddItem.Enabled = False
                    Else
                        Me.btnAddItem.Enabled = True
                    End If

                    Me.tbtnDel.Enabled = True
                    Me.tbtnLoad.Enabled = False
                    Me.tbtnQuery.Enabled = False
                ElseIf Me._FORMMODE = "VIEW" Then
                    Me.tbtnSave.Enabled = False
                    Me.btnAddItem.Enabled = False
                    Me.tbtnDel.Enabled = False
                    Me.tbtnLoad.Enabled = False
                    Me.tbtnQuery.Enabled = False
                End If

                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then
                    If NewData = False Then
                        Me.uiTrnRentalOrder3_OpenRow(Me.DgvTrnOrder.CurrentRow.Index)
                    End If
                Else
                    Me.uiTrnRentalOrder3_NewData()
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
    'Private Sub DgvTrnOrderdetil_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOrderdetil.CellFormatting
    '    Dim dgv As DataGridView = sender
    '    Dim objRow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

    '    If dgv.RowCount > 1 Then
    '        If Me._ORDER_SOURCE = "Manual" Then
    '            objRow.Cells("orderdetil_qty").ReadOnly = False
    '            objRow.Cells("orderdetil_foreign").ReadOnly = False
    '            'objRow.Cells("budgetdetil_name").ReadOnly = False
    '        Else
    '            objRow.Cells("orderdetil_qty").ReadOnly = True
    '            objRow.Cells("orderdetil_foreign").ReadOnly = True
    '            'objRow.Cells("budgetdetil_name").ReadOnly = True
    '        End If

    '        'If objRow.Cells("currency_id").Value = 1 Then       'IDR

    '        'Else

    '        'End If

    '    End If

    'End Sub
    Private Sub DgvTrnOrderdetil_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrderdetil.CellClick
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dlgSelectTrnBudget As dlgSelectTrnBudget = New dlgSelectTrnBudget(Me.DSN)
        Dim retObj As Integer
        Dim jenisBudget As String = ""
        Dim budget_id As Decimal
        Dim remark As String = ""
        Dim tbl_budgetSum As DataTable = New DataTable

        Dim tblTrnBudgetCopyResult As DataTable = clsDataset2.CreateTblTrnBudget
        Dim tblTrnBudgetCopyResultDetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil

        Dim DgvTrnOrderdetilRowsCount As Integer
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        tbl_budgetSum.Clear()

        If Me._ORDER_SOURCE = "ML" Then
            DgvTrnOrderdetilRowsCount = Me.DgvTrnOrderdetil.Rows.Count - 1
        Else
            DgvTrnOrderdetilRowsCount = Me.DgvTrnOrderdetil.Rows.Count
        End If

        If e.RowIndex < 0 Then 'Or e.RowIndex = DgvTrnOrderdetilRowsCount Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case Me.DgvTrnOrderdetil.Columns("btn_budget").Index
                If e.RowIndex < 0 Then
                    Exit Sub
                End If

                jenisBudget = "header"
                retObj = dlgSelectTrnBudget.OpenDialog(Me, Me._CHANNEL, jenisBudget)

                'Tampilkan jika ingin mengaktif button orderdetil
            Case Me.DgvTrnOrderdetil.Columns("btn_budgetdetil").Index
                If Me._ORDER_SOURCE = "ML" Then
                    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budget_id").Value = Me.cbo_Budget_name.SelectedValue

                    If e.RowIndex < 0 Then
                        Exit Sub
                    End If

                    If Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budget_id").Value IsNot System.DBNull.Value Then
                        jenisBudget = "detil"
                        budget_id = Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budget_id").Value 'Me.DgvTrnOrderdetil.CurrentRow.Cells("budget_id").Value
                        retObj = dlgSelectTrnBudget.OpenDialogDetil(budget_id, Me, Me._CHANNEL, jenisBudget)
                    End If
                End If

            Case Me.DgvTrnOrderdetil.Columns("orderdetil_daysbutton").Index
                If Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_daysbutton").ReadOnly = False Then
                    Dim obj As SelectDaysDialogReturn
                    Dim orderdetil_line As Integer = Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_line").Value
                    Dim orderdetil_descr As String = clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_descr").Value, "")
                    Dim orderdetil_foreign As Decimal = Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_foreign").Value
                    Dim orderdetil_qty As Decimal = Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_qty").Value
                    Dim item_id As String = Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("item_id").Value

                    obj = Me.dlgTrnRentalOrder_Open(orderdetil_line, orderdetil_descr, orderdetil_foreign, orderdetil_qty, item_id)

                    'If obj IsNot Nothing Then
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_descr").Value = obj.orderdetil_descr
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_foreign").Value = obj.orderdetil_idr
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_qty").Value = obj.orderdetil_qty
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_days").Value = obj.orderdetil_days
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("item_id").Value = obj.item_id
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("currency_id").Value = 1
                    '    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_foreignrate").Value = 1
                    'End If

                    'Me.DgvTrnOrderdetiluse.DataSource = Me.tbl_TrnOrderdetiluse
                    'Me.tbl_TrnOrderdetiluse.DefaultView.RowFilter = "orderdetiluse_checked=1"
                    'Me.tbl_TrnOrderdetiluse.DefaultView.Sort = "orderdetil_line"

                    'Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
                    'Me.uiTrnRentalOrder3_TotalCalculate()
                End If

        End Select

        If Not retObj = Nothing Then
            Me.BindingStop()

            If jenisBudget = "header" Then
                Me.DataFill(tblTrnBudgetCopyResult, "bg_TrnBudget_Select", "budget_id = " & retObj, "channel_id = " & Me._CHANNEL) ' & retObj)
                If tblTrnBudgetCopyResult.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budget_id").Value = tblTrnBudgetCopyResult.Rows(0).Item("budget_id")
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_id").Value = 0
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_name").Value = ""
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_amount").Value = ""
                End If
            ElseIf jenisBudget = "detil" Then
                Me.DataFill(tblTrnBudgetCopyResultDetil, "pr_TrnBudgetdetil_Select", "budgetdetil_id = " & retObj) ' & retObj)
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_id").Value = tblTrnBudgetCopyResultDetil.Rows(0).Item("budgetdetil_id")
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_amount").Value = tblTrnBudgetCopyResultDetil.Rows(0).Item("budgetdetil_amount")

                'Me.DataFill(tbl_budgetSum, "pr_TrnOrderdetil_AmountSum", "budgetdetil_id = " & retObj & " AND ordertype_id = '" & Me._ORDERTYPE_ID & "'") ' & retObj)
                oDataFiller.DataFillBudgetdetilAmount(tbl_budgetSum, "cq_TrnOrderdetil_AmtSum", budget_id, retObj)
                If tbl_budgetSum.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_amountsum").Value = tbl_budgetSum.Rows(0).Item("amount_sum")
                Else : Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_amountsum").Value = 0
                End If

                Dim budgetdetil_outstd = _
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_amount").Value _
                 - Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_amountsum").Value

                'bgtAmount_value.Add(Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_amount").Value)
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_outstd").Value = budgetdetil_outstd
                If budgetdetil_outstd < 0 Then
                    remark = "Over Budget"
                Else : remark = "OK"
                End If
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_remark").Value = remark
            End If
        End If

    End Sub
    Private Sub DgvTrnOrderdetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOrderdetil.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If dgv.RowCount > 0 Then
                If objRow.Cells("budgetdetil_remark").Value = "OK" Then
                    objRow.DefaultCellStyle.ForeColor = Color.Black

                ElseIf objRow.Cells("budgetdetil_remark").Value = "OVER BUDGET" Then
                    objRow.DefaultCellStyle.ForeColor = Color.Red
                Else
                    objRow.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgvTrnOrderdetil_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrderdetil.CellValueChanged
        Dim dgv As DataGridView = sender
        Dim colName As String = dgv.Columns(e.ColumnIndex).Name
        Dim tbl_Budget As DataTable = clsDataset2.CreateTblTrnBudget
        Dim tbl_Budgetdetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil
        Dim budget_id As Integer
        Dim budgetdetil_id As Integer
        Dim rowIndex As Integer = e.RowIndex
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        budget_id = clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(rowIndex).Cells("budget_id").Value, 0)

        tbl_Budget.Clear()
        tbl_Budgetdetil.Clear()

        Select Case e.ColumnIndex
            Case Me.DgvTrnOrderdetil.Columns("budget_id").Index
                oDataFiller.DataFill(tbl_Budget, "pr_TrnBudget_Select", String.Format("budget_id = {0}", budget_id))
                If tbl_Budget.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budget_name").Value = tbl_Budget.Rows(0).Item("budget_name")
                End If
            Case Me.DgvTrnOrderdetil.Columns("budgetdetil_id").Index
                budgetdetil_id = Me.DgvTrnOrderdetil.Rows(rowIndex).Cells("budgetdetil_id").Value
                oDataFiller.DataFill(tbl_Budgetdetil, "pr_TrnBudgetdetil_Select", String.Format("budgetdetil_id = {0}", budgetdetil_id))
                If tbl_Budgetdetil.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budgetdetil_name").Value = tbl_Budgetdetil.Rows(0).Item("budgetdetil_desc")
                End If
        End Select

        If (colName = "orderdetil_idr" Or colName = "orderdetil_days" Or colName = "orderdetil_qty" Or colName = "orderdetil_discount" Or colName = "orderdetil_foreign" Or colName = "orderdetil_foreignrate") Then
            Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
            Me.uiTrnRentalOrder3_TotalCalculate()

            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
        End If
    End Sub
    Private Sub DgvTrnOrderdetil_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvTrnOrderdetil.RowsRemoved
        Dim dgv As DataGridView = sender
        If dgv.Rows.Count > 0 Then
            Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
            Me.uiTrnRentalOrder3_TotalCalculate()
            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()

        End If
    End Sub
    Private Sub obj_Order_pph_percent_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.uiTrnRentalOrder3_TotalCalculate()
    End Sub
    Private Sub obj_Order_ppn_percent_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.uiTrnRentalOrder3_TotalCalculate()
    End Sub
    Private Sub btn_FindBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim popUpFind As frmPopUpFind

        popUpFind = New frmPopUpFind(Me.DSN, "BUDGET", 1, "Budget", " ")

        popUpFind.ShowDialog()
    End Sub
    Private Function dlgTrnRentalOrder_Open(ByRef orderdetil_line As Integer, ByRef orderdetil_descr As String, ByRef orderdetil_idr As Decimal, ByRef orderdetil_qty As Decimal, ByRef item_id As String) As SelectDaysDialogReturn
        Dim frmSelectDays As dlgTrnRentalOrder_SelectDays_2 = New dlgTrnRentalOrder_SelectDays_2()
        Dim obj As SelectDaysDialogReturn
        Dim datestart As Date
        Dim dateend As Date
        Dim setdate As Date

        frmSelectDays.ShowInTaskbar = False
        frmSelectDays.StartPosition = FormStartPosition.CenterParent
        frmSelectDays.FormBorderStyle = FormBorderStyle.FixedDialog
        frmSelectDays.MinimizeBox = False
        frmSelectDays.MaximizeBox = False

        'If Me.obj_Order_usagedatestart.Text <> "" And Me.obj_Order_usagedateend.Text <> "" Then
        'datestart = Me.obj_Order_usagedatestart.Value.ToShortDateString
        'dateend = Me.obj_Order_usagedateend.Value.ToShortDateString

        'If Me.tbl_TrnOrder_Temp.Rows.Count > 0 Then
        '    setdate = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_setdate")
        '    datestart = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_utilizeddatestart")
        '    dateend = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_utilizeddateend")
        'Else
        '    setdate = Me.dtp_Order_setdate.Value.ToShortDateString
        '    datestart = Me.dtp_Order_utilizeddatestart.Value.ToShortDateString
        '    dateend = Me.dtp_Order_utilizeddateend.Value.ToShortDateString
        'End If

        obj = frmSelectDays.OpenDialog(Me.tbl_TrnOrderdetiluse, Me.tbl_MstItem, setdate, datestart, dateend, orderdetil_line, orderdetil_descr, orderdetil_idr, orderdetil_qty, item_id, Me)
        'If obj IsNot Nothing Then
        '    Me.dtp_Order_setdate.Value = obj.order_setdate.ToShortDateString
        '    Me.dtp_Order_utilizeddatestart.Value = obj.order_utilizeddatestart.ToShortDateString
        '    Me.dtp_Order_utilizeddateend.Value = obj.order_utilizeddateend.ToShortDateString
        'End If

        'Dim tblChanges As DataTable = Me.tbl_TrnOrderdetiluse.GetChanges()
        'If tblChanges IsNot Nothing Then
        '    'MessageBox.Show(tblChanges.Rows.Count)
        'End If

        Return obj

    End Function
    Private Sub obj_Budget_id_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Budget_id.Validated
        Me.cbo_Budget_name.SelectedValue = Me.obj_Budget_id.Text
        Me.obj_Order_prognm.Text = Me.cbo_Budget_name.Text
    End Sub
    Private Sub cbo_Budget_name_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Budget_name.SelectionChangeCommitted
        Dim i, j As Integer

        Me.obj_Budget_id.Text = Me.cbo_Budget_name.SelectedValue
        Me.obj_Order_prognm.Text = Me.cbo_Budget_name.Text

        If Me.tbl_TrnOrderdetil.Rows.Count > 0 Then
            For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                Me.tbl_TrnOrderdetil.Rows(i).Item("budget_id") = Me.cbo_Budget_name.SelectedValue
            Next
        End If
        Me.IsiBudgetName()

        If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
            For j = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
                Me.DgvTrnOrderdetil.Rows(j).Cells("budget_id").Value = Me.cbo_Budget_name.SelectedValue
                Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_id").Value = 0
                Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_name").Value = ""
                'Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_amount").Value = ""
            Next
        End If

    End Sub
    Private Sub cbo_Budget_name_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Budget_name.Validated
        'Dim i, j As Integer

        'Me.obj_Budget_id.Text = Me.cbo_Budget_name.SelectedValue
        'Me.obj_Order_prognm.Text = Me.cbo_Budget_name.Text

        'If Me.tbl_TrnOrderdetil.Rows.Count > 0 Then
        '    For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
        '        Me.tbl_TrnOrderdetil.Rows(i).Item("budget_id") = Me.cbo_Budget_name.SelectedValue
        '    Next
        'End If
        'Me.IsiBudgetName()

        'If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
        '    For j = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
        '        Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_id").Value = 0
        '        Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_name").Value = ""
        '        Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_amount").Value = ""
        '    Next
        'End If

    End Sub
    Private Function IsiBudgetName() As Boolean
        'Dim tbl_Budget As DataTable = clsDataset2.CreateTblTrnBudget
        'Dim tbl_Budgetdetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil
        'Dim budget_id As Integer
        'Dim budgetdetil_id As Integer
        'Dim rowIdx As Integer
        'Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        'Dim tbl_budgetSum As DataTable = New DataTable
        'Dim remark As String = ""

        'Try
        '    If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
        '        For rowIdx = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
        '            budget_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value
        '            budgetdetil_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value

        '            tbl_Budget.Clear()
        '            tbl_Budgetdetil.Clear()
        '            tbl_budgetSum.Clear()

        '            oDataFiller.DataFill(tbl_Budget, "pr_TrnBudget_Select", String.Format("budget_id = {0}", budget_id))
        '            oDataFiller.DataFill(tbl_Budgetdetil, "pr_TrnBudgetdetil_Select", String.Format("budgetdetil_id = {0}", budgetdetil_id))

        '            If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
        '                If Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_type").Value = "Item" Then
        '                    If tbl_Budget.Rows.Count > 0 Then
        '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_name").Value = tbl_Budget.Rows(0).Item("budget_name")
        '                    End If
        '                    If tbl_Budgetdetil.Rows.Count > 0 Then
        '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_name").Value = tbl_Budgetdetil.Rows(0).Item("budgetdetil_desc")
        '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value = tbl_Budgetdetil.Rows(0).Item("budgetdetil_amount")
        '                        'Dim outstd_budget = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_rowtotal").Value - Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value

        '                        'Me.DataFill(tbl_budgetSum, "pr_TrnOrderdetil_AmountSum", "budgetdetil_id = " & budgetdetil_id & " AND ordertype_id = '" & Me._ORDERTYPE_ID & "'") ' & retObj)
        '                        'Me.DataFill(tbl_budgetSum, "pr_TrnOrderdetil_AmountSum", "budgetdetil_id = " & budgetdetil_id)
        '                        ''''Me.DataFill2(tbl_budgetSum, "pr_TrnOrderdetil_AmtSum", budget_id, budgetdetil_id)
        '                        oDataFiller.DataFillBudgetdetilAmount(tbl_budgetSum, "cq_TrnOrderdetil_AmtSum", budget_id, budgetdetil_id)
        '                        If tbl_budgetSum.Rows.Count > 0 Then
        '                            Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value = tbl_budgetSum.Rows(0).Item("amount_sum")
        '                        Else : Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value = 0
        '                        End If

        '                        Dim budgetdetil_outstd = _
        '                                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value _
        '                                         - Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value

        '                        'bgtAmount_value.Add(Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value)
        '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_outstd").Value = budgetdetil_outstd
        '                        If budgetdetil_outstd < 0 Then
        '                            remark = "Over Budget"
        '                            'DgvTrnOrderdetil.Rows(rowIdx).Cells(rowIdx).Style.ForeColor = Color.Red
        '                        Else : remark = "OK"
        '                        End If
        '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = remark
        '                        If DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = "Over Budget" Then
        '                            Dim i As Integer
        '                            For i = 0 To DgvTrnOrderdetil.ColumnCount - 1
        '                                DgvTrnOrderdetil.Rows(rowIdx).Cells(i).Style.ForeColor = Color.Red

        '                            Next
        '                        End If

        '                        'Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_outstd").Value = outstd_budget
        '                        'Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value = bgtAmount_value.Item(rowIdx)
        '                    End If
        '                End If
        '            End If
        '        Next
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Dim order_id As String
        Dim rowIdx As Integer
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim tbl_budgetSum As DataTable = New DataTable
        Dim tbl_distinctbudget As DataTable = New DataTable
        Dim remark As String = ""

        Try
            If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
                tbl_distinctbudget.Clear()
                order_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("order_id").Value
                oDataFiller.DataFill(tbl_distinctbudget, "test_order2", String.Format("order_id = '{0}' and orderdetil_type='Item'", order_id))
                For rowIdx = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
                    tbl_budgetSum.Clear()
                    If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
                        If Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_type").Value = "Item" Then

                            Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_name").Value = clsUtil.GetDataFromDatatable2(tbl_distinctbudget, "budget_id", "budget_name", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value, "budgetdetil_id", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value)
                            'End If
                            If tbl_distinctbudget.Rows.Count > 0 Then
                                Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_name").Value = clsUtil.GetDataFromDatatable2(tbl_distinctbudget, "budget_id", "budgetdetil_name", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value, "budgetdetil_id", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value)
                                Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value = clsUtil.GetDataFromDatatable2(tbl_distinctbudget, "budget_id", "budgetdetil_amount", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value, "budgetdetil_id", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value)
                                If tbl_distinctbudget.Rows.Count > 0 Then
                                    Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value = clsUtil.GetDataFromDatatable2(tbl_distinctbudget, "budget_id", "amount_sum", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value, "budgetdetil_id", Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value)
                                Else : Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value = 0
                                End If

                                Dim budgetdetil_outstd = _
                                                Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value _
                                                 - Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value

                                'bgtAmount_value.Add(Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value)
                                Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_outstd").Value = budgetdetil_outstd
                                If budgetdetil_outstd < 0 Then
                                    remark = "Over Budget"
                                    'DgvTrnOrderdetil.Rows(rowIdx).Cells(rowIdx).Style.ForeColor = Color.Red
                                Else : remark = "OK"
                                End If
                                Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = remark
                                If DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = "Over Budget" Then
                                    Dim i As Integer
                                    For i = 0 To DgvTrnOrderdetil.ColumnCount - 1
                                        DgvTrnOrderdetil.Rows(rowIdx).Cells(i).Style.ForeColor = Color.Red
                                    Next
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    'Private Function GetBudgetDetilInfo() As Boolean
    '    Dim tbl_Budgetdetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil
    '    Dim tbl_BudgetSum As DataTable = New DataTable

    '    Dim budget_id As Integer
    '    Dim budgetdetil_id As Integer
    '    Dim rowIdx As Integer
    '    Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
    '    Dim remark As String = ""

    '    Try
    '        If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
    '            For rowIdx = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
    '                budget_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value
    '                budgetdetil_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value

    '                tbl_budgetSum.Clear()

    '                'If Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_type").Value = "Item" Or _
    '                '        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_type").Value = "" Then
    '                If Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_type").Value = "Item" Then

    '                    Me.DataFill(tbl_Budgetdetil, "pr_TrnBudgetdetil_Select", String.Format("budgetdetil_id = {0}", budgetdetil_id))
    '                    If tbl_Budgetdetil.Rows.Count > 0 Then
    '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value = tbl_Budgetdetil.Rows(0).Item("budgetdetil_amount")
    '                    Else : Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value = 0
    '                    End If

    '                    Me.DataFill(tbl_BudgetSum, "pr_TrnOrderdetil_AmountSum", "budgetdetil_id = " & budgetdetil_id)
    '                    If tbl_BudgetSum.Rows.Count > 0 Then
    '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value = tbl_BudgetSum.Rows(0).Item("amount_sum")
    '                    Else : Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value = 0
    '                    End If

    '                    Dim budgetdetil_outstd = _
    '                                    Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_amount").Value _
    '                                     - Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_amountsum").Value
    '                    Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_outstd").Value = budgetdetil_outstd

    '                    If budgetdetil_outstd < 0 Then
    '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = "Over Budget"
    '                        Dim i As Integer
    '                        For i = 0 To DgvTrnOrderdetil.ColumnCount - 1
    '                            Me.DgvTrnOrderdetil.Rows(rowIdx).Cells(i).Style.ForeColor = Color.Red
    '                        Next
    '                    Else
    '                        Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = "OK"
    '                    End If

    '                    'Dim i As Integer
    '                    'If DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_remark").Value = "Over Budget" Then
    '                    '    For i = 0 To DgvTrnOrderdetil.ColumnCount - 1
    '                    '        DgvTrnOrderdetil.Rows(rowIdx).Cells(i).Style.ForeColor = Color.Red
    '                    '    Next
    '                    'End If

    '                End If

    '            Next
    '        End If
    '    Catch ex As Exception

    '    Finally

    '    End Try

    '    Me.tbl_TrnOrderdetil.RejectChanges()

    'End Function
    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.Gainsboro
            'Me.ftabDataDetil.TabPages.Item(i).Font.Style = FontStyle.Regular
        Next
        activetab = Me.ftabDataDetil.SelectedIndex
        Me.ftabDataDetil.TabPages.Item(activetab).BackColor = Color.White
        'Me.ftabDataDetil.TabPages.Item(activetab).Font.Style = FontStyle.Bold
        If Me.obj_Order_id.Text <> "" Then
            Try
                dbConn.Open()
                If Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_DocCRC" Then
                    'Me.uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                    Me.uiTrnRentalOrder3OpenRow_DocCirc(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                    'Me.uiTrnPurchaseOrder3OpenRow_Episode(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                ElseIf Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_InvRec" Then
                    Me.uiTrnRentalOrder3OpenRow_InvReceipt(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                ElseIf Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_Advance" Then
                    Me.uiTrnRentalOrder3OpenRow_Advance(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                ElseIf Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_Episode" Then
                    Me.uiTrnRentalOrder3OpenRow_Episode(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                End If

            Catch ex As Exception
                Throw New Exception(mUiName & ": _OpenRowDetil()" & vbCrLf & ex.Message)
            End Try
            dbConn.Close()
        End If
    End Sub
    Private Sub obj_Order_canceled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Order_canceled.CheckedChanged

        If Me.chk_Order_canceled.Checked = True Then
            Me.PnlDataMaster.Enabled = False
            Me.PnlDataFooter_Total.Enabled = False
            Me.obj_Order_descr.Enabled = False

            Me.PnlDataMaster1.Enabled = False
            Me.PnlDataMaster2.Enabled = False
            Me.ftabDataDetil_Detil.Enabled = False
            Me.ftabDataDetil_Info.Enabled = False
            Me.ftabDataDetil_PaymReq.Enabled = False
            Me.ftabDataDetil_RentReq.Enabled = False
            Me.ftabDataDetil_Sign.Enabled = False
            Me.ftabDataDetil_SPK.Enabled = False
            Me.ftabDataDetil_UtilizedItems.Enabled = False

            Me.tbtnDel.Enabled = False
            Me.tbtnEdit.Enabled = False
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False
            Me.btnApp.Enabled = False

            Dim i As Integer
            For i = 0 To Me.DgvTrnRequestdetil.Rows.Count - 1
                Me.DgvTrnRequestdetil.Rows(i).Cells("requestdetil_ordered").Value = False
            Next

        Else
            Me.PnlDataMaster.Enabled = True
            Me.PnlDataFooter_Total.Enabled = True
            Me.obj_Order_descr.Enabled = True

            Me.PnlDataMaster1.Enabled = True
            Me.PnlDataMaster2.Enabled = True
            Me.ftabDataDetil_Detil.Enabled = True
            Me.ftabDataDetil_Info.Enabled = True
            Me.ftabDataDetil_PaymReq.Enabled = True
            Me.ftabDataDetil_RentReq.Enabled = True
            Me.ftabDataDetil_Sign.Enabled = True
            Me.ftabDataDetil_SPK.Enabled = True
            Me.ftabDataDetil_UtilizedItems.Enabled = True

            Me.tbtnDel.Enabled = True
            Me.tbtnEdit.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
            Me.btnApp.Enabled = True

            Dim i As Integer
            For i = 0 To Me.DgvTrnRequestdetil.Rows.Count - 1
                Me.DgvTrnRequestdetil.Rows(i).Cells("requestdetil_ordered").Value = True
            Next

        End If
    End Sub
    Private Sub obj_Order_setlocation_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Order_setlocation.Validated
        Me.obj_Order_utilizedlocation.Text = Me.obj_Order_setlocation.Text
    End Sub
    Private Sub lnkSPKGen_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSPKGen.LinkClicked
        Me.uiTrnRentalOrder3_SPKGen(Me.DgvTrnOrderdetil, Me.SPKWorktype)
    End Sub
    Private Sub obj_Order_descr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Order_descr.TextChanged
        Dim i As Integer
        Dim j, rMaxLine As Byte

        Try
            i = 2000 - Me.obj_Order_descr.Text.Length
            If i <= 0 Then
                Me.obj_Order_descr.Text = Mid(Me.obj_Order_descr.Text, 1, 2000)
            End If

            rMaxLine = 36 - Math.Ceiling(Me.DgvTrnOrderdetil.RowCount * 1.5)
            j = rMaxLine - Me.obj_Order_descr.Lines.Length
            Me.Label2.Text = "Chars Left: " & i & " // Lines Left: " & j

        Catch ex As Exception

        End Try
    End Sub
    Private Function uiTrnRentalOrder3_SetViewOnly() As Boolean
        'NavigationButton
        Me.tbtnDel.Enabled = False
        Me.tbtnEdit.Enabled = False
        Me.tbtnNew.Enabled = False
        Me.tbtnPrint.Enabled = True
        Me.tbtnPrintPreview.Enabled = True
        Me.tbtnSave.Enabled = False
        Me.btnAddItem.Enabled = False
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

        Me.obj_Order_prognm.ReadOnly = True
        Me.obj_Order_prognm.BackColor = Color.White
        Me.obj_Order_prognm.ForeColor = Color.Black

        'Me.obj_Order_eps.ReadOnly = True
        'Me.obj_Order_eps.BackColor = Color.White
        'Me.obj_Order_eps.ForeColor = Color.Black

        Me.cbo_Order_progsch.Enabled = False
        Me.gboRevision.Enabled = False

        'PnlDataMaster3
        Me.dtp_Order_setdate.Enabled = False
        Me.dtp_Order_utilizeddatestart.Enabled = False
        Me.dtp_Order_utilizeddateend.Enabled = False

        Me.mtb_Order_settime.ReadOnly = True
        Me.mtb_Order_settime.BackColor = Color.White
        Me.mtb_Order_settime.ForeColor = Color.Black

        Me.mtb_Order_utilizedtimestart.ReadOnly = True
        Me.mtb_Order_utilizedtimestart.BackColor = Color.White
        Me.mtb_Order_utilizedtimestart.ForeColor = Color.Black

        Me.mtb_Order_utilizedtimeend.ReadOnly = True
        Me.mtb_Order_utilizedtimeend.BackColor = Color.White
        Me.mtb_Order_utilizedtimeend.ForeColor = Color.Black

        Me.obj_Order_setlocation.ReadOnly = True
        Me.obj_Order_setlocation.BackColor = Color.White
        Me.obj_Order_setlocation.ForeColor = Color.Black

        Me.obj_Order_utilizedlocation.ReadOnly = True
        Me.obj_Order_utilizedlocation.BackColor = Color.White
        Me.obj_Order_utilizedlocation.ForeColor = Color.Black

        'PnlDataFooter1
        Me.obj_Order_descr.ReadOnly = True
        Me.obj_Order_descr.BackColor = Color.White
        Me.obj_Order_descr.ForeColor = Color.Black

        Me.chk_Order_canceled.Enabled = False

        Me.calc_Order_subdiscount.ReadOnly = True
        Me.calc_Order_subdiscount.BackColor = Color.White
        Me.calc_Order_subdiscount.ForeColor = Color.Black

        Me.obj_Order_pph_percent.ReadOnly = True
        Me.obj_Order_pph_percent.BackColor = Color.White
        Me.obj_Order_pph_percent.ForeColor = Color.Black

        Me.obj_Order_ppn_percent.ReadOnly = True
        Me.obj_Order_ppn_percent.BackColor = Color.White
        Me.obj_Order_ppn_percent.ForeColor = Color.Black

        'If clsUtil.IsDbNull(Me.tbl_MstUser.Rows(0).Item("user_isauthorized_toapprove"), 0) = 1 Then

        Me.DgvTrnOrderdetil.Enabled = True
        Me.DgvTrnOrderPaymReq.Enabled = True
        'Else

        Me.DgvTrnOrderdetil.Enabled = True
        Me.DgvTrnOrderdetiluse.Enabled = True
        Me.DgvTrnOrderPaymReq.Enabled = True
        Me.DgvTrnRequestdetil.Enabled = True


        Me.obj_Order_spkdesc.ReadOnly = True
        Me.lnkSPKGen.Enabled = False
        Me.obj_Order_spkrequired.Enabled = False
        Me.obj_Order_spkworktype.Enabled = False

    End Function

    Private Function uiTrnRentalOrder3_Lock() As Boolean


        'PnlDataMaster1
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.BackColor = Color.Coral
        Me.obj_Order_id.ForeColor = Color.Black

        Me.obj_Request_id.ReadOnly = True
        Me.obj_Request_id.BackColor = Color.White
        Me.obj_Request_id.ForeColor = Color.Black

        'Me.cbo_Periode_id.Enabled = False
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

        Me.obj_Order_prognm.ReadOnly = True
        Me.obj_Order_prognm.BackColor = Color.White
        Me.obj_Order_prognm.ForeColor = Color.Black

        'Me.obj_Order_eps.ReadOnly = True
        'Me.obj_Order_eps.BackColor = Color.White
        'Me.obj_Order_eps.ForeColor = Color.Black

        Me.obj_Order_epsstart.ReadOnly = True
        Me.obj_Order_epsstart.BackColor = Color.White
        Me.obj_Order_epsstart.ForeColor = Color.Black

        Me.obj_Order_epsend.ReadOnly = True
        Me.obj_Order_epsend.BackColor = Color.White
        Me.obj_Order_epsend.ForeColor = Color.Black


        Me.cbo_Order_progsch.Enabled = True
        Me.gboRevision.Enabled = False

        Me.cbo_Currency.Enabled = False

        'PnlDataMaster3
        Me.dtp_Order_setdate.Enabled = False
        Me.dtp_Order_utilizeddatestart.Enabled = False
        Me.dtp_Order_utilizeddateend.Enabled = False

        Me.mtb_Order_settime.ReadOnly = True
        Me.mtb_Order_settime.BackColor = Color.White
        Me.mtb_Order_settime.ForeColor = Color.Black

        Me.mtb_Order_utilizedtimestart.ReadOnly = True
        Me.mtb_Order_utilizedtimestart.BackColor = Color.White
        Me.mtb_Order_utilizedtimestart.ForeColor = Color.Black

        Me.mtb_Order_utilizedtimeend.ReadOnly = True
        Me.mtb_Order_utilizedtimeend.BackColor = Color.White
        Me.mtb_Order_utilizedtimeend.ForeColor = Color.Black

        Me.obj_Order_setlocation.ReadOnly = True
        Me.obj_Order_setlocation.BackColor = Color.White
        Me.obj_Order_setlocation.ForeColor = Color.Black

        Me.obj_Order_utilizedlocation.ReadOnly = True
        Me.obj_Order_utilizedlocation.BackColor = Color.White
        Me.obj_Order_utilizedlocation.ForeColor = Color.Black


        'Me.chk_Order_canceled.Enabled = True

        Me.calc_Order_subdiscount.ReadOnly = True
        Me.calc_Order_subdiscount.BackColor = Color.White
        Me.calc_Order_subdiscount.ForeColor = Color.Black

        Me.obj_Order_pph_percent.ReadOnly = True
        Me.obj_Order_pph_percent.BackColor = Color.White
        Me.obj_Order_pph_percent.ForeColor = Color.Black

        Me.obj_Order_ppn_percent.ReadOnly = True
        Me.obj_Order_ppn_percent.BackColor = Color.White
        Me.obj_Order_ppn_percent.ForeColor = Color.Black


    End Function
    Private Sub DgvTrnOrder_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOrder.CellFormatting
        Dim objRow As System.Windows.Forms.DataGridViewRow = DgvTrnOrder.Rows(e.RowIndex)
        Dim a As Boolean = objRow.Cells("order_canceled").Value

        If objRow.Cells("order_approved2").Value = 0 And objRow.Cells("order_canceled").Value = False Then
            objRow.DefaultCellStyle.BackColor = Color.White
        ElseIf objRow.Cells("order_approved2").Value = 1 And objRow.Cells("order_canceled").Value = False Then
            objRow.DefaultCellStyle.BackColor = Color.LightCyan
        ElseIf objRow.Cells("order_approved2").Value = 2 And objRow.Cells("order_canceled").Value = False Then
            objRow.DefaultCellStyle.BackColor = Color.LightYellow
        Else
            objRow.DefaultCellStyle.BackColor = Color.MistyRose
        End If
    End Sub
    Private Sub uiTrnRentalOrder3_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.obj_Order_descr.Size = New System.Drawing.Point(Me.PnlDataFooter.Size.Width - Me.PnlDataFooter_Total.Size.Width - 20, 63)
        Me.Label2.Location = New System.Drawing.Point(Me.obj_Order_descr.Width - Me.Label2.Width, 7)
    End Sub
    Private Sub uiTrnRentalOrder3_LoadDataCombo()
        Dim criteria As String = ""

        Me.tbl_MstUnit.Clear()
        Me.tbl_MstChannel.Clear()
        Me.tbl_MstCurrency.Clear()
        Me.tbl_TrnBudget.Clear()
        Me.tbl_MstRekanan.Clear()
        Me.tbl_MstItem.Clear()
        Me.tbl_MstProgram.Clear()
        Me.tbl_mstStrukturUnit.Clear()

        Try
            Me.DataFill(Me.tbl_MstUnit, "pr_MstUnit_Select", criteria)
            Me.tbl_MstUnit.DefaultView.Sort = "unit_name"

            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")
            Me.ComboFill(Me.cbo_Deptname, "strukturunit_id", "strukturunit_name", Me.tbl_mstStrukturUnit, "ms_MstStrukturUnit_Select", "")

            Me.ComboFill(Me.cbo_Periode_id, "periode_id", "periode_name", Me.tbl_MstPeriode, "pr_MstPeriode_Select", "")
            Me.ComboFill(Me.cbo_Budget_name, "budget_id", "budget_name", Me.tbl_TrnBudget, "pr_TrnBudget_Select", "")

            Me.ComboFill(Me.cbo_Rekanan_name, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")
            'Me.ComboFillFromDataTable(Me.cboSearchRekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan)

            Me.DataFill(Me.tbl_MstItem, "pr_MstItem_Select", criteria)
            Me.tbl_MstItem.DefaultView.Sort = "item_name"
            Me.ComboFill(Me.cbo_old_program_name, "old_program_id", "program_name", Me.tbl_MstProgram, "pr_MstRentalprogram_Select", "")

            Me.tbl_MstCurrency.Clear()
            Me.DataFill(Me.tbl_MstCurrency, "pr_MstCurrency_Select", criteria)
            Me.tbl_MstCurrency.DefaultView.Sort = "currency_shortname"
            Me.ComboFill(Me.cbo_Currency, "currency_id", "currency_shortname", Me.tbl_MstCurrency, "pr_MstCurrency_Select", "")

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
    End Sub
    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        Me.uiTrnRentalOrder3_GetOrderSource()
        'Me.ConfirmSaveAddItem("Add")

        'Me.uiTrnRentalOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
        'Me.uiTrnRentalOrder3_TotalCalculate()
    End Sub

    Private Sub btnVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVendor.Click
        Dim dlg As dlgSelectVendor = New dlgSelectVendor(Me.DSN)
        'dlg.OpenDialog(Me)
        Dim rekanan_id As String
        rekanan_id = dlg.OpenDialog(Me)
        Me.rekananidtxt.Text = rekanan_id
    End Sub


    Private Sub DgvTrnOrder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvTrnOrder.SelectionChanged
        ''MsgBox("a")  Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        ' Dim channel_id As String = ""
        Dim i As Integer

        'frmPrint.StartPosition = FormStartPosition.CenterParent

        'If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
        '    MsgBox("Pilih data dulu..")
        '    Exit Sub
        'End If

        'ambil row yang dipilih di datagrid
        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
            row = Me.DgvTrnOrder.SelectedRows(i)
            order_id = row.Cells("order_id").Value
            ' channel_id = row.Cells("channel_id").Value

            If Me.DgvTrnOrder.Rows.Count > 0 Then
                Dim approve As Short
                approve = clsUtil.GetDataFromDatatable(tbl_TrnOrder, "order_id", "order_approved2", order_id).ToString
                Me.Approve(approve)
            End If
        Next

    End Sub


End Class


