Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Public Class dlgQueryBuilderNew
    Dim retString As String
    Dim currentString As String

#Region " Constructor & Default Function"
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        MyBase.ShowDialog(owner)
        Return retString
    End Function
#End Region

    Public Function Init(ByVal query As String, ByVal dt As DataTable) As Boolean

        Me.currentString = query
        Me.txtQuery.Text = query

        Dim i As Integer
        For i = 0 To dt.Columns.Count - 1
            Me.listFields.Items.Add(dt.Columns(i).ColumnName)
        Next

        With Me.listOperator.Items
            .Add("=")
            .Add(">")
            .Add(">=")
            .Add("<")
            .Add("<=")
            .Add("Like '...%'")
            .Add("Like '%...'")
            .Add("Like '%..%'")
            .Add("Between")
        End With

        With Me.listLogical.Items
            .Add(" ")
            .Add("And")
            .Add("Or")
        End With

        Me.listFields.SelectedIndex = 0
        Me.listOperator.SelectedIndex = 0
        Me.listLogical.SelectedIndex = 0

    End Function

    Public Function InitFromGridView(ByVal query As String, ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean

        Me.currentString = query
        Me.txtQuery.Text = query

        'Dim i As Integer
        'For i = 0 To dt.Columns.Count - 1
        '    Me.ListFields.Items.Add(dt.Columns(i).ColumnName)
        'Next

        Dim i As Integer
        For i = 0 To GridView.Columns.Count - 1
            If GridView.Columns(i).Visible = True Then
                Me.ListFields.Items.Add(GridView.Columns(i).FieldName)
            End If
        Next

        With Me.ListOperator.Items
            .Add("=")
            .Add(">")
            .Add(">=")
            .Add("<")
            .Add("<=")
            .Add("Like '...%'")
            .Add("Like '%...'")
            .Add("Like '%..%'")
            .Add("Between")
        End With

        With Me.ListLogical.Items
            .Add(" ")
            .Add("And")
            .Add("Or")
        End With

        Me.ListFields.SelectedIndex = 0
        Me.ListOperator.SelectedIndex = 0
        Me.ListLogical.SelectedIndex = 0

    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim qbuilderrow As String = ""
        Try
            Select Case Me.ListLogical.Items(Me.ListLogical.SelectedIndex).ToString
                Case " "
                    qbuilderrow = " "
                Case "And"
                    qbuilderrow = " And "
                Case "Or"
                    qbuilderrow = " Or "
            End Select

            qbuilderrow &= Me.ListFields.Items(Me.ListFields.SelectedIndex).ToString

            Select Case Me.ListOperator.Items(Me.ListOperator.SelectedIndex).ToString
                Case "Like '...%'"
                    qbuilderrow &= " Like '%.' "
                Case "Like '%...'"
                    qbuilderrow &= " Like '.%' "
                Case "Like '%..%'"
                    qbuilderrow &= " Like '%.%' "
                Case "Between"
                    qbuilderrow &= " Between '' And '' "
                Case Else
                    qbuilderrow &= " " & Me.ListOperator.Items(Me.ListOperator.SelectedIndex).ToString & " '' "
            End Select

            Me.txtQuery.Text = Trim(Me.txtQuery.Text) & " " & qbuilderrow
            Me.ListLogical.SelectedIndex = 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Me.retString = Me.txtQuery.Text
        Me.Close()
    End Sub

    Private Sub ListFields_DoubleClick(sender As Object, e As EventArgs) Handles ListFields.DoubleClick
        Try
            Me.btnAdd_Click(Me.btnAdd, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        Me.txtQuery.Text = ""
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.retString = Me.currentString
        Me.Close()
    End Sub
End Class