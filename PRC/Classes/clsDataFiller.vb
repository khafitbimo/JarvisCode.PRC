
Public Class clsDataFiller : Implements IDisposable

    Private mDSN As String

#Region " Constructor "
    Public Sub New(ByVal dsn As String)
        Me.mDSN = dsn
    End Sub
#End Region

    Public Sub DataFill(ByVal tbl As DataTable, ByVal procedure As String, ByVal ParamArray par As OleDb.OleDbParameter())
        Dim dbConn As New OleDb.OleDbConnection(Me.mDSN)
        Dim cmd As OleDb.OleDbCommand
        Dim dbDa As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        Try
            cmd = New OleDb.OleDbCommand(procedure, dbConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddRange(par)

            dbDa = New OleDb.OleDbDataAdapter(cmd)

            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDa.Fill(tbl)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

    End Sub

    Public Function DataFill(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True

    End Function

    Public Function DataFill(ByRef dbConn As OleDb.OleDbConnection, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        End Try

        Return True

    End Function

    Public Function DataFill2(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal OtherCriteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.Parameters.Add("@OtherCriteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@OtherCriteria").Value = OtherCriteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True

    End Function

    Public Function DataFill4(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal Ordertype As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.Parameters.Add("@Date1", Data.OleDb.OleDbType.Date)
        dbCmd.Parameters("@Date1").Value = Date1

        dbCmd.Parameters.Add("@Date2", Data.OleDb.OleDbType.Date)
        dbCmd.Parameters("@Date2").Value = Date2

        dbCmd.Parameters.Add("@Ordertype", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Ordertype").Value = Ordertype

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True
    End Function

    Public Function DataFill5(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal OtherCriteria As String, ByVal Date1 As Date, ByVal Date2 As Date, ByVal Ordertype As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.Parameters.Add("@OtherCriteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@OtherCriteria").Value = OtherCriteria

        dbCmd.Parameters.Add("@Date1", Data.OleDb.OleDbType.Date)
        dbCmd.Parameters("@Date1").Value = Date1

        dbCmd.Parameters.Add("@Date2", Data.OleDb.OleDbType.Date)
        dbCmd.Parameters("@Date2").Value = Date2

        dbCmd.Parameters.Add("@Ordertype", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Ordertype").Value = Ordertype

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True

    End Function

    Public Function DataFillLimit(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal limit As Integer, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.Parameters.Add("@Limit", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@Limit").Value = limit

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 360000
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True

    End Function

    Public Function DataFillForCombo(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        Return True
    End Function

    Public Function ComboFill(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboFillNumeric(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = "0"
        'datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboLink(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal withOption As Boolean) As Boolean
        Dim row As System.Data.DataRow

        If withOption Then
            row = datatable.NewRow
            row.Item(valuemember) = "0"

            datatable.Rows.InsertAt(row, 0)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ListBoxFill(ByRef listbox As ListBox, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        'Dim row As System.Data.DataRow

        datatable.Clear()
        'row = datatable.NewRow
        'row.Item(valuemember) = "0"
        'row.Item(displaymember) = "-- PILIH --"
        'datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        listbox.DataSource = datatable
        listbox.DisplayMember = displaymember

        Return True
    End Function

    Public Function DataFillBudgetdetilAmount(ByRef datatable As DataTable, ByVal procedure As String, ByVal budget_id As Decimal, ByVal budgetdetil_id As Decimal) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        dbCmd.Parameters.Add("@budget_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@budget_id").Value = budget_id
        dbCmd.Parameters.Add("@budgetdetil_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@budgetdetil_id").Value = budgetdetil_id

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try

        Return True
    End Function

    Public Function ComboFillDX(ByRef combobox As DevExpress.XtraEditors.LookUpEdit, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.Properties.DataSource = datatable
        combobox.Properties.ValueMember = valuemember
        combobox.Properties.DisplayMember = displaymember

        'combobox.Properties.PopulateColumns()
        combobox.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(displaymember, 100, ""))
        combobox.Properties.ShowHeader = False

        Return True
    End Function

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
