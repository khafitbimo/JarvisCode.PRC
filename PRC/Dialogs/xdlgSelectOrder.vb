Public Class xdlgSelectOrder 
    Private DSN As String
    Private objTbl As DataTable = New DataTable

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Me.Retrieve(Me.objTbl, String.Format(" order_id = '{0}'", Me.objSearchOrder.EditValue))
    End Sub

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            If Me.objSearchOrder.EditValue = "" Then
                MsgBox("Masukan no order !!")
                Exit Sub
            End If

            objTbl.Clear()
            Me.gcSelectOrder.DataSource = Nothing
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "ov_TrnOrdervoid_SelectOrderToVoid", Criteria)
                'as_TrnOrder_SelectToVoid
            End Using
            Me.gcSelectOrder.DataSource = Me.objTbl
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New(ByVal _dsn As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DSN = _dsn
    End Sub

    Private Sub btnPick_Click(sender As Object, e As EventArgs) Handles btnPick.Click
        If Me.gvSelectOrder.RowCount > 0 Then
            If Me.gvSelectOrder.FocusedRowHandle > -1 Then
                If Me.gvSelectOrder.GetFocusedRowCellValue("flag") <> 0 Then
                    MsgBox("data has response by RV/OR/PV !!")
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class