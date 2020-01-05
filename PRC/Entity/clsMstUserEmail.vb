Public Class clsMstUserEmail

    Private DSN As String

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub
#End Region

    Public Function [Select](ByVal username As String) As Specialized.OrderedDictionary
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader = Nothing
        Dim res As New Specialized.OrderedDictionary
        Dim criteria As String
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            criteria = String.Format("A.user_emaildefault = 1 AND B.user_isdisabled = 0 AND B.username = '{0}'", username)

            cmd = New OleDb.OleDbCommand("ms_MstUserContactEmail_Select", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@criteria", criteria)

            ' cmd.ExecuteNonQuery()
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
            reader.Close()
        End Try

        Return res
    End Function

    Public Function [SelectCheckIsDelegate](ByVal username As String) As Specialized.OrderedDictionary
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader = Nothing
        Dim res As New Specialized.OrderedDictionary
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("dg_checkuser_isdelegate", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@username", username)

            ' cmd.ExecuteNonQuery()
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
            reader.Close()
        End Try

        Return res
    End Function
End Class
