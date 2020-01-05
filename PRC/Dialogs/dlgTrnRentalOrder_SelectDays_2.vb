Public Class dlgTrnRentalOrder_SelectDays_2
    Dim CloseButtonIsPressed As Boolean
    Dim retObj As hapus_uiTrnRentalOrder2.SelectDaysDialogReturn = New hapus_uiTrnRentalOrder2.SelectDaysDialogReturn()

    Private tbl_MstRentalItemGrid As DataTable = clsDataset.CreateTblMstItem
    Private tbl_trnOrderdetiluse As DataTable = clsDataset.CreateTblTrnOrderdetiluse()

#Region " UI and Layout "

    Private Function FormatDgvTrnOrderdetiluse(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

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
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "orderdetil_line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = True

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "Line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 30
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
        cOrderdetiluse_date.Width = 100
        cOrderdetiluse_date.Visible = True
        cOrderdetiluse_date.ReadOnly = True

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
        cOrderdetiluse_qty.ReadOnly = True

        cOrderdetiluse_idr.Name = "orderdetiluse_idr"
        cOrderdetiluse_idr.HeaderText = "IDR"
        cOrderdetiluse_idr.DataPropertyName = "orderdetiluse_idr"
        cOrderdetiluse_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetiluse_idr.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetiluse_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetiluse_idr.Width = 70
        cOrderdetiluse_idr.Visible = True
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

        objDgv.ReadOnly = True
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
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

#End Region

#Region " Opener "

    Public Shadows Function OpenDialog(ByRef tblOrderdetiluse As DataTable, ByRef tblItem As DataTable, _
    ByRef order_setdate As Date, ByRef order_utilizeddatestart As Date, ByRef order_utilizeddateend As Date, _
    ByRef orderdetil_line As Integer, ByRef orderdetil_descr As String, ByRef orderdetil_idr As Decimal, ByRef orderdetil_qty As Decimal, ByRef item_id As String, ByVal owner As System.Windows.Forms.IWin32Window) As Object

        Me.tbl_MstRentalItemGrid = tblItem
        Me.tbl_trnOrderdetiluse.Merge(tblOrderdetiluse, True)

        Me.obj_RentalItem_id.DataSource = Me.tbl_MstRentalItemGrid
        Me.obj_RentalItem_id.DisplayMember = "item_name"
        Me.obj_RentalItem_id.ValueMember = "item_id"

        Me.retObj.item_id = item_id
        Me.retObj.orderdetil_line = orderdetil_line
        Me.retObj.orderdetil_descr = orderdetil_descr
        Me.retObj.orderdetil_qty = orderdetil_qty
        Me.retObj.orderdetil_idr = orderdetil_idr

        Me.retObj.order_setdate = order_setdate
        Me.retObj.order_utilizeddatestart = order_utilizeddatestart
        Me.retObj.order_utilizeddateend = order_utilizeddateend

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            tblOrderdetiluse = Me.tbl_trnOrderdetiluse
            Return retObj
        Else
            Return Nothing
        End If
    End Function

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Dim obj As Button = sender

        If obj.Name = "btnOK" Then
            Me.CloseButtonIsPressed = True

            Dim qty As Decimal = 0
            Dim qtys As Decimal = 0
            Dim days As Decimal = 0
            Dim rowFilter As String
            Dim rows() As DataRow
            Dim j As Integer
            If Me.tbl_trnOrderdetiluse IsNot Nothing Then
                rowFilter = String.Format("orderdetil_line={0}", Me.retObj.orderdetil_line)
                rows = Me.tbl_trnOrderdetiluse.Select(rowFilter)
                For j = 0 To rows.Length - 1
                    If rows(j).Item("orderdetiluse_checked") Then
                        qty = rows(j).Item("orderdetiluse_qty")
                        days = days + 1
                        qtys = qtys + qty
                    End If
                Next
            End If

            Me.retObj.orderdetil_days = days

            If days > 0 Then
                Me.retObj.orderdetil_qty = qtys / days
            End If

            If Me.chkItemDescr.Checked Then
                Me.retObj.orderdetil_descr = Me.txtItemDescr.Text
            End If
        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()

    End Sub

    Private Sub dlgTrnRentalOrder_SelectDays_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        clsUtil.SetLocalization()

        Me.obj_RentalItem_id.DataBindings.Clear()
        Me.obj_Orderdetil_line.DataBindings.Clear()
        Me.obj_Orderdetil_descr.Clear()
        Me.obj_Orderdetil_qty.Clear()
        Me.obj_Orderdetil_idr.Clear()

        Me.obj_RentalItem_id.DataBindings.Add(New Binding("SelectedValue", Me.retObj, "item_id"))
        Me.obj_Orderdetil_line.DataBindings.Add(New Binding("Text", Me.retObj, "orderdetil_line"))
        Me.obj_Orderdetil_descr.DataBindings.Add(New Binding("Text", Me.retObj, "orderdetil_descr"))
        Me.obj_Orderdetil_qty.DataBindings.Add(New Binding("Text", Me.retObj, "orderdetil_qty", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Orderdetil_idr.DataBindings.Add(New Binding("Text", Me.retObj, "orderdetil_idr", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

        Me.dtp_Order_setdate.DataBindings.Add(New Binding("Value", Me.retObj, "order_setdate", True, DataSourceUpdateMode.OnPropertyChanged, Now(), "dd/MM/yyyy"))
        Me.dtp_Order_utilizeddatestart.DataBindings.Add(New Binding("Value", Me.retObj, "order_utilizeddatestart", True, DataSourceUpdateMode.OnPropertyChanged, Now(), "dd/MM/yyyy"))
        Me.dtp_Order_utilizeddateend.DataBindings.Add(New Binding("Value", Me.retObj, "order_utilizeddateend", True, DataSourceUpdateMode.OnPropertyChanged, Now(), "dd/MM/yyyy"))

        Me.tbl_trnOrderdetiluse.Columns("orderdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_trnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrement = True
        Me.tbl_trnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_trnOrderdetiluse.Columns("orderdetiluse_line").AutoIncrementStep = 10

        Me.tbl_trnOrderdetiluse.Columns("orderdetil_line").DefaultValue = retObj.orderdetil_line

        Me.FormatDgvTrnOrderdetiluse(Me.DgvOrderdetiluse)
        Me.DgvOrderdetiluse.DataSource = Me.tbl_trnOrderdetiluse
        Me.tbl_trnOrderdetiluse.DefaultView.RowFilter = String.Format("orderdetil_line={0}", retObj.orderdetil_line)
        Me.tbl_trnOrderdetiluse.DefaultView.Sort = "orderdetiluse_date"

        Me.btnGenerate_Click(Me, New System.EventArgs)


    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim i As Integer
        Dim rowFilter As String
        Dim rows() As DataRow
        Dim newrow As DataRow
        Dim mydate As Date = Me.dtp_Order_setdate.Value


        While Date.Compare(mydate.ToShortDateString, Me.dtp_Order_utilizeddateend.Value.ToShortDateString) <= 0
            'cek apakah tanggal ini di line ybs sudah ada
            rowFilter = String.Format("orderdetil_line={0} and orderdetiluse_date='{1}'", retObj.orderdetil_line, mydate.ToShortDateString)
            rows = Me.tbl_trnOrderdetiluse.Select(rowFilter)
            If rows.Length = 0 Then
                newrow = Me.tbl_trnOrderdetiluse.NewRow()
                newrow("orderdetiluse_date") = mydate.ToShortDateString
                newrow("orderdetiluse_descr") = retObj.orderdetil_descr
                newrow("orderdetiluse_qty") = retObj.orderdetil_qty
                newrow("orderdetiluse_idr") = retObj.orderdetil_idr
                Me.tbl_trnOrderdetiluse.Rows.Add(newrow)
            Else
                If sender.Name = "btnGenerate" Then
                    rows(0).Item("orderdetiluse_qty") = Me.obj_Orderdetil_qty.Text
                    rows(0).Item("orderdetiluse_idr") = Me.obj_Orderdetil_idr.Text
                Else
                    If rows(0).Item("orderdetiluse_idr") <> retObj.orderdetil_idr Then
                        rows(0).Item("orderdetiluse_idr") = retObj.orderdetil_idr
                    End If
                End If
            End If

            mydate = DateAdd(DateInterval.Day, 1, mydate)

        End While


        'potong tanggal sebelum Me.obj_Order_usagedatestart.Value
        rowFilter = String.Format("orderdetil_line={0} and orderdetiluse_date<'{1}'", retObj.orderdetil_line, Me.dtp_Order_setdate.Value.ToShortDateString) ''''.dtp_Order_utilizeddatestart.Value.ToShortDateString)
        rows = Me.tbl_trnOrderdetiluse.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_trnOrderdetiluse.Rows.Remove(rows(i))
        Next

        'potong tanggal setelah Me.obj_Order_usagedateend.Value
        rowFilter = String.Format("orderdetil_line={0} and orderdetiluse_date>'{1}'", retObj.orderdetil_line, Me.dtp_Order_utilizeddateend.Value.ToShortDateString)
        rows = Me.tbl_trnOrderdetiluse.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_trnOrderdetiluse.Rows.Remove(rows(i))
        Next

    End Sub

    Private Sub DgvOrderdetiluse_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim used As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)

        Try
            used = CType(objRow.Cells("orderdetiluse_checked").Value, Boolean)
            If used Then
                objRow.DefaultCellStyle.BackColor = Color.LightSteelBlue
                objRow.Cells("orderdetiluse_idr").Style.BackColor = Color.SlateGray
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
                objRow.Cells("orderdetiluse_idr").Style.BackColor = Color.Gainsboro
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub chkItemDescr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkItemDescr.CheckedChanged
        Dim i, j As Integer
        Dim chk As Boolean
        Dim tgl As String
        Dim descr As String

        j = 0
        descr = "Tgl: "
        If Me.chkItemDescr.Checked Then
            For i = 0 To Me.DgvOrderdetiluse.Rows.Count - 1
                tgl = Me.DgvOrderdetiluse.Rows(i).Cells("orderdetiluse_date").Value
                chk = Me.DgvOrderdetiluse.Rows(i).Cells("orderdetiluse_checked").Value
                If chk Then
                    j += 1
                    If j > 1 Then
                        descr &= ", "
                    End If
                    descr &= tgl
                End If
            Next
            Me.txtItemDescr.Text = "[" & descr & "]"
        Else
            Me.txtItemDescr.Text = ""
        End If
    End Sub

    Private Sub lnkCheckAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCheckAll.LinkClicked
        Dim i As Integer
        For i = 0 To Me.DgvOrderdetiluse.Rows.Count - 1
            Me.DgvOrderdetiluse.Rows(i).Cells("orderdetiluse_checked").Value = True
        Next
    End Sub

    Private Sub lnkClearAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClearAll.LinkClicked
        Dim i As Integer
        For i = 0 To Me.DgvOrderdetiluse.Rows.Count - 1
            Me.DgvOrderdetiluse.Rows(i).Cells("orderdetiluse_checked").Value = False
        Next
    End Sub

End Class