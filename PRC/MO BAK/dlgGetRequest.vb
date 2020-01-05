Public Class dlgGetRequest

    Public ProgType As String = ""


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
        cRequest_date.DefaultCellStyle.Format = "dd/MM/yyyy"
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
            cRequest_epsend _
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
        cRequest_date.DefaultCellStyle.Format = "dd/MM/yyyy"
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

        cRequestdetil_foreignreal.Name = "requestdetil_foreignreal"
        cRequestdetil_foreignreal.HeaderText = "Amount"
        cRequestdetil_foreignreal.DataPropertyName = "requestdetil_foreignreal"
        cRequestdetil_foreignreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cRequestdetil_foreignreal.DefaultCellStyle.Format = "#,##0.00"
        cRequestdetil_foreignreal.Width = 100
        cRequestdetil_foreignreal.Visible = True
        cRequestdetil_foreignreal.ReadOnly = True

        cRequestdetil_idr.Name = "requestdetil_idr"
        cRequestdetil_idr.HeaderText = "IDR"
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
            cRequestdetil_foreignreal, _
            cRequestdetil_idr, _
            cRequest_strukturunitname, _
            cBudget_id, _
            cBudgetdetil_id, _
 _
            cOrder_id, _
            cRequestdetil_itemid, _
            cunit_id, _
            cRequest_strukturunitid, _
            cRequestdetil_line, _
            cRequest_date _
        })

    End Function

#End Region

    Private Sub dlgGetRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ProgType = "PG" Then
            Me.FormatDgvTrnRequest(Me.dgvRequestList)
        ElseIf ProgType = "NP" Then
            Me.FormatDgvTrnRequestdetil(Me.dgvRequestList)
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
End Class