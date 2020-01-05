Public Class dlgNewItemGroup

    Private Sub rbtGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGroup.CheckedChanged
        If Me.rbtGroup.Checked Then
            Me.Text = "New Group"

        End If

    End Sub

    Private Sub rbtCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCategory.CheckedChanged
        If Me.rbtCategory.Checked Then
            Me.Text = "New Category"

        End If

    End Sub
End Class