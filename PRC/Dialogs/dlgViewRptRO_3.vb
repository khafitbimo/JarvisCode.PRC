Public Class dlgViewRptRO_3

    Private DSN As String
    Private criteria As String
    Private channel_id As String
    Private Preview As Boolean
    Private criteria_history As String
    Private tbl_TrnRentalOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnRentalOrderDetil As DataTable = clsDataset.CreateTblTrnOrderdetil()
    Private tbl_TrnOrderTOPDetil As DataTable = clsDataset.CreateTblTrnOrderTOPdetil()
    Private tbl_TrnOrderHistory As DataTable = New DataTable
    Private objTrnROPrintHeader As DataSource.clsRptOrder_3
    Private objDatalistTransaksiDetil As ArrayList
    Private order_subtotal As Double
    Private criteria_TOP As String
    Private objDatalistTOPDetil As ArrayList

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer

    Dim p_order_id, p_request_id, p_order_date, p_order_canceled As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_rekananro_name, p_rekananro_alamat, p_rekananro_telp, p_rekananro_fax, p_rekananro_contact, p_rekananro_contactphone As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_spkrequired, p_order_revno, p_order_revdate As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_prognm, p_budget_id, p_budget_name As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_setdate, p_order_settime, p_order_setlocation, p_order_utilizeddatestart, p_order_utilizeddateend As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_order_utilizedtimestart, p_order_utilizedlocation As Microsoft.Reporting.WinForms.ReportParameter
    Dim p_channel_id, p_channeladdr, p_channeltelp, p_channelfax, p_channelext, p_channelname, p_domain_name As Microsoft.Reporting.WinForms.ReportParameter

    Dim order_pph, order_ppn, order_disc, orderdetil_disc As Decimal

    Private Sub dlgViewRptRO_3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtfiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtfiller.DataFillLimit(Me.tbl_TrnRentalOrder, "pr_TrnOrder_Select", Me.criteria, 10)
        dtfiller.DataFill(Me.tbl_TrnRentalOrderDetil, "pr_TrnOrderdetil2_Select2", Me.criteria)
        dtfiller.DataFill(Me.tbl_TrnOrderHistory, "order_revisi_all", Me.criteria_history)
        dtfiller.DataFill(Me.tbl_TrnOrderTOPDetil, "pr_TrnOrderTOPdetil_Select", Me.criteria_TOP)
        GenerateReport()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistOrderHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim dt As DataTable = New DataTable
        objDatalistOrderHeader = Me.GenerateDataHeader()

        clsUtil.DataFill(Me.DSN, dt, "act_select_channel", " channel_id = '" & Me.channel_id & "' ")

        Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))

        '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
        fileUrl = fileUrl.Replace("\", "/")
        fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me.channel_id & ".jpg"
        '---------------------------------------------------------------

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", fileUrl)
        objRdsH.Name = "PRC_DataSource_clsRptOrder_3"
        objRdsH.Value = objDatalistOrderHeader

        'objReportH.ReportEmbeddedResource = "PRC.rptTrnRO.rdlc"
        'objReportH.ReportEmbeddedResource = "PRC.rptTrnRO_03.rdlc"
        objReportH.ReportEmbeddedResource = "PRC.rptTrnRO_05.rdlc" '"PRC.rptTrnRO_04.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channel_id})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channelname})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channeladdr})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channeltelp})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channelfax})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_channelext})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_domain_name})
        '
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_id})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_request_id})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_date})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananro_name})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananro_alamat})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananro_telp})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananro_fax})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananro_contact})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_rekananro_contactphone})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_spkrequired})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_revno})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_revdate})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_prognm})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_budget_id})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_budget_name})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_setdate})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_settime})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_setlocation})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_utilizeddatestart})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_utilizedtimestart})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_utilizeddateend})

        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_utilizedlocation})
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {Me.p_order_canceled})




        objReportViewer.Name = "ReportViewer1"
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)

        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.ReportViewer1)
        Me.ReportViewer1 = Nothing
        Me.ReportViewer1 = objReportViewer
        Me.ReportViewer1.LocalReport.EnableExternalImages = True

        If Preview = False Then
            Using report As New clsQuickPrint(ReportViewer1.LocalReport)
                report.Print()
            End Using
            Me.Close()
        Else
            Me.Controls.Add(Me.ReportViewer1)
        End If

        Me.ResumeLayout()
        Me.ReportViewer1.Dock = DockStyle.Fill
    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim deviceInfo As String = _
          "<DeviceInfo>" + _
          "  <OutputFormat>EMF</OutputFormat>" + _
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

    Private Function CreateStream(ByVal name As String, _
       ByVal fileNameExtension As String, _
       ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
       ByVal willSeek As Boolean) As System.IO.Stream
        Dim stream As System.IO.Stream = _
            New System.IO.FileStream("..\..\" + _
             name + "." + fileNameExtension, System.IO.FileMode.Create)
        m_streams.Add(stream)
        Return stream
    End Function

    'Private Sub Print()
    '    'Const printerName As String = _
    '    '"Microsoft Office Document Image Writer" '"\\print-programmi\HP LaserJet 2300 Subtitle" '

    '    Dim printerName As String = ""
    '    'Dim dlgPrint As New PrintDialog()
    '    Dim aPrinterSettings As New System.Drawing.Printing.PrinterSettings

    '    printerName = aPrinterSettings.PrinterName

    '    'If dlgPrint.ShowDialog = Windows.Forms.DialogResult.OK Then
    '    '    printerName = dlgPrint.PrinterSettings.PrinterName
    '    'End If

    '    If m_streams Is Nothing Or m_streams.Count = 0 Then
    '        Return
    '    End If

    '    Dim printDoc As New System.Drawing.Printing.PrintDocument()
    '    printDoc.PrinterSettings.PrinterName = printerName
    '    If Not printDoc.PrinterSettings.IsValid Then
    '        Dim msg As String = String.Format( _
    '            "Can't find printer ""{0}"".", printerName)
    '        Console.WriteLine(msg)
    '        Return
    '    End If
    '    AddHandler printDoc.PrintPage, AddressOf PrintPage
    '    printDoc.Print()
    'End Sub

    'Private Sub PrintPage(ByVal sender As Object, _
    'ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
    '    Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))
    '    ev.Graphics.DrawImage(pageImage, ev.PageBounds)

    '    m_currentPageIndex += 1
    '    ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    'End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistROHeader As ArrayList = New ArrayList()
        Dim i As Integer
        Dim v_order_date, v_order_setdate, v_order_revdate, v_order_utilizeddatestart, v_order_utilizeddateend As String

        For i = 0 To Me.tbl_TrnRentalOrder.Rows.Count - 1

            GenerateDataDetail()
            GenerateDataDetailTOP()

            objTrnROPrintHeader = New DataSource.clsRptOrder_3(Me.DSN)
            With objTrnROPrintHeader
                .channel_id = Me.tbl_TrnRentalOrder.Rows(i).Item("channel_id").ToString

                .order_id = Me.tbl_TrnRentalOrder.Rows(i).Item("order_id").ToString
                .request_id = Me.tbl_TrnRentalOrder.Rows(i).Item("request_id").ToString
                .order_date = Me.tbl_TrnRentalOrder.Rows(i).Item("order_date").ToString
                v_order_date = Format(.order_date, "dd MMM yyyy")
                .order_prognm = clsUtil.IsDbNull(Me.tbl_TrnRentalOrder.Rows(i).Item("order_prognm").ToString, "-")
                .order_progsch = clsUtil.IsDbNull(Me.tbl_TrnRentalOrder.Rows(i).Item("order_progsch").ToString, "-")
                .budget_id = Me.tbl_TrnRentalOrder.Rows(i).Item("budget_id").ToString

                .order_setdate = Me.tbl_TrnRentalOrder.Rows(i).Item("order_setdate").ToString
                v_order_setdate = Format(.order_setdate, "dd MMM yyyy")
                .order_setlocation = Me.tbl_TrnRentalOrder.Rows(i).Item("order_setlocation").ToString
                .order_settime = clsUtil.IsDbNull(Me.tbl_TrnRentalOrder.Rows(i).Item("order_settime").ToString, "")

                .order_utilizeddatestart = Me.tbl_TrnRentalOrder.Rows(i).Item("order_utilizeddatestart").ToString
                .order_utilizeddateend = Me.tbl_TrnRentalOrder.Rows(i).Item("order_utilizeddateend").ToString
                v_order_utilizeddatestart = Format(.order_utilizeddatestart, "dd MMM yyyy")
                v_order_utilizeddateend = Format(.order_utilizeddateend, "dd MMM yyyy")
                .order_utilizedlocation = Me.tbl_TrnRentalOrder.Rows(i).Item("order_utilizedlocation").ToString
                .order_utilizedtimestart = Me.tbl_TrnRentalOrder.Rows(i).Item("order_utilizedtimestart").ToString

                .rekanan_id = Me.tbl_TrnRentalOrder.Rows(i).Item("rekanan_id").ToString
                .currency_id = Me.tbl_TrnRentalOrder.Rows(i).Item("currency_id").ToString
                '.currency_shortname = Me.tbl_TrnRentalOrder.Rows(i).Item("currency_shortname").ToString
                .order_authname = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authname").ToString
                .order_authposition = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authposition").ToString
                .order_authname2 = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authname2").ToString
                .order_authposition2 = Me.tbl_TrnRentalOrder.Rows(i).Item("order_authposition2").ToString

                .order_spkrequired = Me.tbl_TrnRentalOrder.Rows(i).Item("order_spkrequired").ToString
                .order_spkworktype = Me.tbl_TrnRentalOrder.Rows(i).Item("order_spkworktype").ToString
                .order_spkdesc = Me.tbl_TrnRentalOrder.Rows(i).Item("order_spkdesc")
                .periode_id = Me.tbl_TrnRentalOrder.Rows(i).Item("periode_id").ToString
                If Me.tbl_TrnOrderHistory.Rows.Count > 0 Then
                    .order_revno = Me.tbl_TrnOrderHistory.Rows(i).Item("order_id").ToString.Substring(Me.tbl_TrnOrderHistory.Rows(i).Item("order_id").ToString.IndexOf(",") + 1)
                Else
                    .order_revno = ""
                End If
                .order_revdesc = Me.tbl_TrnRentalOrder.Rows(i).Item("order_revdesc").ToString
                .order_revdate = clsUtil.IsDbNull(Me.tbl_TrnRentalOrder.Rows(i).Item("order_revdate").ToString, "01/01/1999")
                v_order_revdate = Format(.order_revdate, "dd MMM yyyy")
                .order_descr = Me.tbl_TrnRentalOrder.Rows(i).Item("order_descr").ToString

                '.order_discount = Me.tbl_TrnRentalOrder.Rows(i).Item("order_discount")
                .order_discount = Me.order_disc
                .order_insurancecost = Me.tbl_TrnRentalOrder.Rows(i).Item("order_insurancecost")
                .order_transportationcost = Me.tbl_TrnRentalOrder.Rows(i).Item("order_transportationcost")
                .order_operatorcost = Me.tbl_TrnRentalOrder.Rows(i).Item("order_operatorcost")
                .order_othercost = Me.tbl_TrnRentalOrder.Rows(i).Item("order_othercost")
                '.order_pph_percent = Me.tbl_TrnRentalOrder.Rows(i).Item("order_pph_percent")
                '.order_ppn_percent = Me.tbl_TrnRentalOrder.Rows(i).Item("order_ppn_percent")
                .order_Subtotal = Me.order_subtotal
                .order_SubtotalInclDisc = Me.order_subtotal - Me.order_disc
                .order_PPH = Me.order_pph
                .order_PPN = Me.order_ppn

                .order_Total = Me.order_subtotal - .order_discount + .order_insurancecost _
                               + .order_transportationcost + .order_operatorcost + .order_othercost - .order_PPH + .order_PPN

                .order_Terbilang = clsUtil.Terbilang(.order_Total).Trim.ToUpper
                Me.channel_id = .channel_id
                Me.p_channel_id = New Microsoft.Reporting.WinForms.ReportParameter("p_channel_id", .channel_id)
                Me.p_channelname = New Microsoft.Reporting.WinForms.ReportParameter("p_channelname", .channelname)
                Me.p_channeladdr = New Microsoft.Reporting.WinForms.ReportParameter("p_channeladdr", .channeladdr)
                Me.p_channeltelp = New Microsoft.Reporting.WinForms.ReportParameter("p_channeltelp", .channeltelp)
                Me.p_channelfax = New Microsoft.Reporting.WinForms.ReportParameter("p_channelfax", .channelfax)
                Me.p_channelext = New Microsoft.Reporting.WinForms.ReportParameter("p_channelext", .channelext)
                Me.p_domain_name = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", .domain_name)

                Me.p_order_id = New Microsoft.Reporting.WinForms.ReportParameter("p_order_id", .order_id)
                Me.p_request_id = New Microsoft.Reporting.WinForms.ReportParameter("p_request_id", .request_id)
                Me.p_order_date = New Microsoft.Reporting.WinForms.ReportParameter("p_order_date", v_order_date)
                Me.p_rekananro_name = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananro_name", .rekananro_name)
                Me.p_rekananro_alamat = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananro_alamat", .rekananro_alamat)
                Me.p_rekananro_telp = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananro_telp", .rekananro_telpon)
                Me.p_rekananro_fax = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananro_fax", .rekananro_fax)
                Me.p_rekananro_contact = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananro_contact", .firstrekananro_contact)
                Me.p_rekananro_contactphone = New Microsoft.Reporting.WinForms.ReportParameter("p_rekananro_contactphone", .firstrekananro_contactphone)
                Me.p_order_spkrequired = New Microsoft.Reporting.WinForms.ReportParameter("p_order_spkrequired", .order_spkrequired)
                Me.p_order_revno = New Microsoft.Reporting.WinForms.ReportParameter("p_order_revno", .order_revno)
                Me.p_order_revdate = New Microsoft.Reporting.WinForms.ReportParameter("p_order_revdate", v_order_revdate)
                Me.p_order_prognm = New Microsoft.Reporting.WinForms.ReportParameter("p_order_prognm", .order_prognm)
                Me.p_budget_id = New Microsoft.Reporting.WinForms.ReportParameter("p_budget_id", .budget_id)
                Me.p_budget_name = New Microsoft.Reporting.WinForms.ReportParameter("p_budget_name", .budget_name)
                Me.p_order_setdate = New Microsoft.Reporting.WinForms.ReportParameter("p_order_setdate", v_order_setdate)
                Me.p_order_settime = New Microsoft.Reporting.WinForms.ReportParameter("p_order_settime", .order_settime)
                Me.p_order_setlocation = New Microsoft.Reporting.WinForms.ReportParameter("p_order_setlocation", .order_setlocation)
                Me.p_order_utilizeddatestart = New Microsoft.Reporting.WinForms.ReportParameter("p_order_utilizeddatestart", v_order_utilizeddatestart)
                Me.p_order_utilizeddateend = New Microsoft.Reporting.WinForms.ReportParameter("p_order_utilizeddateend", v_order_utilizeddateend)
                Me.p_order_utilizedtimestart = New Microsoft.Reporting.WinForms.ReportParameter("p_order_utilizedtimestart", .order_utilizedtimestart)
                Me.p_order_utilizedlocation = New Microsoft.Reporting.WinForms.ReportParameter("p_order_utilizedlocation", .order_utilizedlocation)
                Me.p_order_canceled = New Microsoft.Reporting.WinForms.ReportParameter("p_order_canceled", .order_canceled)

            End With
            objDatalistROHeader.Add(objTrnROPrintHeader)
        Next

        Return objDatalistROHeader

    End Function

    Private Sub GenerateDataDetail()
        objDatalistTransaksiDetil = New ArrayList()
        Dim objRODetil As DataSource.clsRptOrderDetil3

        Dim i As Integer

        Me.order_subtotal = 0

        For i = 0 To Me.tbl_TrnRentalOrderDetil.Rows.Count - 1

            objRODetil = New DataSource.clsRptOrderDetil3(Me.DSN)
            With objRODetil
                .orderdetil_type = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_type"), "")
                .order_id = Me.tbl_TrnRentalOrderDetil.Rows(i).Item("order_id")
                .item_id = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("item_id"), "")
                .item_name = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("item_name"), "")
                .orderdetil_foreign = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_foreign"), 0)
                .orderdetil_discount = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_discount"), 0)
                .orderdetil_descr = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_descr"), "")
                .orderdetil_days = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_days"), 0)
                .orderdetil_qty = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_qty"), 0)
                .currency_id = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("currency_id"), 0)
                .orderdetil_pph = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_pph"), 0)
                .orderdetil_ppn = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_ppn"), 0)
                .orderdetil_rowtotalforeign = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_rowtotalforeign"), 0)
                .orderdetil_rowtotalidr = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_rowtotalidr"), 0)
                .orderdetil_pphforeign = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_pphforeign"), 0)
                .orderdetil_ppnforeign = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_ppnforeign"), 0)
                Me.orderdetil_disc = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_discount"), 0)
                'Me.orderdetil_disc = clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_discount"), 0) * _
                'clsUtil.IsDbNull(Me.tbl_TrnRentalOrderDetil.Rows(i).Item("orderdetil_qty"), 0)
                If .orderdetil_type = "Item" Then
                    If .currency_id <> 1 Then
                        Me.order_subtotal += .orderdetil_rowtotalforeign
                        Me.order_pph += .orderdetil_pphforeign
                        Me.order_ppn += .orderdetil_ppnforeign
                        Me.order_disc += Me.orderdetil_disc
                    Else
                        Me.order_subtotal += .orderdetil_rowtotalidr
                        Me.order_pph += .orderdetil_pph
                        Me.order_ppn += .orderdetil_ppn
                        Me.order_disc += Me.orderdetil_disc
                    End If
                    If .currency_id = 1 Then
                        Me.order_disc = String.Format("{0:#,##0}", Me.order_disc)
                    Else
                        Me.order_disc = String.Format("{0:#,##0.00}", Me.order_disc)
                    End If
                End If
            End With

            objDatalistTransaksiDetil.Add(objRODetil)
        Next

    End Sub

    Private Sub GenerateDataDetailTOP()
        objDatalistTOPDetil = New ArrayList()
        Dim objTOPDetil As DataSource.clsRptOrderTOPDetil
        'Dim nomorurut As Int64 = 0
        For i As Integer = 0 To Me.tbl_TrnOrderTOPDetil.Rows.Count - 1
            objTOPDetil = New DataSource.clsRptOrderTOPDetil() '(Me.DSN)
            With objTOPDetil
                .order_id = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("order_id"), "")
                .ordertop_line = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("ordertop_line"), 0)
                .orderterm_line = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_line"), 0)
                .orderterm_seq = (i + 1)
                .orderterm_payplant = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_payplant"), 0)
                .orderterm_percent = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_percent"), 0)
                .currency_id = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("currency_id"), 0)
                .orderterm_rate = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_rate"), 0)
                .orderterm_amount = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_amount"), 0)
                .orderterm_status = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_status"), "")
                .orderterm_notes = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("orderterm_notes"), "")
                .isresponse = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("isresponse"), 0)
                .response_id = clsUtil.IsDbNull(Me.tbl_TrnOrderTOPDetil.Rows(i).Item("response_id"), "")
            End With

            objDatalistTOPDetil.Add(objTOPDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("PRC_DataSource_clsRptOrderDetil3", objDatalistTransaksiDetil))
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("PRC_DataSource_clsRptOrderTOPDetil", objDatalistTOPDetil))
    End Sub
    Public Function SetIDCriteria(ByVal str As String, ByVal criteria_history As String, ByVal criteria_TOP As String) As Boolean
        Me.criteria = str
        Me.criteria_history = criteria_history
        Me.criteria_TOP = criteria_TOP
    End Function

    Public Sub New(ByVal sDSN As String, ByVal Preview As Boolean)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        InitializeComponent()

        Me.Preview = Preview
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class