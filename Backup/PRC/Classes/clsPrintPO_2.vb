
Public Class clsPrintPO_2
    Private DSN As String
    Private criteria As String
    Private channel_id As String

    Private tbl_TrnOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnOrderDetil As DataTable = clsDataset.CreateTblTrnOrderdetil()

    Private objTrnPOPrintHeader As DataSource.clsRptOrder_2
    Private objDatalistTransaksiDetil As ArrayList
    Private order_subtotalDetil As Double

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer

    Dim p_channel_id, p_channelname, p_channeladdr, p_channeltelp, p_channelfax As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_report_name, p_domain_name As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_id, p_order_canceled, p_order_date As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_dlvrname, p_order_dlvraddr1, p_order_dlvraddr2, p_order_dlvraddr3 As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_dlvrtelp, p_order_dlvrfax As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_rekananpo_name, p_rekananpo_alamat1, p_rekananpo_alamat2, p_rekananpo_alamat3 As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_rekananpo_up, p_rekananpo_up_position As Microsoft.Reporting.WinForms.ReportParameter

    Dim order_pph, order_ppn, order_disc, orderdetil_disc As Decimal

    Public Sub Cetak()
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtfiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtfiller.DataFilllimit(Me.tbl_TrnOrder, "pr_TrnOrder_Select", Me.criteria, 10, Me.channel_id)
        dtfiller.DataFill(Me.tbl_TrnOrderDetil, "pr_TrnOrderdetil2_Select", Me.criteria)

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

        Try
            objRdsH.Name = "PRC_DataSource_clsRptOrder_2"
            objRdsH.Value = objDatalistOrderHeader

            objReportH.ReportEmbeddedResource = "PRC.rptTrnPO_02.rdlc"
            objReportH.DataSources.Add(objRdsH)

            AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
            objReportH.EnableExternalImages = True
            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing

            '==
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_report_name})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channel_id})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channelname})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channeladdr})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channeltelp})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channelfax})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_domain_name})

            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_id})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_date})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_canceled})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_dlvrname})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_dlvraddr1})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_dlvraddr2})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_dlvraddr3})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_dlvrtelp})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_dlvrfax})

            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananpo_name})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananpo_alamat1})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananpo_alamat2})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananpo_alamat3})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananpo_up})
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananpo_up_position})
            '==

            Export(objReportH)

            m_currentPageIndex = 0
            Print()

        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)

        End Try


    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim deviceInfo As String = _
          "<DeviceInfo>" + _
          "  <OutputFormat>EMF</OutputFormat>" + _
          "  <PageWidth>8.5in</PageWidth>" + _
          "  <PageHeight>11in</PageHeight>" + _
          "  <MarginTop>0.25in</MarginTop>" + _
          "  <MarginLeft>0.25in</MarginLeft>" + _
          "  <MarginRight>0.25in</MarginRight>" + _
          "  <MarginBottom>0.25in</MarginBottom>" + _
          "</DeviceInfo>"
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        m_streams = New List(Of System.IO.Stream)()

        report.EnableExternalImages = True
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
            New System.IO.FileStream("C:\TransBrowser\Temp\" + _
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
        m_streams.Clear()
    End Sub

    Private Sub PrintPage(ByVal sender As Object, _
    ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))
        ev.Graphics.DrawImage(pageImage, ev.PageBounds)

        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistROHeader As ArrayList = New ArrayList()
        Dim i As Integer
        Dim v_order_date As String

        For i = 0 To Me.tbl_TrnOrder.Rows.Count - 1

            GenerateDataDetail()

            objTrnPOPrintHeader = New DataSource.clsRptOrder_2(Me.DSN)
            With objTrnPOPrintHeader
                .channel_id = Me.tbl_TrnOrder.Rows(i).Item("channel_id").ToString
                .rekanan_id = Me.tbl_TrnOrder.Rows(i).Item("rekanan_id").ToString

                .order_dlvrname = Me.tbl_TrnOrder.Rows(i).Item("order_dlvrname").ToString
                .order_dlvraddr1 = Me.tbl_TrnOrder.Rows(i).Item("order_dlvraddr1").ToString
                .order_dlvraddr2 = Me.tbl_TrnOrder.Rows(i).Item("order_dlvraddr2").ToString
                .order_dlvraddr3 = Me.tbl_TrnOrder.Rows(i).Item("order_dlvraddr3").ToString
                .order_dlvrtelp = Me.tbl_TrnOrder.Rows(i).Item("order_dlvrtelp").ToString
                .order_dlvrfax = Me.tbl_TrnOrder.Rows(i).Item("order_dlvrfax").ToString
                .order_dlvrhp = Me.tbl_TrnOrder.Rows(i).Item("order_dlvrhp").ToString

                .order_id = Me.tbl_TrnOrder.Rows(i).Item("order_id").ToString
                .order_canceled = Me.tbl_TrnOrder.Rows(i).Item("order_canceled").ToString

                .order_date = Me.tbl_TrnOrder.Rows(i).Item("order_date").ToString
                v_order_date = Format(.order_date, "dd MMM yyyy")

                .order_prognm = Me.tbl_TrnOrder.Rows(i).Item("order_prognm").ToString
                .order_progsch = Me.tbl_TrnOrder.Rows(i).Item("order_progsch").ToString
                .budget_id = Me.tbl_TrnOrder.Rows(i).Item("budget_id").ToString
                .currency_id = clsUtil.IsDbNull(Me.tbl_TrnOrder.Rows(i).Item("currency_id"), "")

                .order_setdate = Me.tbl_TrnOrder.Rows(i).Item("order_setdate").ToString
                .order_setlocation = Me.tbl_TrnOrder.Rows(i).Item("order_setlocation").ToString
                .order_utilizeddatestart = Me.tbl_TrnOrder.Rows(i).Item("order_utilizeddatestart").ToString
                .order_utilizeddateend = Me.tbl_TrnOrder.Rows(i).Item("order_utilizeddateend").ToString
                .order_utilizedlocation = Me.tbl_TrnOrder.Rows(i).Item("order_utilizedlocation").ToString
                .order_utilizedtimestart = Me.tbl_TrnOrder.Rows(i).Item("order_utilizedtimestart").ToString
                .order_authname = Me.tbl_TrnOrder.Rows(i).Item("order_authname").ToString
                .order_authposition = Me.tbl_TrnOrder.Rows(i).Item("order_authposition").ToString
                .order_authname2 = Me.tbl_TrnOrder.Rows(i).Item("order_authname2").ToString
                .order_authposition2 = Me.tbl_TrnOrder.Rows(i).Item("order_authposition2").ToString

                .order_setdate = Me.tbl_TrnOrder.Rows(i).Item("order_setdate").ToString
                .order_setlocation = Me.tbl_TrnOrder.Rows(i).Item("order_setlocation").ToString
                .order_settime = Me.tbl_TrnOrder.Rows(i).Item("order_settime").ToString
                .order_spkrequired = Me.tbl_TrnOrder.Rows(i).Item("order_spkrequired").ToString
                .order_spkworktype = Me.tbl_TrnOrder.Rows(i).Item("order_spkworktype").ToString
                .order_spkdesc = Me.tbl_TrnOrder.Rows(i).Item("order_spkdesc")
                .periode_id = Me.tbl_TrnOrder.Rows(i).Item("periode_id").ToString
                .order_revno = Me.tbl_TrnOrder.Rows(i).Item("order_revno").ToString
                .order_revdesc = Me.tbl_TrnOrder.Rows(i).Item("order_revdesc").ToString
                .order_revdate = Me.tbl_TrnOrder.Rows(i).Item("order_revdate").ToString
                .order_descr = Me.tbl_TrnOrder.Rows(i).Item("order_descr").ToString
                .order_note = Me.tbl_TrnOrder.Rows(i).Item("order_note").ToString

                .order_discount = Me.order_disc
                .order_insurancecost = Me.tbl_TrnOrder.Rows(i).Item("order_insurancecost")
                .order_transportationcost = Me.tbl_TrnOrder.Rows(i).Item("order_transportationcost")
                .order_operatorcost = Me.tbl_TrnOrder.Rows(i).Item("order_operatorcost")
                '.po_PPH = Me.po_pph
                '.po_PPN = Me.po_ppn
                .order_PPH = Me.order_pph
                .order_PPN = Me.order_ppn

                .order_Subtotal = Me.order_subtotalDetil
                '.order_PPH = 0.01 * Me.tbl_TrnOrder.Rows(i).Item("order_pph_percent") * (Me.order_subtotalDetil - .order_discount)
                '.order_PPN = 0.01 * Me.tbl_TrnOrder.Rows(i).Item("order_ppn_percent") * (Me.order_subtotalDetil - .order_discount)
                .order_Total = .order_Subtotal - .order_discount + .order_insurancecost _
                               + .order_transportationcost + .order_operatorcost - .order_PPH + .order_PPN

                '.order_Terbilang = clsUtil.Terbilang(Math.Round(.order_Total)).Trim.ToUpper
                .order_Terbilang = clsUtil.Terbilang(.order_Total).Trim.ToUpper

                If Mid(.order_id, 1, 2) = "PO" Then
                    Me.p_report_name = New Microsoft.Reporting.WinForms.ReportParameter("p_report_name", "PURCHASE ORDER")
                ElseIf Mid(.order_id, 1, 2) = "MO" Then
                    Me.p_report_name = New Microsoft.Reporting.WinForms.ReportParameter("p_report_name", "MAINTENANCE ORDER")
                End If

                Me.p_channel_id = New Microsoft.Reporting.WinForms.ReportParameter("p_channel_id", .channel_id)
                Me.p_channelname = New Microsoft.Reporting.WinForms.ReportParameter("p_channelname", .channelname)
                Me.p_channeladdr = New Microsoft.Reporting.WinForms.ReportParameter("p_channeladdr", .channeladdr)
                Me.p_channeltelp = New Microsoft.Reporting.WinForms.ReportParameter("p_channeltelp", .channeltelp)
                Me.p_channelfax = New Microsoft.Reporting.WinForms.ReportParameter("p_channelfax", .channelfax)
                Me.p_domain_name = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", .domain_name)

                Me.p_order_id = New Microsoft.Reporting.WinForms.ReportParameter("p_order_id", .order_id)
                Me.p_order_date = New Microsoft.Reporting.WinForms.ReportParameter("p_order_date", v_order_date)
                Me.p_order_canceled = New Microsoft.Reporting.WinForms.ReportParameter("p_order_canceled", .order_canceled)

                Me.p_order_dlvrname = New Microsoft.Reporting.WinForms.ReportParameter("p_order_dlvrname", .order_dlvrname)
                Me.p_order_dlvraddr1 = New Microsoft.Reporting.WinForms.ReportParameter("p_order_dlvraddr1", .order_dlvraddr1)
                Me.p_order_dlvraddr2 = New Microsoft.Reporting.WinForms.ReportParameter("p_order_dlvraddr2", .order_dlvraddr2)
                Me.p_order_dlvraddr3 = New Microsoft.Reporting.WinForms.ReportParameter("p_order_dlvraddr3", .order_dlvraddr3)
                Me.p_order_dlvrtelp = New Microsoft.Reporting.WinForms.ReportParameter("p_order_dlvrtelp", .order_dlvrtelp)
                Me.p_order_dlvrfax = New Microsoft.Reporting.WinForms.ReportParameter("p_order_dlvrfax", .order_dlvrfax)

                Me.p_rekananpo_name = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananpo_name", .rekananpo_name)
                Me.p_rekananpo_alamat1 = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananpo_alamat1", .rekananpo_alamat1)
                Me.p_rekananpo_alamat2 = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananpo_alamat2", .rekananpo_alamat2)
                Me.p_rekananpo_alamat3 = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananpo_alamat3", .rekananpo_alamat3)
                Me.p_rekananpo_up = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananpo_up", .rekananpo_up)
                Me.p_rekananpo_up_position = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananpo_up_position", .rekananpo_up_position)

            End With
            objDatalistROHeader.Add(objTrnPOPrintHeader)
        Next

        Return objDatalistROHeader

    End Function

    Private Sub GenerateDataDetail()
        objDatalistTransaksiDetil = New ArrayList()
        Dim objPODetil As DataSource.clsRptOrderDetil2

        Dim i As Integer
        Dim inc_no As Integer = 0

        Me.order_subtotalDetil = 0

        Me.order_pph = 0
        Me.order_ppn = 0

        For i = 0 To Me.tbl_TrnOrderDetil.Rows.Count - 1

            objPODetil = New DataSource.clsRptOrderDetil2(Me.DSN)
            With objPODetil

                .order_id = Me.tbl_TrnOrderDetil.Rows(i).Item("order_id")
                .orderdetil_type = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_type"), "Item")
                If .orderdetil_type = "Item" Then inc_no += 1
                .orderdetil_no = inc_no
                .item_id = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("item_id"), "")
                .item_name = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("item_name"), "")
                .currency_id = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("currency_id"), "")
                .orderdetil_discount = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_discount"), 0)
                .orderdetil_descr = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_descr"), "")
                .orderdetil_idr = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_idr"), 0)
                .orderdetil_days = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_days"), 0)
                .orderdetil_qty = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_qty"), 0)
                .orderdetilunit_id = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("unit_id"), 0)
                .orderdetil_foreign = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_foreign"), 0)
                .orderdetil_rowtotalforeign = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_rowtotalforeign"), 0)
                .orderdetil_rowtotalforeign_incldisc = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_rowtotalforeign_incldisc"), 0)
                .orderdetil_pph = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_pph"), 0)
                .orderdetil_ppn = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_ppn"), 0)
                .orderdetil_rowtotalforeign_incltax = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_rowtotalforeign_incltax"), 0)

                Me.orderdetil_disc = clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_discount"), 0) * _
                        clsUtil.IsDbNull(Me.tbl_TrnOrderDetil.Rows(i).Item("orderdetil_qty"), 0)

                Me.order_subtotalDetil += .orderdetil_rowtotalforeign
                Me.order_pph += .orderdetil_pph
                Me.order_ppn += .orderdetil_ppn
                Me.order_disc += Me.orderdetil_disc

            End With

            objDatalistTransaksiDetil.Add(objPODetil)
        Next

    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)

        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("PRC_DataSource_clsRptOrderDetil2", objDatalistTransaksiDetil))

    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New(ByVal sDSN As String)
        Me.DSN = sDSN
    End Sub
End Class
