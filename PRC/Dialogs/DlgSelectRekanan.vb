Imports System.Windows.Forms

Public Class DlgSelectRekanan

    Private DSN As String

    Private tbl_SelectVendor As DataTable = clsDataset2.CreateTblMstrekanan()

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.InitializeComponent()
        Me.DSN = DSN
    End Sub
#End Region

    Private Sub Retrieve()
        Try
            Dim criteria As String

            criteria = " rekanan_active = 1"

            Me.tbl_SelectVendor.Clear()

            Using item As New clsMstRekanan(Me.DSN)
                item.Retrieve(Me.tbl_SelectVendor, criteria)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvSelectVendor_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        obj_search.Focus()
    End Sub

    Private Sub dgvSelectVendor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.dgvSelectVendor.AutoGenerateColumns = False
        Me.dgvSelectVendor.DataSource = Me.tbl_SelectVendor

        Me.tbl_SelectVendor.DefaultView.Sort = "rekanan_name"
        Me.Retrieve()
    End Sub

    Private Sub dgvSelectVendor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSelectVendor.CellDoubleClick
        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub obj_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search.TextChanged
        Me.tbl_SelectVendor.DefaultView.RowFilter = String.Format("rekanan_name like '%{0}%'", Me.obj_search.Text)
    End Sub

    Private Sub DgvMstItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If Me.dgvSelectVendor.CurrentRow IsNot Nothing Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub


End Class
