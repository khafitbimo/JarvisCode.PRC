Public Class dlgGetOrder
    Private DSN As String
    Public ProgType As String = ""
    Public tbl_OrderSelect As DataTable = New DataTable
    Public tbl_RequestDetilSelect As DataTable = clsDataset2.CreateTblRequestdetil()
    Private tbl_MstItem As DataTable = clsDataset2.CreateTblMstItem()
    Private tbl_MstUnit As DataTable = clsDataset2.CreateTblMstUnit()
    Private tbl_MstCurrency As DataTable = clsDataset2.CreateTblMstCurrency()




#Region " UI and Layout "

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

        'If Me._PROGRAMTYPE = "PG" Then
        cBtnBudget.ReadOnly = True
        cBtnBudget.Visible = False
        cBudget_name.Visible = False
        'Else
        'cBtnBudget.ReadOnly = False
        'cBtnBudget.Visible = True
        'cBudget_name.Visible = True
        'End If

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
    Private Function FormatDgvTrnRequestdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cRequest_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_strukturunitid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_strukturunitname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_ordered As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRequestdetil_selected As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRequestdetil_itemid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_itemname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cunit_idname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_foreignreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_descrproc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_approvedbmadt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_approvedbmaby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "Request ID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 95
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
        cOrder_id.Width = 95
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

        cRequest_strukturunitid.Name = "strukturunit_id"
        cRequest_strukturunitid.HeaderText = "strukturunit_id"
        cRequest_strukturunitid.DataPropertyName = "strukturunit_id"
        cRequest_strukturunitid.Width = 130
        cRequest_strukturunitid.Visible = False
        cRequest_strukturunitid.ReadOnly = True

        cRequestdetil_ordered.Name = "requestdetil_ordered"
        cRequestdetil_ordered.HeaderText = " "
        cRequestdetil_ordered.DataPropertyName = "requestdetil_ordered"
        cRequestdetil_ordered.Width = 28
        cRequestdetil_ordered.Visible = True
        cRequestdetil_ordered.ReadOnly = False

        cRequestdetil_selected.Name = "requestdetil_selected"
        cRequestdetil_selected.HeaderText = " "
        cRequestdetil_selected.DataPropertyName = "requestdetil_selected"
        cRequestdetil_selected.Width = 50
        cRequestdetil_selected.Visible = False
        cRequestdetil_selected.ReadOnly = False

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "Line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 100
        cRequestdetil_line.Visible = False
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
        cRequestdetil_itemname.Width = 110
        cRequestdetil_itemname.Visible = True
        cRequestdetil_itemname.ReadOnly = True

        cRequestdetil_descr.Name = "requestdetil_descr"
        cRequestdetil_descr.HeaderText = "Description"
        cRequestdetil_descr.DataPropertyName = "requestdetil_descr"
        cRequestdetil_descr.Width = 150
        cRequestdetil_descr.Visible = True
        cRequestdetil_descr.ReadOnly = True

        cunit_id.Name = "unit_id"
        cunit_id.HeaderText = "unit_id"
        cunit_id.DataPropertyName = "unit_id"
        cunit_id.Width = 35
        cunit_id.Visible = False
        cunit_id.ReadOnly = True

        cunit_idname.Name = "unit_name"
        cunit_idname.HeaderText = "Unit"
        cunit_idname.DataPropertyName = "unit_name"
        cunit_idname.Width = 40
        cunit_idname.Visible = True
        cunit_idname.ReadOnly = True

        cRequest_date.Name = "request_bookdt"
        cRequest_date.HeaderText = "Date"
        cRequest_date.DataPropertyName = "request_bookdt"
        cRequest_date.DefaultCellStyle.Format = "MMM dd, yyyy"
        cRequest_date.Width = 80
        cRequest_date.Visible = False
        cRequest_date.ReadOnly = True

        cRequestdetil_qty.Name = "requestdetil_qty"
        cRequestdetil_qty.HeaderText = "Qty"
        cRequestdetil_qty.DataPropertyName = "Requestdetil_qty"
        cRequestdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_qty.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_qty.Width = 40
        cRequestdetil_qty.Visible = True
        cRequestdetil_qty.ReadOnly = False

        cRequestdetil_foreignrate.Name = "requestdetil_foreignrate"
        cRequestdetil_foreignrate.HeaderText = "Rate"
        cRequestdetil_foreignrate.DataPropertyName = "requestdetil_foreignrate"
        cRequestdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_foreignrate.Width = 100
        cRequestdetil_foreignrate.Visible = True
        cRequestdetil_foreignrate.ReadOnly = True

        cRequestdetil_foreignreal.Name = "requestdetil_foreignreal"
        cRequestdetil_foreignreal.HeaderText = "Amount"
        cRequestdetil_foreignreal.DataPropertyName = "requestdetil_foreignreal"
        cRequestdetil_foreignreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_foreignreal.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_foreignreal.Width = 100
        cRequestdetil_foreignreal.Visible = True
        cRequestdetil_foreignreal.ReadOnly = True

        cRequestdetil_idr.Name = "requestdetil_idrreal"
        cRequestdetil_idr.HeaderText = "IDR"
        cRequestdetil_idr.DataPropertyName = "requestdetil_idrreal"
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
        cRequestdetil_discount.Width = 100
        cRequestdetil_discount.Visible = True
        cRequestdetil_discount.ReadOnly = True


        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Vendor"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 120
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cRequest_descr.Name = "request_descr"
        cRequest_descr.HeaderText = "Request Descr"
        cRequest_descr.DataPropertyName = "request_descr"
        cRequest_descr.Width = 170
        cRequest_descr.Visible = True
        cRequest_descr.ReadOnly = True

        cRequest_descrproc.Name = "request_descrproc"
        cRequest_descrproc.HeaderText = "Request Descr Proc"
        cRequest_descrproc.DataPropertyName = "request_proc"
        cRequest_descrproc.Width = 170
        cRequest_descrproc.Visible = True
        cRequest_descrproc.ReadOnly = True

        cRequestdetil_approvedbmadt.Name = "requestdetil_approvedbmadt"
        cRequestdetil_approvedbmadt.HeaderText = "Appr.BMA"
        cRequestdetil_approvedbmadt.DataPropertyName = "requestdetil_approvedbmadt"
        cRequestdetil_approvedbmadt.Width = 95
        cRequestdetil_approvedbmadt.Visible = True
        cRequestdetil_approvedbmadt.ReadOnly = True

        cRequestdetil_approvedbmaby.Name = "requestdetil_approvedbmaby"
        cRequestdetil_approvedbmaby.HeaderText = "Appr.BMA By"
        cRequestdetil_approvedbmaby.DataPropertyName = "requestdetil_approvedbmaby"
        cRequestdetil_approvedbmaby.Width = 95
        cRequestdetil_approvedbmaby.Visible = True
        cRequestdetil_approvedbmaby.ReadOnly = True

        cCurrency.Name = "currency_id"
        cCurrency.HeaderText = "currency_id "
        cCurrency.DataPropertyName = "currency_id"
        cCurrency.Width = 170
        cCurrency.Visible = False
        cCurrency.ReadOnly = True

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
            cRekanan_name, _
            cRequest_id, _
            cRequestdetil_itemname, _
            cRequestdetil_descr, _
            cRequestdetil_qty, _
            cunit_idname, _
            cRequestdetil_foreignrate, _
            cRequestdetil_foreignreal, _
            cRequestdetil_idr, _
            cRequestdetil_approvedbmadt, _
            cRequestdetil_approvedbmaby, _
            cRequest_strukturunitname, _
            cBudget_id, _
            cBudgetdetil_id, _
            cRequest_descr, _
            cRequest_descrproc, _
 _
            cOrder_id, _
            cRequestdetil_itemid, _
            cunit_id, _
            cRequest_strukturunitid, _
            cRequestdetil_line, _
            cRequest_date, _
            cCurrency _
        })

    End Function
#End Region

    Private Sub dlgGetOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ProgType = "PG" Then
            Me.FormatDgvTrnOrder(Me.dgvOrderList)
            Me.FormatDgvTrnOrderdetil(Me.dgvOrderDetilList)
            Me.FormatDgvTrnRequestdetil(Me.DgvRequestdetilList)
            Me.TxtFullBma.Visible = True
            Me.txtHalfBma.Visible = True
            Me.lblFullBma.Visible = True
            Me.lblHalfBma.Visible = True
            Me.ftabDataOrder_Header.Text = "Order Header"
            Me.ftabDataOrder_Detil.Text = "Order Detil"
        ElseIf ProgType = "NP" Then
            Me.FormatDgvTrnOrderdetil(Me.dgvOrderList)
            Me.TxtFullBma.Visible = False
            Me.txtHalfBma.Visible = False
            Me.lblFullBma.Visible = False
            Me.lblHalfBma.Visible = False
            Me.ftabDataOrder_Detil.ForeColor = Color.Black
            Me.ftabDataOrder_Header.Text = "Request Detil"
            Me.ftabDataOrder_Detil.Text = ""
            ' Me.ftabDataDetil.TabPages.Item(1).IsDisposed = True
            ' Me.ftabDataReq_Detil.Width = 0
        End If

        'Me.FormatDgvTrnRequest(Me.dgvRequestList)

    End Sub
    'Private Sub dgvRequestList_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvRequestList.CellFormatting
    'Dim dgv As DataGridView = sender
    'Dim objRow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

    'Try
    '    If objRow.Cells("requestdetil_checked").Value = 0 Then
    '        objRow.DefaultCellStyle.BackColor = Color.White
    '    Else
    '        objRow.DefaultCellStyle.BackColor = Color.CadetBlue
    '    End If
    'Catch ex As Exception

    'End Try
    'End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dgvRequestList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrderList.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.dgvOrderList.CurrentRow IsNot Nothing And Me.ProgType = "PG" Then
            Me.ftabDataDetil.SelectedIndex = 1
        End If
    End Sub
    Private Sub dgvRequestList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvOrderList.CellFormatting
        If ProgType = "PG" Then
            Try
                If Me.dgvOrderList.Rows(e.RowIndex).Cells("count_appbma").Value = "1" Then

                    Me.dgvOrderList.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.GreenYellow
                Else
                    Me.dgvOrderList.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.White

                End If
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub ftabDataDetil_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Select Case ftabDataDetil.SelectedIndex

            Case 0
                'Me.tbtnSave.Enabled = False
                'Me.tbtnDel.Enabled = False
                'Me.tbtnLoad.Enabled = True
                'Me.tbtnQuery.Enabled = True
                'Me.FlatTabMain.TabPages.Item(0).BackColor = Color.White
                'Me.FlatTabMain.TabPages.Item(1).BackColor = Color.Gainsboro

                'If Me.tbl_RequestdetilSelect.Rows.Count > 0 Then
                '    Me.tbl_RequestdetilSelect.Clear()
                'End If

            Case 1
                'If Me._FORMMODE = "ENTRY" Then
                '    Me.tbtnSave.Enabled = True
                '    Me.tbtnDel.Enabled = True
                '    Me.tbtnLoad.Enabled = False
                '    Me.tbtnQuery.Enabled = False
                'ElseIf Me._FORMMODE = "VIEW" Then
                '    Me.tbtnSave.Enabled = False
                '    Me.tbtnDel.Enabled = False
                '    Me.tbtnLoad.Enabled = False
                '    Me.tbtnQuery.Enabled = False
                'End If

                Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabDataDetil.TabPages.Item(1).BackColor = Color.White
                If Me.ProgType = "PG" Then
                    If Me.dgvOrderList.CurrentRow IsNot Nothing Then
                        Me.openrowdetil(Me.dgvOrderList.CurrentRow.Index)

                        'Else
                        '    Me.uiTrnPurchaseOrder3_NewData()

                    End If
                Else
                    ftabDataDetil.SelectedIndex = 0
                End If
        End Select
    End Sub

    Private Function openrowdetil(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim order_id As String
        Dim tbl_orderdetil As DataTable = clsDataset2.CreateTblTrnOrderdetil
        Dim cookie As Byte() = Nothing

        order_id = Me.dgvOrderList.Rows(rowIndex).Cells("order_id").Value

        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderdetil2_Select2", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tbl_orderdetil.Clear()

        dbConn.Open()
        clsApplicationRole.SetAppRole(dbConn, cookie)

        Try
            Dim i As Integer
            Dim tbl_RequestDetilSelect_Temp As DataTable = clsDataset2.CreateTblRequestdetilSelect

            dbDA.Fill(tbl_orderdetil)
            Me.tbl_RequestDetilSelect.Clear()
            Me.dgvOrderDetilList.DataSource = tbl_orderdetil

            If tbl_orderdetil.Rows.Count > 0 Then
                For i = 0 To tbl_orderdetil.Rows.Count - 1
                    tbl_RequestDetilSelect_Temp.Clear()
                    Me.DataFill(tbl_RequestDetilSelect_Temp, "pr_TrnRequestdetil_Select", "request_id ='" & tbl_orderdetil.Rows(i).Item("orderdetil_requestid_ref") & "' AND requestdetil_line ='" & tbl_orderdetil.Rows(i).Item("requestdetil_line") & "'")
                    Me.tbl_RequestDetilSelect.Merge(tbl_RequestDetilSelect_Temp)
                Next
            End If
            Me.DgvRequestdetilList.DataSource = Me.tbl_RequestDetilSelect
        Catch ex As Exception
            ''Throw New Exception(mUiName & ": uiTrnPurchaseOrder3_OpenRowDetil()" & vbCrLf & ex.Message)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Public Sub New(ByVal sDSN As String, ByVal mst_item As DataTable, ByVal mst_currency As DataTable, ByVal mst_unit As DataTable)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        InitializeComponent()
        Me.tbl_MstUnit = mst_unit
        Me.tbl_MstCurrency = mst_currency
        Me.tbl_MstItem = mst_item
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub obj_rekanan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_rekanan.TextChanged
        Dim criteria As String
        If Me.ProgType = "PG" Then
            If Me.chk_rekanan.Checked Then
                criteria = String.Format("rekanan_name LIKE '%{0}%'", obj_rekanan.Text)

                Me.tbl_OrderSelect.DefaultView.RowFilter = criteria

            End If
        Else
            If Me.chk_rekanan.Checked Then
                criteria = String.Format("rekanan_name LIKE '%{0}%'", obj_rekanan.Text)

                Me.tbl_RequestDetilSelect.DefaultView.RowFilter = criteria

            End If
        End If

    End Sub
    Private Sub obj_request_id_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_request_id.TextChanged
        Dim criteria As String
        If Me.ProgType = "PG" Then
            If Me.chk_order_id.Checked Then
                criteria = String.Format("request_id LIKE '%{0}%'", obj_request_id.Text)

                Me.tbl_OrderSelect.DefaultView.RowFilter = criteria

            End If
        Else
            If Me.chk_order_id.Checked Then
                criteria = String.Format("request_id LIKE '%{0}%'", obj_request_id.Text)

                Me.tbl_RequestDetilSelect.DefaultView.RowFilter = criteria

            End If
        End If
    End Sub

    Private Sub chk_request_id_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_order_id.CheckedChanged
        If chk_order_id.Checked = True Then
            Me.chk_rekanan.Checked = False
            Me.obj_rekanan.Enabled = False
        Else
            'Me.chk_rekanan.Checked = True
            Me.obj_rekanan.Enabled = True
        End If
    End Sub

    Private Sub chk_rekanan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_rekanan.CheckedChanged
        If chk_rekanan.Checked = True Then
            Me.chk_order_id.Checked = False
            Me.obj_request_id.Enabled = False
        Else
            ' Me.chk_request_id.Checked = True
            Me.obj_request_id.Enabled = True
        End If
    End Sub

    Private Sub dgvRequestListDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvOrderDetilList.CellFormatting
        If ProgType = "PG" Then
            'Me.dgvOrderDetilList.Columns("rekanan_name").Visible = False
            'Me.dgvOrderDetilList.Columns("item_name").Visible = False
            'Me.dgvOrderDetilList.Columns("requestdetil_selected").Visible = False
            'Me.dgvOrderDetilList.Columns("requestdetil_ordered").Visible = True
            'Me.dgvOrderDetilList.Columns("request_descrproc").Visible = False
            'Me.dgvOrderDetilList.Columns("request_descr").Visible = False
            'Me.dgvOrderDetilList.Columns("strukturunit_name").Visible = False
            'Me.dgvOrderDetilList.ReadOnly = True
        End If
    End Sub
    Private Function DataFill(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True

    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
End Class