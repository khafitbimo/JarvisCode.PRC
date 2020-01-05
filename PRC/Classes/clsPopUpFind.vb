Public Class clsPopUpFind
    Private m_DSN As String
    Private m_Key As String
    Private m_Clue As String
    Private oParcol() As Collection

    Public Property Key()
        Get
            Return m_Key
        End Get

        Set(ByVal value)
            m_Key = Trim(UCase(value))
        End Set
    End Property



    Public Sub formatColumns(ByRef dgv As DataGridView)
        Select Case m_Key
            Case "SLIP_FORMAT"
                Dim colID, colName, colLength As DataGridViewTextBoxColumn
                colID = clsUtil.CreateColumn("slipformat_id", "slipformat_id", "ID", "TXT12", DataGridViewContentAlignment.MiddleLeft)
                colName = clsUtil.CreateColumn("slipformat_name", "slipformat_name", "NAMA", "TXT25", DataGridViewContentAlignment.MiddleLeft)
                colLength = clsUtil.CreateColumn("slipformat_length", "slipformat_length", "PANJANG", "TXT7", DataGridViewContentAlignment.MiddleLeft)


                dgv.Columns.Clear()
                dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                {colID, colName, colLength})



        End Select
        dgv.AutoGenerateColumns = False
    End Sub

    Public ReadOnly Property getKeyDataTable(Optional ByVal GetColumnOnly As Boolean = False) As DataTable
        Get
            getKeyDataTable = New DataTable
            Select Case m_Key
                Case "SLIP_FORMAT"
                    Dim parCriteria As OleDb.OleDbParameter
                    parCriteria = New OleDb.OleDbParameter("@Criteria", OleDb.OleDbType.VarChar, 1020)
                    parCriteria.Value = " slipformat_isdisabled = 0 ORDER BY slipformat_name "
                    getKeyDataTable = clsUtil.GetDataTable("cp_MstSlipFormat_Select", m_DSN, parCriteria)


            End Select

            If GetColumnOnly Then
                getKeyDataTable.Clear()
            End If

            Return getKeyDataTable
        End Get
    End Property

    Public Sub New(ByVal DSN As String, ByVal Clue As String, ByVal ParamArray oParCol() As Collection)

        m_DSN = DSN
        m_Clue = Clue
        Me.oParcol = oParCol

    End Sub
End Class
