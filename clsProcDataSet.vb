Public Class clsProcDataSet


    Public Shared Function CreateTblRekananType() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanantype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("rekanantype_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblChannel() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblOrderType() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("xordertype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xordertype_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xordertype_mode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty_on", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("day_on", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("eps_on", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("reportform", GetType(System.String)))

        Return tbl
    End Function

    Public Shared Function CreateTblProject() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("project_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblBudget() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblCurrency() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblStrukturUnit() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblRekanan() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_badanhukum", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_city", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_fax", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("rekanan_email", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_url", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_pkpname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_taxprefix", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_buyup", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_buyupposition", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_buyaddress", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("rekanantype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("taxsign_id", GetType(System.Int64)))


        'Defaultvalue
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_badanhukum").DefaultValue = ""
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("rekanan_namereport").DefaultValue = ""
        tbl.Columns("rekanan_address").DefaultValue = ""
        tbl.Columns("rekanan_city").DefaultValue = ""
        tbl.Columns("rekanan_telp").DefaultValue = ""
        tbl.Columns("rekanan_fax").DefaultValue = ""
        tbl.Columns("rekanan_email").DefaultValue = ""
        tbl.Columns("rekanan_url").DefaultValue = ""
        tbl.Columns("rekanan_pkpname").DefaultValue = ""
        tbl.Columns("rekanan_taxprefix").DefaultValue = ""
        tbl.Columns("rekanan_buyup").DefaultValue = ""
        tbl.Columns("rekanan_buyupposition").DefaultValue = ""
        tbl.Columns("rekanan_buyaddress").DefaultValue = ""
        tbl.Columns("rekanan_isdisabled").DefaultValue = 0
        tbl.Columns("rekanantype_id").DefaultValue = 0
        tbl.Columns("taxsign_id").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblOrderKtg() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("xorderktg_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorderktg_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblOrderDetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("xorder_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorderdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorderdetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorderdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorderdetil_day", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorderdetil_eps", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorderdetil_shift1", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorderdetil_shift2", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorderdetil_shift3", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorderdetil_epsdescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorderdetil_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("xorderdetil_domestic", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorderdetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorderdetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorderdetil_subtotal", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("xorderitem_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budgetaccount_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budgetdetil_linedescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))

        '---------------------------
        tbl.Columns("xorderdetil_line").AutoIncrement = True
        tbl.Columns("xorderdetil_line").AutoIncrementSeed = 10
        tbl.Columns("xorderdetil_line").AutoIncrementStep = 10
        tbl.Columns("xorderitem_id").DefaultValue = 0
        tbl.Columns("budgetaccount_id").DefaultValue = 0

        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_linedescr").DefaultValue = ""
        tbl.Columns("xorderdetil_descr").DefaultValue = ""
        tbl.Columns("xorderdetil_qty").DefaultValue = 0
        tbl.Columns("xorderdetil_day").DefaultValue = 0
        tbl.Columns("xorderdetil_eps").DefaultValue = 0
        tbl.Columns("xorderdetil_epsdescr").DefaultValue = ""
        tbl.Columns("xorderdetil_shift1").DefaultValue = False
        tbl.Columns("xorderdetil_shift2").DefaultValue = False
        tbl.Columns("xorderdetil_shift3").DefaultValue = False
        tbl.Columns("xorderdetil_date").DefaultValue = Now

        tbl.Columns("xorderdetil_domestic").DefaultValue = "0"
        tbl.Columns("xorderdetil_foreign").DefaultValue = "0"
        tbl.Columns("xorderdetil_foreignrate").DefaultValue = "0"
        tbl.Columns("currency_id").DefaultValue = "IDR"


        Return tbl
    End Function

    Public Shared Function CreateTblItem() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("xorderitem_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorderitem_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblBudgetDetil() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_descr", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xordertype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorderktg_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorder_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_rev", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_eps", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("xorder_epsdescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xrequest_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_req_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorder_pic", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_iscancel", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorder_cancelfee", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_transportasi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_asuransi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_operator", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("xorder_note", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_set_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("xorder_set_time", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_set_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_use_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("xorder_use_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("xorder_use_timestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_use_timeend", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_use_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_da_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_da_addr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_da_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_da_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_da_up", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_da_hp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_isauth", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorder_auth", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_isappr", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorder_appr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_user_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_user_strukturunit_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("xorder_user_position", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_user_issign", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("xorder_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("xorder_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xorder_modifydate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("xorder_isprinted", GetType(System.Boolean)))


        '-----------
        tbl.Columns("xorder_id").AllowDBNull = True
        tbl.Columns("xorder_id").DefaultValue = "#AUTOREF"
        tbl.Columns("xorderktg_id").DefaultValue = 0
        tbl.Columns("xorder_rev").DefaultValue = "0"
        tbl.Columns("xorder_date").DefaultValue = Now()
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("xorder_descr").DefaultValue = ""
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = "0"
        tbl.Columns("xorder_eps").DefaultValue = 1
        tbl.Columns("xorder_epsdescr").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = "IDR"
        tbl.Columns("xrequest_id").DefaultValue = ""
        tbl.Columns("xorder_req_by").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("xorder_pic").DefaultValue = ""
        tbl.Columns("xorder_iscancel").DefaultValue = 0
        tbl.Columns("xorder_cancelfee").DefaultValue = 0
        tbl.Columns("xorder_pphpercent").DefaultValue = 0.0
        tbl.Columns("xorder_ppnpercent").DefaultValue = 0
        tbl.Columns("xorder_discount").DefaultValue = 0
        tbl.Columns("xorder_transportasi").DefaultValue = 0
        tbl.Columns("xorder_asuransi").DefaultValue = 0
        tbl.Columns("xorder_operator").DefaultValue = 0
        tbl.Columns("xorder_note").DefaultValue = ""
        tbl.Columns("xorder_set_date").DefaultValue = Now
        tbl.Columns("xorder_set_time").DefaultValue = "00:00"
        tbl.Columns("xorder_set_location").DefaultValue = ""
        tbl.Columns("xorder_use_datestart").DefaultValue = Now
        tbl.Columns("xorder_use_dateend").DefaultValue = Now
        tbl.Columns("xorder_use_timestart").DefaultValue = "00:00"
        tbl.Columns("xorder_use_timeend").DefaultValue = "00:00"
        tbl.Columns("xorder_use_location").DefaultValue = ""
        tbl.Columns("xorder_da_name").DefaultValue = ""
        tbl.Columns("xorder_da_addr").DefaultValue = ""
        tbl.Columns("xorder_da_telp").DefaultValue = ""
        tbl.Columns("xorder_da_fax").DefaultValue = ""
        tbl.Columns("xorder_da_up").DefaultValue = ""
        tbl.Columns("xorder_da_hp").DefaultValue = ""
        tbl.Columns("xorder_isauth").DefaultValue = 0
        tbl.Columns("xorder_auth").DefaultValue = ""
        tbl.Columns("xorder_isappr").DefaultValue = 0
        tbl.Columns("xorder_appr").DefaultValue = ""
        tbl.Columns("xorder_user_name").DefaultValue = ""
        tbl.Columns("xorder_user_strukturunit_id").DefaultValue = 0
        tbl.Columns("xorder_user_position").DefaultValue = ""
        tbl.Columns("xorder_user_issign").DefaultValue = 0

        tbl.Columns("xorder_createdate").DefaultValue = Now
        tbl.Columns("xorder_modifyby").DefaultValue = ""
        tbl.Columns("xorder_modifydate").DefaultValue = Now
        tbl.Columns("xorder_isprinted").DefaultValue = 0


        tbl.Columns("xorder_date").DefaultValue = Now()
        tbl.Columns("xorder_createdate").DefaultValue = Now()
        tbl.Columns("xorder_modifydate").DefaultValue = Now()
        tbl.Columns("xorder_set_date").DefaultValue = Now()
        tbl.Columns("xorder_use_datestart").DefaultValue = Now()
        tbl.Columns("xorder_use_dateend").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblOrderPrintForm() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rev", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("xdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("projname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_dept", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("req_dept", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("req_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("set_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("set_time", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("set_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("use_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("use_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("use_timestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("use_timeend", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("use_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("pic", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("spk_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("transport", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asuransi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("opertor", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("note", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_contact", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terbilang", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("appr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("auth", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("da_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("da_address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("da_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("da_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("da_up", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("da_hp", GetType(System.String)))


        Return tbl
    End Function

    Public Shared Function CreateTblOrderPrintForm_detil() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Add(New DataColumn("id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("eps", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("day", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("shift1", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("shift2", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("shift3", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("domestic", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal", GetType(System.Decimal)))
        Return tbl
    End Function

    Public Shared Function CreateTblInvoiceType() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Add(New DataColumn("invoicetype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("invoicetype_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblPaymentRequestType() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Add(New DataColumn("paymentrequesttype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("paymentrequesttype_name", GetType(System.String)))
        Return tbl
    End Function

    Public Shared Function CreateTblPaymentType() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("paymenttype_name", GetType(System.String)))
        Return tbl
    End Function

End Class
