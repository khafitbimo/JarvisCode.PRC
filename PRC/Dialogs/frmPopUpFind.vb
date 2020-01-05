Public Class frmPopUpFind
    Private m_sConn As String
    Private m_Key As String
    Private m_TitleForm As String
    Private m_OnFocusColumnIndex As Int16
    Private m_Clue As String
    Private m_ActiveColumn As String
    Private m_oDtBudgetAccount As DataTable
    Private m_alFoundRows As New ArrayList()

    Private m_oPopUpFind As PRC.clsPopUpFind

    Private tempDatatable As DataTable


    Private Sub FormatDgvMain()


        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.AllowUserToResizeRows = False
        Me.dgvMain.ReadOnly = True

        Me.dgvmain.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvMain.DefaultCellStyle.Font = New Font("Arial", 8)

        Me.dgvMain.EnableHeadersVisualStyles = False

        Me.dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.OldLace
        Me.dgvMain.MultiSelect = False

    End Sub

    Private Sub AnchorNDockingControl()

        Me.lblFind.Anchor = AnchorStyles.Left + AnchorStyles.Top
        Me.txtKeyWord.Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right


    End Sub

    Public Sub New(ByVal ConnString As String, ByVal Key As String, ByVal OnFocusColumnIndex As Int16, ByVal FormTitle As String, ByVal Clue As String, ByVal ParamArray oParCol() As Collection)
        'Public Sub New()
        Me.m_sConn = ConnString
        Me.m_Key = Key
        Me.m_OnFocusColumnIndex = OnFocusColumnIndex
        Me.m_TitleForm = FormTitle
        Me.m_Clue = Clue
        'Me.m_oDtBudgetAccount = New DataTable

        Me.m_oPopUpFind = New PRC.clsPopUpFind(m_sConn, m_Clue, oParCol)

        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ShowInTaskbar = False



    End Sub

    Private Sub frmPopUpFind_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AnchorNDockingControl()
        m_oPopUpFind.Key = m_Key
        m_oPopUpFind.formatColumns(Me.dgvMain)
        FormatDgvMain()

        Me.Text = Me.Text & m_TitleForm


        dgvMain.DataSource = m_oPopUpFind.getKeyDataTable()


    End Sub

    Private Sub txtKeyWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKeyWord.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If Me.dgvMain.RowCount > 0 Then
                    If dgvMain.CurrentRow.Index > 0 Then
                        Me.dgvMain.CurrentCell = Me.dgvMain.Rows(Me.dgvMain.CurrentRow.Index - 1).Cells(m_OnFocusColumnIndex)
                    End If
                End If
                SendKeys.Send("{RIGHT}")

            Case Keys.Down
                If Me.dgvMain.RowCount > 0 Then
                    If dgvMain.CurrentRow.Index < dgvMain.RowCount - 1 Then
                        Me.dgvMain.CurrentCell = Me.dgvMain.Rows(Me.dgvMain.CurrentRow.Index + 1).Cells(m_OnFocusColumnIndex)
                    End If
                End If
                SendKeys.Send("{LEFT}")

            Case Keys.Enter

                If Me.dgvMain.Rows.Count > 0 Then
                    Dim temp As Int16
                    temp = dgvMain.CurrentRow.Index
                    'dgvMain.Rows(temp)(m_OnFocusColumnIndex) = ""
                    clsUtil.gResult = dgvMain.Rows(Me.dgvMain.CurrentRow.Index).Cells(0).Value.ToString

                End If

                Me.Close()
                'Case Keys.Escape
                '    Me.Close()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub dgvMain_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellDoubleClick

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            clsUtil.gResult = dgvMain.Rows(e.RowIndex).Cells(0).Value.ToString
            Me.Close()
        End If

    End Sub


    Private Sub dgvMain_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvMain.RowPostPaint

        Using b As SolidBrush = New SolidBrush(dgvMain.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  dgvMain.DefaultCellStyle.Font, _
                                  b, _
                                  e.RowBounds.Location.X + 10, _
                                  e.RowBounds.Location.Y + 4)
        End Using


    End Sub

    Private Sub txtKeyWord_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKeyWord.TextChanged
        If txtKeyWord.Text = String.Empty Then
            Exit Sub
        End If

        Dim udataRow As DataGridViewRow
        For Each udataRow In dgvMain.Rows
            If UCase(udataRow.Cells(m_OnFocusColumnIndex).Value.ToString).StartsWith(UCase(txtKeyWord.Text)) Then
                dgvMain.CurrentCell = udataRow.Cells(m_OnFocusColumnIndex)
            End If
        Next

    End Sub

    Private Sub dgvMain_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellContentClick

    End Sub
End Class