Public Class uiROReportViewer
    Private tbl_RptOrderSummary As DataTable = clsDataset.CreateTblRptOrder_SummaryFull()
    Private tbl_RptOrderDetilSummary As DataTable = clsDataset.CreateTblRptOrderDetil_SummaryFull()

    Private tbl_OrderPaymReq_AP As DataTable = clsDataset.CreateTblRptOrderpaymreq_ap

    Private objRptROSummary As DataSource.clsRptOrder
    Private objRptRODetilSummary As DataSource.clsRptOrderSummary
    Private objRptROAccrual As DataSource.clsRptOrder_PA_AP
    Private objDatalistTransaksiDetil As ArrayList

    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekanan()
    Private tbl_MstCategory As DataTable = clsDataset.CreateTblMstItemcategory()
    Private tbl_ShootingLocation As DataTable = clsDataset.CreateTblShootingLocation()

    Private order_subtotalDetil As Double
    Dim ReportTitle, ReportSubTitle, ReportSubTitle2 As Microsoft.Reporting.WinForms.ReportParameter

    Private COMBO_ISFILLED As Boolean = False
    Private FILTER_QUERY_MODE As Boolean

    'Private sptChannelName As String
    'Private sptChannelID As String
    'Private sptChannelAddress As String
    'Private sptDomainName As String


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

    Private _RPT_CYCLE As String = "DAILY"    '[DAILY, MONTHLY, YEARLY]
    Private _RPT_TYPE As String = "SUMM"        '[LIST, SUMM]

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
        Me.uiROReportViewer_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

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
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")

            Me._RPT_CYCLE = Me.GetValueFromParameter(objParameters, "RPT_CYCLE")
            Me._RPT_TYPE = Me.GetValueFromParameter(objParameters, "RPT_TYPE")
            Me._ORDERTYPE_ID = Me.GetValueFromParameter(objParameters, "ORDERTYPE_ID")

        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.InitLayoutUI()

            'XYZ
            'X = 1,1,1   = {Harian, Bulanan, Tahunan}
            'Y = 1,2,3,4 = {List, Summary, ItemSummary, Summary By Category}
            'Z = 1,2,3,9 = {All, ByBudget, ByVendor, Line }
            Me.AddReportList(Me.reports, "000", "-- PILIH --")

            Select Case Me._RPT_TYPE
                Case "LIST"
                    'Me.AddReportList(Me.reports, "134", "Order List") '--> special case
                    If Me._ORDERTYPE_ID = "PO" Or Me._ORDERTYPE_ID = "MO" Then
                        Me.AddReportList(Me.reports, "134", "Order Detil List")
                    End If
                    Me.AddReportList(Me.reports, "112", "Order List by Budget per Vendor")
                    Me.AddReportList(Me.reports, "113", "Order List by Vendor per Budget")
                    Me.AddReportList(Me.reports, "119", "---------------------------------------------------------")

                Case "SUMM"
                    'Me.AddReportList(Me.reports, "121", "Order Summary All")
                    Me.AddReportList(Me.reports, "122", "Order Summary by Budget per Vendor")
                    Me.AddReportList(Me.reports, "123", "Order Summary by Vendor per Budget")
                    Me.AddReportList(Me.reports, "129", "---------------------------------------------------------")

                    Me.AddReportList(Me.reports, "131", "Order Item Summary By Category")
                    Me.AddReportList(Me.reports, "132", "Order Item Summary By Vendor")
                    Me.AddReportList(Me.reports, "133", "Order Item Summary By Budget")
                    'Me.AddReportList(Me.reports, "134", "Order List") '--> special case
                    Me.AddReportList(Me.reports, "139", "---------------------------------------------------------")

                    Me.AddReportList(Me.reports, "141", "Order Summary By Category")
                    Me.AddReportList(Me.reports, "142", "Order Summary By Category per Vendor")
                    Me.AddReportList(Me.reports, "143", "Order Summary By Category per Budget")
                    Me.AddReportList(Me.reports, "149", "---------------------------------------------------------")

                    Me.AddReportList(Me.reports, "151", "Order List vs AP By Vendor per Budget")
                    Me.AddReportList(Me.reports, "152", "Order Summary vs AP By Vendor per Budget")
                    'Me.AddReportList(Me.reports, "152", "Order Accrual Summary per Budget")

            End Select

            Select Case Me._RPT_CYCLE
                Case "DAILY"
                    If Me._RPT_TYPE = "LIST" Then Me.lblReportType.Text = "Daily Report List (" & Me._ORDERTYPE_ID & ")"
                    If Me._RPT_TYPE = "SUMM" Then Me.lblReportType.Text = "Daily Report Summary (" & Me._ORDERTYPE_ID & ")"
                    If Me._ORDERTYPE_ID = "RO" Then
                        Me.lblSearchDate1.Text = "'Shooting Start' From"
                    Else
                        Me.lblSearchDate1.Text = "'Order Date' From"
                    End If
                    Me.lblSearchDate1.Visible = True
                    Me.lblSearchDate2.Visible = True
                    Me.dtpSearchDate1.Visible = True
                    Me.dtpSearchDate2.Visible = True
                    Me.txtSearchPeriode.Visible = False
                    Me.txtSearchPeriode.Text = ""
                    Me.txtSearchYear.Text = ""

                Case "MONTHLY"
                    If Me._RPT_TYPE = "LIST" Then Me.lblReportType.Text = "Monthly Report List (" & Me._ORDERTYPE_ID & ")"
                    If Me._RPT_TYPE = "SUMM" Then Me.lblReportType.Text = "Monthly Report Summary (" & Me._ORDERTYPE_ID & ")"

                    Me.lblSearchDate1.Text = "Periode [YYMM]"

                    'Me.lblSearchDate1.Visible = False
                    Me.lblSearchDate2.Visible = False
                    Me.dtpSearchDate1.Visible = False
                    Me.dtpSearchDate2.Visible = False
                    Me.txtSearchPeriode.Visible = True
                    Me.txtSearchYear.Visible = False
                    Me.txtSearchYear.Text = ""

                Case "YEARLY"
                    If Me._RPT_TYPE = "LIST" Then Me.lblReportType.Text = "Yearly Report List (" & Me._ORDERTYPE_ID & ")"
                    If Me._RPT_TYPE = "SUMM" Then Me.lblReportType.Text = "Yearly Report Summary (" & Me._ORDERTYPE_ID & ")"

                    Me.lblSearchDate1.Text = "Year"

                    Me.lblSearchDate1.Visible = True
                    Me.lblSearchDate2.Visible = False
                    Me.dtpSearchDate1.Visible = False
                    Me.dtpSearchDate2.Visible = False
                    Me.txtSearchPeriode.Visible = False
                    Me.txtSearchYear.Visible = True
                    Me.txtSearchPeriode.Text = ""

            End Select

            Me.cboReportName.DataSource = Me.reports
            Me.cboReportName.DisplayMember = "report_name"
            Me.cboReportName.ValueMember = "report_id"

            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        End If

    End Sub

    Private Sub uiROReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.tbtnQuery.Enabled = True
        Me.tbtnRefresh.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False

        Me.chkSearchCategory.Enabled = False
        Me.cboSearchCategory.Enabled = False

        Me.lblSearchDate1.Visible = False
        Me.lblSearchDate2.Visible = False
        Me.dtpSearchDate1.Visible = False
        Me.dtpSearchDate2.Visible = False
        Me.txtSearchPeriode.Visible = False
        Me.txtSearchYear.Visible = False

        If Me._ORDERTYPE_ID = "RO" Then
            Me.chkSearchLocation.Enabled = True
            Me.lboSearchLocation.Enabled = True
        Else
            Me.chkSearchLocation.Enabled = False
            Me.lboSearchLocation.Enabled = False
        End If

    End Function
    Private Sub cboReportName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged
        'Category is required only for DetilSummary report

        Me.chkSearchCategory.Enabled = False
        Me.cboSearchCategory.Enabled = False
        Me.dtpSearchAccrDate.Enabled = False

        If Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "1" _
          Or Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "2" _
          Or Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "3" _
          Or Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "4" _
          Or Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "5" Then
            If Not Me.COMBO_ISFILLED Then
                Me.uiROReportViewer_LoadDataCombo()
            End If
        End If

        If Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "3" _
          Or Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "4" Then
            Me.chkSearchCategory.Enabled = True
            Me.cboSearchCategory.Enabled = True
        End If

        If Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "5" Then
            Me.dtpSearchAccrDate.Enabled = True
        End If


    End Sub

    Private Function uiROReportViewer_LoadDataCombo() As Boolean
        Me.tbl_MstChannel.Clear()
        Me.tbl_MstRekanan.Clear()
        Me.tbl_MstCategory.Clear()

        Try
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")
            Me.ComboFill(Me.cboSearchRekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")
            Me.ComboFill(Me.cboSearchCategory, "category_id", "category_name", Me.tbl_MstCategory, "pr_MstItemcategory_Select", "")
            Me.ListBoxFill(Me.lboSearchLocation, "order_utilizedlocation", Me.tbl_ShootingLocation, "pr_ShootingLocation", "")

            Me.tbl_MstCategory.DefaultView.Sort = "category_name"
            Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"
            Me.tbl_ShootingLocation.DefaultView.Sort = "order_utilizedlocation"

            Me.COMBO_ISFILLED = True
        Catch ex As Exception
            Me.COMBO_ISFILLED = False
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function uiROReportViewer_Retrieve() As Boolean
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""
        Dim rptname_rdlc As String = ""
        Dim rpt_kind As String = ""
        Dim tbl_RptPeriode As DataTable = clsDataset.CreateTblMstPeriode
        Dim AsOf As String = ""
        Dim rFilter As String = ""
        Dim accrudate As String = ""

        Dim tempstat As Boolean = True

        txtCondition = " ordertype_id='" & Me._ORDERTYPE_ID & _
                            "' and channel_id='" & Me._CHANNEL & _
                            "' and order_canceled = 0"

        Try
            '-- Budget
            If Me.chkSearchBudget.Checked Then
                txtSearchCriteria = String.Format(" budget_id = '{0}' ", Me.txtSearchBudget.Text)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Vendor
            If Me.chkSearchRekanan.Checked Then
                txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.cboSearchRekanan.SelectedValue)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Shooting Location
            If Me.chkSearchLocation.Checked Then
                Dim i As Integer
                Dim loc As String = ""
                Dim txtSearchLoc As String = ""

                If Me.chkSearchLocation.Checked Then
                    'User choose only one location
                    If Me.lboSearchLocation.Items.Count = 1 Then
                        txtSearchCriteria = String.Format(" order_utilizedlocation = '{0}' ", Me.lboSearchLocation.SelectedValue)

                    Else
                        'User choose more than one locations
                        For i = 0 To Me.lboSearchLocation.Items.Count - 1
                            If Me.lboSearchLocation.GetSelected(i) Then
                                loc = Me.tbl_ShootingLocation.Rows(i)("order_utilizedlocation").ToString
                                If i < (Me.lboSearchLocation.Items.Count - 1) Then
                                    txtSearchLoc = txtSearchLoc & "', '" & loc
                                End If
                            End If
                        Next

                        txtSearchLoc = Mid(txtSearchLoc, 4, Len(txtSearchLoc)) & "'"
                        rFilter = "Location: " & txtSearchLoc
                        txtSearchCriteria = " order_utilizedlocation IN (" & txtSearchLoc & ")"
                    End If

                End If

                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If

            End If


            '-- Category
            If Me.chkSearchCategory.Checked Then
                txtSearchCriteria = String.Format(" category_id = '{0}' ", Me.cboSearchCategory.SelectedValue)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Periode
            If Me.txtSearchPeriode.Text <> "" Then
                tbl_RptPeriode.Clear()
                Try
                    Me.DataFill(tbl_RptPeriode, "pr_MstPeriode_Select", "periode_id='" & Me.txtSearchPeriode.Text & "'")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                If tbl_RptPeriode.Rows.Count > 0 Then
                    AsOf = "Periode: " & tbl_RptPeriode.Rows(0)("periode_name").ToString
                End If

                txtSearchCriteria = String.Format(" periode_id = '{0}' ", Me.txtSearchPeriode.Text)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Year
            If Me.txtSearchYear.Text <> "" Then
                AsOf = "Year " & Me.txtSearchYear.Text
                txtSearchCriteria = " year(order_utilizeddatestart) = " & Me.txtSearchYear.Text
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Shooting Date
            If Me._RPT_CYCLE = "DAILY" Then
                Dim datestart = Me.dtpSearchDate1.Value.Month.ToString & "/" & _
                                Me.dtpSearchDate1.Value.Day.ToString & "/" & _
                                Me.dtpSearchDate1.Value.Year.ToString

                Dim dateend = Me.dtpHiddenDate2.Value.Month.ToString & "/" & _
                                Me.dtpHiddenDate2.Value.Day.ToString & "/" & _
                                Me.dtpHiddenDate2.Value.Year.ToString

                If Me._ORDERTYPE_ID = "RO" Then
                    AsOf = "Shooting Date Start from " & Format(Me.dtpSearchDate1.Value, "dd MMM yyyy") & _
                           " to " & Format(Me.dtpSearchDate2.Value, "dd MMM yyyy")

                    txtSearchCriteria = " order_utilizeddatestart >= '" & datestart & "' AND order_utilizeddatestart <= '" & dateend & "'"
                Else
                    AsOf = "Order Date: " & Format(Me.dtpSearchDate1.Value, "dd MMM yyyy") & _
                           " to " & Format(Me.dtpSearchDate2.Value, "dd MMM yyyy")

                    txtSearchCriteria = " order_date >= '" & datestart & "' AND order_date < '" & dateend & "'"
                End If

                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If

            End If
            If Me.chkAccruedDate.Checked = True Then
                ''-- Accrued Date
                Dim accrudt = Me.dtpSearchAccrDate.Value.Month.ToString & "/" & _
                                  Me.dtpSearchAccrDate.Value.Day.ToString & "/" & _
                                  Me.dtpSearchAccrDate.Value.Year.ToString

                accrudate = " ap_date <= '" & accrudt & "'"
            Else
                Dim accrudt = "12/31/2999"

                accrudate = " ap_date <= '" & accrudt & "'"

            End If
            'rFilter = "Accrued Date: " & Format(Me.dtpSearchAccrDate.Value, "dd MMM yyyy")
            ''--

            criteria = txtCondition

            'Generating reports........
            If Me._RPT_CYCLE = "DAILY" Or Me._RPT_CYCLE = "MONTHLY" Then
                Select Case Me.cboReportName.SelectedValue
                    '    ===================   LIST   ===================
                    'Case "134"
                    'Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                    'rptname_rdlc = "PRC.rptROListHD.rdlc"
                    Case "134"  'PO Detil List
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptPODetilList.rdlc"
                    Case "112"  'RO List By Budget per Vendor (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROList_byBudget_perVendor.rdlc"
                    Case "113"  'RO List By Vendor per Budget (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROList_byVendor_perBudget.rdlc"


                        '=================== SUMMARY ===================
                    Case "121"
                        tempstat = False

                    Case "122"  'RO Summary By Budget per Vendor (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byBudget_perVendor.rdlc"

                    Case "123"  'RO Summary By Vendor per Budget (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byVendor_perBudget.rdlc"

                        '=================== ITEM SUMMARY ===================
                    Case "131"  'RO Summary By Category (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROItemSummary_byCategory.rdlc"

                    Case "132"  'RO Summary By Category per Vendor (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROItemSummary_byCategory_perVendor.rdlc"

                    Case "133"  'RO Summary By Category per Budget (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROItemSummary_byCategory_perBudget.rdlc"

                        '=================== CATEGORY SUMMARY ===================
                    Case "141"  'RO Summary By Category (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byCategory.rdlc"

                    Case "142"  'RO Summary By Category per Vendor (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byCategory_perVendor.rdlc"

                    Case "143"  'RO Summary By Category per Budget (Daily)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byCategory_perBudget.rdlc"

                        '=================== ACCRUAL ===================
                    Case "151"
                        If Me._ORDERTYPE_ID = "PO" Then
                            Me.FillTblReport2(Me.tbl_OrderPaymReq_AP, "pr_RptPO_vsPA_vsAP_Accrued_Select", criteria, accrudate)
                        Else
                            Me.FillTblReport2(Me.tbl_OrderPaymReq_AP, "pr_RptRO_vsPA_vsAP_Accrued_Select", criteria, accrudate)
                        End If

                        rptname_rdlc = "PRC.rptROList_vsAP_ByVendor_perBudget.rdlc"
                    Case "152"
                        If Me._ORDERTYPE_ID = "PO" Then
                            Me.FillTblReport2(Me.tbl_OrderPaymReq_AP, "pr_RptPO_vsPA_vsAP_Accrued_Select", criteria, accrudate)
                        Else
                            Me.FillTblReport2(Me.tbl_OrderPaymReq_AP, "pr_RptRO_vsPA_vsAP_Accrued_Select", criteria, accrudate)
                        End If
                        rptname_rdlc = "PRC.rptROSummary_vsAP_ByVendor_perBudget.rdlc"
                End Select

            Else
                'YEARLY'
                Select Case Me.cboReportName.SelectedValue

                    '    ===================   LIST   ===================
                    Case "134"  'RO List All (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROListHD.rdlc"

                    Case "112"  'RO List By Budget per Vendor (Yearly)
                        'Me.FillTblReport(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROList_byBudget_perVendor_Yearly.rdlc"

                    Case "113"  'RO List By Vendor per Budget (Yearly)
                        'Me.FillTblReport(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROList_byVendor_perBudget_Yearly.rdlc"


                        '=================== SUMMARY ===================
                    Case "121"
                        tempstat = False

                    Case "122"  'RO Summary By Budget per Vendor (Yearly)
                        'Me.FillTblReport(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byBudget_perVendor_Yearly.rdlc"

                    Case "123"  'RO Summary By Vendor per Budget (Yearly)
                        'Me.FillTblReport(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria)
                        Me.FillTblReport2(Me.tbl_RptOrderSummary, "pr_RptOrderSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byVendor_perBudget_Yearly.rdlc"


                        '=================== DETIL SUMMARY ===================
                    Case "131"  'RO Summary By Category (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROItemSummary_byCategory.rdlc"

                    Case "132"  'RO Summary By Category per Vendor (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROItemSummary_byCategory_perVendor.rdlc"

                    Case "133"  'RO Summary By Category per Budget (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROItemSummary_byCategory_perBudget.rdlc"


                        '=================== CATEGORY SUMMARY ===================
                    Case "141"  'RO Summary By Category (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byCategory_Yearly.rdlc"

                    Case "142"  'RO Summary By Category per Vendor (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byCategory_perVendor_Yearly.rdlc"

                    Case "143"  'RO Summary By Category per Budget (Yearly)
                        Me.FillTblReport2(Me.tbl_RptOrderDetilSummary, "pr_RptOrderDetilSummary_Select", criteria, Me._ORDERTYPE_ID)
                        rptname_rdlc = "PRC.rptROSummary_byCategory_perBudget_Yearly.rdlc"

                End Select

            End If

            Dim rptTitle As String = ""

            If Me._ORDERTYPE_ID = "RO" Then
                rptTitle = "Rental " & Me.cboReportName.Text
            ElseIf Me._ORDERTYPE_ID = "PO" Then
                rptTitle = "Purchase " & Me.cboReportName.Text
            ElseIf Me._ORDERTYPE_ID = "MO" Then
                rptTitle = "Maintenance " & Me.cboReportName.Text
            End If

            ReportTitle = New Microsoft.Reporting.WinForms.ReportParameter("ReportTitle", rptTitle)
            ReportSubTitle = New Microsoft.Reporting.WinForms.ReportParameter("ReportSubTitle", AsOf)
            ReportSubTitle2 = New Microsoft.Reporting.WinForms.ReportParameter("ReportSubTitle2", rFilter)

            rpt_kind = Mid(Me.cboReportName.SelectedValue.ToString, 2, 1)
            Me.GenerateReport(rptname_rdlc, rpt_kind)
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function FillTblReport(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String) As Boolean
        tbl_name.Clear()
        Try
            Me.DataFill(tbl_name, sp_name, criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FillTblReport2(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String, ByVal OtherCriteria As String) As Boolean
        tbl_name.Clear()
        Try
            Me.DataFill2(tbl_name, sp_name, criteria, OtherCriteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function GenerateReport(ByVal rptname_rdlc As String, ByVal rpt_kind As String) As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistOrderHeaderSummary As ArrayList = New ArrayList()
        Dim objDatalistOrderDetilSummary As ArrayList = New ArrayList()
        Dim objDatalistOrderAccrual As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        Select Case rpt_kind
            Case "1"
                '-- List
                objDatalistOrderHeaderSummary = Me.GenerateDataHeaderSummary()
                objRdsH.Name = "PRC_DataSource_clsRptOrder"
                objRdsH.Value = objDatalistOrderHeaderSummary

            Case "2"
                '-- List
                objDatalistOrderHeaderSummary = Me.GenerateDataHeaderSummary()
                objRdsH.Name = "PRC_DataSource_clsRptOrder"
                objRdsH.Value = objDatalistOrderHeaderSummary

            Case "3"
                '-- Item Summary
                objDatalistOrderDetilSummary = Me.GenerateDataDetilSummary()
                objRdsH.Name = "PRC_DataSource_clsRptOrderSummary"
                objRdsH.Value = objDatalistOrderDetilSummary

            Case "4"
                '-- Category Summary
                objDatalistOrderDetilSummary = Me.GenerateDataDetilSummary()
                objRdsH.Name = "PRC_DataSource_clsRptOrderSummary"
                objRdsH.Value = objDatalistOrderDetilSummary

            Case "5"
                '-- Accrual
                objDatalistOrderAccrual = Me.GenerateDataAccrual
                objRdsH.Name = "PRC_DataSource_clsRptOrder_PA_AP"
                objRdsH.Value = objDatalistOrderAccrual


        End Select

        Try
            objReportH.ReportEmbeddedResource = rptname_rdlc
            objReportH.DataSources.Add(objRdsH)
            'Dim parRptChannelName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("ChannelName", Me.sptChannelName)
            'Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("ChannelID", Me.sptChannelID)
            'Dim parRptChannelAddress As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("ChannelAddress", Me.sptChannelAddress)
            ' Dim parRptDomainName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomainName)
            objReportViewer.LocalReport.EnableExternalImages = True

            objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {ReportTitle})
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {ReportSubTitle})
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {ReportSubTitle2})

            'objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptChannelName, parRptChannelID, parRptChannelAddress, parRptDomainName})

            objReportViewer.Name = "ReportViewer1"
            objReportViewer.LocalReport.DataSources.Clear()
            objReportViewer.LocalReport.DataSources.Add(objRdsH)
            objReportViewer.LocalReport.EnableExternalImages = True
            objReportViewer.RefreshReport()

            Me.Panel3.SuspendLayout()
            Me.Panel3.Controls.Remove(Me.ReportViewer1)
            Me.ReportViewer1 = Nothing
            Me.ReportViewer1 = objReportViewer
            Me.ReportViewer1.LocalReport.EnableExternalImages = True

            Me.Panel3.Controls.Add(Me.ReportViewer1)
            Me.Panel3.ResumeLayout()
            Me.ReportViewer1.Dock = DockStyle.Fill
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function GenerateDataHeaderSummary() As ArrayList
        Dim objDatalistROSummary As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_RptOrderSummary.Rows.Count - 1

            Me.objRptROSummary = New DataSource.clsRptOrder(Me.DSN)
            Try
                With Me.objRptROSummary
                    .order_programtype = Me.tbl_RptOrderSummary.Rows(i).Item("order_programtype").ToString
                    .ordertype_id = Me.tbl_RptOrderSummary.Rows(i).Item("ordertype_id").ToString
                    .channel_id = Me.tbl_RptOrderSummary.Rows(i).Item("channel_id").ToString
                    .order_id = Me.tbl_RptOrderSummary.Rows(i).Item("order_id").ToString
                    .order_descr = Me.tbl_RptOrderSummary.Rows(i).Item("order_descr").ToString
                    .rekananro_name = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("rekanan_name").ToString, "")
                    .order_date = Me.tbl_RptOrderSummary.Rows(i).Item("order_date").ToString
                    .order_utilizeddatestart = Me.tbl_RptOrderSummary.Rows(i).Item("order_utilizeddatestart").ToString
                    .order_utilizedlocation = Me.tbl_RptOrderSummary.Rows(i).Item("order_utilizedlocation").ToString
                    .order_prognm = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_prognm").ToString, "")
                    .order_progsch = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_progsch").ToString, "")
                    .budget_id = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("budget_id").ToString, "")
                    .order_setdate = Me.tbl_RptOrderSummary.Rows(i).Item("order_setdate").ToString
                    .periode_id = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("periode_id").ToString, "")
                    .currency_id = Me.tbl_RptOrderSummary.Rows(i).Item("currency_id").ToString
                    .currency_name = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("currency_name").ToString, "")

                    If Me._ORDERTYPE_ID = "RO" Then
                        .order_Subtotal = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("ro_subtotal_incldisc"), 0)
                        .order_SubtotalIDR = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("ro_subtotalidr_incldisc"), 0)
                    Else
                        .order_Subtotal = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("po_subtotal_incldisc"), 0)
                        .order_SubtotalIDR = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("po_subtotalidr_incldisc"), 0)
                    End If

                    .order_discount = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_discount"), 0)
                    .order_insurancecost = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_insurancecost"), 0)
                    .order_transportationcost = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_transportationcost"), 0)
                    .order_operatorcost = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_operatorcost"), 0)
                    .order_pph_percent = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_pph_percent"), 0)
                    .order_ppn_percent = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("order_ppn_percent"), 0)

                    If Me._ORDERTYPE_ID = "RO" Then
                        .ro_PPH = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("ro_pph"), 0)
                        .ro_PPN = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("ro_ppn"), 0)
                    Else
                        .ro_PPH = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("po_pph"), 0)
                        .ro_PPN = clsUtil.IsDbNull(Me.tbl_RptOrderSummary.Rows(i).Item("po_ppn"), 0)
                    End If

                    .order_Total = .order_Subtotal - .order_discount + .order_insurancecost _
                    + .order_transportationcost + .order_operatorcost - .ro_PPH + .ro_PPN

                    .order_TotalIDR = .order_SubtotalIDR - .order_discount + .order_insurancecost _
                                        + .order_transportationcost + .order_operatorcost - .ro_PPH + .ro_PPN



                End With

            Catch ex As Exception

            End Try
            objDatalistROSummary.Add(Me.objRptROSummary)
        Next

        'Me.objRptROSummary.order_TotalperOrder = 0

        Return objDatalistROSummary

    End Function

    Private Function GenerateDataDetilSummary() As ArrayList
        Dim objDatalistRODetilSummary As ArrayList = New ArrayList()
        Dim i As Integer
        'Dim TotalperOrder As Decimal
        If Me.tbl_RptOrderDetilSummary.Rows.Count <= 0 Then
            MsgBox("No Data")
        End If
        'Me.DataGridView1.DataSource = Me.tbl_RptOrderDetilSummary
        For i = 0 To Me.tbl_RptOrderDetilSummary.Rows.Count - 1
            
            Me.objRptRODetilSummary = New DataSource.clsRptOrderSummary(Me.DSN)
            Try
             

                With Me.objRptRODetilSummary
                    'Header
                    .channel_id = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("channel_id").ToString, "")
                    .order_id = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_id").ToString, "")
                    .category_id = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("category_id").ToString, "")
                    .category_name = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("category_name").ToString, "")
                    .rekanan_id = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("rekanan_id").ToString, "")
                    .rekanan_name = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("rekanan_name").ToString, "")

                    .order_programtype = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_programtype").ToString, "")
                    .order_date = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_date").ToString, "")
                    .order_utilizeddatestart = Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_utilizeddatestart").ToString
                    .order_prognm = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_prognm").ToString, "")
                    .order_progsch = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_progsch").ToString, "")
                    .budget_id = Me.tbl_RptOrderDetilSummary.Rows(i).Item("budget_id").ToString
                    .budget_name = Me.tbl_RptOrderDetilSummary.Rows(i).Item("budget_name").ToString
                    .currency_id = Me.tbl_RptOrderDetilSummary.Rows(i).Item("currency_id").ToString
                    .currency_name = Me.tbl_RptOrderDetilSummary.Rows(i).Item("currency_name").ToString

                    .periode_id = Me.tbl_RptOrderDetilSummary.Rows(i).Item("periode_id").ToString

                    '.order_subtotalDetil = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_subtotal"), 0)
                    .order_discount = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_discount"), 0)
                    .order_insurancecost = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_insurancecost"), 0)
                    .order_transportationcost = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_transportationcost"), 0)
                    .order_operatorcost = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_operatorcost"), 0)
                    .order_pph_percent = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_pph_percent"), 0)
                    .order_ppn_percent = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("order_ppn_percent"), 0)

                    'Detil
                    .item_id = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("item_id").ToString, "")
                    .item_name = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("item_name").ToString, "")

                    .strukturunit_name = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("strukturunit_name").ToString, "")
                    .orderdetil_descr = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_descr").ToString, "")
                    .orderdetil_line = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_line").ToString, "")
                    .orderdetil_days = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_days"), 0)
                    .orderdetil_qty = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_qty"), 0)
                    .orderdetil_discount = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_discount"), 0)
                    .orderdetil_idr = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_idr"), 0)
                    .orderdetil_foreign = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_foreign"), 0)
                    .orderdetil_foreignrate = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_foreignrate"), 0)
                    .request_idref = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("request_idref").ToString, "")
                    .request_approved = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("request_approveddate").ToString, "")
                    .orderdetil_pphpercent = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_pphpercent"), 0)
                    .orderdetil_ppnpercent = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("orderdetil_ppnpercent"), 0)
                    .podetil_rowtotalforeign_incldisc = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("podetil_rowtotalforeign_incldisc"), 0)
                    .channel_id = Me._CHANNEL

                    'Me.sptChannelName = .channelname
                    'Me.sptChannelID = .channel_id
                    'Me.sptChannelAddress = .channeladdr
                    'Me.sptDomainName = .domain_name

                    If Me._ORDERTYPE_ID = "RO" Then
                        .rodetil_rowtotalidr_incldisc = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("rodetil_rowtotalidr_incldisc"), 0)
                        .rodetil_rowtotalforeign_incldisc = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("rodetil_rowtotalforeign_incldisc"), 0)
                    Else
                        .rodetil_rowtotalidr_incldisc = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("podetil_rowtotalidr_incldisc"), 0)
                        .rodetil_rowtotalforeign_incldisc = clsUtil.IsDbNull(Me.tbl_RptOrderDetilSummary.Rows(i).Item("podetil_rowtotalforeign_incldisc"), 0)
                    End If

                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            objDatalistRODetilSummary.Add(Me.objRptRODetilSummary)
        Next

        Me.objRptRODetilSummary.order_TotalperOrder = 0

        Return objDatalistRODetilSummary

    End Function

    Private Function GenerateDataAccrual() As ArrayList
        Dim objDatalistROAccrual As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_OrderPaymReq_AP.Rows.Count - 1

            Me.objRptROAccrual = New DataSource.clsRptOrder_PA_AP(Me.DSN)
            Try
                With Me.objRptROAccrual
                    .channel_id = Me.tbl_OrderPaymReq_AP.Rows(i).Item("channel_id").ToString
                    .order_id = Me.tbl_OrderPaymReq_AP.Rows(i).Item("order_id").ToString
                    .order_utilizeddatestart = Me.tbl_OrderPaymReq_AP.Rows(i).Item("order_utilizeddatestart").ToString
                    .rekanan_name = Me.tbl_OrderPaymReq_AP.Rows(i).Item("rekanan_name").ToString
                    .budget_id = Me.tbl_OrderPaymReq_AP.Rows(i).Item("budget_id").ToString
                    .budget_name = Me.tbl_OrderPaymReq_AP.Rows(i).Item("budget_name").ToString
                    .ap_ref = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("ap_ref").ToString, "")
                    .ap_date = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("ap_date"), "01/01/0001")
                    .accru_idr = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("accru_idr"), 0)

                    If .ap_ref = "" Then .orderpaymreq_amount = 0 Else .orderpaymreq_amount = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("orderpaymreq_amount"), 0)
                    .ro_total_excltax = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("ro_total_excltax"), 0)
                    .ro_total_incltax = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("ro_total_incltax"), 0)
                    .outstanding_ap = .ro_total_incltax - .orderpaymreq_amount

                    '.orderdetil_Subtotal = clsUtil.IsDbNull(Me.tbl_OrderPaymReq_AP.Rows(i).Item("orderdetil_subtotal"), 0)

                End With
            Catch ex As Exception

            End Try
            objDatalistROAccrual.Add(Me.objRptROAccrual)
        Next

        Return objDatalistROAccrual

    End Function

    Private Sub chkSearchLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchLocation.CheckedChanged
        If Me.chkSearchLocation.Checked Then
            Me.lblLocation.Visible = True
        Else
            Me.lblLocation.Visible = False
        End If
    End Sub

    Private Sub dtpSearchDate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchDate2.ValueChanged
        Me.dtpHiddenDate2.Value = Me.dtpSearchDate2.Value
    End Sub
End Class



