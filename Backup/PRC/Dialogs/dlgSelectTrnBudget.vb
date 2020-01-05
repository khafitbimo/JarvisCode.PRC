Public Class dlgSelectTrnBudget

    Private mDSN As String
    Private retObj As Integer
    Private mDataFiller As clsDataFiller
    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblTrnBudget()
    Private tbl_TrnBudgetdetil As DataTable = clsDataset.CreateTblTrnBudgetdetil()
    Private mChannel_id As String
    Private mJenisBudget As String
    Private mBudget_id As Decimal

    

    Private Function FormatDgvTrnBudget(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cObj_pilih As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_nameshort As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStruktur_Unit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cObj_pilih.Name = "select"
        cObj_pilih.HeaderText = "PILIH"
        cObj_pilih.Width = 50
        cObj_pilih.Visible = True
        cObj_pilih.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 100
        cBudget_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True

        cBudget_nameshort.Name = "budget_nameshort"
        cBudget_nameshort.HeaderText = "budget_nameshort"
        cBudget_nameshort.DataPropertyName = "budget_nameshort"
        cBudget_nameshort.Width = 100
        cBudget_nameshort.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBudget_nameshort.Visible = False
        cBudget_nameshort.ReadOnly = True

        cBudget_amount.Name = "budget_amount"
        cBudget_amount.HeaderText = "Amount"
        cBudget_amount.DataPropertyName = "budget_amount"
        cBudget_amount.Width = 100
        cBudget_amount.DefaultCellStyle.Format = "#,##0.00"
        cBudget_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudget_amount.Visible = True
        cBudget_amount.ReadOnly = True

        cBudget_valas.Name = "budget_valas"
        cBudget_valas.HeaderText = "Valas"
        cBudget_valas.DataPropertyName = "budget_valas"
        cBudget_valas.Width = 100
        cBudget_valas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBudget_valas.Visible = True
        cBudget_valas.ReadOnly = True

        cStruktur_Unit.Name = "strukturunit_id"
        cStruktur_Unit.HeaderText = "Struktur Unit"
        cStruktur_Unit.DataPropertyName = "strukturunit_id"
        cStruktur_Unit.Width = 100
        cStruktur_Unit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cStruktur_Unit.Visible = False
        cStruktur_Unit.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.AllowUserToAddRows = False
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cObj_pilih, cBudget_id, cBudget_name, cBudget_nameshort, cBudget_amount, cBudget_valas, cStruktur_Unit, cCurrency_id})
        objDgv.AutoGenerateColumns = False
    End Function


    Private Function FormatDgvTrnBudgetDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProjectacc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_comp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_unit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_amountprop As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_valasprop As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_amountrev As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_valasrev As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_amountpaid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_valaspaid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_amountreq As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_valasreq As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Visible = True
        cSelect.ReadOnly = False

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Detil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "Line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 100
        cBudgetdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_line.Visible = False
        cBudgetdetil_line.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True

        cBudgetdetil_tgl.Name = "budgetdetil_tgl"
        cBudgetdetil_tgl.HeaderText = "Date"
        cBudgetdetil_tgl.DataPropertyName = "budgetdetil_tgl"
        cBudgetdetil_tgl.Width = 100
        cBudgetdetil_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_tgl.DefaultCellStyle.Format = "MMM dd, yyyy"
        cBudgetdetil_tgl.Visible = False
        cBudgetdetil_tgl.ReadOnly = True

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account ID"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = True

        cProjectacc_id.Name = "projectacc_id"
        cProjectacc_id.HeaderText = "Project Account ID"
        cProjectacc_id.DataPropertyName = "projectacc_id"
        cProjectacc_id.Width = 100
        cProjectacc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProjectacc_id.DefaultCellStyle.Format = "MMM dd, yyyy"
        cProjectacc_id.Visible = False
        cProjectacc_id.ReadOnly = True

        cBudgetdetil_desc.Name = "budgetdetil_desc"
        cBudgetdetil_desc.HeaderText = "Name"
        cBudgetdetil_desc.DataPropertyName = "budgetdetil_desc"
        cBudgetdetil_desc.Width = 100
        cBudgetdetil_desc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_desc.Visible = True
        cBudgetdetil_desc.ReadOnly = True

        cBudgetdetil_amount.Name = "budgetdetil_amount"
        cBudgetdetil_amount.HeaderText = "Amount"
        cBudgetdetil_amount.DataPropertyName = "budgetdetil_amount"
        cBudgetdetil_amount.Width = 100
        cBudgetdetil_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_amount.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_amount.Visible = False
        cBudgetdetil_amount.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency ID"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True

        cBudgetdetil_valas.Name = "budgetdetil_valas"
        cBudgetdetil_valas.HeaderText = "Valas"
        cBudgetdetil_valas.DataPropertyName = "budgetdetil_valas"
        cBudgetdetil_valas.Width = 100
        cBudgetdetil_valas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_valas.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_valas.Visible = True
        cBudgetdetil_valas.ReadOnly = True

        cBudgetdetil_comp.Name = "budgetdetil_comp"
        cBudgetdetil_comp.HeaderText = "Comp"
        cBudgetdetil_comp.DataPropertyName = "budgetdetil_comp"
        cBudgetdetil_comp.Width = 100
        cBudgetdetil_comp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_comp.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_comp.Visible = False
        cBudgetdetil_comp.ReadOnly = True

        cBudgetdetil_rate.Name = "budgetdetil_rate"
        cBudgetdetil_rate.HeaderText = "Rate"
        cBudgetdetil_rate.DataPropertyName = "budgetdetil_rate"
        cBudgetdetil_rate.Width = 100
        cBudgetdetil_rate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_rate.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_rate.Visible = False
        cBudgetdetil_rate.ReadOnly = True

        cBudgetdetil_eps.Name = "budgetdetil_eps"
        cBudgetdetil_eps.HeaderText = "Episode"
        cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
        cBudgetdetil_eps.Width = 100
        cBudgetdetil_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_eps.DefaultCellStyle.Format = "#,###,##0"
        cBudgetdetil_eps.Visible = False
        cBudgetdetil_eps.ReadOnly = True

        cBudgetdetil_unit.Name = "budgetdetil_unit"
        cBudgetdetil_unit.HeaderText = "Unit"
        cBudgetdetil_unit.DataPropertyName = "budgetdetil_unit"
        cBudgetdetil_unit.Width = 100
        cBudgetdetil_unit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_unit.DefaultCellStyle.Format = "#,###,##0"
        cBudgetdetil_unit.Visible = True
        cBudgetdetil_unit.ReadOnly = True

        cBudgetdetil_days.Name = "budgetdetil_days"
        cBudgetdetil_days.HeaderText = "Days"
        cBudgetdetil_days.DataPropertyName = "budgetdetil_days"
        cBudgetdetil_days.Width = 100
        cBudgetdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_days.DefaultCellStyle.Format = "#,###,##0"
        cBudgetdetil_days.Visible = False
        cBudgetdetil_days.ReadOnly = True

        cBudgetdetil_amountprop.Name = "budgetdetil_amountprop"
        cBudgetdetil_amountprop.HeaderText = "Amount Prop"
        cBudgetdetil_amountprop.DataPropertyName = "budgetdetil_amountprop"
        cBudgetdetil_amountprop.Width = 100
        cBudgetdetil_amountprop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_amountprop.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_amountprop.Visible = False
        cBudgetdetil_amountprop.ReadOnly = True

        cBudgetdetil_valasprop.Name = "budgetdetil_valasprop"
        cBudgetdetil_valasprop.HeaderText = "Valas Prop"
        cBudgetdetil_valasprop.DataPropertyName = "budgetdetil_valasprop"
        cBudgetdetil_valasprop.Width = 100
        cBudgetdetil_valasprop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_valasprop.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_valasprop.Visible = False
        cBudgetdetil_valasprop.ReadOnly = True

        cBudgetdetil_amountrev.Name = "budgetdetil_amountrev"
        cBudgetdetil_amountrev.HeaderText = "Amount Rev"
        cBudgetdetil_amountrev.DataPropertyName = "budgetdetil_amountrev"
        cBudgetdetil_amountrev.Width = 100
        cBudgetdetil_amountrev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_amountrev.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_amountrev.Visible = False
        cBudgetdetil_amountrev.ReadOnly = True

        cBudgetdetil_valasrev.Name = "budgetdetil_valasrev"
        cBudgetdetil_valasrev.HeaderText = "Valas Rev"
        cBudgetdetil_valasrev.DataPropertyName = "budgetdetil_valasrev"
        cBudgetdetil_valasrev.Width = 100
        cBudgetdetil_valasrev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_valasrev.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_valasrev.Visible = False
        cBudgetdetil_valasrev.ReadOnly = True

        cBudgetdetil_amountpaid.Name = "budgetdetil_amountpaid"
        cBudgetdetil_amountpaid.HeaderText = "Amount Paid"
        cBudgetdetil_amountpaid.DataPropertyName = "budgetdetil_amountpaid"
        cBudgetdetil_amountpaid.Width = 100
        cBudgetdetil_amountpaid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_amountpaid.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_amountpaid.Visible = False
        cBudgetdetil_amountpaid.ReadOnly = True

        cBudgetdetil_valaspaid.Name = "budgetdetil_valaspaid"
        cBudgetdetil_valaspaid.HeaderText = "Valas Paid"
        cBudgetdetil_valaspaid.DataPropertyName = "budgetdetil_valaspaid"
        cBudgetdetil_valaspaid.Width = 100
        cBudgetdetil_valaspaid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_valaspaid.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_valaspaid.Visible = False
        cBudgetdetil_valaspaid.ReadOnly = True

        cBudgetdetil_amountreq.Name = "budgetdetil_amountreq"
        cBudgetdetil_amountreq.HeaderText = "Amount Req"
        cBudgetdetil_amountreq.DataPropertyName = "budgetdetil_amountreq"
        cBudgetdetil_amountreq.Width = 100
        cBudgetdetil_amountreq.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_amountreq.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_amountreq.Visible = False
        cBudgetdetil_amountreq.ReadOnly = True

        cBudgetdetil_valasreq.Name = "budgetdetil_valasreq"
        cBudgetdetil_valasreq.HeaderText = "Valas Req"
        cBudgetdetil_valasreq.DataPropertyName = "budgetdetil_valasreq"
        cBudgetdetil_valasreq.Width = 100
        cBudgetdetil_valasreq.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_valasreq.DefaultCellStyle.Format = "#,###,##0.00"
        cBudgetdetil_valasreq.Visible = False
        cBudgetdetil_valasreq.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cBudgetdetil_id, cBudgetdetil_line, cBudget_id, cBudgetdetil_tgl, cAcc_id, cProjectacc_id, cBudgetdetil_desc, cBudgetdetil_amount, cCurrency_id, cBudgetdetil_valas, cBudgetdetil_comp, cBudgetdetil_rate, cBudgetdetil_eps, cBudgetdetil_unit, cBudgetdetil_days, cBudgetdetil_amountprop, cBudgetdetil_valasprop, cBudgetdetil_amountrev, cBudgetdetil_valasrev, cBudgetdetil_amountpaid, cBudgetdetil_valaspaid, cBudgetdetil_amountreq, cBudgetdetil_valasreq})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeColumns = False

    End Function


    Private Sub dlgSelectTrnBudget_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim criteria As String = ""
        Dim channel_id As String = clsConfig.globDefaultChannel

        If Me.mJenisBudget = "header" Then
            Me.FormatDgvTrnBudget(Me.dgvTrnBudget)
            Me.tbl_TrnBudget.Clear()
            Try
                mDataFiller.DataFill(Me.tbl_TrnBudget, "pr_TrnBudget_Select", criteria)
                Me.dgvTrnBudget.DataSource = Me.tbl_TrnBudget
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf Me.mJenisBudget = "detil" Then
            Me.FormatDgvTrnBudgetdetil(Me.dgvTrnBudget)
            Me.tbl_TrnBudgetdetil.Clear()
            Try
                criteria = String.Format("budget_id = {0}", mBudget_id)
                mDataFiller.DataFill(Me.tbl_TrnBudgetdetil, "pr_TrnBudgetdetil_Select", criteria)
                Me.dgvTrnBudget.DataSource = Me.tbl_TrnBudgetdetil
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        'Me.load_data()
    End Sub

    Protected Overrides Sub Finalize()
        mDataFiller = Nothing
        MyBase.Finalize()
    End Sub

    Public Sub New(ByVal DSN As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.mDSN = DSN

        mDataFiller = New clsDataFiller(Me.mDSN)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dgvTrnBudget_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTrnBudget.CellClick
        Dim i As Integer
        If e.ColumnIndex = 0 Then
            For i = 0 To Me.dgvTrnBudget.Rows.Count - 1
                If i <> e.RowIndex Then
                    Me.dgvTrnBudget.Rows(i).Cells("select").Value = False
                End If
            Next
        End If
    End Sub

    Private Sub dgvTrnBudget_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvTrnBudget.CellFormatting
        Dim selected As Boolean
        Dim objRow As System.Windows.Forms.DataGridViewRow = dgvTrnBudget.Rows(e.RowIndex)

        Try
            selected = CBool(objRow.Cells("select").Value)
            If selected Then
                objRow.DefaultCellStyle.BackColor = Color.MistyRose
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal channel_id As String, ByVal jenisBudget As String, Optional ByVal _SOURCE As String = "") As Integer
        mChannel_id = channel_id
        mJenisBudget = jenisBudget
        MyBase.ShowDialog(owner)
        Return retObj
    End Function
    Public Shadows Function OpenDialogDetil(ByVal budget_id As Decimal, ByVal owner As System.Windows.Forms.IWin32Window, ByVal channel_id As String, ByVal jenisBudget As String, Optional ByVal _SOURCE As String = "") As Integer
        mChannel_id = channel_id
        mJenisBudget = jenisBudget
        mBudget_id = budget_id
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim i As Integer

        If Me.dgvTrnBudget.RowCount > 0 Then
            For i = 0 To Me.dgvTrnBudget.Rows.Count - 1
                If Me.dgvTrnBudget.Rows(i).Cells("select").Value = True Then
                    If mJenisBudget = "header" Then
                        retObj = Me.dgvTrnBudget.Rows(i).Cells("budget_id").Value
                    Else : retObj = Me.dgvTrnBudget.Rows(i).Cells("budgetdetil_id").Value
                    End If

                    Me.Close()
                End If
            Next
        Else
            retObj = Nothing
            Me.Close()
        End If
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        retObj = Nothing
        Me.Close()
    End Sub
End Class