Public Class dlgGetRequest

    Private DSN As String
    Public ProgType As String = ""
    Public tbl_RequestSelect As DataTable = New DataTable
    Public tbl_RequestDetilSelect As DataTable = New DataTable

#Region " Constructor "

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal sDSN As String)
        InitializeComponent()
        Me.DSN = sDSN
    End Sub

#End Region

#Region " UI and Layout "

    Private Function FormatDgvTrnRequest(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cRequest_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_strukturunitid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_strukturunitname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_preparedt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_useddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_useddt2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_prepareloc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_usedloc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_epsstart As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_epsend As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_descrproc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_appcountbma As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "Request ID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 90
        cRequest_id.Visible = True
        cRequest_id.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 60
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 200
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True

        cRequest_strukturunitid.Name = "strukturunit_id"
        cRequest_strukturunitid.HeaderText = "strukturunit_id"
        cRequest_strukturunitid.DataPropertyName = "strukturunit_id"
        cRequest_strukturunitid.Width = 100
        cRequest_strukturunitid.Visible = False
        cRequest_strukturunitid.ReadOnly = True

        cRequest_strukturunitname.Name = "strukturunit_name"
        cRequest_strukturunitname.HeaderText = "Requester Dept."
        cRequest_strukturunitname.DataPropertyName = "strukturunit_name"
        cRequest_strukturunitname.Width = 150
        cRequest_strukturunitname.Visible = True
        cRequest_strukturunitname.ReadOnly = True

        cRequest_date.Name = "request_bookdt"
        cRequest_date.HeaderText = "Date"
        cRequest_date.DataPropertyName = "request_bookdt"
        cRequest_date.DefaultCellStyle.Format = "MMM dd, yyyy"
        cRequest_date.Width = 80
        cRequest_date.Visible = False
        cRequest_date.ReadOnly = True

        cRequest_preparedt.Name = "request_preparedt"
        cRequest_preparedt.HeaderText = "request_preparedt"
        cRequest_preparedt.DataPropertyName = "request_preparedt"
        cRequest_preparedt.Width = 100
        cRequest_preparedt.Visible = False
        cRequest_preparedt.ReadOnly = True

        cRequest_useddt.Name = "request_useddt"
        cRequest_useddt.HeaderText = "request_useddt"
        cRequest_useddt.DataPropertyName = "request_useddt"
        cRequest_useddt.Width = 100
        cRequest_useddt.Visible = False
        cRequest_useddt.ReadOnly = True

        cRequest_useddt2.Name = "request_useddt2"
        cRequest_useddt2.HeaderText = "request_useddt2"
        cRequest_useddt2.DataPropertyName = "request_useddt2"
        cRequest_useddt2.Width = 100
        cRequest_useddt2.Visible = False
        cRequest_useddt2.ReadOnly = True

        cRequest_prepareloc.Name = "request_prepareloc"
        cRequest_prepareloc.HeaderText = "Setup Loc"
        cRequest_prepareloc.DataPropertyName = "request_prepareloc"
        cRequest_prepareloc.Width = 100
        cRequest_prepareloc.Visible = False
        cRequest_prepareloc.ReadOnly = True

        cRequest_usedloc.Name = "request_usedloc"
        cRequest_usedloc.HeaderText = "Shooting Loc"
        cRequest_usedloc.DataPropertyName = "request_usedloc"
        cRequest_usedloc.Width = 100
        cRequest_usedloc.Visible = False
        cRequest_usedloc.ReadOnly = True

        cRequest_epsstart.Name = "request_epsstart"
        cRequest_epsstart.HeaderText = "request_epsstart"
        cRequest_epsstart.DataPropertyName = "request_epsstart"
        cRequest_epsstart.Width = 100
        cRequest_epsstart.Visible = False
        cRequest_epsstart.ReadOnly = True

        cRequest_epsend.Name = "request_epsend"
        cRequest_epsend.HeaderText = "request_epsend"
        cRequest_epsend.DataPropertyName = "request_epsend"
        cRequest_epsend.Width = 100
        cRequest_epsend.Visible = False
        cRequest_epsend.ReadOnly = True

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

        cRequest_appcountbma.Name = "count_appbma"
        cRequest_appcountbma.HeaderText = "Approved By Bma"
        cRequest_appcountbma.DataPropertyName = "count_appbma"
        cRequest_appcountbma.Width = 170
        cRequest_appcountbma.Visible = False
        cRequest_appcountbma.ReadOnly = True

        cCurrency.Name = "currency_id"
        cCurrency.HeaderText = "currency_id "
        cCurrency.DataPropertyName = "currency_id"
        cCurrency.Width = 170
        cCurrency.Visible = False
        cCurrency.ReadOnly = True

        objDgv.MultiSelect = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ScrollBars = ScrollBars.Both
        objDgv.Dock = DockStyle.Fill
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         { _
            cRequest_id, _
            cRequest_date, _
            cBudget_id, _
            cBudget_name, _
            cRekanan_id, _
            cRekanan_name, _
            cRequest_strukturunitid, _
            cRequest_strukturunitname, _
            cRequest_preparedt, _
            cRequest_useddt, _
            cRequest_useddt2, _
            cRequest_prepareloc, _
            cRequest_usedloc, _
            cRequest_epsstart, _
            cRequest_epsend, _
            cRequest_descr, _
            cRequest_descrproc, _
            cRequest_appcountbma, _
            cCurrency _
         })

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

    Private Sub dlgGetRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ProgType = "PG" Then
            Me.FormatDgvTrnRequest(Me.dgvRequestList)
            Me.TxtFullBma.Visible = True
            Me.txtHalfBma.Visible = True
            Me.lblFullBma.Visible = True
            Me.lblHalfBma.Visible = True
            Me.ftabDataReq_Header.Text = "Request Header"
        ElseIf ProgType = "NP" Then
            Me.FormatDgvTrnRequestdetil(Me.dgvRequestList)
            Me.TxtFullBma.Visible = False
            Me.txtHalfBma.Visible = False
            Me.lblFullBma.Visible = False
            Me.lblHalfBma.Visible = False
            Me.ftabDataReq_Header.Text = "Request Detil"
        End If

    End Sub

    Private Sub dgvRequestList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRequestList.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.dgvRequestList.CurrentRow IsNot Nothing And Me.ProgType = "PG" Then
            Me.ftabDataDetil.SelectedIndex = 1
        End If
    End Sub

    Private Sub dgvRequestList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvRequestList.CellFormatting
        If ProgType = "PG" Then
            Try
                If Me.dgvRequestList.Rows(e.RowIndex).Cells("count_appbma").Value = "1" Then
                    Me.dgvRequestList.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.GreenYellow
                Else
                    Me.dgvRequestList.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.White
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub obj_rekanan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_rekanan.TextChanged
        Dim criteria As String

        If Me.ProgType = "PG" Then
            If Me.chk_rekanan.Checked Then
                criteria = String.Format("rekanan_name LIKE '%{0}%'", obj_rekanan.Text)

                Me.tbl_RequestSelect.DefaultView.RowFilter = criteria

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
            If Me.chk_request_id.Checked Then
                criteria = String.Format("request_id LIKE '%{0}%'", obj_request_id.Text)

                Me.tbl_RequestSelect.DefaultView.RowFilter = criteria
            End If
        Else
            If Me.chk_request_id.Checked Then
                criteria = String.Format("request_id LIKE '%{0}%'", obj_request_id.Text)

                Me.tbl_RequestDetilSelect.DefaultView.RowFilter = criteria
            End If
        End If
    End Sub

    Private Sub chk_request_id_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_request_id.CheckedChanged
        If chk_request_id.Checked = True Then
            Me.chk_rekanan.Checked = False
            Me.obj_rekanan.Enabled = False
        Else
            'Me.chk_rekanan.Checked = True
            Me.obj_rekanan.Enabled = True
        End If
    End Sub

    Private Sub chk_rekanan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_rekanan.CheckedChanged
        If chk_rekanan.Checked = True Then
            Me.chk_request_id.Checked = False
            Me.obj_request_id.Enabled = False
        Else
            ' Me.chk_request_id.Checked = True
            Me.obj_request_id.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ProgType = "NP" Then
            If CheckBedaVendor() = False Then
                MsgBox("Vendor can't be different.", MsgBoxStyle.Exclamation)

                Exit Sub
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function CheckBedaVendor() As Boolean
        Dim rows() As DataRow = Me.tbl_RequestdetilSelect.Select("requestdetil_ordered = 1")
        Dim rekanan_id As String
        Dim rekanan_idtemp As String

        For i As Integer = 0 To rows.Length - 1
            rekanan_id = rows(i).Item("rekanan_id")

            For j As Integer = 0 To rows.Length - 1
                rekanan_idtemp = rows(j).Item("rekanan_id")

                If rekanan_id <> rekanan_idtemp Then
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    Private Function CekCurrencyDetil() As Boolean
        Dim distinctdt As New DataTable
        Dim dv As DataView
        Dim mycolumn As DataColumn = New DataColumn

        dv = Me.tbl_RequestDetilSelect.GetChanges.DefaultView
        distinctdt.Columns.Add("currency_id")

        Try
            distinctdt = dv.ToTable(True, "currency_id")

            If distinctdt.Rows.Count >= 1 Then
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

    End Function

End Class