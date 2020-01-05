Imports System.Windows.Forms

Public Class clsTrnOrderDetilReport : Implements IDisposable
    Private channel_id As String
    Private DSN As String
    Private filler As clsDataFiller

    Private tbl_ReportDetail As DataTable


#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.channel_id = channel_id
        Me.DSN = DSN
        Me.filler = New clsDataFiller(Me.DSN)
    End Sub
#End Region


#Region " Printing "

    Public Sub Print(ByVal objReportViewer As Microsoft.Reporting.WinForms.ReportViewer, ByVal startDSN As String, ByVal tbl_OrderDetil As DataTable, ByVal obj_vendor_srch As String, ByVal obj_department_srch As String, ByVal obj_currency As String, _
                     ByVal chk_vendor As Boolean, ByVal chk_curr As Boolean, ByVal chk_department As Boolean, Optional ByVal Preview As Boolean = False)
        Dim objReportH As New Microsoft.Reporting.WinForms.LocalReport
        Dim obj As New Microsoft.Reporting.WinForms.ReportDataSource
        Dim params(2) As Microsoft.Reporting.WinForms.ReportParameter
        Dim vendor As String
        Dim department As String
        Dim curr As String

        If chk_vendor = True Then
            vendor = obj_vendor_srch
        Else
            vendor = " "
        End If

        params(0) = New Microsoft.Reporting.WinForms.ReportParameter("parVendorName", vendor)


        If chk_curr = True Then
            curr = obj_currency
        Else
            curr = " "
        End If

        params(1) = New Microsoft.Reporting.WinForms.ReportParameter("parCurName", curr)

        If chk_department = True Then
            department = obj_department_srch
        Else
            department = " "
        End If

        params(2) = New Microsoft.Reporting.WinForms.ReportParameter("parDepartment", department)

        Me.tbl_ReportDetail = tbl_OrderDetil

        obj.Name = "DataSet1"
        obj.Value = tbl_OrderDetil

        objReportH.ReportEmbeddedResource = "PRC.RptTrnOrderDetilReport.rdlc"
        objReportH.DataSources.Add(obj)
        objReportH.EnableExternalImages = True

        If Preview = True Then
            'Dim objReportViewer As New Microsoft.Reporting.WinForms.ReportViewer()
            objReportViewer.Clear()
            objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
            objReportViewer.LocalReport.EnableExternalImages = True
            objReportViewer.LocalReport.SetParameters(params)
            objReportViewer.LocalReport.DataSources.Clear()
            objReportViewer.LocalReport.DataSources.Add(obj)
            objReportViewer.Dock = DockStyle.Fill
            objReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            objReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
            objReportViewer.ZoomPercent = 25
            objReportViewer.RefreshReport()

            'CType(Container, Panel).Controls.Add(objReportViewer)
        Else
        End If
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Me.tbl_ReportDetail))
    End Sub
#End Region

#Region " IDisposable Support "
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free managed resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
