Public Class clsPrintROSPK
    Private DSN As String
    Private criteria As String
    Private channel_id As String

    Private tbl_TrnRentalOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnRentalOrderDetil As DataTable = clsDataset.CreateTblTrnOrderdetil()

    Private objTrnROPrintHeader As DataSource.clsRptOrder

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer


    Public Sub Cetak()
        Dim dtfiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtfiller.DataFillLimit(Me.tbl_TrnRentalOrder, "pr_TrnOrder_Select", Me.criteria, 10)
        dtfiller.DataFill(Me.tbl_TrnRentalOrderDetil, "pr_TrnOrderdetil_Select", Me.criteria)

        GenerateReport()
    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistOrderHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        objDatalistOrderHeader = Me.GenerateDataHeader()

        objRdsH.Name = "PRC_DataSource_clsRptOrder"
        objRdsH.Value = objDatalistOrderHeader

        objReportH.ReportEmbeddedResource = "PRC.rptTrnROSPK.rdlc"
        objReportH.DataSources.Add(objRdsH)

        objReportH.EnableExternalImages = True
        'AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()


    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim deviceInfo As String = _
          "<DeviceInfo>" + _
          "  <OutputFormat>JPEG</OutputFormat>" + _
          "  <PageWidth>8.5in</PageWidth>" + _
          "  <PageHeight>11in</PageHeight>" + _
          "  <MarginTop>0.25in</MarginTop>" + _
          "  <MarginLeft>0.6in</MarginLeft>" + _
          "  <MarginRight>0.25in</MarginRight>" + _
          "  <MarginBottom>0.25in</MarginBottom>" + _
          "</DeviceInfo>"
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        m_streams = New List(Of System.IO.Stream)()

        report.Render("Image", deviceInfo, AddressOf CreateStream, _
           warnings)

        Dim stream As System.IO.Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    'Private Function CreateStream(ByVal name As String, _
    '   ByVal fileNameExtension As String, _
    '   ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
    '   ByVal willSeek As Boolean) As System.IO.Stream
    '    Dim stream As System.IO.Stream = _
    '        New System.IO.FileStream("..\..\" + _
    '         name + "." + fileNameExtension, System.IO.FileMode.Create)
    '    m_streams.Add(stream)
    '    Return stream
    'End Function

    Private Function CreateStream(ByVal name As String, _
    ByVal fileNameExtension As String, _
    ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
    ByVal willSeek As Boolean) As System.IO.Stream
        Dim stream As System.IO.Stream = _
            New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" + _
             name + "." + fileNameExtension, System.IO.FileMode.Create)
        m_streams.Add(stream)
        Return stream
    End Function

    Private Sub Print()
        'Const printerName As String = _
        '"Microsoft Office Document Image Writer" '"\\print-programmi\HP LaserJet 2300 Subtitle" '

        Dim printerName As String = ""
        'Dim dlgPrint As New PrintDialog()
        Dim aPrinterSettings As New System.Drawing.Printing.PrinterSettings

        printerName = aPrinterSettings.PrinterName

        'If dlgPrint.ShowDialog = DialogResult.OK Then
        '    printerName = dlgPrint.PrinterSettings.PrinterName
        'End If

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format( _
                "Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
    End Sub

    Private Sub PrintPage(ByVal sender As Object, _
    ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        'Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))
        'ev.Graphics.DrawImage(pageImage, ev.PageBounds)

        'm_currentPageIndex += 1
        'ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistROHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_TrnRentalOrder.Rows.Count - 1

            objTrnROPrintHeader = New DataSource.clsRptOrder(Me.DSN)
            With objTrnROPrintHeader

                .channel_id = Me.tbl_TrnRentalOrder.Rows(i).Item("channel_id").ToString
                .order_id = Me.tbl_TrnRentalOrder.Rows(i).Item("order_id").ToString
                .rekanan_id = Me.tbl_TrnRentalOrder.Rows(i).Item("rekanan_id").ToString
                .order_prognm = Me.tbl_TrnRentalOrder.Rows(i).Item("order_prognm").ToString
                .order_setdate = Me.tbl_TrnRentalOrder.Rows(i).Item("order_setdate").ToString
                .order_setlocation = Me.tbl_TrnRentalOrder.Rows(i).Item("order_setlocation").ToString
                .order_spkworktype = Me.tbl_TrnRentalOrder.Rows(i).Item("order_spkworktype").ToString
                .order_spkdesc = Me.tbl_TrnRentalOrder.Rows(i).Item("order_spkdesc").ToString
                .order_utilizeddatestart = Me.tbl_TrnRentalOrder.Rows(i).Item("order_utilizeddatestart").ToString

                .order_authname = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authname").ToString
                .order_authposition = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authposition").ToString
                .order_authname2 = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authname2").ToString
                .order_authposition2 = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authposition2").ToString


            End With
            objDatalistROHeader.Add(objTrnROPrintHeader)
        Next

        Return objDatalistROHeader

    End Function


    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function


    Public Sub New(ByVal sDSN As String)
        Me.DSN = sDSN
    End Sub

End Class
