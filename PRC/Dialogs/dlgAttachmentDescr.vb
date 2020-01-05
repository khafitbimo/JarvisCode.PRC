Public Class dlgAttachmentDescr

    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        If Me.obj_attachmentdscr.Text = "" Then
            MsgBox("file name must be filled !", MsgBoxStyle.Exclamation, "Attention")
            Exit Sub
        End If
        If Me.obj_doctype.EditValue = "--Pilih--" Then
            MsgBox("Please select document type first !", MsgBoxStyle.Exclamation, "Attention")
            Exit Sub
        End If

        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Public Sub New(ByVal default_description As String)
        InitializeComponent()
        Me.obj_attachmentdscr.Text = default_description
        Me.obj_doctype.EditValue = "--Pilih--"
    End Sub
End Class