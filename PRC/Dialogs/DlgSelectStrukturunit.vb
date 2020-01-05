Imports System.Windows.Forms

Public Class DlgSelectStrukturunit

    Private DSN As String
    Private tbl_MstStrukturunit As DataTable = clsDataset.CreateTblMstStrukturUnit()

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.InitializeComponent()

        Me.DSN = DSN
    End Sub
#End Region

    Private Sub Retrieve()
        Try
            Me.tbl_MstStrukturunit.Clear()

            Using s As New clsMstStrukturunit(Me.DSN)
                s.Retrieve(Me.tbl_MstStrukturunit, "")
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DlgSelectStrukturunit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DgvStrukturUnit.AutoGenerateColumns = False
        Me.DgvStrukturUnit.DataSource = Me.tbl_MstStrukturunit

        Me.Retrieve()
    End Sub

    Private Sub DgvStrukturUnit_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvStrukturUnit.CellDoubleClick
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            Me.btnOK.PerformClick()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DgvStrukturUnit_SelectionChanged(sender As Object, e As EventArgs) Handles DgvStrukturUnit.SelectionChanged
        If Me.DgvStrukturUnit.CurrentRow IsNot Nothing Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub obj_strukturunit_name_TextChanged(sender As Object, e As EventArgs) Handles obj_strukturunit_name.TextChanged
        Me.tbl_MstStrukturunit.DefaultView.RowFilter = String.Format("strukturunit_name like '%{0}%'", Me.obj_strukturunit_name.Text)
    End Sub
End Class
