
Public Class uiTrnPurchaseOrder3
    Private Const mUiName As String = "Purchase Order"
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
    Private tbl_order_delivery_date As DataTable = clsDataset2.CreateTblTrnOrder_delivery_date()

    Private tbl_TrnRequestdetil As DataTable = clsDataset2.CreateTblRequestdetil()
    Private tbl_RequestdetilSelect As DataTable = clsDataset2.CreateTblRequestdetil()
    Private tbl_RequestSelect As DataTable = clsDataset2.CreateTblRequest()

    Private tbl_TrnOrderApproval As DataTable = clsDataset2.CreateTblTrnorderApproval()
    Private tbl_RequestdetilEps As DataTable = clsDataset2.CreateTblTrnRequestdetileps()
    Private tbl_TrnOrderdetileps As DataTable = clsDataset2.CreateTblTrnOrderdetileps()
    Private tbl_MstChannel As DataTable = clsDataset2.CreateTblMstChannel()
    Private tbl_MstPeriode As DataTable = clsDataset2.CreateTblMstPeriode()
    Private tbl_MstCurrency As DataTable = clsDataset2.CreateTblMstCurrency()
    Private tbl_MstXRate As DataTable = clsDataset2.CreateTblMstXRate()
    Private tbl_TrnBudget As DataTable = clsDataset2.CreateTblTrnBudget()
    Private tbl_MstProgram As DataTable = clsDataset2.CreateTblMstRentalprogram()
    Private tbl_MstRekanan As DataTable = clsDataset2.CreateTblMstrekanan()
    Private tbl_MstRekanan_contact As DataTable = clsDataset2.CreateTblMstrekanan_contact()
    Private tbl_MstItem As DataTable = clsDataset2.CreateTblMstItem()
    Private tbl_MstUnit As DataTable = clsDataset2.CreateTblMstUnit()
    Private tbl_MstStrukturUnit As DataTable = clsDataset2.CreateTblStrukturUnit()
    Private tbl_MstUser As DataTable = clsDataset2.createTblMstUser()
    Private tbl_TrnOrderAmount_perBudget As DataTable = clsDataset2.CreateTblOrderAmount_perBudget()

    Dim ReservedItem As Boolean
    Private m_nama, m_alamat, m_telp, m_ext, m_fax As String
    Private bgtAmount_value As Collection = New Collection

    Private WithEvents btnApp As New ToolStripButton
    Private WithEvents btnUnapp As New ToolStripButton

    Private errorbpj As Boolean = False
    Private errorPA As Boolean = False
    Private order_total As Decimal
    Private order_id_fordelivery
    Dim j As Integer
    Private formstatus As String
    Private channel_number As String
    '========== TOP =============
    Private tbl_TrnOrderTOPdetil As DataTable = clsDataset.CreateTblTrnOrderTOPdetil()
    Private tbl_MstOrderPaying As DataTable = clsDataset.CreateTblMasterPaying()

    Private tbl_TrnOrderAttachment As DataTable = clsDataset2.CreateTblTrnOrderAttachment()
    Private tbl_TrnOrderAttachmentRequest As DataTable = clsDataset2.CreateTblTrnRequestAttachment()

#Region " Window Parameter "
    Private _FORMMODE As String = "ENTRY"       '[ENTRY, VIEW, APPROVAL, UNAPPROVAL]
    Private _CHANNEL As String = "TAS" 'clsConfig.globDefaultChannel
    Private _CHANNEL_CANBE_CHANGED As Boolean = True
    Private _CHANNEL_CANBE_BROWSED As Boolean = True
    Private _ORDER_SOURCE As String = "PR"  '[ML=Manual, PQ, MQ] 
    Private _ORDERTYPE_ID As String = "PO"  '[PO    , MO]
    Private _ORDER_AUTHNAME As String = "Marina Nurdiana"
    Private _ORDER_AUTHPOS As String = "Procurement Dept. Head"
    Private _ORDER_AUTHNAME2 As String = "Deddy Hariyanto"
    Private _ORDER_AUTHPOS2 As String = "Deputy CEO"
    Private _PROGRAMTYPE As String = "NP" '[PG = PROGRAM, NP = NON PROGRAM]
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
        Me.formstatus = "NEW"
        Me.tbl_MstRekanan_contact.Clear()
        Me.Cursor = Cursors.WaitCursor
        If Me.FlatTabMain.SelectedIndex = 0 Then
            Me.FlatTabMain.SelectedIndex = 1
        End If

        Me.uiTrnPurchaseOrder3_NewData()
        Me.bgtAmount_value.Clear()
        Me.ReservedItem = False
        If Me.uiTrnPurchaseOrder3_GetOrderSource() = True Then
            Me.formnewhidup()
            Me.LOCKING_FORM("NEW")
        Else
            Me.FlatTabMain.SelectedIndex = 0
        End If
       
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.obj_Order_id.Text = "" Then
            If Me.uiTrnPurchaseOrder3_FormError() Then
                Return True
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.uiTrnPurchaseOrder3_Save()
        Else
            Dim tbl_cek As DataTable = New DataTable()
            Dim cancel As Integer = 0
            Dim approved As Integer = 0
            tbl_cek.Clear()
            Me.DataFill(tbl_cek, "pr_TrnOrder_Select_CekStatus", String.Format(" order_id = '{0}'", Me.obj_Order_id.Text))

            If tbl_cek.Rows.Count <> 0 Then
                cancel = tbl_cek.Rows(0).Item("order_canceled")
                approved = tbl_cek.Rows(0).Item("order_approved")
                If cancel = 1 Then
                    MsgBox("Cannot saved, because order is canceled !", MsgBoxStyle.Exclamation, "Exclamation")
                    Me.Cursor = Cursors.Arrow
                    Return MyBase.btnSave_Click()
                    Exit Function
                End If
            End If

            If tbl_cek.Rows.Count <> 0 Then
                If approved = 0 Or approved = 2 Then
                    If Me.uiTrnPurchaseOrder3_FormError() Then
                        Return True
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    Me.uiTrnPurchaseOrder3_Save()
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Me.SaveTOP()
                End If
            End If

        End If

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPurchaseOrder3_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Property "

    Private mTotalDetil As Decimal
    Private mTotalDetilPPH As Decimal
    Private mTotalDetilPPN As Decimal
    Private mTotalDetilDisc As Decimal

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

    Public Property TotalDetilDisc() As Decimal
        Get
            Return mTotalDetilDisc
        End Get
        Set(ByVal value As Decimal)
            mTotalDetilDisc = value
            Me.calc_Order_Discount.Text = String.Format("{0:#,##0.00}", value)
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
        'Dim cbOrderdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cbItem_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        'Dim cbItem_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cCategory_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cbUnit_name As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cbCurrency As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

        ' Dim cbUnit_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        'Dim cbCurrency As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

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
        Dim cOrderdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBtn_Child As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn

        cBtn_Child.Name = "btn_child"
        cBtn_Child.UseColumnTextForButtonValue = True
        cBtn_Child.HeaderText = ""
        cBtn_Child.FlatStyle = FlatStyle.Flat
        cBtn_Child.Width = 50
        cBtn_Child.Text = "ChildList"
        cBtn_Child.Frozen = True

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
        cbOrderdetil_type.DisplayStyleForCurrentCellOnly = True
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
        cbItem_name.DisplayStyleForCurrentCellOnly = True
        cbItem_name.AutoComplete = True
        cbItem_name.DataSource = Me.tbl_MstItem

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "ItemID"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 100
        cItem_id.Visible = False
        cItem_id.ReadOnly = True

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
        cOrderdetil_pphforeign.Width = 200
        cOrderdetil_pphforeign.Visible = True
        cOrderdetil_pphforeign.ReadOnly = True

        cOrderdetil_ppnforeign.Name = "orderdetil_ppnforeign"
        cOrderdetil_ppnforeign.HeaderText = "PPN Amount Foreign"
        cOrderdetil_ppnforeign.DataPropertyName = "orderdetil_ppnforeign"
        cOrderdetil_ppnforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnforeign.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppnforeign.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_ppnforeign.Width = 200
        cOrderdetil_ppnforeign.Visible = True
        cOrderdetil_ppnforeign.ReadOnly = True

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
            cBtn_Child, _
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
        cOrderpaymreq_amount.ReadOnly = True

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
        cRequestdetil_ordered.HeaderText = "Ordered"
        cRequestdetil_ordered.DataPropertyName = "requestdetil_ordered"
        cRequestdetil_ordered.Width = 50
        cRequestdetil_ordered.Visible = True
        cRequestdetil_ordered.ReadOnly = False

        cRequestdetil_selected.Name = "requestdetil_selected"
        cRequestdetil_selected.HeaderText = "Selected"
        cRequestdetil_selected.DataPropertyName = "requestdetil_selected"
        cRequestdetil_selected.Width = 50
        cRequestdetil_selected.Visible = False
        cRequestdetil_selected.ReadOnly = True

        cRequestdetil_added.Name = "requestdetil_added"
        cRequestdetil_added.HeaderText = "Added"
        cRequestdetil_added.DataPropertyName = "requestdetil_added"
        cRequestdetil_added.Width = 50
        cRequestdetil_added.Visible = False
        cRequestdetil_added.ReadOnly = True

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

    Private Function FormatDgvTrnTerimabarang(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        ' Format DgvTrnPenerimaanbarang Columns 
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_qtyitem As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_qtyrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_statusrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_location As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_notes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_nosuratjalan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_isdisabled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_createdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_modifiedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_modifieddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appuser As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_appuser_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appuser_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appspv As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_appspv_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appspv_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appacc As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_appacc_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appacc_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_cetakbpb As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "ID"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False

        cTerimabarang_date.Name = "terimabarang_date"
        cTerimabarang_date.HeaderText = "Date"
        cTerimabarang_date.DataPropertyName = "terimabarang_date"
        cTerimabarang_date.Width = 100
        cTerimabarang_date.Visible = True
        cTerimabarang_date.ReadOnly = False

        cTerimabarang_type.Name = "terimabarang_type"
        cTerimabarang_type.HeaderText = "Type"
        cTerimabarang_type.DataPropertyName = "terimabarang_type"
        cTerimabarang_type.Width = 100
        cTerimabarang_type.Visible = True
        cTerimabarang_type.ReadOnly = False

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
        cRekanan_id.HeaderText = "Rekanan ID"
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

        cTerimabarang_qtyitem.Name = "terimabarang_qtyitem"
        cTerimabarang_qtyitem.HeaderText = "Qty Item"
        cTerimabarang_qtyitem.DataPropertyName = "terimabarang_qtyitem"
        cTerimabarang_qtyitem.Width = 100
        cTerimabarang_qtyitem.Visible = True
        cTerimabarang_qtyitem.ReadOnly = False

        cTerimabarang_qtyrealization.Name = "terimabarang_qtyrealization"
        cTerimabarang_qtyrealization.HeaderText = "Qty Realization"
        cTerimabarang_qtyrealization.DataPropertyName = "terimabarang_qtyrealization"
        cTerimabarang_qtyrealization.Width = 100
        cTerimabarang_qtyrealization.Visible = True
        cTerimabarang_qtyrealization.ReadOnly = False

        cOrder_qty.Name = "order_qty"
        cOrder_qty.HeaderText = "Order Qty"
        cOrder_qty.DataPropertyName = "order_qty"
        cOrder_qty.Width = 100
        cOrder_qty.Visible = True
        cOrder_qty.ReadOnly = False

        cTerimabarang_status.Name = "terimabarang_status"
        cTerimabarang_status.HeaderText = "Status"
        cTerimabarang_status.DataPropertyName = "terimabarang_status"
        cTerimabarang_status.Width = 100
        cTerimabarang_status.Visible = True
        cTerimabarang_status.ReadOnly = False

        cTerimabarang_statusrealization.Name = "terimabarang_statusrealization"
        cTerimabarang_statusrealization.HeaderText = "Status Realization"
        cTerimabarang_statusrealization.DataPropertyName = "terimabarang_statusrealization"
        cTerimabarang_statusrealization.Width = 100
        cTerimabarang_statusrealization.Visible = True
        cTerimabarang_statusrealization.ReadOnly = False

        cTerimabarang_location.Name = "terimabarang_location"
        cTerimabarang_location.HeaderText = "Loc."
        cTerimabarang_location.DataPropertyName = "terimabarang_location"
        cTerimabarang_location.Width = 100
        cTerimabarang_location.Visible = True
        cTerimabarang_location.ReadOnly = False

        cTerimabarang_notes.Name = "terimabarang_notes"
        cTerimabarang_notes.HeaderText = "terimabarang_notes"
        cTerimabarang_notes.DataPropertyName = "terimabarang_notes"
        cTerimabarang_notes.Width = 100
        cTerimabarang_notes.Visible = False
        cTerimabarang_notes.ReadOnly = False

        cTerimabarang_nosuratjalan.Name = "terimabarang_nosuratjalan"
        cTerimabarang_nosuratjalan.HeaderText = "terimabarang_nosuratjalan"
        cTerimabarang_nosuratjalan.DataPropertyName = "terimabarang_nosuratjalan"
        cTerimabarang_nosuratjalan.Width = 100
        cTerimabarang_nosuratjalan.Visible = False
        cTerimabarang_nosuratjalan.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimabarang_isdisabled.Name = "terimabarang_isdisabled"
        cTerimabarang_isdisabled.HeaderText = "terimabarang_isdisabled"
        cTerimabarang_isdisabled.DataPropertyName = "terimabarang_isdisabled"
        cTerimabarang_isdisabled.Width = 100
        cTerimabarang_isdisabled.Visible = True
        cTerimabarang_isdisabled.ReadOnly = False

        cTerimabarang_createby.Name = "terimabarang_createby"
        cTerimabarang_createby.HeaderText = "Create By"
        cTerimabarang_createby.DataPropertyName = "terimabarang_createby"
        cTerimabarang_createby.Width = 100
        cTerimabarang_createby.Visible = True
        cTerimabarang_createby.ReadOnly = False

        cTerimabarang_createdt.Name = "terimabarang_createdt"
        cTerimabarang_createdt.HeaderText = "Create Date"
        cTerimabarang_createdt.DataPropertyName = "terimabarang_createdt"
        cTerimabarang_createdt.Width = 100
        cTerimabarang_createdt.Visible = True
        cTerimabarang_createdt.ReadOnly = False

        cTerimabarang_modifiedby.Name = "terimabarang_modifiedby"
        cTerimabarang_modifiedby.HeaderText = "Modified By"
        cTerimabarang_modifiedby.DataPropertyName = "terimabarang_modifiedby"
        cTerimabarang_modifiedby.Width = 100
        cTerimabarang_modifiedby.Visible = True
        cTerimabarang_modifiedby.ReadOnly = False

        cTerimabarang_modifieddt.Name = "terimabarang_modifieddt"
        cTerimabarang_modifieddt.HeaderText = "Modify Date "
        cTerimabarang_modifieddt.DataPropertyName = "terimabarang_modifieddt"
        cTerimabarang_modifieddt.Width = 100
        cTerimabarang_modifieddt.Visible = True
        cTerimabarang_modifieddt.ReadOnly = False

        cTerimabarang_appuser.Name = "terimabarang_appuser"
        cTerimabarang_appuser.HeaderText = "App User"
        cTerimabarang_appuser.DataPropertyName = "terimabarang_appuser"
        cTerimabarang_appuser.Width = 100
        cTerimabarang_appuser.Visible = True
        cTerimabarang_appuser.ReadOnly = False

        cTerimabarang_appuser_by.Name = "terimabarang_appuser_by"
        cTerimabarang_appuser_by.HeaderText = "App User By"
        cTerimabarang_appuser_by.DataPropertyName = "terimabarang_appuser_by"
        cTerimabarang_appuser_by.Width = 100
        cTerimabarang_appuser_by.Visible = True
        cTerimabarang_appuser_by.ReadOnly = False

        cTerimabarang_appuser_dt.Name = "terimabarang_appuser_dt"
        cTerimabarang_appuser_dt.HeaderText = "App User Date"
        cTerimabarang_appuser_dt.DataPropertyName = "terimabarang_appuser_dt"
        cTerimabarang_appuser_dt.Width = 100
        cTerimabarang_appuser_dt.Visible = True
        cTerimabarang_appuser_dt.ReadOnly = False

        cTerimabarang_appspv.Name = "terimabarang_appspv"
        cTerimabarang_appspv.HeaderText = "App Spv"
        cTerimabarang_appspv.DataPropertyName = "terimabarang_appspv"
        cTerimabarang_appspv.Width = 100
        cTerimabarang_appspv.Visible = True
        cTerimabarang_appspv.ReadOnly = False

        cTerimabarang_appspv_by.Name = "terimabarang_appspv_by"
        cTerimabarang_appspv_by.HeaderText = "App Spv By"
        cTerimabarang_appspv_by.DataPropertyName = "terimabarang_appspv_by"
        cTerimabarang_appspv_by.Width = 100
        cTerimabarang_appspv_by.Visible = True
        cTerimabarang_appspv_by.ReadOnly = False

        cTerimabarang_appspv_dt.Name = "terimabarang_appspv_dt"
        cTerimabarang_appspv_dt.HeaderText = "App Spv Date"
        cTerimabarang_appspv_dt.DataPropertyName = "terimabarang_appspv_dt"
        cTerimabarang_appspv_dt.Width = 100
        cTerimabarang_appspv_dt.Visible = True
        cTerimabarang_appspv_dt.ReadOnly = False

        cTerimabarang_appacc.Name = "terimabarang_appacc"
        cTerimabarang_appacc.HeaderText = "App Acc"
        cTerimabarang_appacc.DataPropertyName = "terimabarang_appacc"
        cTerimabarang_appacc.Width = 100
        cTerimabarang_appacc.Visible = True
        cTerimabarang_appacc.ReadOnly = False

        cTerimabarang_appacc_by.Name = "terimabarang_appacc_by"
        cTerimabarang_appacc_by.HeaderText = "App Acc by"
        cTerimabarang_appacc_by.DataPropertyName = "terimabarang_appacc_by"
        cTerimabarang_appacc_by.Width = 100
        cTerimabarang_appacc_by.Visible = True
        cTerimabarang_appacc_by.ReadOnly = False

        cTerimabarang_appacc_dt.Name = "terimabarang_appacc_dt"
        cTerimabarang_appacc_dt.HeaderText = "App Acc Date"
        cTerimabarang_appacc_dt.DataPropertyName = "terimabarang_appacc_dt"
        cTerimabarang_appacc_dt.Width = 100
        cTerimabarang_appacc_dt.Visible = True
        cTerimabarang_appacc_dt.ReadOnly = False

        cTerimabarang_foreign.Name = "terimabarang_foreign"
        cTerimabarang_foreign.HeaderText = "terimabarang_foreign"
        cTerimabarang_foreign.DataPropertyName = "terimabarang_foreign"
        cTerimabarang_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimabarang_foreign.DefaultCellStyle.Format = "#,##0.00"

        cTerimabarang_foreign.Width = 100
        cTerimabarang_foreign.Visible = False
        cTerimabarang_foreign.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cTerimabarang_foreignrate.Name = "terimabarang_foreignrate"
        cTerimabarang_foreignrate.HeaderText = "Foreign Rate"
        cTerimabarang_foreignrate.DataPropertyName = "terimabarang_foreignrate"
        cTerimabarang_foreignrate.Width = 100
        cTerimabarang_foreignrate.Visible = True
        cTerimabarang_foreignrate.ReadOnly = False

        cTerimabarang_idrreal.Name = "terimabarang_idrreal"
        cTerimabarang_idrreal.HeaderText = "IDR"
        cTerimabarang_idrreal.DataPropertyName = "terimabarang_idrreal"
        cTerimabarang_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimabarang_idrreal.DefaultCellStyle.Format = "#,##0.00"
        'cOrderdetil_foreign.DefaultCellStyle.BackColor = Color.LightGray
        cTerimabarang_idrreal.Width = 110

        cTerimabarang_idrreal.Visible = True
        cTerimabarang_idrreal.ReadOnly = False

        cTerimabarang_pph.Name = "terimabarang_pph"
        cTerimabarang_pph.HeaderText = "PPh"
        cTerimabarang_pph.DataPropertyName = "terimabarang_pph"
        cTerimabarang_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimabarang_pph.DefaultCellStyle.Format = "#,##0.00"

        cTerimabarang_pph.Width = 100
        cTerimabarang_pph.Visible = True
        cTerimabarang_pph.ReadOnly = False

        cTerimabarang_ppn.Name = "terimabarang_ppn"
        cTerimabarang_ppn.HeaderText = "PPh"
        cTerimabarang_ppn.DataPropertyName = "terimabarang_ppn"
        cTerimabarang_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimabarang_ppn.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarang_ppn.Width = 100
        cTerimabarang_ppn.Visible = True
        cTerimabarang_ppn.ReadOnly = False

        cTerimabarang_disc.Name = "terimabarang_disc"
        cTerimabarang_disc.HeaderText = "Disc."
        cTerimabarang_disc.DataPropertyName = "terimabarang_disc"
        cTerimabarang_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimabarang_disc.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarang_disc.Width = 100
        cTerimabarang_disc.Visible = True
        cTerimabarang_disc.ReadOnly = False

        cTerimabarang_cetakbpb.Name = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.HeaderText = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.DataPropertyName = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.Width = 100
        cTerimabarang_cetakbpb.Visible = False
        cTerimabarang_cetakbpb.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_id, cTerimabarang_date, cTerimabarang_type, cOrder_id, cBudget_id, cRekanan_id, cEmployee_id_owner, cStrukturunit_id, cTerimabarang_qtyitem, cTerimabarang_qtyrealization, cOrder_qty, cTerimabarang_status, cTerimabarang_statusrealization, cTerimabarang_location, cTerimabarang_notes, cTerimabarang_nosuratjalan, cChannel_id, cTerimabarang_isdisabled, cTerimabarang_createby, cTerimabarang_createdt, cTerimabarang_modifiedby, cTerimabarang_modifieddt, cTerimabarang_appuser, cTerimabarang_appuser_by, cTerimabarang_appuser_dt, cTerimabarang_appspv, cTerimabarang_appspv_by, cTerimabarang_appspv_dt, cTerimabarang_appacc, cTerimabarang_appacc_by, cTerimabarang_appacc_dt, cTerimabarang_foreign, cCurrency_id, cTerimabarang_foreignrate, cTerimabarang_idrreal, cTerimabarang_pph, cTerimabarang_ppn, cTerimabarang_disc, cTerimabarang_cetakbpb})



        ' DgvTrnPenerimaanbarang Behaviours: 
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
        Dim i As Integer

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
        Me.DgvTrnRequestdetil.Dock = DockStyle.Fill

        Me.FormatDgvTrnOrder(Me.DgvTrnOrder)
        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
        Me.FormatDgvTrnOrderpaymreq(Me.DgvTrnOrderPaymReq)
        Me.FormatDgvTrnPurchaseReq(Me.DgvTrnRequestdetil)
        Me.FormatDgvTrnTerimabarang(Me.dgvtrnBPB)
        Me.FormatDgvTrnOrderTOPdetil(Me.DgvTrnOrderTOPdetil)

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.Gainsboro
        Next

        Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.White

        If Me._ORDERTYPE_ID = "PO" Then
            Me.ftabDataDetil.TabPages.Item(1).Text = "Purchase Request"
        ElseIf Me._ORDERTYPE_ID = "MO" Then
            Me.ftabDataDetil.TabPages.Item(1).Text = "Maintenance Request"
        End If

        If Me._FORMMODE = "VIEW" Then
            Me.uiTrnPurchaseOrder3_SetViewOnly()
        End If

        Me.btnApp.Text = "Approve"
        Me.btnUnapp.Text = "Unapprove"
        MyBase.ToolStrip1.Items.Add(Me.btnApp)
        MyBase.ToolStrip1.Items.Add(Me.btnUnapp)
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
        Try
            'stop binding
            Me.obj_Order_id.DataBindings.Clear()
            Me.dtp_order_date.DataBindings.Clear()
            Me.obj_Order_descr.DataBindings.Clear()
            Me.obj_order_note.DataBindings.Clear()
            Me.obj_Request_id.DataBindings.Clear()
            'Me.obj_Order_insurancecost.DataBindings.Clear()
            'Me.obj_Order_transportationcost.DataBindings.Clear()
            'Me.obj_Order_operatorcost.DataBindings.Clear()
            Me.obj_Order_othercost.DataBindings.Clear()
            Me.obj_Order_authname.DataBindings.Clear()
            Me.obj_Order_authposition.DataBindings.Clear()
            Me.obj_Order_authname2.DataBindings.Clear()
            Me.obj_Order_authposition2.DataBindings.Clear()

            Me.chkOrder_canceled.DataBindings.Clear()
            Me.obj_Order_createby.DataBindings.Clear()
            Me.obj_Order_createdate.DataBindings.Clear()
            Me.obj_Order_modifyby.DataBindings.Clear()
            Me.obj_Order_modifydate.DataBindings.Clear()
            'Me.calc_Order_Discount.DataBindings.Clear()
            'Me.obj_Channel_id.DataBindings.Clear()
            'Me.obj_Order_source.DataBindings.Clear()
            'Me.obj_Ordertype_id.DataBindings.Clear()
            Me.obj_Order_intref.DataBindings.Clear()

            Me.obj_order_dlvrname.DataBindings.Clear()
            Me.obj_order_dlvraddr1.DataBindings.Clear()
            Me.obj_order_dlvraddr2.DataBindings.Clear()
            Me.obj_order_dlvraddr3.DataBindings.Clear()
            Me.obj_order_dlvrtelp.DataBindings.Clear()
            Me.obj_order_dlvrfax.DataBindings.Clear()
            Me.obj_order_dlvrhp.DataBindings.Clear()

            Me.obj_Order_revno.DataBindings.Clear()
            Me.dtp_order_revdate.DataBindings.Clear()
            Me.obj_order_revdesc.DataBindings.Clear()

            Me.obj_Budget_id.DataBindings.Clear()
            Me.obj_Rekanan_id.DataBindings.Clear()
            'Me.obj_Old_program_id.DataBindings.Clear()

            Me.cbo_Currency.DataBindings.Clear()
            Me.cbo_Periode_id.DataBindings.Clear()
            Me.cbo_Budget_name.DataBindings.Clear()
            'Me.cbo_Budget_amount.DataBindings.Clear()
            Me.cbo_Rekanan_name.DataBindings.Clear()
            'Me.cbo_Old_program_name.DataBindings.Clear()
            Me.cbo_Deptname.DataBindings.Clear()
            Me.chkSingleBudget.DataBindings.Clear()


            '================ remark pts 20141006 =================
            'Me.chkApproved.DataBindings.Clear()
            '======================================================


            Me.cboSearchStatus.DataBindings.Clear()
            'Me.chkorder_approved.DataBindings.Clear()

            'tambahan dari mba melly 29 Mar 2011----------------------------
            Me.dtp_Order_Dlvrdate.DataBindings.Clear()
            Me.dtp_order_setdate.DataBindings.Clear()
            Me.dtp_Order_utilizeddatestart.DataBindings.Clear()
            Me.dtp_Order_utilizeddateend.DataBindings.Clear()
            Me.mtb_Order_utilizedtimestart.DataBindings.Clear()
            Me.mtb_Order_utilizedtimeend.DataBindings.Clear()
            '---------------------------------------------------------------
            Return True
        Catch ex As Exception
        End Try
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Try
            Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_id"))
            Me.dtp_order_date.DataBindings.Add(New Binding("Value", Me.tbl_TrnOrder_Temp, "order_date", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.obj_Order_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_descr"))
            Me.obj_order_note.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_note"))
            Me.obj_Request_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "request_id"))
            'Me.obj_Order_insurancecost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_insurancecost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
            'Me.obj_Order_transportationcost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_transportationcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
            'Me.obj_Order_operatorcost.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_operatorcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

            Me.obj_Order_authname.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authname"))
            Me.obj_Order_authposition.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authposition"))
            Me.obj_Order_authname2.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authname2"))
            Me.obj_Order_authposition2.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_authposition2"))
            Me.chkOrder_canceled.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_canceled"))
            Me.obj_Order_createby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_createby"))
            Me.obj_Order_createdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_createdate"))
            Me.obj_Order_modifyby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_modifyby"))
            Me.obj_Order_modifydate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_modifydate"))
            'Me.calc_Order_Discount.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_discount", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
            'Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "channel_id"))
            'Me.obj_Order_source.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_source"))
            'Me.obj_Ordertype_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "ordertype_id"))
            Me.obj_Order_intref.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_intref"))

            Me.obj_order_dlvrname.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvrname"))
            Me.obj_order_dlvraddr1.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvraddr1"))
            Me.obj_order_dlvraddr2.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvraddr2"))
            Me.obj_order_dlvraddr3.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvraddr3"))
            Me.obj_order_dlvrtelp.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvrtelp"))
            Me.obj_order_dlvrfax.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvrfax"))
            Me.obj_order_dlvrhp.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_dlvrhp"))

            Me.obj_Order_revno.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revno"))
            Me.dtp_order_revdate.DataBindings.Add(New Binding("Value", Me.tbl_TrnOrder_Temp, "order_revdate", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.obj_order_revdesc.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_revdesc"))

            Me.obj_Budget_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "budget_id"))
            Me.obj_Rekanan_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "rekanan_id"))

            Me.obj_Order_othercost.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "order_othercost"))
            'Me.obj_Old_program_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "old_program_id"))

            Me.cbo_Currency.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "currency_id"))
            Me.cbo_Periode_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "periode_id"))
            Me.cbo_Budget_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "budget_id"))
            'Me.cbo_Budget_amount.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "budget_id"))
            Me.cbo_Rekanan_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "rekanan_id"))
            'Me.cbo_Old_program_name.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "old_program_id"))
            Me.cbo_Deptname.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOrder_Temp, "strukturunit_id"))
            Me.chkSingleBudget.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_singlebudget"))

            '==================== REMARK PTS 20141006 ========================================================
            'Me.chkApproved.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_approved"))
            '===============================================================================================
            ''

            Me.cboSearchStatus.DataBindings.Add(New Binding("Enabled", Me.chkSrchStatus, "Checked")) ''
            'Me.chkorder_approved.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOrder_Temp, "order_approved", True, DataSourceUpdateMode.OnPropertyChanged, 0))

            'tambahan dari mba melly 29 Mar 2011----------------------------
            ' Me.dtp_Order_Dlvrdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "delivery_date"))
            'Me.mtb_Order_settime.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_settime"))
            Me.dtp_Order_Dlvrdate.DataBindings.Add(New Binding("Value", Me.tbl_TrnOrder_Temp, "orderdelivery_date", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.dtp_order_setdate.DataBindings.Add(New Binding("Value", Me.tbl_TrnOrder_Temp, "order_setdate", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.dtp_Order_utilizeddatestart.DataBindings.Add(New Binding("Value", Me.tbl_TrnOrder_Temp, "order_utilizeddatestart", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.dtp_Order_utilizeddateend.DataBindings.Add(New Binding("Value", Me.tbl_TrnOrder_Temp, "order_utilizeddateend", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.mtb_Order_utilizedtimestart.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizedtimestart"))
            Me.mtb_Order_utilizedtimeend.DataBindings.Add(New Binding("Text", Me.tbl_TrnOrder_Temp, "order_utilizedtimeend"))
            '---------------------------------------------------------------
            Return True
        Catch ex As Exception
            ''
        End Try
    End Function
#End Region

#Region " User Defined Function "
    Private Function uiTrnPurchaseOrder3_NewData() As Boolean
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
        Me.tbl_TrnOrder_Temp.Columns("order_pph_percent").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("order_ppn_percent").DefaultValue = 0
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
        Me.tbl_TrnOrder_Temp.Columns("order_setdate").DefaultValue = Now()
        uiTrnPurchaseOrder3_CekChannel()
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrname").DefaultValue = Me.m_nama 'getDeliverName(me._Channel)
        Me.tbl_TrnOrder_Temp.Columns("order_dlvraddr1").DefaultValue = Mid(Me.m_alamat, 1, 35)
        Me.tbl_TrnOrder_Temp.Columns("order_dlvraddr2").DefaultValue = Mid(Me.m_alamat, 36, 50)
        Me.tbl_TrnOrder_Temp.Columns("order_dlvraddr3").DefaultValue = "Ext. " & Me.m_ext
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrtelp").DefaultValue = "Telp. " & Me.m_telp
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrfax").DefaultValue = Me.m_fax
        Me.tbl_TrnOrder_Temp.Columns("order_dlvrhp").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("old_program_id").DefaultValue = 0
        Me.tbl_TrnOrder_Temp.Columns("old_category_id").DefaultValue = ""
        Me.tbl_TrnOrder_Temp.Columns("old_apref").DefaultValue = ""


        ' TODO: Set Default Value for tbl_TrnOrderdetil
        Me.tbl_TrnOrderdetil.Clear()
        Me.tbl_TrnOrderdetil = clsDataset2.CreateTblTrnOrderdetil2()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = 0
        Me.tbl_TrnOrderdetil.Columns("orderdetil_type").DefaultValue = "Item"
        Me.tbl_TrnOrderdetil.Columns("orderdetil_qty").DefaultValue = 1
        Me.tbl_TrnOrderdetil.Columns("orderdetil_days").DefaultValue = 1
        Me.tbl_TrnOrderdetil.Columns("orderdetil_discount").DefaultValue = 0
        Me.tbl_TrnOrderdetil.Columns("unit_id").DefaultValue = 1
        'Me.tbl_TrnOrderdetil.Columns("orderdetil_pphpercent").DefaultValue = 4.5
        Me.tbl_TrnOrderdetil.Columns("orderdetil_pphpercent").DefaultValue = 2
        Me.tbl_TrnOrderdetil.Columns("orderdetil_ppnpercent").DefaultValue = 10

        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10

        '=============== TOP Detil 20160822 ==============================
        ' TODO: Set Default Value for tbl_TrnOrderTOPdetil
        Me.tbl_TrnOrderTOPdetil.Clear()
        Me.tbl_TrnOrderTOPdetil = clsDataset.CreateTblTrnOrderTOPdetil()
        Me.tbl_TrnOrderTOPdetil.Columns("order_id").DefaultValue = 0
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").AutoIncrement = True
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").AutoIncrementStep = 10

        Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderdetil
        Me.DgvTrnOrderPaymReq.DataSource = Me.tbl_TrnOrderPaymReq
        Me.DgvTrnRequestdetil.DataSource = "" 'Me.tbl_TrnPurchaseRequest
        Me.DgvTrnOrderTOPdetil.DataSource = Me.tbl_TrnOrderTOPdetil


        '=== ATTACHMENT ===
        Me.tbl_TrnOrderAttachment.Clear()
        Me.tbl_TrnOrderAttachment = clsDataset2.CreateTblTrnOrderAttachment()
        Me.tbl_TrnOrderAttachment.Columns("order_id").DefaultValue = 0
        Me.tbl_TrnOrderAttachment.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderAttachment.Columns("line").AutoIncrement = True
        Me.tbl_TrnOrderAttachment.Columns("line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderAttachment.Columns("line").AutoIncrementStep = 10
        Me.GC_OrderAttachment.DataSource = Me.tbl_TrnOrderAttachment


        Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnOrder_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try
    End Function

    Private Function uiTrnPurchaseOrder3_GetOrderSource() As Boolean
        Dim dlgRequest As New dlgGetRequest(Me.DSN)

        Try
            Me.tbl_RequestdetilSelect.Clear()
            Me.tbl_RequestdetilSelect.DefaultView.RowFilter = Nothing

            Select Case Me._PROGRAMTYPE
                Case "PG"
                    Dim i As Integer
                    Me.tbl_RequestSelect.Clear()
                    Me.DataFill(Me.tbl_RequestSelect, "pr_TrnRequest_Select2", " jurnaltype_id ='" & Me._ORDER_SOURCE & "' AND request_programtype='" & Me._PROGRAMTYPE & _
                                "' AND requestdetil_ordered=0 AND requestdetil_approvedbma = 1 AND requestdetil_canceled = 0 AND rekanan_id <> 0 and request_canceled = 0 and channel_id = '" & _CHANNEL & "' ")
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
                            If Me.CheckBedaVendor() = False Then
                                MsgBox("Vendor can't be different.", MsgBoxStyle.Exclamation)

                                Exit Function
                            End If
                            'End If

                            If CheckCurrencyDetil() = False Then
                                MsgBox("currency on detail order can't be different", MsgBoxStyle.Exclamation)

                                Exit Function
                            End If

                            Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = False
                            Dim reqIndex As Integer = .dgvRequestList.CurrentRow.Index

                            With .dgvRequestList
                                Me.obj_Request_id.Text = .Item("request_id", reqIndex).Value
                                Me.obj_Budget_id.Text = .Item("budget_id", reqIndex).Value
                                Me.cbo_Budget_name.SelectedValue = .Item("budget_id", reqIndex).Value
                                Me.cbo_Deptname.SelectedValue = .Item("strukturunit_id", reqIndex).Value
                                Me.obj_Rekanan_id.Text = .Item("rekanan_id", reqIndex).Value
                                Me.cbo_Rekanan_name.SelectedValue = .Item("rekanan_id", reqIndex).Value
                                Me.cbo_Currency.SelectedValue = tbl_RequestSelect.Rows(0).Item("currency_id")
                                Me.dtp_order_setdate.Value = .Item("request_preparedt", reqIndex).Value
                                Me.dtp_Order_utilizeddatestart.Value = .Item("request_useddt", reqIndex).Value
                                Me.mtb_Order_utilizedtimestart.Text = Format(.Item("request_useddt", reqIndex).Value, "HH:mm")
                                Me.dtp_Order_utilizeddateend.Value = .Item("request_useddt2", reqIndex).Value
                                Me.mtb_Order_utilizedtimeend.Text = Format(.Item("request_useddt2", reqIndex).Value, "HH:mm")

                            End With

                            Dim reqid As String = .dgvRequestList.Item("request_id", reqIndex).Value
                            Dim sift As String = " requestdetil_ordered=0 AND request_id = '" & reqid & "' AND requestdetil_approvedbma=1 AND ISNULL(requestdetil_mother,0) = 0 AND requestdetil_canceled = 0 AND rekanan_id=" & Me.obj_Rekanan_id.Text

                            Me.tbl_RequestdetilSelect.Clear()
                            Me.DataFill(Me.tbl_RequestdetilSelect, "pr_TrnRequestdetil_Select", sift)

                            Me.DgvTrnRequestdetil.DataSource = Me.tbl_RequestdetilSelect
                            Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = False

                            If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
                                For i = 0 To Me.tbl_RequestdetilSelect.Rows.Count - 1
                                    Me.tbl_RequestdetilSelect.Rows(i).Item("requestdetil_ordered") = 1
                                    Me.tbl_TrnOrderdetil.Rows.Add()
                                    If Me.tbl_RequestdetilSelect.Rows(i).Item("item_id").ToString <> "" Then
                                        Me.uiTrnPurchaseOrder3_SetItemDetil(i, i)
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

                                Dim eps_end As Integer = 1

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
                                    Dim eps_start As Integer = 1
                                    Dim row_eps As Integer = (eps_end - eps_start)
                                    For c = 0 To row_eps
                                        Me.tbl_TrnOrderdetileps.Rows.Add()

                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetil_line") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_line")
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
                                Next

                            Catch ex As Exception
                                MessageBox.Show("Error occured when trying to get episode. " & ex.Message)
                            End Try

                            Me.FormatDgvTrnOrderdetileps(Me.dgvepisode)
                            Me.dgvepisode.DataSource = Me.tbl_TrnOrderdetileps
                            Me.obj_Budget_id.Enabled = False
                            Me.cbo_Budget_name.Enabled = False
                            Me.obj_Order_othercost.Enabled = True

                            Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
                            Me.obj_Order_othercost.Enabled = True
                            Return True
                        Else
                            'Me.obj_Order_othercost.Enabled = True
                            'Me.obj_Budget_id.Enabled = True
                            'Me.cbo_Budget_name.Enabled = True
                            Return False
                        End If
                    End With
                Case "NP"
                    Dim i, j, k As Integer
                    If Me.ReservedItem = False Then
                        Me.tbl_RequestdetilSelect.Clear()
                        Me.DataFill(Me.tbl_RequestdetilSelect, "pr_TrnRequestHD_Select2", " jurnaltype_id ='" & Me._ORDER_SOURCE & "' AND request_programtype='" & Me._PROGRAMTYPE & _
                                    "' AND requestdetil_ordered = 0  AND requestdetil_approvedbma = 1 AND requestdetil_canceled = 0 AND rekanan_id <> 0 AND request_canceled = 0 AND channel_id = '" & _CHANNEL & "' ")
                        Me.tbl_RequestdetilSelect.DefaultView.RowFilter = Nothing
                    Else
                        Me.tbl_RequestdetilSelect.DefaultView.RowFilter = "requestdetil_selected = 0"
                        Me.ReservedItem = False
                    End If

                    With dlgRequest
                        .tbl_RequestDetilSelect = Me.tbl_RequestdetilSelect
                        .ProgType = Me._PROGRAMTYPE
                        .dgvRequestList.DataSource = Me.tbl_RequestdetilSelect
                        .ShowDialog()

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

                        If .chk_rekanan.Checked = True Or .chk_request_id.Checked = True Then
                            Me.tbl_RequestdetilSelect = .tbl_RequestDetilSelect
                            .dgvRequestList.DataSource = Me.tbl_RequestdetilSelect
                        End If

                        If .DialogResult = DialogResult.OK Then
                           
                            'iterasi untuk ubah nilai selected = ordered
                            Dim count As Integer = 0
                            Dim deptname, rekanan, budget, curr As Integer

                            For i = 0 To Me.tbl_RequestdetilSelect.Rows.Count - 1
                                If Me.tbl_RequestdetilSelect.Rows(i).Item("requestdetil_ordered") = True Then
                                    Me.tbl_RequestdetilSelect.Rows(i).Item("requestdetil_selected") = 1
                                    deptname = tbl_RequestdetilSelect.Rows(i).Item("strukturunit_id")
                                    rekanan = tbl_RequestdetilSelect.Rows(i).Item("rekanan_id")
                                    budget = tbl_RequestdetilSelect.Rows(i).Item("budget_id")
                                    curr = tbl_RequestdetilSelect.Rows(i).Item("currency_id")
                                    count += 1
                                End If
                            Next

                            If count > 0 Then
                                'Pull request header to order header
                                Me.cbo_Deptname.SelectedValue = deptname
                                Me.obj_Rekanan_id.Text = rekanan
                                Me.cbo_Rekanan_name.SelectedValue = rekanan
                                Me.obj_Budget_id.Text = budget
                                Me.cbo_Budget_name.SelectedValue = budget
                                Me.cbo_Currency.SelectedValue = curr
                                'Pull request detil to order detil
                                Me.DgvTrnRequestdetil.DataSource = Me.tbl_RequestdetilSelect
                                Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = False

                                '===== GK berfungsi dengan baik.. bugs===== PTS 20141229==
                                Me.tbl_RequestdetilSelect.DefaultView.RowFilter = " requestdetil_ordered = 1 "
                                '=========================================================

                                Dim newitem As Boolean
                                For i = 0 To Me.DgvTrnRequestdetil.Rows.Count - 1
                                    Dim xrequest_id As String = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(i).Cells("request_id").Value, "")
                                    Dim xbudget_id As Integer = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(i).Cells("budget_id").Value, 0)

                                    If Me.obj_Request_id.Text = "" Then
                                        Me.obj_Request_id.Text = xrequest_id
                                    Else
                                        If InStr(Me.obj_Request_id.Text, xrequest_id, CompareMethod.Text) = 0 Then _
                                        Me.obj_Request_id.Text = Me.obj_Request_id.Text + ", " + xrequest_id
                                    End If

                                    newitem = True
                                    If Me.tbl_TrnOrderdetil.Rows.Count = 0 Then
                                        Me.tbl_TrnOrderdetil.Rows.Add()
                                        Me.uiTrnPurchaseOrder3_SetItemDetil(i, i)
                                    Else
                                        For j = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                                            Dim cbudget_id As Integer = clsUtil.IsDbNull(Me.tbl_TrnOrderdetil.Rows(j).Item("budget_id"), 0)

                                            If xbudget_id <> cbudget_id Then
                                                Me.obj_Budget_id.Text = "0"
                                                Me.cbo_Budget_name.SelectedValue = 0
                                            End If

                                        Next
                                        If newitem Then
                                            Me.tbl_TrnOrderdetil.Rows.Add()
                                            k = Me.tbl_TrnOrderdetil.Rows.Count - 1
                                            Me.uiTrnPurchaseOrder3_SetItemDetil(k, i)

                                        End If
                                    End If
                                    Me.DgvTrnRequestdetil.Rows(i).Cells("requestdetil_added").Value = True
                                Next

                                Dim tbl_req_header As DataTable = New DataTable
                                tbl_RequestSelect.Clear()
                                Dim a As String = String.Format("transaksi_request.request_id= '{0}'", clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(0).Cells("request_id").Value, ""))
                                Me.DataFill(tbl_RequestSelect, "pr_TrnRequest_Select", String.Format("transaksi_request.request_id= '{0}'", clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(0).Cells("request_id").Value, "")))

                                With tbl_RequestSelect
                                    Me.dtp_order_setdate.Value = clsUtil.IsDbNull(.Rows(0).Item("request_preparedt").ToString, Now)
                                    Me.dtp_Order_utilizeddatestart.Value = clsUtil.IsDbNull(.Rows(0).Item("request_useddt").ToString, Now)
                                    Me.mtb_Order_utilizedtimestart.Text = clsUtil.IsDbNull(Format(.Rows(0).Item("request_useddt").ToString, "HH:mm"), "")
                                    Me.dtp_Order_utilizeddateend.Value = clsUtil.IsDbNull(.Rows(0).Item("request_useddt2").ToString, Now)
                                    Me.mtb_Order_utilizedtimeend.Text = clsUtil.IsDbNull(Format(.Rows(0).Item("request_useddt2").ToString, "HH:mm"), "")

                                    Me.obj_Budget_id.Enabled = False
                                    Me.cbo_Budget_name.Enabled = False
                                End With
                            End If
                            ' Set detil Episode---========================================================================
                            Try
                                Dim a As Integer = 0
                                Dim b As Integer = 0
                                Dim c As Integer = 0

                                Dim eps_end As Integer = 1

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
                                    Dim eps_start As Integer = 1
                                    Dim row_eps As Integer = (eps_end - eps_start)
                                    For c = 0 To row_eps
                                        Me.tbl_TrnOrderdetileps.Rows.Add()

                                        Me.tbl_TrnOrderdetileps.Rows(tbl_TrnOrderdetileps.Rows.Count - 1).Item("orderdetil_line") = Me.tbl_TrnOrderdetil.Rows(a).Item("orderdetil_line")
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
                                Next

                            Catch ex As Exception
                                MessageBox.Show("Error occured when trying to get episode. " & ex.Message)
                            End Try

                            Me.FormatDgvTrnOrderdetileps(Me.DgvEpisode)
                            Me.dgvepisode.DataSource = Me.tbl_TrnOrderdetileps
                            Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
                            Me.obj_Order_othercost.Enabled = True
                            Return True
                        Else

                            'Me.obj_Budget_id.Enabled = True
                            'Me.cbo_Budget_name.Enabled = True
                            'tbl_RequestdetilSelect.DefaultView.RowFilter = "requestdetil_ordered = 1"
                            Return False
                        End If
                    End With
            End Select
           
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Function uiTrnPurchaseOrder3_SetItemDetil(ByVal rowidx_a As Integer, ByVal rowidx As Integer) As Boolean
        Try
            Dim req_unit As Int64 = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("unit_id").Value
            Dim req_itemid As Int64 = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("item_id").Value
            Dim req_days As Int64 = 1
            Dim req_currencyid As Int64 = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("currency_id").Value
            Dim req_foreignrate As Decimal = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value
            Dim req_detildescr As String = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_descr").Value
            Dim req_qty As Decimal = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value
            Dim req_foreign As Decimal = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 0)
            Dim req_discount As Decimal = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0)
            Dim req_budgetid As Int64 = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("budget_id").Value
            Dim req_budgetdetilid As Int64 = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("budgetdetil_id").Value
            Dim req_request_id As String = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("request_id").Value
            Dim req_requestdetilline As Int64 = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_line").Value


            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_type") = "Item"
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("unit_id") = req_unit
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("item_id") = req_itemid
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_days") = req_days
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("currency_id") = req_currencyid
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreignrate") = req_foreignrate
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_descr") = req_detildescr
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_qty") = req_qty
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreign") = req_foreign
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_discount") = req_discount
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("budget_id") = req_budgetid
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("budgetdetil_id") = req_budgetdetilid
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_requestid_ref") = req_request_id
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("requestdetil_line") = req_requestdetilline
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_idr") = req_foreign * req_foreignrate

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr") = req_qty * req_foreign * req_foreignrate
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc") = ((req_qty * req_foreign) - (req_qty * req_discount)) * req_foreignrate

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign") = req_qty * req_foreign
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc") = (req_qty * req_foreign) - (req_qty * req_discount)

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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function uiTrnPurchaseOrder3_SetItemDetil_OLD(ByVal rowidx_a As Integer, ByVal rowidx As Integer) As Boolean
        Try
            'Note perhitungan total incl disc RO berbeda dengan PO  cek store pr_trnordetil2_select----------------------
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_type") = "Item"
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("unit_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("unit_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("item_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("item_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_days") = 1
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("currency_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("currency_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreignrate") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_descr") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_descr").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_qty") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_foreign") = clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 0)
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_discount") = (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0))

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("budget_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("budget_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("budgetdetil_id") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("budgetdetil_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_requestid_ref") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("request_id").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("requestdetil_line") = Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_line").Value
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_idr") = Math.Round(clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value * _
                                                                                               Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value, 0), MidpointRounding.AwayFromZero)

            '============= REMARK PTS20171103 === Karena rumusan itungannya aneh harus nya dikali dulu rate, jadi untuk yang curreny IDR rumusan di bawah gk masalah tapi ketika currency Foreign bermasalah
            'Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc") = (Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value - (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0) * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value))
            '=============Modified PTS20171103 ============
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc") = ((Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value) - (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0) * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignrate").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value))
            '==============================================
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign") = Math.Round(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value, 2, MidpointRounding.AwayFromZero)

            '============= REMARK PTS20171103 =====
            'Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc") = (Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value - (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0) * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value))
            '============= MODIFIED PTS20171103 ===
            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalforeign_incldisc") = ((Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_foreignreal").Value * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value) - (clsUtil.IsDbNull(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_discount").Value, 0) * Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value))
            '======================================

            Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr") = Math.Round(Me.DgvTrnRequestdetil.Rows(rowidx).Cells("requestdetil_qty").Value * _
                                                                                  1 * _
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
            'Note perhitungan total incl disc RO berbeda dengan PO--- cek store pr_trnordetil2_select-----------------------------------                                                                                   Me.tbl_TrnOrderdetil.Rows(rowidx_a).Item("orderdetil_rowtotalidr_incldisc")), MidpointRounding.AwayFromZero)
        Catch ex As Exception
            MessageBox.Show("Error occured when trying to get requested items. " & ex.Message)
        End Try
    End Function
    Private Function uiTrnPurchaseOrder3_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""

        txtCondition = " ordertype_id='" & Me._ORDERTYPE_ID & "' and channel_id='" & Me._CHANNEL + "'"

        '-- Periode
        If Me.chkSearchPeriode.Checked Then
            txtSearchCriteria = String.Format(" periode_id = '{0}' ", Me.channel_number & Me.txtSearchPeriode.Text)
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
        ''
        If Me.chkSearchApproved.Checked Then
            Select Case Me.cboSearchApproved.SelectedValue
                Case 0
                    txtSearchCriteria = " order_approved2 = 0 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
                Case 1
                    txtSearchCriteria = " order_approved2 = 1 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
                Case 2
                    txtSearchCriteria = " order_approved2 = 2 "
                    If txtCondition = "" Then
                        txtCondition = " (" & txtSearchCriteria & ") "
                    Else
                        txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    End If
            End Select
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

        criteria = txtCondition & " AND order_programtype = '" & Me._PROGRAMTYPE & "'"

        Me.tbl_TrnOrder.Clear()
        Try
            Me.DataFillLimit(Me.tbl_TrnOrder, "pr_TrnOrder_Select3", criteria, Me.nudSearchRowLimit.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Not Me.COMBO_ISFILLED Then
            Me.uiTrnPurchaseOrder3_LoadDataCombo()
        End If

        Me.lblTotalRows.Visible = True
        Me.lblTotalRows.Text = Me.DgvTrnOrder.Rows.Count & " " & "Row(s)"

        'uiTrnPurchaseOrder3_GetOrderCreator()
    End Function

    Private Function uiTrnPurchaseOrder3_Save() As Boolean
        'save data
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim channel_id As String
        Dim line As Integer
        Dim idr As Decimal
        Dim rowFilter As String
        channel_id = Me._CHANNEL

        '================== ADD PTS 20141006 ====================================
        Dim dbConn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        '========================================================================

        Dim tbl_TrnOrder_Temp_Changes As DataTable
        Dim tbl_TrnOrderdetil_Changes As DataTable
        Dim tbl_TrnOrderpaymreq_Changes As DataTable
        Dim tbl_TrnRequestdetil_Changes As DataTable
        Dim tbl_TrnOrderApproval_Changes As DataTable
        Dim tbl_orderdeliverydate_Temp_changes As DataTable
        Dim tbl_TrnOrderdetileps_Changes As DataTable
        Dim tbl_TrnOrderTOPdetil_Changes As DataTable
        Dim success As Boolean
        Dim order_id As Object = New Object
        Dim request_id As Object = New Object
        Dim requestdetil_line As Int16

        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult
        Dim cookie As Byte() = Nothing

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(order_id)

        If Me.tbtnSave.Visible = False Then
            MsgBox(" Data cannot be saved because this order is already canceled")
            Exit Function
        End If
        'Me.tbl_TrnOrder_Temp.AcceptChanges()

        Me.BindingContext(Me.tbl_TrnOrder_Temp).EndCurrentEdit()
        tbl_TrnOrder_Temp_Changes = Me.tbl_TrnOrder_Temp.GetChanges()
        tbl_orderdeliverydate_Temp_changes = Me.tbl_TrnOrder_Temp.GetChanges()

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

        Me.dgvepisode.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetileps).EndCurrentEdit()
        tbl_TrnOrderdetileps_Changes = Me.tbl_TrnOrderdetileps.GetChanges()

        '===== ADD PTS20160822 ==========
        Me.DgvTrnOrderTOPdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderTOPdetil).EndCurrentEdit()
        tbl_TrnOrderTOPdetil_Changes = Me.tbl_TrnOrderTOPdetil.GetChanges()
        '================================

        Me.cbo_Currency.SelectedValue = Me.cbo_Currency.SelectedValue
        Dim curr As Integer = Me.cbo_Currency.SelectedValue
        'menghitung orderdetil_id sebelum disave
        If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
            Dim j As Integer
            For j = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
                If Me.tbl_TrnOrderdetil.Rows(j).RowState = DataRowState.Deleted Then Continue For
                Dim orderdetil_idr = Nothing
                orderdetil_idr = Me.DgvTrnOrderdetil.Rows(j).Cells("orderdetil_qty").Value _
                                * Me.DgvTrnOrderdetil.Rows(j).Cells("orderdetil_foreign").Value _
                                * Me.DgvTrnOrderdetil.Rows(j).Cells("orderdetil_foreignrate").Value _
                                '* Me.DgvTrnOrderdetil.Rows(j).Cells("orderdetil_days").Value
                Me.tbl_TrnOrderdetil.Rows(j).Item("orderdetil_idr") = orderdetil_idr
            Next
        End If

        If tbl_TrnOrderdetil_Changes IsNot Nothing Then
            For i = 0 To tbl_TrnOrderdetil_Changes.Rows.Count - 1
                If tbl_TrnOrderdetil_Changes.Rows(i).RowState <> DataRowState.Deleted Then
                    line = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_line")
                    idr = tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_idr")
                    rowFilter = String.Format("orderdetil_line={0}", line)
                End If

                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount") = Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount")
                
                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc") = Math.Round(((tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign") - _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_discount") * _
                                                                                            1) * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty")) * _
                                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreignrate"), MidpointRounding.AwayFromZero)

                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign") = Math.Round(tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty") * _
                                                                                       1 * _
                                                                                       tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign"), 2, MidpointRounding.AwayFromZero)


                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalforeign_incldisc") = Math.Round(((tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_foreign") - _
                                                                                                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_discount")) * _
                                                                                                1) * _
                                                                                                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty"), 2, MidpointRounding.AwayFromZero)


                tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr") = Math.Round((tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_qty") * _
                                                                                   1 * _
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
                'end---------------------------------------------------------------------------------------------------------------------------------------------                                                                            tbl_TrnOrderdetil_Changes.Rows(i).Item("orderdetil_rowtotalidr_incldisc"), 2), 2)
                'Note perhitungan total incl disc RO berbeda dengan PO--- cek store pr_trnordetil2_select---------------------
            Next
        End If

        If tbl_TrnOrder_Temp_Changes IsNot Nothing _
            Or tbl_TrnOrderdetil_Changes IsNot Nothing _
                Or tbl_TrnRequestdetil_Changes IsNot Nothing _
                    Or tbl_TrnOrderpaymreq_Changes IsNot Nothing _
                            Or tbl_TrnOrderdetileps_Changes IsNot Nothing _
                            Or tbl_TrnOrderTOPdetil_Changes IsNot Nothing Then
            Try
                MasterDataState = tbl_TrnOrder_Temp.Rows(0).RowState
                order_id = tbl_TrnOrder_Temp.Rows(0).Item("order_id")
                'hanya untuk meng-cancel item yang tidak jadi di order

                '================== ADD PTS 20141006 ====================================
                dbConn1.Open()
                dbTrans = dbConn1.BeginTransaction()

                clsApplicationRole.SetAppRole(dbConn1, dbTrans, cookie)
                '========================================================================

                'If tbl_TrnRequestdetil_Changes IsNot Nothing Then
                '    For i = 0 To Me.tbl_TrnRequestdetil.Rows.Count - 1
                '        If Me.tbl_TrnRequestdetil.Rows(i).RowState = DataRowState.Modified And _
                '            Me.tbl_TrnRequestdetil.Rows(i).Item("requestdetil_ordered") = 0 _
                '            Then
                '            Me.tbl_TrnRequestdetil.Rows(i).Item("request_id") = request_id
                '            Me.tbl_TrnRequestdetil.Rows(i).Item("requestdetil_line") = requestdetil_line
                '        End If
                '    Next
                '    success = Me.uiTrnPurchaseOrder3_SaveRequestDetil(request_id, requestdetil_line, tbl_TrnRequestdetil_Changes, MasterDataState, dbConn1, dbTrans)
                '    '============ ADD PTS 20141006 === buat rollback
                '    If Not success Then
                '        GoTo rollback
                '    End If
                '    '===============================================
                '    If Not success Then Throw New Exception("Error: Save RequestDetil Data at Me.uiTrnPurchaseOrder3_SaveDetil(tbl_TrnRequestdetil_Changes)")
                '    Me.tbl_TrnRequestdetil.AcceptChanges()
                'End If

                If tbl_TrnOrder_Temp_Changes IsNot Nothing Then
                    Me.uiTrnPurchaseOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
                    Me.uiTrnPurchaseOrder3_TotalCalculate()

                    success = Me.uiTrnPurchaseOrder3_SaveMaster(order_id, tbl_TrnOrder_Temp_Changes, MasterDataState, dbConn1, dbTrans)

                    '============ ADD PTS 20141006 === buat rollback
                    If Not success Then
                        GoTo rollback
                    End If
                    '===============================================
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnPurchaseOrder3_SaveMaster(tbl_TrnOrder_Temp_Changes)")

                    Me.tbl_TrnOrder_Temp.AcceptChanges()
                End If

                If tbl_TrnOrderdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                        If Me.tbl_TrnOrderdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderdetil.Rows(i).Item("order_id") = order_id
                        End If
                    Next

                    'Try
                    success = Me.uiTrnPurchaseOrder3_SaveDetil(order_id, tbl_TrnOrderdetil_Changes, MasterDataState, dbConn1, dbTrans)
                    '============ ADD PTS 20141006 === buat rollback
                    If Not success Then
                        GoTo rollback
                    End If
                    '===============================================
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPurchaseOrder3_SaveDetil(tbl_TrnOrderdetil_Changes)")
                    'Catch ex As Exception
                    'End Try

                    Me.tbl_TrnOrderdetil.AcceptChanges()
                End If

            If tbl_TrnOrderpaymreq_Changes IsNot Nothing Then
                success = Me.uiTrnPurchaseOrder3_SaveDetilPaymReq(order_id, tbl_TrnOrderpaymreq_Changes, MasterDataState, dbConn1, dbTrans)
                '============ ADD PTS 20141006 === buat rollback
                If Not success Then
                    GoTo rollback
                End If
                '===============================================
                If Not success Then Throw New Exception("Error: Saving Payment Request Data at Me.uiTrnPurchaseOrder3_SavePaymentreqreference(tbl_TrnPaymentreqreference_Changes)")
                Me.tbl_TrnOrderPaymReq.AcceptChanges()
            End If

            If tbl_TrnOrderdetileps_Changes IsNot Nothing Then
                For i = 0 To Me.tbl_TrnOrderdetileps.Rows.Count - 1
                    If Me.tbl_TrnOrderdetileps.Rows(i).RowState = DataRowState.Added Then
                        Me.tbl_TrnOrderdetileps.Rows(i).Item("order_id") = order_id
                    End If
                Next
                success = Me.uiTrnPurchaseOrder3_SaveDetilEps(order_id, tbl_TrnOrderdetileps_Changes, MasterDataState, dbConn1, dbTrans)
                '============ ADD PTS 20141006 === buat rollback
                If Not success Then
                    GoTo rollback
                End If
                '===============================================
                If Not success Then Throw New Exception("Error: Save Use Data at Me.uiTrnRentalOrder3_SaveUse(tbl_TrnOrderdetil_Changes)")
                Me.tbl_TrnOrderdetileps.AcceptChanges()
            End If

            '====== ADD 20171031 === untuk TOPDetil(term of payment Detil)
            If tbl_TrnOrderTOPdetil_Changes IsNot Nothing Then
                For i = 0 To Me.tbl_TrnOrderTOPdetil.Rows.Count - 1
                    If Me.tbl_TrnOrderTOPdetil.Rows(i).RowState = DataRowState.Added Then
                        Me.tbl_TrnOrderTOPdetil.Rows(i).Item("order_id") = order_id
                    End If
                Next
                success = Me.uiTrnPurchaseOrder3_SaveTOPDetil(order_id, tbl_TrnOrderTOPdetil_Changes, MasterDataState, dbConn1, dbTrans)

                If Not success Then
                    GoTo rollback
                End If

                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPurchaseOrder3_SaveDetilTOPdetil(tbl_TrnOrderdetilTOPdetil_Changes)")
                Me.tbl_TrnOrderTOPdetil.AcceptChanges()
            End If

            result = FormSaveResult.SaveSuccess

            '==============================ADD pts 20141006 ===========================================

            dbTrans.Commit()

            If result = FormSaveResult.SaveSuccess Then
                GoTo save_confirmation
            End If
rollback:
            dbTrans.Rollback()

save_confirmation:
            '=========================================================================================

            If SHOW_SAVE_CONFIRMATION Then
                Dim dbConn2 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                Dim cookie2 As Byte() = Nothing
                    Try
                        dbConn2.Open()
                        clsApplicationRole.SetAppRole(dbConn2, cookie2)

                        MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Me.uiTrnPurchaseOrder3_OpenRowMaster(channel_id, order_id, dbConn2)
                        Me.uiTrnPurchaseOrder3_OpenRowDetil(channel_id, order_id, dbConn2)
                        Me.uiTrnPurchaseOrder3_OpenRowPaymReq(channel_id, order_id, dbConn2)
                        Me.uiTrnPurchaseOrder3_OpenRowPurchaseReq(channel_id, order_id, dbConn2)
                        Me.uiTrnPurchaseOrder3_OpenRowTOPDetil(channel_id, order_id, dbConn2)
                        Me.LOCKING_FORM("OPENROW")
                    Catch ex As Exception
                        Throw ex
                    Finally
                        If dbConn2.State = ConnectionState.Open Then
                            clsApplicationRole.UnsetAppRole(dbConn2, cookie2)
                            dbConn2.Close()
                        End If
                    End Try
                End If
            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '============ ADD PTS 20141006==========================
                dbTrans.Rollback()
                '======================================================
            Finally
                If dbConn1.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn1, dbTrans, cookie)
                    dbConn1.Close()
                End If
            End Try
        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Me.uiTrnPurchaseOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
        Me.uiTrnPurchaseOrder3_TotalCalculate()


        ''=========== ATTACHMENT ==============================================================
        Dim tbl_TrnOrderAttachment_Changes As DataTable
        Dim dbConnFiles As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFiles)
        'Dim dbTransFiles As OleDb.OleDbTransaction = Nothing
        Dim cookieFiles As Byte() = Nothing
        Me.GV_OrderAttachment.CloseEditor()
        Me.BindingContext(Me.tbl_TrnOrderAttachment).EndCurrentEdit()
        tbl_TrnOrderAttachment_Changes = Me.tbl_TrnOrderAttachment.GetChanges()

        If result <> FormSaveResult.SaveError Then
            If tbl_TrnOrderAttachment_Changes IsNot Nothing Then
                Try
                    order_id = tbl_TrnOrder_Temp.Rows(0).Item("order_id")
                    dbConnFiles.Open()
                    clsApplicationRole.SetAppRole(dbConnFiles, cookieFiles)
                    'dbTransFiles = dbConnFiles.BeginTransaction()
                    'clsApplicationRole.SetAppRole(dbConn1, dbTrans, cookie)

                    For i = 0 To Me.tbl_TrnOrderAttachment.Rows.Count - 1
                        If Me.tbl_TrnOrderAttachment.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderAttachment.Rows(i).Item("order_id") = order_id
                        End If
                    Next
                    success = Me.uiTransaksiOrder_SaveAttachment(order_id, tbl_TrnOrderAttachment_Changes, MasterDataState, dbConnFiles) ', dbTransFiles)
                    'If Not success Then
                    '    GoTo rollbackFiles
                    'End If
                    If Not success Then Throw New Exception("Error: Save Attachment Data at Me.uiTransaksiJasaKontenAttachment_Save(tbl_TrnJasakontenattachment_Changes)")
                    Me.tbl_TrnOrderAttachment.AcceptChanges()

                    result = FormSaveResult.SaveSuccess
                    'dbTransFiles.Commit()

                    'If result = FormSaveResult.SaveSuccess Then
                    '    GoTo save_confirmationFiles
                    'End If

                    'rollbackFiles:
                    '                dbTransFiles.Rollback()

                    'save_confirmationFiles:

                    If SHOW_SAVE_CONFIRMATION Then
                        Try
                            Me.uiTransaksiOrder_OpenRowAttachment(order_id, dbConnFiles)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If

                Catch ex As Exception
                    result = FormSaveResult.SaveError
                    MessageBox.Show("Data Attachment Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'dbTransFiles.Rollback()
                Finally
                    'clsApplicationRole.UnsetAppRole(dbConnFiles, dbTransFiles, cookieFiles)
                    clsApplicationRole.UnsetAppRole(dbConnFiles, cookieFiles)
                    dbConnFiles.Close()
                End Try

            Else
                result = FormSaveResult.Nochanges
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("All changes Attachment has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        ''===================================================================================================================================================


        Me.ReservedItem = False
        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
        RaiseEvent FormAfterSave(order_id, result)
        Me.Cursor = Cursors.Arrow
    End Function

    Private Function uiTrnPurchaseOrder3_SaveMaster(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
                                                    ByRef dbconn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean
        '======== remark PTS 21041006 ============== 
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        '=============================================
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        Try
            ' Save data: transaksi_order
            dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrder_Insert", dbconn, dbTrans)
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
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.TinyInt, 1, "order_approved"))
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
            dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdelivery_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "orderdelivery_date"))

            dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrder_Update", dbconn, dbTrans)
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
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifyby", Me.UserName))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_modifydate", Now()))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_discount", System.Data.DataRowVersion.Current, Nothing))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_source", System.Data.OleDb.OleDbType.VarWChar, 40, "order_source"))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertype_id", System.Data.OleDb.OleDbType.VarWChar, 40, "ordertype_id"))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revno", System.Data.OleDb.OleDbType.VarWChar, 8, "order_revno"))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "order_revdate"))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_revdesc", System.Data.OleDb.OleDbType.VarWChar, 510, "order_revdesc"))
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_approved", System.Data.OleDb.OleDbType.TinyInt, 1, "order_approved"))
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
            dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdelivery_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "orderdelivery_date"))
            dbDA = New OleDb.OleDbDataAdapter
            dbDA.UpdateCommand = dbCmdUpdate
            dbDA.InsertCommand = dbCmdInsert

            Try
                '======================== REMARK PTS 20141006 karena sudah pake dbconn transak udah di open dari atas, jadi gk perlu di open lagi==========
                'dbconn.Open()
                '==========================================================================================================================================
                dbDA.Update(objTbl)

                order_id = objTbl.Rows(0).Item("order_id")
                'Me.order_id_fordelivery = order_id
                Me.tbl_TrnOrder_Temp.Clear()
                Me.tbl_TrnOrder_Temp.Merge(objTbl)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            Finally
                '======================== REMARK PTS 20141006 karena sudah pake dbconn transak jadi jangan dulu di close dbconn nya==========
                'dbconn.Close()
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    '====================== UPDATE DI TRANSAKSI REQUESTDETIL IS ORDERED NYA ==============================
    Private Function uiTrnPurchaseOrder3_SaveRequestDetil(ByRef request_id As Object, ByRef requestdetil_line As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
                                                          ByRef dbConn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean '================ ADD transact PTS 20141006 ================
      
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_requestdetil
        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil2_ReqDetilUpdate", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 30, "request_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "requestdetil_line"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate

        Try
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak udah di open dari atas, jadi gk perlu di open lagi==========
            'dbConn.Open()
            '==========================================================================================================================================
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak jadi jangan dulu di close dbconn nya==========
            'dbConn.Close()
        End Try

        Return True
    End Function
    Private Function uiTrnPurchaseOrder3_SaveDetil(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
                                                   ByRef dbconn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean

        '======================================= REMARK PTS 20141006 ==================================
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        '==============================================================================================

        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        ' Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderdetil2
        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Insert2", dbconn, dbTrans)
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
        dbCmdInsert.Parameters("@order_id").Value = order_id

        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Update2", dbconn, dbTrans)
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
        dbCmdUpdate.Parameters("@order_id").Value = order_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak udah di open dari atas, jadi gk perlu di open lagi==========
            'dbconn.Open()
            '==========================================================================================================================================
            dbDA.Update(objTbl)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak jadi jangan dulu di close dbconn nya==========
            'dbconn.Close()
        End Try
        Return True
    End Function
    Private Function uiTrnPurchaseOrder3_SaveUse(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

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
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True
    End Function

    '=================== REMARK PTS 20141006 ===================================== GK DIPAKE INI JUGA
    Private Function uiTrnPurchaseOrder3_SaveDetilPaymReq(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
                                                          ByRef dbconn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean
        ' Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderpaymreq
        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Insert", dbconn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Update", dbconn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_line", System.Data.OleDb.OleDbType.Integer, 4, "orderpaymreq_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymentreq_id", System.Data.OleDb.OleDbType.VarWChar, 30, "paymentreq_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "orderpaymreq_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderpaymreq_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderpaymreq_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters("@order_id").Value = order_id


        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderpaymreq_Delete", dbconn, dbTrans)
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
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak udah di open dari atas, jadi gk perlu di open lagi==========
            'dbconn.Open()
            '==========================================================================================================================================
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak jadi jangan dulu di close dbconn nya==========
            'dbConn.Close()
        End Try

        Return True
    End Function
    '======================================================================================================
    '============================ REMARK PTS 20141006 ========================== GK DIPAKE INI
    'Private Function uiTrnPurchaseOrder3_SaveDetilPurchaseReq(ByRef request_id As Object, ByRef requestdetil_line As Object, ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Dim dbCmdUpdate As OleDb.OleDbCommand
    '    Dim dbDA As OleDb.OleDbDataAdapter

    '    ' Save data: transaksi_requestdetil
    '    dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnRequest_Update", dbConn)
    '    dbCmdUpdate.CommandType = CommandType.StoredProcedure
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@request_id", System.Data.OleDb.OleDbType.VarWChar, 30))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_refreference", System.Data.OleDb.OleDbType.VarWChar, 24))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_ordered", System.Data.OleDb.OleDbType.Boolean, 1))
    '    dbCmdUpdate.Parameters("@request_id").Value = request_id
    '    dbCmdUpdate.Parameters("@requestdetil_line").Value = requestdetil_line
    '    dbCmdUpdate.Parameters("@requestdetil_refreference").Value = order_id
    '    dbCmdUpdate.Parameters("@requestdetil_ordered").Value = 1

    '    dbDA = New OleDb.OleDbDataAdapter
    '    dbDA.UpdateCommand = dbCmdUpdate

    '    Try
    '        dbConn.Open()
    '        dbDA.Update(objTbl)

    '    Catch ex As Data.OleDb.OleDbException
    '        MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return False
    '    Finally
    '        dbConn.Close()
    '    End Try

    '    Return True
    'End Function
    '======================================================================================================================

    Private Function uiTrnPurchaseOrder3_SaveDetilEps(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
                                                      ByRef dbconn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_orderdetileps
        dbCmdInsert = New OleDb.OleDbCommand("to_TrnOrderdetilEps_Insert", dbconn, dbTrans)
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


        dbCmdUpdate = New OleDb.OleDbCommand("to_TrnOrderdetilEps_Update", dbconn, dbTrans)
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


        dbCmdDelete = New OleDb.OleDbCommand("cp_TrnOrderdetileps_Delete", dbconn, dbTrans)
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
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak udah di open dari atas, jadi gk perlu di open lagi==========
            'dbconn.Open()
            '==========================================================================================================================================
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            '======================== REMARK PTS 20141006 karena sudah pake dbconn transak jadi jangan dulu di close dbconn nya==========
            'dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnPurchaseOrder3_PrintPreview() As Boolean
        'print data
        Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String = "nothing"
        Dim criteria As String = ""
        Dim channel_id As String = ""
        Dim criteria_history As String = ""
        Dim criteria_TOP As String = ""
        Dim frmPrint As dlgViewRptPO_3 = New dlgViewRptPO_3(Me.DSN)
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

        criteria_TOP = String.Format(" order_id = '{0}' ", order_id)

        frmPrint.SetIDCriteria(criteria, criteria_history, criteria_TOP)

        frmPrint.ShowDialog(Me)
    End Function

    Private Function uiTrnPurchaseOrder3_Print() As Boolean
        Dim i As Integer
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim criteria_history As String = ""
        Dim channel_id As String = ""
        '
        Dim oPrint As clsPrintPO_3 = New clsPrintPO_3(Me.DSN)
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

        'Dim OPrintSPK As clsPrintROSPK = New clsPrintROSPK(Me.DSN)

        If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
            MsgBox("Pilih data dulu..")
            Exit Function
        End If

        ''ambil row yang dipilih di datagrid
        'criteria = String.Empty
        'For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
        '    row = Me.DgvTrnOrder.SelectedRows(i)
        '    If row.Cells("order_spkrequired").Value Then
        '        order_id = row.Cells("order_id").Value
        '        channel_id = row.Cells("channel_id").Value

        '        If criteria = "" Then
        '            criteria = String.Format(" order_id = '{0}' ", order_id)
        '        Else
        '            criteria = String.Format(" {1} or order_id = '{0}' ", order_id, criteria)
        '        End If
        '    End If
        'Next

        'If criteria <> String.Empty Then
        '    criteria &= " and channel_id='" + channel_id + "'"
        '    'OPrintSPK.SetIDCriteria(criteria)
        '    'OPrintSPK.Cetak()
        'End If

    End Function
    Private Function uiTrnPurchaseOrder3_Delete() As Boolean
        'Dim res As String = ""
        'Dim order_id As Object = New Object

        'Me.Cursor = Cursors.WaitCursor
        'RaiseEvent FormBeforeDelete(order_id)

        'Me.Cursor = Cursors.WaitCursor
        'If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then

        '    res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If res = DialogResult.Yes Then
        '        'Me.uiTrnPurchaseOrder3_DeleteRow(Me.DgvTrnOrder.CurrentRow.Index)
        '    End If
        'End If
        'RaiseEvent FormAfterDelete(order_id)
        'Me.Cursor = Cursors.Arrow
    End Function

    Private Function uiTrnPurchaseOrder3_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim order_id As String
        Dim channel_id As String
        Dim row As DataGridViewRow
        Dim i As Integer
        Dim order_canceled As Boolean
        Dim errorPA As Decimal = 0
        Dim order_approved As Integer = 0
        Dim cookie As Byte() = Nothing

        order_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("order_id").Value
        channel_id = Me.DgvTrnOrder.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim tbl_jurnal As DataTable = New DataTable
            Dim error_messageadvance As Decimal = 0
            Dim error_messagebpb As Decimal = 0
            Me.uiTrnPurchaseOrder3_OpenRowMaster(channel_id, order_id, dbConn)
            'j += 1
            Me.uiTrnPurchaseOrder3_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowPaymReq(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowPurchaseReq(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderApproval_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowTOPDetil(channel_id, order_id, dbConn)
            Me.uiTransaksiOrder_OpenRowAttachmentRequest(order_id, dbConn)
            Me.obj_Budget_id.Enabled = False
            Me.cbo_Budget_name.Enabled = False

            'Dim h As Integer
            'Dim y As Integer
            'Dim tbl_orderAdvance As DataTable = New DataTable

            'If Me.DgvTrnOrderdetil.Rows.Count > 0 Then

            '    For h = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
            '        If order_id <> String.Empty Then
            '            tbl_jurnal.Clear()
            '            Me.DataFill(tbl_jurnal, "to_TrnOrderdetil_SelectJurnalBPB", String.Format("order_id = '{0}' AND orderdetil_line = {1}", order_id, clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)))
            '            tbl_orderAdvance.Clear()
            '            Dim orderdetil_line As Integer = clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)
            '            Me.DataFill(tbl_orderAdvance, "pr_TrnOrderdetilAdvanceForOrder_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND isadvance <> 0 and advance_canceled = 0", order_id, orderdetil_line))

            '            If tbl_jurnal.Rows.Count > 0 Or tbl_orderAdvance.Rows.Count > 0 Then
            '                Dim u As Integer

            '                For u = 0 To tbl_jurnal.Rows.Count - 1
            '                    If tbl_jurnal.Rows(u).Item("terimabarang_id") <> "" Or clsUtil.IsDbNull(tbl_jurnal.Rows(u).Item("isadvance"), 0) = 1 Then
            '                        error_messagebpb += 1

            '                    End If
            '                Next
            '                For y = 0 To tbl_orderAdvance.Rows.Count - 1
            '                    If clsUtil.IsDbNull(tbl_orderAdvance.Rows(y).Item("isadvance"), 0) <> 0 Then
            '                        error_messageadvance += 1

            '                    End If
            '                Next
            '            End If
            '        End If
            '    Next
            'End If

            'If error_messageadvance > 0 Then
            '    Me.errorPA = True
            'Else
            '    Me.errorPA = False
            'End If

            'If Me._FORMMODE <> "VIEW" Then
            '    'cek data approval
            '    If Me.DgvTrnOrder.Rows.Count <> 0 Then
            '        row = Me.DgvTrnOrder.SelectedRows(i)
            '        order_canceled = row.Cells("order_canceled").Value
            '        order_approved = row.Cells("order_approved2").Value

            '        If order_approved = 1 And order_canceled = False Then
            '            Me.btnApp.Enabled = True
            '            Me.chkOrder_canceled.Enabled = False
            '        ElseIf order_approved = 0 And order_canceled = False Then
            '            Me.btnApp.Enabled = True
            '            Me.chkOrder_canceled.Enabled = True
            '        ElseIf order_approved = 0 And order_canceled = True Then
            '            Me.btnApp.Enabled = False
            '            Me.chkOrder_canceled.Enabled = False
            '        ElseIf order_approved = 2 And order_canceled = True Then
            '            Me.btnApp.Enabled = False
            '            Me.chkOrder_canceled.Enabled = False
            '        ElseIf order_approved = 2 And order_canceled = False Then
            '            Me.btnApp.Enabled = True
            '            Me.chkOrder_canceled.Enabled = True
            '        End If
            '    End If

            '    ' cek data BPJ dan PA
            '    If (error_messagebpb > 0 Or error_messageadvance > 0) Then
            '        Me.chkOrder_canceled.Enabled = False
            '        Me.btnApp.Enabled = False
            '        Me.tbtnSave.Enabled = False
            '    End If
            'Else
            '    Me.btnApp.Visible = False
            'End If

            Me.uiTrnPurchaseOrder3_Lock()
            Me.IsiBudgetName()
            Me.LOCKING_FORM("OPENROW")

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnPurchaseOrder3_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try


        ''==================== ATTACHMENT =================
        Dim dbConnFiles As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFiles)
        Dim cookieFiles As Byte() = Nothing
        Try
            dbConnFiles.Open()
            clsApplicationRole.SetAppRole(dbConnFiles, cookieFiles)
            Me.uiTransaksiOrder_OpenRowAttachment(order_id, dbConnFiles)

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnRentalOrder3_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConnFiles, cookieFiles)
            dbConnFiles.Close()
        End Try
        '========================================

        RaiseEvent FormAfterOpenRow(order_id)

        Me.Cursor = Cursors.Arrow
        Return True
    End Function

    '========================================= ADD PTS 20141003 ===============================================
    Private Function uiTrnPurchaseOrder3_OpenRowAfterApprove(ByVal order_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Dim channel_id As String
        Dim row As DataGridViewRow
        Dim i As Integer
        Dim order_canceled As Boolean
        Dim errorPA As Decimal = 0
        Dim order_approved As Integer = 0
        Dim cookie As Byte() = Nothing

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            Dim tbl_jurnal As DataTable = New DataTable
            Dim error_messageadvance As Decimal = 0
            Dim error_messagebpb As Decimal = 0

            Me.uiTrnPurchaseOrder3_OpenRowMaster(Me._CHANNEL, order_id, dbConn)
        

            Me.uiTrnPurchaseOrder3_OpenRowDetil(Me._CHANNEL, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowPaymReq(Me._CHANNEL, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowPurchaseReq(Me._CHANNEL, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderApproval_OpenRowDetil(Me._CHANNEL, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(Me._CHANNEL, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowTOPDetil(Me._CHANNEL, order_id, dbConn)

            Me.obj_Budget_id.Enabled = False
            Me.cbo_Budget_name.Enabled = False

            Dim h As Integer
            Dim y As Integer
            Dim tbl_orderAdvance As DataTable = New DataTable

            If Me.DgvTrnOrderdetil.Rows.Count > 0 Then

                For h = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
                    If order_id <> String.Empty Then
                        tbl_jurnal.Clear()
                        Me.DataFill(tbl_jurnal, "to_TrnOrderdetil_SelectJurnalBPB", String.Format("order_id = '{0}' AND orderdetil_line = {1}", order_id, clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)))
                        tbl_orderAdvance.Clear()
                        Dim orderdetil_line As Integer = clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)
                        Me.DataFill(tbl_orderAdvance, "pr_TrnOrderdetilAdvanceForOrder_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND isadvance <> 0 and advance_canceled = 0", order_id, orderdetil_line))

                        If tbl_jurnal.Rows.Count > 0 Or tbl_orderAdvance.Rows.Count > 0 Then
                            Dim u As Integer

                            For u = 0 To tbl_jurnal.Rows.Count - 1
                                If tbl_jurnal.Rows(u).Item("terimabarang_id") <> "" Or clsUtil.IsDbNull(tbl_jurnal.Rows(u).Item("isadvance"), 0) = 1 Then
                                    error_messagebpb += 1

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
                Me.errorPA = True
            Else
                Me.errorPA = False
            End If
            If Me._FORMMODE <> "VIEW" Then
                'cek data approval
                If Me.DgvTrnOrder.Rows.Count <> 0 Then
                    row = Me.DgvTrnOrder.SelectedRows(i)
                    order_canceled = row.Cells("order_canceled").Value
                    order_approved = row.Cells("order_approved2").Value
                    If order_approved = 1 And order_canceled = False Then
                        Me.btnApp.Enabled = True
                        Me.chkOrder_canceled.Enabled = False
                        'ElseIf order_approved = 1 And order_canceled = True Then
                        '    Me.btnApp.Enabled = False
                        '    Me.chkOrder_canceled.Enabled = False
                    ElseIf order_approved = 0 And order_canceled = False Then
                        Me.btnApp.Enabled = True
                        Me.chkOrder_canceled.Enabled = True
                    ElseIf order_approved = 0 And order_canceled = True Then
                        Me.btnApp.Enabled = False
                        Me.chkOrder_canceled.Enabled = False
                    ElseIf order_approved = 2 And order_canceled = True Then
                        Me.btnApp.Enabled = False
                        Me.chkOrder_canceled.Enabled = False
                    ElseIf order_approved = 2 And order_canceled = False Then
                        Me.btnApp.Enabled = True
                        Me.chkOrder_canceled.Enabled = True
                    End If
                End If
                ' cek data BPJ dan PA
                If (error_messagebpb > 0 Or error_messageadvance > 0) Then
                    Me.chkOrder_canceled.Enabled = False
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
                'If (error_messagebpb > 0 Or error_messageadvance > 0) And order_canceled = False Then
                '    'MsgBox("This Order has been have PA and BPJ")
                '    Me.chkOrder_canceled.Enabled = False
                '    Me.btnApp.Enabled = True
                '    'Me.DgvTrnOrderdetil.ReadOnly = True
                '    Me.tbtnSave.Enabled = False
                'ElseIf (error_messagebpb > 0 Or error_messageadvance > 0) And order_canceled = True Then
                '    Me.chkOrder_canceled.Enabled = False
                '    Me.btnApp.Enabled = True
                '    'Me.DgvTrnOrderdetil.ReadOnly = True
                '    Me.tbtnSave.Enabled = False
                'End If
            Else
                Me.btnApp.Visible = False
            End If
            Me.uiTrnPurchaseOrder3_Lock()
            Me.IsiBudgetName()
        'Me._ORDER_SOURCE = "FromRequest"
            If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved2") = 1 Then
                Me.chkOrder_canceled.Enabled = False
                btnApp.Text = "Disapprove"
            Else
                Me.chkOrder_canceled.Enabled = True
                btnApp.Text = "Approve"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnPurchaseOrder3_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
        RaiseEvent FormAfterOpenRow(order_id)
        Me.Cursor = Cursors.Arrow
        Return True
    End Function
    ''
    '==========================================================================================================


    Private Function uiTrnPurchaseOrder3_OpenRowMaster(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrder_Select3", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@Limit", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        'dbCmd.Parameters("@Criteria").Value = "order_id='" + order_id + "' and channel_id='" + Me._CHANNEL + "'"
        dbCmd.Parameters("@Limit").Value = Me.nudSearchRowLimit.Value
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrder_Temp.Clear()


        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnOrder_Temp)

            If Me.formstatus = "OPENROW" Then
                '===========PTS ADD 20130802=========
                Me.tbl_MstRekanan_contact.Clear()
                Me.ComboFill(Me.obj_Order_othercost, "rekanancontact_line", "rekanancontact_name", Me.tbl_MstRekanan_contact, "pr_MstRekananContact_Select", "rekanan_id = '" & Me.tbl_TrnOrder_Temp.Rows(0).Item("rekanan_id") & "'")
                '======================================
            End If
            ''
            Me.BindingStart()

            ''========================= ADD PTS 20141006 =========================
            'If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved") = 0 Then
            '    Me.chkApproved.Checked = False
            'ElseIf Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved") = 1 Then
            '    Me.chkApproved.Checked = True
            'ElseIf Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved") = 2 Then
            '    Me.chkApproved.Checked = False
            'End If
            ''=====================================================================

            If Me._FORMMODE <> "VIEW" Then
                Me.Approve(Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved2"))
                If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved2") = 1 Then

                    Me.PnlDataMaster1.Enabled = False
                    'Me.PnlDataMaster2.Enabled = False
                    Me.cbo_Periode_id.Enabled = False
                    Me.PnlDataFooter_total.Enabled = False
                    Me.obj_order_note.Enabled = False
                    Me.PnlDataMaster2.BackColor = Color.Tan
                    Me.ftabDataDetil_Info.Enabled = False
                    Me.ftabDataDetil_PaymReq.Enabled = False
                    Me.ftabDataDetil_Sign.Enabled = False
                    Me.tbtnSave.Enabled = False
                    Me.btnAddItem.Enabled = False
                    Me.tbtnDel.Enabled = False
                    Me.tbtnEdit.Enabled = False
                    Me.tbtnPrint.Enabled = True
                    Me.tbtnPrintPreview.Enabled = True
                    'If clsUtil.IsDbNull(Me.tbl_MstUser.Rows(0).Item("user_isauthorized_toapprove"), 0) <> 1 Then
                    Me.chkOrder_canceled.Enabled = False
                    'End If
                    'Me.obj_Order_othercost.Enabled = False
                    Me.obj_order_revdesc.ReadOnly = True
                Else
                    Me.PnlDataMaster1.Enabled = True
                    Me.PnlDataMaster2.Enabled = True
                    Me.cbo_Periode_id.Enabled = True
                    Me.PnlDataFooter_total.Enabled = True
                    Me.obj_order_note.Enabled = True
                    Me.PnlDataMaster2.BackColor = Color.PapayaWhip
                    Me.ftabDataDetil_Info.Enabled = True
                    Me.ftabDataDetil_PaymReq.Enabled = True
                    Me.ftabDataDetil_Sign.Enabled = True
                    '========20140519=====remark pts===
                    'Me.tbtnSave.Enabled = True
                    '===========================
                    Me.btnAddItem.Enabled = True
                    Me.tbtnDel.Enabled = False
                    Me.tbtnEdit.Enabled = True
                    Me.tbtnPrint.Enabled = True
                    Me.tbtnPrintPreview.Enabled = True
                    '=================remark 20140519 PTS=========================
                    'Me.chkOrder_canceled.Enabled = True
                    '==================Modified 20140519 PTS======================
                    If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_canceled") = 0 Then
                        Me.chkOrder_canceled.Enabled = True
                        Me.tbtnSave.Enabled = True
                    Else
                        Me.chkOrder_canceled.Enabled = False
                        Me.tbtnSave.Enabled = False
                    End If
                    '=============================================================
                    'Me.obj_Order_othercost.Enabled = True
                    Me.obj_order_revdesc.ReadOnly = False


                End If
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
        Me.tbl_order_delivery_date = Me.tbl_TrnOrder_Temp.Copy
    End Function
    Private Function uiTrnPurchaseOrder3_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Select2", dbConn)
        ''''dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetilVersi2_Select", dbConn)

        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        ''''dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        '' dbCmd.Parameters("@Criteria").Value = "order_id='" + order_id + "' and channel_id='" + Me._CHANNEL + "'"
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
        Try
            dbDA.Fill(Me.tbl_TrnOrderdetil)
            Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderdetil

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try


    End Function
    Private Function uiTrnPurchaseOrder3_OpenRowPaymReq(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3_OpenRowPaymReq()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3_OpenRowPurchaseReq(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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

        Me.tbl_TrnRequestdetil = clsDataset2.CreateTblRequestdetil
        Me.tbl_TrnRequestdetil.Columns("requestdetil_refreference").DefaultValue = order_id
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").AutoIncrement = True
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnRequestdetil.Columns("requestdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnRequestdetil)
            Me.DgvTrnRequestdetil.DataSource = Me.tbl_TrnRequestdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3_OpenRowPurchaseReq()" & vbCrLf & ex.Message)
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
            'Me.dgvTrnOrderApproval.DataSource = Me.tbl_TrnOrderApproval
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OrderApproval_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tblBPB As DataTable = New DataTable

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_selectfororder", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}' and terimabarang_isdisabled = 0", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tblBPB.Clear()

        Try
            dbDA.Fill(tblBPB)

            Me.FormatDgvTrnTerimabarang(Me.dgvtrnBPB)
            Me.dgvtrnBPB.DataSource = tblBPB
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OrderBPB_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function uiTrnPurchaseOrder3OpenRow_DocCirc(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OpenRow_DocCirc()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3OpenRow_InvReceipt(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3OpenRow_InvReceipt()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3OpenRow_Advance(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
    Private Function uiTrnPurchaseOrder3OpenRow_Episode(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Me.FormatDgvTrnOrderdetileps(Me.dgvepisode)
            Me.dgvepisode.DataSource = Me.tbl_TrnOrderdetileps
        Catch ex As Exception
            Throw New Exception(mUiName & ": _OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPurchaseOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, 0)
            Me.uiTrnPurchaseOrder3_RefreshPosition()
        End If
    End Function
    Private Function uiTrnPurchaseOrder3_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPurchaseOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOrder.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, DgvTrnOrder.CurrentCell.RowIndex - 1)
                Me.uiTrnPurchaseOrder3_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnPurchaseOrder3_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPurchaseOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOrder.CurrentCell.RowIndex < Me.DgvTrnOrder.Rows.Count - 1 Then
                Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, DgvTrnOrder.CurrentCell.RowIndex + 1)
                Me.uiTrnPurchaseOrder3_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnPurchaseOrder3_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPurchaseOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOrder.CurrentCell = Me.DgvTrnOrder(1, Me.DgvTrnOrder.Rows.Count - 1)
            Me.uiTrnPurchaseOrder3_RefreshPosition()
        End If
    End Function
    Private Function uiTrnPurchaseOrder3_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            Me.uiTrnPurchaseOrder3_OpenRow(Me.DgvTrnOrder.CurrentRow.Index)
            Me.uiTrnPurchaseOrder3_GetOrderCreator()
            'Me.txtAllPOAmount_perBudget.Text = String.Format("{0:#,##0.00}", 0)
            'Me.txtAllROAmount_perBudget.Text = String.Format("{0:#,##0.00}", 0)
            'Me.txtRO_plus_PO.Text = String.Format("{0:#,##0.00}", 0)
            IsiBudgetName()
        End If


    End Function
    Private Function uiTrnPurchaseOrder3_GetOrderCreator() As Boolean
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

            'Me.lbl_createby.Text = createby & modifyby
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiTrnPurchaseOrder3_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
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
                        Me.uiTrnPurchaseOrder3_Save()
                        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                        move = True
                    Case DialogResult.No
                        tbl_RequestdetilSelect.Clear()
                        Me.DataFill(tbl_RequestdetilSelect, "pr_TrnRequestHD_Select", "jurnaltype_id='" & Me._ORDER_SOURCE & "' AND requestdetil_ordered=0 AND request_programtype='" & Me._PROGRAMTYPE & "' AND requestdetil_qty>0 AND item_id<>'' ")
                        Me.ReservedItem = False
                        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                        move = True
                    Case DialogResult.Cancel
                        tbl_RequestdetilSelect.Clear()
                        Me.DataFill(tbl_RequestdetilSelect, "pr_TrnRequestHD_Select", "jurnaltype_id = '" & Me._ORDER_SOURCE & "' AND requestdetil_ordered=0 AND request_programtype='" & Me._PROGRAMTYPE & "' AND requestdetil_qty>0 AND item_id<>'' ")
                        Me.ReservedItem = False
                        Me.DgvTrnRequestdetil.Columns("requestdetil_ordered").Visible = True
                        move = False
                End Select
            Else
                move = True
            End If
            tbl_RequestdetilSelect.DefaultView.RowFilter = Nothing
        End If

        Return move

    End Function
    Private Function uiTrnPurchaseOrder3_ConfirmSaveBeforeAddItem(ByVal Message As String) As Boolean
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

        'If Me.DgvTrnOrder.CurrentCell IsNot Nothing Then

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

            res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Select Case res
                Case DialogResult.Yes
                    If Me.uiTrnPurchaseOrder3_FormError() Then
                        Return False
                    End If
                    Me.uiTrnPurchaseOrder3_Save()
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
        'End If
        Return move
    End Function

    Private Function uiTrnPurchaseOrder3_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()
            '==================== ADD 20180517 =========== CEK request apakah sudah jadi order apakah belum
            Dim CekReqNoOrdered As DataTable = New DataTable()
            Dim request_id As String
            Dim requestdetil_Line As Integer
            For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                If Me.tbl_TrnOrderdetil.Rows(i).RowState = DataRowState.Added Then
                    request_id = Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_requestid_ref")
                    requestdetil_Line = Me.tbl_TrnOrderdetil.Rows(i).Item("requestdetil_line")
                    CekReqNoOrdered.Clear()
                    CekReqNoOrdered = CekRequestNotOrdered(request_id, requestdetil_Line).Copy
                    If CekReqNoOrdered.Rows.Count <> 0 Then
                        If CekReqNoOrdered.Rows(0).Item("requestdetil_ordered") = 1 Then
                            ErrorMessage = String.Format("{0} Line {1} is fulled by {2}", request_id, requestdetil_Line, CekReqNoOrdered.Rows(0).Item("requestdetil_refreference"))
                            Throw New Exception(ErrorMessage)
                        End If
                    End If
                End If
            Next

            '======== ADD PTS 20150622 ===== cek cancel order ==============
            Dim tbl_ordercek As DataTable = New DataTable
            Dim approve As Integer
            Me.DataFill(tbl_ordercek, "to_TalentorderApproved_Select", String.Format(" order_id = '{0}' ", Me.obj_Order_id.Text))

            If Me.chkOrder_canceled.Checked = True Then
                If tbl_ordercek.Rows.Count <> 0 Then
                    approve = tbl_ordercek.Rows(0).Item("order_approved")
                    If approve = 1 Then
                        ErrorMessage = "Order cant be canceled, because it already approved !"
                        Throw New Exception(ErrorMessage)
                    End If
                End If
            End If
            '===============================================================

            'cek periode sudah diisi''
            If CType(Me.cbo_Periode_id.SelectedValue, String) = "0" Then
                ErrorMessage = "Periode belum diisi"
                Me.objFormError.SetError(Me.cbo_Periode_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Periode_id, "")
            End If

            'cek rekanan
            If Me.cbo_Rekanan_name.SelectedValue = 0 Then
                ErrorMessage = "Rekanan belum diisi"
                Me.objFormError.SetError(Me.cbo_Rekanan_name, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Rekanan_name, "")
            End If

            'cek currency
            If Me.cbo_Currency.SelectedValue = 0 Then
                ErrorMessage = "Currency belum diisi"
                Me.objFormError.SetError(Me.cbo_Currency, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.cbo_Currency, "")
            End If

            '=================== ADD PTS 20150205 =========================
            'cek Order sudah ditarik RV
            If Me.obj_Order_id.Text <> "" Or Me.obj_Order_id.Text <> String.Empty Then
                If Me.uiTrnPurchaseOrder3_CekOrderTarikRV(Me.obj_Order_id.Text) = True Then
                    ErrorMessage = "Order sudah ditarik RV, data tidak dapat dicancel atau di update !"
                    Throw New Exception(ErrorMessage)
                End If
            End If

            '========= TOP LOcking =============
            If Me.chkOrder_canceled.Checked = False Then
                Dim TotalForeignInclDisc As Decimal = 0
                Dim TotalAmountTOP As Decimal = 0

                Dim percent_total As Decimal = 0

                Dim count_AP As Integer = 0
                Dim count_NoFillPayPlant As Integer = 0
                Dim count_percent0 As Integer = 0

                '===================== REMARK 20191205 =========
                'For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                '    TotalForeignInclDisc = TotalForeignInclDisc + Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_rowtotalforeign_incldisc")
                'Next
                '===================== MODIFIED 20191205 =======
                For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                    TotalForeignInclDisc = TotalForeignInclDisc + Math.Round(((tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreign") - _
                                                                                               tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount")) * _
                                                                                               1) * _
                                                                                               tbl_TrnOrderdetil.Rows(i).Item("orderdetil_qty"), 2, MidpointRounding.AwayFromZero)
                Next

                '================================================

                If Me.tbl_TrnOrderTOPdetil.Rows.Count <> 0 Then
                    For w As Integer = 0 To Me.tbl_TrnOrderTOPdetil.Rows.Count - 1
                        If Me.tbl_TrnOrderTOPdetil.Rows(w).RowState <> DataRowState.Deleted Then
                            TotalAmountTOP = TotalAmountTOP + Me.tbl_TrnOrderTOPdetil.Rows(w).Item("orderterm_amount")
                        End If
                    Next
                Else
                    ErrorMessage = "Top harus diisi !"
                    Throw New Exception(ErrorMessage)
                End If

                If TotalForeignInclDisc <> TotalAmountTOP Then
                    ErrorMessage = "Total Amount TOP dengan total amount order tidak sama !"
                    Throw New Exception(ErrorMessage)
                End If

                For a As Integer = 0 To Me.DgvTrnOrderTOPdetil.RowCount - 1
                    If Me.DgvTrnOrderTOPdetil.Rows(a).Cells("orderterm_payplant").Value = "AP" Then
                        count_AP = count_AP + 1
                    End If
                Next

                For up As Integer = 0 To Me.DgvTrnOrderTOPdetil.RowCount - 1
                    If Me.DgvTrnOrderTOPdetil.Rows(up).Cells("orderterm_payplant").Value = "" Then
                        count_NoFillPayPlant = count_NoFillPayPlant + 1
                    End If
                Next

                If count_percent0 > 0 Then
                    MsgBox("Term Percent cannot be zero value !", MsgBoxStyle.Information, "Information")
                    Exit Function
                End If

                If count_NoFillPayPlant > 0 Then
                    MsgBox("Pay Plant must be filled !", MsgBoxStyle.Information, "Information")
                    Exit Function
                End If

                If count_AP > 1 Then
                    MsgBox("Should not be more than one payment by AP !", MsgBoxStyle.Information, "Information")
                    Exit Function
                End If

            End If
            'Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try

        Return False

    End Function
    '=============================== ADD PTS 20150205 ================================
    Private Function uiTrnPurchaseOrder3_CekOrderTarikRV(ByVal order_id) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_cekRV As DataTable = New DataTable
        Dim errortrue As Boolean
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrder_HandleUpdateAfterRV", dbConn)
        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@order_id").Value = order_id  'String.Format("order_id='{0}'", order_id)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tbl_cekRV.Clear()

        dbConn.Open()
        clsApplicationRole.SetAppRole(dbConn, cookie)

        Try
            dbDA.Fill(tbl_cekRV)
            If tbl_cekRV.Rows.Count <> 0 Then
                errortrue = True
            Else
                errortrue = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return errortrue
    End Function
    '===================================================================================
    Private Function CekRequestNotOrdered(ByVal request_id As String, requestdetil_line As Integer) As DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_CekReqNotOrdered As DataTable = New DataTable
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("prc_TrnOrder_CekTarikanRequest", dbConn)
        'dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@request_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@requestdetil_line", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@request_id").Value = request_id
        dbCmd.Parameters("@requestdetil_line").Value = requestdetil_line
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tbl_CekReqNotOrdered.Clear()

        dbConn.Open()
        clsApplicationRole.SetAppRole(dbConn, cookie)

        Try
            dbDA.Fill(tbl_CekReqNotOrdered)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return tbl_CekReqNotOrdered
    End Function


    Private Function uiTrnPurchaseOrder3_DetilCalculate(ByVal dgv As DataGridView, ByRef sumdetil As Decimal, ByRef sumPPH As Decimal, ByRef sumPPN As Decimal, ByRef sumDisc As Decimal) As Boolean
        Dim i As Integer
        Dim cPPN, cPPH, cDiscount, cSubtotal, totalrow As Decimal

        sumdetil = 0 : sumPPH = 0 : sumPPN = 0 : sumDisc = 0

        For i = 0 To dgv.Rows.Count - 1
            If Me.cbo_Currency.SelectedValue <> 1 Then
                cPPH = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_pphforeign").Value, 0)
                cPPN = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_ppnforeign").Value, 0)
                cDiscount = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_discount").Value, 0) * _
                            clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_qty").Value, 0)
                cSubtotal = clsUtil.IsDbNull(Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_rowtotalforeign"), 0) ''clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_rowtotalforeign").Value, 0)
            Else

                cPPH = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_pph").Value, 0)
                cPPN = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_ppn").Value, 0)
                cDiscount = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_discount").Value, 0) * _
                            clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_qty").Value, 0)
                cSubtotal = clsUtil.IsDbNull(dgv.Rows(i).Cells("orderdetil_rowtotalidr").Value, 0)
            End If

            totalrow = cSubtotal
            sumdetil += totalrow : sumPPH += cPPH : sumPPN += cPPN : sumDisc += cDiscount
            'End If
        Next
    End Function

    Private Function uiTrnPurchaseOrder3_TotalCalculate() As Boolean
        'Calculate Cost, Tax, and Total
        Dim [insurance], [transport], [operator], [other], [additional] As Decimal
        Dim [discount], [subtotal], [ppn], [pph] As Decimal
        Dim [gtotal] As Decimal

        If Me.tbl_TrnOrder_Temp.Rows.Count > 0 Then
            [insurance] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_insurancecost")
            [transport] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_transportationcost")
            [operator] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_operatorcost")
            [other] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_othercost")
            '[discount] = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_discount")
        Else
            [insurance] = 0
            [transport] = 0
            [operator] = 0
            [other] = 0
            '[discount] = 0
        End If

        [subtotal] = clsUtil.IsEmptyText(Me.calc_Order_subtotal.Text, 0)
        [additional] = [insurance] + [transport] + [operator] + [other]

        [pph] = Me.calc_Order_PPH.Text
        [ppn] = Me.calc_Order_PPN.Text
        [discount] = clsUtil.IsEmptyText(Me.calc_Order_Discount.Text, 0)

        [gtotal] = ([subtotal] - [discount] + [additional]) + ([ppn] - [pph])

        order_total = [gtotal]

        If [discount] > 0 Then
            Me.calc_Order_Discount.Text = String.Format("({0:#,##0.00})", [discount])
        Else
            Me.calc_Order_Discount.Text = String.Format("{0:#,##0.00}", [discount])
        End If

        If [pph] > 0 Then
            Me.calc_Order_PPH.Text = String.Format("({0:#,##0.00})", [pph])
        Else
            Me.calc_Order_PPH.Text = String.Format("{0:#,##0.00}", [pph])
        End If

        If Me.chkOrder_canceled.Checked Then
            Me.calc_Order_GTotal.Text = String.Format("{0:#,##0.00}", 0)
        Else
            Me.calc_Order_GTotal.Text = String.Format("{0:#,##0.00}", [gtotal])
        End If

        If Me.tbl_TrnOrder_Temp.Rows.Count <> 0 Then
            If Me.tbl_TrnOrder_Temp.Rows(0).Item("currency_id") = 1 Then
                Me.calc_Order_Discount.Text = String.Format("({0:#,##0})", [discount])
            Else
                Me.calc_Order_Discount.Text = String.Format("{0:#,##0.00}", [discount])
            End If
        Else
            If Me.cbo_Currency.SelectedValue = 1 Then
                Me.calc_Order_Discount.Text = String.Format("({0:#,##0})", [discount])
            Else
                Me.calc_Order_Discount.Text = String.Format("{0:#,##0.00}", [discount])
            End If

        End If


    End Function
#End Region

    Private Sub uiTrnPurchaseOrder3_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Me.uiTrnPurchaseOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
        Me.uiTrnPurchaseOrder3_TotalCalculate()

        Me.DgvTrnOrderdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
    End Sub

    Private Sub uiTrnPurchaseOrder3_FormBeforeNew() Handles Me.FormBeforeNew
        If Me._FORMMODE = "ENTRY" Then
            Me.calc_Order_GTotal.Text = "0.00"
            Me.calc_Order_subtotal.Text = "0.00000"
            Me.calc_Order_PPH.Text = "0.00"
            Me.calc_Order_PPN.Text = "0.00"

            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = False

            Me.DgvTrnOrderdetil.ReadOnly = False
            Me.DgvTrnOrderdetil.AllowUserToDeleteRows = True
            Me.DgvTrnOrderdetil.AllowUserToAddRows = True
        End If
    End Sub

    Private Function uiTrnPurchaseOrder3_LoadDataCombo() As Boolean
        Dim criteria As String = ""
        '==
        Try
            Dim tbl_channelnumber As New DataTable
            Me.tbl_MstChannel.Clear()
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "' ")

            tbl_channelnumber.Clear()
            Me.DataFill(tbl_channelnumber, "pr_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'", "")
            Me.channel_number = tbl_channelnumber.Rows(0).Item("channel_number").ToString

            Me.tbl_MstPeriode.Clear()
            Me.ComboFill(Me.cbo_Periode_id, "periode_id", "periode_name", Me.tbl_MstPeriode, "pr_MstPeriode_Select", " channel_id = '" & Me._CHANNEL & "' ")

            Me.tbl_MstStrukturUnit.Clear()
            Me.ComboFill(Me.cbo_Deptname, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturUnit, "ms_MstStrukturUnit_Select", "")

            'Me.tbl_StrukturUnit.Clear()
            'Me.DataFill(Me.tbl_MstUnit, "ms_MstStrukturUnit_Select", criteria)
            'Me.tbl_StrukturUnit.DefaultView.Sort = "strukturunit_name"

            Me.tbl_TrnBudget.Clear()
            Me.ComboFill(Me.cbo_Budget_name, "budget_id", "budget_name", Me.tbl_TrnBudget, "pr_TrnBudget_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.ComboFillNumeric(Me.cbo_budget_amount, "budget_id", "budget_amount", Me.tbl_TrnBudget, "pr_TrnBudget_Select", " channel_id ='" & Me._CHANNEL & "' ")

            Me.tbl_MstRekanan.Clear()
            Me.ComboFill(Me.cbo_Rekanan_name, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")

            Me.tbl_MstProgram.Clear()
            Me.ComboFill(Me.cbo_old_program_name, "old_program_id", "program_name", Me.tbl_MstProgram, "pr_MstRentalprogram_Select", "")
            ' Me.ComboFillFromDataTable(Me.cboSearchRekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan)

            Me.tbl_MstItem.Clear()
            Me.DataFill(Me.tbl_MstItem, "pr_MstItem_Select", criteria)
            Me.tbl_MstItem.DefaultView.Sort = "item_name"

            Me.tbl_MstUnit.Clear()
            Me.DataFill(Me.tbl_MstUnit, "pr_MstUnit_Select", criteria)
            Me.tbl_MstUnit.DefaultView.Sort = "unit_name"

            Me.tbl_MstCurrency.Clear()
            Me.DataFill(Me.tbl_MstCurrency, "pr_MstCurrency_Select", criteria)
            Me.tbl_MstCurrency.DefaultView.Sort = "currency_shortname"
            Me.ComboFill(Me.cbo_Currency, "currency_id", "currency_shortname", Me.tbl_MstCurrency, "pr_MstCurrency_Select", "")

            'buat test develop (approve sebagai spv).------------------------------------------------------------------
            If Me.Browser Is Nothing Then
                Me.DataFill(Me.tbl_MstUser, "cq_MstUser_Select", String.Format("username = '{0}'", "devproc"))
            End If
            '------------------------------------------------------------------------------------------------

            Me.COMBO_ISFILLED = True
        Catch ex As Exception
            Me.COMBO_ISFILLED = False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Try
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
                Me.DataFill(Me.tbl_MstUser, "cq_MstUser_Select", String.Format("username = '{0}'", Me.UserName))
            End If

            If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
                Me.chkSrchStatus.Checked = True
                Me.uiTrnPurchaseOrder3_LoadSupportingData()
                If Not Me.COMBO_ISFILLED Then
                    Me.uiTrnPurchaseOrder3_LoadDataCombo()
                End If

                Me.AddPayingData("AR", "Advance")
                Me.AddPayingData("YV", "YV")

                Me.DgvTrnOrder.DataSource = Me.tbl_TrnOrder

                Me.BindingStop()
                Me.BindingStart()

                Me.uiTrnPurchaseOrder3_Lock()
                Me.uiTrnPurchaseOrder3_NewData()

                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True

                Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
                Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED

                Me.chkSearchChannel.Checked = True
                Me.cboSearchChannel.SelectedValue = Me._CHANNEL
                Me.chkSearchChannel.Enabled = False
                Me.cboSearchChannel.Enabled = False
               

                If Me._PROGRAMTYPE = "PG" Then
                    Me.lblProgType.Text = "PROGRAM"
                    Me.chkSingleBudget.Enabled = False
                ElseIf Me._PROGRAMTYPE = "NP" Then
                    Me.lblProgType.Text = "NON PROGRAM"
                    Me.chkSingleBudget.Enabled = False
                End If

                Me.ReservedItem = False

                Me.obj_Request_id.ReadOnly = True
                Me.obj_Budget_id.ReadOnly = True
                Me.cbo_Budget_name.Enabled = False
                Me.cbo_Deptname.Enabled = False
                Me.obj_Rekanan_id.ReadOnly = True
                Me.cbo_Rekanan_name.Enabled = False

                Me.btnApp.Visible = False
                Me.InitLayoutUI()
                Me.LOCKING_FORM_LIST()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub uiTrnPurchaseOrder3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlatTabMain.SelectedIndexChanged
        Select Case FlatTabMain.SelectedIndex
            Case 0
                'Me.btnApp.Enabled = False
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.White
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro

                If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
                    Me.tbl_RequestdetilSelect.Clear()
                End If

                Me.ftabDataDetil.SelectedIndex = 0
                Me.LOCKING_FORM_LIST()
            Case 1
                If Me._FORMMODE = "ENTRY" Then
                    Me.tbtnSave.Enabled = True
                    Me.btnAddItem.Enabled = True
                    Me.tbtnDel.Enabled = False
                    Me.tbtnLoad.Enabled = False
                    Me.tbtnQuery.Enabled = False
                    Me.btnApp.Visible = True
                ElseIf Me._FORMMODE = "VIEW" Then
                    Me.tbtnSave.Enabled = False
                    Me.btnAddItem.Enabled = False
                    Me.tbtnDel.Enabled = False
                    Me.tbtnLoad.Enabled = False
                    Me.tbtnQuery.Enabled = False
                End If
                'Me.btnApp.Enabled = True
                Me.FlatTabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.FlatTabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then
                    If Me.formstatus = "OPENROW" Then
                        Me.uiTrnPurchaseOrder3_OpenRow(Me.DgvTrnOrder.CurrentRow.Index)
                        Me.IsiBudgetName()
                    Else
                        Me.formstatus = "NEW"
                        Me.uiTrnPurchaseOrder3_NewData()
                        Me.obj_Order_othercost.Enabled = True
                    End If

                Else
                    Me.formstatus = "NEW"
                    Me.uiTrnPurchaseOrder3_NewData()
                    Me.obj_Order_othercost.Enabled = True
                End If

        End Select

    End Sub
    Private Sub DgvTrnOrder_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrder.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnOrder.CurrentRow IsNot Nothing Then
            Me.formstatus = "OPENROW"
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
            Me.uiTrnPurchaseOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
            Me.uiTrnPurchaseOrder3_TotalCalculate()
            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
        End If
    End Sub
    Private Sub obj_Order_pph_percent_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.uiTrnPurchaseOrder3_TotalCalculate()
    End Sub
    Private Sub obj_Order_ppn_percent_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.uiTrnPurchaseOrder3_TotalCalculate()
    End Sub
    Private Sub btn_FindBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_FindBudget.Click
        Dim popUpFind As frmPopUpFind
        popUpFind = New frmPopUpFind(Me.DSN, "BUDGET", 1, "Budget", " ")
        popUpFind.ShowDialog()
    End Sub
    Private Sub obj_Budget_id_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Budget_id.Validated
        Me.cbo_Budget_name.SelectedValue = Me.obj_Budget_id.Text
    End Sub
  
    Private Sub cbo_Budget_name_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Budget_name.Validated
        'Me.obj_Budget_id.Text = Me.cbo_Budget_name.SelectedValue
        'Dim i, j As Integer
        'If Me.chkSingleBudget.Checked Then
        '    If Me.tbl_TrnOrderdetil.Rows.Count > 0 Then
        '        For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
        '            Me.tbl_TrnOrderdetil.Rows(i).Item("budget_id") = Me.cbo_Budget_name.SelectedValue
        '        Next
        '    End If
        '    Me.IsiBudgetName()
        '    If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
        '        For j = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
        '            Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_id").Value = 0
        '            Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_name").Value = ""
        '            Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_amount").Value = ""
        '        Next
        '    End If
        'End If
    End Sub
    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.Gainsboro
        Next

        activetab = Me.ftabDataDetil.SelectedIndex
        Me.ftabDataDetil.TabPages.Item(activetab).BackColor = Color.White

        If Me.obj_Order_id.Text <> "" Then
            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)

                If Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_DocCirculation" Then
                    'Me.uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                    Me.uiTrnPurchaseOrder3OpenRow_DocCirc(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                    'Me.uiTrnPurchaseOrder3OpenRow_Episode(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                ElseIf Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_InvRec" Then
                    Me.uiTrnPurchaseOrder3OpenRow_InvReceipt(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                ElseIf Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_Advance" Then
                    Me.uiTrnPurchaseOrder3OpenRow_Advance(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                ElseIf Me.ftabDataDetil.SelectedTab.Name = "ftabDataDetil_Episode" Then
                    Me.uiTrnPurchaseOrder3OpenRow_Episode(Me.DgvTrnOrder.Rows(Me.DgvTrnOrder.CurrentRow.Index).Cells("channel_id").Value, Me.obj_Order_id.Text, dbConn)
                End If
            Catch ex As Exception
                Throw New Exception(mUiName & ": _OpenRowDetil()" & vbCrLf & ex.Message)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub obj_Order_canceled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOrder_canceled.CheckedChanged

        If Me.chkOrder_canceled.Checked = True Then
            Me.PnlDataMaster1.Enabled = False
            Me.PnlDataMaster2.Enabled = False
            Me.PnlDataFooter_total.Enabled = False
            Me.obj_order_note.Enabled = False

            Me.PnlDataMaster2.BackColor = Color.Tan

            Me.ftabDataDetil_Detil.Enabled = False
            Me.ftabDataDetil_Info.Enabled = False
            Me.ftabDataDetil_PaymReq.Enabled = False
            Me.ftabDataDetil_Sign.Enabled = False

            Me.tbtnDel.Enabled = False
            Me.tbtnEdit.Enabled = False
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
            Me.btnApp.Enabled = False
            Dim i As Integer
            For i = 0 To Me.DgvTrnRequestdetil.Rows.Count - 1
                Me.DgvTrnRequestdetil.Rows(i).Cells("requestdetil_ordered").Value = False
            Next

        Else
            Me.PnlDataMaster1.Enabled = True
            Me.PnlDataMaster2.Enabled = True
            Me.PnlDataFooter_total.Enabled = True
            Me.obj_order_note.Enabled = True

            Me.PnlDataMaster2.BackColor = Color.PapayaWhip

            Me.ftabDataDetil_Detil.Enabled = True
            Me.ftabDataDetil_Info.Enabled = True
            Me.ftabDataDetil_PaymReq.Enabled = True
            Me.ftabDataDetil_Sign.Enabled = True

            Me.tbtnDel.Enabled = False
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
    Private Sub btnCheckAll_OrderAmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                        'Me.txtAllROAmount_perBudget.Text = String.Format("{0:#,##0.00}", ro_amount)
                        'Me.txtRO_plus_PO.Text = String.Format("{0:#,##0.00}", ro_amount)
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    'Private Sub obj_Order_descr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Order_descr.TextChanged
    '    Dim i As Integer
    '    Dim j, rMaxLine As Byte

    '    i = 2000 - Me.obj_Order_descr.Text.Length
    '    If i <= 0 Then
    '        Me.obj_Order_descr.Text = Mid(Me.obj_Order_descr.Text, 1, 2000)
    '    End If
    '    Me.Label2.Text = "Chars Left: " & i

    '    rMaxLine = 36 - Math.Ceiling(Me.DgvTrnOrderdetil.RowCount * 1.5)

    '    Try
    '        j = rMaxLine - Me.obj_Order_descr.Lines.Length
    '    Catch ex As Exception
    '        'MessageBox.Show("Jumlah baris tidak boleh lebih dari 35", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try

    '    Me.Label2.Text = Me.Label2.Text & " // Lines Left: " & j

    'End Sub
    Private Function uiTrnPurchaseOrder3_SetViewOnly() As Boolean
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
        Me.obj_Order_id.Enabled = True
        Me.obj_Order_id.BackColor = Color.Coral
        Me.obj_Order_id.ForeColor = Color.Black

        Me.obj_Request_id.ReadOnly = True
        Me.obj_Request_id.Enabled = True
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

        Me.chkOrder_canceled.Enabled = False

        Me.calc_Order_Discount.ReadOnly = True
        Me.calc_Order_Discount.BackColor = Color.White
        Me.calc_Order_Discount.ForeColor = Color.Black


        Me.DgvTrnOrderdetil.Enabled = True
        Me.DgvTrnOrderPaymReq.Enabled = True


    End Function
    Private Function uiTrnPurchaseOrder3_Lock() As Boolean
        If Me._FORMMODE <> "VIEW" Then
            If Me.tbl_TrnOrder_Temp.Rows.Count <> 0 Then
                If Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved2") = 1 Then
                    Me.cbo_Periode_id.Enabled = False
                Else
                    Me.cbo_Periode_id.Enabled = True
                End If
            End If
        End If

        'PnlDataMaster1
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.Enabled = True
        Me.obj_Order_id.BackColor = Color.Coral
        Me.obj_Order_id.ForeColor = Color.Black

        Me.obj_Request_id.ReadOnly = True
        Me.obj_Request_id.Enabled = True
        Me.obj_Request_id.BackColor = Color.White
        Me.obj_Request_id.ForeColor = Color.Black

        'Me.cbo_Periode_id.Enabled = True
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
        Me.cbo_Currency.Enabled = False
        Me.gboRevision.Enabled = False

        'PnlDataFooter1
        Me.obj_Order_descr.ReadOnly = False
        Me.obj_Order_descr.BackColor = Color.White
        Me.obj_Order_descr.ForeColor = Color.Black

        'Me.chkOrder_canceled.Enabled = True

        Me.calc_Order_Discount.ReadOnly = True
        Me.calc_Order_Discount.BackColor = Color.White
        Me.calc_Order_Discount.ForeColor = Color.Black


        'AdditionalCost
        'Me.obj_Order_insurancecost.ReadOnly = True
        'Me.obj_Order_insurancecost.BackColor = Color.White
        'Me.obj_Order_insurancecost.ForeColor = Color.Black

        'Me.obj_Order_operatorcost.ReadOnly = True
        'Me.obj_Order_operatorcost.BackColor = Color.White
        'Me.obj_Order_operatorcost.ForeColor = Color.Black

        'Me.obj_Order_transportationcost.ReadOnly = True
        'Me.obj_Order_transportationcost.BackColor = Color.White
        'Me.obj_Order_transportationcost.ForeColor = Color.Black

        'Me.obj_Order_othercost.ReadOnly = True
        'Me.obj_Order_othercost.BackColor = Color.White
        'Me.obj_Order_othercost.ForeColor = Color.Black


    End Function
    Private Sub DgvTrnOrderdetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrderdetil.CellClick
        ' Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dlgSelectTrnBudget As dlgSelectTrnBudget = New dlgSelectTrnBudget(Me.DSN)
        Dim retObj As Integer
        Dim jenisBudget As String = ""
        Dim budget_id As Decimal
        Dim remark As String = ""
        Dim tbl_budgetSum As DataTable = New DataTable


        Dim tblTrnBudgetCopyResult As DataTable = clsDataset2.CreateTblTrnBudget
        Dim tblTrnBudgetCopyResultDetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil

        Dim odataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        tbl_budgetSum.Clear()

        Select Case e.ColumnIndex

            Case Me.DgvTrnOrderdetil.Columns("btn_child").Index
                ' Dim a As DataGridViewComboBoxCell = DirectCast(Me.DgvTrnOrderdetil.CurrentRow.Cells("item_id")., DataGridViewComboBoxCell)

                Dim order_line As Integer = Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_line").Value
                Dim refrequest_id As String = Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_requestid_ref").Value
                Dim ref_requestdetil_line As Integer = Me.DgvTrnOrderdetil.CurrentRow.Cells("requestdetil_line").Value
                Dim item_names As String = Me.DgvTrnOrderdetil.CurrentRow.Cells("item_id").FormattedValue.ToString
                Dim descr As String = Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_descr").Value
                Dim qty_order As Decimal = Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_qty").Value
                Dim unit_order As String = Me.DgvTrnOrderdetil.CurrentRow.Cells("unit_id").FormattedValue.ToString

                'Dim tbl_requestdetilChild As DataTable = New DataTable
                'tbl_requestdetilChild.Clear()
                'tbl_requestdetilChild = Me.RetrieveChildFromRequest(refrequest_id, ref_requestdetil_line).Copy
                'If tbl_requestdetilChild.Rows.Count <= 0 Then

                '    Exit Sub
                'End If

                Dim dlgItemChildRequest As dlgItemChildRequest = New dlgItemChildRequest(Me.DSN, order_line, refrequest_id, ref_requestdetil_line, item_names, descr, qty_order, unit_order)
                dlgItemChildRequest.ShowDialog()

            Case Me.DgvTrnOrderdetil.Columns("btn_budget").Index
                If e.RowIndex < 0 Then
                    Exit Sub
                End If
                If Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_type").Value = "Item" Then
                    If Me._PROGRAMTYPE = "NP" Then
                        If Not Me.chkSingleBudget.Checked Then
                            jenisBudget = "header"
                            retObj = dlgSelectTrnBudget.OpenDialog(Me, Me._CHANNEL, jenisBudget)
                        End If
                    Else : Exit Sub
                    End If
                End If

                'Tampilkan JIka ingin mengaktif button orderdetil
            Case Me.DgvTrnOrderdetil.Columns("btn_budgetdetil").Index
                'If Me._ORDER_SOURCE = "ML" Then
                '    If e.RowIndex < 0 Then
                '        Exit Sub
                '    End If
                '    If Me.DgvTrnOrderdetil.CurrentRow.Cells("budget_id").Value IsNot System.DBNull.Value Then
                '        If Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("orderdetil_type").Value = "Item" Then
                '            jenisBudget = "detil"
                '            budget_id = Me.DgvTrnOrderdetil.CurrentRow.Cells("budget_id").Value
                '            retObj = dlgSelectTrnBudget.OpenDialogDetil(budget_id, Me, Me._CHANNEL, jenisBudget)
                '        End If
                '    End If
                'End If
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

        End Select

        If Not retObj = Nothing Then
            Me.BindingStop()
            'Me.BindingStopApproval()
            If jenisBudget = "header" Then
                Me.DataFill(tblTrnBudgetCopyResult, "bg_TrnBudget_Select", "budget_id = " & retObj, "channel_id = " & Me._CHANNEL) ' & retObj)
                If tblTrnBudgetCopyResult.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budget_id").Value = tblTrnBudgetCopyResult.Rows(0).Item("budget_id")
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_id").Value = 0
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_name").Value = ""
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_amount").Value = 0
                End If
            ElseIf jenisBudget = "detil" Then
                Me.DataFill(tblTrnBudgetCopyResultDetil, "pr_TrnBudgetdetil_Select", "budgetdetil_id = " & retObj) ' & retObj)
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_id").Value = tblTrnBudgetCopyResultDetil.Rows(0).Item("budgetdetil_id")
                Me.DgvTrnOrderdetil.CurrentRow.Cells("budgetdetil_amount").Value = tblTrnBudgetCopyResultDetil.Rows(0).Item("budgetdetil_amount")

                'Me.DataFill(tbl_budgetSum, "pr_TrnOrderdetil_AmountSum", "budgetdetil_id = " & retObj) ' & retObj)
                'Me.DataFill(tbl_budgetSum, "pr_TrnOrderdetil_AmountSum", "budgetdetil_id = " & retObj & " AND ordertype_id = '" & Me._ORDERTYPE_ID & "'") ' & retObj)
                ''''Me.DataFill2(tbl_budgetSum, "pr_TrnOrderdetil_AmtSum", budget_id, retObj)

                odataFiller.DataFillBudgetdetilAmount(tbl_budgetSum, "cq_TrnOrderdetil_AmtSum", budget_id, retObj)
                If tbl_budgetSum.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_amountsum").Value = tbl_budgetSum.Rows(0).Item("amount_sum")
                Else : Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_amountsum").Value = 0
                End If

                Dim budgetdetil_outstd = _
                Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_rowtotalidr_incldisc").Value _
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
    Private Sub DgvTrnOrderdetil_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOrderdetil.CellValueChanged
        Dim dgv As DataGridView = sender
        Dim colName As String = dgv.Columns(e.ColumnIndex).Name
        Dim tbl_Budget As DataTable = clsDataset2.CreateTblTrnBudget
        Dim tbl_Budgetdetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil
        Dim budget_id As Integer
        Dim budgetdetil_id As Integer
        Dim rowIndex As Integer = e.RowIndex
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        budget_id = Me.DgvTrnOrderdetil.Rows(rowIndex).Cells("budget_id").Value
        budgetdetil_id = Me.DgvTrnOrderdetil.Rows(rowIndex).Cells("budgetdetil_id").Value

        tbl_Budget.Clear()
        tbl_Budgetdetil.Clear()

        Select Case e.ColumnIndex
            Case Me.DgvTrnOrderdetil.Columns("budget_id").Index
                oDataFiller.DataFill(tbl_Budget, "pr_TrnBudget_Select", String.Format("budget_id = {0}", budget_id))
                If tbl_Budget.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budget_name").Value = tbl_Budget.Rows(0).Item("budget_name")
                End If
            Case Me.DgvTrnOrderdetil.Columns("budgetdetil_id").Index
                oDataFiller.DataFill(tbl_Budgetdetil, "pr_TrnBudgetdetil_Select", String.Format("budgetdetil_id = {0}", budgetdetil_id))
                If tbl_Budgetdetil.Rows.Count > 0 Then
                    Me.DgvTrnOrderdetil.Rows(e.RowIndex).Cells("budgetdetil_name").Value = tbl_Budgetdetil.Rows(0).Item("budgetdetil_desc")
                End If
        End Select



        If (colName = "orderdetil_idr" Or colName = "orderdetil_qty" Or colName = "orderdetil_discount" Or colName = "orderdetil_foreign" Or colName = "orderdetil_foreignrate") Then
            Me.uiTrnPurchaseOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
            Me.uiTrnPurchaseOrder3_TotalCalculate()

            Me.DgvTrnOrderdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOrderdetil).EndCurrentEdit()
        End If

        If colName = "orderdetil_type" Then
            If dgv.CurrentRow.Cells("orderdetil_type").Value = "Descr" Then
                dgv.CurrentRow.Cells("item_id").Value = ""
                dgv.CurrentRow.Cells("unit_id").Value = 0
                dgv.CurrentRow.Cells("orderdetil_qty").Value = 0
                'dgv.CurrentRow.Cells("orderdetil_days").Value = 0
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
        Try


            If dgv.RowCount >= 1 Then
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

                    objRow.Cells("orderdetil_foreign").ReadOnly = True
                    objRow.Cells("orderdetil_foreign").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_foreign").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_foreign").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                    objRow.Cells("orderdetil_foreignrate").ReadOnly = True
                    objRow.Cells("orderdetil_foreignrate").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_foreignrate").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_foreignrate").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

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

                    objRow.Cells("orderdetil_ppn").ReadOnly = True
                    objRow.Cells("orderdetil_ppn").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_ppn").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_ppn").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                    objRow.Cells("orderdetil_pph").ReadOnly = True
                    objRow.Cells("orderdetil_pph").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_pph").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_pph").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                    objRow.Cells("orderdetil_rowtotalforeign_incltax").ReadOnly = True
                    objRow.Cells("orderdetil_rowtotalforeign_incltax").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_rowtotalforeign_incltax").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_rowtotalforeign_incltax").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                    objRow.Cells("orderdetil_rowtotalforeign_incldisc").ReadOnly = True
                    objRow.Cells("orderdetil_rowtotalforeign_incldisc").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_rowtotalforeign_incldisc").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_rowtotalforeign_incldisc").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                    objRow.Cells("orderdetil_rowtotalidr_incldisc").ReadOnly = True
                    objRow.Cells("orderdetil_rowtotalidr_incldisc").Style.BackColor = Color.LightGray
                    objRow.Cells("orderdetil_rowtotalidr_incldisc").Style.ForeColor = Color.LightGray
                    objRow.Cells("orderdetil_rowtotalidr_incldisc").Style.SelectionForeColor = System.Drawing.Color.FromName("Highlight")

                Else

                    'dgv.CurrentRow.Cells("item_id").ReadOnly = False
                    objRow.Cells("item_id").ReadOnly = True
                    objRow.Cells("item_id").Style.BackColor = Color.White
                    objRow.Cells("item_id").Style.ForeColor = Color.Black
                    objRow.Cells("item_id").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                    objRow.Cells("orderdetil_line").ReadOnly = True
                    objRow.Cells("orderdetil_line").Style.BackColor = Color.White

                    objRow.Cells("unit_id").ReadOnly = True
                    objRow.Cells("unit_id").Style.BackColor = Color.White
                    objRow.Cells("unit_id").Style.ForeColor = Color.Black
                    objRow.Cells("unit_id").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                    objRow.Cells("orderdetil_qty").ReadOnly = True
                    objRow.Cells("orderdetil_qty").Style.BackColor = Color.White
                    objRow.Cells("orderdetil_qty").Style.ForeColor = Color.Black
                    objRow.Cells("orderdetil_qty").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                    objRow.Cells("currency_id").ReadOnly = True
                    objRow.Cells("currency_id").Style.BackColor = Color.White
                    objRow.Cells("currency_id").Style.ForeColor = Color.Black
                    objRow.Cells("currency_id").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

                    objRow.Cells("orderdetil_rowtotalidr_incldisc").ReadOnly = True
                    'objRow.Cells("orderdetil_rowtotalidr_incldisc").Style.BackColor = Color.White
                    'objRow.Cells("orderdetil_rowtotalidr_incldisc").Style.ForeColor = Color.Black
                    objRow.Cells("orderdetil_rowtotalidr_incldisc").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")

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

                    objRow.Cells("orderdetil_foreign").ReadOnly = True
                    objRow.Cells("orderdetil_foreign").Style.BackColor = Color.White
                    objRow.Cells("orderdetil_foreign").Style.ForeColor = Color.Black
                    objRow.Cells("orderdetil_foreign").Style.SelectionForeColor = System.Drawing.Color.FromName("HighlightText")
                End If

                If dgv.RowCount > 1 Then
                    If _ORDER_SOURCE = "ML" Then
                        objRow.Cells("orderdetil_foreign").ReadOnly = False
                        objRow.Cells("budgetdetil_name").ReadOnly = False
                    Else
                        objRow.Cells("orderdetil_foreign").ReadOnly = True
                        objRow.Cells("budgetdetil_name").ReadOnly = True
                    End If
                End If

                If dgv.RowCount > 0 Then
                    If objRow.Cells("budgetdetil_remark").Value = "OK" Then
                        objRow.DefaultCellStyle.ForeColor = Color.Black

                    ElseIf objRow.Cells("budgetdetil_remark").Value = "OVER BUDGET" Then
                        objRow.DefaultCellStyle.ForeColor = Color.Red
                    Else
                        objRow.DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DgvTrnOrder_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOrder.CellFormatting

        Dim objRow As System.Windows.Forms.DataGridViewRow = DgvTrnOrder.Rows(e.RowIndex)
        Dim a As Boolean = objRow.Cells("order_canceled").Value

        If objRow.Cells("order_approved2").Value = 0 And objRow.Cells("order_canceled").Value = False Then
            objRow.DefaultCellStyle.BackColor = Color.White
        ElseIf objRow.Cells("order_approved2").Value = 1 And objRow.Cells("order_canceled").Value = False Then
            objRow.DefaultCellStyle.BackColor = Color.LightBlue
        ElseIf objRow.Cells("order_approved2").Value = 2 And objRow.Cells("order_canceled").Value = False Then
            objRow.DefaultCellStyle.BackColor = Color.PaleGoldenrod
        Else
            objRow.DefaultCellStyle.BackColor = Color.MistyRose

        End If
    End Sub
    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        Me.Cursor = Cursors.WaitCursor
        uiTrnPurchaseOrder3_GetOrderSource()
        Me.Cursor = Cursors.Arrow
        'Me.ConfirmSaveAddItem("Add")
        ''If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
        ''    Me.ReservedItem = True
        ''Else
        ''    Me.ReservedItem = False
        ''End If
        ''Me.uiTrnPurchaseOrder3_GetOrderSource()

        'Me.uiTrnPurchaseOrder3_DetilCalculate(Me.DgvTrnOrderdetil, Me.TotalDetil, Me.TotalDetilPPH, Me.TotalDetilPPN, Me.TotalDetilDisc)
        'Me.uiTrnPurchaseOrder3_TotalCalculate()
    End Sub
    Private Sub uiTrnPurchaseOrder3_CekChannel()
        Dim dt As New DataTable
        ' Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            dt.Clear()

            DataFill(dt, "pr_MstChannel_Select", String.Format("channel_id = '{0}'", Me._CHANNEL))
            m_nama = clsUtil.IsDbNull(dt.Rows(0)("channel_namereport"), "")
            m_alamat = clsUtil.IsDbNull(dt.Rows(0)("channel_address"), "")
            m_telp = clsUtil.IsDbNull(dt.Rows(0)("channel_telp1"), "")
            m_ext = clsUtil.IsDbNull(dt.Rows(0)("channel_telp2"), "")
            m_fax = clsUtil.IsDbNull(dt.Rows(0)("channel_fax"), "")

        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub

    Private Sub btnAddDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDesc.Click
        Dim i As Integer

        i = Me.tbl_TrnOrderdetil.Rows.Count

        If Me.DgvTrnOrderdetil.Rows.Count >= 0 Then
            'Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
            Me.tbl_TrnOrderdetil.Rows.Add().Item("unit_id") = 1
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_type") = "Descr"
            Me.tbl_TrnOrderdetil.Rows(i).Item("item_id") = "3000000000"
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_descr") = ""
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_qty") = 1
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_days") = 1
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_idr") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreign") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreignrate") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_actual") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_actualnote") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("currency_id") = 1
            Me.tbl_TrnOrderdetil.Rows(i).Item("budget_id") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("budgetdetil_id") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("budgetaccount_id") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("old_orderdetil_id") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("channel_id") = Me._CHANNEL
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_pphpercent") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_ppnpercent") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_pphforeign") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_ppnforeign") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_pph") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_ppn") = 0
            Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_requestid_ref") = ""

        End If
    End Sub
    Private Sub btnDelDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelDesc.Click

        If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
            If Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_type").Value = "Descr" Then
                Me.tbl_TrnOrderdetil.Rows(Me.DgvTrnOrderdetil.CurrentRow.Index).Delete()
            Else
                MessageBox.Show("Cannot delete item!")
            End If
        End If

    End Sub
    Private Sub cbo_Currency_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Currency.Validated
        Dim i As Integer

        Me.tbl_MstXRate.Clear()
        Me.DataFill(Me.tbl_MstXRate, "pr_MstXRate_Select", "exrate_currency = '" & Me.cbo_Currency.Text.Trim & "'")
        For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
            Me.tbl_TrnOrderdetil.Rows(i).Item("currency_id") = Me.cbo_Currency.SelectedValue
            If Me.tbl_MstXRate.Rows.Count > 0 Then
                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreignrate") = clsUtil.IsDbNull(Me.tbl_MstXRate.Rows(0)("exrate_mid"), 0) / clsUtil.IsDbNull(Me.tbl_MstXRate.Rows(0)("exrate_value"), 0)
            Else
                Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreignrate") = 0
            End If
        Next
        Me.cbo_Currency.SelectedValue = Me.cbo_Currency.SelectedValue
    End Sub
    Private Function confirmNew() As Boolean
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before input new data ?"
        Dim iTab As Integer = Me.FlatTabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPurchaseOrder3_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
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
                move = Me.uiTrnPurchaseOrder3_ConfirmSaveBeforeAddItem(Message)
            End If
        Else
            move = True
        End If

        If move = True Then
            'kenapa kalo rows.count > 0 ReservedItem di ubah jd True??????
            'krn blm ketemu jwbnnya, smntr di disable ajah..
            'If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
            '    Me.ReservedItem = True
            'Else
            '    Me.ReservedItem = False
            'End If
            Me.uiTrnPurchaseOrder3_GetOrderSource()
        End If

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

    Private Function CekCurrencyDetil() As Boolean
        Dim distinctdt As New DataTable
        Dim dv As DataView

        dv = Me.tbl_TrnOrderdetil.GetChanges.DefaultView
        distinctdt.Columns.Add("currency_id")
        Dim mycolumn As DataColumn = New DataColumn

        Try
            distinctdt = dv.ToTable(True, "currency_id")
            If distinctdt.Rows.Count > 1 Then
                Dim errormessage As String = ""
                Dim errorfound As Boolean = False
                errormessage = "currency on detail order can't be different"
                Me.objFormError.SetError(Me.DgvTrnOrderdetil, errormessage)

                Throw New Exception(errormessage)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return False
        End Try

        Return True
    End Function

    Private Function IsiBudgetName() As Boolean
        'Dim tbl_Budget As DataTable = clsDataset2.CreateTblTrnBudget
        'Dim tbl_Budgetdetil As DataTable = clsDataset2.CreateTblTrnBudgetdetil
        'Dim order_id As String
        'Dim budget_id As Integer
        'Dim budgetdetil_id As Integer
        'Dim rowIdx As Integer
        'Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        'Dim tbl_budgetSum As DataTable = New DataTable
        'Dim tbl_distinctbudget As DataTable = New DataTable
        'Dim remark As String = ""

        'Try
        '    If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
        '        For rowIdx = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
        '            budget_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budget_id").Value
        '            budgetdetil_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("budgetdetil_id").Value
        '            order_id = Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("order_id").Value

        '            tbl_Budget.Clear()
        '            tbl_Budgetdetil.Clear()
        '            tbl_budgetSum.Clear()
        '            oDataFiller.DataFill(tbl_distinctbudget, "test_order2", String.Format("order_id = '{0}' and orderdetil_type='Item'", order_id))

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
                    If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
                        If Me.DgvTrnOrderdetil.Rows(rowIdx).Cells("orderdetil_type").Value = "Item" Then
                            'If tbl_Budget.Rows.Count > 0 Then
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
    'Private Sub chkSingleBudget_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSingleBudget.CheckStateChanged
    '    If Me.chkSingleBudget.Checked Then
    '        Me.obj_Budget_id.Text = Me.cbo_Budget_name.SelectedValue
    '        Dim i, j As Integer
    '        'Me.cbo_Budget_name.Enabled = True
    '        'Me.obj_Budget_id.Enabled = True

    '        If Me.tbl_TrnOrderdetil.Rows.Count > 0 Then
    '            For i = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
    '                Me.tbl_TrnOrderdetil.Rows(i).Item("budget_id") = Me.cbo_Budget_name.SelectedValue
    '            Next
    '        End If
    '        Me.IsiBudgetName()
    '        If Me.DgvTrnOrderdetil.Rows.Count > 0 Then
    '            For j = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
    '                Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_id").Value = 0
    '                Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_name").Value = ""
    '                Me.DgvTrnOrderdetil.Rows(j).Cells("budgetdetil_amount").Value = 0
    '            Next
    '        End If
    '    ElseIf Not Me.chkSingleBudget.Checked Then
    '        Me.obj_Budget_id.Text = 0
    '        Me.cbo_Budget_name.SelectedValue = 0
    '        'Me.cbo_Budget_name.Enabled = False
    '        'Me.obj_Budget_id.Enabled = False
    '    End If


    'End Sub
    Private Sub uiTrnPurchaseOrder3_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'Me.obj_order_note.Location = New System.Drawing.Point(14, 25)
        'Me.obj_order_note.Size = New System.Drawing.Point(Me.PnlDataFooter_note.Size.Width - 20, 79)
        'Me.chkOrder_canceled.Location = New System.Drawing.Point(Me.PnlDataFooter_note.Size.Width - (Me.chkOrder_canceled.Size.Width + 7), 110)
    End Sub
    Private Sub chkApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApproved.CheckedChanged
        If Me.chkApproved.Checked Then Me.lblApproved.Text = "APPROVED" Else Me.lblApproved.Text = ""
    End Sub
    Private Sub uiTrnPurchaseOrder3_LoadSupportingData()
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
    End Sub
#Region "Approved"
    Private Enum Approves
        Approved
        DisApprove
    End Enum

    Private app As Approves = Approves.DisApprove


    Sub GrabOrderDetilTo_OrderDetilProc(ByVal order_id)
        '====Add PTS 20130503
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("tr_TrnOrderApprove_Proc", dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id
            cmd.ExecuteNonQuery()

            result = True
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Sub

    Sub GrabOrderDetilUseTo_OrderDetilUseProc(ByVal order_id)
        '====Add PTS 20130503
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("[tr_TrnOrderApproveDetilUse_Proc]", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id

            cmd.ExecuteNonQuery()

            result = True
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Sub

    Sub Delete_OrderDetilProc(ByVal order_id)
        '====Add PTS 20130503
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("tr_TrnOrderDeleteDetil_Proc", dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id

            cmd.ExecuteNonQuery()

            result = True
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Sub

    Sub Delete_OrderDetilUseProc(ByVal order_id)
        '====Add PTS 20130503
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("tr_TrnOrderDeleteDetilUse_Proc", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id

            cmd.ExecuteNonQuery()

            result = True
        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Function UpdateApprove(ByVal order_id As String, ByVal approved As Integer, ByVal order_canceled As Integer) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("to_TalentorderApproved_Update2", dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id
            cmd.Parameters.Add("@order_approved", OleDb.OleDbType.TinyInt, 1).Value = approved
            cmd.Parameters.Add("@order_approvedby", OleDb.OleDbType.VarChar, 200).Value = Me.UserName
            cmd.Parameters.Add("@order_approveddt", OleDb.OleDbType.DBTimeStamp, 4).Value = Date.Now
            cmd.Parameters.Add("@order_canceled", OleDb.OleDbType.TinyInt, 1).Value = order_canceled

            cmd.ExecuteNonQuery()

            result = True

            If approved = 2 Then
                'Disapprove
                '==== add pts 20130503=======================
                Call Delete_OrderDetilProc(order_id)
                'Call Delete_OrderDetilUseProc(order_id)
                '============================================
            ElseIf approved = 1 Then
                'Approve
                '=====ADD Pts 20130503=======================
                Call GrabOrderDetilTo_OrderDetilProc(order_id)
                'Call GrabOrderDetilUseTo_OrderDetilUseProc(order_id)
                '=====ADD Pts 20130503=======================
            End If

        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return result
    End Function

    Private Function InsertApprove(ByVal order_id As String) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Boolean = False
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("to_TalentorderApproved_Insert2", dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@order_id", OleDb.OleDbType.VarChar, 30).Value = order_id
            cmd.Parameters.Add("@order_approved", OleDb.OleDbType.TinyInt, 1).Value = 1
            cmd.Parameters.Add("@order_approvedby", OleDb.OleDbType.VarChar, 200).Value = Me.UserName
            cmd.Parameters.Add("@order_approveddt", OleDb.OleDbType.DBTimeStamp, 4).Value = Date.Now
            cmd.Parameters.Add("@order_canceled", OleDb.OleDbType.TinyInt, 1).Value = 0

            cmd.ExecuteNonQuery()

            result = True

            '=====ADD Pts 20130503=======================
            Call GrabOrderDetilTo_OrderDetilProc(order_id)
            'Call GrabOrderDetilUseTo_OrderDetilUseProc(order_id)
            '============================================

        Catch ex As Exception
            result = False
            Throw New Exception(ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return result
    End Function

    Private Function IsApproved(ByVal order_id As String) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim SQL As String = String.Format("select count(*) from E_FRM.DBO.transaksi_talentorder_approve where order_id = '{0}'", order_id)
        Dim result As Boolean = False
        Dim val As Integer
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

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
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return result
    End Function
#End Region

    '========== REMARK 20180518 ====
    'Private Sub btnApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApp.Click
    '    Dim btn As ToolStripButton = sender
    '    Dim row As DataGridViewRow
    '    Dim order_id As String
    '    Dim criteria As String = ""
    '    Dim channel_id As String = ""
    '    Dim tblorderdetil_tempcek As DataTable = New DataTable
    '    Dim i As Integer
    '    Dim error_messageadvance As Decimal = 0
    '    Dim error_messagebpb As Decimal = 0
    '    Dim tbl_jurnal As DataTable = New DataTable
    '    'frmPrint.StartPosition = FormStartPosition.CenterParent

    '    If Me.DgvTrnOrder.SelectedRows.Count <= 0 Then
    '        MsgBox("Pilih data dulu..")
    '        Exit Sub
    '    End If

    '    'ambil row yang dipilih di datagrid
    '    If Me.DgvTrnOrder.Rows.Count > 0 Then
    '        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
    '            row = Me.DgvTrnOrder.SelectedRows(i)
    '            order_id = row.Cells("order_id").Value
    '            channel_id = row.Cells("channel_id").Value
    '            criteria = String.Format("order_id='{0}' and orderdetil_type ='Item'", order_id)
    '            'CEK Data BPB dan BPJ----------------------------------------------------------------------------------------------------------
    '            tblorderdetil_tempcek.Clear()
    '            Me.DataFill(tblorderdetil_tempcek, "pr_TrnOrderDetil_SelectCek", criteria)

    '            Dim h As Integer
    '            Dim y As Integer
    '            Dim tbl_orderAdvance As DataTable = New DataTable

    '            If tblorderdetil_tempcek.Rows.Count > 0 Then

    '                For h = 0 To tblorderdetil_tempcek.Rows.Count - 1
    '                    If order_id <> String.Empty Then
    '                        tbl_jurnal.Clear()
    '                        Me.DataFill(tbl_jurnal, "to_TrnOrderdetil_SelectJurnalBPB", String.Format("order_id = '{0}' AND orderdetil_line = {1}", order_id, clsUtil.IsDbNull(tblorderdetil_tempcek.Rows(i).Item("orderdetil_line"), 0)))
    '                        tbl_orderAdvance.Clear()
    '                        Dim orderdetil_line As Integer = clsUtil.IsDbNull(tblorderdetil_tempcek.Rows(h).Item("orderdetil_line"), 0)
    '                        Me.DataFill(tbl_orderAdvance, "pr_TrnOrderdetilAdvanceForOrder_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND isadvance <> 0 and advance_canceled = 0", order_id, orderdetil_line))

    '                        If tbl_jurnal.Rows.Count > 0 Or tbl_orderAdvance.Rows.Count > 0 Then
    '                            Dim u As Integer

    '                            For u = 0 To tbl_jurnal.Rows.Count - 1
    '                                If tbl_jurnal.Rows(u).Item("terimabarang_id") <> "" Or clsUtil.IsDbNull(tbl_jurnal.Rows(u).Item("isadvance"), 0) = 1 Then
    '                                    error_messagebpb += 1

    '                                End If
    '                            Next
    '                            For y = 0 To tbl_orderAdvance.Rows.Count - 1
    '                                If clsUtil.IsDbNull(tbl_orderAdvance.Rows(y).Item("isadvance"), 0) <> 0 Then
    '                                    error_messageadvance += 1

    '                                End If
    '                            Next
    '                        End If
    '                    End If
    '                Next
    '            End If
    '            If error_messageadvance > 0 Then
    '                Me.errorPA = True
    '            Else
    '                Me.errorPA = False
    '            End If
    '            '--------------------------------------------------------------------------------------------------------------------------------------


    '            'Approve Order-------------------------------------------------------------------------------------------------------------------------
    '            If order_id = "" Then
    '                MsgBox("Please Load Data...")
    '            ElseIf error_messagebpb > 0 Then
    '                MsgBox("Sorry this order has been have a BPB")
    '                Exit Sub
    '            ElseIf error_messageadvance > 0 Then
    '                MsgBox(" Sorry this order has been have a PA")
    '                Exit Sub
    '            Else
    '                Try
    '                    If app = Approves.Approved Then '==> APPROVE ORDER
    '                        If Me.IsApproved(order_id) = True Then ' Apakah di transaksi_talentorder_approve ada gk? ADA
    '                            If Me.UpdateApprove(order_id, 1, 0) = True Then
    '                                app = Approves.DisApprove
    '                                btn.Text = "Disapprove"
    '                            End If
    '                        Else ' Apakah di transaksi_talentorder_approve ada gk? TIDAK ADA 
    '                            If Me.InsertApprove(order_id) = True Then
    '                                app = Approves.DisApprove
    '                                If FlatTabMain.SelectedIndex = 1 Then
    '                                    btn.Text = "Disapprove"

    '                                End If
    '                            End If
    '                        End If
    '                    ElseIf app = Approves.DisApprove Then '==> DISAPPROVE ORDER
    '                        If Me.UpdateApprove(order_id, 2, 0) = True Then
    '                            app = Approves.Approved
    '                            btn.Text = "Approve"
    '                        End If
    '                    End If
    '                    If FlatTabMain.SelectedIndex = 1 Then
    '                        Me.uiTrnPurchaseOrder3_Retrieve()
    '                        Me.uiTrnPurchaseOrder3_OpenRowAfterApprove(order_id)
    '                    Else
    '                        Me.uiTrnPurchaseOrder3_Retrieve()
    '                    End If

    '                Catch ex As Exception
    '                    MsgBox(ex.Message, MsgBoxStyle.Critical)
    '                End Try
    '            End If
    '        Next
    '    End If
    'End Sub
   
    Private Sub btnVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVendor.Click
        Dim dlg As dlgSelectVendor = New dlgSelectVendor(Me.DSN, Me._CHANNEL)
        Dim rekanan_id As String
        rekanan_id = dlg.OpenDialog(Me)
        Me.rekananidtxt.Text = rekanan_id
    End Sub

    Private Sub DgvTrnOrder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvTrnOrder.SelectionChanged
        Dim row As DataGridViewRow
        Dim order_id As String
        Dim criteria As String = ""
        Dim channel_id As String = ""
        Dim i As Integer

        For i = 0 To Me.DgvTrnOrder.SelectedRows.Count - 1
            row = Me.DgvTrnOrder.SelectedRows(i)
            order_id = row.Cells("order_id").Value
            channel_id = row.Cells("channel_id").Value

            If criteria = "" Then
                criteria = String.Format(" order_id = '{0}' ", order_id)
            Else
                criteria = String.Format(" {1} or order_id = '{0}' ", order_id, criteria)
            End If
            If Me.DgvTrnOrder.Rows.Count > 0 Then
                Dim approve As Short
                approve = clsUtil.GetDataFromDatatable(tbl_TrnOrder, "order_id", "order_approved2", order_id).ToString
                Me.Approve(approve)
            End If
        Next

    End Sub

    Private Sub cbo_Rekanan_name_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_Rekanan_name.SelectedValueChanged

        If Me.formstatus = "NEW" Then
            If Me.FlatTabMain.SelectedIndex = 1 Then
                If Me.cbo_Rekanan_name.ValueMember = "0" Then

                Else
                    If Me.cbo_Rekanan_name.SelectedValue = 0 Then
                    Else
                        Me.tbl_MstRekanan_contact.Clear()
                        Me.ComboFill(Me.obj_Order_othercost, "rekanancontact_line", "rekanancontact_name", Me.tbl_MstRekanan_contact, "pr_MstRekananContact_Select", "rekanan_id = '" & Me.cbo_Rekanan_name.SelectedValue & "'")
                    End If

                End If
            End If
        ElseIf Me.formstatus = "OPENROW" Then

        End If

    End Sub

    Sub formnewhidup()
    
        Me.PnlDataMaster1.Enabled = True
        Me.PnlDataMaster2.Enabled = True
        Me.PnlDataFooter_total.Enabled = True
        Me.obj_order_note.Enabled = True
        Me.PnlDataMaster2.BackColor = Color.PapayaWhip
        Me.ftabDataDetil_Info.Enabled = True
        Me.ftabDataDetil_PaymReq.Enabled = True
        Me.ftabDataDetil_Sign.Enabled = True
        Me.tbtnSave.Enabled = True
        Me.btnAddItem.Enabled = True
        Me.tbtnDel.Enabled = False
        Me.tbtnEdit.Enabled = True
        Me.tbtnPrint.Enabled = True
        Me.tbtnPrintPreview.Enabled = True
        Me.chkOrder_canceled.Enabled = True
        Me.obj_Order_othercost.Enabled = True
        Me.obj_order_revdesc.ReadOnly = False

        Me.DgvTrnOrderdetil.Columns("item_id").ReadOnly = True
        Me.DgvTrnOrderdetil.Columns("unit_id").ReadOnly = True
      
    End Sub

    Private Sub PackageItemDetilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PackageItemDetilToolStripMenuItem.Click
        Dim tbl_requestdetilpackage As DataTable = New DataTable
        Me.DataFill(tbl_requestdetilpackage, "order_SelectItemPackage", String.Format("request_id = '{0}' AND ISNULL(requestdetil_mother,0) = {1}", Me.DgvTrnOrderdetil.CurrentRow.Cells("orderdetil_requestid_ref").Value, Me.DgvTrnOrderdetil.CurrentRow.Cells("requestdetil_line").Value))
        If tbl_requestdetilpackage.Rows.Count <> 0 Then
            Dim dlgPackageItemDetil As dlgOrderPackageItemDetil = New dlgOrderPackageItemDetil(tbl_requestdetilpackage, "", 0)
            dlgPackageItemDetil.ShowDialog()
        End If
    End Sub

    '======= TOP ==== PTS 20171031 ==========
    Private Function FormatDgvTrnOrderTOPdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnOrderTOPdetil
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrdertop_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_seq As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_percent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_payplant As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cOrderterm_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderterm_notes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModify_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModify_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cIsresponse As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cResponse_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cisresponse.Name = "isresponse"
        cisresponse.HeaderText = "Is Response"
        cisresponse.DataPropertyName = "isresponse"
        cisresponse.Width = 100
        cIsresponse.Visible = False
        cisresponse.ReadOnly = True

        cresponse_id.Name = "response_id"
        cresponse_id.HeaderText = "Response ID"
        cresponse_id.DataPropertyName = "response_id"
        cresponse_id.Width = 100
        cresponse_id.Visible = True
        cresponse_id.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cOrderterm_rate.Name = "orderterm_rate"
        cOrderterm_rate.HeaderText = "Rate"
        cOrderterm_rate.DataPropertyName = "orderterm_rate"
        cOrderterm_rate.Width = 100
        cOrderterm_rate.Visible = False
        cOrderterm_rate.ReadOnly = True

        cOrderterm_amount.Name = "orderterm_amount"
        cOrderterm_amount.HeaderText = "Amount"
        cOrderterm_amount.DataPropertyName = "orderterm_amount"
        cOrderterm_amount.DefaultCellStyle.Format = "#,##0.00"
        cOrderterm_amount.Width = 100

        cOrderterm_amount.Visible = True
        cOrderterm_amount.ReadOnly = False
        cOrderterm_amount.DefaultCellStyle.Format = "#,##0.00"

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order Id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOrdertop_line.Name = "ordertop_line"
        cOrdertop_line.HeaderText = "ordertop_line"
        cOrdertop_line.DataPropertyName = "ordertop_line"
        cOrdertop_line.Width = 100
        cOrdertop_line.Visible = False
        cOrdertop_line.ReadOnly = False

        cOrderterm_line.Name = "orderterm_line"
        cOrderterm_line.HeaderText = "TLine"
        cOrderterm_line.DataPropertyName = "orderterm_line"
        cOrderterm_line.Width = 40
        cOrderterm_line.Visible = True
        cOrderterm_line.ReadOnly = True

        cOrderterm_seq.Name = "orderterm_seq"
        cOrderterm_seq.HeaderText = "orderterm_seq"
        cOrderterm_seq.DataPropertyName = "orderterm_seq"
        cOrderterm_seq.Width = 100
        cOrderterm_seq.Visible = False
        cOrderterm_seq.ReadOnly = False

        cOrderterm_percent.Name = "orderterm_percent"
        cOrderterm_percent.HeaderText = "(%)"
        cOrderterm_percent.DataPropertyName = "orderterm_percent"
        cOrderterm_percent.Width = 70
        cOrderterm_percent.Visible = True
        cOrderterm_percent.ReadOnly = True

        cOrderterm_payplant.Name = "orderterm_payplant"
        cOrderterm_payplant.HeaderText = "Pay Plant"
        cOrderterm_payplant.DataPropertyName = "orderterm_payplant"
        cOrderterm_payplant.Width = 100
        cOrderterm_payplant.Visible = True
        cOrderterm_payplant.ReadOnly = False
        cOrderterm_payplant.ValueMember = "paying_id"
        cOrderterm_payplant.DisplayMember = "paying_name"
        cOrderterm_payplant.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        cOrderterm_payplant.DisplayStyleForCurrentCellOnly = True
        cOrderterm_payplant.AutoComplete = True
        cOrderterm_payplant.DataSource = Me.tbl_MstOrderPaying

        cOrderterm_status.Name = "orderterm_status"
        cOrderterm_status.HeaderText = "Status"
        cOrderterm_status.DataPropertyName = "orderterm_status"
        cOrderterm_status.Width = 100
        cOrderterm_status.Visible = False
        cOrderterm_status.ReadOnly = False

        cOrderterm_notes.Name = "orderterm_notes"
        cOrderterm_notes.HeaderText = "Notes"
        cOrderterm_notes.DataPropertyName = "orderterm_notes"
        cOrderterm_notes.Width = 100
        cOrderterm_notes.Visible = True
        cOrderterm_notes.ReadOnly = False

        cCreate_by.Name = "create_by"
        cCreate_by.HeaderText = "create_by"
        cCreate_by.DataPropertyName = "create_by"
        cCreate_by.Width = 100
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = False

        cCreate_date.Name = "create_date"
        cCreate_date.HeaderText = "create_date"
        cCreate_date.DataPropertyName = "create_date"
        cCreate_date.Width = 100
        cCreate_date.Visible = False
        cCreate_date.ReadOnly = False

        cModify_by.Name = "modify_by"
        cModify_by.HeaderText = "modify_by"
        cModify_by.DataPropertyName = "modify_by"
        cModify_by.Width = 100
        cModify_by.Visible = False
        cModify_by.ReadOnly = False

        cModify_date.Name = "modify_date"
        cModify_date.HeaderText = "modify_date"
        cModify_date.DataPropertyName = "modify_date"
        cModify_date.Width = 100
        cModify_date.Visible = False
        cModify_date.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, cOrdertop_line, cOrderterm_line, cOrderterm_seq, cOrderterm_percent, cCurrency_id, cOrderterm_rate, cOrderterm_amount, cOrderterm_payplant, cOrderterm_status, cOrderterm_notes, cCreate_by, cCreate_date, cModify_by, cModify_date, cIsresponse, cResponse_id})

    End Function

    Private Function uiTrnPurchaseOrder3_SaveTOPDetil(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
       ByRef dbconn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean

        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdInsert = New OleDb.OleDbCommand("pr_TrnOrderTOPdetil_Insert", dbconn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30)) ', "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertop_line", System.Data.OleDb.OleDbType.Integer, 4, "ordertop_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_line", System.Data.OleDb.OleDbType.Integer, 4, "orderterm_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_seq", System.Data.OleDb.OleDbType.Integer, 4, "orderterm_seq"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_percent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_payplant", System.Data.OleDb.OleDbType.VarWChar, 100, "orderterm_payplant"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_status", System.Data.OleDb.OleDbType.VarWChar, 200, "orderterm_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "orderterm_notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 400, "create_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "create_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 400, "modify_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modify_date"))
        dbCmdInsert.Parameters("@order_id").Value = order_id

        dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderTOPdetil_Update", dbconn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30)) ', "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertop_line", System.Data.OleDb.OleDbType.Integer, 4, "ordertop_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_line", System.Data.OleDb.OleDbType.Integer, 4, "orderterm_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_seq", System.Data.OleDb.OleDbType.Integer, 4, "orderterm_seq"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_percent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_payplant", System.Data.OleDb.OleDbType.VarWChar, 100, "orderterm_payplant"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_status", System.Data.OleDb.OleDbType.VarWChar, 200, "orderterm_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "orderterm_notes"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 400, "create_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "create_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 400, "modify_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modify_date"))
        dbCmdUpdate.Parameters("@order_id").Value = order_id

        dbCmdDelete = New OleDb.OleDbCommand("pr_TrnOrderTOPdetil_Delete", dbconn, dbTrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30)) ', "order_id"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ordertop_line", System.Data.OleDb.OleDbType.Integer, 4, "ordertop_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_line", System.Data.OleDb.OleDbType.Integer, 4, "orderterm_line"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_seq", System.Data.OleDb.OleDbType.Integer, 4, "orderterm_seq"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_percent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_percent", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_rate", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderterm_amount", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_payplant", System.Data.OleDb.OleDbType.VarWChar, 100, "orderterm_payplant"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_status", System.Data.OleDb.OleDbType.VarWChar, 200, "orderterm_status"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderterm_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "orderterm_notes"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 400, "create_by"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "create_date"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 400, "modify_by"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modify_date"))
        dbCmdDelete.Parameters("@order_id").Value = order_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Try
            dbDA.Update(objTbl)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function uiTrnPurchaseOrder3_OpenRowTOPDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderTOPdetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderTOPdetil.Clear()

        Me.tbl_TrnOrderTOPdetil = clsDataset.CreateTblTrnOrderTOPdetil()
        Me.tbl_TrnOrderTOPdetil.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").AutoIncrement = True
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderTOPdetil.Columns("orderterm_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnOrderTOPdetil)
            Me.DgvTrnOrderTOPdetil.DataSource = Me.tbl_TrnOrderTOPdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPurchaseOrder3_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub btn_addTOP_Click(sender As Object, e As EventArgs) Handles btn_addTOP.Click
        Dim TotalForeignInclDisc As Decimal = 0
        Dim amountTOPAdd As Decimal = 0
        Dim amountTOPcurrent As Decimal = 0
        Dim percentTOPAdd As Decimal = 0

        '===================== REMARK 20191205 =========
        'For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
        '    TotalForeignInclDisc = TotalForeignInclDisc + Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_rowtotalforeign_incldisc")
        'Next
        '===================== MODIFIED 20191205 =======
        For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
            TotalForeignInclDisc = TotalForeignInclDisc + Math.Round(((tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreign") - _
                                                                                       tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount")) * _
                                                                                       1) * _
                                                                                       tbl_TrnOrderdetil.Rows(i).Item("orderdetil_qty"), 2, MidpointRounding.AwayFromZero)
        Next

        '================================================

        If Me.tbl_TrnOrderTOPdetil.Rows.Count <> 0 Then
            For p As Integer = 0 To Me.tbl_TrnOrderTOPdetil.Rows.Count - 1
                If Me.tbl_TrnOrderTOPdetil.Rows(p).RowState <> DataRowState.Deleted Then
                    amountTOPcurrent = amountTOPcurrent + Me.tbl_TrnOrderTOPdetil.Rows(p).Item("orderterm_amount")
                End If
            Next
            amountTOPAdd = TotalForeignInclDisc - amountTOPcurrent

            percentTOPAdd = amountTOPAdd / TotalForeignInclDisc * 100
        Else
            amountTOPAdd = TotalForeignInclDisc
            percentTOPAdd = 100
        End If

        If amountTOPAdd <= 0 Then
            MsgBox("Amount all filled into TOP !", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        Dim row As DataRow
        row = Me.tbl_TrnOrderTOPdetil.NewRow()
        If Me.obj_Order_id.Text <> "" Then
            row.Item("order_id") = Me.obj_Order_id.Text
        Else
            row.Item("order_id") = ""
        End If
        row.Item("ordertop_line") = 0
        row.Item("orderterm_seq") = 0
        row.Item("orderterm_percent") = percentTOPAdd
        row.Item("orderterm_amount") = amountTOPAdd
        row.Item("orderterm_payplant") = "AP"
        row.Item("orderterm_status") = ""
        row.Item("orderterm_notes") = ""
        row.Item("currency_id") = Me.cbo_Currency.SelectedValue

        If Me.tbl_TrnOrderdetil.Rows.Count <> 0 Then
            row.Item("orderterm_rate") = Me.tbl_TrnOrderdetil.Rows(0).Item("orderdetil_foreignrate")
        Else
            row.Item("orderterm_rate") = 0
        End If

        row.Item("create_by") = ""
        row.Item("create_date") = Date.Now()

        row.Item("modify_by") = ""
        row.Item("modify_date") = Date.Now()

        Me.tbl_TrnOrderTOPdetil.Rows.Add(row)
    End Sub

    Private Sub AddPayingData(ByVal paying_id As String, ByVal paying_name As String)
        Dim row As DataRow
        row = Me.tbl_MstOrderPaying.NewRow()
        row.Item("paying_id") = paying_id
        row.Item("paying_name") = paying_name
        Me.tbl_MstOrderPaying.Rows.Add(row)
    End Sub

    Private Function SaveTOP() As Boolean
        '========= TOP LOcking =============
        If Me.DgvTrnOrderTOPdetil.Rows.Count <> 0 Then
            Dim percent_total As Decimal = 0

            Dim count_AP As Integer = 0
            Dim count_NoFillPayPlant As Integer = 0
            Dim count_percent0 As Integer = 0

            Dim TotalForeignInclDisc As Decimal = 0
            Dim TotalAmountTOP As Decimal = 0

            For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                TotalForeignInclDisc = TotalForeignInclDisc + Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_rowtotalforeign_incldisc")
            Next

            If Me.tbl_TrnOrderTOPdetil.Rows.Count <> 0 Then
                For w As Integer = 0 To Me.tbl_TrnOrderTOPdetil.Rows.Count - 1
                    If Me.tbl_TrnOrderTOPdetil.Rows(w).RowState <> DataRowState.Deleted Then
                        TotalAmountTOP = TotalAmountTOP + Me.tbl_TrnOrderTOPdetil.Rows(w).Item("orderterm_amount")
                    End If
                Next
            Else
                MsgBox("TOP tidak boleh kosong", MsgBoxStyle.Exclamation, "Attention")
                Exit Function
            End If

            If TotalForeignInclDisc <> TotalAmountTOP Then

                MsgBox("Total Amount TOP dengan total amount order tidak sama !", MsgBoxStyle.Exclamation, "Attention")
                Exit Function
            End If

            For a As Integer = 0 To Me.DgvTrnOrderTOPdetil.RowCount - 1
                If Me.DgvTrnOrderTOPdetil.Rows(a).Cells("orderterm_payplant").Value = "AP" Then
                    count_AP = count_AP + 1
                End If
            Next

            For up As Integer = 0 To Me.DgvTrnOrderTOPdetil.RowCount - 1
                If Me.DgvTrnOrderTOPdetil.Rows(up).Cells("orderterm_payplant").Value = "" Then
                    count_NoFillPayPlant = count_NoFillPayPlant + 1
                End If
            Next

            If count_percent0 > 0 Then
                MsgBox("Term Percent cannot be zero value !", MsgBoxStyle.Information, "Information")
                Exit Function
            End If

            If count_NoFillPayPlant > 0 Then
                MsgBox("Pay Plant must be filled !", MsgBoxStyle.Information, "Information")
                Exit Function
            End If

            If count_AP > 1 Then
                MsgBox("Should not be more than one payment by AP !", MsgBoxStyle.Information, "Information")
                Exit Function
            End If

        Else
            MsgBox("TOP harus diisi", MsgBoxStyle.Critical, "Critical")
        End If
        '=============================================================================================================

        Dim u As Integer = 0
        Dim success As Boolean
        Dim MasterDataState As System.Data.DataRowState
        Dim tbl_TrnOrderTOPdetil_Changes As DataTable
        Dim result As FormSaveResult
        Dim cookie As Byte() = Nothing
        Dim dbConn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        Dim is_rollback As Boolean = False

        Me.DgvTrnOrderTOPdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOrderTOPdetil).EndCurrentEdit()
        tbl_TrnOrderTOPdetil_Changes = Me.tbl_TrnOrderTOPdetil.GetChanges()

        If tbl_TrnOrderTOPdetil_Changes IsNot Nothing Then
            Try
                dbConn1.Open()
                dbTrans = dbConn1.BeginTransaction()
                clsApplicationRole.SetAppRole(dbConn1, dbTrans, cookie)

                '====== ADD 20160822 === untuk TOPDetil(term of payment Detil)
                If tbl_TrnOrderTOPdetil_Changes IsNot Nothing Then
                    For u = 0 To Me.tbl_TrnOrderTOPdetil.Rows.Count - 1
                        If Me.tbl_TrnOrderTOPdetil.Rows(u).RowState = DataRowState.Added Then
                            Me.tbl_TrnOrderTOPdetil.Rows(u).Item("order_id") = Me.obj_Order_id.Text
                        End If
                    Next
                    success = Me.uiTrnPurchaseOrder3_SaveTOPDetil(Me.obj_Order_id.Text, tbl_TrnOrderTOPdetil_Changes, MasterDataState, dbConn1, dbTrans)
                    If Not success Then
                        GoTo rollback
                    End If
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPurchaseOrder3_SaveDetilTOPdetil(tbl_TrnOrderdetilTOPdetil_Changes)")
                    Me.tbl_TrnOrderTOPdetil.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                dbTrans.Commit()

                If result = FormSaveResult.SaveSuccess Then
                    GoTo save_confirmation
                End If

rollback:
                dbTrans.Rollback()
                is_rollback = True
save_confirmation:
                If SHOW_SAVE_CONFIRMATION Then
                    Dim dbConn2 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                    Dim cookie2 As Byte() = Nothing

                    dbConn2.Open()
                    clsApplicationRole.SetAppRole(dbConn2, cookie2)

                    Try

                        If is_rollback = False Then
                            MessageBox.Show("Term of payment Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Me.uiTrnPurchaseOrder3_OpenRowTOPDetil(Me._CHANNEL, Me.obj_Order_id.Text, dbConn2)
                        Me.LockingTOP()

                    Catch ex As Exception
                        Throw ex
                    Finally
                        If dbConn2.State = ConnectionState.Open Then
                            clsApplicationRole.UnsetAppRole(dbConn2, cookie2)
                            dbConn2.Close()
                        End If
                    End Try
                End If

            Catch ex As Exception
                Dim dbConn2 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                Dim cookie2 As Byte() = Nothing

                dbConn2.Open()
                clsApplicationRole.SetAppRole(dbConn2, cookie2)

                Try
                    result = FormSaveResult.SaveError
                    MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dbTrans.Rollback()
                    Me.uiTrnPurchaseOrder3_OpenRowTOPDetil(Me._CHANNEL, Me.obj_Order_id.Text, dbConn2)
                    Me.LockingTOP()
                Catch exs As Exception
                    Throw exs
                Finally
                    If dbConn2.State = ConnectionState.Open Then
                        clsApplicationRole.UnsetAppRole(dbConn2, cookie2)
                        dbConn2.Close()
                    End If
                End Try

            Finally
                If dbConn1.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn1, dbTrans, cookie)
                    dbConn1.Close()
                End If
            End Try
        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes TOP has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Function

    Private Sub LockingTOP()
        If Me.tbl_TrnOrder_Temp.Rows.Count <> 0 Then
            Dim order_approved As Integer = 0

            order_approved = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved")
            If order_approved = 1 Then

                'For i As Integer = 0 To Me.DgvTrnOrderTOP.Rows.Count - 1
                '    If (clsUtil.IsDbNull(Me.DgvTrnOrderTOP.Rows(i).Cells("advance_id").Value, "") = "" And Me.DgvTrnOrderTOP.Rows(i).Cells("orderterm_status").Value = "VQ") _
                '        Or (clsUtil.IsDbNull(Me.DgvTrnOrderTOP.Rows(i).Cells("advance_id").Value, "") = "" And Me.DgvTrnOrderTOP.Rows(i).Cells("orderterm_status").Value = "AP") Then
                '        Me.DgvTrnOrderTOP.Rows(i).ReadOnly = False
                '        Me.DgvTrnOrderTOP.Rows(i).Cells("advance_id").ReadOnly = True
                '    Else
                '        Me.DgvTrnOrderTOP.Rows(i).ReadOnly = True
                '    End If
                'Next

                Me.btn_addTOP.Enabled = True
                'Me.btn_saveTOP.Visible = True
            ElseIf order_approved = 0 Then
                'Me.DgvTrnOrderTOP.ReadOnly = False
                Me.btn_addTOP.Enabled = True
                'Me.btn_saveTOP.Visible = False
            Else
                'Me.DgvTrnOrderTOP.ReadOnly = False
                Me.btn_addTOP.Enabled = True
                'Me.btn_saveTOP.Visible = False
            End If
        End If
    End Sub

    Private Sub DgvTrnOrderTOPdetil_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTrnOrderTOPdetil.CellValueChanged
        Dim TotalForeignInclDisc As Decimal = 0

        If Me.tbl_TrnOrderdetil.Rows.Count <> 0 Then
            '===================== REMARK 20191205 =========
            'For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
            '    TotalForeignInclDisc = TotalForeignInclDisc + Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_rowtotalforeign_incldisc")
            'Next
            '===================== MODIFIED 20191205 =======
            For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                TotalForeignInclDisc = TotalForeignInclDisc + Math.Round(((tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreign") - _
                                                                                           tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount")) * _
                                                                                           1) * _
                                                                                           tbl_TrnOrderdetil.Rows(i).Item("orderdetil_qty"), 2, MidpointRounding.AwayFromZero)
            Next

            '================================================

            Select Case e.ColumnIndex
                Case Me.DgvTrnOrderTOPdetil.Columns("orderterm_amount").Index
                    Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_percent").Value = (Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_amount").Value / TotalForeignInclDisc) * 100 'amount = percent/100 * TotalForeignInclDisc
            End Select
        End If
    End Sub

    Private Sub SetPersenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPersenToolStripMenuItem.Click
        Dim tbl_TOPcek As DataTable = New DataTable()
        Dim response_id As String = ""
        tbl_TOPcek.Clear()

        If Me.obj_Order_id.Text <> "" Then
            Me.DataFill(tbl_TOPcek, "pr_TrnOrderTOPDetil_Select", String.Format("order_id = '{0}' and orderterm_line = '{1}' ", Me.obj_Order_id.Text, Me.DgvTrnOrderTOPdetil.CurrentRow.Cells("orderterm_line").Value))
            If tbl_TOPcek.Rows.Count <> 0 Then
                response_id = clsUtil.IsDbNull(tbl_TOPcek.Rows(0).Item("response_id"), "")
            End If
        End If

        If response_id = "" Then
            Dim TotalForeignInclDisc As Decimal = 0
            '===================== REMARK 20191205 =========
            'For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
            '    TotalForeignInclDisc = TotalForeignInclDisc + Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_rowtotalforeign_incldisc")
            'Next
            '===================== MODIFIED 20191205 =======
            For i As Integer = 0 To Me.tbl_TrnOrderdetil.Rows.Count - 1
                TotalForeignInclDisc = TotalForeignInclDisc + Math.Round(((tbl_TrnOrderdetil.Rows(i).Item("orderdetil_foreign") - _
                                                                                           tbl_TrnOrderdetil.Rows(i).Item("orderdetil_discount")) * _
                                                                                           1) * _
                                                                                           tbl_TrnOrderdetil.Rows(i).Item("orderdetil_qty"), 2, MidpointRounding.AwayFromZero)
            Next

            '================================================

            Dim dlgTOPPercentTools As dlgTOPPercentTools = New dlgTOPPercentTools(Me.DSN, Me._CHANNEL, TotalForeignInclDisc)
            dlgTOPPercentTools.ShowDialog()
            If dlgTOPPercentTools.DialogResult = DialogResult.OK Then
                Me.DgvTrnOrderTOPdetil.Rows(Me.DgvTrnOrderTOPdetil.CurrentRow.Index).Cells("orderterm_amount").Value = CType(dlgTOPPercentTools.obj_amountaftpercent.Text, Decimal)
            End If
        End If
    End Sub

    Private Sub DgvTrnOrderTOPdetil_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTrnOrderTOPdetil.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.obj_Order_id.Text <> "" Then
                Dim tbl_cekTOPDetil As DataTable = New DataTable()
                Dim advance_id As String = ""

                tbl_cekTOPDetil.Clear()
                Me.DataFill(tbl_cekTOPDetil, "pr_TrnOrderTOP_Select_CekStatus", String.Format("order_id = '{0}' AND orderterm_line = '{1}' ", _
                                                                              Me.obj_Order_id.Text, _
                                                                              Me.DgvTrnOrderTOPdetil.Rows(Me.DgvTrnOrderTOPdetil.CurrentRow.Index).Cells("orderterm_line").Value))
                If tbl_cekTOPDetil.Rows.Count <> 0 Then
                    advance_id = clsUtil.IsDbNull(tbl_cekTOPDetil.Rows(0).Item("response_id"), "")

                    If advance_id <> "" Then
                        MsgBox("Cannot delete, Because this term have Advance !" & vbCrLf & "Advance ID : " & advance_id, MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                End If
            End If

            Me.DgvTrnOrderTOPdetil.Rows.Remove(Me.DgvTrnOrderTOPdetil.CurrentRow)
        End If
    End Sub

    'Private Sub LOCKING_FORM(ByVal ACTION As String)
    '    Me.DgvTrnOrderdetil.Columns("item_id").ReadOnly = True
    '    Me.DgvTrnOrderdetil.Columns("unit_id").ReadOnly = True

    '    If Me._FORMMODE = "ENTRY" Then
    '        If ACTION = "OPENROW" Then
    '            Dim tbl_cek As DataTable = New DataTable()
    '            Dim tbl_TOPcek As DataTable = New DataTable()
    '            Dim approved As Int64 = 0
    '            Dim canceled As Int64 = 0

    '            tbl_cek.Clear()
    '            Me.DataFill(tbl_cek, "pr_TrnOrder_Select_CekStatus", String.Format("order_id = '{0}'", Me.obj_Order_id.Text))

    '            approved = clsUtil.IsDbNull(tbl_cek.Rows(0).Item("order_canceled"), 0)
    '            canceled = clsUtil.IsDbNull(tbl_cek.Rows(0).Item("order_approved"), 0)

    '            '==================================================== LOCK TOP ====================================================='
    '            If approved = 0 Then
    '                Me.tbtnSave.Enabled = True
    '                For col As Integer = 0 To Me.DgvTrnOrderTOPdetil.Columns.Count - 1
    '                    Me.DgvTrnOrderTOPdetil.Columns(col).ReadOnly = True
    '                Next
    '                For i As Integer = 0 To Me.DgvTrnOrderTOPdetil.Rows.Count - 1
    '                    If clsUtil.IsDbNull(Me.DgvTrnOrderTOPdetil.Rows(i).Cells("response_id").Value, "") <> "" Then
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = True
    '                    Else
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = False
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = False
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = False
    '                    End If
    '                Next
    '            ElseIf approved = 1 Then
    '                Me.tbtnSave.Enabled = True
    '                For col As Integer = 0 To Me.DgvTrnOrderTOPdetil.Columns.Count - 1
    '                    Me.DgvTrnOrderTOPdetil.Columns(col).ReadOnly = True
    '                Next
    '                For i As Integer = 0 To Me.DgvTrnOrderTOPdetil.Rows.Count - 1
    '                    If clsUtil.IsDbNull(Me.DgvTrnOrderTOPdetil.Rows(i).Cells("response_id").Value, "") <> "" Then
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = True
    '                    Else
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = False
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = False
    '                        Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = False
    '                    End If
    '                Next
    '            End If
    '            '====================================================================================================================
    '        ElseIf ACTION = "NEW" Then
    '            Me.tbtnSave.Enabled = True
    '        End If
    '    End If
    'End Sub

    Private Sub DgvTrnOrderTOPdetil_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvTrnOrderTOPdetil.CellFormatting
        If clsUtil.IsDbNull(Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("response_id").Value, "") = "" Then
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_amount").ReadOnly = False
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_line").ReadOnly = True
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_payplant").ReadOnly = False
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_notes").ReadOnly = False
        Else
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_amount").ReadOnly = True
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_line").ReadOnly = True
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_payplant").ReadOnly = True
            Me.DgvTrnOrderTOPdetil.Rows(e.RowIndex).Cells("orderterm_notes").ReadOnly = True
        End If
    End Sub

    Private Function RetrieveChildFromRequest(ByVal refrequest_id As String, ByVal refrequestdetil_line As Integer) As DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing
        Dim reason As String = String.Empty
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_requestdetilChild As DataTable = New DataTable

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderDetil_ChildRequest_Select", dbConn)
        dbCmd.Parameters.Add("@request_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@requestdetil_line", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@request_id").Value = refrequest_id
        dbCmd.Parameters("@requestdetil_line").Value = refrequestdetil_line

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        tbl_requestdetilChild.Clear()

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(tbl_requestdetilChild)
            Return tbl_requestdetilChild
        Catch ex As Exception
            Throw New Exception("Not Retrieve" & vbCrLf & ex.Message)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

#Region "LOCKINGFORM"
    Private Sub LOCKING_FORM(ByVal ACTION As String)
        If Me._FORMMODE = "ENTRY" Then
            If ACTION = "OPENROW" Then
                Dim tbl_cek As DataTable = New DataTable()
                Dim tbl_TOPcek As DataTable = New DataTable()
                Dim approved As Int64 = 0
                Dim canceled As Int64 = 0
                Dim order_id As String = Me.obj_Order_id.Text

                Dim tbl_jurnal As DataTable = New DataTable
                Dim error_messagebpj As Decimal = 0
                Dim error_messageadvance As Decimal = 0

                tbl_cek.Clear()
                Me.DataFill(tbl_cek, "pr_TrnOrder_Select_CekStatus", String.Format("order_id = '{0}'", Me.obj_Order_id.Text))

                approved = clsUtil.IsDbNull(tbl_cek.Rows(0).Item("order_approved"), 0)
                canceled = clsUtil.IsDbNull(tbl_cek.Rows(0).Item("order_canceled"), 0)

                '======================================= CEK BPJ DAN PA ===========================================
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

                If error_messagebpj > 0 Then
                    Me.errorbpj = True
                Else
                    Me.errorbpj = False
                End If

                If Me.errorbpj = True Or Me.errorpa = True Then
                    Me.tbtnSave.Enabled = True
                    Me.btnApp.Enabled = False
                    Me.btnUnapp.Enabled = False
                    Me.obj_canceled.Enabled = False
                    Me.chkOrder_canceled.Enabled = False
                    Me.btnApp.Visible = False
                    Me.btnUnapp.Visible = False

                    Exit Sub
                End If

                '==================================================== LOCK TOP =====================================================''
                If canceled = 1 Then
                    Me.tbtnSave.Enabled = False
                    Me.btnApp.Enabled = False
                    Me.btnUnapp.Enabled = False
                    Me.btnApp.Visible = False
                    Me.btnUnapp.Visible = False
                    Me.chkOrder_canceled.Enabled = False
                    Me.obj_canceled.Enabled = False
                    Exit Sub
                End If

                If approved = 0 Or approved = 2 Then
                    Me.tbtnSave.Enabled = True
                    Me.btnApp.Enabled = True
                    Me.btnUnapp.Enabled = False
                    Me.btnApp.Visible = True
                    Me.btnUnapp.Visible = False
                    Me.obj_canceled.Enabled = True
                    Me.chkOrder_canceled.Enabled = False

                    For col As Integer = 0 To Me.DgvTrnOrderTOPdetil.Columns.Count - 1
                        Me.DgvTrnOrderTOPdetil.Columns(col).ReadOnly = True
                    Next
                    For i As Integer = 0 To Me.DgvTrnOrderTOPdetil.Rows.Count - 1
                        If clsUtil.IsDbNull(Me.DgvTrnOrderTOPdetil.Rows(i).Cells("response_id").Value, "") <> "" Then
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = True
                        Else
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = False
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = False
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = False
                        End If
                    Next
                ElseIf approved = 1 Then
                    Me.tbtnSave.Enabled = True
                    Me.btnApp.Enabled = False
                    Me.btnUnapp.Enabled = True
                    Me.btnApp.Visible = False
                    Me.btnUnapp.Visible = True
                    Me.obj_canceled.Enabled = False
                    Me.chkOrder_canceled.Enabled = False
                    For col As Integer = 0 To Me.DgvTrnOrderTOPdetil.Columns.Count - 1
                        Me.DgvTrnOrderTOPdetil.Columns(col).ReadOnly = True
                    Next
                    For i As Integer = 0 To Me.DgvTrnOrderTOPdetil.Rows.Count - 1
                        If clsUtil.IsDbNull(Me.DgvTrnOrderTOPdetil.Rows(i).Cells("response_id").Value, "") <> "" Then
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = True
                        Else
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_amount").ReadOnly = False
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_line").ReadOnly = True
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_payplant").ReadOnly = False
                            Me.DgvTrnOrderTOPdetil.Rows(i).Cells("orderterm_notes").ReadOnly = False
                        End If
                    Next
                End If
                '====================================================================================================================
            ElseIf ACTION = "NEW" Then
                Me.tbtnSave.Enabled = True
                Me.btnApp.Enabled = False
                Me.btnUnapp.Enabled = False
                Me.btnApp.Visible = False
                Me.btnUnapp.Visible = False
                Me.obj_canceled.Enabled = False
                Me.chkOrder_canceled.Enabled = False
            End If
        ElseIf Me._FORMMODE = "VIEW" Then
            Me.tbtnNew.Enabled = False
            Me.tbtnSave.Enabled = False
            Me.btnApp.Enabled = False
            Me.btnUnapp.Enabled = False
            Me.btnApp.Visible = False
            Me.btnUnapp.Visible = False
            Me.obj_canceled.Enabled = False
            Me.chkOrder_canceled.Enabled = False
        End If
    End Sub

    Private Sub LOCKING_FORM_LIST()
        Me.tbtnSave.Enabled = False
        Me.btnApp.Enabled = False
        Me.btnUnapp.Enabled = False
        Me.obj_canceled.Enabled = False

        Me.btnApp.Visible = False
        Me.btnUnapp.Visible = False
    End Sub
#End Region

    '===================== 20180516 =============
#Region "Approval_Order"
    Private Sub btnApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApp.Click
        '=================REMARK 20180516 =======
        'Me.Approve_Order(sender)
        '================= MODIFIED 20180516 ======
        Dim order_id As String = ""
        If Me.FlatTabMain.SelectedIndex = 0 Then
            order_id = Me.DgvTrnOrder.CurrentRow.Cells("order_id").Value
        ElseIf Me.FlatTabMain.SelectedIndex = 1 Then
            order_id = Me.obj_Order_id.Text
        End If

        If order_id <> "" Then
            Me.Order_Approval("approve", order_id)
        End If

    End Sub

    Private Sub btnUnapp_Click(sender As Object, e As EventArgs) Handles btnUnapp.Click
        Dim order_id As String = ""
        If Me.FlatTabMain.SelectedIndex = 0 Then
            order_id = Me.DgvTrnOrder.CurrentRow.Cells("order_id").Value
        ElseIf Me.FlatTabMain.SelectedIndex = 1 Then
            order_id = Me.obj_Order_id.Text
        End If

        If order_id <> "" Then
            Me.Order_Approval("unapprove", order_id)
        End If
    End Sub

    Private Function Order_Approval(ByVal approval_status As String, ByVal order_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing
        Dim reason As String = ""
        Dim usernameto As String = String.Empty
        Dim UsernameEmailTo As String = String.Empty
        Dim UsernameEmailCC As String = String.Empty
        Dim tbl_delegate As DataTable = New DataTable
        Dim userdelegatedto As String = String.Empty
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("prc_TrnOrderApprove", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 14).Value = order_id
            oCm.Parameters.Add("@app_status", System.Data.OleDb.OleDbType.VarWChar, 200).Value = approval_status
            oCm.ExecuteNonQuery()
            oCm.Dispose()

            If approval_status = "approve" Then
                MsgBox("Data Approved !", MsgBoxStyle.Information, "Information")
            Else
                MsgBox("Data Unapproved !", MsgBoxStyle.Information, "Information")
            End If

        Catch ex As Data.OleDb.OleDbException
            If approval_status = "approve" Then
                MessageBox.Show("Data Not Approved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Data Not Unapproved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            If approval_status = "approve" Then
                MessageBox.Show("Data Not Approved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Data Not Unapproved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Me.uiTrnPurchaseOrder3_OpenRow_id(order_id)

    End Function
#End Region

#Region "Cancel_Order"
    Private Sub obj_canceled_Click(sender As Object, e As EventArgs) Handles obj_canceled.Click
        If MsgBox("Are you sure to cancel this order ?", MsgBoxStyle.YesNo, "Cancel Confirmation") = MsgBoxResult.Yes Then
            Me.Order_Cancel(Me.obj_Order_id.Text)
        End If
    End Sub

    Private Function Order_Cancel(ByVal order_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing
        Dim reason As String = ""
        Dim usernameto As String = String.Empty
        Dim UsernameEmailTo As String = String.Empty
        Dim UsernameEmailCC As String = String.Empty
        Dim tbl_delegate As DataTable = New DataTable
        Dim userdelegatedto As String = String.Empty
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("prc_TrnOrderDisabled", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 14).Value = order_id
            oCm.ExecuteNonQuery()
            oCm.Dispose()

            MsgBox("Canceled Order is Success !", MsgBoxStyle.Information, "Information")

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Canceled Order is Not Success !" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Canceled Order is Not Success !" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        Me.uiTrnPurchaseOrder3_OpenRow_id(Me.obj_Order_id.Text)
    End Function
#End Region

    Private Function uiTrnPurchaseOrder3_OpenRow_id(ByVal order_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim channel_id As String = Me._CHANNEL
        Dim row As DataGridViewRow
        Dim i As Integer
        'Dim order_canceled As Boolean
        Dim errorPA As Decimal = 0
        Dim order_approved As Integer = 0
        Dim cookie As Byte() = Nothing

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            Dim tbl_jurnal As DataTable = New DataTable
            Dim error_messageadvance As Decimal = 0
            Dim error_messagebpb As Decimal = 0

            Me.uiTrnPurchaseOrder3_OpenRowMaster(channel_id, order_id, dbConn)
            'j += 1
            Me.uiTrnPurchaseOrder3_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowPaymReq(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowPurchaseReq(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderApproval_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3OrderBPB_OpenRowDetil(channel_id, order_id, dbConn)
            Me.uiTrnPurchaseOrder3_OpenRowTOPDetil(channel_id, order_id, dbConn)
            Me.uiTransaksiOrder_OpenRowAttachmentRequest(order_id, dbConn)
            Me.obj_Budget_id.Enabled = False
            Me.cbo_Budget_name.Enabled = False

            'Dim h As Integer
            'Dim y As Integer
            'Dim tbl_orderAdvance As DataTable = New DataTable

            'If Me.DgvTrnOrderdetil.Rows.Count > 0 Then

            '    For h = 0 To Me.DgvTrnOrderdetil.Rows.Count - 1
            '        If order_id <> String.Empty Then
            '            tbl_jurnal.Clear()
            '            Me.DataFill(tbl_jurnal, "to_TrnOrderdetil_SelectJurnalBPB", String.Format("order_id = '{0}' AND orderdetil_line = {1}", order_id, clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)))
            '            tbl_orderAdvance.Clear()
            '            Dim orderdetil_line As Integer = clsUtil.IsDbNull(Me.DgvTrnOrderdetil.Rows(h).Cells("orderdetil_line").Value, 0)
            '            Me.DataFill(tbl_orderAdvance, "pr_TrnOrderdetilAdvanceForOrder_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND isadvance <> 0 and advance_canceled = 0", order_id, orderdetil_line))

            '            If tbl_jurnal.Rows.Count > 0 Or tbl_orderAdvance.Rows.Count > 0 Then
            '                Dim u As Integer

            '                For u = 0 To tbl_jurnal.Rows.Count - 1
            '                    If tbl_jurnal.Rows(u).Item("terimabarang_id") <> "" Or clsUtil.IsDbNull(tbl_jurnal.Rows(u).Item("isadvance"), 0) = 1 Then
            '                        error_messagebpb += 1

            '                    End If
            '                Next
            '                For y = 0 To tbl_orderAdvance.Rows.Count - 1
            '                    If clsUtil.IsDbNull(tbl_orderAdvance.Rows(y).Item("isadvance"), 0) <> 0 Then
            '                        error_messageadvance += 1

            '                    End If
            '                Next
            '            End If
            '        End If
            '    Next
            'End If

            'If error_messageadvance > 0 Then
            '    Me.errorPA = True
            'Else
            '    Me.errorPA = False
            'End If

            'If Me._FORMMODE <> "VIEW" Then
            '    'cek data approval
            '    If Me.DgvTrnOrder.Rows.Count <> 0 Then
            '        row = Me.DgvTrnOrder.SelectedRows(i)
            '        order_canceled = row.Cells("order_canceled").Value
            '        order_approved = row.Cells("order_approved2").Value

            '        If order_approved = 1 And order_canceled = False Then
            '            Me.btnApp.Enabled = True
            '            Me.chkOrder_canceled.Enabled = False
            '        ElseIf order_approved = 0 And order_canceled = False Then
            '            Me.btnApp.Enabled = True
            '            Me.chkOrder_canceled.Enabled = True
            '        ElseIf order_approved = 0 And order_canceled = True Then
            '            Me.btnApp.Enabled = False
            '            Me.chkOrder_canceled.Enabled = False
            '        ElseIf order_approved = 2 And order_canceled = True Then
            '            Me.btnApp.Enabled = False
            '            Me.chkOrder_canceled.Enabled = False
            '        ElseIf order_approved = 2 And order_canceled = False Then
            '            Me.btnApp.Enabled = True
            '            Me.chkOrder_canceled.Enabled = True
            '        End If
            '    End If

            '    ' cek data BPJ dan PA
            '    If (error_messagebpb > 0 Or error_messageadvance > 0) Then
            '        Me.chkOrder_canceled.Enabled = False
            '        Me.btnApp.Enabled = False
            '        Me.tbtnSave.Enabled = False
            '    End If
            'Else
            '    Me.btnApp.Visible = False
            'End If

            Me.uiTrnPurchaseOrder3_Lock()
            Me.IsiBudgetName()
            Me.LOCKING_FORM("OPENROW")

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnPurchaseOrder3_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try


        ''==================== ATTACHMENT =================
        Dim dbConnFiles As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFiles)
        Dim cookieFiles As Byte() = Nothing
        Try
            dbConnFiles.Open()
            clsApplicationRole.SetAppRole(dbConnFiles, cookieFiles)
            Me.uiTransaksiOrder_OpenRowAttachment(order_id, dbConnFiles)

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnRentalOrder3_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConnFiles, cookieFiles)
            dbConnFiles.Close()
        End Try
        '========================================

        RaiseEvent FormAfterOpenRow(order_id)

        Me.Cursor = Cursors.Arrow
        Return True
    End Function


#Region "Attachment"
    Private Sub obj_addattachment_Click(sender As Object, e As EventArgs) Handles obj_addattachment.Click
        Me.object_attach_dlg.Multiselect = False
        If Me.object_attach_dlg.ShowDialog = DialogResult.OK Then
            If New IO.FileInfo(Me.object_attach_dlg.FileName).Length > 5000000 Then ' jika file lebih besar dari 5000000 byte = 5 Mb tidak boleh diattach
                MsgBox("Ukuran file tidak boleh lebih dari 5 Mb", MsgBoxStyle.Critical, "Attention")
                Exit Sub
            End If
            Dim dlgAttachmentDescr As New dlgAttachmentDescr(Me.object_attach_dlg.SafeFileName)
            If dlgAttachmentDescr.ShowDialog = DialogResult.OK Then
                Dim row As DataRow
                row = Me.tbl_TrnOrderAttachment.NewRow()
                row.Item("filename") = dlgAttachmentDescr.obj_attachmentdscr.Text
                row.Item("fileext") = New IO.FileInfo(Me.object_attach_dlg.FileName).Extension
                row.Item("filedata") = Me.GetByteArrayFile(Me.object_attach_dlg.FileName)
                row.Item("notes") = ""
                row.Item("localpath_temp") = Me.object_attach_dlg.FileName
                row.Item("doctype") = dlgAttachmentDescr.obj_doctype.EditValue
                Me.tbl_TrnOrderAttachment.Rows.Add(row)
            End If
        End If
    End Sub

    Public Shared Function GetTempFilename(ByVal extension As String) As String
        Return System.IO.Path.GetTempPath() + Guid.NewGuid.ToString() + extension
    End Function

    Private Sub RepositoryItemButtonOpenFile_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonOpenFile.ButtonClick
        Dim datarow As DataRow = Me.GV_OrderAttachment.GetFocusedDataRow

        If datarow.Item("doctype") = "Comparative Sheet" Then
            If Me._FORMMODE = "VIEW" Then
                Dim tbl_user As DataTable = New DataTable()
                Dim userstruktunit As Decimal = 0
                Me.DataFill(tbl_user, "ms_MstUser_Select", String.Format(" username = '{0}' ", Me.UserName))
                If tbl_user.Rows.Count <> 0 Then
                    userstruktunit = tbl_user.Rows(0).Item("strukturunit_id")
                End If

                If userstruktunit <> 5559 And userstruktunit <> 5507 And userstruktunit <> 4507 And userstruktunit <> 5511 Then 'BMA
                    MsgBox("You dont have authorize to open or download this file !", MsgBoxStyle.Exclamation, "Attention")
                    Exit Sub
                End If

            End If
        End If

        If datarow.RowState = DataRowState.Added Then
            If datarow.Item("localpath_temp") <> "" Then
                Try
                    Dim Proc As New System.Diagnostics.Process
                    Proc.StartInfo.FileName = datarow.Item("localpath_temp")
                    Proc.Start()
                Catch ex As Exception
                    Throw ex
                End Try
            End If
        Else
            Dim extention As String
            Dim fileByteArray As Byte()
            extention = Me.GV_OrderAttachment.GetFocusedDataRow.Item("fileext")
            fileByteArray = Me.GV_OrderAttachment.GetFocusedDataRow.Item("filedata")
            Me.OpenFile(extention, fileByteArray)
        End If

    End Sub

    Private Function OpenFile(ByVal extension As String, ByVal fileByteArray As Byte()) As Boolean
        Dim filename As String = GetTempFilename(extension)
        IO.File.WriteAllBytes(filename, fileByteArray)
        Process.Start(filename)
        Return True
    End Function

    Private Function DownloadFile(ByVal extension As String, ByVal fileByteArray As Byte()) As Boolean
        Me.SaveFileDialog1.Filter = "|*" + extension
        If Me.SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            IO.File.WriteAllBytes(Me.SaveFileDialog1.FileName, fileByteArray)
            Return True
            Exit Function
        End If
        Return False
    End Function

    Private Function GetByteArrayFile(ByVal LocalPathFile As String) As Byte()
        Dim data As Byte() = Nothing
        data = IO.File.ReadAllBytes(LocalPathFile)
        Return data
    End Function

    Private Sub RepositoryItemButtonDownload_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonDownload.ButtonClick
        If Me.GV_OrderAttachment.GetFocusedDataRow.Item("doctype") = "Comparative Sheet" Then
            If Me._FORMMODE = "VIEW" Then
                Dim tbl_user As DataTable = New DataTable()
                Dim userstruktunit As Decimal = 0
                Me.DataFill(tbl_user, "ms_MstUser_Select", String.Format(" username = '{0}' ", Me.UserName))
                If tbl_user.Rows.Count <> 0 Then
                    userstruktunit = tbl_user.Rows(0).Item("strukturunit_id")
                End If

                If userstruktunit <> 5559 And userstruktunit <> 5507 And userstruktunit <> 4507 And userstruktunit <> 5511 Then 'BMA
                    MsgBox("You dont have authorize to open or download this file !", MsgBoxStyle.Exclamation, "Attention")
                    Exit Sub
                End If

            End If
        End If

        Me.DownloadFile(Me.GV_OrderAttachment.GetFocusedDataRow.Item("fileext"), Me.GV_OrderAttachment.GetFocusedDataRow.Item("filedata"))
    End Sub

    Private Function uiTransaksiOrder_SaveAttachment(ByRef order_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, ByRef dbconn As OleDb.OleDbConnection) As Boolean ', ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        Dim dbCmdInsert As OleDb.OleDbCommand
        'Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_jasakontendetil
        dbCmdInsert = New OleDb.OleDbCommand("od_TrnOrderAttachment_Insert", dbconn) ', dbtrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@filename", System.Data.OleDb.OleDbType.VarWChar, 4000, "filename"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@filedata", System.Data.OleDb.OleDbType.Binary, 11000000, "filedata"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fileext", System.Data.OleDb.OleDbType.VarWChar, 100, "fileext"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@doctype", System.Data.OleDb.OleDbType.VarWChar, 200, "doctype"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.Date, 4, "DBTimeStamp"))
        dbCmdInsert.Parameters("@order_id").Value = order_id


        'dbCmdUpdate = New OleDb.OleDbCommand("jk_TrnJasakontenAttachment_Delete", dbconn, dbtrans)
        'dbCmdUpdate.CommandType = CommandType.StoredProcedure
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jaskon_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@filename", System.Data.OleDb.OleDbType.VarWChar, 4000, "filename"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@filedata", System.Data.OleDb.OleDbType.Binary, "filedata"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fileext", System.Data.OleDb.OleDbType.VarWChar, 4, "fileext"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "notes"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 4000, "create_by"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.Date, 4, "DBTimeStamp"))
        'dbCmdUpdate.Parameters("@jaskon_id").Value = jaskon_id

        'dbCmdDelete = New OleDb.OleDbCommand("jk_TrnJasakontenAttachment_Delete", dbconn) ', dbtrans)
        'dbCmdDelete.CommandType = CommandType.StoredProcedure
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jaskon_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        'dbCmdDelete.Parameters("@jaskon_id").Value = jaskon_id

        dbDA = New OleDb.OleDbDataAdapter
        'dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        'dbDA.DeleteCommand = dbCmdDelete

        Try
            'dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            'dbConn.Close()
        End Try

        Return True
    End Function

    Private Sub GV_OrderAttachment_KeyDown(sender As Object, e As KeyEventArgs) Handles GV_OrderAttachment.KeyDown
        If e.KeyData = Keys.Delete Then
            Dim approved As Integer = 0

            If Me.tbl_TrnOrder_Temp.Rows.Count <> 0 Then
                approved = Me.tbl_TrnOrder_Temp.Rows(0).Item("order_approved")
            End If

            Dim canceled As Boolean = False
            canceled = clsUtil.IsDbNull(Me.tbl_TrnOrder_Temp.Rows(0).Item("order_canceled"), False)

            If Me._FORMMODE <> "VIEW" Then
                If canceled = True Then
                    MsgBox("Cannot delete data !!" + Chr(13) + "Data has been Canceled.")
                    Exit Sub
                End If

                If (approved = 0 Or approved = 2) Then
                    If Me.GV_OrderAttachment.GetFocusedDataRow.RowState = DataRowState.Added Then
                        Me.GV_OrderAttachment.DeleteSelectedRows()
                    Else
                        Dim dlgtanyadelete As String = MsgBox("Are you sure to delete this row ?", MsgBoxStyle.YesNo, "Confirmation Delete Row.")
                        If dlgtanyadelete = MsgBoxResult.Yes Then
                            Dim order_id As String = Me.GV_OrderAttachment.GetRowCellValue(Me.GV_OrderAttachment.FocusedRowHandle, "order_id").ToString
                            Dim line As Integer = Me.GV_OrderAttachment.GetRowCellValue(Me.GV_OrderAttachment.FocusedRowHandle, "line").ToString

                            Dim dbConnFiles As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFiles)
                            Dim cookieFiles As Byte() = Nothing
                            Try
                                dbConnFiles.Open()
                                clsApplicationRole.SetAppRole(dbConnFiles, cookieFiles)

                                Dim dbCmdDelete As OleDb.OleDbCommand
                                dbCmdDelete = New OleDb.OleDbCommand("od_TrnOrderAttachment_Delete", dbConnFiles)
                                dbCmdDelete.CommandType = CommandType.StoredProcedure
                                dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100))
                                dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 100))
                                dbCmdDelete.Parameters("@order_id").Value = order_id
                                dbCmdDelete.Parameters("@line").Value = line

                                dbCmdDelete.ExecuteNonQuery()
                                Me.uiTransaksiOrder_OpenRowAttachment(order_id, dbConnFiles)

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                clsApplicationRole.UnsetAppRole(dbConnFiles, cookieFiles)
                                If dbConnFiles.State = ConnectionState.Open Then
                                    dbConnFiles.Close()
                                End If
                            End Try
                        End If
                    End If
                End If

                If approved = 1 Then
                    MsgBox("Cannot delete data !!" + Chr(13) + "Order has been Approved")
                    Exit Sub
                End If
            Else
                MsgBox("Cannot delete data !!" + Chr(13) + "Only Procurement can change.")
                Exit Sub
            End If
        End If
    End Sub

    Private Function uiTransaksiOrder_OpenRowAttachment(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("od_TrnOrderAttachment_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderAttachment.Clear()

        Me.tbl_TrnOrderAttachment = clsDataset2.CreateTblTrnOrderAttachment()
        Me.tbl_TrnOrderAttachment.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderAttachment.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderAttachment.Columns("line").AutoIncrement = True
        Me.tbl_TrnOrderAttachment.Columns("line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderAttachment.Columns("line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnOrderAttachment)
            Me.GC_OrderAttachment.DataSource = Me.tbl_TrnOrderAttachment
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiOrder_OpenRowAttachment()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTransaksiOrder_GETAttachmentRequest(ByVal request_list As String) As Boolean
        Dim dbConnFiles As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFiles)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookieFiles As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("od_TrnOrderAttachmentRequest_Select", dbConnFiles)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("request_id IN ({0})", request_list)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderAttachmentRequest.Clear()

        Try
            dbConnFiles.Open()
            clsApplicationRole.SetAppRole(dbConnFiles, cookieFiles)
            dbDA.Fill(Me.tbl_TrnOrderAttachmentRequest)
            Me.GC_RequestAttachment.DataSource = Me.tbl_TrnOrderAttachmentRequest
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiOrder_OpenRowAttachment()" & vbCrLf & ex.Message)
        Finally
            clsApplicationRole.UnsetAppRole(dbConnFiles, cookieFiles)
            dbConnFiles.Close()
        End Try

    End Function

    Private Sub uiTransaksiOrder_OpenRowAttachmentRequest(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_listrequest As DataTable = New DataTable()

        dbCmd = New OleDb.OleDbCommand("od_TrnOrderGetReferenceAttachment_Select", dbConn)
        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@order_id").Value = order_id 'String.Format("order_id = '{0}',", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tbl_listrequest.Clear()

        Try
            dbDA.Fill(tbl_listrequest)

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiOrder_OpenRowAttachment()" & vbCrLf & ex.Message)
        End Try
        Dim listrequest As String = ""
        If tbl_listrequest.Rows.Count <> 0 Then
            For i As Integer = 0 To tbl_listrequest.Rows.Count - 1
                If listrequest <> "" Then
                    listrequest = listrequest & String.Format(",'{0}'", tbl_listrequest.Rows(i).Item("request_id"))
                Else
                    listrequest = String.Format("'{0}'", tbl_listrequest.Rows(i).Item("request_id"))
                End If
            Next
            Me.uiTransaksiOrder_GETAttachmentRequest(listrequest)
        End If

    End Sub

    Private Sub RepAttachBtnOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepAttachBtnOpen.ButtonClick
        Dim datarow As DataRow = Me.GV_Requestattachment.GetFocusedDataRow
        If datarow.RowState = DataRowState.Added Then
            If datarow.Item("localpath_temp") <> "" Then
                Try
                    Dim Proc As New System.Diagnostics.Process
                    Proc.StartInfo.FileName = datarow.Item("localpath_temp")
                    Proc.Start()
                Catch ex As Exception
                    Throw ex
                End Try
            End If
        Else
            Dim extention As String
            Dim fileByteArray As Byte()
            extention = Me.GV_Requestattachment.GetFocusedDataRow.Item("fileext")
            fileByteArray = Me.GV_Requestattachment.GetFocusedDataRow.Item("filedata")
            Me.OpenFile(extention, fileByteArray)
        End If
    End Sub

    Private Sub RepAttachBtnDownload_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepAttachBtnDownload.ButtonClick
        Me.DownloadFile(Me.GV_Requestattachment.GetFocusedDataRow.Item("fileext"), Me.GV_Requestattachment.GetFocusedDataRow.Item("filedata"))
    End Sub

#End Region
End Class




