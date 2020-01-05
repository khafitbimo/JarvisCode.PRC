Public Class uiUpdateAfterDataMigration
    'Dim newdetil_line As Integer
    'Dim newitem_line As Integer

    'Dim tblmaster As DataTable = clsDataset.CreateTblTrnOrder_migrasi()
    'Dim tbldetil As DataTable = clsDataset.CreateTblTrnOrderdetil_migrasi()
    'Dim tbldetil_Changes As DataTable


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim order_id, criteria, kriteria, item_id As String
    '    Dim i, j As Integer
    '    Dim success As Boolean

    '    'criteria = " ordertype_id='" & Me.txtSource.Text & "' and channel_id='" & Me.txtChannel.Text + "'"
    '    criteria = " left(order_id, 2)='" & Me.txtSource.Text & "' and  channel_id='" & Me.txtChannel.Text + "'"

    '    tblmaster.Clear()
    '    Try
    '        Me.DataFill(tblmaster, "pr_TrnOrderdetil_Select_ie", criteria)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If tblmaster.Rows.Count > 0 Then
    '        For i = 0 To tblmaster.Rows.Count - 1
    '            order_id = tblmaster.Rows(i)("order_id").ToString
    '            kriteria = "order_id='" & order_id & _
    '                        "' and channel_id='" & Me.txtChannel.Text & "'"

    '            tbldetil.Clear()
    '            Try
    '                Me.DataFill(tbldetil, "pr_TrnOrderdetil_Select_ieo", kriteria)
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try

    '            If tbldetil.Rows.Count > 0 Then
    '                For j = 0 To tbldetil.Rows.Count - 1

    '                    tbldetil.Rows(j).SetModified()
    '                    Me.BindingContext(tbldetil).EndCurrentEdit()
    '                    tbldetil_Changes = tbldetil.GetChanges()

    '                    item_id = tbldetil.Rows(j)("item_id").ToString
    '                    Me.newdetil_line = (j + 1) * 10
    '                    success = Me.uiUpdateAfterDataMigration_UpdateRow(order_id, item_id, tbldetil_Changes, DataRowState.Modified)
    '                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnRentalOrder_SaveDetil(tbl_TrnOrderdetil_Changes)")
    '                    tbldetil.AcceptChanges()

    '                Next
    '            End If
    '        Next
    '        MessageBox.Show("Selesai.....")
    '    End If


    'End Sub

    'Private Function uiUpdateAfterDataMigration_UpdateRow(ByRef order_id As Object, ByRef item_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Dim dbCmdUpdate As OleDb.OleDbCommand
    '    Dim dbDA As OleDb.OleDbDataAdapter

    '    ' Save data: transaksi_orderdetil

    '    dbCmdUpdate = New OleDb.OleDbCommand("pr_TrnOrderdetil_UpdateLine", dbConn)
    '    dbCmdUpdate.CommandType = CommandType.StoredProcedure
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 40, "item_id"))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
    '    dbCmdUpdate.Parameters("@order_id").Value = order_id
    '    dbCmdUpdate.Parameters("@orderdetil_line").Value = Me.newdetil_line

    '    dbDA = New OleDb.OleDbDataAdapter
    '    dbDA.UpdateCommand = dbCmdUpdate

    '    Try
    '        dbConn.Open()
    '        'dbDA.Update(objTbl)
    '        dbDA.Update(tbldetil_Changes)

    '    Catch ex As Data.OleDb.OleDbException
    '        MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return False
    '    Finally
    '        dbConn.Close()
    '    End Try

    '    Return True
    'End Function

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim cat_id, criteria, kriteria, item_id As String
    '    Dim i, j As Integer
    '    Dim success As Boolean

    '    criteria = ""
    '    '
    '    tblmaster.Clear()
    '    Try
    '        Me.DataFill(tblmaster, "pr_MstRentalcategory_Select", criteria)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If tblmaster.Rows.Count > 0 Then
    '        For i = 0 To tblmaster.Rows.Count - 1
    '            cat_id = tblmaster.Rows(i)("category_id").ToString
    '            kriteria = "category_id='" & cat_id & "'"

    '            tbldetil.Clear()
    '            Try
    '                Me.DataFill(tbldetil, "pr_MstRentalitem_Select", kriteria)
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try

    '            If tbldetil.Rows.Count > 0 Then
    '                For j = 0 To tbldetil.Rows.Count - 1

    '                    tbldetil.Rows(j).SetModified()
    '                    Me.BindingContext(tbldetil).EndCurrentEdit()
    '                    tbldetil_Changes = tbldetil.GetChanges()

    '                    item_id = tbldetil.Rows(j)("item_id").ToString
    '                    Me.newitem_line = (j + 1)
    '                    success = Me.uiUpdateAfterDataMigration_UpdateItemRow(cat_id, item_id, tbldetil_Changes, DataRowState.Modified)
    '                    'If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnRentalOrder_SaveDetil(tbl_TrnOrderdetil_Changes)")
    '                    tbldetil.AcceptChanges()

    '                Next
    '            End If
    '        Next
    '        MessageBox.Show("Selesai.....")
    '    End If

    'End Sub

    'Private Function uiUpdateAfterDataMigration_UpdateItemRow(ByRef cat_id As Object, ByRef item_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Dim dbCmdUpdate As OleDb.OleDbCommand
    '    Dim dbDA As OleDb.OleDbDataAdapter

    '    ' Save data: transaksi_orderdetil

    '    dbCmdUpdate = New OleDb.OleDbCommand("pr_MstRentalitem_UpdateLine", dbConn)
    '    dbCmdUpdate.CommandType = CommandType.StoredProcedure
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@category_id", System.Data.OleDb.OleDbType.VarWChar, 30))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_line", System.Data.OleDb.OleDbType.Integer, 4))
    '    dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 40, "item_id"))
    '    dbCmdUpdate.Parameters("@category_id").Value = cat_id
    '    dbCmdUpdate.Parameters("@item_line").Value = Me.newitem_line

    '    dbDA = New OleDb.OleDbDataAdapter
    '    dbDA.UpdateCommand = dbCmdUpdate

    '    Try
    '        dbConn.Open()
    '        'dbDA.Update(objTbl)
    '        dbDA.Update(tbldetil_Changes)

    '    Catch ex As Data.OleDb.OleDbException
    '        MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return False
    '    Finally
    '        dbConn.Close()
    '    End Try

    '    Return True
    'End Function


End Class
