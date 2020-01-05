Public Class dlgSelectItem2
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
    Property item_name() As String
        Get
            Return Me.txtItemName.Text
        End Get
        Set(ByVal Value As String)
            txtItemName.Text = Value
        End Set
    End Property
    Property item_desc() As String
        Get
            Return Me.txtItemDesc.Text
        End Get
        Set(ByVal Value As String)
            Me.txtItemDesc.Text = Value
        End Set
    End Property
#End Region

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object  
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
            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()
    End Sub
    Public Sub New(ByVal strDSN As String, ByVal criteria As String)
        InitializeComponent()
        Me.DSN = strDSN
        Me.criteria = criteria
    End Sub
End Class