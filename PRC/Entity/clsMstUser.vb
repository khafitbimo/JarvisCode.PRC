Public Class clsMstUser : Implements IDisposable


    Private DSN As String

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub
#End Region

    Public Function [Select](ByVal username As String) As Specialized.OrderedDictionary
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader
        Dim criteria As String
        Dim res As New Specialized.OrderedDictionary
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            criteria = String.Format(" username = '{0}'", username)

            cmd = New OleDb.OleDbCommand("ms_MstUser_Select", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@criteria", criteria)

            cmd.ExecuteNonQuery()
            reader = cmd.ExecuteReader()

            For i As Integer = 0 To reader.FieldCount - 1
                res.Add(reader.GetName(i), DBNull.Value)
            Next

            If reader.HasRows = True Then
                While reader.Read()
                    For i As Integer = 0 To reader.FieldCount - 1
                        res.Item(i) = reader.Item(i)
                    Next
                End While
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return res
    End Function

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "ms_MstUser_Select")
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
