'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Core

'Imports Microsoft.Office.Interop
'---
Public Class uiOrderExpView

    Private tbl_MstChannel As DataTable = clsDataset2.CreateTblMstChannel()
    Private tbl_MstRekanan As DataTable = clsDataset2.CreateTblMstrekanan()
    Private tbl_MstCategory As DataTable = clsDataset2.CreateTblMstItemcategory()
    Private tbl_ShootingLocation As DataTable = clsDataset2.CreateTblShootingLocation()

    Private tbl_Order As DataTable = clsDataset2.CreateTblRptOrder_Summary
    Private tbl_OrderDetil As DataTable = clsDataset2.CreateTblRptOrderDetil_Summary
    Private tbl_OrderPaymReq As DataTable = clsDataset2.CreateTblTrnOrderpaymreq
    Private tbl_OrderPaymReq_AP As DataTable = clsDataset2.CreateTblRptOrderpaymreq_ap
    Private tbl_BudgetDetil As DataTable = clsDataset2.CreateTblRptBudgetDetil

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

    Private _ORDERTYPE_ID As String = "RO"  '[RO, PO, MO, BG]

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
        Me.uiOrderExpView_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiOrderExpView_Save()
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


    Private Sub uiOrderExpView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Me.InitLayoutUI()

        'XYZ
        'X = 
        'Y = 
        'Z = 
        Me.AddReportList(Me.reports, "000", "-- PILIH --")

        Select Case Me._ORDERTYPE_ID
            Case "RO"
                Me.AddReportList(Me.reports, "111", " RO List ")
                Me.AddReportList(Me.reports, "112", " RO Detil List")
                Me.AddReportList(Me.reports, "113", " RO vs PaymReq")
                Me.AddReportList(Me.reports, "114", " RO vs PaymReq vs AP (Accrual)")
                Me.AddReportList(Me.reports, "115", " RO vs PaymReq vs AP (Accrual) / Category")

            Case "PO"
                Me.AddReportList(Me.reports, "111", " PO List ")
                Me.AddReportList(Me.reports, "112", " PO Detil List")
                Me.AddReportList(Me.reports, "113", " PO vs PaymReq")
                Me.AddReportList(Me.reports, "114", " PO vs PaymReq vs AP (Accrual)")
                Me.AddReportList(Me.reports, "115", " PO vs PaymReq vs AP (Accrual) / Category")

            Case "MO"
                Me.AddReportList(Me.reports, "111", " MO List ")
                Me.AddReportList(Me.reports, "112", " MO Detil List")
                Me.AddReportList(Me.reports, "113", " MO vs PaymReq")
                Me.AddReportList(Me.reports, "114", " MO vs PaymReq vs AP (Accrual)")
                Me.AddReportList(Me.reports, "115", " MO vs PaymReq vs AP (Accrual) / Category")

            Case "BG"
                Me.AddReportList(Me.reports, "211", " Budget Detil List ")

        End Select

        If Me._ORDERTYPE_ID = "BG" Then


            'Me.txtSearchBudget.Enabled = False
        End If

        Me.cboReportName.DataSource = Me.reports
        Me.cboReportName.DisplayMember = "report_name"
        Me.cboReportName.ValueMember = "report_id"

        'Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
        'Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
        'Me.cboSearchChannel.SelectedValue = Me._CHANNEL

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
        'Me.tbtnSave.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False

        Me.chkSearchCategory.Enabled = False
        Me.cboSearchCategory.Enabled = False
        Me.txtSearchBudget.Enabled = False
        Me.cboSearchRekanan.Enabled = False

        Me.lblLocationInfo.Enabled = False
        Me.lboSearchLocation.Enabled = False

        If Me._ORDERTYPE_ID = "RO" Then
            Me.chkSearchLocation.Enabled = True

        ElseIf Me._ORDERTYPE_ID = "PO" Or Me._ORDERTYPE_ID = "MO" Then
            Me.chkSearchLocation.Enabled = False

        ElseIf Me._ORDERTYPE_ID = "BG" Then
            Me.dtpSearchAccrDate.Enabled = False

            Me.lboSearchLocation.Enabled = False
            Me.chkSearchLocation.Enabled = False

            Me.chkSearchChannel.Enabled = False
            Me.cboSearchChannel.Enabled = False

            Me.chkSearchRekanan.Enabled = False
            Me.cboSearchRekanan.Enabled = False

            Me.chkSearchCategory.Enabled = False
            Me.cboSearchCategory.Enabled = False

            Me.lblDateType.Enabled = False
            Me.cboDateType.Enabled = False
            Me.cboDateType.Text = ""

        End If

    End Function

    Private Sub cboReportName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged

        Me.dgvToExport.DataSource = ""
        Me.dgvToExport.Columns.Clear()

        If Mid(Me.cboReportName.SelectedValue.ToString, 2, 1) = "1" Then
            If Not Me.COMBO_ISFILLED Then
                Me.uiOrderExpView_LoadDataCombo()
            End If
        End If

        If (Mid(Me.cboReportName.SelectedValue.ToString, 3, 1) = "4") Or (Mid(Me.cboReportName.SelectedValue.ToString, 3, 1) = "5") Then
            Me.lblSearchAccrDate.Enabled = True
            Me.dtpSearchAccrDate.Enabled = True
        End If

    End Sub

    Private Function uiOrderExpView_LoadDataCombo() As Boolean
        Me.tbl_MstChannel.Clear()
        Me.tbl_MstRekanan.Clear()
        Me.tbl_MstCategory.Clear()

        Try
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannel, "pr_MstChannel_Select", "")
            Me.ComboFill(Me.cboSearchRekanan, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "pr_MstRekanan_Select", "")
            Me.ComboFill(Me.cboSearchCategory, "category_id", "category_name", Me.tbl_MstCategory, "pr_MstItemcategory_Select", "")

            If Me._ORDERTYPE_ID = "RO" Then
                Me.ListBoxFill(Me.lboSearchLocation, "order_utilizedlocation", Me.tbl_ShootingLocation, "pr_ShootingLocation", " ordertype_id='" & Me._ORDERTYPE_ID & "'")
            End If

            Me.COMBO_ISFILLED = True
        Catch ex As Exception
            Me.COMBO_ISFILLED = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function uiOrderExpView_Retrieve() As Boolean
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""
        Dim rpt_kind As String = ""
        Dim rFilter As String = ""
        Dim OtherCriteria As String = ""

        Me.dgvToExport.Columns.Clear()
        Me.tbl_Order.Clear()
        Me.tbl_OrderDetil.Clear()
        Me.tbl_OrderPaymReq.Clear()

        If Me._ORDERTYPE_ID <> "BG" Then
            txtCondition = " ordertype_id='" & Me._ORDERTYPE_ID & "'" & _
                        " and channel_id='" & Me._CHANNEL & "'" & _
                        " and order_canceled = 0"
        End If

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
                    txtCondition = "(" & txtSearchCriteria & ")"
                Else
                    txtCondition = txtCondition & " AND " & "(" & txtSearchCriteria & ")"
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

            '-- Shooting Date (RO) or Order Date (PO n MO)
            Dim datestart = Me.dtpSearchDate1.Value.Month.ToString & "/" & _
                                Me.dtpSearchDate1.Value.Day.ToString & "/" & _
                                Me.dtpSearchDate1.Value.Year.ToString

            Dim dateend = Me.dtpHiddenDate2.Value.Month.ToString & "/" & _
                           Me.dtpHiddenDate2.Value.Day.ToString & "/" & _
                            Me.dtpHiddenDate2.Value.Year.ToString

            If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                txtSearchCriteria = " order_utilizeddatestart >= '" & datestart & "' AND order_utilizeddatestart < '" & dateend & "'"
            ElseIf Me.cboDateType.Text = "By Order Date" Then
                txtSearchCriteria = " order_date >= '" & datestart & "' AND order_date < '" & dateend & "'"
            Else
                txtSearchCriteria = " budget_datestart >= '" & datestart & "' AND budget_datestart < '" & dateend & "'"
            End If

            If txtCondition = "" Then
                txtCondition = " (" & txtSearchCriteria & ") "
            Else
                txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
            End If

            '-- Accrued Date
            If (Mid(Me.cboReportName.SelectedValue, 3, 1) = "4") Or (Mid(Me.cboReportName.SelectedValue, 3, 1) = "5") Then
                Dim accrudt = Me.dtpSearchAccrDate.Value.Month.ToString & "/" & _
                              Me.dtpSearchAccrDate.Value.Day.ToString & "/" & _
                              Me.dtpSearchAccrDate.Value.Year.ToString

                OtherCriteria = " ap_date <= '" & accrudt & "'"

            End If

            criteria = txtCondition

            'Generating view........
            Me.Panel2.SuspendLayout()
            Me.Panel2.Controls.Remove(Me.dgvToExport)
            Me.dgvToExport.Columns.Clear()

            Select Case Me.cboReportName.SelectedValue
                'Me.dtpSearchDate1.Value, Me.dtpHiddenDate2.Value,
                Case "111"
                    If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                        Me.FillTblReport4(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_Summary2_ByShootingDate_Select", criteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    Else
                        Me.FillTblReport4(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_Summary2_ByOrderDate_Select", criteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    End If

                Case "112"
                    criteria = criteria & " and orderdetil_type = 'Item'"
                    If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                        Me.FillTblReport4(Me.tbl_OrderPaymReq_AP, "pr_RptOrderDetil_Summary2_ByShootingDate_Select", criteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    Else
                        Me.FillTblReport4(Me.tbl_OrderPaymReq_AP, "pr_RptOrderDetil_Summary2_ByOrderDate_Select", criteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    End If

                Case "113"
                    If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                        Me.FillTblReport4(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_vsPA2pr_ByShootingDate_Select", criteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    Else
                        Me.FillTblReport4(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_vsPA2_ByOrderDate_Select", criteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    End If

                Case "114"
                    If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                        Me.FillTblReport5(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_vsPA_vsAP_Accrued2_ByShootingDate_Select", criteria, OtherCriteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    Else
                        Me.FillTblReport5(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_vsPA_vsAP_Accrued2_ByOrderDate_Select", criteria, OtherCriteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    End If

                Case "115"
                    If Me.cboDateType.Text = "By Utilizing/Shooting Date" Then
                        Me.FillTblReport5(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_vsPA_vsAP_Accrued2_Category_ByShootingDate_Select", criteria, OtherCriteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    Else
                        Me.FillTblReport5(Me.tbl_OrderPaymReq_AP, "pr_RptOrder_vsPA_vsAP_Accrued2_Category_ByOrderDate_Select", criteria, OtherCriteria, CDate(Me.dtpSearchDate1.Value.ToString("MMM dd, yyyy")), CDate(Me.dtpHiddenDate2.Value.ToString("MMM dd, yyyy")), Me._ORDERTYPE_ID)
                    End If

                Case "211"
                    Me.FillTblReport(Me.tbl_BudgetDetil, "pr_RptBudgetDetil_Select", criteria)
            End Select

            Me.Panel2.Controls.Add(Me.dgvToExport)
            Me.Panel2.ResumeLayout()
            Me.dgvToExport.Dock = DockStyle.Fill

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiOrderExpView_Save() As Boolean

        Select Case Me.cboReportName.SelectedValue
            Case "111"
                uiOrderExpView_SaveToExcel(Me.tbl_OrderPaymReq_AP)
            Case "112"
                uiOrderExpView_SaveToExcel(Me.tbl_OrderPaymReq_AP)
            Case "113"
                uiOrderExpView_SaveToExcel(Me.tbl_OrderPaymReq_AP)
            Case "114"
                uiOrderExpView_SaveToExcel(Me.tbl_OrderPaymReq_AP)
            Case "115"
                uiOrderExpView_SaveToExcel(Me.tbl_OrderPaymReq_AP)
            Case "211"
                uiOrderExpView_SaveToExcel(Me.tbl_BudgetDetil)

        End Select

    End Function

    Private Function uiOrderExpView_SaveToExcel(ByVal tblname As DataTable) As Boolean
        Dim rowCount As Integer = tblname.Rows.Count

        If rowCount <= 0 Then
            MessageBox.Show("Cannot export empty table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If rowCount > 65534 Then
                MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Me.lblProgress.Visible = True
                Me.ProgressBar1.Visible = True

                Dim ColumnIndex As Integer = 0
                Dim RowIndex As Integer = 0

                Dim xl As Excel.Application = New Excel.Application
                Dim xlBook As Excel.Workbook = xl.Workbooks.Add
                Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

                'xl.Visible = False

                'Dim xl As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
                'Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
                'Dim xlWorksheet As Microsoft.Office.Interop.Excel.Worksheet

                'Dim xl As Excel.Application
                'Dim xlBook As Excel.Workbook
                'Dim xlWorksheet As Excel.Worksheet

                'xl = New Excel.Application
                'xlBook = xl.Workbooks.Add
                'xlWorksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)


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
                            lblProgress.Text = "Exporting " & RowIndex & " of " & rowCount & " records"
                            lblProgress.Refresh()
                            ProgressBar1.Value = CInt(100 * (RowIndex / rowCount))
                            ProgressBar1.Refresh()
                        Next

                    Next

                    MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    xl.Visible = True
                    Me.lblProgress.Visible = False
                    Me.ProgressBar1.Visible = False
                Catch ex As Exception
                    MessageBox.Show("Error" & vbCrLf & ex.Message)
                End Try
            End If

        End If

        Me.lblProgress.Visible = False
        Me.ProgressBar1.Visible = False
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

    Private Function FillTblReport2(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String, ByVal OtherCriteria As String) As Boolean
        tbl_name.Clear()
        tbl_name.Columns.Clear()
        Try
            Me.DataFill2(tbl_name, sp_name, criteria, OtherCriteria)
            If tbl_name.Rows.Count > 0 Then
                Me.dgvToExport.DataSource = tbl_name
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FillTblReport4(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String, ByVal Date1 As Date, ByVal Date2 As DateTime, ByVal Ordertype As String) As Boolean
        tbl_name.Clear()
        tbl_name.Columns.Clear()
        Try
            Me.DataFill4(tbl_name, sp_name, criteria, Date1, Date2, Ordertype)
            If tbl_name.Rows.Count > 0 Then
                Me.dgvToExport.DataSource = tbl_name
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FillTblReport5(ByVal tbl_name As DataTable, ByVal sp_name As String, ByVal criteria As String, ByVal OtherCriteria As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal Ordertype As String) As Boolean
        tbl_name.Clear()
        tbl_name.Columns.Clear()
        Try
            Me.DataFill5(tbl_name, sp_name, criteria, OtherCriteria, Date1, Date2, Ordertype)
            If tbl_name.Rows.Count > 0 Then
                Me.dgvToExport.DataSource = tbl_name
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub chkSearchLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchLocation.CheckedChanged
        If Me.chkSearchLocation.Checked Then
            Me.lblLocationInfo.Enabled = True
            Me.lboSearchLocation.Enabled = True
        Else
            Me.lblLocationInfo.Enabled = False
            Me.lboSearchLocation.Enabled = False
        End If
    End Sub

    Private Sub dtpSearchDate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSearchDate2.ValueChanged
        Me.dtpSearchAccrDate.Value = Me.dtpSearchDate2.Value
        Me.dtpHiddenDate2.Value = Me.dtpSearchDate2.Value.AddDays(1)
    End Sub

    Private Sub PnlDfSearch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlDfSearch.Paint

    End Sub

    Private Sub chkSearchBudget_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchBudget.CheckedChanged
        If Me.chkSearchBudget.Checked = True Then
            Me.txtSearchBudget.Enabled = True
        Else
            Me.txtSearchBudget.Enabled = False
        End If
    End Sub

    Private Sub chkSearchRekanan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchRekanan.CheckedChanged
        If Me.chkSearchRekanan.Checked = True Then
            Me.cboSearchRekanan.Enabled = True
        Else
            Me.cboSearchRekanan.Enabled = False
        End If
    End Sub
End Class



