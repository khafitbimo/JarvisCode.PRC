Imports System.Windows.Forms
Imports System.Drawing

Public Class uiTrnOrderDetilReport
    Private Const mUiName As String = "uiTrnOrderDetilReport"

    Private tbl_OrderDetil As DataTable = clsDataset.CreateTblTrnOrderDetilReport()
    Private tbl_currencyid As DataTable = clsDataset.CreateTblMstCurrency()

    Private objReportViewer As New Microsoft.Reporting.WinForms.ReportViewer With {.Dock = DockStyle.Fill}

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "NTV"
#End Region

#Region " Overrides "

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.OrderDetil_Retrieve()
        Me.OrderDetil_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.OrderDetil_PrintPreview()
        Me.Cursor = Cursors.Default
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible

        If Me.PnlDfSearch.Visible Then
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If

        Return MyBase.btnQuery_Click()
    End Function
#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvorderDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvorderDetil Columns 
        Dim request_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim requestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim request_bookdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim requestdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim requestdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim jurnaltype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim order_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim order_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim order_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim order_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim department As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim vendor As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim order_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim order_usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim unit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim currency As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_pphforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_ppnforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim orderdetil_rowtotalforeign_incltax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim rv_usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        request_id.Name = "request_id"
        request_id.HeaderText = "request_id"
        request_id.DataPropertyName = "request_id"
        request_id.Width = 100
        request_id.Visible = True
        request_id.ReadOnly = True

        requestdetil_line.Name = "requestdetil_line"
        requestdetil_line.HeaderText = "requestdetil_line"
        requestdetil_line.DataPropertyName = "requestdetil_line"
        requestdetil_line.Width = 100
        requestdetil_line.Visible = True
        requestdetil_line.ReadOnly = True

        request_bookdt.Name = "request_bookdt"
        request_bookdt.HeaderText = "request_bookdt"
        request_bookdt.DataPropertyName = "request_bookdt"
        request_bookdt.Width = 100
        request_bookdt.Visible = True
        request_bookdt.ReadOnly = True

        requestdetil_descr.Name = "requestdetil_descr"
        requestdetil_descr.HeaderText = "requestdetil_descr"
        requestdetil_descr.DataPropertyName = "requestdetil_descr"
        requestdetil_descr.Width = 100
        requestdetil_descr.Visible = True
        requestdetil_descr.ReadOnly = True


        requestdetil_qty.Name = "requestdetil_qty"
        requestdetil_qty.HeaderText = "requestdetil_qty"
        requestdetil_qty.DataPropertyName = "requestdetil_qty"
        requestdetil_qty.Width = 100
        requestdetil_qty.Visible = True
        requestdetil_qty.ReadOnly = True

        jurnaltype_id.Name = "jurnaltype_id"
        jurnaltype_id.HeaderText = "jurnaltype_id"
        jurnaltype_id.DataPropertyName = "jurnaltype_id"
        jurnaltype_id.Width = 100
        jurnaltype_id.Visible = True
        jurnaltype_id.ReadOnly = True

        order_id.Name = "order_id"
        order_id.HeaderText = "order_id"
        order_id.DataPropertyName = "order_id"
        order_id.Width = 100
        order_id.Visible = True
        order_id.ReadOnly = True


        order_line.Name = "order_line"
        order_line.HeaderText = "order_line"
        order_line.DataPropertyName = "order_line"
        order_line.Width = 100
        order_line.Visible = True
        order_line.ReadOnly = True

        order_date.Name = "order_date"
        order_date.HeaderText = "order_date"
        order_date.DataPropertyName = "order_date"
        order_date.Width = 100
        order_date.Visible = True
        order_date.ReadOnly = True


        order_type.Name = "order_type"
        order_type.HeaderText = "order_type"
        order_type.DataPropertyName = "order_type"
        order_type.Width = 100
        order_type.Visible = True
        order_type.ReadOnly = True

        department.Name = "department"
        department.HeaderText = "department"
        department.DataPropertyName = "department"
        department.Width = 100
        department.Visible = True
        department.ReadOnly = True


        vendor.Name = "vendor"
        vendor.HeaderText = "vendor"
        vendor.DataPropertyName = "vendor"
        vendor.Width = 100
        vendor.Visible = True
        vendor.ReadOnly = True

        order_item.Name = "order_item"
        order_item.HeaderText = "order_item"
        order_item.DataPropertyName = "order_item"
        order_item.Width = 100
        order_item.Visible = True
        order_item.ReadOnly = True

        orderdetil_descr.Name = "orderdetil_descr"
        orderdetil_descr.HeaderText = "orderdetil_descr"
        orderdetil_descr.DataPropertyName = "orderdetil_descr"
        orderdetil_descr.Width = 100
        orderdetil_descr.Visible = True
        orderdetil_descr.ReadOnly = True

        orderdetil_qty.Name = "orderdetil_qty"
        orderdetil_qty.HeaderText = "orderdetil_qty"
        orderdetil_qty.DataPropertyName = "orderdetil_qty"
        orderdetil_qty.Width = 100
        orderdetil_qty.Visible = True
        orderdetil_qty.ReadOnly = True

        orderdetil_days.Name = "orderdetil_days"
        orderdetil_days.HeaderText = "orderdetil_days"
        orderdetil_days.DataPropertyName = "orderdetil_days"
        orderdetil_days.Width = 100
        orderdetil_days.Visible = True
        orderdetil_days.ReadOnly = True

        order_usage.Name = "order_usage"
        order_usage.HeaderText = "order_usage"
        order_usage.DataPropertyName = "order_usage"
        order_usage.Width = 100
        order_usage.Visible = True
        order_usage.ReadOnly = True


        unit.Name = "unit"
        unit.HeaderText = "unit"
        unit.DataPropertyName = "unit"
        unit.Width = 100
        unit.Visible = True
        unit.ReadOnly = True

        currency.Name = "currency"
        currency.HeaderText = "currency"
        currency.DataPropertyName = "currency"
        currency.Width = 100
        currency.Visible = True
        currency.ReadOnly = True

        orderdetil_discount.Name = "orderdetil_discount"
        orderdetil_discount.HeaderText = "orderdetil_discount"
        orderdetil_discount.DataPropertyName = "orderdetil_discount"
        orderdetil_discount.Width = 100
        orderdetil_discount.Visible = True
        orderdetil_discount.ReadOnly = True

        orderdetil_foreign.Name = "orderdetil_foreign"
        orderdetil_foreign.HeaderText = "orderdetil_foreign"
        orderdetil_foreign.DataPropertyName = "orderdetil_foreign"
        orderdetil_foreign.Width = 100
        orderdetil_foreign.Visible = True
        orderdetil_foreign.ReadOnly = True

        orderdetil_pphforeign.Name = "orderdetil_pphforeign"
        orderdetil_pphforeign.HeaderText = "orderdetil_pphforeign"
        orderdetil_pphforeign.DataPropertyName = "orderdetil_pphforeign"
        orderdetil_pphforeign.Width = 100
        orderdetil_pphforeign.Visible = True
        orderdetil_pphforeign.ReadOnly = True

        orderdetil_ppnforeign.Name = "orderdetil_ppnforeign"
        orderdetil_ppnforeign.HeaderText = "orderdetil_ppnforeign"
        orderdetil_ppnforeign.DataPropertyName = "orderdetil_ppnforeign"
        orderdetil_ppnforeign.Width = 100
        orderdetil_ppnforeign.Visible = True
        orderdetil_ppnforeign.ReadOnly = True

        orderdetil_rowtotalforeign_incltax.Name = "orderdetil_rowtotalforeign_incltax"
        orderdetil_rowtotalforeign_incltax.HeaderText = "orderdetil_rowtotalforeign_incltax"
        orderdetil_rowtotalforeign_incltax.DataPropertyName = "orderdetil_rowtotalforeign_incltax"
        orderdetil_rowtotalforeign_incltax.Width = 100
        orderdetil_rowtotalforeign_incltax.Visible = True
        orderdetil_rowtotalforeign_incltax.ReadOnly = True

        rv_usage.Name = "rv_usage"
        rv_usage.HeaderText = "rv_usage"
        rv_usage.DataPropertyName = "rv_usage"
        rv_usage.Width = 100
        rv_usage.Visible = True
        rv_usage.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {request_id, requestdetil_line, request_bookdt, requestdetil_descr, requestdetil_qty, jurnaltype_id, order_id, order_line, order_date, order_type, vendor, order_item, orderdetil_descr, _
         orderdetil_qty, orderdetil_days, order_usage, unit, currency, orderdetil_foreign, orderdetil_pphforeign, orderdetil_ppnforeign, orderdetil_rowtotalforeign_incltax, rv_usage
        })

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function InitLayoutUI() As Boolean
        Me.PnlReport.Controls.Add(Me.objReportViewer)
    End Function

#End Region

#Region " User Defined Function "

    Private Function OrderDetil_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        If Me.chk_vendor_srch.Checked = True Then
            If criteria = "" Then
                criteria &= criteria & String.Format(" vendor like '%{0}%'", Me.obj_vendor_srch.Text)
            Else
                criteria &= String.Format(" AND vendor like '%{0}%'", Me.obj_vendor_srch.Text)
            End If
        End If

        If Me.chk_currency_srch.Checked = True Then
            If criteria = "" Then
                criteria &= criteria & String.Format(" currency like '%{0}%'", Me.obj_currency_srch.Text)
            Else
                criteria &= String.Format(" AND currency like '%{0}%'", Me.obj_currency_srch.Text)
            End If
        End If

        If Me.chk_periode_srch.Checked = True Then
            If criteria = "" Then
                criteria &= String.Format(" request_bookdt BETWEEN '{0}' AND '{1}'", _
                                            obj_bookdate_search_awal.Value.Date.ToString("MM/dd/yyyy") & " 00:00", _
                                            obj_bookdate_search_akhir.Value.Date.ToString("MM/dd/yyyy") & " 23:59")
            Else
                criteria &= String.Format(" AND request_bookdt BETWEEN '{0}' AND '{1}'", _
                                        obj_bookdate_search_awal.Value.Date.ToString("MM/dd/yyyy") & " 00:00", _
                                        obj_bookdate_search_akhir.Value.Date.ToString("MM/dd/yyyy") & " 23:59")
            End If
        End If

        If Me.chk_dept_search.Checked = True Then
            If criteria = "" Then
                criteria &= String.Format(" strukturunit = {0}", Me.obj_strukturunit_id.Text)
            Else
                criteria &= String.Format(" and strukturunit = {0}", Me.obj_strukturunit_id.Text)
            End If
        End If

        If Me.chk_type_srch.Checked = True Then
            If Me.cboTypeSearch.Text = "PO" Then
                If criteria = "" Then
                    criteria &= String.Format(" order_type like '%{0}%'", Me.cboTypeSearch.Text)
                Else
                    criteria &= String.Format(" AND order_type like '%{0}%'", Me.cboTypeSearch.Text)
                End If
            ElseIf Me.cboTypeSearch.Text = "NO" Then
                If criteria = "" Then
                    criteria &= String.Format(" order_type like '%{0}%'", Me.cboTypeSearch.Text)
                Else
                    criteria &= String.Format(" AND order_type like '%{0}%'", Me.cboTypeSearch.Text)
                End If
            ElseIf Me.cboTypeSearch.Text = "TO" Then
                If criteria = "" Then
                    criteria &= String.Format(" order_type like '%{0}%'", Me.cboTypeSearch.Text)
                Else
                    criteria &= String.Format(" AND order_type like '%{0}%'", Me.cboTypeSearch.Text)
                End If
            ElseIf Me.cboTypeSearch.Text = "RO" Then
                If criteria = "" Then
                    criteria &= String.Format(" order_type like '%{0}%'", Me.cboTypeSearch.Text)
                Else
                    criteria &= String.Format(" AND order_type like '%{0}%'", Me.cboTypeSearch.Text)
                End If
            End If
        End If

        Me.tbl_OrderDetil.Clear()

        Try
            Me.DataFill(Me.tbl_OrderDetil, "pr_TrnOrderDetilReport_Select", criteria)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function OrderDetil_PrintPreview() As Boolean
        Dim index As Integer = Me.ftabmain.SelectedIndex
        Dim tbl_orderdetilreport As DataTable = tbl_OrderDetil
        Dim orderdetil As clsTrnOrderDetilReport

        Try
            orderdetil = New clsTrnOrderDetilReport(Me.DSN)
            orderdetil.Print(Me.objReportViewer, Me.DSN, tbl_orderdetilreport, Me.obj_vendor_srch.Text, Me.obj_strukturunit_name.Text, Me.obj_currency_srch.Text, _
                             Me.chk_vendor_srch.Checked, Me.chk_currency_srch.Checked, Me.chk_dept_search.Checked, True)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then

            Dim filer As New clsDataFiller(Me.DSN)
            filer.ComboFill(Me.obj_currency_srch, "currency_id", "currency_shortname", Me.tbl_currencyid, "ms_MstCurrency_Select", "currency_active=1")


            Me.InitLayoutUI()

            Me.tbtnSave.Visible = False
            Me.tbtnDel.Visible = False
            Me.tbtnLoad.Visible = True
            Me.tbtnNew.Visible = False
            Me.tbtnPrint.Visible = False
            Me.tbtnPrintPreview.Visible = False
            Me.tbtnPrev.Visible = False
            Me.tbtnRefresh.Visible = False
            Me.ToolStripSeparator1.Visible = False
            Me.ToolStripSeparator2.Visible = False
            Me.ToolStripSeparator3.Visible = False
            Me.ToolStripSeparator4.Visible = False
            Me.ToolStripSeparator5.Visible = False
            Me.tbtnNext.Visible = False
            Me.tbtnFirst.Visible = False
            Me.tbtnLast.Visible = False
        End If
    End Sub

    Private Sub OrderDetil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub btnVendor_Click(sender As Object, e As EventArgs) Handles btnVendor.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dlg As New DlgSelectRekanan(Me.DSN)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.dgvSelectVendor.CurrentRow.DataBoundItem, DataRowView).Row

            Me.obj_vendor_srch.Text = row.Item("rekanan_name")
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDepartment_Click(sender As Object, e As EventArgs) Handles btnDepartment.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dlg As New DlgSelectStrukturunit(Me.DSN)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvStrukturUnit.CurrentRow.DataBoundItem, DataRowView).Row

            Me.obj_strukturunit_id.Text = row.Item("strukturunit_id").ToString()
            Me.obj_strukturunit_name.Text = row.Item("strukturunit_name").ToString()
        End If

        Me.Cursor = Cursors.Default
    End Sub

End Class


