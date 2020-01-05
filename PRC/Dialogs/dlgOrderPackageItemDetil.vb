Public Class dlgOrderPackageItemDetil
    Private tbl_requestdetilpackage As DataTable = New DataTable
    Private line As Int64
    Private item As String

    Public Sub New(ByVal tbl_requestdetilpackage As DataTable, ByVal item As String, Optional ByRef line As Int64 = 0)
        InitializeComponent()
        Me.line = line
        Me.item = item

        Me.tbl_requestdetilpackage = tbl_requestdetilpackage.Copy
    End Sub

    Private Sub dlgOrderPackageItemDetil_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.obj_line.Text = Me.line
        'Me.obj_item.Text = Me.item
        Me.GC_DetilPackage.DataSource = Me.tbl_requestdetilpackage
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class