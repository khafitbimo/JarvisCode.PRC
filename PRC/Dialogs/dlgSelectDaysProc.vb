Imports System.Windows.Forms

Public Class dlgSelectDaysProc
    Private CloseButtonIsPressed As Boolean
    Private tbl_temp As DataTable = New DataTable
    Private source As String
    Private retObj As Object
    Private order_id As String
    Private orderdetil_line As Integer

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function FormatDgvOrderComplete_OrderDetilUsage(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_checked As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrderdetiluse_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_actual As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_actualnote As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 60
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = True


        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "Utlzd Line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 50
        cOrderdetiluse_line.Visible = True
        cOrderdetiluse_line.ReadOnly = True


        cOrderdetiluse_checked.Name = "orderdetiluse_checked"
        cOrderdetiluse_checked.HeaderText = "Use"
        cOrderdetiluse_checked.DataPropertyName = "orderdetiluse_checked"
        cOrderdetiluse_checked.Width = 30
        cOrderdetiluse_checked.Visible = True
        cOrderdetiluse_checked.ReadOnly = True

        cOrderdetiluse_date.Name = "orderdetiluse_date"
        cOrderdetiluse_date.HeaderText = "Date"
        cOrderdetiluse_date.DataPropertyName = "orderdetiluse_date"
        cOrderdetiluse_date.Width = 70
        cOrderdetiluse_date.Visible = True
        cOrderdetiluse_date.ReadOnly = False

        cOrderdetiluse_descr.Name = "orderdetiluse_descr"
        cOrderdetiluse_descr.HeaderText = "Descr"
        cOrderdetiluse_descr.DataPropertyName = "orderdetiluse_descr"
        cOrderdetiluse_descr.Width = 100
        cOrderdetiluse_descr.Visible = True
        cOrderdetiluse_descr.ReadOnly = False

        cOrderdetiluse_qty.Name = "orderdetiluse_qty"
        cOrderdetiluse_qty.HeaderText = "Qty"
        cOrderdetiluse_qty.DataPropertyName = "orderdetiluse_qty"
        cOrderdetiluse_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_qty.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_qty.Width = 40
        cOrderdetiluse_qty.Visible = True
        cOrderdetiluse_qty.ReadOnly = False

        cOrderdetiluse_idr.Name = "orderdetiluse_idr"
        cOrderdetiluse_idr.HeaderText = "IDR"
        cOrderdetiluse_idr.DataPropertyName = "orderdetiluse_idr"
        cOrderdetiluse_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_idr.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetiluse_idr.Width = 70
        cOrderdetiluse_idr.Visible = False
        cOrderdetiluse_idr.ReadOnly = True

        cOrderdetiluse_actual.Name = "orderdetiluse_actual"
        cOrderdetiluse_actual.HeaderText = "orderdetiluse_actual"
        cOrderdetiluse_actual.DataPropertyName = "orderdetiluse_actual"
        cOrderdetiluse_actual.Width = 100
        cOrderdetiluse_actual.Visible = False
        cOrderdetiluse_actual.ReadOnly = False

        cOrderdetiluse_actualnote.Name = "orderdetiluse_actualnote"
        cOrderdetiluse_actualnote.HeaderText = "orderdetiluse_actualnote"
        cOrderdetiluse_actualnote.DataPropertyName = "orderdetiluse_actualnote"
        cOrderdetiluse_actualnote.Width = 100
        cOrderdetiluse_actualnote.Visible = False
        cOrderdetiluse_actualnote.ReadOnly = False


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = False
        objDgv.AutoGenerateColumns = False
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
            cOrder_id, _
            cOrderdetil_line, _
            cOrderdetiluse_line, _
            cOrderdetiluse_checked, _
            cOrderdetiluse_date, _
            cOrderdetiluse_descr, _
            cOrderdetiluse_qty, _
            cOrderdetiluse_idr, _
            cOrderdetiluse_actual, _
            cOrderdetiluse_actualnote _
        })

    End Function

    Private Function FormatDgvOrderComplete_OrderDetilUsageProc(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_checked As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrderdetiluse_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        ' Dim cOrderdetiluse_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRemark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 60
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = True
       
        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "Utlzd Line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 50
        cOrderdetiluse_line.Visible = True
        cOrderdetiluse_line.ReadOnly = True


        cOrderdetiluse_checked.Name = "orderdetiluse_checked"
        cOrderdetiluse_checked.HeaderText = "Use"
        cOrderdetiluse_checked.DataPropertyName = "orderdetiluse_checked"
        cOrderdetiluse_checked.Width = 30
        cOrderdetiluse_checked.Visible = True
        cOrderdetiluse_checked.ReadOnly = False

        cOrderdetiluse_date.Name = "orderdetiluse_date"
        cOrderdetiluse_date.HeaderText = "Date"
        cOrderdetiluse_date.DataPropertyName = "orderdetiluse_date"
        cOrderdetiluse_date.Width = 70
        cOrderdetiluse_date.Visible = True
        cOrderdetiluse_date.ReadOnly = True

        cOrderdetiluse_qty.Name = "orderdetiluse_qty"
        cOrderdetiluse_qty.HeaderText = "Qty"
        cOrderdetiluse_qty.DataPropertyName = "orderdetiluse_qty"
        cOrderdetiluse_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_qty.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_qty.Width = 40
        cOrderdetiluse_qty.Visible = True
        cOrderdetiluse_qty.ReadOnly = False

        cRemark.Name = "remark"
        cRemark.HeaderText = "Remark"
        cRemark.DataPropertyName = "remark"
        cRemark.Width = 150
        cRemark.Visible = True
        cRemark.ReadOnly = False

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.AutoGenerateColumns = False
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
            cOrder_id, _
            cOrderdetil_line, _
            cOrderdetiluse_line, _
            cOrderdetiluse_checked, _
            cOrderdetiluse_date, _
            cOrderdetiluse_qty, _
            cRemark})

    End Function


    Sub New(ByVal order_id As String, ByVal orderdetil_line As Int32, ByVal item_id As String, ByVal tbl_temp As DataTable, ByVal DSN As String, ByVal Source As String)
        ' This call is required by the designer.
        InitializeComponent()

        Me.order_id = order_id
        Me.orderdetil_line = orderdetil_line

        Me.obj_orderid.Text = order_id
        Me.obj_orderline.Text = orderdetil_line
        Me.obj_itemid.Text = item_id

        Me.source = Source

        Me.tbl_temp.Clear()
        If Me.source = "Usage Order" Then
            Me.Text = "Usage Order"
            Me.tbl_temp = tbl_temp
            Me.tbl_temp.DefaultView.RowFilter = "order_id='" & order_id & "' and orderdetil_line=" & orderdetil_line
            'tbl_temp.DefaultView.RowFilter = "order_id='" & order_id & "' and orderdetil_line=" & orderdetil_line & " and orderdetiluse_checked=1"
            Me.FormatDgvOrderComplete_OrderDetilUsage(Me.dgvSelectDays)
            Me.dgvSelectDays.DataSource = Me.tbl_temp
        ElseIf Me.source = "Usage Notes" Then
            Me.Text = "Usage Notes Procurement"
            Me.tbl_temp = tbl_temp
            Me.tbl_temp.DefaultView.RowFilter = "order_id='" & order_id & "' and orderdetil_line=" & orderdetil_line
            'tbl_temp.DefaultView.RowFilter = "order_id='" & order_id & "' and orderdetil_line=" & orderdetil_line & " and orderdetiluse_checked=1"
            Me.FormatDgvOrderComplete_OrderDetilUsageProc(Me.dgvSelectDays)
            'Me.FormatDgvOrderComplete_OrderDetilUsage(Me.dgvSelectDays)
            Me.dgvSelectDays.DataSource = Me.tbl_temp
        End If

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.source = "Usage Notes" Then
            Me.tbl_temp.GetChanges()
            Me.tbl_temp.DefaultView.RowFilter = "order_id='" & Me.order_id & "' and orderdetil_line=" & Me.orderdetil_line

            Dim a As Integer = 0
            For i As Integer = 0 To Me.dgvSelectDays.Rows.Count - 1
                If Me.dgvSelectDays.Rows(i).Cells("orderdetiluse_checked").Value = True Then
                    a += 1
                End If
            Next

            lbl_days.Text = a
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvSelectDays_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelectDays.CellClick
        If Me.source = "Usage Notes" Then
            Select Case e.ColumnIndex
                Case Me.dgvSelectDays.Columns("orderdetiluse_checked").Index
                    If e.RowIndex < 0 Then
                        Exit Sub
                    End If

                    Dim order_id As String
                    Dim orderdetil_line As Integer
                    Dim orderdetiluse_line As Integer

                    order_id = Me.dgvSelectDays.Rows(e.RowIndex).Cells("order_id").Value
                    orderdetil_line = Me.dgvSelectDays.Rows(e.RowIndex).Cells("orderdetil_line").Value
                    orderdetiluse_line = Me.dgvSelectDays.Rows(e.RowIndex).Cells("orderdetiluse_line").Value

                    If Me.dgvSelectDays.Rows(e.RowIndex).Cells("orderdetiluse_checked").Value = 0 Then
                        For i As Integer = 0 To tbl_temp.Rows.Count - 1
                            Dim order_idtemp As String
                            Dim orderdetil_linetemp As Integer
                            Dim orderdetiluse_linetemp As Integer

                            order_idtemp = Me.tbl_temp.Rows(i).Item("order_id")
                            orderdetil_linetemp = Me.tbl_temp.Rows(i).Item("orderdetil_line")
                            orderdetiluse_linetemp = Me.tbl_temp.Rows(i).Item("orderdetiluse_line")

                            If order_idtemp = order_id And orderdetil_linetemp = orderdetil_line And orderdetiluse_linetemp = orderdetiluse_line Then
                                Me.tbl_temp.Rows(i).Item("orderdetiluse_checked") = 1
                                Me.tbl_temp.GetChanges()
                            End If
                        Next
                    Else

                        For q As Integer = 0 To tbl_temp.Rows.Count - 1
                            Dim order_idtemp As String
                            Dim orderdetil_linetemp As Integer
                            Dim orderdetiluse_linetemp As Integer

                            order_idtemp = Me.tbl_temp.Rows(q).Item("order_id")
                            orderdetil_linetemp = Me.tbl_temp.Rows(q).Item("orderdetil_line")
                            orderdetiluse_linetemp = Me.tbl_temp.Rows(q).Item("orderdetiluse_line")

                            If order_idtemp = order_id And orderdetil_linetemp = orderdetil_line And orderdetiluse_linetemp = orderdetiluse_line Then
                                Me.tbl_temp.Rows(q).Item("orderdetiluse_checked") = 0
                                Me.tbl_temp.GetChanges()
                            End If
                        Next

                    End If


            End Select
        End If
        


    End Sub
End Class
