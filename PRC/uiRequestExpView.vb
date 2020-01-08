

Public Class uiRequestExpView
    Private tbl_MstChannel As DataTable = clsDataset2.CreateTblMstChannel()
    Private tbl_MstItem As DataTable = clsDataset2.CreateTblMstItem()
    Private tbl_MstRekanan As DataTable = clsDataset2.CreateTblMstrekanan()
    Private tbl_MstCategory As DataTable = clsDataset2.CreateTblMstItemcategory()
    Private tbl_ShootingLocation As DataTable = clsDataset2.CreateTblShootingLocation()
    Private tbl_MstStrukturUnit As DataTable = clsDataset2.CreateTblMstStrukturUnit()
    Private tbl_MstBudget As DataTable = clsDataset2.CreateTblTrnBudget()

    Private tbl_requestall As DataTable = New DataTable 'CreateTbl_DetailList_111()
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

    Private _REQUESTTYPE_ID As String = "RR" '"RQ"

#End Region

#Region "DATASET"
    Public Shared Function CreateTbl_DetailList_111() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("shooting_date", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("program_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("days", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("curr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("total", GetType(System.decimal)))
        tbl.Columns.Add(New DataColumn("total_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_reference", GetType(System.String)))

        Return tbl
    End Function
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
        Me.uiRequestExpView_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRequestExpView_Save()
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
            Me._REQUESTTYPE_ID = Me.GetValueFromParameter(objParameters, "REQUESTTYPE_ID")

        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then

            Me.tbl_MstChannel.Clear()
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")
            Me.InitLayoutUI()

            'XYZ
            'X = 
            'Y = 
            'Z = 
            Me.AddReportList(Me.reports, "000", "-- PILIH --")

            Select Case Me._REQUESTTYPE_ID
                Case "RQ"
                    Me.AddReportList(Me.reports, "111", " RR Detail List ")
                    Me.AddReportList(Me.reports, "112", " RR Category Detail List ")
                    Me.AddReportList(Me.reports, "113", " RR Budget Summary List ")
                    Me.AddReportList(Me.reports, "114", " RR Vendor Summary List ")
                    Me.AddReportList(Me.reports, "115", " RR Item Summary List ")
                    Me.AddReportList(Me.reports, "116", " RR Item Detail List ")
                Case "MQ"
                    Me.AddReportList(Me.reports, "111", " MR Detail List ")
                    Me.AddReportList(Me.reports, "112", " MR Category Detail List ")
                    Me.AddReportList(Me.reports, "113", " MR Budget Summary List ")
                    Me.AddReportList(Me.reports, "114", " MR Vendor Summary List ")
                    Me.AddReportList(Me.reports, "115", " MR Item Summary List ")
                    Me.AddReportList(Me.reports, "116", " MR Item Detail List ")
                Case "PQ"
                    Me.AddReportList(Me.reports, "111", " PR Detail List ")
                    Me.AddReportList(Me.reports, "112", " PRCategory Detail List ")
                    Me.AddReportList(Me.reports, "113", " PR Budget Summary List ")
                    Me.AddReportList(Me.reports, "114", " PR Vendor Summary List ")
                    Me.AddReportList(Me.reports, "115", " PR Item Summary List ")
                    Me.AddReportList(Me.reports, "116", " PR Item Detail List ")
            End Select

            If Me._REQUESTTYPE_ID = "RQ" Then
                'Me.txtSearchBudget.Enabled = False
            End If

            Me.cboReportName.DataSource = Me.reports
            Me.cboReportName.DisplayMember = "report_name"
            Me.cboReportName.ValueMember = "report_id"

            Me.chkSearchChannel.Enabled = False 'Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.Enabled = False 'Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL
            Me.chkSearchChannel.Checked = True
        End If
    End Sub

    Private Sub uiRequestExpView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Me.chkSearchCategory.Enabled = False
        Me.cboSearchCategory.Enabled = False
        Me.cboSearchStruktur.Enabled = False

        ' If Me._REQUESTTYPE_ID = "RQ" Then
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
            If Not Me.COMBO_ISFILLED Then
                Me.uiRequestExpView_LoadDataCombo()
            End If
            Me.dtpSearchApoKadiv1.Enabled = True
            Me.dtpSearchApoKadiv2.Enabled = True
            Me.chkSearchAppKadiv.Enabled = True
            Me.chkSearchCategory.Enabled = True
            Me.chkSearchStruktur.Enabled = True
            Me.cboSearchItem.Enabled = False
            Me.chkSearchCategory.Checked = False
            Me.Label4.Enabled = False
        ElseIf Me.cboReportName.SelectedValue.ToString = "112" Then
            Me.dtpSearchApoKadiv1.Enabled = False
            Me.dtpSearchApoKadiv2.Enabled = False
            Me.chkSearchAppKadiv.Enabled = False
            Me.chkSearchCategory.Enabled = False
            Me.chkSearchStruktur.Enabled = False
            Me.cboSearchItem.Enabled = False
            Me.Label4.Enabled = False
            Me.chkSearchCategory.Checked = False
        ElseIf Me.cboReportName.SelectedValue.ToString = "116" Then
            'If Not Me.COMBO_ISFILLED2 Then
            Me.uiRequestExpView_LoadDataCombo()
            'End If
            Me.dtpSearchApoKadiv1.Enabled = False
            Me.dtpSearchApoKadiv2.Enabled = False
            Me.chkSearchAppKadiv.Enabled = False
            Me.chkSearchCategory.Enabled = False
            Me.chkSearchStruktur.Enabled = False
            Me.Label4.Enabled = True
            Me.cboSearchItem.Enabled = True
            Me.chkSearchCategory.Checked = False
        ElseIf Me.cboReportName.SelectedValue.ToString = "115" Then
            If Not Me.COMBO_ISFILLED Then
                Me.uiRequestExpView_LoadDataCombo()
            End If
            Me.dtpSearchApoKadiv1.Enabled = False
            Me.dtpSearchApoKadiv2.Enabled = False
            Me.chkSearchAppKadiv.Enabled = False
            Me.chkSearchCategory.Enabled = True
            Me.chkSearchCategory.Checked = True
            Me.chkSearchStruktur.Enabled = False
            Me.cboSearchItem.Enabled = False
            Me.Label4.Enabled = False
        Else
            Me.dtpSearchApoKadiv1.Enabled = False
            Me.dtpSearchApoKadiv2.Enabled = False
            Me.chkSearchAppKadiv.Enabled = False
            Me.chkSearchCategory.Enabled = False
            Me.chkSearchStruktur.Enabled = False
            Me.cboSearchItem.Enabled = False
            Me.Label4.Enabled = False
            Me.chkSearchCategory.Checked = False
        End If
    End Sub
    Private Function uiRequestExpView_LoadDataCombo() As Boolean
        'Me.tbl_MstChannel.Clear()
        'Me.tbl_MstRekanan.Clear()
        'Me.tbl_MstCategory.Clear()
        'Me.tbl_MstBudget.Clear()
        'Me.tbl_MstBudget.Clear()
        'Me.tbl_MstItem.Clear()
        If Me.cboReportName.SelectedValue = "111" Or Me.cboReportName.SelectedValue = "115" Then
            Try
                'Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")
                Me.ComboFill(Me.cboSearchStruktur, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")
                Me.ComboFill(Me.cboSearchCategory, "budget_id", "budget_nameshort", Me.tbl_MstBudget, "pr_TrnBudget_Select", "")
                Me.ComboFill(Me.cboSearchStruktur, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturUnit, "ms_MstStrukturUnit_Select", "")
                Me.COMBO_ISFILLED = True
            Catch ex As Exception
                Me.COMBO_ISFILLED = False
                MsgBox(ex.Message)
            End Try
        Else
            Try
                Me.ComboFill(Me.cboSearchItem, "item_id", "item_name", Me.tbl_MstItem, "pr_MstItem_Select", "")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Function

    Private Function DataFillWithQueryBuilder(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal QueryBuilder As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@QueryBuilder", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@QueryBuilder").Value = QueryBuilder

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


    Private Function uiRequestExpView_Retrieve() As Boolean
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""
        Dim rpt_kind As String = ""
        Dim rFilter As String = ""
        Dim OtherCriteria As String = ""
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim QueryBuilder As String = ""

        Me.dgvToExport.Columns.Clear()
        Me.tbl_requestall.Clear()

        If Me._REQUESTTYPE_ID <> "BG" And Me.cboReportName.SelectedValue = "111" Then
            txtCondition = " transaksi_requestdetil.request_id like'" & Me._REQUESTTYPE_ID & "%" & "'"
        Else
            Me._REQUESTTYPE_ID = Me._REQUESTTYPE_ID & "%"
        End If

        If Me.Label4.Enabled = True And Me.cboSearchItem.SelectedValue = 0 Then
            MsgBox(" Please select an item ")
            Exit Function
        End If

        If Me.chkSearchCategory.Checked = True And Me.cboSearchCategory.SelectedValue = 0 Then
            MsgBox(" Please select an budget ")
            Exit Function
        End If

        Try
            '-- Vendor ----------------------------------------------------------------------------
            If Me.chkSearchStruktur.Checked Then
                txtSearchCriteria = String.Format(" transaksi_requestdetil.strukturunit_id = '{0}' ", Me.cboSearchStruktur.SelectedValue)
                If txtCondition = "" Then
                    txtCondition = txtSearchCriteria
                Else
                    txtCondition = txtCondition & "AND" & txtSearchCriteria
                End If
            End If

            '-- Category -------------------------------------------------------------------------
            If Me.chkSearchCategory.Checked Then
                txtSearchCriteria = String.Format(" transaksi_requestdetil.budget_id = '{0}' ", Me.cboSearchCategory.SelectedValue)
                If txtCondition = "" Then
                    txtCondition = txtSearchCriteria
                Else
                    txtCondition = txtCondition & " AND " & txtSearchCriteria
                End If
            End If

            '-- Shooting Date --------------------------------------------------------------------
            Dim datestart = Me.dtpSearchDate1.Value.Year.ToString & "-" & _
                                Me.dtpSearchDate1.Value.Month.ToString & "-" & _
                                Me.dtpSearchDate1.Value.Day.ToString

            Dim dateend = Me.dtpSearchDate2.Value.Year.ToString & "-" & _
                           Me.dtpSearchDate2.Value.Month.ToString & "-" & _
                            Me.dtpSearchDate2.Value.Day.ToString
            '-- Shoot Date ------------------------------------------------------------------------
            If Me.cbodate_shoot.Checked Then
                If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                    If Me.cboReportName.SelectedValue = "111" Then
                        txtSearchCriteria = " request_useddt >= '" & datestart & "' AND request_useddt <= '" & dateend & "'"
                    End If

                    If txtCondition = "" Then
                        txtCondition = txtSearchCriteria
                    Else
                        txtCondition = txtCondition & " AND " & txtSearchCriteria
                    End If
                End If
            End If
            '-- Approval Kadiv Date ------------------------------------------------------------------
            If Me.chkSearchAppKadiv.Checked Then
                Dim datestart1 = Me.dtpSearchApoKadiv1.Value.Year.ToString & "-" & _
                                              Me.dtpSearchApoKadiv1.Value.Month.ToString & "-" & _
                                              Me.dtpSearchApoKadiv1.Value.Day.ToString

                Dim dateend2 = Me.dtpSearchApoKadiv2.Value.Year.ToString & "-" & _
                               Me.dtpSearchApoKadiv2.Value.Month.ToString & "-" & _
                                Me.dtpSearchApoKadiv2.Value.Day.ToString
                txtSearchCriteria = " request_approved2= 1 and request_approved2dt >= '" & datestart1 & "' AND request_approved2dt <= '" & dateend2 & "'order by program_name asc"

                If txtCondition = "" Then
                    txtCondition = txtSearchCriteria
                Else
                    txtCondition = txtCondition & " AND " & txtSearchCriteria
                End If
            End If
            criteria = txtCondition

            'Generating view........---------------------------------------------------------------
            Me.Panel2.SuspendLayout()
            Me.Panel2.Controls.Remove(Me.dgvToExport)
            Me.dgvToExport.Columns.Clear()

            Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
            Dim cookie As Byte() = Nothing

            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            Try
                Select Case Me.cboReportName.SelectedValue
                    Case "111"
                        Me.tbl_requestall.Clear()
                        Me.FillTblReport(Me.tbl_requestall, "cq_RptRequestDetil_Select", criteria)
                        'Me.FillTblReportQueryBuilder(Me.tbl_requestall, "cq_RptRequestDetil_SelectNew", criteria, QueryBuilder)
                        If Me._REQUESTTYPE_ID = "PQ" Then
                            Me.tbl_requestall.Columns.Remove("days")
                        End If
                    Case "112"
                        If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                            dbCmd = New OleDb.OleDbCommand("cq_RptCategoryDetailRQ_list", dbConn)
                            dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
                            dbCmd.Parameters("@datestart").Value = datestart
                            dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
                            dbCmd.Parameters("@dateend").Value = dateend
                            dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
                            dbCmd.Parameters("@requesttype_id").Value = Me._REQUESTTYPE_ID
                            dbCmd.CommandType = CommandType.StoredProcedure
                            dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                            Me.tbl_requestall2.Clear()
                            dbDA.Fill(Me.tbl_requestall2)
                            Me.dgvToExport.DataSource = tbl_requestall2
                        End If
                    Case "113"
                        dbCmd = New OleDb.OleDbCommand("cq_RptBudgetSummaryRQ_list", dbConn)
                        dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@datestart").Value = datestart
                        dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@dateend").Value = dateend
                        dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@requesttype_id").Value = Me._REQUESTTYPE_ID
                        dbCmd.CommandType = CommandType.StoredProcedure
                        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                        Me.tbl_requestall3.Clear()
                        dbDA.Fill(Me.tbl_requestall3)
                        Me.dgvToExport.DataSource = tbl_requestall3
                    Case "114"
                        dbCmd = New OleDb.OleDbCommand("cq_RptVendorSummaryRQ_list", dbConn)
                        dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@datestart").Value = datestart
                        dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@dateend").Value = dateend
                        dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@requesttype_id").Value = Me._REQUESTTYPE_ID
                        dbCmd.CommandType = CommandType.StoredProcedure
                        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                        Me.tbl_requestall4.Clear()
                        dbDA.Fill(Me.tbl_requestall4)
                        Me.dgvToExport.DataSource = tbl_requestall4
                    Case "115"
                        dbCmd = New OleDb.OleDbCommand("cq_RptItemSummaryRQ_list", dbConn)
                        dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@datestart").Value = datestart
                        dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@dateend").Value = dateend
                        dbCmd.Parameters.Add("@budget_id", Data.OleDb.OleDbType.Numeric)
                        dbCmd.Parameters("@budget_id").Value = Me.cboSearchCategory.SelectedValue
                        dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@requesttype_id").Value = Me._REQUESTTYPE_ID
                        dbCmd.CommandType = CommandType.StoredProcedure
                        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                        Me.tbl_requestall5.Clear()
                        dbDA.Fill(Me.tbl_requestall5)
                        Me.dgvToExport.DataSource = tbl_requestall5
                    Case "116"
                        dbCmd = New OleDb.OleDbCommand("cq_RptItemDetailRQ_list", dbConn)
                        dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@datestart").Value = datestart
                        dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@dateend").Value = dateend
                        dbCmd.Parameters.Add("@item_id", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@item_id").Value = Me.cboSearchItem.SelectedValue
                        dbCmd.Parameters.Add("@requesttype_id", Data.OleDb.OleDbType.VarChar)
                        dbCmd.Parameters("@requesttype_id").Value = Me._REQUESTTYPE_ID
                        dbCmd.CommandType = CommandType.StoredProcedure
                        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                        Me.tbl_requestall6.Clear()
                        dbDA.Fill(Me.tbl_requestall6)
                        Me.dgvToExport.DataSource = tbl_requestall6
                End Select
            Catch ex As Exception
                Throw ex
            Finally
                If dbConn.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End If
            End Try

            Me.Panel2.Controls.Add(Me.dgvToExport)
            Me.Panel2.ResumeLayout()
            Me.dgvToExport.Dock = DockStyle.Fill

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiRequestExpView_Save() As Boolean
        Select Case Me.cboReportName.SelectedValue
            Case "111"
                Me.ExportToExcelViaADO(Me.tbl_requestall, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiRequestExpView_SaveToExcel(Me.tbl_requestall)
            Case "112"
                Me.ExportToExcelViaADO(Me.tbl_requestall2, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiRequestExpView_SaveToExcel(Me.tbl_requestall2)
            Case "113"
                Me.ExportToExcelViaADO(Me.tbl_requestall3, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiRequestExpView_SaveToExcel(Me.tbl_requestall3)
            Case "114"
                Me.ExportToExcelViaADO(Me.tbl_requestall4, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiRequestExpView_SaveToExcel(Me.tbl_requestall4)
            Case "115"
                Me.ExportToExcelViaADO(Me.tbl_requestall5, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiRequestExpView_SaveToExcel(Me.tbl_requestall5)
            Case "116"
                Me.ExportToExcelViaADO(Me.tbl_requestall6, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
                'uiRequestExpView_SaveToExcel(Me.tbl_requestall6)
        End Select
    End Function
    Private Function uiRequestExpView_SaveToExcel(ByVal tblname As DataTable) As Boolean
        Dim rowCount As Integer = tblname.Rows.Count
        If rowCount <= 0 Then
            MessageBox.Show("Cannot export empty table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If rowCount > 65534 Then
                MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Me.lb_export.Visible = True
                Me.pb_export.Visible = True

                Dim ColumnIndex As Integer = 0
                Dim RowIndex As Integer = 0

                'Dim xl As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = xl.Workbooks.Add
                'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(xlBook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                'xl.Visible = False

                'Dim xl As New Microsoft.Office.Interop.Excel.Application
                'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
                'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet

                'Dim xl As Microsoft.Office.Interop.Excel.Application
                'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
                'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet

                'xl = New Excel.Application
                'xlBook = xl.Workbooks.Add
                'xlWorksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)
                Dim xl As Excel.Application = New Excel.Application
                Dim xlBook As Excel.Workbook = xl.Workbooks.Add
                Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

                xl.Visible = False
                xlBook = xl.Workbooks.Add
                xlWorksheet = xlBook.Worksheets.Add

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Try
                    For Each col As System.Data.DataColumn In tblname.Columns
                        ColumnIndex = ColumnIndex + 1
                        xlWorksheet.Cells(1, ColumnIndex).Value = col.ColumnName
                    Next

                    For Each row As System.Data.DataRow In tblname.Rows
                        RowIndex = RowIndex + 1
                        ColumnIndex = 0

                        For Each col As System.Data.DataColumn In tblname.Columns
                            ColumnIndex = ColumnIndex + 1

                            Dim cMark As String = Mid(row.Item(ColumnIndex - 1).ToString, 1, 1)
                            If cMark = "=" Then cMark = "'" & row.Item(ColumnIndex - 1).ToString Else cMark = row.Item(ColumnIndex - 1).ToString

                            xlWorksheet.Cells(RowIndex + 1, ColumnIndex).Value = cMark
                            lb_export.Text = "Exporting " & RowIndex & " of " & rowCount & " records"
                            lb_export.Refresh()
                            pb_export.Value = CInt(100 * (RowIndex / rowCount))
                            pb_export.Refresh()
                        Next

                    Next

                    MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    xl.Visible = True
                    Me.lb_export.Visible = False
                    Me.pb_export.Visible = False
                Catch ex As Exception
                    MessageBox.Show("Error" & vbCrLf & ex.Message)
                End Try
            End If
        End If

        Me.lb_export.Visible = False
        Me.pb_export.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Function
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

    Private Function FillTblReportQueryBuilder(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String, ByVal QueryBuilder As String) As Boolean
        tbl_name.Clear()
        tbl_name.Columns.Clear()
        Try
            Me.DataFillWithQueryBuilder(tbl_name, sp_name, criteria, QueryBuilder)
            If tbl_name.Rows.Count > 0 Then
                Me.dgvToExport.DataSource = tbl_name
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub chkSearchCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchCategory.CheckedChanged
        If Me.chkSearchCategory.Checked = True Then
            Me.cboSearchCategory.Enabled = True
        Else
            Me.cboSearchCategory.Enabled = False
        End If
    End Sub

    Private Sub chkSearchRekanan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchStruktur.CheckedChanged
        If Me.chkSearchStruktur.Checked = True Then
            Me.cboSearchStruktur.Enabled = True
        Else
            Me.cboSearchStruktur.Enabled = False
        End If
    End Sub
    Private Sub chkSearchAppKadiv_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSearchAppKadiv.CheckedChanged
        If Me.chkSearchAppKadiv.Checked = True Then
            Me.dtpSearchApoKadiv1.Enabled = True
            Me.dtpSearchApoKadiv2.Enabled = True
        Else
            Me.dtpSearchApoKadiv1.Enabled = False
            Me.dtpSearchApoKadiv2.Enabled = False
        End If
    End Sub
    Private Sub cboReportName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedValueChanged
        If Mid(Me.cboReportName.SelectedValue.ToString, 3, 1) = "1" Then
            'Me.dtpSearchApoKadiv1.Enabled = True
            'Me.dtpSearchApoKadiv2.Enabled = True
            Me.chkSearchAppKadiv.Enabled = True
            Me.chkSearchCategory.Enabled = True
            Me.chkSearchStruktur.Enabled = True
            Me.cboSearchCategory.Enabled = False
            Me.cboSearchStruktur.Enabled = False
        Else
            Me.dtpSearchApoKadiv1.Enabled = False
            Me.dtpSearchApoKadiv2.Enabled = False
            Me.chkSearchAppKadiv.Enabled = False
            Me.chkSearchCategory.Enabled = False
            Me.chkSearchStruktur.Enabled = False
            Me.cboSearchCategory.Enabled = False
            Me.cboSearchStruktur.Enabled = False
        End If
    End Sub


    Private Sub cbodate_shoot_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbodate_shoot.CheckedChanged
        If Me.cbodate_shoot.Checked = True Then
            Me.dtpSearchDate1.Enabled = True
            Me.dtpSearchDate2.Enabled = True
        Else
            Me.dtpSearchDate1.Enabled = False
            Me.dtpSearchDate2.Enabled = False
        End If
    End Sub
#Region " Export to Excel "
    'Private Sub ui_SaveToExcel()
    '    If Me.tbl_export_toexcel.Rows.Count > 0 Then
    '        Me.ExportToExcelViaADO(Me.tbl_export_toexcel, Me.SaveFileDialog1, Me.lb_export, Me.pb_export)
    '    End If
    'End Sub
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

                MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                If conOleDBConnection.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(conOleDBConnection, cookie)
                    conOleDBConnection.Close()
                End If
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

    Private Sub lbl_querybuilder_Click(sender As Object, e As EventArgs) Handles lbl_querybuilder.Click
        If Me.cboReportName.SelectedValue = "000" Then
            MsgBox("Please select report first !", MsgBoxStyle.Exclamation, "Information")
            Exit Sub
        End If

        Dim dlg As dlgQueryBuilderNew = New dlgQueryBuilderNew
        Dim retString As String
        dlg.ShowInTaskbar = False
        dlg.StartPosition = FormStartPosition.CenterParent
        Select Case Me.cboReportName.SelectedValue
            Case "111"
                dlg.Init(Me.txtSearchAdv.Text, Me.tbl_requestall)
            Case "112"
                dlg.Init(Me.txtSearchAdv.Text, Me.tbl_requestall2)
            Case "113"
                dlg.Init(Me.txtSearchAdv.Text, Me.tbl_requestall3)
            Case "114"
                dlg.Init(Me.txtSearchAdv.Text, Me.tbl_requestall4)
            Case "115"
                dlg.Init(Me.txtSearchAdv.Text, Me.tbl_requestall5)
            Case "116"
                dlg.Init(Me.txtSearchAdv.Text, Me.tbl_requestall6)
        End Select

        retString = dlg.OpenDialog(Me)
        Me.txtSearchAdv.Text = retString
    End Sub
End Class



