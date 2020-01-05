Public Class clsMstRekanan : Implements IDisposable

    Private DSN As String
    Private filler As clsDataFiller

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
        Me.filler = New clsDataFiller(Me.DSN)
    End Sub

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal criteria As String)
        Try
            Me.filler.DataFill(objTbl, "ms_MstRekanan_Select2", criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


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

