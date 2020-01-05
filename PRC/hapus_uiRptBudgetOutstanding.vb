Public Class hapus_uiRptBudgetOutstanding
    Private tbl_MstBudget As DataTable = clsDataset.CreateTblTrnBudget()
    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstItem As DataTable = clsDataset.CreateTblMstItem()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstBudgetDetil As DataTable = clsDataset.CreateTblTrnBudgetdetil()
    Private sptChannelName As String
    Private sptChannelID As String
    Private sptChannelAddress As String
    Private sptDomainName As String


    Public Sub Form_Load(ByVal sender As Object)
        Me.tbl_MstBudget.Clear()
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            'Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            'Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
            'Me._ORDERTYPE_ID = Me.GetValueFromParameter(objParameters, "ORDERTYPE_ID")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then

        End If

    End Sub


    Private Sub uiRptBudgetOutstanding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

#Region " Window Parameter "
    Private _CHANNEL As String = clsConfig.globDefaultChannel
    Private _CHANNEL_CANBE_CHANGED As Boolean = True
    Private _CHANNEL_CANBE_BROWSED As Boolean = True

    Private _ORDERTYPE_ID As String = "RO"

    Private _RPT_CYCLE As String = "DAILY"    '[DAILY, MONTHLY, YEARLY]
    Private _RPT_TYPE As String = "SUMM"        '[LIST, SUMM]

#End Region

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRptBudgetOutstanding_retrieve()
        Me.Cursor = Cursors.Arrow
        Me.tbtnPrev.Enabled = False
        Me.tbtnFirst.Enabled = False
        Return MyBase.btnLoad_Click()
    End Function
    Private Sub uiRptBudgetOutstanding_retrieve()
        If rdbudgetid.Checked = False And rdbudgetname.Checked = False Then
            MsgBox("You Must Select Budget Criteria")
            Return
        End If
        Dim tbl_Print As DataTable = clsDataset.CreateTblRptBudgetOutstanding
        Dim budget_id As String
        Dim rptDataSourceName As String
        Dim rptProcedureName As String

        Dim rptRdlcName As String = String.Empty
        Dim dbCmd As OleDb.OleDbCommand = New OleDb.OleDbCommand()
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim datalist As ArrayList = New ArrayList
        Dim obj As DataSource.clsRptBudgetOutstanding

        budget_id = Me.obj_budget.SelectedValue
        budget_id = String.Format(" budget_id= '{0}' ", budget_id)
        rptDataSourceName = "PRC_DataSource_clsRptBudgetOutstanding"
        rptProcedureName = "pr_Rpt_Budget_vs_Request_vs_Order"
        rptRdlcName = "PRC.RptBudgetOutstanding.rdlc"
        dbCmd = Me.GenerateReportDbCommand(rptProcedureName, budget_id)
        dbCmd.Connection = dbConn


        Dim DA As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter(dbCmd)
        Dim tbl As System.Data.DataTable = New System.Data.DataTable
        Dim dv As DataView
        Dim i As Integer
        'Dim filter As String = ""         

        Try
            dbConn.Open()
            'Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
            'Me.DataFill(tbl_Print, "pr_Rpt_Budget_vs_Request_vs_Order", budget_id)
            'dr = dbCmd.ExecuteReader()

            DA.Fill(tbl)

            If tbl.Rows.Count <= 0 Then
                MsgBox("No Data")
                Exit Sub
            End If

            dv = tbl.DefaultView
            If dv.Count <= 0 Then
                MsgBox("No data")
                Exit Sub
            End If

            For i = 0 To dv.Count - 1
                'While dr.Read()
                obj = New DataSource.clsRptBudgetOutstanding(Me.DSN)
                With obj
                    .transaction_id = clsUtil.IsDbNull(dv.Item(i).Item("transaction_id").ToString, "")
                    .budget_id = clsUtil.IsDbNull(dv.Item(i).Item("budget_id").ToString, "")
                    .budgetdetil_id = clsUtil.IsDbNull(dv.Item(i).Item("budgetdetil_id").ToString, "")
                    .budgetdetil_name = clsUtil.IsDbNull(dv.Item(i).Item("budgetdetil_name").ToString, "")
                    .budget_amount = clsUtil.IsDbNull(dv.Item(i).Item("budget_amount").ToString, "")
                    .item_id = clsUtil.IsEmptyText(dv.Item(i).Item("item_id").ToString, " ")
                    .item_name = clsUtil.IsDbNull(dv.Item(i).Item("item_name").ToString, "")
                    .qty = clsUtil.IsDbNull(dv.Item(i).Item("qty").ToString, "")
                    .amount = clsUtil.IsDbNull(dv.Item(i).Item("amount").ToString, "")
                    .rate = clsUtil.IsDbNull(dv.Item(i).Item("rate").ToString, "")
                    .currency = clsUtil.IsDbNull(dv.Item(i).Item("currency").ToString, "")
                    .budgetdetil_amount = clsUtil.IsDbNull(dv.Item(i).Item("budgetdetil_amount").ToString, "")
                    .subtotal_amount = clsUtil.IsDbNull(dv.Item(i).Item("subtotal_amount").ToString, "")
                    .type = clsUtil.IsDbNull(dv.Item(i).Item("type").ToString, "")
                    .budget_name = clsUtil.GetDataFromDatatable(Me.tbl_MstBudget, "budget_id", "budget_name", dv.Item(i).Item("budget_id"))
                    .channel_id = Me._CHANNEL

                    Me.sptChannelName = .channelname
                    Me.sptChannelID = .channel_id
                    Me.sptChannelAddress = .channeladdr
                    Me.sptDomainName = .domain_name


                End With
                datalist.Add(obj)
            Next


            'End While
            'dr.Close()

            Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
            Dim parRptChannelName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("ChannelName", Me.sptChannelName)
            Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("ChannelID", Me.sptChannelID)
            Dim parRptChannelAddress As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("ChannelAddress", Me.sptChannelAddress)
            Dim parRptDomainName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomainName)

            objRdsH.Name = rptDataSourceName
            objRdsH.Value = datalist
            objReportH.ReportEmbeddedResource = rptRdlcName
            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True
            'objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptChannelName, parRptChannelID, parRptChannelAddress, parRptDomainName})

            objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
            'objReportViewer.LocalReport.SetParameters(New ReportParameter() {ReportTitle})
            objReportViewer.Name = "ReportViewer1"
            objReportViewer.LocalReport.EnableExternalImages = True
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptChannelName, parRptChannelID, parRptChannelAddress, parRptDomainName})
            objReportViewer.LocalReport.DataSources.Clear()
            objReportViewer.LocalReport.DataSources.Add(objRdsH)
            objReportViewer.RefreshReport()

            Me.Panel1.SuspendLayout()
            Me.Panel1.Controls.Remove(Me.ReportViewer1)
            Me.ReportViewer1 = Nothing
            Me.ReportViewer1 = objReportViewer
            Me.ReportViewer1.LocalReport.EnableExternalImages = True
            Me.Panel1.Controls.Add(Me.ReportViewer1)
            Me.ReportViewer1.Dock = DockStyle.Fill
            Me.Panel1.ResumeLayout()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub
    Private Function GenerateReportDbCommand(ByVal rptProcedureName As String, ByVal budget_id As String) As OleDb.OleDbCommand
        Dim dbCmd As OleDb.OleDbCommand
        dbCmd = New OleDb.OleDbCommand(rptProcedureName)
        dbCmd.Parameters.Add("@criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@criteria").Value = budget_id
        dbCmd.CommandType = CommandType.StoredProcedure
        Return dbCmd
    End Function
    Private Sub rdbudgetid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbudgetid.CheckedChanged
        Me.DataFill(Me.tbl_MstBudget, "bg_TrnBudget_Select", "")
        Me.tbl_MstBudget.DefaultView.Sort = "budget_id"
        If rdbudgetid.Checked = True Then

            Me.obj_budget.Width = 70
            Me.ComboLink(Me.obj_budget, "budget_id", "budget_id", Me.tbl_MstBudget, True)
        End If
    End Sub
    Private Sub rdbudgetname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbudgetname.CheckedChanged
        Me.DataFill(Me.tbl_MstBudget, "bg_TrnBudget_Select", "")
        Me.tbl_MstBudget.DefaultView.Sort = "budget_name"
        If rdbudgetname.Checked = True Then
            Me.obj_budget.Width = 340
            Me.ComboLink(Me.obj_budget, "budget_id", "budget_name", Me.tbl_MstBudget, True)
        End If
    End Sub
End Class
