Public Class dlgSelectItem
    Private DSN As String
    'Private tbl_MstItem_all_temp As DataTable = clsDataset.CreateTblMstItem
    Private tbl_MstItem_all_tempCategory As DataTable = clsDataset.CreateTblMstItemCategory
    Private tbl_MstItem_all_tempCategoryGroup As DataTable = clsDataset.CreateTblMstItemcategorygroup
    Private tbl_MstItem_all_temp As DataTable = clsDataset.CreateTblMstItem
    'Private tbl_TrnRequestDetil As DataTable = clsDataset.CreateTblTrnRequestdetil
    Private retRow() As DataRow
    Private criteria As String
    Private CloseButtonIsPressed As Boolean

#Region "Class"

    Public Class clsItem
        Private item_id As String
        Private item_name As String

        Public Property id() As String
            Get
                Return item_id
            End Get
            Set(ByVal value As String)
                item_id = value
            End Set
        End Property

        Public Property name() As String
            Get
                Return item_name
            End Get
            Set(ByVal value As String)
                item_name = value
            End Set
        End Property
    End Class

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvMstItem(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCategory_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "item_selected"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Visible = True
        cSelect.ReadOnly = False

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "ID"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 70
        cItem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cItem_id.Visible = False
        cItem_id.ReadOnly = True

        cItem_line.Name = "item_line"
        cItem_line.HeaderText = "Line"
        cItem_line.DataPropertyName = "item_line"
        cItem_line.Width = 50
        cItem_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cItem_line.Visible = False
        cItem_line.ReadOnly = True

        cItem_name.Name = "item_name"
        cItem_name.HeaderText = "Name"
        cItem_name.DataPropertyName = "item_name"
        cItem_name.Width = 245
        cItem_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_name.Visible = True
        cItem_name.ReadOnly = True

        cItem_descr.Name = "item_descr"
        cItem_descr.HeaderText = "Description"
        cItem_descr.DataPropertyName = "item_descr"
        cItem_descr.Width = 158
        cItem_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_descr.Visible = True
        cItem_descr.ReadOnly = True

        cCategory_id.Name = "category_id"
        cCategory_id.HeaderText = "Category ID"
        cCategory_id.DataPropertyName = "category_id"
        cCategory_id.Width = 100
        cCategory_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCategory_id.Visible = False
        cCategory_id.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cItem_id, cItem_line, cItem_name, cItem_descr, cCategory_id})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
    End Function

    Private Function BindingStop() As Boolean
        Try
            'Me.GroupBox1.DataBindings.Clear()
            Me.obj_item_name.DataBindings.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function BindingStart() As Boolean
        Try
            ' Me.GroupBox1.DataBindings.Add(New Binding("Enabled", Me.rbGroup, "Checked"))
            ' Me.obj_item_name.DataBindings.Add(New Binding("Enabled", Me.rbName, "Checked"))
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function InitLayoutUI() As Boolean
        Try
            Me.DgvMstItem.DataSource = Me.tbl_MstItem_all_temp
            Me.FormatDgvMstItem(Me.DgvMstItem)

            Me.BindingStop()
            Me.BindingStart()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

#End Region

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim criteria = ""
        'Dim i As Integer
        'Dim key(0) As DataColumn

        Me.tbl_MstItem_all_temp.Clear()
        Try
            Me.tbl_MstItem_all_temp.Columns.Add(New DataColumn("item_selected", GetType(System.Boolean)))
            Me.tbl_MstItem_all_temp.Columns("item_selected").DefaultValue = False
        Catch ex As Exception
        End Try

        'criteria = String.Format("item_name <> '' and item_name not like '-%' AND is_active = 1")

        'oDataFiller.ComboFill(Me.obj_item_group, "group_id", "group_name", Me.tbl_MstItem_all_tempCategoryGroup, "pr_MstItemcategorygroup_Select", "")
        'Me.tbl_MstItem_all_tempCategoryGroup.DefaultView.Sort = "group_name"
        'oDataFiller.ComboFill(Me.obj_item_category, "category_id", "category_name", Me.tbl_MstItem_all_tempCategory, "pr_MstItemCategory_Select", "")
        'Me.tbl_MstItem_all_tempCategory.DefaultView.Sort = "category_name"
        oDataFiller.DataFill(Me.tbl_MstItem_all_temp, "pr_MstItemCluster2_Select", criteria)
        Me.tbl_MstItem_all_temp.DefaultView.Sort = "item_name"

        'key(0) = Me.tbl_MstItem_all_temp.Columns("item_id")
        'Me.tbl_MstItem_all_temp.PrimaryKey = key
        'For i = 0 To Me.tbl_TrnRequestDetil.Rows.Count - 1
        '    Me.tbl_MstItem_all_temp.Rows.Find(Me.tbl_TrnRequestDetil.Rows(i).Item("item_id")).Delete()
        'Next

        Me.InitLayoutUI()

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.retRow
        Else
            Return Nothing
        End If

    End Function

#End Region

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Dim obj As Button = sender

        If obj.Name = "btnOK" Then
            If Me.tbl_MstItem_all_temp.Rows.Count > 0 Then
                retRow = Me.tbl_MstItem_all_temp.Select("item_selected = True")
            End If

            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()
    End Sub

    Private Sub DgvMstItem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvMstItem.CellFormatting
        Dim selected As Boolean
        Dim objRow As System.Windows.Forms.DataGridViewRow = DgvMstItem.Rows(e.RowIndex)

        Try
            selected = CBool(objRow.Cells("select").Value)
            If selected Then
                objRow.DefaultCellStyle.BackColor = Color.MistyRose
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal criteria As String)
        InitializeComponent()
        Me.DSN = strDSN
        Me.criteria = criteria
    End Sub

    Private Sub obj_item_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criteria As String = String.Empty

        'If rbGroup.Checked Then
        '    criteria = String.Format("group_id = '{0}'", Me.obj_item_group.SelectedValue)
        '    If Me.cb_item_category.Checked Then
        '        criteria &= String.Format(" AND category_id = '{0}'", Me.obj_item_category.SelectedValue)
        '    End If
        '    Me.tbl_MstItem_all_temp.DefaultView.RowFilter = criteria
        'End If
    End Sub

    'Private Sub cb_item_category_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim criteria As String = String.Empty

    '    If rbGroup.Checked Then
    '        criteria = String.Format("group_id = '{0}'", Me.obj_item_group.SelectedValue)
    '        If Me.cb_item_category.Checked Then
    '            criteria &= String.Format(" AND category_id = '{0}'", Me.obj_item_category.SelectedValue)
    '        End If
    '        Me.tbl_MstItem_all_temp.DefaultView.RowFilter = criteria
    '    End If
    'End Sub

    'Private Sub obj_item_group_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim criteria As String

    '    If Me.rbGroup.Checked Then
    '        criteria = String.Format("group_id = '{0}'", obj_item_group.SelectedValue)
    '        Me.tbl_MstItem_all_tempCategory.DefaultView.RowFilter = criteria
    '        Try
    '            Me.obj_item_category.SelectedIndex = 0
    '        Catch ex As Exception
    '        End Try

    '        If Me.cb_item_category.Checked Then
    '            criteria &= String.Format(" AND category_id = '{0}'", obj_item_category.SelectedValue)
    '        End If
    '        Me.tbl_MstItem_all_temp.DefaultView.RowFilter = criteria
    '    End If
    'End Sub

    'Private Sub rbGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim criteria As String

    '    If Me.rbGroup.Checked Then
    '        SendKeys.Send("{TAB}")

    '        criteria = String.Format("group_id = '{0}'", obj_item_group.SelectedValue)
    '        Me.tbl_MstItem_all_tempCategory.DefaultView.RowFilter = criteria
    '        Try
    '            Me.obj_item_category.SelectedIndex = 0
    '        Catch ex As Exception
    '        End Try

    '        If Me.cb_item_category.Checked Then
    '            criteria &= String.Format(" AND category_id = '{0}'", obj_item_category.SelectedValue)
    '        End If
    '        Me.tbl_MstItem_all_temp.DefaultView.RowFilter = criteria
    '    End If
    'End Sub

    'Private Sub rbName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim criteria As String

    '    If Me.rbName.Checked Then
    '        SendKeys.Send("{TAB}")

    '        criteria = String.Format("item_name LIKE '%{0}%'", obj_item_name.Text)
    '        Me.tbl_MstItem_all_temp.DefaultView.RowFilter = criteria
    '    End If
    'End Sub

    Private Sub obj_item_name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_item_name.TextChanged
        Dim criteria As String

        'If Me.rbName.Checked Then
        criteria = String.Format("item_name LIKE '%{0}%'", obj_item_name.Text)
        Me.tbl_MstItem_all_temp.DefaultView.RowFilter = criteria
        'End If
    End Sub
End Class