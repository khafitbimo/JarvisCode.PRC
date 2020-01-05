Public Class dlgTOPPercentTools 
    Private amount_order As Decimal = 0
    Private percent As Decimal = 0
    Private amountaftpercent As Decimal = 0


    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        If Me.amountaftpercent <> 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal DSN As String, ByVal channel_id As String, ByVal Amount_order As Decimal)
        InitializeComponent()
        Me.amount_order = Amount_order
        Me.obj_amount_order.Text = Me.amount_order
    End Sub

    Private Sub obj_percent_EditValueChanged(sender As Object, e As EventArgs) Handles obj_percent.EditValueChanged
        If obj_percent.Text <> "" Then
            Me.amountaftpercent = 0
            percent = CType(Me.obj_percent.Text, Decimal)
            Me.amountaftpercent = (percent / 100) * Me.amount_order
            Me.obj_amountaftpercent.Text = Me.amountaftpercent
        End If

    End Sub

   
End Class