Public Class dlgItemChildRequest 
    Private DSN As String
    Private orderdetil_line As Integer
    Private refrequest_id As String
    Private refrequestdetil_line As Integer
    Private item_names As String
    Private description As String
    Private qty_order As Decimal
    Private unit_order As String
    Private DataFill As clsDataFiller
    Private tbl_requestdetilChild As DataTable = New DataTable

    Public Sub New(ByVal DSN As String, ByVal orderdetil_line As Integer, ByVal refrequest_id As String, ByVal refrequestdetil_line As Integer, ByVal item_names As String, ByVal description As String, ByVal qty_order As Decimal, ByVal unit_order As String)
        InitializeComponent()
        Me.DSN = DSN
        Me.orderdetil_line = orderdetil_line
        Me.refrequest_id = refrequest_id
        Me.refrequestdetil_line = refrequestdetil_line
        Me.item_names = item_names
        Me.description = description
        Me.qty_order = qty_order
        Me.unit_order = unit_order
        Me.DataFill = New clsDataFiller(Me.DSN)
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function RetrieveChildFromRequest() As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing
        Dim reason As String = String.Empty
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("pr_TrnOrderDetil_ChildRequest_Select", dbConn)
        dbCmd.Parameters.Add("@request_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters.Add("@requestdetil_line", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@request_id").Value = Me.refrequest_id
        dbCmd.Parameters("@requestdetil_line").Value = Me.refrequestdetil_line

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_requestdetilChild.Clear()

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_requestdetilChild)
            Me.GC_RequestDetilChild.DataSource = Me.tbl_requestdetilChild
            If Me.tbl_requestdetilChild.Rows.Count <= 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New Exception("Not Retrieve" & vbCrLf & ex.Message)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Sub dlgItemChildRequest_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.obj_orderdetilline.Text = Me.orderdetil_line
        Me.obj_item.Text = Me.item_names
        Me.obj_descr.Text = Me.description
        Me.obj_request_id.Text = Me.refrequest_id
        Me.obj_requestdetil_line.Text = Me.refrequestdetil_line
        Me.obj_qty.Text = qty_order
        Me.obj_unit.Text = unit_order

        If Me.RetrieveChildFromRequest() = False Then
            MsgBox("Dont have item child !", MsgBoxStyle.Information, "Information")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub
End Class