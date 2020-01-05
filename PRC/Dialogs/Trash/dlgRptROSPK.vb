Public Class dlgRptROSPK

    Private DSN As String
    Private criteria As String
    Private channel_id As String

    Private tbl_TrnRentalOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnRentalOrderDetil As DataTable = clsDataset.CreateTblTrnOrderdetil()

    Private objTrnROPrintHeader As DataSource.clsRptTrnRO

    Private Sub dlgMstAccountPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtfiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtfiller.DataFill(Me.tbl_TrnRentalOrder, "pr_TrnOrder_Select", Me.criteria, "TTV")
        'dtfiller.DataFill(Me.tbl_TrnRentalOrderDetil, "pr_TrnOrderdetil_Select", Me.criteria, "TTV")

        GenerateReport()

        Me.ReportViewer1.RefreshReport()
    End Sub


    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistSettlementHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        objDatalistSettlementHeader = Me.GenerateDataHeader()

        objRdsH.Name = "PRINT_RO_DataSource_clsRptTrnRO"
        objRdsH.Value = objDatalistSettlementHeader

        objReportH.ReportEmbeddedResource = "PRINT_RO.rptTrnROSPK.rdlc"
        objReportH.DataSources.Add(objRdsH)


        'AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource

        objReportViewer.Name = "ReportViewer1"
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.LocalReport.EnableExternalImages = True

        objReportViewer.RefreshReport()


        Me.SuspendLayout()
        Me.Controls.Remove(Me.ReportViewer1)
        Me.ReportViewer1 = Nothing
        Me.ReportViewer1 = objReportViewer
        Me.ReportViewer1.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.ReportViewer1)
        Me.ResumeLayout()
        Me.ReportViewer1.Dock = DockStyle.Fill

    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistROHeader As ArrayList = New ArrayList()

        Dim i As Integer


        For i = 0 To Me.tbl_TrnRentalOrder.Rows.Count - 1



            objTrnROPrintHeader = New DataSource.clsRptTrnRO(Me.DSN)
            With objTrnROPrintHeader
                .order_id = Me.tbl_TrnRentalOrder.Rows(i).Item("order_id").ToString
                .rekanan_iderp = Me.tbl_TrnRentalOrder.Rows(i).Item("rekanan_id").ToString
                .order_prognm = Me.tbl_TrnRentalOrder.Rows(i).Item("order_prognm").ToString
                .order_setdate = Me.tbl_TrnRentalOrder.Rows(i).Item("order_setdate").ToString
                .order_setlocation = Me.tbl_TrnRentalOrder.Rows(i).Item("order_setlocation").ToString
                .order_spknote = Me.tbl_TrnRentalOrder.Rows(i).Item("order_spknote").ToString

            End With
            objDatalistROHeader.Add(objTrnROPrintHeader)
        Next

        Return objDatalistROHeader

    End Function


    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub New(ByVal sDSN As String)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class