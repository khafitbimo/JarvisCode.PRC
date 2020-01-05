'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel

Public Class uiOrderHistory
    Private tbl_MstChannel As DataTable = clsDataset2.CreateTblMstChannel()
    Private tbl_MstItem As DataTable = clsDataset2.CreateTblMstItem()
    Private tbl_MstRekanan As DataTable = clsDataset2.CreateTblMstrekanan()
    Private tbl_MstCategory As DataTable = clsDataset2.CreateTblMstItemcategory()
    Private tbl_ShootingLocation As DataTable = clsDataset2.CreateTblShootingLocation()
    Private tbl_MstStrukturUnit As DataTable = clsDataset2.CreateTblMstStrukturUnit()
    Private tbl_MstBudget As DataTable = clsDataset2.CreateTblTrnBudget()

    Private tbl_requestall As DataTable = clsDataset2.CreateTblOrderHistory
    Private tbl_requestall2 As DataTable = New DataTable
    Private tbl_requestall3 As DataTable = New DataTable
    Private tbl_requestall4 As DataTable = New DataTable
    Private tbl_requestall5 As DataTable = New DataTable
    Private tbl_requestall6 As DataTable = New DataTable
    Private COMBO_ISFILLED As Boolean = False

    Private FILTER_QUERY_MODE As Boolean
    Friend Class clsReportList
        Private mReport_id As String
        Private mReport_name As String
        Public Property report_id() As String
            Get
                Return mReport_id
            End Get
            Set(ByVal value As String)
                mReport_id = value
            End Set
        End Property
        Public Property report_name() As String
            Get
                Return mReport_name
            End Get
            Set(ByVal value As String)
                mReport_name = value
            End Set
        End Property
    End Class
    Dim reports As ArrayList = New ArrayList()
    Dim objReport As clsReportList

#Region " Window Parameter "
    Private _CHANNEL As String = clsConfig.globDefaultChannel
    Private _CHANNEL_CANBE_CHANGED As Boolean = True
    Private _CHANNEL_CANBE_BROWSED As Boolean = True

    Private _ORDERTYPE_ID As String = "PO"

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

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiOrderHistory_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiOrderHistory_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()

        'mybase.ParentForm.Menu.MenuItems(
    End Function

    'Public Overrides Function btnHelpTopic_Click() As Boolean
    '    'MsgBox("test help", MsgBoxStyle.OkOnly, "test help")
    '    'HelpProvider1.HelpNamespace = "http://insosys_start.trans7.co.id/ema.chm"
    '    'HelpProvider1.SetHelpNavigator(Me.btnHelpTopic, HelpNavigator.Topic)
    '    'HelpProvider1.SetHelpKeyword(btnHelpTopic, "html/dynamichelp2.htm")
    '    'Help.ShowHelp(Me, HelpProvider1.HelpNamespace)

    '    Return MyBase.btnHelpTopic_Click()
    'End Function


#End Region
    Private Function FormatDgvOrderHistory(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTtttt Columns 
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_requestid_ref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCanceled As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_Name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID (Previous)"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 500
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False
        'cOrder_id.Frozen = True


        cCurrent.Name = "Current"
        cCurrent.HeaderText = "Order ID (Current)"
        cCurrent.DataPropertyName = "Current"
        cCurrent.Width = 150
        cCurrent.Visible = True
        cCurrent.ReadOnly = False
        cCurrent.Frozen = True

        cOrderdetil_requestid_ref.Name = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.HeaderText = "Request ID"
        cOrderdetil_requestid_ref.DataPropertyName = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.Width = 100
        cOrderdetil_requestid_ref.Visible = True
        cOrderdetil_requestid_ref.ReadOnly = False

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "Req.Line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 50
        If Me.cboReportName.SelectedValue = "111" Then
            cRequestdetil_line.Visible = True
        Else
            cRequestdetil_line.Visible = False
        End If

        cRequestdetil_line.ReadOnly = True

        cCanceled.Name = "canceled"
        cCanceled.HeaderText = "canceled"
        cCanceled.DataPropertyName = "canceled"
        cCanceled.Width = 100
        cCanceled.Visible = False
        cCanceled.ReadOnly = True

        cRequest_date.Name = "request_date"
        cRequest_date.HeaderText = "Req.Date"
        cRequest_date.DataPropertyName = "request_date"
        cRequest_date.Width = 100

        If Me.cboReportName.SelectedValue = "111" Then
            cRequest_date.Visible = True
        Else
            cRequest_date.Visible = False
        End If
        cRequest_date.ReadOnly = True


        cItem_Name.Name = "item_name"
        cItem_Name.HeaderText = "Item Name"
        cItem_Name.DataPropertyName = "item_name"
        cItem_Name.Width = 100

        If Me.cboReportName.SelectedValue = "111" Then
            cItem_Name.Visible = True
        Else
            cItem_Name.Visible = False
        End If
        cItem_Name.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cCurrent, cOrder_id, cOrderdetil_requestid_ref, cRequestdetil_line, cCanceled, cItem_Name, cRequest_date})



        ' DgvTtttt Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Function
    Private Function AddReportList(ByRef rpts As ArrayList, ByVal id As String, ByVal name As String) As ArrayList
        objReport = New clsReportList
        objReport.report_id = id
        objReport.report_name = name
        rpts.Add(objReport)
        Return rpts
    End Function

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            'Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            'Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
            Me._ORDERTYPE_ID = Me.GetValueFromParameter(objParameters, "ORDERTYPE_ID")

        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.InitLayoutUI()
            Me.dgvToExport.DataSource = Me.tbl_requestall
            'XYZ
            'X = 
            'Y = 
            'Z = 
            Me.AddReportList(Me.reports, "000", "-- PILIH --")

            Select Case Me._ORDERTYPE_ID
                Case "RO"
                    Me.AddReportList(Me.reports, "111", " RO Detail List ")
                    Me.AddReportList(Me.reports, "112", " RO ALL List ")
                    'Me.AddReportList(Me.reports, "113", " RQ Budget Summary List ")
                    'Me.AddReportList(Me.reports, "114", " RQ Vendor Summary List ")
                    'Me.AddReportList(Me.reports, "115", " RQ Item Summary List ")
                    'Me.AddReportList(Me.reports, "116", " RQ Item Detail List ")
                Case "MO"
                    Me.AddReportList(Me.reports, "111", " MO Detail List ")
                    Me.AddReportList(Me.reports, "112", " MO ALL List ")
                    'Me.AddReportList(Me.reports, "113", " MQ Budget Summary List ")
                    'Me.AddReportList(Me.reports, "114", " MQ Vendor Summary List ")
                    'Me.AddReportList(Me.reports, "115", " MQ Item Summary List ")
                    'Me.AddReportList(Me.reports, "116", " MQ Item Detail List ")
                Case "PO"
                    Me.AddReportList(Me.reports, "111", " PO Detail List ")
                    Me.AddReportList(Me.reports, "112", " PO Detail List ")
                    'Me.AddReportList(Me.reports, "113", " PQ Budget Summary List ")
                    'Me.AddReportList(Me.reports, "114", " PQ Vendor Summary List ")
                    'Me.AddReportList(Me.reports, "115", " PQ Item Summary List ")
                    'Me.AddReportList(Me.reports, "116", " PQ Item Detail List ")
            End Select

            ' If Me._ORDERTYPE_ID = "RO" Then
            'Me.txtSearchBudget.Enabled = False
            'End If

            Me.cboReportName.DataSource = Me.reports
            Me.cboReportName.DisplayMember = "report_name"
            Me.cboReportName.ValueMember = "report_id"

            'Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            'Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            'Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        End If

    End Sub

    Private Sub uiOrderHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub
    Private Function InitLayoutUI() As Boolean
        Me.FlatTabMain.Anchor = AnchorStyles.Bottom
        Me.FlatTabMain.Anchor += AnchorStyles.Top
        Me.FlatTabMain.Anchor += AnchorStyles.Right
        Me.FlatTabMain.Anchor += AnchorStyles.Left

        Me.FlatTabMain.TabPages.Item(0).BackColor = Color.White
        Me.tbtnDel.Enabled = False
        Me.tbtnEdit.Enabled = False
        Me.tbtnFirst.Enabled = False
        Me.tbtnPrev.Enabled = False
        Me.tbtnNext.Enabled = False
        Me.tbtnLast.Enabled = False
        Me.tbtnNew.Enabled = False
        Me.tbtnQuery.Enabled = False
        Me.tbtnRefresh.Enabled = False
        Me.tbtnSave.Enabled = True
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False

      

        ' If Me._ORDERTYPE_ID = "RQ" Then
        'Me.cboSearchStruktur.Enabled = True
        'Me.chkSearchCategory.Enabled = True
        'Me.cboSearchCategory.Enabled = True
        'End If
    End Function
    Private Sub cboReportName_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReportName.RightToLeftChanged

    End Sub
    Private Sub cboReportName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged
        Me.dgvToExport.DataSource = ""
        Me.dgvToExport.Columns.Clear()

        If Me.cboReportName.SelectedValue.ToString = "111" Then
            'If Not Me.COMBO_ISFILLED Then
            '    Me.uiOrderHistory_LoadDataCombo()
            'End If
            Me.Label4.Enabled = False
            Me.chk_requestdate.Enabled = True
            Me.dtpReqDateStart.Enabled = True
            Me.dtpReqDateEnd.Enabled = True
        ElseIf Me.cboReportName.SelectedValue.ToString = "112" Then
          
            Me.Label4.Enabled = False
            Me.chk_requestdate.Enabled = False
            Me.dtpReqDateStart.Enabled = False
            Me.dtpReqDateEnd.Enabled = False

            'ElseIf Me.cboReportName.SelectedValue.ToString = "116" Then
            '    'If Not Me.COMBO_ISFILLED2 Then
            '    Me.uiOrderHistory_LoadDataCombo()
            '    'End If

            '    Me.Label4.Enabled = True

            'ElseIf Me.cboReportName.SelectedValue.ToString = "115" Then
            '    If Not Me.COMBO_ISFILLED Then
            '        Me.uiOrderHistory_LoadDataCombo()
            '    End If

            '    Me.Label4.Enabled = False
        Else
          
            Me.Label4.Enabled = False

        End If
    End Sub
    Private Function uiOrderHistory_LoadDataCombo() As Boolean
        'Me.tbl_MstChannel.Clear()
        'Me.tbl_MstRekanan.Clear()
        'Me.tbl_MstCategory.Clear()
        'Me.tbl_MstBudget.Clear()
        'Me.tbl_MstBudget.Clear()
        'Me.tbl_MstItem.Clear()
        If Me.cboReportName.SelectedValue = "111" Or Me.cboReportName.SelectedValue = "115" Then
            Try
                Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")
                'Me.ComboFill(Me.cboSearchStruktur, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")
                'Me.ComboFill(Me.cboSearchCategory, "budget_id", "budget_nameshort", Me.tbl_MstBudget, "pr_TrnBudget_Select", "")
                'Me.ComboFill(Me.cboSearchStruktur, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturUnit, "ms_MstStrukturUnit_Select", "")
                Me.COMBO_ISFILLED = True
            Catch ex As Exception
                Me.COMBO_ISFILLED = False
                MsgBox(ex.Message)
            End Try
        Else
            'Try
            '    Me.ComboFill(Me.cboSearchItem, "item_id", "item_name", Me.tbl_MstItem, "pr_MstItem_Select", "")
            '    'Me.COMBO_ISFILLED2 = True
            'Catch ex As Exception
            '    ' Me.COMBO_ISFILLED2 = False
            '    MsgBox(ex.Message)
            'End Try
        End If
    End Function
    Private Function uiOrderHistory_Retrieve() As Boolean
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""
        Dim rpt_kind As String = ""
        Dim rFilter As String = ""
        Dim OtherCriteria As String = ""
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        ' Dim dbConn As OleDb.OleDbConnection


        Me.dgvToExport.Columns.Clear()
        Me.tbl_requestall.Clear()

        txtCondition = " order_id like '" & Me._ORDERTYPE_ID & "%" & "'"

        Try

            '-- Order ID ----------------------------------------------------------------------------
            If Me.chk_order_id.Checked Then
                txtSearchCriteria = String.Format(" order_id like   '%{0}%' ", Me.txt_order_id.Text)
                If txtCondition = "" Then
                    txtCondition = txtSearchCriteria
                Else
                    txtCondition = txtCondition & "AND" & txtSearchCriteria
                End If
            End If

            '-- Request ID -------------------------------------------------------------------------
            If Me.chk_request_id.Checked Then
                txtSearchCriteria = String.Format(" orderdetil_requestid_ref = '{0}' ", Me.txt_request_id.Text)
                If txtCondition = "" Then
                    txtCondition = txtSearchCriteria
                Else
                    txtCondition = txtCondition & " AND " & txtSearchCriteria
                End If
            End If

            '-- Request Date --------------------------------------------------------------------
            Dim datestart = Me.dtpReqDateStart.Value.Year.ToString & "-" & _
                                Me.dtpReqDateStart.Value.Month.ToString & "-" & _
                                Me.dtpReqDateStart.Value.Day.ToString

            Dim dateend = Me.dtpReqDateEnd.Value.Year.ToString & "-" & _
                           Me.dtpReqDateEnd.Value.Month.ToString & "-" & _
                            Me.dtpReqDateEnd.Value.Day.ToString

            If Me.chk_requestdate.Checked Then

                If Me.cboReportName.SelectedValue = "111" Then
                    txtSearchCriteria = " request_date >= '" & datestart & "' AND request_date <= '" & dateend & "'"
                  
                End If 
                If txtCondition = "" Then
                    txtCondition = txtSearchCriteria
                Else
                    txtCondition = txtCondition & " AND " & txtSearchCriteria
                End If

            End If

            criteria = txtCondition

            'Generating view........---------------------------------------------------------------
            Me.Panel2.SuspendLayout()
            'Me.Panel2.Controls.Remove(Me.dgvToExport)
            Me.dgvToExport.Columns.Clear()
            Dim i As Integer = 0
            ' Select Case Me.cboReportName.SelectedValue
            'Me.dtpSearchDate1.Value, Me.dtpHiddenDate2.Value,
            ' Case "111"
            'If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
            Me.tbl_requestall.Clear()
            ' Me.FillTblReport(Me.tbl_requestall, "order_revisi", "orderdetil_requestid_ref='" & Me.tbl_TrnOrderdetil.Rows(i).Item("orderdetil_requestid_ref") & "' and requestdetil_line ='" & Me.tbl_TrnOrderdetil.Rows(i).Item("requestdetil_line") & "'")
            If Me.cboReportName.SelectedValue = "111" Then
                Me.FillTblReport(Me.tbl_requestall, "order_revisi", criteria)
            Else
                Me.FillTblReport(Me.tbl_requestall, "order_revisi_ALL", criteria)
                Dim j As Integer = 0
                If tbl_requestall.Rows.Count > 0 Then
                    For j = 0 To tbl_requestall.Rows.Count - 1
                        Me.tbl_requestall.Rows(j).Item("order_id") = Me.tbl_requestall.Rows(j).Item("order_id").ToString.Replace(",", " <-- ")
                    Next
                End If
            End If
            Me.tbl_requestall.Columns.Add(New DataColumn("current", GetType(System.String)))
            For i = 0 To Me.tbl_requestall.Rows.Count - 1
                If (Me.tbl_requestall.Rows(i).Item("order_id").ToString).Contains("<--") Then
                    Me.tbl_requestall.Rows(i).Item("current") = Me.tbl_requestall.Rows(i).Item("order_id").ToString.Substring(0, Me.tbl_requestall.Rows(i).Item("order_id").ToString.IndexOf("<--"))
                    Me.tbl_requestall.Rows(i).Item("order_id") = Me.tbl_requestall.Rows(i).Item("order_id").ToString.Substring(Me.tbl_requestall.Rows(i).Item("order_id").ToString.IndexOf("<--"))
                Else
                    Me.tbl_requestall.Rows(i).Item("current") = ""
                    Me.tbl_requestall.Rows(i).Item("order_id") = Me.tbl_requestall.Rows(i).Item("order_id")
                End If
            Next
            'If Me._ORDERTYPE_ID = "PQ" Then
            'Me.tbl_requestall.Columns.Remove("canceled")
            Me.FormatDgvOrderHistory(Me.dgvToExport)

            'End If
            ' End If
            'Case "112"
            '    If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
            '        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            '        dbCmd = New OleDb.OleDbCommand("cq_RptCategoryDetailRQ_list", dbConn)
            '        dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
            '        dbCmd.Parameters("@datestart").Value = datestart
            '        dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
            '        dbCmd.Parameters("@dateend").Value = dateend
            '        dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
            '        dbCmd.Parameters("@requesttype_id").Value = Me._ORDERTYPE_ID
            '        dbCmd.CommandType = CommandType.StoredProcedure
            '        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            '        Me.tbl_requestall2.Clear()
            '        dbDA.Fill(Me.tbl_requestall2)
            '        Me.dgvToExport.DataSource = tbl_requestall2
            '    End If
            'Case "113"
            '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            '    dbCmd = New OleDb.OleDbCommand("cq_RptBudgetSummaryRQ_list", dbConn)
            '    dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@datestart").Value = datestart
            '    dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@dateend").Value = dateend
            '    dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@requesttype_id").Value = Me._ORDERTYPE_ID
            '    dbCmd.CommandType = CommandType.StoredProcedure
            '    dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            '    Me.tbl_requestall3.Clear()
            '    dbDA.Fill(Me.tbl_requestall3)
            '    Me.dgvToExport.DataSource = tbl_requestall3
            'Case "114"
            '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            '    dbCmd = New OleDb.OleDbCommand("cq_RptVendorSummaryRQ_list", dbConn)
            '    dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@datestart").Value = datestart
            '    dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@dateend").Value = dateend
            '    dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@requesttype_id").Value = Me._ORDERTYPE_ID
            '    dbCmd.CommandType = CommandType.StoredProcedure
            '    dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            '    Me.tbl_requestall4.Clear()
            '    dbDA.Fill(Me.tbl_requestall4)
            '    Me.dgvToExport.DataSource = tbl_requestall4
            'Case "115"
            '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            '    dbCmd = New OleDb.OleDbCommand("cq_RptItemSummaryRQ_list", dbConn)
            '    dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@datestart").Value = datestart
            '    dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@dateend").Value = dateend
            '    dbCmd.Parameters.Add("@budget_id", Data.OleDb.OleDbType.Numeric)
            '    dbCmd.Parameters("@budget_id").Value = Me.cboSearchCategory.SelectedValue
            '    dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@requesttype_id").Value = Me._ORDERTYPE_ID
            '    dbCmd.CommandType = CommandType.StoredProcedure
            '    dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            '    Me.tbl_requestall5.Clear()
            '    dbDA.Fill(Me.tbl_requestall5)
            '    Me.dgvToExport.DataSource = tbl_requestall5
            'Case "116"
            '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            '    dbCmd = New OleDb.OleDbCommand("cq_RptItemDetailRQ_list", dbConn)
            '    dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@datestart").Value = datestart
            '    dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@dateend").Value = dateend
            '    dbCmd.Parameters.Add("@item_id", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@item_id").Value = Me.cboSearchItem.SelectedValue
            '    dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
            '    dbCmd.Parameters("@requesttype_id").Value = Me._ORDERTYPE_ID
            '    dbCmd.CommandType = CommandType.StoredProcedure
            '    dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            '    Me.tbl_requestall6.Clear()
            '    dbDA.Fill(Me.tbl_requestall6)
            '    Me.dgvToExport.DataSource = tbl_requestall6
            ' End Select


            Me.Panel2.Controls.Add(Me.dgvToExport)
            Me.Panel2.ResumeLayout()
            Me.dgvToExport.Dock = DockStyle.Fill

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiOrderHistory_Save() As Boolean
        Select Case Me.cboReportName.SelectedValue
            Case "111"
                Me.ExportToExcelViaADO(Me.tbl_requestall, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiOrderHistory_SaveToExcel(Me.tbl_requestall)
            Case "112"
                Me.ExportToExcelViaADO(Me.tbl_requestall, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiOrderHistory_SaveToExcel(Me.tbl_requestall2)
            Case "113"
                Me.ExportToExcelViaADO(Me.tbl_requestall3, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiOrderHistory_SaveToExcel(Me.tbl_requestall3)
            Case "114"
                Me.ExportToExcelViaADO(Me.tbl_requestall4, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiOrderHistory_SaveToExcel(Me.tbl_requestall4)
            Case "115"
                Me.ExportToExcelViaADO(Me.tbl_requestall5, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiOrderHistory_SaveToExcel(Me.tbl_requestall5)
            Case "116"
                Me.ExportToExcelViaADO(Me.tbl_requestall6, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiOrderHistory_SaveToExcel(Me.tbl_requestall6)
        End Select
    End Function
    'Private Function uiOrderHistory_SaveToExcel(ByVal tblname As DataTable) As Boolean
    '    Dim rowCount As Integer = tblname.Rows.Count
    '    If rowCount <= 0 Then
    '        MessageBox.Show("Cannot export empty table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Else
    '        If rowCount > 65534 Then
    '            MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Else
    '            Me.lb_export.Visible = True
    '            Me.pb_export.Visible = True

    '            Dim ColumnIndex As Integer = 0
    '            Dim RowIndex As Integer = 0

    '            'Dim xl As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
    '            'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = xl.Workbooks.Add
    '            'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(xlBook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

    '            'xl.Visible = False

    '            'Dim xl As New Microsoft.Office.Interop.Excel.Application
    '            'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
    '            'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet

    '            'Dim xl As Microsoft.Office.Interop.Excel.Application
    '            'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
    '            'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet

    '            'xl = New Excel.Application
    '            'xlBook = xl.Workbooks.Add
    '            'xlWorksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)
    '            Dim xl As Excel.Application = New Excel.Application
    '            Dim xlBook As Excel.Workbook = xl.Workbooks.Add
    '            Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

    '            xl.Visible = False
    '            xlBook = xl.Workbooks.Add
    '            xlWorksheet = xlBook.Worksheets.Add

    '            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    '            Try
    '                For Each col As System.Data.DataColumn In tblname.Columns
    '                    ColumnIndex = ColumnIndex + 1
    '                    xlWorksheet.Cells(1, ColumnIndex).Value = col.ColumnName
    '                Next

    '                For Each row As System.Data.DataRow In tblname.Rows
    '                    RowIndex = RowIndex + 1
    '                    ColumnIndex = 0

    '                    For Each col As System.Data.DataColumn In tblname.Columns
    '                        ColumnIndex = ColumnIndex + 1

    '                        Dim cMark As String = Mid(row.Item(ColumnIndex - 1).ToString, 1, 1)
    '                        If cMark = "=" Then cMark = "'" & row.Item(ColumnIndex - 1).ToString Else cMark = row.Item(ColumnIndex - 1).ToString

    '                        xlWorksheet.Cells(RowIndex + 1, ColumnIndex).Value = cMark
    '                        lb_export.Text = "Exporting " & RowIndex & " of " & rowCount & " records"
    '                        lb_export.Refresh()
    '                        pb_export.Value = CInt(100 * (RowIndex / rowCount))
    '                        pb_export.Refresh()
    '                    Next

    '                Next

    '                MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                xl.Visible = True
    '                Me.lb_export.Visible = False
    '                Me.pb_export.Visible = False
    '            Catch ex As Exception
    '                MessageBox.Show("Error" & vbCrLf & ex.Message)
    '            End Try
    '        End If
    '    End If

    '    Me.lb_export.Visible = False
    '    Me.pb_export.Visible = False
    '    Me.Cursor = System.Windows.Forms.Cursors.Arrow
    'End Function
    Private Function FillTblReport(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String) As Boolean
        tbl_name.Clear()
        tbl_name.Columns.Clear()
        Try
            Me.DataFill(tbl_name, sp_name, criteria)
            If tbl_name.Rows.Count > 0 Then
                Me.dgvToExport.DataSource = tbl_name
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
  
#Region " Export to Excel "
 
    Public Function ExportToExcelViaADO(ByVal tbl As DataTable, ByRef sd As System.Windows.Forms.SaveFileDialog, ByRef status As System.Windows.Forms.Label, ByRef pbar As System.Windows.Forms.ProgressBar) As Boolean
        Dim conOleDBConnection As New OleDb.OleDbConnection
        Dim comOleDBCommand As New OleDb.OleDbCommand
        Dim filepath As String = ""
        Dim rowcount As Integer = tbl.Rows.Count
        Dim RowIndex As Integer = 0
        Dim page As Integer = 1
        Dim currPage As Integer = 1
        Dim cookie As Byte() = Nothing

        status.Visible = True
        pbar.Visible = True
        status.Text = "Progress " & RowIndex & " of " & rowcount
        pbar.Value = 100 * (RowIndex / rowcount)
        status.Refresh()
        pbar.Refresh()

        sd.Title = "Save file"
        sd.FileName = ""
        sd.Filter = "Excel Application|*.xls"
        If sd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            filepath = sd.FileName

            If System.IO.File.Exists(filepath) = True Then
                Try
                    System.IO.File.Delete(filepath)
                Catch ex As Exception
                    MessageBox.Show("File cannot to be overwrited because being used", "Error", MessageBoxButtons.OK)
                    Return False
                End Try
            End If

            conOleDBConnection.ConnectionString = _
            "Data Source=" & filepath & ";" & _
            "Provider=Microsoft.Jet.OLEDB.4.0;" & _
            "Extended Properties=Excel 8.0;"

            comOleDBCommand.Connection = conOleDBConnection

            Try
                conOleDBConnection.Open()
                clsApplicationRole.SetAppRole(conOleDBConnection, cookie)

                Dim kolom As New ArrayList()
                Dim kolom2 As New ArrayList()
                Dim kolomType As New ArrayList()
                Dim str As String = ""
                Dim str2 As String = ""
                Dim str3 As String = ""

                Dim patt() As String = New String() {"System.", "Int32", "Int64", "Decimal", "DateTime"}
                Dim rep() As String = New String() {"", "Numeric", "Numeric", "Float", "String"}
                For Each col As System.Data.DataColumn In tbl.Columns
                    kolom.Add("[" & col.ColumnName & "] " & pregReplace(col.DataType.ToString(), patt, rep))
                    kolom2.Add("[" & col.ColumnName & "]")
                    kolomType.Add(pregReplace(col.DataType.ToString(), patt, rep))
                Next
                str = implodeArrayList(kolom, ",")
                str2 = implodeArrayList(kolom2, ",")
                str3 = implodeArrayList(prefixArrayList(kolom2, "row."), ",")

                If rowcount > 65534 Then
                    page = CType(Math.Ceiling(CType(rowcount, Double) / 65534), Integer)
                End If

                For i As Integer = 1 To page
                    Dim ct As String = "CREATE TABLE [hasil" & i & "] (" & str & ");"
                    comOleDBCommand.CommandText = ct
                    comOleDBCommand.ExecuteNonQuery()
                Next


                Dim x As String

                For Each row As System.Data.DataRow In tbl.Rows
                    Dim xa As New ArrayList()
                    RowIndex = RowIndex + 1
                    xa = fixValue(kolomType, row.ItemArray)
                    If xa IsNot Nothing Then
                        x = implodeArrayList(xa, ",")
                    Else
                        x = "'" & implodeArray(row.ItemArray(), "','", True) & "'"
                    End If

                    currPage = CType(Math.Ceiling(CType(RowIndex, Double) / 65534), Integer)
                    comOleDBCommand.CommandType = CommandType.Text
                    comOleDBCommand.CommandText = "INSERT INTO [hasil" & currPage & "$] (" & str2 & ") VALUES (" & x & ");"

                    comOleDBCommand.ExecuteNonQuery()
                    status.Text = "Progress " & RowIndex & " of " & rowcount
                    pbar.Value = 100 * (RowIndex / rowcount)
                    status.Refresh()
                    pbar.Refresh()
                Next

                clsApplicationRole.UnsetAppRole(conOleDBConnection, cookie)
                conOleDBConnection.Close()
                MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End If
        status.Visible = False
        pbar.Visible = False
        Return True
    End Function
    Public Function sqlSmartQuote(ByVal str As String) As String
        Return str.Replace("'", "''")
    End Function
    Public Function checkNull(ByVal value As Object, ByVal defaultvalue As Object) As Object
        If DBNull.Value.Equals(value) Then
            Return defaultvalue
        Else
            Return value
        End If
    End Function
    Public Function checkForExcelColumnMaxLength(ByVal val As String) As String
        If val.Length > 255 Then
            Return val.Substring(0, 255)
        Else
            Return val
        End If
    End Function
    Public Function implodeArray(ByVal AL() As Object, ByVal separator As String, Optional ByVal useSmartQuote As Boolean = False) As String
        Dim result As String = ""
        Dim temp As String = ""
        For i As Integer = 0 To AL.Length - 1
            If i > 0 Then
                result = result & separator
            End If
            If useSmartQuote = True Then
                temp = checkNull(AL(i), "")
                If (temp.Length > 255) Then
                    temp = temp.Substring(0, 255)
                End If

                result = result & Trim(CType(temp, String).Replace("'", "''"))
            Else
                temp = checkNull(AL(i), "")
                If (temp.Length > 255) Then
                    temp = temp.Substring(0, 255)
                End If
                result = result & Trim(CType(temp, String))
            End If
        Next

        Return result
    End Function

    Public Function implodeArrayList(ByVal AL As ArrayList, ByVal separator As String) As String
        Dim result As String = ""
        For i As Integer = 0 To AL.Count - 1
            If i > 0 Then
                result = result & separator
            End If
            result = result & CType(AL.Item(i), String)
        Next

        Return result
    End Function

    Public Function prefixArrayList(ByVal AL As ArrayList, ByVal prefix As String) As ArrayList
        For i As Integer = 0 To AL.Count - 1
            AL.Item(i) = prefix & AL.Item(i)
        Next

        Return AL
    End Function

    Public Function pregReplace(ByVal str As String, ByVal pattern() As String, ByVal replace() As String) As String
        If pattern.Length = replace.Length Then
            For i As Integer = 0 To pattern.Length - 1
                str = str.Replace(pattern(i), replace(i))
            Next
        End If

        Return str
    End Function

    Function fixValue(ByVal Type As ArrayList, ByVal Value As Array) As ArrayList
        Dim result As New ArrayList()
        Dim dVal As Object

        If Value.Length = Type.Count Then
            For i As Integer = 0 To Value.Length - 1
                Select Case Type.Item(i)
                    Case "Numeric"
                        dVal = checkNull(Value(i), 0)
                    Case "Float"
                        dVal = checkNull(Value(i), 0)
                    Case Else
                        dVal = "'" & sqlSmartQuote(checkForExcelColumnMaxLength(Trim(checkNull(Value(i), "")))) & "'"
                End Select

                result.Add(dVal)
            Next
            Return result
        Else
            Return Nothing
        End If
    End Function
#End Region
    Private Sub dgvToExport_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvToExport.CellFormatting
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



